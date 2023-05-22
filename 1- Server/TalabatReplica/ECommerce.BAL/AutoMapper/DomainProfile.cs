using AutoMapper;
using ECommerce.BAL.DTOs;
using ECommerce.DAL.Models;
using ECommerce.DAL.Models.IdentityModels;

namespace ECommerce.BAL.Mapper
{
    internal class DomainProfile : Profile
    {
        public DomainProfile( )
        {
            CreateMap<Test , TestDto>( ).ReverseMap( );
            CreateMap<MenuItem, MenueItemDto>().ReverseMap();
            CreateMap<Category , CategoryDto>( ).ReverseMap( );
            CreateMap<Resturant , RestaurantDto>( ).ReverseMap( );
            CreateMap<ApplicationUser,ProfileUserDto>().ReverseMap( );
            CreateMap<Cart, CartDto>().ReverseMap();

        }
    }
}
