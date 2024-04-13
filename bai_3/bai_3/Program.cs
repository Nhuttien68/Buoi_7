using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProduct productManager = new ProductManager();
            Function functions = new Function();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1. Them san pham");
                Console.WriteLine("2. Cap nhat san pham");
                Console.WriteLine("3. tim kiem san pham");
                Console.WriteLine("4. Xoa san pham");
                Console.WriteLine("5. Thoat");
                Console.Write("Nhap lua chon cua ban: ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                    Console.Write("Nhap lua chon cua ban: ");
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap so luong san pham can them: ");
                        int numberOfProduct;
                        while (!int.TryParse(Console.ReadLine(), out numberOfProduct) || numberOfProduct <= 0)
                        {
                            Console.WriteLine("So luong khong hop le. Vui long nhap lai.");
                            Console.Write("Nhap so luong san pham can them: ");
                        }

                        for (int i = 0; i < numberOfProduct; i++)
                        {
                            Console.Write("Moi nhap san pham thu " + (i+1)+"\n");
                            functions.InsertProduct(productManager);
                        }
                        break;
                    case 2:
                        if (productManager.GetAllProducts().Count == 0)
                        {
                            Console.WriteLine("Danh sach san pham rong. Vui long them san pham truoc khi cap nhat.");
                            break;
                        }
                        functions.UpdateProduct(productManager);
                        break;
                    case 3:
                        if (productManager.GetAllProducts().Count == 0)
                        {
                            Console.WriteLine("Danh sach san pham rong. Vui long them san pham truoc khi cap nhat.");
                            break;
                        }
                        functions.SearchProduct(productManager);
                        break;
                    case 4:
                        if (productManager.GetAllProducts().Count == 0)
                        {
                            Console.WriteLine("Danh sach san pham rong. Vui long them san pham truoc khi cap nhat.");
                            break;
                        }
                        functions.DeleteProduct(productManager);
                        break;
                    case 5:
                        if (productManager.GetAllProducts().Count == 0)
                        {
                            Console.WriteLine("Danh sach san pham rong. Vui long them san pham truoc khi cap nhat.");
                            break;
                        }
                        functions.DisplayProducts(productManager.GetAllProducts());
                        break;
                    case 6:
                        exit = true;
                        Console.WriteLine("Cam on da su dung chuong trinh.");
                        break;
                }
            }
        }
    }
}
