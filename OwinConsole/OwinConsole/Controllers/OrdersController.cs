using OwinConsole.Models;
using OwinConsole.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Extensions;
using System.Web.OData.Query;

namespace OwinConsole.Controllers
{
	public class OrdersController : ODataController
	{
		private readonly IOrderDataService _orderDataService;

		public OrdersController(IOrderDataService orderDataService)
		{
			_orderDataService = orderDataService;
		}

		private bool OrderExists(int key)
		{
			return _orderDataService.GetAllOrders().Any(p => p.ID == key);
		}

		[EnableQuery]
		public PageResult<Order> Get(ODataQueryOptions<Order> queryOptions)
		{
			var results = queryOptions.ApplyTo(_orderDataService.GetAllOrders());
			var res = results as IEnumerable<Order>;
			return new PageResult<Order>(results as IEnumerable<Order>, Request.ODataProperties().NextLink, res.Count());
		}

		//[EnableQuery]
		//public IQueryable<Order> Get()
		//{
		//	return _orderDataService.GetAllOrders();
		//}
		//[EnableQuery]
		//public SingleResult<Order> Get([FromODataUri] int key)
		//{
		//	IQueryable<Order> result = _orderDataService.GetAllOrders().Where(p => p.ID == key);
		//	return SingleResult.Create(result);
		//}
	}
}
