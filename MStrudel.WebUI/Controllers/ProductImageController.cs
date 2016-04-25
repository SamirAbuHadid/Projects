using MStrudel.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
	}
}