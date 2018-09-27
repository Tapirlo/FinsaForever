using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;
using CorsiOnline.Models;


namespace CorsiOnline.Models.Core
{
    public class AulaRepository : IAulaRepository
    {
        private ContestoCorso context;

        public AulaRepository (ContestoCorso c)
        {
            context = c;
        }

        public bool AggiungiAula(Aula aula)
        {
            try
            {
                context.Aule.Add(aula);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RegistraAulaPerCorso(string a, string c, DateTime d)
        {
           // try
            {
            
                context.PrenotazioniAule.Add(new PrenotazioneAula
                {
                    Corso = c,
                    Aula = a,
                    Data = d,
                    
                });
                context.SaveChanges();
                return true;
               
            }
            /*catch (Exception)
            {
                return false;
            }*/
        }
        public IEnumerable<Aula> GetAllAula()
        {
            return context.Aule.ToList();
        }
    }
}
