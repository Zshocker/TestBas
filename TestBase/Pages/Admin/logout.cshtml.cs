using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestBase.Pages.Admin
{
    public class Index1Model : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            if (!HttpContext.User.Identity.IsAuthenticated) return Redirect("/");
            await HttpContext.SignOutAsync();
            return  Redirect("/");
        }
    }
}
