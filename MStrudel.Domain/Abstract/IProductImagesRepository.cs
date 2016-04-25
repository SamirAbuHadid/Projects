using MStrudel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStrudel.Domain.Abstract
{
	public interface IProductImagesRepository
	{
		IEnumerable<ProductImage> ProductImages { get; }
		void SaveProductImage(ProductImage productImage);
		ProductImage DeleteProductImage(int imageId);
	}
}
