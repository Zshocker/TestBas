using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using TestBase.Data;
using TestBase.Models;


namespace TestBase.Pages.Students
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly TestBase.Data.DataContext _context;
        private readonly IConfiguration _config;
        public CreateModel(TestBase.Data.DataContext context, IConfiguration configuration )
        {
            _context = context;
            _config = configuration;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Etudiant Etudiant { get; set; }
        public  IFormFile file { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {  
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var fileNam = Etudiant.name+"_"+Etudiant.CNE+"_"+new Random().Next()+"_"+".png";
            var filePath = Path.Combine(_config["ImagesRealPath"],fileNam);
            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            Etudiant.ImageUrl = _config["ImagesPath"]+"/"+fileNam;
            _context.etudiants.Add(Etudiant);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
