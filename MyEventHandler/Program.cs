using System;
using System.Threading;

namespace MyEventHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
        static void MyEventHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Handler statrs");
            Thread.Sleep(5000);
            Console.WriteLine("Handler ends");
        }
        void Run()
        {
            EventHandler h = new EventHandler(MyEventHandler);
            AsyncCaller ac = new AsyncCaller(h);
            bool completedOK = ac.Invoke(5000, null, EventArgs.Empty);
            Console.WriteLine($"completedOK: {completedOK.ToString()}");
            bool completedOK2 = ac.Invoke(2000, null, EventArgs.Empty);
            Console.WriteLine($"completedOK2: {completedOK2.ToString()}");
            Console.ReadLine();
        }
    }
}
