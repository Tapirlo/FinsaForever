using CorsiOnline.Models.Core;
using CorsiOnline.Models.Database;
using CorsiOnline.ViewModels;
using CorsiOnline.ViewModels.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Controllers.ApiControllers
{
    [Route("api/docenti")]
    public class DocenteApiController : Controller
    {
        private IDocentiRepository repository;

        public DocenteApiController(IDocentiRepository repo)
        {
            repository = repo;
        }

        [HttpGet("ListaDocenti")]
        public IActionResult ListaDocenti(String surname)
        {
            var docenti = repository.FindBySurname(surname);
            List<DocenteModel> listaDocenti = new List<DocenteModel>();
            foreach (var d in docenti)
            {
                listaDocenti.Add(new DocenteModel(d));
            }
            return Ok(listaDocenti);
            //return repository.GetCorsiByName(nome);
        }

        [HttpPut("UpdateCorso")]
        public IActionResult UpdateDocente(Docente d)
        {
            if (repository.UpdateDocente(d))
            {
                return Ok(new DocenteModel(d));
            }
            return BadRequest();
        }

        [HttpGet("GetAllDocenti")]
        public IActionResult GetAllDocenti()
        {
            return Ok(repository.GetAllDocenti().Select(x => new DocenteModels(x)));
        }

        [HttpGet("DocentePerID")]
        public IActionResult DocentePerID(string  iddocente)
        {
            return Ok(new DocenteModels(repository.FindByCF(iddocente)));
        }

        [HttpPost("AggiungiDocente")]
        public IActionResult AggiungiDocente([FromBody]DocenteModels docente)
        {
            if(repository.AggiungiDocente(docente.AsDocente(), docente.GetInsegnamenti()))
            {
                return Ok(docente);
            }
            return BadRequest();
        }
    }
}
