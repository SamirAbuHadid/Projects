using MStrudel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MStrudel.WebUI.Models
{
	public class CartListViewModel
	{
		public Cart Cart { get; set; }
		public string ReturnUrl { get; set; }
	}
}