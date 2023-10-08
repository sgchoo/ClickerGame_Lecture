using System;
using System.Reflection;

namespace FuncTest
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Func<int> Func1 = () => 10;
            Console.WriteLine($"func1() : {Func1()}");

            Func<int, int> Func2 = (x) => x * 2;
            Console.WriteLine($"func2(4) : {Func2(4)}");

            Func<double, double, double> Func3 = (x, y) => x / y;
            Console.WriteLine($"func(22, 7) : {Func3(22, 7)}");
        }
    }
}
