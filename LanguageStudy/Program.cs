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

namespace EventTest
{
    delegate void EventHandler(string message);

    class MyNotifier
    {
        public event EventHandler SomethingHappened;
        public void DoSomething(int number)
        {
            int temp = number % 10;
            if (temp != 0 && temp % 3 == 0)
            {
                SomethingHappened(String.Format("{0} : 짝", number));
            }
        }
    }
    
    class MainApp
    {
        public static void MyHandler(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] arg)
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler);

            for(int i = 0; i < 30; i++)
            {
                notifier.DoSomething(i);
            }
        }
    }
}
