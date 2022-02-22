using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestBase.Data;
using TestBase.Models;

namespace TestBase.Pages.Admin
{
    public class IndexModel : PageModel
    {
        DataContext data;
        public  IndexModel(DataContext data)
        {
            this.data = data;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated) return Redirect("/Admin/Students");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string login,string pass)
        {
            if (pass == null || login == null) return Redirect("/Admin");
            HashAlgorithm ash = MD5.Create();
            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(pass);
            byte[] hashBytes = ash.ComputeHash(textBytes);
            string hash = BitConverter
                .ToString(hashBytes)
                .Replace("-", String.Empty);
            Utilis utilis = data.Auth(login, hash);
            if (utilis == null) return Redirect("/Admin");
            var claimes = new List<Claim>
            {
                new Claim(ClaimTypes.Name,utilis.name),
                new Claim("id", utilis.id.ToString()),
                new Claim(ClaimTypes.Role, "Administrator")
            };
            var claimId = new ClaimsIdentity(claimes, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true,
                IssuedUtc = DateTimeOffset.UtcNow
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimId), authProperties);
            return Redirect("/Admin/Students");
        }
      
    }
}
