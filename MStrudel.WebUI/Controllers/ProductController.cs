using MStrudel.WebUI.Models;
using System.Linq;
using System.Web.Mvc;
using MStrudel.Domain.Abstract;
using MStrudel.Domain.Entities;

namespace MStrudel.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository _productRepository;
        public int ItemsOnPage = 4;

        public ProductController(IProductsRepository prodRepository)
        {
            _productRepository = prodRepository;
        }

        [HttpGet]
        public ActionResult Index(int categoryId = 0, int page = 1)
        {
            var model = new ProductListViewModel
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = ItemsOnPage,
                    TotalItems = categoryId != 0
                            ? _productRepository.Products.Where(p => p.CategoryId == categoryId).Count()
                            : _productRepository.Products.Count()
                },
                Products = _productRepository.Products
                .Where(p =>
                    {
                        if (categoryId != 0)
                        {
                            return p.CategoryId == categoryId;
                        }
                        return true;
                    })
                .Skip((page - 1) * ItemsOnPage)
                .Take(ItemsOnPage)
                .OrderBy(p => p.Name),
                CurrentCategory = categoryId
            };

            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);
            if(product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            return null;
        }
    }
}
