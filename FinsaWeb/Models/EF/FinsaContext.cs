﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF
{
    public class FinsaContext : DbContext
    {
        public FinsaContext(DbContextOptions<FinsaContext> options) : base(options)
        {

        }
        public DbSet<Docente> docenti { get; set; }
    }
}