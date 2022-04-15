using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.OPCUA
{
    public class OPCUARobot
    {
        private OpcUaClient opcUaClient = new OpcUaClient();

        public void GetRobotDataValue()
        {
            //string url = "opc.tcp://118.24.36.220:62547/DataAccessServer";
            string url = "opc.tcp://cn-l-7256975:61510/ABB.IRC5.OPCUA.Server";
            opcUaClient.ConnectServer(url);
            //string opctag = "ns=2;s=Machines/Machine A/TestValueInt";
            string opctag = "ns=2;i=11"; 
            opcUaClient.AddSubscription("MainTag", opctag, SubCallback);
        }

        public void ConnectRobot()
        {
            opcUaClient.AppConfig.ApplicationName = "MyHomework";
            opcUaClient.AppConfig.ApplicationUri = Utils.Format(@"urn:{0}:MyHomework", System.Net.Dns.GetHostName());
            opcUaClient.AppConfig.ApplicationType = ApplicationType.Client;
            opcUaClient.AppConfig.SecurityConfiguration = new SecurityConfiguration
            {
                ApplicationCertificate = new CertificateIdentifier
                {
                    StoreType = @"Directory",
                    StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\MachineDefault",
                    SubjectName = Utils.Format(@"CN={0}, DC={1}", "MyHomework", System.Net.Dns.GetHostName()),
                },
                TrustedIssuerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Certificate Authorities" },
                TrustedPeerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Applications" },
                RejectedCertificateStore = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\RejectedCertificates" },
                AutoAcceptUntrustedCertificates = true,
                AddAppCertToTrustedStore = true,
            };
            opcUaClient.AppConfig.TransportConfigurations = new TransportConfigurationCollection();
            opcUaClient.AppConfig.TransportQuotas = new TransportQuotas { OperationTimeout = 15000 };
            opcUaClient.AppConfig.ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 };
            opcUaClient.AppConfig.TraceConfiguration = new TraceConfiguration();

            opcUaClient.AppConfig.Validate(ApplicationType.Client).GetAwaiter().GetResult();
            if (opcUaClient.AppConfig.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                opcUaClient.AppConfig.CertificateValidator.CertificateValidation += (s, e) => { e.Accept = (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted); };
            }

            var application = new Opc.Ua.Configuration.ApplicationInstance
            {
                ApplicationName = "MyHomework",
                ApplicationType = ApplicationType.Client,
                ApplicationConfiguration = opcUaClient.AppConfig
            };
            application.CheckApplicationInstanceCertificate(false, 2048, 24).GetAwaiter().GetResult();

            opcUaClient.ConnectServer("opc.tcp://cn-l-7256975:61510/ABB.IRC5.OPCUA.Server");

            bool result = opcUaClient.Connected;
        }

        public void SubscribRobot()
        {
            string opctag = "ns=2;i=11";
            opcUaClient.AddSubscription("MainTag", opctag, SubCallback);
        }

        private void SubCallback(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
        {
            try
            {
                if (key == "MainTag")
                {
                    MonitoredItemNotification notification = args.NotificationValue as MonitoredItemNotification;
                    if (notification != null)
                    {
                        //这里订阅值，有变化，则执行抓取所有数据包
                        object value = notification.Value.WrappedValue.Value;
                        int tagValue = Convert.ToInt32(value);
                        Console.WriteLine(tagValue);
                     
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
