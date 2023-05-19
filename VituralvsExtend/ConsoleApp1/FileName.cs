using MyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace namespaceTest
{
    internal class FileName
    {
        static void main(string[] args)
        {
            Program program = new Program();
            Program.Product product = new Program.Product("test", 120);
            Console.WriteLine(product.getInfor());
        }
    }
}
