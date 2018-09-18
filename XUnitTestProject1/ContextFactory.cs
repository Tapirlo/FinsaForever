using CorsiOnline.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1
{
    public static class ContextFactory
    {
        public static ContestoCorso CreateContext()
        {
            var builder = new DbContextOptionsBuilder<ContestoCorso>();
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DatabaseCorsi;Trusted_Connection=True;MultipleActiveResultSets=true");
            var ctx = new ContestoCorso(builder.Options);
            return ctx;
            
        }
    }
}
