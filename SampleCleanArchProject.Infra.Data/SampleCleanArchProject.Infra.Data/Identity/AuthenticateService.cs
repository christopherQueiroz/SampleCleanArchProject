using Microsoft.AspNetCore.Identity;
using SampleCleanArchProject.Domain.Account;

namespace SampleCleanArchProject.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticateService(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> usermanager)
        {
            this._signInManager = signInManager;
            this._userManager = usermanager;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task Logout() => await _signInManager.SignOutAsync(); 

        public async Task<bool> Register(string email, string password)
        {
            var appUser = new ApplicationUser()
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(appUser, password);

            if (result.Succeeded)
                await _signInManager.SignInAsync(appUser, isPersistent: false);

            return result.Succeeded;
        }
    }
}