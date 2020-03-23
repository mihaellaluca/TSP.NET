using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Laborator4
{
	public class Customer
	{
		public string CustomerId { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public ICollection<Order> Orders { get; set; }
	}

}
