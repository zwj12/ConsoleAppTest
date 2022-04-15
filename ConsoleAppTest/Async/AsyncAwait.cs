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
        public static int i = 0;

        static void Main4(string[] args)
        {
            Console.WriteLine("111 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            //Task t = AsyncMethod();
            AsyncMethod2();
            Console.WriteLine("222 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }


        static private async Task AsyncMethod()
        {
            Console.WriteLine("1");
            Thread.Sleep(500);
            Console.WriteLine("2");
            Task<string> ResultFromTimeConsumingMethod = TimeConsumingMethod();
            //string Result1 = ResultFromTimeConsumingMethod.Result;
            //Console.WriteLine("Result1");
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


        static private async void AsyncMethod2()
        {
            Console.WriteLine("1");
            await TimeConsumingMethod();    
            Console.WriteLine("2");  
        }

        static private void TimeConsumingMethod2()
        {
            Console.WriteLine("Helo I am TimeConsumingMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            Console.WriteLine("Helo I am TimeConsumingMethod after Sleep(5000). My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);

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

        public async Task TestAsyncReturnVariable()
        {
              var str=  await DemoAsync();
              Console.WriteLine("TestAsyncReturnVariable: " + str);
        }
        
        public async  Task<string> DemoAsync()
        {
            await Task.Run(() => { i = 45; Thread.Sleep(3000); i = 46; });
            Console.WriteLine("await end");
            i = 47;
            Thread.Sleep(3000);
            Console.WriteLine("DemoAsync end");
            i = 48;
            return "Hello World"; 
        }

        public void CreateTask()
        {
            //1.new方式实例化一个Task，需要通过Start方法启动
            Task task = new Task(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"hello, task1的线程ID为{Thread.CurrentThread.ManagedThreadId}");
            });
            task.Start();

            //2.Task.Factory.StartNew(Action action)创建和启动一个Task
            Task task2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"hello, task2的线程ID为{ Thread.CurrentThread.ManagedThreadId}");
            });

            //3.Task.Run(Action action)将任务放在线程池队列，返回并启动一个Task
            Task task3 = Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"hello, task3的线程ID为{ Thread.CurrentThread.ManagedThreadId}");
            });
        }

    }
}
