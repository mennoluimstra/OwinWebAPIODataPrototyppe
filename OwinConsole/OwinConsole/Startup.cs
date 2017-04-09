using Owin;
using OwinConsole.Models;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace OwinConsole
{
	public class Startup
	{
		// This code configures Web API. The Startup class is specified as a type
		// parameter in the WebApp.Start method.
		public void Configuration(IAppBuilder appBuilder)
		{
			// Configure Web API for self-host. 
			HttpConfiguration config = new HttpConfiguration();
			config.EnableDependencyInjection();

			config.EnableSystemDiagnosticsTracing();
			config.DependencyResolver = new UnityResolver(UnityHelpers.GetConfiguredContainer());

			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			// OData
			//ODataModelBuilder builder = new ODataConventionModelBuilder();
			//builder.EntitySet<Order>("Orders");
			//config.MapODataServiceRoute(
			//	routeName: "ODataRoute",
			//	routePrefix: null,
			//	model: builder.GetEdmModel());

			var modelBuilder = new ODataConventionModelBuilder();
			modelBuilder.EntitySet<Order>("Orders");
			config.MapODataServiceRoute(
				routeName: "OData", 
				routePrefix: "api", 
				model: modelBuilder.GetEdmModel());
			//appBuilder.UseWebApi(config);



			config.EnsureInitialized();


			appBuilder.UseWebApi(config);
		}
	}
}
