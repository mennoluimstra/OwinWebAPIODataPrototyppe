using Microsoft.Practices.Unity;
using OwinConsole.Services;
using System;

namespace OwinConsole
{
	public static class UnityHelpers
	{
		#region Unity Container
		private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
		{
			var container = new UnityContainer();
			RegisterTypes(container);
			return container;
		});

		public static IUnityContainer GetConfiguredContainer()
		{
			return container.Value;
		}
		#endregion

		public static void RegisterTypes(IUnityContainer container)
		{
			container.RegisterType<IProductDataService, ProductDataService>(new ContainerControlledLifetimeManager());
			container.RegisterType<IOrderDataService, OrderDataService>(new ContainerControlledLifetimeManager());
		}

	}
}
