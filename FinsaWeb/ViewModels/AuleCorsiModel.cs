using CorsiOnline.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.ViewModels
{
    public class AuleCorsiModel
    {
        public IEnumerable<Aula> Aule { get; set; }
        public IEnumerable<Corso> Corsi { get; set; }
        public AuleCorsiModel(IEnumerable<Aula>a,IEnumerable<Corso>c)
        {
            Aule = a;
            Corsi = c;
        }
    }
}
