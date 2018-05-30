using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScaffoldCore.Infrastructure.Factories
{
	public interface IDbContextFactory
	{
		T CreateDatabaseContext<T>() where T : DbContext;
	}
}
