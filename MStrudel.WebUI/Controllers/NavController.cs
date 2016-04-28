using MStrudel.Domain.Abstract;
using MStrudel.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace MStrudel.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ICategoriesRepository _categoryRepository;

        public NavController(ICategoriesRepository repository)
        {
            _categoryRepository = repository;
        }

        public PartialViewResult Menu(int? categoryId = null)
        {
            var model = new NavViewModel();

            model.Categories = _categoryRepository.Categories.OrderBy(p => p.SortId);

            ViewBag.SelectedCategory = categoryId;
            return PartialView(model);
        }
    }
}
