using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_3
{
    public class ProductManager : IProduct
    {
        private List<Product> products = new List<Product>();

        public void Insert(Product product)
        {
            products.Add(product);
        }

        public void Update(int productId, Product product)
        {
            Product existingProduct = products.Find(p => p.ProductId == productId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Price = product.Price;
            }
            else
            {
                Console.WriteLine("Khong tim thay san pham co ID tuong ung.");
            }
        }

        public void Delete(int productId)
        {
            Product productToRemove = products.Find(p => p.ProductId == productId);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
            }
            else
            {
                Console.WriteLine("Khong tim thay san pham co ID tuong ung.");
            }
        }

        public List<Product> Search(string input)
        {
            List<Product> searchResults = products.FindAll(p => p.ProductName.ToLower().Contains(input.ToLower()));
            return searchResults;
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }
    }
}

