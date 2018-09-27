using Xunit;
using System.Linq;
using System;
using CorsiOnline.Models.Database;
using CorsiOnline.Models;
using CorsiOnline.Models.Core;
using Xunit.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace XUnitTestProject1
{
    public class UnitTest1 : IDisposable
    {
        ContestoCorso _context;
        IRepositoryCorsi repoCorsi;
        ITestOutputHelper output;

        public UnitTest1()
        {
            _context = ContextFactory.CreateContext();
            repoCorsi = new RepositoryCorsi(_context);
            
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public void InserisciCorso()
        {
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                int CountCorsiIniziale = _context.Corsi.Count();
                Corso corsi = new Corso()
                {
                    Nome = "Test_Ciccio",                    
                    IDCorso = "10",                    
                    DataInizio = new DateTime(2018, 09, 01),
                    DataFine = new DateTime(2018, 12, 01)

                };
                repoCorsi.AggiungiCorso(corsi);
                Assert.Equal(CountCorsiIniziale + 1, _context.Corsi.Count());
                transaction.Rollback();
            }
        }


    }
}
