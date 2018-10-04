using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;

namespace CorsiOnline.ViewModels
{
    public class StudenteModels
    {
        public string CodiceFiscale { get; set; }
        public String Nome { get; set; }
        public String Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public String Sesso { get; set; }
        public int? Punteggio { get; set; }

        public override string ToString()
        {
            return CodiceFiscale + " " + Nome;
        }
        public StudenteModels()
        {

        }

        public StudenteModels(Studente s)
        {
            CodiceFiscale = s.CodiceFiscale;
            Nome = s.Nome;
            Cognome = s.Cognome;
            DataNascita = s.DataNascita;
            Sesso = s.Sesso;
                      

        }

        public StudenteModels(Studente s, int? punti): this(s)
        {
            Punteggio = punti;

        }
    }
}
