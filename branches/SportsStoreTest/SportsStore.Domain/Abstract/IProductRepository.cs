using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<CategoryLookup> Categories { get; }
        IEnumerable<ProductCategory> ProductCategories { get; }
        IEnumerable<ListProductsByCategory_Result> ListProductsByCategory(int? categoryId, int? page, int? pageSize, string sortParam, ObjectParameter totalRows);
    }
}
