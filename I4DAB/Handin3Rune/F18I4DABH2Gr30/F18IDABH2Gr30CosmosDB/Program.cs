using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using DocumentDB.Repository;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Client.TransientFaultHandling;
using Newtonsoft.Json;

namespace F18IDABH2Gr30CosmosDB
{
    class Program
    {
        private const string EndpointUrl = "https://localhost:8081";

        private const string PrimaryKey =
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private const string databaseId = "PersonKartotekDB";

        //Changed client type for attempt 2
        //private DocumentClient client;
        public static IReliableReadWriteDocumentClient Client { get; set; }

        static void Main(string[] args)
        {
            IDocumentDbInitializer initializer = new DocumentDbInitializer();

            try
            {
                Client = initializer.GetClient(EndpointUrl, PrimaryKey);
                Task program = DemoAsync(args);
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message,
                    baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("End of demo, press any key to exit.");
                Console.ReadKey();
            }
        }

        private static async Task DemoAsync(string[] args)
        {
            //Create repository
            DocumentDbRepository<Person> repository = new DocumentDbRepository<Person>(Client, databaseId);

            //Create UnitOfWork
            UnitOfWork UOW = new UnitOfWork(repository);

            //Create zipcodes
            ZIP Aarhus = new ZIP
            {
                Country = "Denmark",
                Town = "Aarhus",
                ZipCode = "8000"
            };
            ZIP AarhusN = new ZIP
            {
                Country = "Denmark",
                Town = "Aarhus",
                ZipCode = "8200"
            };
            //Create a new person
            Person person1 = new Person
            {
                PersonId = "Nr1",
                Addresses = new Address[]
                {
                    new Address
                    {
                        AddressType = "Home",
                        Street = "Vestre Ringgade",
                        StreetNumber = "176",
                        ZIP = Aarhus
                    },
                    new Address
                    {
                        AddressType = "Work",
                        Street = "Finlandsgade",
                        StreetNumber = "17",
                        ZIP = Aarhus
                    },
                },
                Email = "nickolai@email.dk",
                FirstName = "Nickolai",
                LastName = "Ernst",
                MiddleName = "Lundby",
                PersonType = "Co-worker",
                PhoneNumbers = new PhoneNumber[]
                {
                    new PhoneNumber
                    {
                        Number = "12345678",
                        PhoneType = "Private",
                        Provider = "TDC"
                    },
                    new PhoneNumber
                    {
                        Number = "87654321",
                        PhoneType = "Work",
                        Provider = "TDC"
                    },
                }
            };

            //Add created person to database
            UOW.AddPerson(person1);

            //Create another person
            Person person2 = new Person
            {
                PersonId = "Nr2",
                Addresses = new Address[]
                {
                    new Address
                    {
                        AddressType = "Home",
                        Street = "Abildgade",
                        StreetNumber = "21",
                        ZIP = AarhusN
                    },
                    new Address
                    {
                        AddressType = "Work",
                        Street = "Finlandsgade",
                        StreetNumber = "17",
                        ZIP = Aarhus
                    },
                },
                Email = "rune@email.dk",
                FirstName = "Rune",
                LastName = "Keena",
                MiddleName = "Aagaard",
                PersonType = "Co-worker",
                PhoneNumbers = new PhoneNumber[]
                {
                    new PhoneNumber
                    {
                        Number = "88888888",
                        PhoneType = "Private",
                        Provider = "Telia"
                    },
                    new PhoneNumber
                    {
                        Number = "22222222",
                        PhoneType = "Work",
                        Provider = "TDC"
                    },
                }
            };

            //Add second person to database collection
            UOW.AddPerson(person2);
            //Now do the work
            await UOW.BodyOfWork();
            //Create operations tested.
            //Now test update operation
            person1.FirstName = "Martin";
            person1.LastName = "Jensen";
            person2.MiddleName = "Von";
            await UOW.BodyOfWork();

            //Read operation
            Person testPerson = new Person();
            testPerson = await UOW.ReadPerson(person2);
            Console.WriteLine($"Id of person2: {testPerson.PersonId}");

            //Delete operation
            UOW.DeletePerson(person1);
            await UOW.BodyOfWork();
        }
    }
}
