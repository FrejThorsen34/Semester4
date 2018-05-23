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
    public class ConnectionsController : ApiController
    {
        private static readonly SmartGridInfoContext db = new SmartGridInfoContext();
	    private readonly IUnitOfWork _uow = new UnitOfWork(db);

		// GET: api/Connections
		public async Task<IEnumerable<Connection>> GetConnections()
		{
			return await _uow.ConnectionRepository.GetAllAsync();
		}

        // GET: api/Connections/5
        [ResponseType(typeof(Connection))]
        public async Task<IHttpActionResult> GetConnection(string id)
        {
            Connection connection = await db.Connections.FindAsync(id);
            if (connection == null)
            {
                return NotFound();
            }

            return Ok(connection);
        }

        // PUT: api/Connections/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConnection(string id, [FromBody]Connection connection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != connection.Id)
            {
                return BadRequest();
            }

            db.Entry(connection).State = EntityState.Modified;

            try
            {
	            await _uow.ConnectionRepository.UpdateAsync(connection, id);
	            await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectionExists(id))
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

        // POST: api/Connections
        [ResponseType(typeof(Connection))]
        public async Task<IHttpActionResult> PostConnection([FromBody]Connection connection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Connections.Add(connection);

            try
            {
                //await db.SaveChangesAsync();
	            await _uow.SaveAsync();
            }
            catch (DbUpdateException)
            {
                if (ConnectionExists(connection.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = connection.Id }, connection);
        }

        // DELETE: api/Connections/5
        [ResponseType(typeof(Connection))]
        public async Task<IHttpActionResult> DeleteConnection(string id)
        {
            Connection connection = await db.Connections.FindAsync(id);
            if (connection == null)
            {
                return NotFound();
            }

            db.Connections.Remove(connection);
            await db.SaveChangesAsync();

            return Ok(connection);
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

        private bool ConnectionExists(string id)
        {
            return db.Connections.Count(e => e.Id == id) > 0;
        }
    }
}