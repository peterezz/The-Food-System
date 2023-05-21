using AutoMapper;
using ECommerce.BAL.DTOs;
using ECommerce.BAL.Repository;
using ECommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BAL.Managers
{
    public class MenueItemManager : BaseRepo<MenuItem>
    {
        private readonly IMapper mapper;

        public MenueItemManager(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<List<MenueItemDto>> GetAll_MenueItemAsync()
        {
            var data = await GetWhereAsync(null, o=>o.Orders,Cart=>Cart.Carts);
            return mapper.Map<List<MenueItemDto>>(data);

        }
        public async Task<MenueItemDto> GetById_MenueItemAsync(int id)
        {
            var data = await FirstOrDefaultAsync(m =>m.ItemID==id, o => o.Orders, Cart => Cart.Carts);
        
            return mapper.Map<MenueItemDto>(data);

        }
        public async Task Delete_MenueItemAsync(int id)
        {
            MenuItem menue = await GetByIdAsync(id); ;
            // var data = mapper.Map<menue>(dto);
            await RemoveAsync(menue);


        }
         public async Task<MenueItemDto> Add_MenueItem(MenueItemDto dto)
         {
          
            var data= mapper.Map<MenuItem>(dto);
             await AddAsync(data);
            return dto;
             

         }
        public async Task<MenueItemDto> update_MenueItem(MenueItemDto dto,int id)
        {
            var data = mapper.Map<MenuItem>(dto);
            await UpdateAsync(data);
            return dto;


        }
    }
}

