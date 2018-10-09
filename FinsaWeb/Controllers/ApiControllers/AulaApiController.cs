using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;
using CorsiOnline.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CorsiOnline.Controllers.ApiControllers
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
        [HttpPatch("{nomeaula}/modificaAula")]
        public IActionResult ModificaAula(string nomeaula,[FromBody] JsonPatchDocument<AulaModel> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            Aula aula = repository.GetAulaById(nomeaula);      
            AulaModel model = new AulaModel(aula);
            patchDoc.ApplyTo(model);
            
            if (repository.UpdateAula(model.GetAula()))
            {
                return Ok(model);
            }
            return BadRequest();
            

        }
        
        [HttpGet("AllAule")]

        public IActionResult AllAule()
        {
            return Ok(repository.GetAllAula());
        }

        [HttpGet("AulaPerID")]

        public IActionResult AulaPerID(String idAula)
        {
            return Ok(repository.GetAulaById(idAula));
        }
        [HttpPost("InserisciAula")]
        public IActionResult InserisciAula([FromBody] Aula aula)
        {
            if(repository.AggiungiAula(aula))
            {
                return Ok(new AulaModel(aula));
            }
            return BadRequest();
        }
    }
}