using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TraderInfo.Models;

namespace TraderInfo.Controllers
{
    public class FutureTradeController : ApiController
    {
        // GET: api/FutureTrade
		[ResponseType(typeof(FutureTrade))]
        public async Task<IEnumerable<FutureTrade>> Get()
		{
			return await DocumentDBRepository<FutureTrade>.ReadFutureTrade(t => true);
		}

		// GET: api/FutureTrade/5
		[ResponseType(typeof(FutureTrade))]
		public async Task<IHttpActionResult> Get(string id)
		{
			var trade = await DocumentDBRepository<FutureTrade>.ReadFutureTrade(t => t.Id == id);
			if (!trade.Any())
			{
				return NotFound();
			}

			return Ok(trade);
		}

		// POST: api/FutureTrade
		[ResponseType(typeof(FutureTrade))]
		public async Task<IHttpActionResult> Post(FutureTrade trade)
		{
			return await DocumentDBRepository<FutureTrade>.Create(trade);
		}

		// PUT: api/FutureTrade/5
		[ResponseType(typeof(FutureTrade))]
		public async Task<IHttpActionResult> Put(FutureTrade trade)
		{
			return await DocumentDBRepository<FutureTrade>.Update(trade);
		}

		// DELETE: api/FutureTrade/5
	    [ResponseType(typeof(FutureTrade))]
		public async Task<IHttpActionResult> Delete(string id)
	    {
		    return await DocumentDBRepository<FutureTrade>.DeleteFutureTrade(id);
	    }
	}
}
