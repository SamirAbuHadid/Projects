using MStrudel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MStrudel.WebUI.Models
{
	public class ProductEditViewModel
	{
		public Product Product { get; set; }
		public List<SelectListItem> Categories { get; set; }
	}
}