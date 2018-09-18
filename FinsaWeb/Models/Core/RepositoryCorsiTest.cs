using System;
using System.Collections.Generic;
using CorsiOnline.Models.Database;
namespace CorsiOnline.Models.Database
{
    public class RepositoryCorsiTest:IRepositoryCorsi
    {
        private List<Corso> corsi;
        public RepositoryCorsiTest()
        {
            CreaCorsiAdMinchiam();
        }
        private void CreaCorsiAdMinchiam()
        {
            corsi = new List<Corso>();
            corsi.Add(new Corso { IDCorso = "1", Nome = "C# for dummies", DataInizio = new DateTime(2018, 6, 1), DataFine = new DateTime(2018, 9, 30)});
            corsi.Add(new Corso { IDCorso = "2", Nome = "Java c++ per principianti", DataInizio = new DateTime(2017, 6, 1), DataFine = new DateTime(2017, 9, 30) });
            corsi.Add(new Corso { IDCorso = "3", Nome = "Javascript for dummies", DataInizio = new DateTime(2016, 6, 1), DataFine = new DateTime(2016, 9, 30) });
            corsi.Add(new Corso { IDCorso = "4", Nome = "Programmazione for dummies", DataInizio = new DateTime(2015, 6, 1), DataFine = new DateTime(2015, 9, 30) });
        }
        public IEnumerable<Corso> GetAllCorsi()
        {
            return corsi.ToArray();
        }
    }
}
