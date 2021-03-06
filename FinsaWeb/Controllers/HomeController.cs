﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;

namespace CorsiOnline.Controllers
{
    public class HomeController : Controller
    {
        private ICorsiRepository repository;
        public HomeController(ICorsiRepository r)
        {
            repository = r;
        }

        public IActionResult Index()
        {
            IEnumerable<Corso> corsi = repository.GetAllCorsi();
            return View(corsi);
        }

    }

}
