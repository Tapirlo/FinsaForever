using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models;
using CorsiOnline.Models.Core;
using Microsoft.AspNetCore.Mvc;
using CorsiOnline.ViewModels;
using CorsiOnline.Models.Database;

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
        public IActionResult AggiungiDocente(DocenteModel docente)
        {
            if (ModelState.IsValid)
            {
                if (repository.AggiungiDocente(docente.UnDocente, docente.RegistraMaterie()))
                {

                    return RedirectToAction("Completo");
                }
                else
                {
                    return RedirectToAction("Incompleto");
                }
            }            
            return View(docente);

        }
        public IActionResult Completo()
        {
            return View();
        }
        public IActionResult Incompleto()
        {
            return View();
        }

        public IActionResult CercaDocente()
        {
            
            return View(repository.GetAllDocenti());
        }
    }
}