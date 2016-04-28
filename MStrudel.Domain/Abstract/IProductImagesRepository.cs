using MStrudel.Domain.Entities;
using System.Collections.Generic;

namespace MStrudel.Domain.Abstract
{
    public interface IProductImagesRepository
    {
        IEnumerable<ProductImage> ProductImages { get; }
        void SaveProductImage(ProductImage productImage);
        ProductImage DeleteProductImage(int imageId);
    }
}
