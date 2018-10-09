using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;

namespace CorsiOnline.ViewModels.DTOS
{
    public class StudenteModels
    {
        public string CodiceFiscale { get; set; }
        public String Nome { get; set; }
        public String Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public String Sesso { get; set; }
        public int? Punteggio { get; set; }
        public string Email { get; set; }
        public string Corso { get; set; }

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
            Email = s.Email;             

        }

        public StudenteModels(Studente s, int? punti): this(s)
        {
            Punteggio = punti;

        }
        public StudenteModels(Studente s, string corso) : this(s)
        {
            Corso = corso;

        }
        public Studente AsStudente()
        {
            Studente s = new Studente
            {
                CodiceFiscale = this.CodiceFiscale,
                Nome = this.Nome,
                Cognome = this.Cognome,
                DataNascita = this.DataNascita,
                Sesso = this.Sesso,
                Email = this.Email
            };
            return s;

            
        }
    }
}
