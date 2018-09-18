using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models;
using CorsiOnline.Models.Core;
using Microsoft.AspNetCore.Mvc;

namespace CorsiOnline.Controllers
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
        public IActionResult AggiungiDocente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AggiungiDocente(Docente docente)
        {
            if (repository.AggiungiDocente(docente))
            {
                return View();
            }
            else
            {
                return View();
            }
        }
        public IActionResult CercaDocente()
        {
            return View();
        }
    }
}