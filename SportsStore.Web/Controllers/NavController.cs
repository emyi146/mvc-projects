using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

        public PartialViewResult Menu(string category = null)
        {
            IEnumerable<string> categories = _productRepository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(p => p);

            ViewBag.SelectedCategory = category;
            return PartialView(categories);
        }
    }
}