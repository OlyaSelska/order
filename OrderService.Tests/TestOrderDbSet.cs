using OrderDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Tests
{
	class TestOrderDbSet : TestDbSet<Order>
	{
		public override Order Find(params object[] keyValues)
		{
			return this.SingleOrDefault(order => order.Id == (int)keyValues.Single());
		}
	}
}
