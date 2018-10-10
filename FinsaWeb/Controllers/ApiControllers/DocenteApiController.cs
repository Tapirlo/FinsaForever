using CorsiOnline.Models.Core;
using CorsiOnline.Models.Core.UnitOfWorks;
using CorsiOnline.Models.Database;
using CorsiOnline.ViewModels;
using CorsiOnline.ViewModels.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Controllers.ApiControllers
{
    [Route("api/docenti")]
    public class DocenteApiController : Controller
    {
        private IUnitOfWorkDocenti repository;

        public DocenteApiController(IUnitOfWorkDocenti repo)
        {
            repository = repo;
        }

        [HttpGet("ListaDocenti")]
        public IActionResult ListaDocenti(String surname)
        {
            var docenti = repository.FindBySurname(surname);
            if (docenti == null)
            {
                return BadRequest();
            }

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
            try
            {
                repository.UpdateDocente(d);
                return Ok(new DocenteModel(d));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpGet("GetAllDocenti")]
        public IActionResult GetAllDocenti()
        {
            IEnumerable<Docente> docenti = repository.GetAllDocenti();
            if (docenti == null)
            {
                return BadRequest();
            }
            return Ok(docenti.Select(x => new DocenteModels(x)));
        }

        [HttpGet("DocentePerID")]
        public IActionResult DocentePerID(string  iddocente)
        {
            Docente d = repository.FindByCF(iddocente);
            if (d == null)
            {
                return BadRequest();
            }
            return Ok(new DocenteModels(d));
        }

        [HttpPost("AggiungiDocente")]
        public IActionResult AggiungiDocente([FromBody]DocenteModels docente)
        {
            try
            {
                repository.AggiungiDocente(docente.AsDocente(), docente.GetInsegnamenti());
                return Ok(docente);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
    }
}
