using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CorsiOnline.Models;
using CorsiOnline.ViewModels;
using CorsiOnline.Models.Database;

namespace FinsaWeb.Controllers
{
    [Route("api/corsi")]
    public class CorsoApiController : Controller
    {
        private IRepositoryCorsi repository;

        public CorsoApiController(IRepositoryCorsi repo)
        {
            repository = repo;
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
          if(repository.UpdateCorso(c))
          {
                return Ok(new CorsoModels(c));
          }
          return BadRequest();
        }

        [HttpGet("CorsoPerID")]

        public IActionResult CorsoPerID(String idcorso)
        {
            return Ok(repository.GetCorsoByID(idcorso));
        }

    }
}