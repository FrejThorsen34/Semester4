using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PersonKartotekDD.Models;

namespace PersonKartotekDD.Controllers
{
    public class PersonController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return UOW.GetAllPeople();
        }

        // GET: api/Person/5
        public Person Get(string id)
        {
            return UOW.GetPerson(id);
        }

        // POST: api/Person
        public void Post([FromBody]string value)
        {
        }

                // PUT: api/Person/5
        public async Task<IHttpActionResult> Put(string id, [FromBody]string value)
        {
            Zip Aarhus = new Zip() { Country = "Denmark", Id = "1", Town = "Aarhus", ZipCode = "8000" };
            //Zip Odense = new Zip() { Country = "Denmark", Id = "2", Town = "Odense", ZipCode = "5000" };
            Address NickHome = new Address() { AddressType = "Home", Street = "Gammel Munkegade", Id = id, StreetNumber = "12A", Zip = Aarhus };
            Address NickWork = new Address() { AddressType = "Work", Id = "2", Street = "Finlandsgade", StreetNumber = "17", Zip = Aarhus };
            //Address RuneHome = new Address() { AddressType = "Home", Street = "Abildgade", Id = "3", StreetNumber = "8C", Zip = Aarhus };
            //Address RuneWork = new Address() { AddressType = "Work", Id = "4", Street = "Vestregade", StreetNumber = "2", Zip = Odense };
            Person Nick = new Person() { Addresses = new Address[] { NickHome, NickWork }, Email = "Nick@olai.dk", FirstName = "Nickolai", MiddleName = "Lundby", LastName = "Ernst", Id = "1", PersonType = "Co-worker", PhoneNumbers = new PhoneNumber[] { new PhoneNumber() { Id = "1", Number = "88888888", PhoneType = "Private", Provider = "TDC" } } };
            //Person Rune = new Person() { Addresses = new Address[] { RuneHome, RuneWork }, Email = "Ru@ne.dk", Id = "2", FirstName = "Rune", MiddleName = "Aagaard", LastName = "Keena", PersonType = "Co-worker", PhoneNumbers = new PhoneNumber[] { new PhoneNumber() { Id = "2", Number = "22222222", PhoneType = "Private", Provider = "Telia" } } };
            UOW.AddPerson(Nick);
            await UOW.BodyOfWork();
            return StatusCode(HttpStatusCode.Created);
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
