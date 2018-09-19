using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;

namespace CorsiOnline.Models
{
    public interface IAulaRepository
    {
        IEnumerable<Aula> GetAllAula();
        bool AggiungiAula(Aula aula);
    }
}
