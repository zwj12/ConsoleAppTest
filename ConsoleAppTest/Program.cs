using ConsoleAppTest.Mapper;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ConsoleAppTest
{

    public static class Program
    {
        public static string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }

        public delegate string AsyncMethodCaller(int callDuration, out int threadId);

       

        static async Task Main(string[] args)
        {
            Model model = new Model
            {
                SomeValue = 100,
                AnotherValue = "10001"
            };
            model.Position.X = 10;
            model.Position.Y = 20;
            model.Position.Z = 30;

            AutoMapperStartupTask auto = new AutoMapperStartupTask();
            auto.Execute();

            ViewModel viewModel = MappingExtensions.ToViewModel(model);


            Console.WriteLine($"model={model}");
            Console.WriteLine($"viewModel={viewModel}");

            model.SomeValue = 56;
            model.Day = WeekDay.Wednesday;
            model.Position.Z = 40;

            Console.WriteLine($"model={model}");
            Console.WriteLine($"viewModel={viewModel}");

            Model model2 = MappingExtensions.ToModel(viewModel);

            Console.WriteLine($"model={model2}");
            Console.WriteLine($"viewModel={viewModel}");


            Console.ReadKey();
        }

        //public static void Main(string[] args)
        //{
        //    DateTime PMOPStopTime = DateTime.Now;
        //    DateTime PMOPStartTime= DateTime.Now.AddDays(-4);

        //    TimeSpan sdf = PMOPStopTime - PMOPStartTime;

        //    Console.WriteLine($"{sdf}");

        //    //sfdsfdsf
        //    ItmsrcSetupDataParam itmsrcStatisticsData = new ItmsrcSetupDataParam();
        //    int size1 = Marshal.SizeOf(itmsrcStatisticsData);

        //    Console.ReadKey();
        //}

     

    }


}

