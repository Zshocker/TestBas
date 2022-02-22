using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestBase.Data;
namespace TestBase.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(FormCollection Input,DataContext data)
        {
            if (Input["pass"] == "" || Input["login"] == "") return Redirect("/Admin");
            HashAlgorithm ash = MD5.Create();
            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(Input["pass"]);
            byte[] hashBytes = ash.ComputeHash(textBytes);
            string hash = BitConverter
                .ToString(hashBytes)
                .Replace("-", String.Empty);

            return Redirect("/Admin/Students");
        }
    }
}
