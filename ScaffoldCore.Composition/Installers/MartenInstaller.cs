using Autofac;
using Marten;
using ScaffoldCore.Infrastructure.Factories;
using ScaffoldCore.Infrastructure.Interfaces;

namespace ScaffoldCore.Composition.Installers
{
	public class MartenInstaller : IBuilder
	{
		private readonly ContainerOptions _options;

		public MartenInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var store = DocumentStore.For(_options.Database.PostgresConnectionString);

			builder
				.RegisterInstance<IDocumentStore>(store)
				.SingleInstance();
		}
	}
}
