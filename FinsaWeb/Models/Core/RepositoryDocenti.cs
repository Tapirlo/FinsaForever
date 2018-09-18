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
            throw new NotImplementedException();
        }

        public IEnumerable<Docente> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Docente> FindBySurname(string surname)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Docente> GetAllDocenti()
        {
            //return contesto.Docenti.Include(x => x.Nome).ToList();
            return contesto.Docenti.ToList();
        }
    }
}
