using FinsaWeb.Models.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Controllers
{
    public class HomeController : Controller
    {
        private DocentiRepository docentiRepo;
        public HomeController(DocentiRepository docentiRepo)
        {
            this.docentiRepo = docentiRepo;
        }
        public IActionResult Index()
        {
            var result = docentiRepo.FindByName("ciccio");
            return View(result);
        }
    }
}
