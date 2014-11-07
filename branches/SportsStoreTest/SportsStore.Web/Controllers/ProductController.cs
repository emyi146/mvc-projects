using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Helpers;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain;
using SportsStore.Web.HtmlHelpers;
using SportsStore.Web.Models;
namespace SportsStore.Web.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository repository;
        public int PageSize = 3;


        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List(string category, int page = 1, string sortHeader = "ProductId", SortDirection sortDirection = SortDirection.Ascending)
        {

            string sortDirectionString = sortDirection == SortDirection.Ascending ? "ASC" : "DESC";
                  

            
            IQueryable<Product> query =
                repository.Products.AsQueryable()
                    .Where(p => category == null | p.Category == category)
                    .OrderBy(sortHeader + " " + sortDirectionString);

            IEnumerable<Product> productsInCategory = query.AsEnumerable();
            
      
            ProductListViewModel model = new ProductListViewModel
            {
                Products = productsInCategory
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                SortingPagingInfo = new SortingPagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = productsInCategory.Count(),
                        SortField = sortHeader,
                        SortDirection = sortDirection
                    },
                CurrentCategory = category
            };

            return View(model);
        }


    }
}