using CorsiOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models.Core
{
    public interface IDocentiRepository
    {
        IEnumerable<Docente> FindByName(string name);
        IEnumerable<Docente> FindBySurname(string surname);
        IEnumerable<Docente> FindByCF(string cf);
        IEnumerable<Docente> GetAllDocenti();
        bool AggiungiDocente(Docente docente);

    }
}
