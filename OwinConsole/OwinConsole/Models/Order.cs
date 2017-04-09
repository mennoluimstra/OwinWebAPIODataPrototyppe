using System;

namespace OwinConsole.Models
{
	public class Order
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
