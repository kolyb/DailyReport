using Azure.Messaging;
using DailyReport.BusinessLogic.Interfaces.IdentityInterface;
using DailyReport.BusinessLogic.ModelsDTO.IdentityDTO;
using DailyReport.DataAccess.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace DailyReport.BusinessLogic.Servicies.IdentityService
{
    public class UserIdentityService : IUserIdentity
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserIdentityService(UserManager<UserIdentity> userManager,
            SignInManager<UserIdentity> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }

            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
        //Registration
        public async Task CreateAsync(UserIdentityDTO item)
        {
            if (item == null)
            {
                throw new Exception("There is no current user!");
            }

            if (item.Id != null)
            {
                throw new Exception("User is already consits");
            }

            //var user = await _userManager.FindByIdAsync(item.Id);          

            if (item.Password == null)
            {
                throw new Exception("There is no current user!");
            }

            var user = new UserIdentity
            {
                PasswordHash = HashPassword(item.Password),
                Email = item.Email,
                UserName = item.Email,
            };
           
            await _userManager.CreateAsync(user);
        }

        //Log in
        public async Task<SignInResult> Authenticate(UserIdentityDTO item)
        {
            if (item == null)
            {
                //this class inherits from ApplicationException
                throw new ValidationException("Can not find entity");
            }

            UserIdentity user = new UserIdentity
            {
                Email = item.Email,
                PasswordHash = item.Password,
            };

            bool value = false;

            return await _signInManager.PasswordSignInAsync(user.Email, user.PasswordHash, item.RememberMe, value);
        }
        //Log out
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
