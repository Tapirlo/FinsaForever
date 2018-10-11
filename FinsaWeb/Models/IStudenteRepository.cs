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
        Studente FindByCF(string cf);
        bool IscriviStudente(Studente studente,String nomecorso);
        IEnumerable<Studente> GetAllStudenti();
        Dictionary<Studente, int?> StudentiIscrittiACorso(String idcorso);
        bool AggiungiStudente(Studente s);
        void AssegnaPunteggio(String cfStudente, String idCorso, int? punteggio);
    }
}
