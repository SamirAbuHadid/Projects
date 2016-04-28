using MStrudel.Domain.Abstract;
using System.Collections.Generic;
using MStrudel.Domain.Entities;

namespace MStrudel.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<Order> Orders
        {
            get { return _context.Orders.Include("OrderedProducts"); }
        }

        public void SaveOrder(Order order)
        {
            if(order.OrderId == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if(order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
