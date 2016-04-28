using System.Collections.Generic;
using System.Linq;

namespace MStrudel.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> _lines = new List<CartLine>();

        public List<CartLine> Lines { get { return _lines; } }

        public void AddItem(Product product, int quantity)
        {
            CartLine item = _lines.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if(item == null)
            {
                _lines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void DeleteItem(Product product)
        {
            _lines.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }

        public void ChangeQuantity(Product product, int quantity)
        {
            CartLine item = _lines.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();

            if(item == null)
            {
                _lines.Add(new CartLine { Product = product, Quantity = quantity });
            }

            var newQuantity = item.Quantity + quantity;
            if(newQuantity == 0)
            {
                _lines.Remove(item);
            }
            item.Quantity = newQuantity;
        }

        public void Clear()
        {
            _lines.Clear();
        }

        public decimal TotalValue()
        {
            return _lines.Sum(p => p.Product.Price * p.Quantity);
        }

    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
