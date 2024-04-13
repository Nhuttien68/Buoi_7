using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_3
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Product(int productId, string productName, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }
    }
}
