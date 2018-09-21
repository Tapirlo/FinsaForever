using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;

namespace CorsiOnline.ViewModels
{
    public class CorsoModels
    {
        public String IDCorso { get; set; }
        public String Nome { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public String [] Argomenti { get; set; }

        public CorsoModels()
        {

        }

        public CorsoModels(Corso c)
        {
            IDCorso = c.IDCorso;
            Nome = c.Nome;
            DataFine = c.DataFine;
            DataInizio = c.DataInizio;
            var args = c.MaterieCorsi;
            Argomenti = new String[args.Count];
            int i = 0;
            foreach(MateriaCorso mc in args)
            {
                Argomenti[i] = mc.Materia;
                i++;
            }
        }
    }
}
