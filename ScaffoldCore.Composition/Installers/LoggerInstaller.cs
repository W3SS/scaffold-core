using Autofac;
using Serilog;
using ScaffoldCore.Infrastructure.Interfaces;

namespace ScaffoldCore.Composition.Installers
{
	public class LoggerInstaller : IBuilder
	{
		private readonly ContainerOptions _options;

		public LoggerInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

			builder
				.RegisterInstance<ILogger>(logger)
				.SingleInstance();
		}
	}
}
