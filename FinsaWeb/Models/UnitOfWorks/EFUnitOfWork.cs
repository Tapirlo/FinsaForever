using CorsiOnline.Models.Core.UnitOfWorks;
using CorsiOnline.Models.Database;
using CorsiOnline.Models.UnitOfWorks.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsiOnline.Models.UnitOfWorks
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ContestoCorso ctx;

        public EFUnitOfWork( ContestoCorso contesto)
        {
            ctx = contesto;
        }
        public void Begin()
        {
            ctx.Database.BeginTransaction();
        }

        public void Cancel()
        {
            ctx.Database.CurrentTransaction?.Rollback();
        }

        public void End()
        {
            ctx.Database.CurrentTransaction?.Commit();
        }

        public void Save()
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new ConnectionException(e.Message);
            }
            catch (DbUpdateException e)
            {

                throw new DBEditException(e.Message);
            }
        }
    }
}
