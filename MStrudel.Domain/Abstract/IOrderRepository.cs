using MStrudel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStrudel.Domain.Abstract
{
	public interface IOrderRepository
	{
		IEnumerable<Order> Orders { get; }
		void SaveOrder(Order order);
		void DeleteOrder(int orderId);
	}
}
