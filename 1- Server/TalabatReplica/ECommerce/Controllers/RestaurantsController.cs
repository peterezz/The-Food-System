using ECommerce.BAL.DTOs;
using ECommerce.BAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace ECommerce.API.Controllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepo restaurantManager;

        public RestaurantsController( IRestaurantRepo restaurantManager )
        {
            this.restaurantManager = restaurantManager;
        }
        // GET: RestaurantsController
        [HttpGet( Name = "GetAllRestaurants" )]
        public async Task<IActionResult> Index( )
        {
            var data = await restaurantManager.GetRestaurantsAsync( );
            if ( data.Count == 0 )
                return Ok( "No Restaurants found yet!" );
            return Ok( data );
        }

        // GET: RestaurantsController/Details/5
        [HttpGet( "{id:int}" , Name = "RestaurantDetails" )]
        public async Task<IActionResult> Details( int id )
        {
            if ( id <= 0 )
                return BadRequest( "Not Valid ID" );
            var data = await restaurantManager.GetResturentByIDAsync( id );
            if ( data == null )
                return NotFound( "Restaurant not found" );
            return Ok( data );
        }

        // GET: RestaurantsController/Create
        [HttpPost( Name = "CreateRestaurant" )]
        public async Task<IActionResult> Create( [FromForm] RestaurantDto restaurantDto )
        {
            if ( !ModelState.IsValid )
                return BadRequest( ModelState );
            if ( await restaurantManager.FindRestaurantByAdminID( restaurantDto.ResAdminID ) )
                return BadRequest( "Request is rejected as already registered a restaurant to the system" );
            var data = await restaurantManager.CreateRestaurantAsync( restaurantDto );
            return CreatedAtAction( nameof( Details ) , new { id = data.RestaurantID } , data );
        }
        [HttpPut( "{id:int}" )]
        public async Task<IActionResult> EditRestaurant( [FromHeader] int id , [FromForm] RestaurantDto restaurantDto )
        {
            if ( id != restaurantDto.RestaurantID )
                return BadRequest( "Request not valid!" );
            if ( !ModelState.IsValid )
                return BadRequest( ModelState );
            if ( await restaurantManager.GetResturentByIDAsync( id ) == null )
                return NotFound( "Restaurant not found!" );
            await restaurantManager.UpdateRestaurantAsync( restaurantDto );
            return Ok( "Successful Update" );
        }
        [HttpDelete( "{id:int}" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRestaurant( int id )
        {

            if ( !ModelState.IsValid )
                return BadRequest( ModelState );
            var data = await restaurantManager.GetResturentByIDAsync( id );
            if ( data == null )
                return NotFound( "Restaurant not found!" );
            await restaurantManager.DeleteRestaurantAsync( data );
            return Ok( "Successful Delete" );

        }

    }
}
