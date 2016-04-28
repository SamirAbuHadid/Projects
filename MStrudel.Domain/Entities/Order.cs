using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MStrudel.Domain.Entities
{
	public class Order
	{
		[HiddenInput(DisplayValue = false)]
		public int OrderId { get; set; }

		[Required(ErrorMessage = "Будь ласка введіть Ваше Ім'я")]
		[Display(Name = "Ім'я")]
		public string Name { get; set; }

		[Display(Name = "Прізвище")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Будь ласка введіть адресу доставки")]
		[Display(Name = "Адреса доставки")]
		public string Adress { get; set; }

		[Required(ErrorMessage = "Будь ласка введіть Ваш номер телефону, по якому з Вами можна зв'язатись")]
		[Display(Name = "Телефон")]
		[DataType(DataType.PhoneNumber)]
		[DisplayFormat(DataFormatString = "{0:###-###-####}", ApplyFormatInEditMode = true)]
		public string Phone { get; set; }

		[Display(Name = "E-mail")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage="Введіть правильний e-mail")]
		public string Email { get; set; }

		[Display(Name = "Дата доставки")]
		[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? DeliveryTime { get; set; }

		[Display(Name = "Коментарі до замовлення")]
		public string Comment { get; set; }

		public ICollection<OrderedProduct> OrderedProducts { get; set; }
	}

	public class OrderedProduct
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public virtual Order Order { get; set; }
		public virtual Product Product { get; set; }
	}
}
