using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestBase.Data;
using TestBase.Models;

namespace TestBase.Controllers
{
    [Route("api/Student")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class EtudiantsController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public EtudiantsController(ILogger<EtudiantsController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public List<Etudiant> GetAllEtudiants()
        {

            _logger.LogWarning("[" + DateTime.Now.ToString() + "] : All Etudiants where requested by " + Request.HttpContext.Connection.RemoteIpAddress);
            return _context.etudiants.ToList();
        }
        [HttpGet("{id}")]
        public Etudiant DetailEtudiant(int id)
        {
            var etudiant = _context.etudiants.FirstOrDefault(m => m.id == id);
            if (etudiant == null)
            {
                _logger.LogError("[" + DateTime.Now.ToString() + "] : Error : id requested by " + Request.HttpContext.Connection.RemoteIpAddress + " was not found ");

                return null;
            }
            _logger.LogWarning("[" + DateTime.Now.ToString() + "] :Etudiant " + etudiant.ToString() + " was requested by " + Request.HttpContext.Connection.RemoteIpAddress);
            return etudiant;
        }
        [HttpPost]
        public bool InsertEtudiant(Etudiant etudiant)
        {
            try
            {
                _context.Add(etudiant);
                _context.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }

        }
    }
}
