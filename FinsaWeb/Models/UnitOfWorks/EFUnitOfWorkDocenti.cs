using CorsiOnline.Models.Core;
using CorsiOnline.Models.Core.UnitOfWorks;
using CorsiOnline.Models.Database;
using CorsiOnline.Models.UnitOfWorks;
using CorsiOnline.Models.UnitOfWorks.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models.UnitOfWorks
{
    public class EFUnitOfWorkDocenti : EFUnitOfWork, IUnitOfWorkDocenti
    {
        private IDocentiRepository repoDocenti;
        

        public EFUnitOfWorkDocenti(IDocentiRepository docenti, ContestoFinsa contesto) : base(contesto)
        {
            repoDocenti = docenti;
            
        }

        public void AggiungiDocente(Docente docente, IEnumerable<Insegnamento> insegnamenti)
        {
            repoDocenti.AggiungiDocente(docente, insegnamenti);
            Save();
        }

        public Docente FindByCF(string cf)
        {
            try
            {
                return repoDocenti.FindByCF(cf);
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

        public IEnumerable<Docente> FindByName(string name)
        {
            try
            {
                return repoDocenti.FindByName(name);
                
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public IEnumerable<Docente> FindBySurname(string surname)
        {
            try
            {
                return repoDocenti.FindBySurname(surname);

            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public IEnumerable<Docente> GetAllDocenti()
        {
            try
            {
                return repoDocenti.GetAllDocenti();

            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public void UpdateDocente(Docente d)
        {
            try
            {
                repoDocenti.UpdateDocente(d);
            }
            catch (ArgumentNullException e)
            {
                throw new DBEditException(e.Message);
            }
            catch (InvalidOperationException e)
            {
                throw new DBEditException(e.Message);
            }
        }
    }
}
