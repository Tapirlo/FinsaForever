using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models.EF
{
    public class FinsaContext : DbContext
    {
        public FinsaContext(DbContextOptions<FinsaContext> options) : base(options)
        {
           //aaa
        }
        public DbSet<Docente> docenti { get; set; }
    }
}
