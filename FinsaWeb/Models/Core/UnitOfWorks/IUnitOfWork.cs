using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void Begin();
        void End();
        void Save();
        void Cancel();
    }
}
