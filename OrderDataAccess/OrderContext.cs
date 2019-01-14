using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDataAccess
{
	public class OrderContext : DbContext, IOrderContext
	{
		public OrderContext() : base("name=OrderDBEntities")
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }

		public void MarkAsModified(Order item)
		{
			Entry(item).State = EntityState.Modified;
		}
	}
}
