using Microsoft.AspNetCore.Identity;
using SampleCleanArchProject.Domain.Account;

namespace SampleCleanArchProject.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> usermanager)
        {
            this._roleManager = roleManager;
            this._userManager = usermanager;
        }
        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "USER"
                };

                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };

                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if(_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "usuario@localhost",
                    Email = "usuario@localhost",
                    NormalizedEmail = "USUARIO@LOCALHOST",
                    NormalizedUserName = "USUARIO@LOCALHOST",
                    EmailConfirmed =  true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(user, "DummyPwd@2025").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "User").Wait();
                
            }


            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                ApplicationUser admin = new ApplicationUser()
                {
                    UserName = "admin@localhost",
                    Email = "admin@localhost",
                    NormalizedEmail = "ADMIN@LOCALHOST",
                    NormalizedUserName = "ADMIN@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(admin, "DummyPwd@2025").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(admin, "Admin").Wait();

            }
        }
    }
}