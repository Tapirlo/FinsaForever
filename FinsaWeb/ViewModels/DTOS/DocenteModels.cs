using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;

namespace CorsiOnline.ViewModels.DTOS
{
    public class DocenteModels
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string CodiceFiscale { get; set; }
        public string Telefono { get; set; }
        public DateTime DataNascita { get; set; }
        
        public DocenteModels()
        {

        }

        public DocenteModels(Docente d)
        {
            Nome = d.Nome;
            Cognome = d.Cognome;
            Email = d.Email;
            CodiceFiscale = d.CodiceFiscale;
            Telefono = d.Telefono;
            DataNascita = d.DataNascita;

            Insegnamenti = new String[d.Insegnamenti.Count];
            int i = 0;
            foreach (var insegnamento in d.Insegnamenti)
            {
                Insegnamenti[i++] = insegnamento.Materia;
            }
        }

        public String[] Insegnamenti { get; set; }

        public IEnumerable<Insegnamento> GetInsegnamenti()
        {
            List<Insegnamento> lista = new List<Insegnamento>();
            for (int i = 0; i < Insegnamenti.Length; i++)
            {
                lista.Add(new Insegnamento
                {
                    Docente = this.CodiceFiscale,
                    Materia = this.Insegnamenti[i]

                });
            }
            return lista;
        }
        public Docente  AsDocente()
        {
            return new Docente
            {
                Nome = this.Nome,
                Cognome = this.Cognome,
                CodiceFiscale = this.CodiceFiscale,
                DataNascita = this.DataNascita,
                Telefono = this.Telefono,
                Email = this.Email
            };
        }

        
    }
}
