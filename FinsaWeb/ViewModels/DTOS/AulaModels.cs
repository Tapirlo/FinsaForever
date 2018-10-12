using CorsiOnline.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.ViewModels.DTOS
{
    public class AulaModels
    {

        public string NomeAula { get; set; }                
        public int NumeroPosti { get; set; }        
        public int NumeroComputer { get; set; }
        public int Superficie { get; set; }
        public Prenotazione[] Prenotazioni { get; set; }

        public AulaModels()
        {

        }

        public AulaModels(Aula aula)
        {
            NomeAula = aula.NomeAula;
            NumeroPosti = aula.NumeroPosti;
            NumeroComputer = aula.NumeroComputer;
            Superficie = aula.Superficie;
            Prenotazioni = new Prenotazione[aula.PrenotazioniAule.Count];
            int i = 0;
            foreach (PrenotazioneAula prenotazione in aula.PrenotazioniAule)
            {
                Prenotazioni[i++] = new Prenotazione(prenotazione.Corso, prenotazione.Data);
            }
        }

        public class Prenotazione
        {
            public string Corso { get; set; }
            public DateTime Data { get; set; }


            public Prenotazione()
            {

            }

            public Prenotazione(String corso, DateTime data)
            {
                Corso = corso;
                Data = data;

            }


        }


    }
}
