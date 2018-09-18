using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;

namespace CorsiOnline.Controllers
{
    public class CorsoController : Controller
    {
        private IRepositoryCorsi repository;

        public CorsoController(IRepositoryCorsi repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            
            return View(repository.GetAllCorsi());
        }
    }
}