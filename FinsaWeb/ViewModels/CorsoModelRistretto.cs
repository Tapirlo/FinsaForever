using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;

namespace CorsiOnline.ViewModels
{
    public class CorsoModelRistretto
    {
        public String IDCorso { get; set; }
        public String Nome { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }

        public override string ToString()
        {
            return IDCorso + " " + Nome;
        }
        public CorsoModelRistretto()
        {

        }

        public CorsoModelRistretto(Corso c)
        {
            IDCorso = c.IDCorso;
            Nome = c.Nome;
            DataFine = c.DataFine;
            DataInizio = c.DataInizio;
            
        }
    }
}

