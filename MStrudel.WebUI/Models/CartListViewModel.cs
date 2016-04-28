using MStrudel.Domain.Entities;

namespace MStrudel.WebUI.Models
{
	public class CartListViewModel
	{
		public Cart Cart { get; set; }
		public string ReturnUrl { get; set; }
	}
}