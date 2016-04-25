using MStrudel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MStrudel.WebUI.Models
{
	public class ProductListViewModel
	{
		public IEnumerable<Product> Products { get; set; }
		public PagingInfo PagingInfo { get; set; }
		public int? CurrentCategory { get; set; }
	}
}