using Autofac;
using ScaffoldCore.Infrastructure.Exceptions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using ScaffoldCore.Infrastructure.Interfaces;

namespace ScaffoldCore.Composition.Installers
{
	public class RedisInstaller : IBuilder
	{
		private readonly ContainerOptions _options;

		public RedisInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			try
			{
				var connection = ConnectionMultiplexer.Connect($"{_options.Caching.RedisHost}:{_options.Caching.RedisPort}");
				IDatabase db = connection.GetDatabase(_options.Caching.RedisDatabaseId);

				builder
					.RegisterInstance<IConnectionMultiplexer>(connection)
					.SingleInstance();

				builder
					.RegisterInstance<IDatabase>(db)
					.SingleInstance();
			}
			catch (Exception ex)
			{
				throw new HandledException(ExceptionType.Service, ex.Message);
			}
		}
	}
}
