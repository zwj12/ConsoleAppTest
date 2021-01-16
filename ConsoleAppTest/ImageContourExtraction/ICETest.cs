using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.ImageContourExtraction
{
    class ICETest
    {
        static void Main1(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            Bitmap bitmapOrigin = new Bitmap(@"C:\Users\CNMIZHU7\source\repos\ConsoleAppTest\ConsoleAppTest\Text.bmp");
            Bitmap bitmapContour = null;
            BitmapOutline bitmapOutline = new BitmapOutline(bitmapOrigin);
            bitmapContour = bitmapOutline.Calculate(GradientTypeEnum.Lapacian, 125);
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
                        //streamWriter.WriteLine(string.Format("{0},{1},{2}", i, j, bitmapContour.GetPixel(i, j)));
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
}
