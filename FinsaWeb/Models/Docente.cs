using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models
{
    public class Docente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public DateTime DataNascita { get; set; }
        public string Telefono { get; set; }
        public string CodFiscale { get; set; }
    }
}
