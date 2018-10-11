using CorsiOnline.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CorsiOnline.Models.Core.UnitOfWorks 
{
    public interface IUnitOfWorkStudenti : IUnitOfWork
    {
        IEnumerable<Studente> FindByName(string name);
        Studente FindByCF(string cf);
        void IscriviStudente(Studente studente, String nomecorso);
        IEnumerable<Studente> GetAllStudenti();
        Dictionary<Studente, int?> StudentiIscrittiACorso(String idcorso);
        void AggiungiStudente(Studente s);
        void AssegnaPunteggio(String cfStudente, String idCorso, int punteggio);
    }
}
