﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.Core
{
    public interface DocentiRepository
    {
        IEnumerable<Docente> FindByName(string name);
    }
}