using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SportsStore.Domain;
using SportsStore.Domain.Abstract;

namespace SportsStore.Web.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository _productRepository;

        public NavController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public PartialViewResult Menu(string categoryName = null)
        {
            IEnumerable<CategoryLookup> categories = _productRepository.Categories
                .OrderBy(c => c.CategoryLookup_Name);

            ViewBag.SelectedCategory = categories.FirstOrDefault(c => c.CategoryLookup_Name == categoryName);
            return PartialView(categories);
        }
    }
}