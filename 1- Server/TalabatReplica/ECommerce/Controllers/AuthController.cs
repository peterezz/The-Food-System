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

                //return Ok(result);

            // using anonymus obj to return specific data from result

            return Ok(new { Authenticated = result.IsAuthenticated, Username = result.Username, Email = result.Email, Token = result.Token, Roles=result.Roles  , ExpiresOn = result.ExpiresOn });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            //return Ok(result);

            // if need to return specific data from result ==> using anonymus obj

            return Ok(new { Auth = result.IsAuthenticated, us = result.Username, token = result.Token, Roles = result.Roles, exp = result.ExpiresOn, email = result.Email });
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

    }
}
