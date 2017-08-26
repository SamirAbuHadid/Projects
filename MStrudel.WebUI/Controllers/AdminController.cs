using MStrudel.Domain.Abstract;
using MStrudel.Domain.Entities;
using MStrudel.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MStrudel.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRepository _productRepository;

        public AdminController(IProductsRepository repository)
        {
            _productRepository = repository;
        }

        public ActionResult Index()
        {
            return View(_productRepository.Products);
        }

        public ViewResult Edit(int productId)
        {
            var model = new ProductEditViewModel();
            Product product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);
            model.Product = product;
            model.Categories = new List<SelectListItem>();

            var categories = _productRepository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(c => c.Name);

            foreach(var category in categories)
            {
                model.Categories.Add(
                    new SelectListItem
                    {
                        Text = category.Name,
                        Value = category.CategoryId.ToString(),
                        Selected = category.CategoryId == product.CategoryId ? true : false
                    }
                );
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Product", Exclude = "ImageData")]ProductEditViewModel modelParam, HttpPostedFileBase image = null)
        {
            if(ModelState.IsValid)
            {
                if(image != null)
                {
                    modelParam.Product.ImageData = new byte[image.ContentLength];
                    modelParam.Product.ImageMimeType = image.ContentType;
                    image.InputStream.Read(modelParam.Product.ImageData, 0, image.ContentLength);
                }
                var resizedImage = new WebImage(modelParam.Product.ImageData).Resize(200, 200, true, true).Crop(left: 1, top: 1);
                modelParam.Product.ImageData = resizedImage.GetBytes();

                Product product = modelParam.Product;
                _productRepository.SaveProduct(product);
                TempData["message"] = string.Format("{0} збережено", product.Name);
                return RedirectToAction("Index");
            }

            return View(modelParam);
        }

        public ViewResult Create()
        {
            var model = new ProductEditViewModel();
            model.Product = new Product();

            model.Categories = new List<SelectListItem>();

            var categories = _productRepository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(c => c.Name);

            foreach(var category in categories)
            {
                model.Categories.Add(
                    new SelectListItem
                    {
                        Text = category.Name,
                        Value = category.CategoryId.ToString()
                    }
                );
            }
            model.Categories[0].Selected = true;

            return View("Edit", model);
        }

        [HttpDelete]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = _productRepository.DeleteProduct(productId);
            TempData["message"] = string.Format("{0} видалено", deletedProduct.Name);
            return RedirectToAction("Index");
        }
    }
}
