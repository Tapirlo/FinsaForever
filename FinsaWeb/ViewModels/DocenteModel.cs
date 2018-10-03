using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;


namespace CorsiOnline.ViewModels
{
    public class DocenteModel
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string CodiceFiscale { get; set; }
        public string Telefono { get; set; }
        public DateTime DataNascita { get; set; }

        public DocenteModel()
        {
            UnDocente = new Docente();
        }
        public DocenteModel(Docente d)
        {
            UnDocente = new Docente();
            Nome = d.Nome;
            Cognome = d.Cognome;
            Email = d.Email;
            CodiceFiscale = d.CodiceFiscale;
            Telefono = d.Telefono;
            DataNascita = d.DataNascita;
        }

        public Docente UnDocente { get; set; }
        public String Materie { get; set; }

        public IEnumerable<Insegnamento> RegistraMaterie()
        {
            String[] materie = Materie.Split(" ");
            List<Insegnamento> insegnamenti = new List<Insegnamento>();
            for(int i=0;i<materie.Length;i++)
            {
                insegnamenti.Add(new Insegnamento { Docente = UnDocente.CodiceFiscale, Materia = materie[i] });
            }
            return insegnamenti;
        }
    }
}
