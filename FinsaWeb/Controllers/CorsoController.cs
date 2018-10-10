using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;
using CorsiOnline.ViewModels;
using CorsiOnline.Models.Core.UnitOfWorks;


namespace CorsiOnline.Controllers
{
    public class CorsoController : Controller
    {
        private IUnitOfWorkCorsi repository;

        public CorsoController(IUnitOfWorkCorsi repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            
            return View(repository.GetAllCorsi());
        }

        public IActionResult UpdateCorso()
        {
            return View(repository.GetAllCorsi());
        }

        public IActionResult AggiungiCorso()
        {
            return View();
        }
        public IActionResult CercaCorsi()
        {
            return View();
        }
        public IActionResult Completo()
        {
            return View();
        }
        public IActionResult Incompleto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AggiungiCorso(Corso corso)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.AggiungiCorso(corso);
                    return RedirectToAction("Completo");

                }
                catch(Exception)
                {
                    return RedirectToAction("Incompleto");

                }
            }
            return View(corso);
        }

       
    }
}