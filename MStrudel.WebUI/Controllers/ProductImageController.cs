using MStrudel.Domain.Abstract;
using System.Collections.Generic;
using System.Web.Mvc;
using MStrudel.Domain.Entities;
using System.Linq;

namespace MStrudel.WebUI.Controllers
{
    public class ProductImageController : Controller
    {
        private IProductImagesRepository _repository;

        public ProductImageController(IProductImagesRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<FileContentResult> GetImages(int productId)
        {
            IEnumerable<ProductImage> productImages = _repository.ProductImages.Where(p => p.ProductID == productId);
            if (productImages != null && productImages.Any())
            {
                var images = productImages.Select(x => File(x.ImageData, x.ImageMimeType));
                return images;
            }
            return null;
        }

        [HttpGet]
        public FileContentResult GetImage(int imageId)
        {
            ProductImage productImage = _repository.ProductImages.First(p => p.ImageID == imageId);
            return File(productImage.ImageData, productImage.ImageMimeType);
        }
    }
}
