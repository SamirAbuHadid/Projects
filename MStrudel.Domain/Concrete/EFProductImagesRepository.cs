using MStrudel.Domain.Abstract;
using System.Collections.Generic;
using MStrudel.Domain.Entities;
using System.Linq;

namespace MStrudel.Domain.Concrete
{
    public class EFProductImagesRepository : IProductImagesRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<ProductImage> ProductImages
        {
            get { return _context.ProductImages; }
        }

        public void SaveProductImage(ProductImage productImage)
        {
            if(productImage.ImageID == 0)
            {
                _context.ProductImages.Add(productImage);
                _context.SaveChanges();
            }
        }

        public ProductImage DeleteProductImage(int imageId)
        {
            var image = _context.ProductImages.Find(imageId);
            if(image != null)
            {
                _context.ProductImages.Remove(image);
                _context.SaveChanges();
            }

            return image;
        }

        public void DeleteImagesOnProduct(int productId)
        {
            var images = _context.ProductImages.Where(p => p.ProductID.Equals(productId));
            if(images != null && images.Count() > 0)
            {
                foreach(var image in images)
                {
                    _context.ProductImages.Remove(image);
                }
                _context.SaveChanges();
            }
        }
    }
}
