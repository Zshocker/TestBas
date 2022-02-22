using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBase.Models
{
    public class Etudiant
    {
        static int Cm = 0;
        public int id { get; set; }
        public string name { get; set; }
        public string CNE { get; set; }
        bool saved = false;
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
