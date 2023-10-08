using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleLambda
{
    class MainApp
    {
        delegate int Calculate(int a, int b);

        static void Main(string[] arg)
        {
            Calculate calc = (a, b) => a + b;

            Console.WriteLine($"{3} + {4} : {calc(3, 4)}");
        }
    }
}
