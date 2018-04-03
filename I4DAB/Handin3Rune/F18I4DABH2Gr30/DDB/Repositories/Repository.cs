using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using DDB.Models;

namespace DDB.Repositories
{
	public class Repository
	{
		private DocumentClient _client;

		public Repository(DocumentClient client)
		{
			_client = client;
		}

		public async Task Add(string databaseName, string collectionName, Person person)
		{
			try
			{
				await this._client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, person.Id));
			}
			catch (DocumentClientException de)
			{
				if (de.StatusCode == HttpStatusCode.NotFound)
				{
					await this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
						person);
				}
				else
				{
					throw;
				}
			}
		}
	}
}
