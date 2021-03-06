﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;
using CorsiOnline.Models;
using Microsoft.EntityFrameworkCore;


namespace CorsiOnline.Models.Core
{
    public class RepositoryAule : IAulaRepository
    {
        private ContestoFinsa context;

        public RepositoryAule (ContestoFinsa c)
        {
            context = c;
        }

        public bool AggiungiAula(Aula aula)
        {
            context.Aule.Add(aula);
            return true;            
        }

        public bool RegistraAulaPerCorso(string a, string c, DateTime d)
        {
            context.PrenotazioniAule.Add(new PrenotazioneAula
            {
                Corso = c,
                Aula = a,
                Data = d,

            });            
            return true;
        }
        public IEnumerable<Aula> GetAllAula()
        {
            return context.Aule.ToList();
        }

        public bool UpdateAula(Aula a)
        {
           Aula vecchia = context.Aule.Where(x => x.NomeAula == a.NomeAula).First();

           vecchia.NomeAula = a.NomeAula;
           vecchia.NumeroComputer = a.NumeroComputer;
           vecchia.NumeroPosti = a.NumeroPosti;
           vecchia.Superficie = a.Superficie;
           return true;
            
        }

        public Aula GetAulaById(string id)
        {
            return context.Aule.Where(x => x.NomeAula == id).Include(x => x.PrenotazioniAule).First();
        }
        
        
    }
}
