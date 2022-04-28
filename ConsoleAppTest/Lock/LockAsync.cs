using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest.Lock
{
    public static class LockAsync
    {
        public static readonly SemaphoreSlim _mutex = new SemaphoreSlim(1);

        private static int count=0;

        private static int millisecondsTimeout=0;


        private static SemaphoreSlim semaphore;
        // A padding interval to make the output more orderly.
        private static int padding;

        public static async void WaitAync(int index)
        {
            bool flag= await _mutex.WaitAsync(millisecondsTimeout);
            Console.WriteLine($"{index}, {flag}, Enter, {DateTime.Now:yyyy - MM - ddTHH:mm: ss.fff}");
            if (flag)
            {
                try
                {
                    await Task.Delay(1000);
                    count++;
                    Console.WriteLine($"{index}, {count}");
                }
                catch (Exception)                {

                    throw;
                }
                finally
                {
                    Console.WriteLine($"{index}, Release, {DateTime.Now:yyyy - MM - ddTHH:mm: ss.fff}");
                    _mutex.Release();
                }
            }
        }


        public static void Mainx()
        {
            // Create the semaphore.
            semaphore = new SemaphoreSlim(1);
            Console.WriteLine("{0} tasks can enter the semaphore.",
                              semaphore.CurrentCount);
            Task[] tasks = new Task[5];

            // Create and start five numbered tasks.
            for (int i = 0; i <= 4; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    // Each task begins by requesting the semaphore.
                    Console.WriteLine("Task {0} begins and waits for the semaphore.",
                                      Task.CurrentId);

                    int semaphoreCount;
                    semaphore.Wait();
                    try
                    {
                        Interlocked.Add(ref padding, 100);

                        Console.WriteLine("Task {0} enters the semaphore.", Task.CurrentId);

                        // The task just sleeps for 1+ seconds.
                        Thread.Sleep(1000 + padding);
                    }
                    finally
                    {
                        semaphoreCount = semaphore.Release();
                        semaphoreCount = semaphore.Release();
                        semaphoreCount = semaphore.Release();
                    }
                    Console.WriteLine("Task {0} releases the semaphore; previous count: {1}. current count: {2}",
                                      Task.CurrentId, semaphoreCount, semaphore.CurrentCount);
                });
            }

            // Wait for half a second, to allow all the tasks to start and block.
            Thread.Sleep(500);

            // Restore the semaphore count to its maximum value.
            Console.Write("Main thread calls Release(3) --> ");
            //semaphore.Release(3);
            Console.WriteLine("{0} tasks can enter the semaphore.",
                              semaphore.CurrentCount);
            // Main thread waits for the tasks to complete.
            Task.WaitAll(tasks);

            Console.WriteLine("Main thread exits.");
        }
    }
}
