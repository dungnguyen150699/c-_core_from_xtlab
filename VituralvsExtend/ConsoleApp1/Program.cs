//using System;

using MyApp;

namespace MyApp // Note: actual namespace depends on the project name. siminal vs package
{
    internal class Program
    {
        public struct Product
        {
            // du lieu
            public string name;
            public Int32? price;
            // phuong thuc
            public string getInfor()
            {
                return $"Ten san pham: {name}, gia: {price}";
            }
            // constructor
            public Product(string name, Int32? price)
            {
                this.name = name;
                this.price = price; // thiet lap du ko thi ide bao error
            }
        }

        public enum HOCLUC { // Ko khac gi java
            KEM,TB,KHA,GIOI
        }
        public enum HOCLUC1 { // Ko khac gi java
             // KEM(1), TB(2),KHA(2.5),GIOI(3,5); // error;
             KEM=1, TB=2,KHA=3,GIOI=4
           // public double code;
           /* public HOCLUC1(double code)
            {
                this.code = code;
            }
           */
        }
        static void Main(string[] args)
        {
            Product sp1; // Constuct ko can new
            // Construct la tham tri ko phai tham chieu
            // Class la tham chieu
            sp1.name = "Iphone";
            sp1.price = null;
            Console.WriteLine(sp1.getInfor());

            Product sp2 = new Product("Iphone X", 50000000);
            Console.WriteLine(sp2.getInfor());
        }
    }
}


namespace ConsoleApp11
{
    internal class FileName1
    {
        static void main(string[] args)
        {
            Program program = new Program();
            Program.Product product = new Program.Product("test", 120);
            Console.WriteLine(product.getInfor());
        }
    }

}

