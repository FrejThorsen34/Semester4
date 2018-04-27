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
    public class PhoneNumbersController : ApiController
    {
        private PersonKartotekContext db = new PersonKartotekContext();
		
        // GET: api/PhoneNumbers
        public IEnumerable<PhoneNumberDTO> GetPhoneNumbers()
        {
			List<PhoneNumberDTO> phoneNumbers = new List<PhoneNumberDTO>();
	        foreach (PhoneNumber pn in db.PhoneNumbers)
	        {
		        phoneNumbers.Add(new PhoneNumberDTO(pn));
	        }
            return phoneNumbers;
        }

        // GET: api/PhoneNumbers/5
        [ResponseType(typeof(PhoneNumberDTO))]
        public async Task<IHttpActionResult> GetPhoneNumber(int id)
        {
            PhoneNumber phoneNumber = await db.PhoneNumbers.FindAsync(id);
            if (phoneNumber == null)
            {
                return NotFound();
            }

            return Ok(new PhoneNumberDTO(phoneNumber));
        }

        // PUT: api/PhoneNumbers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhoneNumber(int id, PhoneNumber phoneNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phoneNumber.Id)
            {
                return BadRequest();
            }

            db.Entry(phoneNumber).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneNumberExists(id))
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

        // POST: api/PhoneNumbers
        [ResponseType(typeof(PhoneNumber))]
        public async Task<IHttpActionResult> PostPhoneNumber(PhoneNumber phoneNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhoneNumbers.Add(phoneNumber);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = phoneNumber.Id }, phoneNumber);
        }

        // DELETE: api/PhoneNumbers/5
        [ResponseType(typeof(PhoneNumber))]
        public async Task<IHttpActionResult> DeletePhoneNumber(int id)
        {
            PhoneNumber phoneNumber = await db.PhoneNumbers.FindAsync(id);
            if (phoneNumber == null)
            {
                return NotFound();
            }

            db.PhoneNumbers.Remove(phoneNumber);
            await db.SaveChangesAsync();

            return Ok(phoneNumber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneNumberExists(int id)
        {
            return db.PhoneNumbers.Count(e => e.Id == id) > 0;
        }
    }
}