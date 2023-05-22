using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecuredController : ControllerBase
    {
        [HttpGet("Check")]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Welcome in refresh token tester");
        }
    }
}
