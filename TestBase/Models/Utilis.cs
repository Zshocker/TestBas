using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBase.Models
{
    public class Utilis
    {
        public int id { get; set; }
        public string login { get; set; }
        public string passHash { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public Utilis()
        {

        }
        public Utilis(string login, string passHash, string name, string email)
        {
            this.login = login;
            this.passHash = passHash;
            this.name = name;
            this.email = email;
        }
    }
}
