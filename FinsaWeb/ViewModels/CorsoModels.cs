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

        public override string ToString()
        {
            return IDCorso+" "+Nome;
        }
        public CorsoModels()
        {

        }
        public Corso AsCorso()
        {
            Corso c = new Corso
            {
                IDCorso = this.IDCorso,
                Nome = this.Nome,
                DataFine = this.DataFine,
                DataInizio = this.DataInizio,
                MaterieCorsi = new List<MateriaCorso>()
            };
            for (int i = 0; i < Argomenti.Length; i++)
            {
                c.MaterieCorsi.Add(new MateriaCorso
                {
                    Corso = this.IDCorso,
                    Materia = Argomenti[i]
                });
            }
            return c;

          
        }
        public CorsoModels(Corso c)
        {
            IDCorso = c.IDCorso;
            Nome = c.Nome;
            DataFine = c.DataFine;
            DataInizio = c.DataInizio;
            var args = c.MaterieCorsi;
        
            if(args!=null)
            {
                Argomenti = new String[args.Count];
                int i = 0;
                foreach (MateriaCorso mc in args)
                {
                    Argomenti[i] = mc.Materia;
                    i++;
                }
            }
            else
            {
                Argomenti = new String[0];
            }
       
        }
    }
}
