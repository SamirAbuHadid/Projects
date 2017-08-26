using MStrudel.Domain.Entities;
using System.Collections.Generic;

namespace MStrudel.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
        void DeleteOrder(int orderId);
    }
}
