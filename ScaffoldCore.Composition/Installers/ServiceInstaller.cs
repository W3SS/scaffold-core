using Autofac;
using ScaffoldCore.Domain;
using System.Reflection;
using ScaffoldCore.Domain.Base;
using ScaffoldCore.Infrastructure.Interfaces;

namespace ScaffoldCore.Composition.Installers
{
	public class ServiceInstaller : IBuilder
	{
		private readonly ContainerOptions _options;

		public ServiceInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var ServiceAssembly = typeof(Init).GetTypeInfo().Assembly;

			builder
				.RegisterAssemblyTypes(ServiceAssembly)
				.Where(t => typeof(BaseService).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();
		}
	}
}
