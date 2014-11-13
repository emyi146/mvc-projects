using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<CategoryLookup> Categories { get; }
        IEnumerable<ProductCategory> ProductCategories { get; }
        IEnumerable<ListProductsByCategory_Result> ListProductsByCategory(int? categoryId);
    }
}
