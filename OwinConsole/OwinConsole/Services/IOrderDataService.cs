using System.Linq;
using OwinConsole.Models;

namespace OwinConsole.Services
{
	public interface IOrderDataService
	{
		void Add(Order Order);
		void Delete(int id);
		IQueryable<Order> GetAllOrders();
		Order GetOrder(int id);
		void Update(Order order);
	}
}