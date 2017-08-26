using MStrudel.Domain.Entities;
using System.Collections.Generic;

namespace MStrudel.WebUI.Models
{
	public class NavViewModel
	{
		public IEnumerable<Category> Categories { get; set; }
	}
}