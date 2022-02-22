using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestBase.Models;

namespace TestBase.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Etudiant> etudiants { get; set; }
        public DbSet<Utilis> utilis { get; set; }
        public Utilis? Auth(string login,string pass)
        {
            return utilis.First(us => us.login == login && us.passHash == pass);
        }
    }
}
