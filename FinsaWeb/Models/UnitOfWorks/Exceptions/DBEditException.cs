using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models.UnitOfWorks.Exceptions
{
    public class DBEditException : Exception
    {
        public DBEditException(string message): base(message)
        {

        }      

    }
}
