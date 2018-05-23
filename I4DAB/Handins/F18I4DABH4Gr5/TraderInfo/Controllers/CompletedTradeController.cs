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
    public class CompletedTradeController : ApiController
    {
		// GET: api/FutureTrade
	    [ResponseType(typeof(CompletedTrade))]
	    public async Task<IEnumerable<CompletedTrade>> Get()
	    {
		    return await DocumentDBRepository<CompletedTrade>.ReadCompletedTrade(t => true);
	    }

	    // GET: api/FutureTrade/5
	    [ResponseType(typeof(CompletedTrade))]
	    public async Task<IHttpActionResult> Get(string id)
	    {
		    var trade = await DocumentDBRepository<CompletedTrade>.ReadCompletedTrade(t => t.Id == id);
		    if (!trade.Any())
		    {
			    return NotFound();
		    }

		    return Ok(trade);
	    }

	    // POST: api/FutureTrade
	    [ResponseType(typeof(CompletedTrade))]
	    public async Task<IHttpActionResult> Post(CompletedTrade trade)
	    {
		    return await DocumentDBRepository<CompletedTrade>.Create(trade);
	    }

	    // PUT: api/FutureTrade/5
	    [ResponseType(typeof(CompletedTrade))]
	    public async Task<IHttpActionResult> Put(CompletedTrade trade)
	    {
		    return await DocumentDBRepository<CompletedTrade>.Update(trade);
	    }

	    // DELETE: api/FutureTrade/5
	    [ResponseType(typeof(CompletedTrade))]
	    public async Task<IHttpActionResult> Delete(string id)
	    {
		    return await DocumentDBRepository<CompletedTrade>.DeleteCompletedTrade(id);
	    }
	}
}
