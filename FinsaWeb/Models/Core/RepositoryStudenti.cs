using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CorsiOnline.Models.Core
{
    public class RepositoryStudenti : IStudenteRepository, IDisposable
    {
        public void Dispose()
        {
            contesto.Dispose();
        }
        private ContestoCorso contesto;

        public RepositoryStudenti(ContestoCorso ctx)
        {
            contesto = ctx;
        }

        public IEnumerable<Studente> FindByName(string name)
        {
            return contesto.Studenti.Where(x => x.Nome.Contains(name) || x.Cognome.Contains(name)).ToList();
        }
        public bool IscriviStudente(Studente studente, String nomecorso)
        {
            try
            {
                contesto.Studenti.Add(studente);
                contesto.StudentiCorsi.Add(new StudenteCorso
                {
                    Studente = studente.CodiceFiscale,
                    Corso = nomecorso
                });
                contesto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public IEnumerable<Studente> GetAllStudenti()
        {
            return contesto.Studenti.ToList();
        }

        public Studente FindByCF(string cf)
        {
            return contesto.Studenti.Where(x => x.CodiceFiscale == cf).First();
        }


        public IEnumerable<Studente> StudentiIscrittiACorso(String idcorso)
        {
            return contesto.Studenti.Include(x => x.StudentiCorsi).
               Join(contesto.StudentiCorsi, x => x.CodiceFiscale, x => x.Studente, (x1, x2) => new { Studente = x1, StudenteCorso = x2 })
               .Where(x => x.StudenteCorso.Corso == idcorso).Select(x => x.Studente).ToList();
        }
    }
}
