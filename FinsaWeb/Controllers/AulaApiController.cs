using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models;
using CorsiOnline.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CorsiOnline.Controllers
{
    [Route("api/aule")]
    public class AulaApiController : Controller
    {

        private IAulaRepository repository;

        public AulaApiController(IAulaRepository repo)
        {
            repository = repo;
        }
        [HttpPost("RegistraAula")]
        public IActionResult RegistraAula(RegistraAulaModel model )
        {
            if (repository.RegistraAulaPerCorso(model.Aula, model.Corso, model.Data))
            {
                return Ok(model);
            }
            return BadRequest();
        }
    }
}