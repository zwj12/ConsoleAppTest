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

namespace ConsoleAppTest
{
    class Program
    {
        public static ManualResetEvent StopEventHandle;
        public static AutoResetEvent EngineIsReady;
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static void printstr(A a)
        {
            Console.WriteLine("printstrA");
        }

        static void Main(string[] args)
        {
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
