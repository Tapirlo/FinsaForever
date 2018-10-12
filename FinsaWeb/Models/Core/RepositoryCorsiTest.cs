using System;
using System.Collections.Generic;
using CorsiOnline.Models.Database;
using System.Linq;
namespace CorsiOnline.Models.Core
{
    public class RepositoryCorsiTest:ICorsiRepository
    {
        private List<Corso> corsi;
        public RepositoryCorsiTest()
        {
            CreaCorsiAdMinchiam();
        }
        private void CreaCorsiAdMinchiam()
        {
            corsi = new List<Corso>();
            corsi.Add(new Corso { IDCorso = "1", Nome = "C# for dummies", DataInizio = new DateTime(2018, 6, 1), DataFine = new DateTime(2018, 9, 30), StudentiCorsi=new List<StudenteCorso>(), DocentiCorsi = new List<DocenteCorso>(), MaterieCorsi = new List<MateriaCorso>() });
            corsi.Add(new Corso { IDCorso = "2", Nome = "Java c++ per principianti", DataInizio = new DateTime(2017, 6, 1), DataFine = new DateTime(2017, 9, 30), StudentiCorsi = new List<StudenteCorso>() , DocentiCorsi = new List<DocenteCorso>(), MaterieCorsi = new List<MateriaCorso>() });
            corsi.Add(new Corso { IDCorso = "3", Nome = "Javascript for dummies", DataInizio = new DateTime(2016, 6, 1), DataFine = new DateTime(2016, 9, 30), StudentiCorsi = new List<StudenteCorso>() , DocentiCorsi = new List<DocenteCorso>(), MaterieCorsi = new List<MateriaCorso>() });
            corsi.Add(new Corso { IDCorso = "4", Nome = "Programmazione for dummies", DataInizio = new DateTime(2015, 6, 1), DataFine = new DateTime(2015, 9, 30), StudentiCorsi = new List<StudenteCorso>(), DocentiCorsi = new List<DocenteCorso>(), MaterieCorsi = new List<MateriaCorso>() });
        }
        public IEnumerable<Corso> GetAllCorsi()
        {
            return corsi.ToArray();
        }
        public IEnumerable<Corso> GetCorsiByName(String name)
        {
            return corsi.Where(x => x.Nome.Contains(name)).ToList();
        }
        public bool AggiungiCorso(Corso corso)
        {
            if(corsi.Contains(corso))
            {
                return false;
            }
            corsi.Add(corso);
            return true;
        }

        public bool UpdateCorso(Corso c)
        {
            int n = corsi.IndexOf(c);
            if(n<0)
            {
                return false;
            }
            corsi[n] = c;
            return true;
        }

        public Corso GetCorsoByID(String idcorso)
        {
            for(int i=0;i<corsi.Count;i++)
            {
                if(corsi[i].IDCorso==idcorso)
                {
                    return corsi[i];
                }
            }
            return null;
        }
    }
}
