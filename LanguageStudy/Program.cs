using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    delegate int MyDelegate( int a, int b );

    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }

        public int Minus(int a, int b)
        {
            return (a - b);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            MyDelegate CallBack;

            CallBack = new MyDelegate(calculator.Plus);
            Console.WriteLine(CallBack(3, 4));

            CallBack = new MyDelegate(calculator.Minus);
            Console.WriteLine(CallBack(7, 5));
        }
    }
}
