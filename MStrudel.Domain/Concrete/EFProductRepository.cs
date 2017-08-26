using MStrudel.Domain.Abstract;
using MStrudel.Domain.Entities;
using System.Collections.Generic;

namespace MStrudel.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products.Include("Category"); }
        }

        public void SaveProduct(Product product)
        {
            if(product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product entry = context.Products.Find(product.ProductID);
                if(entry != null)
                {
                    entry.Name = product.Name;
                    entry.Description = product.Description;
                    entry.Price = product.Price;
                    entry.CategoryId = product.CategoryId;
                    if(product.ImageData != null)
                    {
                        entry.ImageData = product.ImageData;
                        entry.ImageMimeType = product.ImageMimeType;
                    }
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            var product = context.Products.Find(productId);
            if(product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }
    }
}
