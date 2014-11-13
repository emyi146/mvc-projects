using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SportsStore.Domain.Abstract;
using SportsStore.Domain;
using SportsStore.Web.HtmlHelpers;
using SportsStore.Web.Models;
using SortDirection = System.Web.Helpers.SortDirection;

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

        public ViewResult List(string categoryName, int page = 1, string sortHeader = "Product_Id", SortDirection sortDirection = SortDirection.Ascending)
        {
            CategoryLookup category = getCategoryByName(categoryName);
            int? categoryId = category != null ? category.CategoryLookup_Id : (int?) null;

            IQueryable<ListProductsByCategory_Result> query =
                repository.ListProductsByCategory(categoryId).AsQueryable()
                    .OrderBy(sortHeader + " " + sortDirection);

            IEnumerable<ListProductsByCategory_Result> productsInCategory = query.AsEnumerable().ToList();

            var model = new ProductListViewModel
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
                CurrentCategory = category != null ? category.CategoryLookup_Name : null
            };

            return View(model);
        }

        private CategoryLookup getCategoryByName(string categoryName)
        {
            return repository.Categories.FirstOrDefault(c => c.CategoryLookup_Name == categoryName);
        }


    }
}