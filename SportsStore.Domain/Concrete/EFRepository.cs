﻿using System.Data.Entity.Core.Objects;
using System.Linq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Collections.Generic;
namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {

        private EFContext context = new EFContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public IEnumerable<CategoryLookup> Categories
        {
            get
            {
                return context.CategoryLookups;
            }
        }

        public IEnumerable<ProductCategory> ProductCategories
        {
            get
            {
                return context.ProductCategories;
            }
        }

        public IEnumerable<ListProductsByCategory_Result> ListProductsByCategory(int? categoryId, int? page, int? pageSize, string sortParam, ObjectParameter totalRows)
        {
            return context.ListProductsByCategory(categoryId, page, pageSize, sortParam, totalRows).AsEnumerable();
        }

    }
    
}