using CorsiOnline.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;
using CorsiOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace CorsiOnline.Models.Core
{
    public class RepositoryDocenti : IDocentiRepository
    {
        private ContestoCorso contesto;

        public RepositoryDocenti(ContestoCorso ctx)
        {
            contesto = ctx;
        }

        public IEnumerable<Docente> FindByCF(string cf)
        {
            return contesto.Docenti.Where(d => d.CodiceFiscale.Contains(cf)).ToList();
        }

        public IEnumerable<Docente> FindByName(string name)
        {
            return contesto.Docenti.Where(d => d.Nome.Contains(name)).ToList();
        }

        public IEnumerable<Docente> FindBySurname(string surname)
        {
            return contesto.Docenti.Where(d => d.Cognome.Contains(surname)).ToList();
        }

        public IEnumerable<Docente> GetAllDocenti()
        {
            return contesto.Docenti.ToList();
        }
        public bool AggiungiDocente(Docente docente)
        {
            contesto.Docenti.Add(docente);
            contesto.SaveChanges();
            return true;
        }
    }
}
