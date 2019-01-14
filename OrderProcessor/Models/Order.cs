using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcessor.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string DeliveryAddress { get; set; }
	}
}