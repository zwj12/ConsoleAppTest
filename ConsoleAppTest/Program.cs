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
using ConsoleAppTest.Log;
using ConsoleAppTest.Lock;
using System.Configuration;
using ConsoleAppTest.Configuration;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using ConsoleAppTest.Interop;
using System.Globalization;
using System.IO.Compression;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;
using System.Security.Cryptography.X509Certificates;
using ConsoleAppTest.Interview;
using ConsoleAppTest.Rick;

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

        public static  A A(this A @this,string str1)
        {
            Console.WriteLine(@this.Getstr());
            @this.str= "AAA";
            return @this;
        }
    }

    enum weekday
    {
        monday=1,
        tuesday=2,
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string str = "abc123assdfds12432134sdfdsf";
            Regex reg = new Regex(@"[0-9]+");
            Match mc = reg.Match(str);
          string str2=  reg.Replace(str, "zhuweijin",1);
            Console.WriteLine(str);
            Console.WriteLine(str2);
            SortFile.SortFilesByName();

            Console.ReadKey();

        }

   
    }



}
