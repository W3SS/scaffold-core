using Autofac;
using AutoMapper;
using ScaffoldCore.Infrastructure.Factories;
using ScaffoldCore.Infrastructure.Interfaces;

namespace ScaffoldCore.Composition.Installers
{
	public class ContextInstaller : IBuilder
	{
		private readonly ContainerOptions _options;

		public ContextInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var dbContext = new DbContextFactory(_options.Database.SqlConnectionString);

			builder
				.RegisterInstance<IDbContextFactory>(dbContext)
				.SingleInstance();
		}
	}
}
