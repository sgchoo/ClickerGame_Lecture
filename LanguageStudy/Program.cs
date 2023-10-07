using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace UsingDictionary
{
    class MainApp
    {
        static void Main(string[] arg)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic["하나"] = "One";
            dic["둘"] = "Two";
            dic["셋"] = "Three";
            dic["넷"] = "Four";
            dic["다섯"] = "Five";

            Console.WriteLine(dic["하나"]);
            Console.WriteLine(dic["둘"]);
            Console.WriteLine(dic["셋"]);
            Console.WriteLine(dic["넷"]);
            Console.WriteLine(dic["다섯"]);
        }
    }
}
