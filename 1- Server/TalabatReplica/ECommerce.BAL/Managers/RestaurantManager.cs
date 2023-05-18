using AutoMapper;
using ECommerce.BAL.DTOs;
using ECommerce.BAL.Repository;
using ECommerce.BAL.Repository.Interfaces;
using ECommerce.DAL.Manager;
using ECommerce.DAL.Models;

namespace ECommerce.BAL.Managers
{
    public class RestaurantManager : BaseRepo<Resturant>, IRestaurantRepo
    {
        private readonly IMapper _mapper;

        public RestaurantManager( ApplicationDbContext context , IMapper mapper ) : base( context )
        {
            _mapper = mapper;
        }

        public async Task<RestaurantDto> CreateRestaurantAsync( RestaurantDto restaurantDto )
        {

            restaurantDto.Poster = await FileManager.UploadFileAsync( restaurantDto.PosterFile );
            var data = _mapper.Map<Resturant>( restaurantDto );
            await AddAsync( data );
            restaurantDto.RestaurantID = data.RestaurantID;
            return restaurantDto;

        }
        public async Task DeleteRestaurantAsync( RestaurantDto restaurantDto )
        {

            var data = _mapper.Map<Resturant>( restaurantDto );
            await RemoveAsync( data );

        }
        public async Task UpdateRestaurantAsync( RestaurantDto restaurantDto )
        {
            var data = _mapper.Map<Resturant>( restaurantDto );
            await UpdateAsync( data );
        }
        public async Task<List<RestaurantDto>> GetRestaurantsAsync( )
        {
            var data = await GetAllAsync( );
            return _mapper.Map<List<RestaurantDto>>( data );
        }
        public async Task<RestaurantDto> GetResturentByIDAsync( int resID )
        {
            var data = await GetByIdAsync( resID );
            return _mapper.Map<RestaurantDto>( data );
        }

        public async Task<bool> FindRestaurantByAdminID( string adminID ) => await FirstOrDefaultAsync( res => res.ResAdminID.Equals( adminID ) ) != null;

    }
}
