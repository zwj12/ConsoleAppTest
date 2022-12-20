using ConsoleAppTest.Socket;
using System;
using System.Net;

namespace ConsoleAppTest
{
    public class A
    {
        public A()
        {

        }

        public string str = "A";
    }

    public static class B
    {
        public static string Getstr(this A @this)
        {
            return @this.str;
        }

        public static A A(this A @this, string str1)
        {
            Console.WriteLine(@this.Getstr());
            @this.str = "AAA";
            return @this;
        }
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
            //SortFile.SortFilesByName();

            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(iPAddress, 3008);
            SocketClient.Connect(remoteEP);
            UInt32 robotStatus = SocketClient.GetRobotStatus();
            if(robotStatus == 0 )
            {
                SocketClient.ClearData();
                SocketClient.SendData();
                SocketClient.Start();
                Console.WriteLine("Start robot");
            }
            else
            {
                Console.WriteLine("Robot is busy, trying to stop robot");
                SocketClient.Stop();
            }
          
            SocketClient.Close();
            Console.ReadKey();

        }


    }



}
