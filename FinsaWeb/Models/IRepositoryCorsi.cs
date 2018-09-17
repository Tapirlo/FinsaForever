using System;
using System.Collections.Generic;
using CorsiOnline.Models.Database;
namespace CorsiOnline.Models
{
    public interface IRepositoryCorsi
    {
        IEnumerable<Corso> GetAllCorsi();
    }
}
