using MStrudel.Domain.Entities;

namespace MStrudel.WebUI.Models
{
	public class OrderListViewModel
	{
		public Cart Cart { get; set; }
		public Order Order { get; set; }
	}
}