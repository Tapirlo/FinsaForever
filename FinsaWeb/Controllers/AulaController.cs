using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;
using CorsiOnline.Models.Core;
using Microsoft.AspNetCore.Mvc;
using CorsiOnline.ViewModels;

namespace CorsiOnline.Controllers
{
    public class AulaController : Controller
    {
        private IAulaRepository aulaRepository;
        private IRepositoryCorsi corsiRepository;
        public AulaController(IAulaRepository repo,IRepositoryCorsi repo1)
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
                if(aulaRepository.AggiungiAula(aula))
                {
                   return RedirectToAction("Complete");
                    
                }
                else
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

            return View(new AuleCorsiModel(aulaRepository.GetAllAula(),corsiRepository.GetAllCorsi()));
        }



    }
}
