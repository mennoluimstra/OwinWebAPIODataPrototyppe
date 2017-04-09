using OwinConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OwinConsole.Services
{
	public class OrderDataService : IOrderDataService
	{
		private List<Order> _orders = new List<Order>();

		public OrderDataService()
		{
			_orders.Add(new Order { ID = 1, Name = "Order1", Description = "This is the first Order.", TotalPrice = 20.98m, OrderDate = DateTime.Now });
		}

		public void Add(Order Order)
		{
			_orders.Add(Order);
		}

		public Order GetOrder(int id)
		{
			return _orders.FirstOrDefault(p => p.ID == id);
		}

		public IQueryable<Order> GetAllOrders()
		{
			return _orders.AsQueryable();
		}

		public void Update(Order order)
		{
			var orderFound = _orders.FirstOrDefault(p => p.ID == order.ID);
			if (orderFound != null)
			{
				orderFound.Name = order.Name;
				orderFound.Description = order.Description;
				orderFound.TotalPrice = order.TotalPrice;
				orderFound.OrderDate = order.OrderDate;
			}
		}

		public void Delete(int id)
		{
			var orderFound = _orders.FirstOrDefault(p => p.ID == id);
			if (orderFound != null)
			{
				_orders.Remove(orderFound);
			}
		}
	}
}
