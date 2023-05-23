using AutoMapper;
using ECommerce.BAL.DTOs;
using ECommerce.DAL.Enums;
using ECommerce.DAL.Models;
using ECommerce.DAL.Models.IdentityModels;
using ECommerce.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BAL.Managers
{
    public class resAdminManager
    {
        private readonly ApplicationDbContext context;

        //get all
        //getByid (detaials)
        //delete
        //update
        //add or Confirm
        private readonly UserManager<ApplicationUser> userman;

        public resAdminManager(ApplicationDbContext context,UserManager<ApplicationUser> userman,IMapper mapper)
        {
            this.context = context;
            this.userman = userman;
            Mapper = mapper;
        }


        public IMapper Mapper { get; }



      
        public async Task<List<ResAdminConfirmDto>> getAllResAdmin()

        { 

      //   var users = await userman.Users.Where(U=>U.EmailConfirmed==false).ToListAsync();

            var usersInRole = await userman.GetUsersInRoleAsync(nameof(Roles.ResturantAdmin));
            var userss =  usersInRole.Where(u=>u.EmailConfirmed==false).ToList();
            return Mapper.Map<List<ResAdminConfirmDto>>(userss);
        }

        public async Task DeleteResAdmin(String id)
        {
          
                
            var user = await userman.FindByIdAsync(id);
            var result = await userman.DeleteAsync(user);


        }

        public async Task<ResAdminConfirmDto> GetAdminById(string id)
        {
            return Mapper.Map<ResAdminConfirmDto>( await userman.FindByIdAsync(id));
        }

        public async Task<ResAdminConfirmDto> updateResAdmin(ResAdminConfirmDto dto)
        {
            var user = userman.FindByIdAsync(dto.id).Result;
            user.Email=dto.Email;
            user.FirstName=dto.FirstName;  
            user.LastName=dto.LastName;
            user.EmailConfirmed = dto.EmailConfirm;
         //   var data = Mapper.Map<ApplicationUser>(dto);
            
            await userman.UpdateAsync(user);
           // await context.SaveChangesAsync();
            return dto;

        }


    }
}
