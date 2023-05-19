using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace LINQSpace
{

    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // các màu sắc
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

    }

    public class Brand
    {
        public string Name { set; get; }
        public int ID { set; get; }
    }


    public class Program
    {
     
        static void Main(string[] args)
        {
            var brands = new List<Brand>() {
            new Brand{ID = 1, Name = "Công ty AAA"},
            new Brand{ID = 2, Name = "Công ty BBB"},
            new Brand{ID = 4, Name = "Công ty CCC"},
                };

            var products = new List<Product>() {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };
           
            // Lay san pham gia 400;
            // var kq = from p in products
            //            where p.Price == 400 
            //            select p;
            //printKq(kq);
            //----
            //var kq = products.Select(
            //    (p) =>
            //    {
            //        return p.Name;
            //    }
            //);
            //printKq(kq);
            //----
            var kq = brands.GroupJoin(products, b => b.ID, p => p.Brand,
                (brand, pros) => {
                    return new
                    {
                        ThuongHieu = brand.Name,
                        Cacsanpham = pros
                    };
   
                });

            foreach (var item in kq)
            {
                Console.WriteLine($"Thuong Hieu: {item.ThuongHieu}");
                foreach(var p in item.Cacsanpham)
                {
                   Console.WriteLine($"Cac san pham: {p}");
                }
            }
        }


    }
}