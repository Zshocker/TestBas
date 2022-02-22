using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestBase.Data;
using TestBase.Models;

namespace TestBase.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly TestBase.Data.DataContext _context;

        public IndexModel(TestBase.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Etudiant> Etudiant { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!HttpContext.User.Identity.IsAuthenticated) return Redirect("/Admin");
            Etudiant = await _context.etudiants.ToListAsync();
            return Page();
        }
    }
}
