using CorsiOnline.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models
{
    public interface IStundenteRepository
    {
        IEnumerable<Studente> FindByName(string name);
    }
}
