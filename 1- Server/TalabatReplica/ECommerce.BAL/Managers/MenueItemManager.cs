using AutoMapper;
using ECommerce.BAL.DTOs;
using ECommerce.BAL.Repository;
using ECommerce.DAL.Models;

namespace ECommerce.BAL.Managers
{
    public class MenueItemManager : BaseRepo<MenuItem>
    {
        private readonly IMapper mapper;

        public MenueItemManager( ApplicationDbContext context , IMapper mapper ) : base( context )
        {
            this.mapper = mapper;
        }

        public async Task<List<MenueItemDto>> GetAll_MenueItemAsync( )
        {
            var data = await GetAllAsync( );
            return mapper.Map<List<MenueItemDto>>( data );
        }
        public async Task<MenueItemDto> GetById_MenueItemAsync( int id )
        {
            var data = await GetByIdAsync( id );
            return mapper.Map<MenueItemDto>( data );
        }
        public async Task Delete_MenueItemAsync( int id )
        {
            MenuItem menue = await GetByIdAsync( id ); ;
            // var data = mapper.Map<menue>(dto);
            await RemoveAsync( menue );


        }

        
        public async Task<MenueItemDto> Add_MenueItem( MenueItemDto dto )
        {
            var data = mapper.Map<MenuItem>( dto );
            await AddAsync( data );
            return dto;
        }
        public async Task<MenueItemDto> update_MenueItem( MenueItemDto dto , int id )
        {
            var data = mapper.Map<MenuItem>( dto );
            await UpdateAsync( data );
            return dto;
        }
        public async Task<List<MenueItemDto>> GetCategoryItemsAsync( string name )
        {
            return mapper.Map<List<MenueItemDto>>( await GetWhereAsync( cat => cat.Name == name , ca => ca.category ) );
        }

        public async Task<List<MenueItemDto>> GetTopMenuItemsAsync( int ResID )
        {
            var data = await GetWhereAsync( item => item.IsTopItem && item.ResturantID == ResID && item.IsAccepted );
            return mapper.Map<List<MenueItemDto>>( data );
        }
    }
}

