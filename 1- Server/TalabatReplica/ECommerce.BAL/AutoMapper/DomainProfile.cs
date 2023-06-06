using AutoMapper;
using ECommerce.BAL.DTOs;
using ECommerce.DAL.Models;

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
            CreateMap<Order, orderDto>().ReverseMap();
        }
    }
}
