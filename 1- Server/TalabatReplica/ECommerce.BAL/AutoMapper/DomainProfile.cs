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
            CreateMap<Category , CategoryDto>( ).ReverseMap( );
        }
    }
}
