using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;
using CorsiOnline.Models.Core;
using Microsoft.AspNetCore.Mvc;
using CorsiOnline.ViewModels;
using CorsiOnline.Models.Core.UnitOfWorks;

namespace CorsiOnline.Controllers
{
    public class AulaController : Controller
    {
        private IUnitOfWorkAule aulaRepository;
        private IUnitOfWorkCorsi corsiRepository;
        public AulaController(IUnitOfWorkAule repo, IUnitOfWorkCorsi repo1)
        {
            aulaRepository = repo;
            corsiRepository = repo1;

        }
        public IActionResult AggiungiAula()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AggiungiAula(Aula aula)
        {            

           if (ModelState.IsValid)
            {
                try
                {
                    aulaRepository.AggiungiAula(aula);
                    return RedirectToAction("Complete");
                }
                catch (Exception)
                {
                    return RedirectToAction("Failed");
                }

            }
            return View(aula);
           
        }
        public IActionResult Complete()
        {
            return View();
        }
        public IActionResult Failed()
        {
            return View();
        }
        public IActionResult RegistraAula()
        {
            IEnumerable<Aula> aule = aulaRepository.GetAllAula();
            IEnumerable<Corso> corsi = corsiRepository.GetAllCorsi();
            if (aule == null || corsi == null)
            {
                return BadRequest();
            }
            return View(new AuleCorsiModel(aule, corsi));
        }

        public IActionResult UpdateAula()
        {
            return View(aulaRepository.GetAllAula());
        }

    }
}
