using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDB.Repositories;
using System.Net;
using DDB.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace DDB
{
	public class UnitOfWork
	{
		public Repository Repository;
		
		public UnitOfWork(Repository repository)
		{
			Repository = repository;
		}
	}
}
