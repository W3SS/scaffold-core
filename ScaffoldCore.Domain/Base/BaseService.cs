using AutoMapper;
using ScaffoldCore.Infrastructure.Interfaces;
using System.Data;
using System;
using Serilog;

namespace ScaffoldCore.Domain.Base
{
	public abstract class BaseService : IService
	{
		public BaseService(IMapper mapper, ILogger logger)
		{
			Mapper = mapper;
			Logger = logger;
		}

		public IMapper Mapper { get; set; }
		public ILogger Logger { get; set; }
	}
}
