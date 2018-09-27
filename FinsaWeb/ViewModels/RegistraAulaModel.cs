using CorsiOnline.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.ViewModels
{
    public class RegistraAulaModel
    {
        public string Aula
        {
            get; set;
        }
        public string  Corso
        {
            get; set;
        }
        public DateTime Data
        {
            get; set;
        }
     
    }
}
