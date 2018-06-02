using Microsoft.EntityFrameworkCore;
using ScaffoldCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScaffoldCore.Domain.Contexts
{
	public class SampleContext : DbContext
	{
		private readonly string ConnectionString;

		public SampleContext(string connectionString) : base()
		{
			ConnectionString = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer(ConnectionString);
		}

		public DbSet<SampleEntity> SampleEntities { get; set; }
	}
}
