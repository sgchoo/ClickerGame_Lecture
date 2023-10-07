using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace UsingGenericList
{
    class MainApp
    {
        static void Main(string[] arg)
        {
            List<int> list = new List<int>();
            for(int i = 0; i < 5; i++)
                list.Add(i);

            foreach(int element in list)
                Console.WriteLine($"{element}");
            Console.WriteLine();

            list.RemoveAt(2);

            foreach(int element in list)
                Console.WriteLine($"{element}");
            Console.WriteLine();

            list.Insert(2, 2);
            
            foreach (int element in list)
                Console.WriteLine($"{element}");
            Console.WriteLine();
        }
    }
}
