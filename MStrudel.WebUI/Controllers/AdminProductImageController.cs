using System.Linq;
using System.Web;
using System.Web.Mvc;
using MStrudel.Domain.Abstract;
using MStrudel.Domain.Entities;
using MStrudel.WebUI.Models;

namespace MStrudel.WebUI.Controllers
{
    public class AdminProductImageController : Controller
    {
        private IProductImagesRepository _repository;

        public AdminProductImageController(IProductImagesRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public ViewResult Index(int productId = 0)
        {
            var model = new GalleryViewModel { ProductId = productId };

            model.ProductImages = _repository.ProductImages.Where(p => p.ProductID.Equals(productId));

            return View(model);
        }

        [HttpPut]
        public ActionResult Edit(int productId, HttpPostedFileBase image = null)
        {
            if(ModelState.IsValid)
            {
                var productImage = new ProductImage();

                if(image != null)
                {
                    productImage.ProductID = productId;
                    productImage.ImageData = new byte[image.ContentLength];
                    productImage.ImageMimeType = image.ContentType;
                    image.InputStream.Read(productImage.ImageData, 0, image.ContentLength);

                    _repository.SaveProductImage(productImage);
                }
                TempData["message"] = "Зображення збережено";
            }

            return RedirectToAction("Index", new { productId = productId });
        }

        [HttpDelete]
        public RedirectToRouteResult Delete(int imageId, int productId)
        {
            ProductImage productImage = _repository.DeleteProductImage(imageId);
            TempData["message"] = "Зображення видалено";
            return RedirectToAction("Index", new { productId });
        }

        public FileContentResult GetImage(int imageId)
        {
            ProductImage productImage = _repository.ProductImages.FirstOrDefault(p => p.ImageID == imageId);
            if(productImage != null)
            {
                return File(productImage.ImageData, productImage.ImageMimeType);
            }
            return null;
        }
    }
}