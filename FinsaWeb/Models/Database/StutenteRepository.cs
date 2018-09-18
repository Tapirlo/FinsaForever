using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models.Database
{
    public class StutenteRepository : IStundenteRepository
    {
        private static List<Studente> students = new List<Studente>
        {
            new Studente
            {
                Id = 1,
                Nome = "Pasticcio"
            },
             new Studente
            {
                Id = 2,
                Nome = "Pasticcione"

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

        
    }
}
