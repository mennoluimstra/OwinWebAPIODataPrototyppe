using OwinConsole.Models;
using System.Collections.Generic;
using System.Linq;

namespace OwinConsole.Services
{
	public class ProductDataService : IProductDataService
	{
		private List<Product> _products = new List<Product>();

		public ProductDataService()
		{
			_products.Add(new Product { ID = 1, Name = "Product1", Description = "This is the first product.", Price = 1.50m, Stock = 100 });
		}

		public void Add(Product product)
		{
			_products.Add(product);
		}

		public Product GetProduct(int id)
		{
			return _products.FirstOrDefault(p => p.ID == id);
		}

		public IQueryable<Product> GetAllProducts()
		{
			return _products.AsQueryable();
		}

		public void Update(Product product)
		{
			var prod = _products.FirstOrDefault(p => p.ID == product.ID);
			if(prod != null)
			{
				prod.Name = product.Name;
				prod.Description = product.Description;
				prod.Price = product.Price;
				prod.Stock = product.Stock;
			}
		}

		public void Delete(int id)
		{
			var prod = _products.FirstOrDefault(p => p.ID == id);
			if (prod != null)
			{
				_products.Remove(prod);
			}
		}
	}
}
