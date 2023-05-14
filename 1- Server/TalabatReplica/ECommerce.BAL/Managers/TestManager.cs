using AutoMapper;
using ECommerce.BAL.DTOs;
using ECommerce.BAL.Repository;
using ECommerce.DAL.Models;

namespace ECommerce.BAL.Managers
{
    public class TestManager : BaseRepo<Test>
    {
        private readonly IMapper _mapper;

        public TestManager( ApplicationDbContext context , IMapper mapper ) : base( context )
        {
            _mapper = mapper;
        }
        public async Task<List<TestDto>> GetAllTests( )
        {
            var data = await GetAll( );
            return _mapper.Map<List<TestDto>>( data );
        }
    }
}
