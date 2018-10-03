using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CorsiOnline.Models;
using CorsiOnline.ViewModels;
using CorsiOnline.Models.Database;

namespace CorsiOnline.Controllers
{
    [Route("api/studenti")]
    public class StudenteApiController : Controller
    {
        private IStudenteRepository repository;

        public StudenteApiController(IStudenteRepository repo)
        {
            repository = repo;
        }
        [HttpGet("AllStudenti")]
        public IActionResult AllStudenti()
        {


            return Ok(repository.GetAllStudenti().Select(x => new StudenteModels(x)));

        }

        [HttpGet("StudentePerCF")]
        public IActionResult StudentePerCF(String cf)
        {
            return Ok(repository.FindByCF(cf));
        }


    }
}
