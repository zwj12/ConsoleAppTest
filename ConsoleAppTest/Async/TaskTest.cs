using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Async
{
    class TaskTest
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Main Start");
            Task task = TaskTest.TestWithOutawaitAsync();
            Console.WriteLine("Main End");
            Console.ReadKey();
            return;

        }

        public static async Task TestAsync()
        {
            //Task task1= Test1Async();
            //Task task2= Test2Async();
            //Task[] tasks = { task1, task2 };
            //Task.WaitAll(tasks);

            Console.WriteLine("TestAsync start");
            await Test1Async();
            Console.WriteLine("TestAsync middle");
            await Test2Async();
            Console.WriteLine("TestAsync end");

            //Output:
            //Main Start
            //TestAsync start
            //Test1Async.Start
            //Main End
            //Test1Async.End
            //TestAsync middle
            //Test2Async.Start
            //Test2Async.End
            //TestAsync end

        }

        public static async Task TestWithOutawaitAsync()
        {
            Console.WriteLine("TestAsync start");
            Test1Async();
            Console.WriteLine("TestAsync middle");
            Test2Async();
            Console.WriteLine("TestAsync end");

            //Output:
            //Main Start
            //TestAsync start
            //Test1Async.Start
            //TestAsync middle
            //Test2Async.Start
            //TestAsync end
            //Main End
            //Test1Async.End
            //Test2Async.End
        }

        public static async Task Test1Async()
        {
            Console.WriteLine("Test1Async.Start");
            await Task.Delay(2000);
            Console.WriteLine("Test1Async.End");
        }

        public static async Task Test2Async()
        {
            Console.WriteLine("Test2Async.Start");
            await Task.Delay(3000);
            Console.WriteLine("Test2Async.End");
        }

    }
}
