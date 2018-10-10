using CorsiOnline.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models.Core.UnitOfWorks
{
    public interface IUnitOfWorkCorsi : IUnitOfWork
    {
        IEnumerable<Corso> GetAllCorsi();
        IEnumerable<Corso> GetCorsiByName(String name);
        Corso GetCorsoByID(String idcorso);
        void AggiungiCorso(Corso c);
        void UpdateCorso(Corso c);
    }
}
