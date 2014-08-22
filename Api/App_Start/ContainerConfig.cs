using System.Web.Http;
using Api.IocContainer;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Api
{
	public class ContainerConfig
	{
		public static void Configure()
		{
			var container = new Container();

			AppBindings.Bind(container);

			// This is an extension method from the integration package.
			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

			container.Verify();

			GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
		}
	}
}