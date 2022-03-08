using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace TestBase.Controllers
{
    [Route("api/chaine")]
    [ApiController]
    [Produces(MediaTypeNames.Text.Plain)]
    public class ChaineController : ControllerBase
    {
        [HttpGet]
        public ActionResult<String> GetChaine()
        {
            Random random = new Random((int)DateTime.Now.ToBinary());
            return "your random num :"+ random.NextDouble()*100;
        }
    }
}
