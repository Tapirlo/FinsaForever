using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;


namespace CorsiOnline.ViewModels
{
    public class DocenteModel
    {
        public Docente UnDocente { get; set; }

        public DocenteModel()
        {
            UnDocente = new Docente();
        }

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
