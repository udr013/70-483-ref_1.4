using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDelegates
{
    class Program
    {

        delegate int IntOperation(int a, int b);

        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Substract(int a, int b)
        {
            return a - b;
        }

        static void Main(string[] args)
        {
            var op = new IntOperation(Add);
            Console.WriteLine(op(2, 2));

            op = Substract;
            Console.WriteLine(op(2, 2));

            IntOperation add = (a, b) => a * b;
            Console.WriteLine(add(2, 2));

            Console.ReadKey();
        }
    }
}
