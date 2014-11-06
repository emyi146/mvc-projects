using System.Collections.Generic;
using SportsStore.Domain;

namespace SportsStore.Web.Models
{
    public class ProductListViewModel
    {
        public SortingPagingInfo PagingInfo { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}