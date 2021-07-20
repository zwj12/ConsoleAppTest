using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace ConsoleAppTest.Async
{
    class AsyncAwait
    {

        static void Main1(string[] args)
        {
            Console.WriteLine("111 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            AsyncMethod();
            Console.WriteLine("222 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }


        static private async Task AsyncMethod()
        {
            Console.WriteLine("1");
            Thread.Sleep(500);
            Console.WriteLine("2");
            var ResultFromTimeConsumingMethod = TimeConsumingMethod();
            string Result = await ResultFromTimeConsumingMethod + " + AsyncMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(Result);
            //返回值是Task的函数可以不用return
        }

        //这个函数就是一个耗时函数，可能是IO操作，也可能是cpu密集型工作。
        static private Task<string> TimeConsumingMethod()
        {
            Console.WriteLine("3");
            var task = Task.Run(() =>
            {
                Console.WriteLine("Helo I am TimeConsumingMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
                Console.WriteLine("Helo I am TimeConsumingMethod after Sleep(5000). My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                return "Hello I am TimeConsumingMethod";
            });

            return task;
        }


        static void Main4()
        {
            Start();
            End();
            Console.ReadKey();
        }

        static void Wait() => Console.WriteLine("waiting...");
        static void End() => Console.WriteLine("end...");
        static int Start()
        {
            Console.WriteLine("start...");
            HttpClient client = new HttpClient();
            Thread.Sleep(500);
            var result = client.GetStringAsync("https://www.visualstudio.com/");
            string str = result.Result;
            return str.Length;
        }
    }
}
