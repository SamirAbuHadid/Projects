using MStrudel.Domain.Abstract;
using MStrudel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Security;


namespace MStrudel.Domain.Concrete
{
	public class EmailOrderProcessor : IOrderProcessor
	{
		private EmailSettings _settings;

		public EmailOrderProcessor(EmailSettings settings)
		{
			_settings = settings;
		}

		public void ProcessOrder(Order order, Cart cart)
		{
			using(var smtpClient = new SmtpClient())
			{
				smtpClient.EnableSsl = _settings.UseSsl;
				smtpClient.Host = _settings.ServerName;
				smtpClient.Port = _settings.ServerPort;
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Credentials = new NetworkCredential(_settings.Username, _settings.Password);

				var body = new StringBuilder();
				body.AppendLine("Параметри замовлення:");
				body.AppendLine("------");
				body.AppendLine(string.Format("Замовник:{0} {1} {2}", order.Name, order.LastName, order.Phone));
				if(!string.IsNullOrWhiteSpace(order.Email))
				{
					body.AppendLine(string.Format("E-mail:{0}", order.Email));
				}
				body.AppendLine(string.Format("Адреса:{0}", order.Adress));
				body.AppendLine(string.Format("Дата доставки: {0}", order.DeliveryTime.ToString()));

				if(!string.IsNullOrWhiteSpace(order.Comment))
				{
					body.AppendLine(string.Format("Побажання: {0}", order.Comment));
				}

				body.AppendLine("------");
				body.AppendLine("Продукція:");
				body.AppendLine("------");

				foreach(var item in cart.Lines)
				{
					body.AppendLine(string.Format("{0} x {1} (Сума: {2:c}", item.Quantity, item.Product.Name, item.Product.Price * item.Quantity));
				}
				body.AppendLine("------");
				body.AppendLine(string.Format("Всього: {0:c}", cart.Lines.Sum(p => p.Quantity * p.Product.Price)));

				var mailMsg = new MailMessage(_settings.MailFrom,
											_settings.MailTo,
											"[Замовлення] Створено нове замовлення",
											body.ToString());
				smtpClient.Send(mailMsg);
			}
		}
	}

	public class EmailSettings
	{
		private string _password = ConfigurationManager.AppSettings["MailSenderPwd"];

		public string MailTo = "shtrudelnya@gmail.com";
		public string MailFrom = "shtrudelnya@gmail.com";
		public bool UseSsl = true;
		public string Username = ConfigurationManager.AppSettings["MailSenderUser"];
		public SecureString Password = new SecureString();
		public string ServerName = "smtp.gmail.com";
		public int ServerPort = 587;

		public EmailSettings()
		{
			_password.ToCharArray().ToList().ForEach(p => Password.AppendChar(p));
		}
	}
}
