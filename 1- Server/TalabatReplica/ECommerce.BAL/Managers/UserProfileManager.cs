using AutoMapper;
using ECommerce.BAL.DTOs;
using ECommerce.BAL.Mapper;
using ECommerce.BAL.Repository;
using ECommerce.DAL.Models;
using ECommerce.DAL.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.JSInterop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BAL.Managers
{
    public class UserProfileManager : BaseRepo<ApplicationUser>
    {
        public UserProfileManager(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper) : base(context)
        {
            Context = context;
            UserManager = userManager;
            Mapper = mapper;
        }

        public ApplicationDbContext Context { get; }
        public UserManager<ApplicationUser> UserManager { get; }
        public IMapper Mapper { get; }

        public async Task<ProfileUserDto> UpdateProfile(string id,ProfileUserDto userDto)
        {
            var user = UserManager.FindByIdAsync(id);
            var data = Mapper.Map<ApplicationUser>(userDto);
            await UserManager.UpdateAsync(data);
          //  Context.SaveChanges();
             return userDto;

        }
    }

  
}
