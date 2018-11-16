﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageApiDemo.Services
{
	public class DataService<T> : IDataService<T> where T : class
	{
		//fields
		private MyDbContext _context;
		private DbSet<T> _dbSet;

		//constructor
		public DataService()
		{
			_context = new MyDbContext();
			_dbSet = _context.Set<T>();
		}

		public void Create(T entity)
		{
			_dbSet.Add(entity);
			_context.SaveChanges(); // commit in TSQL
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
			_context.SaveChanges();
		}

		public IEnumerable<T> GetAll()
		{
			return _dbSet.ToList();
		}

		public T GetSingle(Func<T, bool> predicate)
		{
			return _context.Set<T>().FirstOrDefault(predicate);
		}

		public IEnumerable<T> Query(Func<T, bool> predicate)
		{
			return _context.Set<T>().Where(predicate);
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
			_context.SaveChanges();
		}

	}
}
