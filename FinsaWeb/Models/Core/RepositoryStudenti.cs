using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;

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
    }
}
