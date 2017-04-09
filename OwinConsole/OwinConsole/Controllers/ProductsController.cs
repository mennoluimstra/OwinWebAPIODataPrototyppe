using OwinConsole.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using OwinConsole.Models;

namespace OwinConsole.Controllers
{
	[RoutePrefix("api/products")]
	public class ProductsController : ApiController
	{
		private readonly IProductDataService _productDataService;

		public ProductsController(IProductDataService productDataService)
		{
			_productDataService = productDataService;
		}

		// GET api/values 
		public IEnumerable<Product> Get()
		{
			return _productDataService.GetAllProducts().AsEnumerable();
		}

		// GET api/values/5 
		public Product Get(int id)
		{
			return _productDataService.GetProduct(id);
		}

		// POST api/values 
		public void Post([FromBody]Product product)
		{
			_productDataService.Add(product);
		}

		// PUT api/values/5 
		public void Put([FromBody]Product product)
		{
			_productDataService.Update(product);
		}

		// DELETE api/values/5 
		public void Delete(int id)
		{
			_productDataService.Delete(id);
		}
	}
}
