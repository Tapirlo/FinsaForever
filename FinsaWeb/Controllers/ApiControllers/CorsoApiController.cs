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
    [Route("api/corsi")]
    public class CorsoApiController : Controller
    {
        private IUnitOfWorkCorsi repository;

        public CorsoApiController(IUnitOfWorkCorsi repo)
        {
            repository = repo;
        }
        [HttpGet("AllCorsi")]
        public IActionResult AllCorsi()
        {
            IEnumerable<Corso> risultato = repository.GetAllCorsi();
            if (risultato != null)
            {
                return Ok(risultato.Select(x => new CorsoModels(x)));
            }
            return BadRequest();
        }
        [HttpGet("ListaCorsi")]
  
        public IActionResult ListaCorsi(String nome)
        {
            var c = repository.GetCorsiByName(nome);
            List<CorsoModels> lista = new List<CorsoModels>();
            foreach (var cc in c)
            {
                lista.Add(new CorsoModels(cc));
            }
            return Ok(lista);
            //return repository.GetCorsiByName(nome);
        }
        [HttpPut("UpdateCorso")]

        public IActionResult UpdateCorso(Corso c)
        {
            try
            {
                repository.UpdateCorso(c);
                return Ok(new CorsoModels(c));
            }
            catch (Exception)
            {
                return BadRequest();                    
            }

          
        }

        [HttpGet("CorsoPerID")]

        public IActionResult CorsoPerID(String idcorso)
        {
            Corso c = repository.GetCorsoByID(idcorso);
            if (c != null)
            {
                return Ok(new CorsoModels(c));
            }
            return BadRequest();
        }


        [HttpPost("InserisciCorso")]
        public IActionResult InserisciCorso([FromBody]CorsoModels corso)
        {
            try
            {
                repository.AggiungiCorso(corso.AsCorso());
                return Ok(corso);
            }
            catch (Exception)
            {
                return BadRequest();
            }
                
            
        }

    }
}