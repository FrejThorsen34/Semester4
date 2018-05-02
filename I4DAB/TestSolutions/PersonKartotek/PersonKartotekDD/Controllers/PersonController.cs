using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PersonKartotekDD.Models;
using Swashbuckle.Swagger;

namespace PersonKartotekDD.Controllers
{
    public class PersonController : ApiController
    {
        
        // GET: api/Person
		[ResponseType(typeof(Person))]
        public async Task<IEnumerable<Person>> GetPeople()
		{
			return await DocumentDBRepository<Person>.Read(p => true);
		}

		// GET: api/Person/5
		[ResponseType(typeof(Person))]
		public async Task<IHttpActionResult> GetById(string id)
        {
            var person = await DocumentDBRepository<Person>.Read(p => p.Id == id);
	        if (!person.Any())
		        return NotFound();
	        return Ok(person);
        }

        // POST: api/Person
	    [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult>Post(Person person)
	    {
		    return await DocumentDBRepository<Person>.Create(person);
	    }

        // PUT: api/Person/5
	    [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> Put(Person person)
	    {
		    return await DocumentDBRepository<Person>.Update(person);
	    }

		// DELETE: api/Person/5
		[ResponseType(typeof(Person))]
		public async Task<IHttpActionResult> Delete(string id)
		{
			return await DocumentDBRepository<Person>.Delete(id);
		}
    }
}
