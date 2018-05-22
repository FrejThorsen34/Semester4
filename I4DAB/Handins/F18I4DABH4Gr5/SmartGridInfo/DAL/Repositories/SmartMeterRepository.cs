using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartGridInfo.Models;

namespace SmartGridInfo.DAL.Repositories
{
    public class SmartMeterRepository : Repository<SmartMeter>, ISmartMeterRepository
    {
        public SmartMeterRepository(SmartGridInfoContext context) : base(context)
        {

        }
    }
}