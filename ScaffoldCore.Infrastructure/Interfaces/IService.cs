using AutoMapper;
using Serilog;
using System.Data;

namespace ScaffoldCore.Infrastructure.Interfaces
{
	public interface IService
	{
		IMapper Mapper { get; }
		ILogger Logger { get; }
	}
}
