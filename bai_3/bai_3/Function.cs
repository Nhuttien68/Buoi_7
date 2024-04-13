using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_3
{
    public class Function
    {

        public void InsertProduct(IProduct productManager)
        {
            int productId;
            while (true)
            {
                Console.Write("Nhap ProductId: ");
                if (int.TryParse(Console.ReadLine(), out productId) && productId > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ProductId phai la mot so nguyen duong.");
                }
            }

            string productName;
            while (true)
            {
                Console.Write("Nhap ProductName: ");
                productName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(productName) && CheckXSSInput(productName) && !chuakitudacbiet(productName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ProductName khong hop le. Vui long nhap lai.");
                }
            }

            decimal price;
            while (true)
            {
                Console.Write("Nhap Price: ");
                if (decimal.TryParse(Console.ReadLine(), out price) && price > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Price phai la mot so duong.");
                }
            }

            productManager.Insert(new Product(productId, productName, price));
        }

        public void UpdateProduct(IProduct productManager)
        {
            int updateId;
            while (true)
            {
                Console.Write("Nhap ProductId can cap nhat: ");
                if (int.TryParse(Console.ReadLine(), out updateId) && updateId > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ProductId phai la mot so nguyen duong.");
                }
            }

            string updatedName;
            while (true)
            {
                Console.Write("Nhap ProductName moi: ");
                updatedName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(updatedName) && CheckXSSInput(updatedName) && !chuakitudacbiet(updatedName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ProductName khong hop le. Vui long nhap lai.");
                }
            }

            decimal updatedPrice;
            while (true)
            {
                Console.Write("Nhap Price moi: ");
                if (decimal.TryParse(Console.ReadLine(), out updatedPrice) && updatedPrice > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Price phai la mot so duong.");
                }
            }

            productManager.Update(updateId, new Product(updateId, updatedName, updatedPrice));
        }

        public void DeleteProduct(IProduct productManager)
        {
            Console.Write("Nhap ProductId can xoa: ");
            int deleteId = int.Parse(Console.ReadLine());
            productManager.Delete(deleteId);
        }
        public void DisplayProducts(List<Product> products)
        {
            if (products.Count > 0)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"ProductId: {product.ProductId}, ProductName: {product.ProductName}, Price: {product.Price}");
                }
            }
            else
            {
                Console.WriteLine("Khong co san pham nao.");
            }
        }


        public void SearchProduct(IProduct productManager)
        {
            Console.Write("Nhap tu khoa tim kiem: ");
            string keyword = Console.ReadLine();
            List<Product> searchResults = productManager.Search(keyword);
            DisplayProducts(searchResults);
        }
        public bool chuakitudacbiet(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<embed", "<frame", "<script", "<frameset", "<html", "<iframe", "<img", "<style", "<layer", "<link", "<ilayer", "<meta", "<object", "<h", "<input", "<a", "&lt", "&gt" };
                if (string.IsNullOrEmpty(input)) return false;
                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
