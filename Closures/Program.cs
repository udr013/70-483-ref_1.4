using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closures
{
    class Program
    {

        delegate int GetValue();

        static GetValue getLocalInt;

        static void SetLocalInt()
        {
            ///Local variable set to 99
            int localInt = 99;
            ///Set delegate geLocalint to a lambda that returns the value of localint
            ///Now localint will stay available though otherwise distroyed blz 71
            getLocalInt = () => localInt;
        }

        static void Main(string[] args)
        {
            SetLocalInt();
            Console.WriteLine("value of localint{o}", getLocalInt());
            Console.ReadKey();
        }
    }
}
