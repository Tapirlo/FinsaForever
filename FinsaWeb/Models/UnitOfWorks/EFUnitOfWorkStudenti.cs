using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Core.UnitOfWorks;
using CorsiOnline.Models.Database;
using CorsiOnline.Models.UnitOfWorks.Exceptions;

namespace CorsiOnline.Models.UnitOfWorks
{
    public class EFUnitOfWorkStudenti : EFUnitOfWork, IUnitOfWorkStudenti
    {
        private IStudenteRepository repoStudenti;

        public EFUnitOfWorkStudenti(IStudenteRepository studenti, ContestoCorso contesto) : base(contesto)
        {
            repoStudenti = studenti;
           
        }

        public void AggiungiStudente(Studente s)
        {
            repoStudenti.AggiungiStudente(s);
            Save();
        }

        public void AssegnaPunteggio(string cfStudente, string idCorso, int? punteggio)
        {
            try
            {
                repoStudenti.AssegnaPunteggio(cfStudente, idCorso, punteggio);
            }
            catch (ArgumentNullException e)
            {
                throw new DBEditException(e.Message);
            }
            catch (InvalidOperationException e)
            {
                throw new DBEditException(e.Message);
            }
            Save();
        }

        public void Cancella(string cf)
        {
            try
            {
                repoStudenti.Cancella(cf);
            }
            catch (ArgumentNullException e)
            {
                throw new DBEditException(e.Message);
            }
            catch (InvalidOperationException e)
            {
                throw new DBEditException(e.Message);
            }
            Save();
        }

        public Studente FindByCF(string cf)
        {
            try
            {
                return repoStudenti.FindByCF(cf);
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public IEnumerable<Studente> FindByName(string name)
        {
            try
            {
                return repoStudenti.FindByName(name);
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
        }

        public IEnumerable<Studente> GetAllStudenti()
        {
            try
            {
                return repoStudenti.GetAllStudenti();
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
        }

        public void IscriviStudente(Studente studente, string nomecorso)
        {
            repoStudenti.IscriviStudente(studente, nomecorso);
            Save();
        }

        public Dictionary<Studente, int?> StudentiIscrittiACorso(string idcorso)
        {
            try
            {
                return repoStudenti.StudentiIscrittiACorso(idcorso);                
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
