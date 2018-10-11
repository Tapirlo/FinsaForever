using CorsiOnline.Models.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.UnitOfWorks.Exceptions;
using CorsiOnline.Models.Core.UnitOfWorks;
using CorsiOnline.Models.Database;

namespace CorsiOnline.Models.UnitOfWorks
{
    public class EFUnitOfWorkAule : EFUnitOfWork, IUnitOfWorkAule
    {
        private IAulaRepository repoAule;

        public EFUnitOfWorkAule(IAulaRepository aule, ContestoCorso contesto) : base(contesto)
        {
            repoAule = aule;
        }

        public void AggiungiAula(Aula aula)
        {
            repoAule.AggiungiAula(aula);
            Save();
        }

        public IEnumerable<Aula> GetAllAula()
        {
            try
            {
                return repoAule.GetAllAula();
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
        }

        public Aula GetAulaById(string id)
        {
            try
            {
                return repoAule.GetAulaById(id);
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

        public void RegistraAulaPerCorso(string a, string c, DateTime d)
        {
            repoAule.RegistraAulaPerCorso(a, c, d);
            Save();
        }

        public void UpdateAula(Aula a)
        {
            try
            {
                repoAule.UpdateAula(a);
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
    }
}
