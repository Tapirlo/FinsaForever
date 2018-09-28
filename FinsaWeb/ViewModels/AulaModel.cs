using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;

namespace CorsiOnline.ViewModels
{
    public class AulaModel
    {
        
        public AulaModel(Aula a)
        {
            NomeAula = a.NomeAula;
            NumeroPosti = a.NumeroPosti;
            NumeroComputer = a.NumeroComputer;
            Superficie = a.Superficie;
        }
        public AulaModel()
        {

        }
        public Aula GetAula()
        {
            return new Aula(NomeAula, NumeroComputer, NumeroPosti, Superficie);
        }

        public string NomeAula { get; set; }
        
        public int NumeroPosti { get; set; }
        
        public int NumeroComputer { get; set; }
        
        public int Superficie { get; set; }
    }
}
