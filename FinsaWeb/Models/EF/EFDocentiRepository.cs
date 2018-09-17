using FinsaWeb.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF
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
