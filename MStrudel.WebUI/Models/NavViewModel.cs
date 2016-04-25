using MStrudel.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MStrudel.WebUI.Models
{
	public class NavViewModel
	{
		public IEnumerable<Category> Categories { get; set; }
	}
}