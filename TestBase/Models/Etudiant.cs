using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBase.Models
{
    public class Etudiant
    {
        public int id { get; set; }
        public string name { get; set; }
        public string CNE { get; set; }
        public Etudiant(string nam, string cne)
        {
            name = nam;
            CNE = cne;
        }
        public Etudiant()
        {
        }
    }
}
