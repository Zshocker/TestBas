using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestBase.Data;
using TestBase.Models;

namespace TestBase.Pages.Students
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly TestBase.Data.DataContext _context;
        public CreateModel(TestBase.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Etudiant Etudiant { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.etudiants.Add(Etudiant);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
