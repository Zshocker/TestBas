using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestBase.Data;
using TestBase.Models;

namespace TestBase.Pages.Students
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TestBase.Data.DataContext _context;
        public IndexModel(TestBase.Data.DataContext context)
        {
            _context = context;
        }
        public IList<Etudiant> Etudiants { get;set; }
        public void OnGet()
        { 
            Etudiants = _context.etudiants.ToList();
        }
    }
}
