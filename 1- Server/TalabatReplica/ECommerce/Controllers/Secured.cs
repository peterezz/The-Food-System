//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ECommerce.API.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class Secured : ControllerBase
//    {
//        [HttpGet]
//        [Authorize(Roles = "customer")]
//        public IActionResult Get()
//        {
//            return Ok("Welcome in refresh token tester");
//        }
//    }
//}
