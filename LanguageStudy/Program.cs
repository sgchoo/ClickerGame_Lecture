using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy
{
    class Myclass
    {
        public int MyField1;
        public int MyField2;

        public Myclass DeepCopy()
        {
            Myclass newCopy = new Myclass();
            newCopy.MyField1 = this.MyField1;
            newCopy.MyField2 = this.MyField2;

            return newCopy;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shallow Copy");

            { 
                Myclass source = new Myclass();
                source.MyField1 = 10;
                source.MyField2 = 20;

                Myclass target = source;
                target.MyField2 = 30;

                Console.WriteLine($"{source.MyField1} {source.MyField2}");
                Console.WriteLine($"{target.MyField1} {target.MyField2}");
            }

            Console.WriteLine("Deep Copy");

            {
                Myclass source = new Myclass();
                source.MyField1 = 10;
                source.MyField2 = 20;

                Myclass target = source.DeepCopy();
                target.MyField2 = 30;

                Console.WriteLine($"{source.MyField1} {source.MyField2}");
                Console.WriteLine($"{target.MyField1} {target.MyField2}");
            }
        }
    }
}
