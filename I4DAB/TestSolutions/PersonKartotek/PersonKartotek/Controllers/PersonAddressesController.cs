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
using PersonKartotek.Models;

namespace PersonKartotek.Controllers
{
    public class PersonAddressesController : ApiController
    {
        private PersonKartotekContext db = new PersonKartotekContext();

        // GET: api/PersonAddresses
        public IEnumerable<PersonAddressDTO> GetPersonAddresses()
        {
            List<PersonAddressDTO> personAddresses = new List<PersonAddressDTO>();
            foreach (PersonAddress pa in db.PersonAddresses)
            {
                personAddresses.Add(new PersonAddressDTO(pa));
            }
            return personAddresses;
        }

        // GET: api/PersonAddresses/5
        [ResponseType(typeof(PersonAddressDTO))]
        public async Task<IHttpActionResult> GetPersonAddress(int id)
        {
            PersonAddress personAddress = await db.PersonAddresses.FindAsync(id);
            if (personAddress == null)
            {
                return NotFound();
            }

            return Ok(new PersonAddressDTO(personAddress));
        }

        // PUT: api/PersonAddresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersonAddress(int id, PersonAddress personAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personAddress.Id)
            {
                return BadRequest();
            }

            db.Entry(personAddress).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonAddressExists(id))
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

        // POST: api/PersonAddresses
        [ResponseType(typeof(PersonAddress))]
        public async Task<IHttpActionResult> PostPersonAddress(PersonAddress personAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonAddresses.Add(personAddress);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = personAddress.Id }, personAddress);
        }

        // DELETE: api/PersonAddresses/5
        [ResponseType(typeof(PersonAddress))]
        public async Task<IHttpActionResult> DeletePersonAddress(int id)
        {
            PersonAddress personAddress = await db.PersonAddresses.FindAsync(id);
            if (personAddress == null)
            {
                return NotFound();
            }

            db.PersonAddresses.Remove(personAddress);
            await db.SaveChangesAsync();

            return Ok(personAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonAddressExists(int id)
        {
            return db.PersonAddresses.Count(e => e.Id == id) > 0;
        }
    }
}