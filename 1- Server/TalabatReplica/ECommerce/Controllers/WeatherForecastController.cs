using ECommerce.BAL.DTOs;
using ECommerce.BAL.Managers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[ ] Summaries = new[ ]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TestManager _manager;

        public WeatherForecastController( ILogger<WeatherForecastController> logger , TestManager manager )
        {
            _logger = logger;
            this._manager = manager;
        }


        [HttpGet( Name = "Test" )]
        public async Task<IEnumerable<TestDto>> Test( )
        {
            return await _manager.GetAllTests( );
        }
    }
}