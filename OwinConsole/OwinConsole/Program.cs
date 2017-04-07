using Microsoft.Owin.Hosting;
using Microsoft.Practices.Unity;
using System;

namespace OwinConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			IUnityContainer _container = UnityHelpers.GetConfiguredContainer();
			string baseAddress = "http://localhost:9000/";
			var startup = _container.Resolve<Startup>();
			IDisposable webApplication = WebApp.Start(baseAddress, startup.Configuration);

			try
			{
				Console.WriteLine($"Owin console started @ {baseAddress}");
				Console.ReadKey();
			}
			finally
			{
				webApplication.Dispose();
			}
		}
	}
}
