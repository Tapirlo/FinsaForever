using CorsiOnline.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models.Core.UnitOfWorks
{
    public interface IUnitOfWorkAule : IUnitOfWork
    {
        IEnumerable<Aula> GetAllAula();
        void AggiungiAula(Aula aula);
        void RegistraAulaPerCorso(string a, string c, DateTime d);
        void UpdateAula(Aula a);
        Aula GetAulaById(string id);
    }
}
