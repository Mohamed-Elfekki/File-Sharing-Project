using AutoMapper;
using AutoMapper.QueryableExtensions;
using FileSharingProject.Areas.Admin.Models;
using FileSharingProject.Constants;
using FileSharingProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FileSharingProject.Areas.Admin.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }



        public async Task<OperationResult> ToggleBlockUserAsync(string userId)
        {
            var existedUser = await context.Users.FindAsync(userId);
            if (existedUser == null)
            {
                return OperationResult.NotFound();
            }
            existedUser.IsBlocked = !existedUser.IsBlocked;
            context.Update(existedUser);
            await context.SaveChangesAsync();
            return OperationResult.Succeeded();
        }

        public IQueryable<AdminUserViewModel> GetAll()
        {
            var result = context.Users
                .ProjectTo<AdminUserViewModel>(mapper.ConfigurationProvider);
            return result;

        }

        public IQueryable<AdminUserViewModel> GetBlockedUsers()
        {
            var result = context.Users.Where(u => u.IsBlocked)
                .ProjectTo<AdminUserViewModel>(mapper.ConfigurationProvider);
            return result;
        }

        public IQueryable<AdminUserViewModel> Search(string term)
        {
            var result = context.Users.Where(u => u.Email == term
            || u.FirstName.Contains(term) || u.LastName.Contains(term)
            //  || term.Contains(u.FirstName) || term.Contains(u.LastName)
            || (u.FirstName + " " + u.LastName).Contains(term))
                           .ProjectTo<AdminUserViewModel>(mapper.ConfigurationProvider);
            return result;
        }

        public async Task<int> UserRegistrationCountAsync()
        {
            var count = await context.Users.CountAsync();
            return count;
        }

        public async Task<int> UserRegistrationCountAsync(int month)
        {
            var year = DateTime.Today.Year;
            var count = await context.Users
                .CountAsync(u => u.CreatedDate.Month == month && u.CreatedDate.Year == year);
            return count;
        }

        public async Task IntializeAsync()
        {
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }

            var adminEmail = "admin@a.com";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var user = new ApplicationUser
                {

                    Email = adminEmail,
                    UserName = adminEmail,
                    PhoneNumber = "05344333334",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };
                await userManager.CreateAsync(user, "S3@mtwc!n9BD");
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
        }
    }
}
