using CorsiOnline.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models
{
    public interface IStudenteRepository
    {
        IEnumerable<Studente> FindByName(string name);
        bool IscriviStudente(Studente studente,String nomecorso);
    }
}
