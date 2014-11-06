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
    }
}