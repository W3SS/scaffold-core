using Autofac;

namespace ScaffoldCore.Infrastructure.Interfaces
{
	public interface IBuilder
	{
		void Install(ContainerBuilder builder);
	}
}
