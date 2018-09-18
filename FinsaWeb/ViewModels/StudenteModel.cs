using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;
namespace CorsiOnline.ViewModels
{
    public class StudenteModel
    {
        public IEnumerable<Corso> Corsi { get; set; }

        public Studente UnAlunno { get; set; }

        public StudenteModel()
        {
            UnAlunno = new Studente();
        }

        public String UnCorso { get; set; }
    }
}
