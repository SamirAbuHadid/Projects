using MStrudel.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MStrudel.Domain.Entities;

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
			
		}

		public ProductImage DeleteProductImage(int imageId)
		{
			return new ProductImage();
		}
	}
}
