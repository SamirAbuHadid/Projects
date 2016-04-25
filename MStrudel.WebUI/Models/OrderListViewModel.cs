using MStrudel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MStrudel.WebUI.Models
{
	public class OrderListViewModel
	{
		public Cart Cart { get; set; }
		public Order Order { get; set; }
	}
}