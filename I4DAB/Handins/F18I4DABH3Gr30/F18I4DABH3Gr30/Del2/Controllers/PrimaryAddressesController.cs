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
using Del2.DAL;
using Del2.Models;

namespace Del2.Controllers
{
    public class PrimaryAddressesController : ApiController
    {
        private PersonKartotekContext db = new PersonKartotekContext();

        // GET: api/PrimaryAddresses
        public IQueryable<PrimaryAddress> GetPrimaryAddresses()
        {
            return db.PrimaryAddresses;
        }

        // GET: api/PrimaryAddresses/5
        [ResponseType(typeof(PrimaryAddress))]
        public async Task<IHttpActionResult> GetPrimaryAddress(int id)
        {
            PrimaryAddress primaryAddress = await db.PrimaryAddresses.FindAsync(id);
            if (primaryAddress == null)
            {
                return NotFound();
            }

            return Ok(primaryAddress);
        }

        // PUT: api/PrimaryAddresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrimaryAddress(int id, PrimaryAddress primaryAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != primaryAddress.Id)
            {
                return BadRequest();
            }

            db.Entry(primaryAddress).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrimaryAddressExists(id))
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

        // POST: api/PrimaryAddresses
        [ResponseType(typeof(PrimaryAddress))]
        public async Task<IHttpActionResult> PostPrimaryAddress(PrimaryAddress primaryAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PrimaryAddresses.Add(primaryAddress);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = primaryAddress.Id }, primaryAddress);
        }

        // DELETE: api/PrimaryAddresses/5
        [ResponseType(typeof(PrimaryAddress))]
        public async Task<IHttpActionResult> DeletePrimaryAddress(int id)
        {
            PrimaryAddress primaryAddress = await db.PrimaryAddresses.FindAsync(id);
            if (primaryAddress == null)
            {
                return NotFound();
            }

            db.PrimaryAddresses.Remove(primaryAddress);
            await db.SaveChangesAsync();

            return Ok(primaryAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrimaryAddressExists(int id)
        {
            return db.PrimaryAddresses.Count(e => e.Id == id) > 0;
        }
    }
}