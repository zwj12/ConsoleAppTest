using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Socket
{
    public static class SocketClient
    {
        private static TcpClient tcpClient;
        private static BinaryWriter binaryWriter;
        private static BinaryReader binaryReader;

        public static void Connect(IPEndPoint remoteEP)
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                binaryReader.Close();
                binaryWriter.Close();
                tcpClient.Close();
            }
            tcpClient=new TcpClient();
            tcpClient.Connect(remoteEP);
            binaryReader = new BinaryReader(tcpClient.GetStream());
            binaryWriter = new BinaryWriter(tcpClient.GetStream());
        }

        public static void Close()
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                binaryReader.Close();
                binaryWriter.Close();
                tcpClient.Close();
            }
        }

        private static byte[] PackSocketHeader(UInt32 command, MemoryStream requestData=null)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriterData = new BinaryWriter(memoryStream))
                {
                    binaryWriterData.Write(command);
                    if (requestData != null && requestData.Length > 0)
                    {
                        binaryWriterData.Write(Convert.ToUInt32(requestData.Length));
                        binaryWriterData.Write(requestData.ToArray());
                    }
                    else
                    {
                        binaryWriterData.Write((UInt32)0);
                    }

                    return memoryStream.ToArray();
                }
            }           
        }

        public static UInt32 GetRobotStatus()
        {
            byte[] requestBytes = PackSocketHeader(4);
            binaryWriter.Write(requestBytes);

            UInt32 command= binaryReader.ReadUInt32();
            UInt32 dataLength = binaryReader.ReadUInt32();
            UInt32 errorCode = binaryReader.ReadUInt32();
            UInt32 robotStatus = binaryReader.ReadUInt32();

            return robotStatus;
        }
    }
}
