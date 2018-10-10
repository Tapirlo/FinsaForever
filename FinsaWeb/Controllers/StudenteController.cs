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
    public class StudenteController : Controller
    {
        private IUnitOfWorkStudenti repositoryStudenti;
        private IUnitOfWorkCorsi repositoryCorsi;

        public StudenteController(IUnitOfWorkStudenti s, IUnitOfWorkCorsi c)
        {
            repositoryStudenti = s;
            repositoryCorsi = c;
        }

        public IActionResult IscriviStudente()
        {
            IEnumerable<Corso> icorsi = repositoryCorsi.GetAllCorsi();
            return View(new StudenteModel { Corsi = icorsi });
        }
        [HttpPost]
        public IActionResult IscriviStudente(StudenteModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repositoryStudenti.IscriviStudente(model.UnAlunno, model.UnCorso);
                    return RedirectToAction("Completo");
                }
                catch (Exception)
                {
                    return RedirectToAction("Incompleto");
                }
                
            }
            IEnumerable<Corso> icorsi = repositoryCorsi.GetAllCorsi();
            model.Corsi = icorsi;
            return View(model);
        }

        public IActionResult Completo()
        {
            return View();
        }
        public IActionResult Incompleto()
        {
            return View();
        }
        public IActionResult Index()
        {

            return View(repositoryStudenti.GetAllStudenti());
        }
    }

}

