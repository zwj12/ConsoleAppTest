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

        class Person
        {
            public Person(string name)
            {
                Name = name;
            }
            public string Name { get; set; }
        }

        static List<Person> _people = new List<Person>();


        private static void MakePerson()
        {
            int i = 10;
            int j;
            j = i;
            Person c = new Person("Bob");
            _people.Add(c);
        }

        private static void DoSomething()
        {
            // more processing
            Console.WriteLine("done");
        }

        public static async void DoWork()
        {
            Console.WriteLine("Static thread procedure. Data='{0}'");
        }

        static void IntializeConfigurationFile()
        {
            // Create a set of unique key/value pairs to store in
            // the appSettings section of an auxiliary configuration
            // file.
            string time1 = String.Concat(DateTime.Now.ToLongDateString(),
                                   " ", DateTime.Now.ToLongTimeString());

            string time2 = String.Concat(DateTime.Now.ToLongDateString(),
                                   " ", new DateTime(2009, 06, 30).ToLongTimeString());

            string[] buffer = {"<appSettings>",
        "<add key='AuxAppStg0' value='" + time1 + "'/>",
        "<add key='AuxAppStg1' value='" + time2 + "'/>",
        "</appSettings>"};

            // Create an auxiliary configuration file and store the
            // appSettings defined before.
            // Note creating a file at run-time is just for demo 
            // purposes to run this example.
            File.WriteAllLines("auxiliaryFile.config", buffer);

            // Get the current configuration associated
            // with the application.
            System.Configuration.Configuration config =
               ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Associate the auxiliary with the default
            // configuration file. 
            System.Configuration.AppSettingsSection appSettings = config.AppSettings;
            appSettings.File = "auxiliaryFile.config";

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload in memory of the 
            // changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void CreateAppSettings()
        {
            // Get the application configuration file.
            System.Configuration.Configuration config =
              ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            string sectionName = "appSettings";

            // Add an entry to appSettings.
            int appStgCnt =
                ConfigurationManager.AppSettings.Count;
            string newKey = "NewKey" + appStgCnt.ToString();

            string newValue = DateTime.Now.ToLongDateString() +
              " " + DateTime.Now.ToLongTimeString();

            config.AppSettings.Settings.Add(newKey, newValue);

            // Save the configuration file.
            //config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of the changed section. This 
            // makes the new values available for reading.
           ConfigurationManager.RefreshSection(sectionName);

            // Get the AppSettings section.
            AppSettingsSection appSettingSection =
              (AppSettingsSection)config.GetSection(sectionName);

           

            Console.WriteLine();
            Console.WriteLine("Using GetSection(string).");
            Console.WriteLine("AppSettings section:");
            Console.WriteLine(
            appSettingSection.Settings["Setting3"].Value);
        }

        static void Main(string[] args)
        {
            Rick.SortFile.SortFilesByName();
            return;


            Task task1 = Task.Run(
                          () =>
                          {
                              Thread.Sleep(3000);
                              Console.WriteLine($"Task.Run 1 方式创建一个task，线程ID为{Thread.CurrentThread.ManagedThreadId}");
                          });

            Task task2 = Task.Run(
                () =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"Task.Run 2 方 式创建一个task，线程ID为{Thread.CurrentThread.ManagedThreadId}");
                });

            Task task3 = Task.Run(
                () =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Task.Run 3方式创建一个task，线程ID为{Thread.CurrentThread.ManagedThreadId}");
                });
            Console.ReadKey();

            return;


            InteropTest.MarshalTest();
            Console.ReadKey();
            return;

            //DateTime TimeStamp = DateTime.Now;
            //DateTime TimeStamp = DateTime.Parse("2022-05-14T11:54:18");
            //Console.WriteLine(TimeStamp.ToString("s"));
            //Console.WriteLine(TimeStamp.ToString("o"));
            //Console.WriteLine(TimeStamp.ToString("O"));

            string dllDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            System.IO.DirectoryInfo dllDirectoryInfo = new System.IO.DirectoryInfo(dllDirectory);
            System.IO.DirectoryInfo ZenonProjectDirectoryInfo = dllDirectoryInfo.Parent.Parent.Parent;
            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Console.WriteLine(dllDirectory);
            Console.WriteLine(dllDirectoryInfo.FullName);

            System.IO.DirectoryInfo dllDirectoryInfoTest = new System.IO.DirectoryInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Console.WriteLine(dllDirectoryInfoTest.FullName);


            Console.ReadKey();
            return;
            string server = null;

            // Define a regular expression to parse user's input.
            // This is a security check. It allows only
            // alphanumeric input string between 2 to 40 character long.
            Regex rex = new Regex(@"^[a-zA-Z]\w{1,39}$");

            if (args.Length < 1)
            {
                // If no server name is passed as an argument to this program, use the current
                // server name as default.
                server = Dns.GetHostName();
                Console.WriteLine("Using current host: " + server);
            }
            else
            {
                server = args[0];
                server = "www.baidu.com";
                if (!(rex.Match(server)).Success)
                {
                    Console.WriteLine("Input string format not allowed.");
                    //return;
                }
            }

            server = "www.baidu.com";

            // Get the list of the addresses associated with the requested server.
            IPAddresses(server);

            // Get additional address information.
            IPAddressAdditionalInfo();

            Console.ReadKey();

            return;

            string sstr = null;

            string sstr1 = sstr ?? "hello";
            string sstr2 = sstr1 ?? "hello2";
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = @"Configuration\Michael.Config";
            configFileMap.LocalUserConfigFilename = @"Configuration\MichaelLocal.Config";
            configFileMap.RoamingUserConfigFilename = @"Configuration\MichaelRoaming.Config";

            //var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap,ConfigurationUserLevel.None);
            CustomSection customSection = configFile.GetSection("CustomSection") as CustomSection;
            customSection.MaxUsers = 111;
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("CustomSection");

            //configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            customSection = configFile.GetSection("CustomSection") as CustomSection;

            ConfigurationManager.RefreshSection("CustomSection");
            long ixd = customSection.MaxUsers;

            //var configFileRoaming = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            var configFileRoaming = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.PerUserRoaming);
            CustomSection customSectionRoaming = configFileRoaming.GetSection("CustomSection") as CustomSection;
            customSectionRoaming.MaxUsers = 22;   
            configFileRoaming.Save(ConfigurationSaveMode.Modified);

            //var configFileLocal2 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            //CustomSection customSectionLocal2 = configFileLocal2.GetSection("CustomSection") as CustomSection;
           var customSectionLocal2 = ConfigurationManager.GetSection("CustomSection") as CustomSection;
            //var customSectionLocal3 = ConfigurationManager.GetSection("CustomSection") as CustomSection;

            //var configFileLocal = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            ////var configFileLocal = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.PerUserRoamingAndLocal);
            //CustomSection customSectionLocal = configFileLocal.GetSection("CustomSection") as CustomSection;
            //customSectionLocal.MaxUsers = 35669;
            //configFileLocal.Save(ConfigurationSaveMode.Modified);

            //customSectionLocal2.MaxUsers = 12;
            ConfigurationManager.RefreshSection("CustomSection");

            var customSectionLocal3 = ConfigurationManager.GetSection("CustomSection") as CustomSection;
            long ixds= customSectionLocal3.MaxUsers;

            //ConfigurationManager.RefreshSection(appSettings.SectionInformation.Name);
            //ConfigurationManager.RefreshSection(customSectionLocal.SectionInformation.Name);   

            //  Console.ReadKey();

            return;


            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

            Console.ReadKey();

            return;

            //List<Thread> threads = new List<Thread>();
            //for (int i = 0; i < 5; i++)
            //{
            //    Thread thread = new Thread(LockAsync.WaitAync);
            //    threads.Add(thread);
            //    thread.Start();
            //}
            //foreach (var item in threads)
            //{
            //    item.Join();
            //}

            //int ixt = LockAsync._mutex.CurrentCount;

            //LockAsync.WaitAync(1);
            //LockAsync.WaitAync(2);
            //LockAsync.WaitAync(3);
            //LockAsync.WaitAync(4);
            //LockAsync.WaitAync(5);

            LockAsync.Mainx();

            Console.ReadKey();

            return;


            int k1 = 17;
            k1++;
            MakePerson();
            DoSomething();
            return;

            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            //Trace.Indent();
            Trace.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Trace.WriteLine("Exiting Main");
            // Trace.Unindent();


            SystemTrace.WriteMichaelLog("Entering Main");
            Console.WriteLine("Hello World.");
            SystemTrace.WriteMichaelLog("Exiting Main");

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
            Task task11=  TaskTest.TestWithOutawaitAsync();
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

        private static void IPAddresses(string server)
        {
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

                // Get server related information.
                IPHostEntry heserver = Dns.GetHostEntry(server);

                // Loop on the AddressList
                foreach (IPAddress curAdd in heserver.AddressList)
                {


                    // Display the type of address family supported by the server. If the
                    // server is IPv6-enabled this value is: InterNetworkV6. If the server
                    // is also IPv4-enabled there will be an additional value of InterNetwork.
                    Console.WriteLine("AddressFamily: " + curAdd.AddressFamily.ToString());

                    // Display the ScopeId property in case of IPV6 addresses.
                    if (curAdd.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
                        Console.WriteLine("Scope Id: " + curAdd.ScopeId.ToString());


                    // Display the server IP address in the standard format. In
                    // IPv4 the format will be dotted-quad notation, in IPv6 it will be
                    // in in colon-hexadecimal notation.
                    Console.WriteLine("Address: " + curAdd.ToString());

                    // Display the server IP address in byte format.
                    Console.Write("AddressBytes: ");

                    Byte[] bytes = curAdd.GetAddressBytes();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        Console.Write(bytes[i]);
                    }

                    Console.WriteLine("\r\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[DoResolve] Exception: " + e.ToString());
            }
        }

        // This IPAddressAdditionalInfo displays additional server address information.
        private static void IPAddressAdditionalInfo()
        {
            try
            {
                // Display the flags that show if the server supports IPv4 or IPv6
                // address schemas.
                Console.WriteLine("\r\nSupportsIPv4: " + Socket.SupportsIPv4);
                Console.WriteLine("SupportsIPv6: " + Socket.SupportsIPv6);

                if (Socket.SupportsIPv6)
                {
                    // Display the server Any address. This IP address indicates that the server
                    // should listen for client activity on all network interfaces.
                    Console.WriteLine("\r\nIPv6Any: " + IPAddress.IPv6Any.ToString());

                    // Display the server loopback address.
                    Console.WriteLine("IPv6Loopback: " + IPAddress.IPv6Loopback.ToString());

                    // Used during autoconfiguration first phase.
                    Console.WriteLine("IPv6None: " + IPAddress.IPv6None.ToString());

                    Console.WriteLine("IsLoopback(IPv6Loopback): " + IPAddress.IsLoopback(IPAddress.IPv6Loopback));
                }
                Console.WriteLine("IsLoopback(Loopback): " + IPAddress.IsLoopback(IPAddress.Loopback));
            }
            catch (Exception e)
            {
                Console.WriteLine("[IPAddresses] Exception: " + e.ToString());
            }
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
