using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Del2.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Del2.DAL
{
	public class Repository<TEntity> where TEntity : BaseModel
	{
		protected readonly DbContext Context;

		public Repository(DbContext context)
		{
			Context = context;
		}

		public TEntity Get(int id)
		{
			return Context.Set<TEntity>().Find(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return Context.Set<TEntity>().ToList();
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return Context.Set<TEntity>().Where(predicate);
		}

		public void Add(TEntity entity)
		{
			Context.Set<TEntity>().Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().AddRange(entities);
		}

		public void Remove(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().RemoveRange(entities);
		}

		public void Update(int id, TEntity entity)
		{
			if (id != entity.Id)
			{
				Context.Set<TEntity>().Add(entity);
			}
			else
			{
				Context.Set<TEntity>().AddOrUpdate(entity);
			}
		}
	}
}