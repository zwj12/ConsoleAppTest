using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest.MultiThread
{
    public class ThreadTest
    {
        public void TestMultiThread()
        {
            Thread thread_A=new Thread(new ThreadStart(ThreadProc_A));
            thread_A.IsBackground = true;
            thread_A.Start();

        }

        public void ThreadProc_A()
        {
            Console.WriteLine("thread_A Start {0}", Thread.CurrentThread.ManagedThreadId);
            Thread thread_B = new Thread(new ThreadStart(ThreadProc_B));
            thread_B.IsBackground = false;
            thread_B.Start();
            Thread.Sleep(10000);
            Console.WriteLine("thread_A End {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public void ThreadProc_B()
        {
            Console.WriteLine("thread_B Start {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(50000);
            Console.WriteLine("thread_B End {0}", Thread.CurrentThread.ManagedThreadId);
        }

    }
}
