using MStrudel.Domain.Entities;
using System.Collections.Generic;

namespace MStrudel.Domain.Abstract
{
    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}
