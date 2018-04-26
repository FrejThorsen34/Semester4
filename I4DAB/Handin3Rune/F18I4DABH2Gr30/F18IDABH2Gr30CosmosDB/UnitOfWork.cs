using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentDB.Repository;

namespace F18IDABH2Gr30CosmosDB
{
    public class UnitOfWork : IDisposable
    {
        //=======================================
        //Per feedback, now utilizing a repository
        //https://github.com/Crokus/cosmosdb-repo
        //========================================
        private IDocumentDbRepository<Person> _personRepo;
        private List<Person> _updated = new List<Person>();
        private List<Person> _removed = new List<Person>();
        private List<Person> _added = new List<Person>();

        public UnitOfWork(DocumentDbRepository<Person> repository)
        {
            _personRepo = repository;
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
            return await _personRepo.GetByIdAsync(person.Id);
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
                await _personRepo.AddOrUpdateAsync(added);
            }
            //Updating
            foreach (var updated in _updated)
            {
                await _personRepo.AddOrUpdateAsync(updated);
            }
	        //Deleting
	        foreach (var removed in _removed)
	        {
		        await _personRepo.RemoveAsync(removed.Id);
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
