using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator4
{
	public class Order
	{
		public string OrderId { get; set; }
		public decimal TotalValue { get; set; }
		public DateTime date { get; set; }
		public Customer customer { get; set; }
	}
}
