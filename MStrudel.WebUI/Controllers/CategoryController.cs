using MStrudel.Domain.Abstract;
using MStrudel.Domain.Entities;
using System.Linq;
using System.Web.Mvc;

namespace MStrudel.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoriesRepository _categoryRepository;

        public CategoryController(ICategoriesRepository repository)
        {
            _categoryRepository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_categoryRepository.Categories.OrderBy(c => c.SortId));
        }

        public ActionResult Edit(int categoryId)
        {
            Category model = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryId == categoryId);

            if(model == null)
            {
                model = new Category();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                _categoryRepository.SaveCategory(category);
            }
            return RedirectToAction("Index", "Category");
        }

        [HttpDelete]
        public ActionResult Delete(int categoryId)
        {
            if(categoryId != 0)
            {
                _categoryRepository.DeleteCategory(categoryId);
            }

            return RedirectToAction("Index");
        }
    }
}
