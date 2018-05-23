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
using SmartGridInfo.DAL;
using SmartGridInfo.Models;

namespace SmartGridInfo.Controllers
{
    public class SmartMetersController : ApiController
    {
	    private static readonly SmartGridInfoContext db = new SmartGridInfoContext();
		private readonly IUnitOfWork _uow = new UnitOfWork(db);

        // GET: api/SmartMeters
        public IEnumerable<SmartMeterDTO> GetSmartMeters()
        {
			var smartMeterList = new List<SmartMeterDTO>();

			foreach (var sm in db.SmartMeters)
			{
				smartMeterList.Add(new SmartMeterDTO(sm));
	        }

	        return smartMeterList;
        }

        // GET: api/SmartMeters/5
        [ResponseType(typeof(SmartMeter))]
        public async Task<IHttpActionResult> GetSmartMeter(string id)
        {
            SmartMeterDTO smartMeter = new SmartMeterDTO(await db.SmartMeters.FindAsync(id));
            if (smartMeter.SerialNumber == null)
            {
                return NotFound();
            }

            return Ok(smartMeter);
        }

        // PUT: api/SmartMeters/5
		/*
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSmartMeter(string id, [FromBody]SmartMeter smartMeter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartMeter.SerialNumber)
            {
                return BadRequest();
            }

            db.Entry(smartMeter).State = EntityState.Modified;

            try
            {
	            await _uow.SmartMeterRepository.UpdateAsync(smartMeter, id);
	            await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartMeterExists(id))
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

        // POST: api/SmartMeters
        [ResponseType(typeof(SmartMeter))]
        public async Task<IHttpActionResult> PostSmartMeter([FromBody]SmartMeter smartMeter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SmartMeters.Add(smartMeter);

            try
            {
	            await _uow.SaveAsync();
            }
            catch (DbUpdateException)
            {
                if (SmartMeterExists(smartMeter.SerialNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = smartMeter.SerialNumber }, smartMeter);
        }
		*/

        // DELETE: api/SmartMeters/5
        [ResponseType(typeof(SmartMeter))]
        public async Task<IHttpActionResult> DeleteSmartMeter(string id)
        {
            SmartMeter smartMeter = await db.SmartMeters.FindAsync(id);
            if (smartMeter == null)
            {
                return NotFound();
            }

	        db.Connections.RemoveRange(smartMeter.Connections);
            db.SmartMeters.Remove(smartMeter);
	        await _uow.SaveAsync();
            //await db.SaveChangesAsync();

            return Ok(smartMeter);
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

        private bool SmartMeterExists(string id)
        {
            return db.SmartMeters.Count(e => e.SerialNumber == id) > 0;
        }
    }
}