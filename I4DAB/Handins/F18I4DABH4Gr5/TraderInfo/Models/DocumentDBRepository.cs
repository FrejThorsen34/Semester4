using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace TraderInfo.Models
{
    public static class DocumentDBRepository<T> where T : class
    {
        private static readonly string DatabaseId = ConfigurationManager.AppSettings["database"];
        private static readonly string Collection1Id = ConfigurationManager.AppSettings["collection1"];
	    private static readonly string Collection2Id = ConfigurationManager.AppSettings["collection2"];
		private static DocumentClient client;

        public static void Initialize()
        {
            client = new DocumentClient(new Uri(ConfigurationManager.AppSettings["endpoint"]), ConfigurationManager.AppSettings["authKey"]);
            CreateDatabaseIfNotExistsAsync().Wait();
            CreateCollection1IfNotExistsAsync().Wait();
	        CreateCollection2IfNotExistsAsync().Wait();
		}

        private static async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }

        private static async Task CreateCollection1IfNotExistsAsync()
        {
            try
            {
                await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, Collection1Id));
			}
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = Collection1Id },
						new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw;
                }
            }
        }

	    private static async Task CreateCollection2IfNotExistsAsync()
	    {
		    try
		    {
			    await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, Collection2Id));
		    }
		    catch (DocumentClientException e)
		    {
			    if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
			    {
				    await client.CreateDocumentCollectionAsync(
					    UriFactory.CreateDatabaseUri(DatabaseId),
					    new DocumentCollection { Id = Collection2Id },
					    new RequestOptions { OfferThroughput = 1000 });
			    }
			    else
			    {
				    throw;
			    }
		    }
	    }

		public static async Task<IEnumerable<T>> ReadFutureTrade(Expression<Func<T, bool>> predicate)
        {
            IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, Collection1Id))
                .Where(predicate)
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }
	    public static async Task<IEnumerable<T>> ReadCompletedTrade(Expression<Func<T, bool>> predicate)
	    {
		    IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
				    UriFactory.CreateDocumentCollectionUri(DatabaseId, Collection2Id))
			    .Where(predicate)
			    .AsDocumentQuery();

		    List<T> results = new List<T>();
		    while (query.HasMoreResults)
		    {
			    results.AddRange(await query.ExecuteNextAsync<T>());
		    }

		    return results;
	    }

		public static async Task<IHttpActionResult> Update(CompletedTrade completedTrade)
        {
            try
            {
                await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, Collection2Id, completedTrade.Id), completedTrade);
                return new OkResult(new HttpRequestMessage());
            }
            catch (Exception)
            {
                return new NotFoundResult(new HttpRequestMessage());
            }
        }

        public static async Task<IHttpActionResult> Update(FutureTrade futureTrade)
        {
            try
            {
                await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, Collection1Id, futureTrade.Id), futureTrade);
                return new OkResult(new HttpRequestMessage());
            }
            catch (Exception)
            {
                return new NotFoundResult(new HttpRequestMessage());
            }
        }

        public static async Task<IHttpActionResult> Create(CompletedTrade completedTrade)
        {
            try
            {
                await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, Collection2Id, completedTrade.Id));
                return new BadRequestResult(new HttpRequestMessage());
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, Collection2Id), completedTrade);
                    return new OkResult(new HttpRequestMessage());
                }

                throw;
            }
        }

        public static async Task<IHttpActionResult> Create(FutureTrade futureTrade)
        {
            try
            {
                await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, Collection1Id, futureTrade.Id));
                return new BadRequestResult(new HttpRequestMessage());
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, Collection1Id), futureTrade);
                    return new OkResult(new HttpRequestMessage());
                }

                throw;
            }
        }

        public static async Task<IHttpActionResult> DeleteFutureTrade(string id)
        {
            try
            {
                await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, Collection1Id, id));
                return new OkResult(new HttpRequestMessage());
            }
            catch (Exception)
            {
                return new NotFoundResult(new HttpRequestMessage());
            }
        }

	    public static async Task<IHttpActionResult> DeleteCompletedTrade(string id)
	    {
		    try
		    {
			    await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, Collection2Id, id));
			    return new OkResult(new HttpRequestMessage());
		    }
		    catch (Exception)
		    {
			    return new NotFoundResult(new HttpRequestMessage());
		    }
	    }
	}
}