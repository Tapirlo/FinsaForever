using CorsiOnline.Models.Core;
using FinsaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models.EF
{
    public class EFDocentiRepository : DocentiRepository
    {
        private FinsaContext context;
        public EFDocentiRepository(FinsaContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Docente> FindByName(string nome)
        {
            return context.docenti.Where(c => c.Nome.Contains(nome)).ToList();
        }
    }
}
