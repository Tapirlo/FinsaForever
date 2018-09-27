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
            return contesto.Docenti.Include(x => x.Insegnamenti).ToList();
        }

        public bool AggiungiDocente(Docente docente, IEnumerable<Insegnamento> insegnamenti)
        {
            contesto.Docenti.Add(docente);
            foreach(Insegnamento inse in insegnamenti)
            {
                contesto.Insegnamenti.Add(inse);
            }
            contesto.SaveChanges();
            return true;
        }

        public bool UpdateDocente(Docente d)
        {
            try
            {
                Docente old = contesto.Docenti.Where(x => x.CodiceFiscale == d.CodiceFiscale).First();
                old.Nome = d.Nome;
                old.Cognome = d.Cognome;
                old.Email = d.Email;
                old.CodiceFiscale = d.CodiceFiscale;
                old.Telefono = d.Telefono;
                old.DataNascita = d.DataNascita;
                contesto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
