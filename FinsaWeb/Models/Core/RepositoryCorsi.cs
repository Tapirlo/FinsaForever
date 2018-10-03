using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CorsiOnline.Models.Core
{
    public class RepositoryCorsi : IRepositoryCorsi, IDisposable
    {
        public void Dispose()
        {
            contesto.Dispose();
        }
        private ContestoCorso contesto;

        public RepositoryCorsi(ContestoCorso ctx)
        {
            contesto = ctx;
        }
        public IEnumerable<Corso> GetCorsiByName(String name)
        {
            return contesto.Corsi.Include(x => x.StudentiCorsi).ThenInclude(x => x.StudenteNavigation).Include(x => x.DocentiCorsi).ThenInclude(x => x.DocenteNavigation).Include(x => x.MaterieCorsi).Where(x => x.Nome.Contains(name)).ToList();
        }
        public IEnumerable<Corso> GetAllCorsi()
        {
            return contesto.Corsi.Include(x => x.StudentiCorsi).ThenInclude(x => x.StudenteNavigation).Include(x => x.DocentiCorsi).ThenInclude(x => x.DocenteNavigation).Include(x => x.MaterieCorsi).ToList();
        }
        public bool AggiungiCorso(Corso corso)
        {
            //if(contesto.Corsi.Contains(corso))
            //{
            //    return false;
            //}
            contesto.Corsi.Add(corso);
            contesto.SaveChanges();
            return true;
        }

        public bool UpdateCorso(Corso c)
        {
            try
            {
                Corso vecchio = contesto.Corsi.Where(x => x.IDCorso == c.IDCorso).First();
                vecchio.Nome = c.Nome;
                vecchio.DataInizio = c.DataInizio;
                vecchio.DataFine = c.DataFine;
                contesto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Corso GetCorsoByID(String idcorso)
        {
            return contesto.Corsi.Where(x => x.IDCorso == idcorso).Include(x=>x.MaterieCorsi).First();
        }
    }
}
