﻿using ECommerce.DAL.Models.IdentityModels;
using ECommerce.DAL.Reposatory.Repo;
using ECommerce.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Reposatory.RepoServices
{
    public class IAuthServices : IAouthRepo
    {
     
        public UserManager<ApplicationUser> UserManager { get; } // use this to check about register data recieved from user
        public RoleManager<IdentityRole> _roleManager { get; }

        private readonly JWTData _jwt;
        public IAuthServices(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> role, IOptions<JWTData> jwt)
        {
            UserManager = userManager;
            _roleManager = role;
            _jwt = jwt.Value;
        }


        public async Task<AuthModel> RegisterAsync(RegisterModel register)
        {
            //Firstly need to cheack about email, username, .. already exist in db or not befor approve it

            if (await UserManager.FindByEmailAsync(register.Email) != null)
                return new AuthModel { Message = "Email already registered" };


            if (await UserManager.FindByEmailAsync(register.Username) != null)
                return new AuthModel { Message = "User Name already exist" };

            // in case email , username not exist then add new user
            var user = new ApplicationUser
            {
                UserName = register.Username,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,

            };

            var result = await UserManager.CreateAsync(user ,register.Password); // create user in db

            if (!result.Succeeded)
            {

                var error = string.Empty;

                foreach (var item in result.Errors)
                {
                    error += $"{item.Description}\n";
                }

                return new AuthModel { Message = $"Registration field, try again later \n {error}" };
            }

            //assign role to user 
            await UserManager.AddToRoleAsync(user, "Customer"); // AddToRoleAsync(object from applicationuser , rolename)

            // return token details to user
            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthModel
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "Customer" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };

        }
    


        //function to add claims and  create token for user
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await UserManager.GetClaimsAsync(user);  // get all claims already exist for thes user
            var roles = await UserManager.GetRolesAsync(user);  // get all roles for thes user
            var roleClaims = new List<Claim>(); //list of claims to add clamis for each role

            //adding claims of each role to the list 
            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            //define new claims if required
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            //merge all claims "ald , new" for these user
            .Union(userClaims) // old claims
            .Union(roleClaims); // new claims

            //var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key)); //generate security key by using Key Defined in .json file

            //var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256); // generate SigningCredentials using SymmetricSecurityKey 

            //values using when jwt token "property defined in JWT class and binding data from json file to it"
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays));
            //signingCredentials: signingCredentials
            //);

            return jwtSecurityToken;
        }

        // get token to check about user to Login 
        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await UserManager.FindByEmailAsync(model.Email); //check emai; exist or not


            //if email not exist or password is wrong return message
            if (user is null || !await UserManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);

            var rolesList = await UserManager.GetRolesAsync(user); // get all roles of this user

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;
        }

        //assine specific role to specific user 
        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await UserManager.FindByIdAsync(model.UserId);

            // check user and role existance
            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            // check the role if already exist with this user or not bfor assign it to user
            if (await UserManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            // assigne role which recieved from controler to user hav an id which recieved
            var result = await UserManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Something went wrong";
        }

    }
}

