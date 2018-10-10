using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

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

            contesto.Studenti.Add(studente);
            contesto.StudentiCorsi.Add(new StudenteCorso
            {
                Studente = studente.CodiceFiscale,
                Corso = nomecorso
            });
            return true;            

        }
        public IEnumerable<Studente> GetAllStudenti()
        {
            return contesto.Studenti.ToList();
        }

        public Studente FindByCF(string cf)
        {
            return contesto.Studenti.Where(x => x.CodiceFiscale == cf).First();
        }

        public Dictionary<Studente, int?> StudentiIscrittiACorso(String idcorso)
        {
            var dictionary = new Dictionary<Studente, int?>();
            var collection =  contesto.Studenti.Include(x => x.StudentiCorsi).
               Join(contesto.StudentiCorsi, x => x.CodiceFiscale, x => x.Studente, (x1, x2) => new { Studente = x1, StudenteCorso = x2 })
               .Where(x => x.StudenteCorso.Corso == idcorso).ToList();
            foreach (var item in collection)
            {
                dictionary.Add(item.Studente, item.StudenteCorso.Punteggio);
            }
            return dictionary;
        }

        public bool AggiungiStudente(Studente s)
        {
            contesto.Studenti.Add(s);            
            return true;
        }
    }
}
