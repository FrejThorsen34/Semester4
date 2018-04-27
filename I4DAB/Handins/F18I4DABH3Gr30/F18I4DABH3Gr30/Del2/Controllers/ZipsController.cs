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
		/// <summary>
		/// Returns all zips
		/// </summary>
		/// <returns></returns>
        // GET: api/Zips
        public IEnumerable<ZipDTO> GetZips()
        {
	        List<ZipDTO> zips = new List<ZipDTO>();
	        foreach (Zip z in db.Zips)
	        {
		        zips.Add(new ZipDTO(z));
	        }
	        return zips;
        }

        // GET: api/Zips/5
		/// <summary>
		/// Return zip and all addresses with that zip code
		/// </summary>
		/// <param name="id">Zipcode</param>
		/// <returns></returns>
        [ResponseType(typeof(ZipDTO))]
        public async Task<IHttpActionResult> GetZip(int id)
		{
			Zip zip = await db.Zips.FindAsync(id);
			if (zip == null)
			{
				return NotFound();
			}

	        return Ok(new ZipDTO(zip));
		}

        // PUT: api/Zips/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZip(int id, Zip zip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zip.Id)
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
                if (ZipExists(zip.Id))
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

        private bool ZipExists(int id)
        {
            return db.Zips.Count(e => e.Id == id) > 0;
        }
    }
}