using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_3
{
    public interface IProduct
    {
        void Insert(Product product);
        void Update(int productId, Product product);
        void Delete(int productId);
        List<Product> Search(string input);
        List<Product> GetAllProducts();
    }
}
