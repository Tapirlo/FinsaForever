using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models;
using CorsiOnline.Models.Core.UnitOfWorks;
using CorsiOnline.Models.Database;
using CorsiOnline.ViewModels;
using CorsiOnline.ViewModels.DTOS;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CorsiOnline.Controllers.ApiControllers
{
    [Route("api/aule")]
    public class AulaApiController : Controller
    {

        private IUnitOfWorkAule repository;

        public AulaApiController(IUnitOfWorkAule repo)
        {
            repository = repo;
        }
        [HttpPost("RegistraAula")]
        public IActionResult RegistraAula([FromBody]RegistraAulaModel model )
        {
            try
            {
                repository.RegistraAulaPerCorso(model.Aula, model.Corso, model.Data);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPatch("{nomeaula}/modificaAula")]
        public IActionResult ModificaAula(string nomeaula,[FromBody] JsonPatchDocument<AulaModel> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            Aula aula = repository.GetAulaById(nomeaula);
            if (aula == null)
            {
                return BadRequest();
            }
            AulaModel model = new AulaModel(aula);
            patchDoc.ApplyTo(model);
            try
            {
                repository.UpdateAula(model.GetAula());
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }            

        }
        
        [HttpGet("AllAule")]

        public IActionResult AllAule()
        {
            return Ok(repository.GetAllAula());
        }

        [HttpGet("AulaPerID")]

        public IActionResult AulaPerID(String idAula)
        {
            Aula aula = repository.GetAulaById(idAula);
            if (aula == null)
            {
                return BadRequest();
            }
            return Ok(new AulaModels(aula));
        }
        [HttpPost("InserisciAula")]
        public IActionResult InserisciAula([FromBody] Aula aula)
        {
            try
            {
                repository.AggiungiAula(aula);
                return Ok(new AulaModel(aula));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}