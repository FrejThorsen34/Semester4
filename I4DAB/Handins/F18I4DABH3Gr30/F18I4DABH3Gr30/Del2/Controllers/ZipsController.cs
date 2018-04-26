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
    public class ZipsController : ApiController
    {
        private PersonKartotekContext db = new PersonKartotekContext();

        // GET: api/Zips
        public IQueryable<Zip> GetZips()
        {
            return db.Zips;
        }

        // GET: api/Zips/5
        [ResponseType(typeof(Zip))]
        public async Task<IHttpActionResult> GetZip(string id)
        {
            Zip zip = await db.Zips.FindAsync(id);
            if (zip == null)
            {
                return NotFound();
            }

            return Ok(zip);
        }

        // PUT: api/Zips/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZip(string id, Zip zip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zip.Zipcode)
            {
                return BadRequest();
            }

            db.Entry(zip).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZipExists(id))
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

        // POST: api/Zips
        [ResponseType(typeof(Zip))]
        public async Task<IHttpActionResult> PostZip(Zip zip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zips.Add(zip);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZipExists(zip.Zipcode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = zip.Zipcode }, zip);
        }

        // DELETE: api/Zips/5
        [ResponseType(typeof(Zip))]
        public async Task<IHttpActionResult> DeleteZip(string id)
        {
            Zip zip = await db.Zips.FindAsync(id);
            if (zip == null)
            {
                return NotFound();
            }

            db.Zips.Remove(zip);
            await db.SaveChangesAsync();

            return Ok(zip);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZipExists(string id)
        {
            return db.Zips.Count(e => e.Zipcode == id) > 0;
        }
    }
}