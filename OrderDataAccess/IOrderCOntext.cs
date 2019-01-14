using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDataAccess
{
	public interface IOrderContext : IDisposable
	{
		DbSet<Product> Products { get; }
		DbSet<Order> Orders { get; }
		int SaveChanges();
		void MarkAsModified(Order item);
	}
}
