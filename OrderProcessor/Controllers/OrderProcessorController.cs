using OrderProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace OrderProcessor.Controllers
{
    public class OrderProcessorController : ApiController
    {
	    [Route("api/orders")]
	    [HttpGet]
	    public async Task<IEnumerable<Order>> Get()
	    {
		    var orders = new List<Order>();
		    using (var client = new HttpClient())
		    {
			    client.BaseAddress = new Uri("http://localhost:51498/api/");
			    //HTTP GET
			    var responseTask = client.GetAsync("orders");
			    responseTask.Wait();

			    var result = responseTask.Result;
			    if (result.IsSuccessStatusCode)
			    {

				    var readTask = result.Content.ReadAsAsync<Order[]>();
				    readTask.Wait();

				    var order = readTask.Result;

				    foreach (var item in order)
				    {
					    orders.Add(item);
				    }
			    }
		    }

		    return orders;
	    }

	    [Route("api/send")]
	    [HttpPost]
	    public IHttpActionResult SendEmail()
	    {
		    var orders = new List<Order>();
		    using (var client = new HttpClient())
		    {
			    client.BaseAddress = new Uri("http://localhost:51498/api/");
			    //HTTP GET
			    var responseTask = client.GetAsync("orders");
			    responseTask.Wait();

			    var result = responseTask.Result;
			    if (result.IsSuccessStatusCode)
			    {

				    var readTask = result.Content.ReadAsAsync<Order[]>();
				    readTask.Wait();

				    var order = readTask.Result;

				    foreach (var item in order)
				    {
					    orders.Add(item);
				    }
			    }
		    }

		    if (orders != null)
		    {
			    foreach (var order in orders)
			    {
					string subject = "Notification letter";
				    string body = "Your order created.";
				    string FromMail = "your@gmail.com";
				    string emailTo = order.Email;
				    MailMessage mail = new MailMessage();
				    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
				    mail.From = new MailAddress(FromMail);
				    mail.To.Add(emailTo);
				    mail.Subject = subject;
				    mail.Body = body;
				    SmtpServer.Credentials =
					    new System.Net.NetworkCredential("your@gmail.com", "password");
				    SmtpServer.EnableSsl = true;
				    SmtpServer.Send(mail);
				}
		    }

		    return Content(HttpStatusCode.Created, "Message send");
	    }
	}
}
