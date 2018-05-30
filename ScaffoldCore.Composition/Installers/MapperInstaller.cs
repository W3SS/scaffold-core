using Autofac;
using AutoMapper;
using ScaffoldCore.Infrastructure.Interfaces;

namespace ScaffoldCore.Composition.Installers
{
	public class MapperInstaller : IBuilder
	{
		private readonly ContainerOptions _options;

		public MapperInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var configuration = new MapperConfiguration(cfg =>
			{
				cfg.CreateMissingTypeMaps = true;
			});

			var mapper = new Mapper(configuration);

			builder
				.RegisterInstance<IMapper>(mapper)
				.SingleInstance();
		}
	}
}
