using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SmartGridInfo.DAL.Repositories;
using SmartGridInfo.Models;

namespace SmartGridInfo.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public SmartGridInfoContext Context { get; set; }
        public ISmartMeterRepository SmartMeterRepository { get; set; }
        public IConnectionRepository ConnectionRepository { get; set; }

        public UnitOfWork(SmartGridInfoContext context)
        {
            Context = context;
            SmartMeterRepository = new SmartMeterRepository(context);
            ConnectionRepository = new ConnectionRepository(context);
        }
        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

    }
}