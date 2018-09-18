using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsiOnline.Models.Database;

namespace CorsiOnline.Models.Core
{
    public class StudenteRepository : IStundenteRepository
    {
        private static List<Studente> students = new List<Studente>
        {
            new Studente
            {
                CodiceFiscale = "XXXAAABBB",
                Nome = "Pasticcio",
                Cognome = "TestA",
                Email = "aaa@aa.aa",
                Sesso = "M"

            },
             new Studente
            {
                CodiceFiscale = "XXXAAACCC",
                Nome = "Pasticcione",
                Cognome = "TestB",
                Email = "aaa@aa.aa",
                Sesso = "X"

            },
              new Studente
            {
                CodiceFiscale = "XXXAAADDD",
                Nome = "Puccetta",
                Cognome = "TestC",
                Email = "aaa@aa.aa",
                Sesso = "F"

            }

        };

        public IEnumerable<Studente> FindByName(string name)
        {
            List<Studente> stud = new List<Studente>();
            for(int i=0;i<students.Count;i++)
            {
                if(students[i].Nome.Contains(name)||students[i].Cognome.Contains(name))
                {
                    stud.Add(students[i]);
                }
            }
            return stud;
        }

        public IEnumerable<Studente> FindAllStudents(string name)
        {
            List<Studente> stud = new List<Studente>();
            //da implementare
            return stud;
        }


    }
}
