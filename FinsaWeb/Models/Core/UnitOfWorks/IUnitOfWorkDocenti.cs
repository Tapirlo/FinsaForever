using CorsiOnline.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models.Core.UnitOfWorks
{
    public interface IUnitOfWorkDocenti : IUnitOfWork
    {
        IEnumerable<Docente> FindByName(string name);
        IEnumerable<Docente> FindBySurname(string surname);
        Docente FindByCF(string cf);
        IEnumerable<Docente> GetAllDocenti();
        void AggiungiDocente(Docente docente, IEnumerable<Insegnamento> insegnamenti);
        void UpdateDocente(Docente d);
    }
}
