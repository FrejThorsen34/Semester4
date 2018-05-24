using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProsumerInfo.DAL;
using ProsumerInfo.Models;

namespace ProsumerInfo.Controllers
{
    public class ProsumersController : ApiController
    {
        private static readonly ProsumerInfoContext db = new ProsumerInfoContext();
	    private readonly IUnitOfWork _uow = new UnitOfWork(db);

        // GET: api/Prosumers
        public async Task<IEnumerable<Prosumer>> GetProsumers()
        {
				return await _uow.ProsumerRepository.GetAllAsync();
        }

        // GET: api/Prosumers/5
        [ResponseType(typeof(Prosumer))]
        public async Task<IHttpActionResult> GetProsumer(string id)
        {
            Prosumer prosumer = await db.Prosumers.FindAsync(id);
            if (prosumer == null)
            {
                return NotFound();
            }

            return Ok(prosumer);
        }

        // PUT: api/Prosumers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProsumer(string id, double production, double consumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

	        Prosumer prosumer = await db.Prosumers.FindAsync(id);
	        if (prosumer == null)
	        {
		        return BadRequest();
			}

            db.Entry(prosumer).State = EntityState.Modified;
	        prosumer.Production = production;
	        prosumer.Consumption = consumption;
	        prosumer.Balance = production - consumption;

            try
            {
	            await _uow.ProsumerRepository.UpdateAsync(prosumer, id);
	            await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProsumerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Prosumers
        [ResponseType(typeof(Prosumer))]
        public async Task<IHttpActionResult> PostProsumer([FromBody]Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prosumers.Add(prosumer);

            try
            {
				//await _uow.ProsumerRepository.Add(prosumer);
	            await _uow.SaveAsync();
			}
            catch (DbUpdateException)
            {
                if (ProsumerExists(prosumer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = prosumer.Id }, prosumer);
        }

        // DELETE: api/Prosumers/5
        [ResponseType(typeof(Prosumer))]
        public async Task<IHttpActionResult> DeleteProsumer(string id)
        {
            Prosumer prosumer = await db.Prosumers.FindAsync(id);
            if (prosumer == null)
            {
                return NotFound();
            }

	        Identity identity = await db.Identities.FindAsync(prosumer.IdentityId);
	        if (identity == null)
	        {
		        return NotFound();
	        }

			db.Identities.Remove(identity);
	        db.Prosumers.Remove(prosumer);
			await db.SaveChangesAsync();

            return Ok(prosumer);
        }

		/*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
		*/

        private bool ProsumerExists(string id)
        {
            return db.Prosumers.Count(e => e.Id == id) > 0;
        }
    }
}