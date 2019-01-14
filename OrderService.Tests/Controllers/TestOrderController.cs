using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderDataAccess;
using OrderService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Tests.Controllers
{
	[TestClass]
	public class TestOrderController
	{
		[TestMethod]
		private List<Product> GetTestProducts()
		{
			var context = new TestOrderContext();

			var testProducts = new List<Product>();

			//testProducts.Add(context.Products.Add(new Product { Id = 1, Name = "orange", Price = 2.34, Unit = 1 }));
			//testProducts.Add(context.Products.Add(new Product { Id = 2, Name = "apple", Price = 2, Unit = 5 }));
			//testProducts.Add(context.Products.Add(new Product { Id = 3, Name = "pineapple", Price = 3.4, Unit = 3 }));
			//testProducts.Add(context.Products.Add(new Product { Id = 4, Name = "banana", Price = 1, Unit = 1 }));
			//testProducts.Add(context.Products.Add(new Product { Id = 5, Name = "strawberry", Price = 4.8, Unit = 2 }));
			testProducts.Add(new Product { Id = 1, Name = "orange", Price = 2.34, Unit = 1 });
			testProducts.Add(new Product { Id = 2, Name = "apple", Price = 2, Unit = 5 });
			testProducts.Add(new Product { Id = 3, Name = "pineapple", Price = 3.4, Unit = 3 });
			testProducts.Add(new Product { Id = 4, Name = "banana", Price = 1, Unit = 1 });
			testProducts.Add(new Product { Id = 5, Name = "strawberry", Price = 4.8, Unit = 2 });

			return testProducts;
		}

		[TestMethod]
		private List<Order> GetTestOrders()
		{
			var context = new TestOrderContext();

			var testOrders = new List<Order>();

			testOrders.Add(context.Orders.Add(new Order
			{
				Id = 1,
				Email = "ololo@gmail.com",
				DeliveryAddress = "Ukraine, Kyiv, Shevchenka32" ,
				Products = GetTestProducts().Where(t => (t.Id == 1 && t.Id == 2)).ToList()
			}));
			testOrders.Add(context.Orders.Add(new Order
			{
				Id = 2,
				Email = "iypiter@gmail.com",
				DeliveryAddress = "Ukraine, storozhynets, Soborna5a",
				Products = GetTestProducts().Where(t => (t.Id == 4 && t.Id == 3)).ToList()
			}));
			testOrders.Add(context.Orders.Add(new Order
			{
				Id = 3,
				Email = "earth@gmail.com",
				DeliveryAddress = "Ukraine, Chernivtsi, Simovycha19",
				Products = GetTestProducts().Where(t => (t.Id == 5 && t.Id == 2)).ToList()
			}));
			testOrders.Add(context.Orders.Add(new Order
			{
				Id = 4,
				Email = "neptun@gmail.com",
				DeliveryAddress = "Ukraine, Chernivtsi, Ruska287",
				Products = GetTestProducts().Where(t => (t.Id == 1 && t.Id == 4 && t.Id == 2)).ToList()
			}));

			return testOrders;
		}

		[TestMethod]
		public void GetAllOrders()
		{
			var context = new TestOrderContext();
			context.Orders.Add(new Order { Id = 1, Email = "iypiter@gmail.com", DeliveryAddress = "Ukraine, Chernivtsi, Ruska287" });
			context.Orders.Add(new Order { Id = 2, Email = "iypiter@gmail.com", DeliveryAddress = "Ukraine, Chernivtsi, Ruska287" });
			context.Orders.Add(new Order { Id = 3, Email = "iypiter@gmail.com", DeliveryAddress = "Ukraine, Chernivtsi, Ruska287" });
			context.Orders.Add(new Order { Id = 4, Email = "iypiter@gmail.com", DeliveryAddress = "Ukraine, Chernivtsi, Ruska287" });
			
			var controller = new OrdersController(context);
			var result = controller.GetOrders() as IEnumerable<Order>;
			Assert.IsNotNull(result);
			Assert.AreEqual(4, result.Count());
		}
	}
}
