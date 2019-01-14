using OrderDataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Tests
{
	public class TestOrderContext : IOrderContext
	{
		public TestOrderContext()
		{
			this.Orders = new TestOrderDbSet();
		}

		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }

		public int SaveChanges()
		{
			return 0;
		}

		public void MarkAsModified(Order item) { }
		public void Dispose() { }
	}
}
