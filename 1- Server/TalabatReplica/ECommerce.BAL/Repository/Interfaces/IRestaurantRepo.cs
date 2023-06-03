using ECommerce.BAL.DTOs;

namespace ECommerce.BAL.Repository.Interfaces
{
    public interface IRestaurantRepo
    {
        Task<RestaurantDto> CreateRestaurantAsync( RestaurantDto restaurantDto );
        Task DeleteRestaurantAsync( RestaurantDto restaurantDto );
        Task UpdateRestaurantAsync( RestaurantDto restaurantDto );
        Task<List<RestaurantDto>> GetRestaurantsAsync( );
        Task<RestaurantDto> GetResturentByIDAsync( int resID );
        Task<bool> FindRestaurantByAdminID( string adminID );
        Task<RestaurantDto> GetResturentByNameAsync( string resName );
        Task<RestaurantDto> GetRestaurantByAdminIDAsync( string resAdminID );
        //Task<List<RestaurantDto>> GetRestaurantPagesAsync(int Page, int pageSize);

    }
}
