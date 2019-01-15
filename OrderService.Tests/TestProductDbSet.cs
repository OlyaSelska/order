using OrderDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Tests
{
	class TestProductDbSet : TestDbSet<Product>
	{
		public override Product Find(params object[] keyValues)
		{
			return this.SingleOrDefault(product => product.Id == (int)keyValues.Single());
		}
	}
}
