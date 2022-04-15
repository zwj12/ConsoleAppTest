using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Threading;
using NLog;
using ConsoleAppTest.Encryption;
using ConsoleAppTest.MongoDBLearn;
using MongoDB.Bson;
using ConsoleAppTest.JsonLearn;
using ConsoleAppTest.CRC;
using ConsoleAppTest.WebApi;
using ConsoleAppTest.OPCUA;
using ConsoleAppTest.Async;
using System.Diagnostics;
using ConsoleAppTest.MultiThread;
using ConsoleAppTest.XML;
using System.Runtime.CompilerServices;

namespace ConsoleAppTest
{
    public enum RobotCategory
    {
        ROB1 = 1,
        ROB2 = 2,
    }

    class Program
    {        
        public static ManualResetEvent StopEventHandle;
        public static AutoResetEvent EngineIsReady;
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static void printstr(A a)
        {
            Console.WriteLine("printstrA");
        }

        static void printstr1([CallerMemberName] string str="")
        {
            Console.WriteLine(str);
        }

        async static public Task test00()
        {
            await Task.Delay(1000);
        }

        async static  public Task test01()
        {
            await Task.Delay(1000);
        }

        async static public Task test02()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Hello world " + i);
                Task task = test01();
                await task;
                //await test01();                
            }
        }

        [Flags]
        enum MyEnum
        {
            a=0x01,
            b=0x02,
            c=0x08
        }


    static async Task Main(string[] args)
        {


            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            //Trace.Indent();
            Trace.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Trace.WriteLine("Exiting Main");
           // Trace.Unindent();


            Console.ReadKey();
            return;


            bool boolTest = false;
            bool.TryParse("1", out boolTest);

            List<int> intlist = new List<int>();
            int k = intlist.FirstOrDefault();
            intlist.Add(3);
            int l = intlist.FirstOrDefault();

            List<Certificate> cerList = new List<Certificate>();
            Certificate c = cerList.FirstOrDefault();
            cerList.Add(new Certificate());
            Certificate ds = cerList.FirstOrDefault();




            int? xyz=default(int?);
            int yz;
            //xyz = 8;
            yz = xyz.GetValueOrDefault() <= 0 ? 0 : (int)xyz;
            yz = xyz.GetValueOrDefault();

            printstr1("sdf");
            Console.ReadKey();
            return;

            Console.WriteLine("Main Start");
            Task task1=  TaskTest.TestWithOutawaitAsync();
            Console.WriteLine("Main End");
            

            Console.ReadKey();
            return;
            XMLTest xmltest = new XMLTest();
            xmltest.ReadFromString();
            Console.ReadKey();
            return;

            DateTime testd = DateTime.Parse("12/07/21 09:51:42");
            Console.WriteLine(testd);
            Console.ReadKey();

            return;


            DateTime dateTimeRequest = DateTime.Now;
            Thread.Sleep(100);
            DateTime dateTimeResponse = DateTime.Now;
            TimeSpan interval = dateTimeRequest - dateTimeResponse;
            string str = string.Format("{0:yyyy-MM-ddTHH:mm:ss.fff} -> {1:yyyy-MM-ddTHH:mm:ss.fff} -> {2:0.000}s", dateTimeRequest, dateTimeResponse , (dateTimeResponse-dateTimeRequest).TotalSeconds);
            Console.WriteLine(str);
            string str1 = string.Format("{0:yyyy-MM-ddTHH:mm:ss.fff} -> {1:yyyy-MM-ddTHH:mm:ss.fff} ({2:0.000}){3}", dateTimeRequest, dateTimeResponse, interval.TotalSeconds, Environment.NewLine);

      

            Console.WriteLine(str1);
            Console.ReadKey();
            return;

            //Thread t = new Thread(() => {
            //    Console.WriteLine("5秒后，运行子线程");
            //    Thread.Sleep(TimeSpan.FromSeconds(5));
            //    Console.WriteLine("子线程运行完毕");

            //    Console.WriteLine("5秒后，再运行子线程任务");
            //    Thread.Sleep(TimeSpan.FromSeconds(5));
            //    Console.WriteLine("因为线程IsBackground = false，不是后台线程，所以主线程即使完成了，子线程也会继续完成");
            //    Console.WriteLine("请按任意键结束。。。。");
            //    Console.ReadKey();
            //});
            //t.IsBackground = true;//因为线程IsBackground = false，不是后台线程，所以主线程即使完成了，子线程也会继续完成
            //t.Start();
            //Console.WriteLine("主线程给 子线程 6秒完成任务");
            //Thread.Sleep(TimeSpan.FromSeconds(6));
            //Console.WriteLine("主线程完成了");

            //return;
            ThreadTest threadTest = new ThreadTest();
            threadTest.TestMultiThread();
            Console.WriteLine("thread End {0}", Thread.CurrentThread.ManagedThreadId);

            threadTest.TestMultiThread();
            Console.WriteLine("thread End {0}", Thread.CurrentThread.ManagedThreadId);

            //Console.ReadKey();
            return;

            for (int i = 0; i < 500; i++)

            {

                Console.WriteLine("This is No. {0} task in No. {1} thread", i, System.Threading.Thread.CurrentThread.Name);

                Trace.WriteLine(String.Format("This is No. {0} task in No. {1} thread", i, System.Threading.Thread.CurrentThread.Name), "Information");

            }
            return;

            Certificate certificate = new Certificate();
            certificate.GetCert();
            //certificate.GetFileDigitalSignatures();
            Console.WriteLine("End");
            Console.ReadKey();
            return;

            AsyncAwait asyncAwait = new AsyncAwait();
            Task<string> taskstr= asyncAwait.DemoAsync();
            asyncAwait.TestAsyncReturnVariable();
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(AsyncAwait.i);
                Console.WriteLine(taskstr.Result);
                Thread.Sleep(1000);
            }
            Console.ReadKey();

            return;


            OPCUARobot oPCUARobot = new OPCUARobot();
            oPCUARobot.ConnectRobot();
            Console.ReadKey();
            oPCUARobot.SubscribRobot();
            Console.ReadKey();
            return;

            HttpController httpController = new HttpController();
            httpController.InitController();
            Console.ReadKey();
            return;

            double d = 5.5;
            int u = (int)d;
            Console.WriteLine(u);

            RobotCategory robotCategory = RobotCategory.ROB1;
            Console.WriteLine(string.Format("{0}--{1}Scan.json", robotCategory,1.ToString().PadLeft(4,'0')));
            
            byte[] data= new byte[3] ;
            data[0] = 13;

            CRCAlgorithm cRCAlgorithm = new CRCAlgorithm();
            cRCAlgorithm.ModBusCRC16(ref data, 1);
            Console.ReadKey();
            return;


            JsonTest jsonTest = new JsonTest();
            jsonTest.TestData();


            //MongoDBTest mongoDBTest = new MongoDBTest();
            //mongoDBTest.TestData();

            var y = new BsonDocument {
                { "name", "MongoDB" }
                };

            B b = new B();
            A a = new A();
            printstr(a);
            printstr(b);
            Console.ReadKey();
            return;


            CertInfo.ShowInfo(@"C:\ProgramData\ABB\IRC5 OPC UA\CertificateStores\ApplicationCertificate\certs\IRC5 OPC UA Server [9236BDA1082D64A513341C8B49B286156F1ADE2E].der");
            return;

            int value = 12345678;
            byte[] bytes = BitConverter.GetBytes(value);
            Console.WriteLine(BitConverter.ToString(bytes));

            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            Console.WriteLine(BitConverter.ToString(bytes));
            // Call method to send byte stream across machine boundaries.

            // Receive byte stream from beyond machine boundaries.
            Console.WriteLine(BitConverter.ToString(bytes));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            Console.WriteLine(BitConverter.ToString(bytes));
            int result = BitConverter.ToInt32(bytes, 0);
            Console.WriteLine("Original value: {0}", value);
            Console.WriteLine("Returned value: {0}", result);


            Console.ReadKey();
            return;


            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.


            Bitmap bitmapOrigin = new Bitmap(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\Text.bmp");
            Bitmap bitmapContour = null;
            BitmapOutline bitmapOutline = new BitmapOutline(bitmapOrigin);
            bitmapContour= bitmapOutline.Calculate(GradientTypeEnum.Lapacian, 125);
            bitmapContour.Save(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\TextContour.bmp");

            //bitmapContour = bitmapOutline.Calculate(GradientTypeEnum.Sobel_Horizontal, 125);
            //bitmapContour.Save(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\TextContourSobelHorizontal.bmp");

            //bitmapContour = bitmapOutline.Calculate(GradientTypeEnum.Sobel_Vertical, 125);
            //bitmapContour.Save(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\TextContourSobel_Vertical.bmp");

            //bitmapContour = bitmapOutline.Calculate(GradientTypeEnum.Sobel_Diagonal1, 125);
            //bitmapContour.Save(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\TextContourSobelDiagonal1.bmp");

            //bitmapContour = bitmapOutline.Calculate(GradientTypeEnum.Sobel_Diagonal2, 125);
            //bitmapContour.Save(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\TextContourSobelDiagonal2.bmp");

            //bitmapContour = bitmapOutline.Calculate(GradientTypeEnum.Prewitt_Horizontal, 125);
            //bitmapContour.Save(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\TextContourPrewittHorizontal.bmp");

            //bitmapContour = bitmapOutline.Calculate(GradientTypeEnum.Prewitt_Vertical, 125);
            //bitmapContour.Save(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\TextContourPrewittVertical.bmp");

            //bitmapContour = bitmapOutline.Calculate(GradientTypeEnum.Prewitt_Diagonal1, 125);
            //bitmapContour.Save(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\TextContourPrewittDiagonal1.bmp");

            //bitmapContour = bitmapOutline.Calculate(GradientTypeEnum.Prewitt_Diagonal2, 125);
            //bitmapContour.Save(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\TextContourPrewittDiagonal2.bmp");


            StreamWriter streamWriter = new StreamWriter(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\TextContour.txt");
            for (int i = 0; i < bitmapContour.Width; i++)
            {
                for (int j = 0; j < bitmapContour.Height; j++)
                {
                    Color colorPixel = bitmapContour.GetPixel(i, j);
                    if (colorPixel.R == 255)
                    {
                        streamWriter.WriteLine(string.Format("{0},{1},{2}", i, j, bitmapContour.GetPixel(i, j)));
                    }
                    //streamWriter.WriteLine(string.Format("{0},{1},{2}", i, j, bitmapContour.GetPixel(i, j)));
                }
            }
            streamWriter.Close();

            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }

    class A
    {
        public A()
        {

        }

        public string str = "A";
    }

    class B:A
    {
        public B()
        {
            this.str = "B";
        }
    }
}
