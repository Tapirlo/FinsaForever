using System;
using System.Collections.Generic;
using CorsiOnline.Models.Database;
namespace CorsiOnline.Models
{
    public interface IRepositoryCorsi
    {
        IEnumerable<Corso> GetAllCorsi();
        IEnumerable<Corso> GetCorsiByName(String name);
        bool AggiungiCorso(Corso c);
    }
}
