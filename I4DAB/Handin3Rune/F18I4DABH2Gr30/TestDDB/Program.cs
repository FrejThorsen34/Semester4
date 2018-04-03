using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using DDB;
using DDB.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

using System.Configuration;
using DDB.Repositories;

namespace TestDDB
{
	class Program
	{

		private const string EndpointUrl = "https://localhost:8081";

		private static string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
	
		static void Main(string[] args)
		{

			try
			{
				Program p = new Program();
				p.MainAsync().Wait();
			}
			catch (DocumentClientException de)
			{
				Exception baseException = de.GetBaseException();
				Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
			}
			catch (Exception e)
			{
				Exception baseException = e.GetBaseException();
				Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
			}
			finally
			{
				Console.WriteLine("Press any key to exit.");
				Console.ReadKey();
			}
		}

		private async Task MainAsync()
		{
			DocumentClient client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
			Repository repo = new Repository(client);
			UnitOfWork UOW = new UnitOfWork(repo);

			//string databaseId = "PersonKartotek";
			//string collectionName = "People";

			await client.CreateDatabaseIfNotExistsAsync(new Database { Id = "PersonKartotek" });
			await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("PersonKartotek"), new DocumentCollection { Id = "People" });

			Person person = new Person
			{
				FirstName = "Jens",
				MiddleName = "Kjeld",
				LastName = "Larsen",
				Email = "JKL@minmail.dk",
				PersonType = "co-worker",
				PhoneNumbers = new PhoneNumber[]
				{
					new PhoneNumber()
					{
						Number = "12345678",
						PhoneType = "Home",
						Provider = "TDC"
					},
					new PhoneNumber()
					{
						Number = "87654321",
						PhoneType = "Work",
						Provider = "Telia"
					}
				},
				PrimaryAddress = new PrimaryAddress
				{
					Street = "Ringgaden",
					StreetNumber = "154A",
					Zip = new Zip()
					{
						Country = "Denmark",
						Zipcode = "8000",
						Town = "Aarhus C"
					}
				},
			SecondaryAddresses = new AddressType[]
				{
					new AddressType()
					{
						Address = new Address()
						{
							StreetNumber = "11B",
							Street = "Vejen",
							Zip = new Zip()
							{
								Country = "Denmark",
								Zipcode = "8000",
								Town = "Aarhus C"
							}
						},
						Type = "Home"
					},
					new AddressType()
					{
						Address = new Address()
						{
							StreetNumber = "89E",
							Street = "Arbejdsvej",
							Zip = new Zip()
							{
								Country = "Denmark",
								Zipcode = "8000",
								Town = "Aarhus C"
							}
						},
						Type = "Work"
					}
				}
			};

			//create operations
			await UOW.Repository.Add("PersonKartotek", "People", person);
		}
	}
}
