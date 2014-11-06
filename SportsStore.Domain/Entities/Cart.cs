using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }



    public class Cart
    {
        public List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine cartLine = lineCollection
                .Where(l => l.Product.ProductId == product.ProductId)
                .FirstOrDefault();

            if (cartLine == null)
            {
                cartLine = new CartLine { Product = product, Quantity = quantity };
                lineCollection.Add(cartLine);
            }

        }
    }
}
