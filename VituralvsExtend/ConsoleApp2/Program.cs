using System.Diagnostics;

namespace MyApp2
{
    internal class Program
    {
        internal class Iphone : Product
        {
            public override void sayName() => Console.WriteLine(base.name);
        }

        public class Product
        {
            public int? price { get; set; }
            public string? name { get; set; }
            public virtual void sayName() => Console.WriteLine("Product name is : " + name);

        }

        static void Main(String[] args)
        {
            Iphone iphone = new Iphone();
            iphone.sayName();
        }
    }
  
    
}
