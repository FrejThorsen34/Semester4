using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGridInfo.DAL.Repositories;

namespace SmartGridInfo.DAL
{
    public interface IUnitOfWork
    {
        ISmartMeterRepository SmartMeterRepository { get; set; }
        IConnectionRepository ConnectionRepository { get; set; }
        void Save();
        Task SaveAsync();
    }
}
