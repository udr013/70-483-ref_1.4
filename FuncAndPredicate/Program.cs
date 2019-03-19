using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndPredicate
{
    class Program
    {
        static void Main(string[] args)
        {
            //two valus in one new value out
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine(add(3, 3));

            //Boolean
            Predicate<int> devidableByThree = (i) => i % 3 == 0;
            Console.WriteLine(devidableByThree(9));
            Console.ReadKey();
        }
    }
}
