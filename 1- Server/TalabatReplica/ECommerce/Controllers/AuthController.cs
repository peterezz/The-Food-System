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

            [HttpPost("register")]
        
            public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _authService.RegisterAsync(model);

                if (!result.IsAuthenticated)
                    return BadRequest(result.Message);

                return Ok(result);
            }

    }
}
