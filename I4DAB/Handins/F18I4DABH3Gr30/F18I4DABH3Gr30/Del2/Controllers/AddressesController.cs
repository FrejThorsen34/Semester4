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
    public class AddressesController : ApiController
    {
        private PersonKartotekContext db = new PersonKartotekContext();

        // GET: api/Addresses
        public IQueryable<AddressDTO> GetAddresses()
        {
	        var addresses = from a in db.Addresses
		        select new AddressDTO()
		        {
			        Id = a.Id,
			        Street = a.Street,
					StreetNumber = a.StreetNumber,
					ZipCode = a.Zip.Zipcode
		        };
			return addresses;
        }

        // GET: api/Addresses/5
		/// <summary>
		/// Returns address based on address id
		/// </summary>
		/// <param name="id">id of the address</param>
		/// <returns></returns>
        [ResponseType(typeof(AddressDetailDTO))]
        public async Task<IHttpActionResult> GetAddress(int id)
        {
	        var address = await db.Addresses.Select(a =>
				new AddressDetailDTO()
				{
					Id = a.Id,
					Street = a.Street,
					StreetNumber = a.StreetNumber,
					ZipCode = a.Zip.Zipcode
				}).SingleOrDefaultAsync(a => a.Id == id);
			
			if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.Id)
            {
                return BadRequest();
            }

            db.Entry(address).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        [ResponseType(typeof(Address))]
        public async Task<IHttpActionResult> PostAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(address);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public async Task<IHttpActionResult> DeleteAddress(int id)
        {
            Address address = await db.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(address);
            await db.SaveChangesAsync();

            return Ok(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressExists(int id)
        {
            return db.Addresses.Count(e => e.Id == id) > 0;
        }
    }
}