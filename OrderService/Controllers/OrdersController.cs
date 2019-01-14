using OrderDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.WebPages;
using Microsoft.Ajax.Utilities;

namespace OrderService.Controllers
{
	public class OrdersController : ApiController
	{
		private IOrderContext db = new OrderContext();

		public OrdersController() { }

		public OrdersController(IOrderContext context)
		{
			db = context;
		}

		[Route("api/orders")]
		[HttpGet]
		public IEnumerable<Order> GetOrders()
		{
			return db.Orders;
		}

		[ResponseType(typeof(Order))]
		[Route("api/orders/{Id}")]
		[HttpGet]
		public Order GetOrders(int Id)
		{
			return db.Orders.Find(Id);
		}

		[Route("api/products")]
		[HttpGet]
		public IQueryable<Product> GetProducts()
		{
			return db.Products;
		}

		[ResponseType(typeof(Order))]
		[Route("api/createorder")]
		[HttpPost]
		public IHttpActionResult CreateOrder([FromBody]Order order)
		{
			Validate(order);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				Order orderProduct = new Order()
				{
					Email = order.Email,
					DeliveryAddress = order.DeliveryAddress
				};

				foreach (var item in order.Products)
				{
					Product product = db.Products.FirstOrDefault(t => t.Id == item.Id);
					product.Unit = item.Unit;
					orderProduct.Products.Add(product);

				}

				db.Orders.Add(orderProduct);

				db.SaveChanges();
				return Content(HttpStatusCode.Created, $"Your Order Id is: {orderProduct.Id}");
			}
			catch
			{
				return InternalServerError();
			}
		}

		private void Validate(Order order)
		{
			//get existing products ids
			var products = db.Products.Select(t => t.Id).ToList();

			if (order.Email.IsEmpty())
				ModelState.AddModelError("Email", "Email is empty");
			if (order.DeliveryAddress.IsEmpty())
				ModelState.AddModelError("DeliveryAddress", "DeliveryAddress is empty");
			if(order.Products.Count == 0)
				ModelState.AddModelError("Products", "Please, add id of products that you want to order");
			if (order.Products != null)
			{
				foreach (var product in order.Products)
				{
					if(product.Unit <= 0)
						ModelState.AddModelError("Product.Unit", $"Unit of product Id = {product.Id} must be more then 0");
					if(!products.Contains(product.Id))
						ModelState.AddModelError("Product.Id", $"Product with Id = {product.Id} not found. If you want to know what product you can order check method 'products' ;)");
				}
			}



		}
	}
}
