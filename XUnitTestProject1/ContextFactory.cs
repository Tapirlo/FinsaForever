using CorsiOnline.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1
{
    public static class ContextFactory
    {
        public static ContestoFinsa CreateContext()
        {
            var builder = new DbContextOptionsBuilder<ContestoFinsa>();
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DatabaseCorsi;Trusted_Connection=True;MultipleActiveResultSets=true");
            var ctx = new ContestoFinsa(builder.Options);
            return ctx;
            
        }
    }
}
