using ECommerce.DAL.Models.IdentityModels;
using ECommerce.DAL.Reposatory.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Web.WebPages.Html;

namespace ECommerce.API.Controllers
{
    public class AuthController : ControllerBase
    {
          public IAouthRepo _authService { get; }


            public AuthController(IAouthRepo aouthRepo)
            {
                _authService = aouthRepo;
            }

            [HttpPost("Register")]
        
            public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _authService.RegisterAsync(model);

                if (!result.IsAuthenticated)
                    return BadRequest(result.Message);
                
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            //return Ok(result);

            // using anonymus obj to return specific data from result

            return Ok(new { Authenticated = result.IsAuthenticated, Username = result.Username, Email = result.Email, Token = result.Token, Roles=result.Roles  , RefreshTokenExpiration = result.RefreshTokenExpiration });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            // in case token not null , empty add this on cookie
            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            //return Ok(result);

            // if need to return specific data from result ==> using anonymus obj

            return Ok(new { Auth = result.IsAuthenticated, us = result.Username, token = result.Token, Roles = result.Roles, RefreshTokenExpiration=result.RefreshTokenExpiration , email = result.Email });
        }


        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);

        }

        //add token on cookie 
        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime() 
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions); 
        }

        // get refresh token 
        [HttpGet("RefreshToken")]
        public async Task<IActionResult> GetRefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var result = await _authService.RefreshTokenASync(refreshToken);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }

        [HttpPost ("RevokeToken")] // create DTO to store refresh token which recieved from request 
        public async Task<IActionResult> RevokeToken([FromBody] RevokeModel revoke )
        {
            // in case token == null i.e user not send it then get it from cookies
            var token = revoke.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token Is Required");

            //in case the user already send token or his token exist in cookies then revoke his token from authmodel
            var result =await _authService.RevokeTokenAsync(token);

            if(!result)
                return BadRequest("token is Invalid");

            return Ok();

        }

    }
}
