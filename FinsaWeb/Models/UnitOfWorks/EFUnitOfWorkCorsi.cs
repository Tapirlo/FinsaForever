using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Core.UnitOfWorks;
using CorsiOnline.Models.Database;
using Microsoft.EntityFrameworkCore;
using CorsiOnline.Models.UnitOfWorks.Exceptions;


namespace CorsiOnline.Models.UnitOfWorks
{
    public class EFUnitOfWorkCorsi : EFUnitOfWork, IUnitOfWorkCorsi
    {
        private IRepositoryCorsi repoCorsi;

        public EFUnitOfWorkCorsi(IRepositoryCorsi corsi, ContestoCorso contesto) : base(contesto)
        {
            repoCorsi = corsi;
        }
              

        public IEnumerable<Corso> GetAllCorsi()
        {
            try
            {
                return repoCorsi.GetAllCorsi();
            }
            catch (ArgumentNullException e)
            {
               return null;
            }
        }

        public void AggiungiCorso(Corso c)
        {
            repoCorsi.AggiungiCorso(c);
            Save();            
        }

        public IEnumerable<Corso> GetCorsiByName(string name)
        {
            try
            {
                return repoCorsi.GetCorsiByName(name);
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
        }

        public Corso GetCorsoByID(string idcorso)
        {
            try
            {
                return repoCorsi.GetCorsoByID(idcorso);
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

        public void UpdateCorso(Corso c)
        {
            try
            {
                repoCorsi.UpdateCorso(c);
            }
            catch (Exception e)
            {
                throw new DBEditException(e.Message);
            }
            Save();
        }
    }
}
