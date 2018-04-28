using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DocumentDB.Repository;
using Microsoft.Azure.Documents.Client.TransientFaultHandling;

namespace PersonKartotekDD.Models
{
    public class UnitOfWork : IDisposable
    {
        public static IReliableReadWriteDocumentClient Client { get; set; }
        private readonly DocumentDbRepository<Person> _repository;
        private List<Person> _updated = new List<Person>();
        private List<Person> _removed = new List<Person>();
        private List<Person> _added = new List<Person>();

        private const string EndpointUrl = "https://localhost:8081";
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private const string DatabaseId = "PersonKartotekDB";

        public UnitOfWork()
        {
            IDocumentDbInitializer initializer = new DocumentDbInitializer();
            Client = initializer.GetClient(EndpointUrl, PrimaryKey);
            _repository = new DocumentDbRepository<Person>(Client, DatabaseId);
        }

        //================
        // CRUD-Operations
        //================

        //Create
        public void AddPerson(Person person)
        {
            _added.Add(person);
            WriteToConsoleAndPromptToContinue($"{person.FirstName} added to the add-queue");
        }

        //Read
        public async Task<Person> ReadPerson(Person person)
        {
            return await _repository.GetByIdAsync(person.Id);
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _repository.GetAllAsync().Result;
        }

        public Person GetPerson(string id)
        {
            return _repository.GetByIdAsync(id).Result;
        }

        //Update
        public void UpdatePerson(Person person)
        {
            _updated.Add(person);
            WriteToConsoleAndPromptToContinue($"{person.FirstName} added to the update-queue");
        }

        //Delete
        public void DeletePerson(Person person)
        {
            _removed.Add(person);
            WriteToConsoleAndPromptToContinue($"{person.FirstName} added to the delete-queue");
        }

        //Work
        public async Task BodyOfWork()
        {
            WriteToConsoleAndPromptToContinue("Working on the DB commencing");

            //Adding
            foreach (var added in _added)
            {
                await _repository.AddOrUpdateAsync(added);
            }
            //Updating
            foreach (var updated in _updated)
            {
                await _repository.AddOrUpdateAsync(updated);
            }
            //Deleting
            foreach (var removed in _removed)
            {
                await _repository.RemoveAsync(removed.Id);
            }

            WriteToConsoleAndPromptToContinue("Work on DB complete");
        }

        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}