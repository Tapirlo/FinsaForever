using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Core;
using Microsoft.AspNetCore.Mvc;

namespace FinsaWeb.Controllers
{
    public class DocenteController : Controller
    {
        private IDocentiRepository repository;

        public DocenteController(IDocentiRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.GetAllDocenti());
        }
    }
}