using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderDataAccess;
using OrderService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace OrderService.Tests.Controllers
{
	[TestClass]
	public class TestOrderController
	{
		[TestMethod]
		private ICollection<Product> GetTestProducts()
		{
			var testProducts = new List<Product>();
			testProducts.Add(new Product { Id = 1, Name = "orange", Price = 2.34, Unit = 1 });
			testProducts.Add(new Product { Id = 2, Name = "apple", Price = 2, Unit = 5 });

			return testProducts;
		}

		private TestOrderContext GetOrder()
		{
			var context = new TestOrderContext();
			context.Orders.Add(new Order
			{
				Id = 2,
				Email = "iypiter@gmail.com",
				DeliveryAddress = "Ukraine, Chernivtsi, Ruska287",
				Products = GetTestProducts().Where(t => (t.Id == 1 && t.Id == 4 && t.Id == 2)).ToList()
			});
			context.Orders.Add(new Order
			{
				Id = 3,
				Email = "iypiter@gmail.com",
				DeliveryAddress = "Ukraine, Chernivtsi, Ruska287",
				Products = GetTestProducts().Where(t => (t.Id == 5 && t.Id == 2)).ToList()
			});
			context.Orders.Add(new Order
			{
				Id = 4,
				Email = "iypiter@gmail.com",
				DeliveryAddress = "Ukraine, Chernivtsi, Ruska287",
				Products = GetTestProducts().Where(t => (t.Id == 4 && t.Id == 3)).ToList()
			});
			return context;
		}

		[TestMethod]
		public void GetAllOrders()
		{
			var controller = new OrdersController(GetOrder());
			IEnumerable<Order> result = controller.GetOrders();
			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Count());
		}

		[TestMethod]
		public void GetOrderById()
		{
			// Set up Prerequisites
			var controller = new OrdersController(GetOrder());
			// Act  
			Order result = controller.GetOrders(2);

			// Assert  
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetAllOrders_CheckContainsProducts()
		{
			// Set up Prerequisites   
			var controller = new OrdersController(GetOrder());
			// Act  
			Order result = controller.GetOrders(2);

			// Assert  
			Assert.IsNotNull(result.Products);
		}

		[TestMethod]
		public void GetOrderById_CheckContainsProduct()
		{
			// Set up Prerequisites   
			var controller = new OrdersController(GetOrder());
			// Act  
			Order result = controller.GetOrders(2);

			// Assert  
			Assert.IsNotNull(result.Products);
		}

		[TestMethod]
		public void CreateOrder_ReturnsCreatedResponse()
		{
			
			// Arrange
			var context = new TestOrderContext();

			var testProducts = new List<Product>();
			foreach (var product in GetTestProducts())
			{
				testProducts.Add(context.Products.Add(product));
			}

			context.Orders.Add(new Order
			{
				Id = 1,
				Email = "iypiter@gmail.com",
				DeliveryAddress = "Ukraine, Chernivtsi, Ruska287",
				Products = testProducts
			});

			var controller = new OrdersController(context);
			// Act  
			var createdResponse = controller.CreateOrder(context.Orders.FirstOrDefault()) as NegotiatedContentResult<string>;
			
			// Assert
			Assert.AreEqual(HttpStatusCode.Created, createdResponse.StatusCode);
		}

		[TestMethod]
		public void CreateOrder_ReturnsBadResponse()
		{

			// Arrange
			var context = new TestOrderContext();

			var testProducts = new List<Product>();
			foreach (var product in GetTestProducts())
			{
				testProducts.Add(context.Products.Add(product));
			}

			context.Orders.Add(new Order
			{
				Id = 1,
				Email = "",
				DeliveryAddress = "Ukraine, Chernivtsi, Ruska287",
				Products = testProducts
			});

			var controller = new OrdersController(context);
			// Act  
			var createdResponse = controller.CreateOrder(context.Orders.FirstOrDefault()) as InvalidModelStateResult;

			// Assert
			Assert.AreEqual(false, createdResponse.ModelState.IsValid);
		}
	}
}