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


        [HttpGet("StudentiIscritti")]
        public IActionResult StudentiIscritti(String idcorso)
        {
            var dizionario = repository.StudentiIscrittiACorso(idcorso);
            List<StudenteModels> lista = new List<StudenteModels>();
            foreach(var studente in dizionario)
            {
                lista.Add(new StudenteModels(studente.Key,studente.Value));
            }
            return Ok(lista);
        }

        [HttpPost("StudenteForm")]
        public IActionResult AggiungiStudente(Studente s)
        {
            return Ok();
        }

    }
}
