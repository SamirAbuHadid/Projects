using MStrudel.Domain.Entities;

namespace MStrudel.Domain.Abstract
{
	public interface IOrderProcessor
	{
		void ProcessOrder(Order order, Cart cart);
	}
}
