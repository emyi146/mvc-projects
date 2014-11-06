using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository repository;
        public int PageSize = 2;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            IEnumerable<Product> productsInCategory = repository.Products
                .Where(p => category == null | p.Category == category)
                .OrderBy(p => p.ProductId);
                
            ProductListViewModel model = new ProductListViewModel
            {
                Products = productsInCategory
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = productsInCategory.Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}