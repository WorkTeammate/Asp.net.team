using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using _01_Framework.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace _01_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public long CurrentAccountId()
        {
            if (IsAuthenticated())
                return long.Parse(_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "AccountId").Value);
            return 0;
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var resault = new AuthViewModel();
            if (!IsAuthenticated())
                return resault;

            var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            resault.Id = long.Parse(claims.FirstOrDefault(x => x.Type == "AccountId").Value);
            resault.Username = claims.FirstOrDefault(x => x.Type == "UserName").Value;
            resault.RoleId = long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            resault.Fullname = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            resault.ProfilePicture = claims.FirstOrDefault(x => x.Type == "ProfilePicture").Value;


            resault.Role = Roles.GetByRole(resault.RoleId);

            return resault;

        }

        public string CurrentAccountRole()
        {
            if (IsAuthenticated())
                return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            return null;
        }

        public List<long> GetPermissions()
        {
            if (!IsAuthenticated())
            {
                return new List<long>();
            }
            var permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Permissions")?.Value;

            return JsonConvert.DeserializeObject<List<long>>(permissions);
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public void SignIn(AuthViewModel account)
        {
            //Security Data Information
            var permissions = JsonConvert.SerializeObject(account.Permissions);
            var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Fullname),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim("UserName", account.Username), // Or Use ClaimTypes.NameIdentifier
                new Claim("ProfilePicture", account.ProfilePicture),
                new Claim("Permissions", permissions)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                // چند روز میتواند ساین باشد بعدش پاک شود
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(2),

            };
            // کوکی را ست میکند در ریسپانس
            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public void SignOut()
        {
            // حذف کوکی
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}