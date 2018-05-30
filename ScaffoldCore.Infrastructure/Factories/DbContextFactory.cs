using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScaffoldCore.Infrastructure.Factories
{
	public class DbContextFactory : IDbContextFactory
	{
		private string ConnectionString;

		public DbContextFactory(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public T CreateDatabaseContext<T>() where T : DbContext
		{
			try
			{
				return (T)Activator.CreateInstance(typeof(T), ConnectionString);
			}
			catch (Exception ex)
			{
				throw new Exception("Error constructing a DbContext via DbContextFactory. See inner exception for details.", ex);
			}
		}

	}
}
