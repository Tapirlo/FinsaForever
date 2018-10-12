using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using FluentAssertions;
using System.Linq;
using System;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;
using CorsiOnline.Models.Core;

namespace XUnitTestProject1.RepositoryTest
{
    public class RepositoryDocentiTest
    {
        private ContestoFinsa ctx;
        private IDocentiRepository docentiRepository;
        private static int counter = 0;

        public RepositoryDocentiTest()
        {
            var options = new DbContextOptionsBuilder<ContestoFinsa>()
                    .UseInMemoryDatabase("InMemory" + counter++)
                    .Options;
            ctx = new ContestoFinsa(options);
            docentiRepository = new RepositoryDocenti(ctx);
            ctx.Docenti.AddRange(CreaDocenti(10));
            ctx.SaveChanges();

        }

        private IEnumerable <Docente> CreaDocenti(int m)
        {
            Docente[] docenti = new Docente[m];
            for (int i = 0; i < m; i++)
            {
                docenti[i] = new Docente { Nome = "Test_Nome" + i, Cognome = "Test_Cognome" + i, CodiceFiscale = "Test_Cf" + i, DataNascita = DateTime.Today, Email = "Test_Email" + i, Telefono = "Test_Telefono" + i };
            }
            return docenti;
        }

        [Fact]
        public void GetDocentiByName()
        {
            var docenti = docentiRepository.FindByName("Test_Nome0");
            docenti.Should().HaveCount(1);

            docenti = docentiRepository.FindByName("Test_Nome");
            docenti.Should().HaveCount(10);

        }

        [Fact]
        public void GetDocentiBySurname()
        {
            var docenti = docentiRepository.FindBySurname("Test_Cognome0");
            docenti.Should().HaveCount(1);

            docenti = docentiRepository.FindBySurname("Test_Cognome");
            docenti.Should().HaveCount(10);

        }

        [Fact]
        public void GetDocentiByCodiceFiscale()
        {
            var docenti = docentiRepository.FindByCF("Test");
           

        }

        [Fact]
        public void GetAllDocenti()
        {
            var docenti = docentiRepository.GetAllDocenti();
            docenti.Should().HaveCount(10);
        }

        [Fact]
        public void AggiungiDocente()
        {
            int n = docentiRepository.GetAllDocenti().Count();
            bool ok = docentiRepository.AggiungiDocente(new Docente { Nome = "Test_Nome" + 11, Cognome = "Test_Cognome" + 11, CodiceFiscale = "Test_Cf" + 11, DataNascita = DateTime.Today, Email = "Test_Email" + 11, Telefono = "Test_Telefono" + 11 }, new Insegnamento[0]);
            int m = docentiRepository.GetAllDocenti().Count();
            m.Should().Equals(n + 1);
            ok.Should().BeTrue();
        }
        

    }
}
