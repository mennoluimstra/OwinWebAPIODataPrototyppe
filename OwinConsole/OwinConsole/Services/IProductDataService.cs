using System.Linq;
using OwinConsole.Models;

namespace OwinConsole.Services
{
	public interface IProductDataService
	{
		void Add(Product product);
		void Delete(int id);
		IQueryable<Product> GetAllProducts();
		Product GetProduct(int id);
		void Update(Product product);
	}
}