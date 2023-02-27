using ConsoleAppTest.Rick;
using ConsoleAppTest.Socket;
using ConsoleAppTest.Zip;
using Ionic.Zip;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    public class A
    {
        private A()
        {

        }

        public static string str = "A";

        public static string MyProperty { get; set; }
    }

    enum weekday
    {
        monday = 1,
        tuesday = 2,
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            string solutionDir = @"C:\PMTWTempFiles\PMPP\Solutions\SolutionOneRobotRW6";
            string packPath = @"C:\PMTWTempFiles\PMPP\PackedSolutions\SolutionOneRobotRW6.rspag";

            try
            {
                ZipHelper zipHelper= new ZipHelper();
                zipHelper.Pack(solutionDir, packPath);
                zipHelper.Unpack(packPath, solutionDir);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          



            //SortFile.SortFilesByName();


            Console.ReadKey();

        }


    }


}

