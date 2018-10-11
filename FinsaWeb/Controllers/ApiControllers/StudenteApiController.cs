using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CorsiOnline.Models;
using CorsiOnline.ViewModels;
using CorsiOnline.Models.Database;
using CorsiOnline.ViewModels.DTOS;
using CorsiOnline.Models.Core.UnitOfWorks;

namespace CorsiOnline.Controllers.ApiControllers
{
    [Route("api/studenti")]
    public class StudenteApiController : Controller
    {
        private IUnitOfWorkStudenti repository;

        public StudenteApiController(IUnitOfWorkStudenti repo)
        {
            repository = repo;
        }
        [HttpGet("AllStudenti")]
        public IActionResult AllStudenti()
        {
            IEnumerable<Studente> studenti = repository.GetAllStudenti();
            if (studenti != null)
            {
                return Ok(studenti.Select(x => new StudenteModels(x)));
            }
            return BadRequest();

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
            if (dizionario == null)
            {
                return BadRequest();
            }
            List<StudenteModels> lista = new List<StudenteModels>();
            foreach(var studente in dizionario)
            {
                lista.Add(new StudenteModels(studente.Key,studente.Value));
            }
            return Ok(lista);
        }

        [HttpPost("AggiungiStudente")]
        public IActionResult AggiungiStudente([FromBody]StudenteModels s)
        {
            if (s.Corso != null)
            {
                try
                {
                    repository.IscriviStudente(s.AsStudente(), s.Corso);
                    return Ok(s);
                }
                catch (Exception)
                {
                    return BadRequest();
                }                
            }
            else
            {
                try
                {
                    repository.AggiungiStudente(s.AsStudente());
                    return Ok(s);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                
            }
           
        }

        [HttpPut("InserisciPunteggio")]
        public IActionResult InserisciPunteggio([FromBody] StudenteModels[] studenti)
        {
            try
            {
                foreach (StudenteModels studente in studenti)
                {
                    if (studente.Punteggio != null)
                    {
                        repository.AssegnaPunteggio(studente.CodiceFiscale, studente.Corso, (int)studente.Punteggio);
                    }                    
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(studenti);
        }

        

    }
}
