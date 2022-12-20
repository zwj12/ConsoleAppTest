using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

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
            tcpClient = new TcpClient();
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

        private static byte[] PackSocketHeader(UInt32 command, byte[] data = null)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriterData = new BinaryWriter(memoryStream))
                {
                    binaryWriterData.Write(command);
                    if (data != null && data.Length > 0)
                    {
                        binaryWriterData.Write(Convert.ToUInt32(data.Length));
                        binaryWriterData.Write(data);
                    }
                    else
                    {
                        binaryWriterData.Write((UInt32)0);
                    }
                    return memoryStream.ToArray();
                }
            }
        }

        public static void SendData()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriterData = new BinaryWriter(memoryStream))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        binaryWriterData.Write(-1248.41f +i*30);
                        binaryWriterData.Write(-251.20f+ i*30);
                        binaryWriterData.Write(2085.35f);
                        binaryWriterData.Write(0.0465545f);
                        binaryWriterData.Write(-0.823272f);
                        binaryWriterData.Write(0.56531f);
                        binaryWriterData.Write(-0.0219229f);
                        binaryWriterData.Write(-1);
                        binaryWriterData.Write(-1);
                        binaryWriterData.Write(0);
                        binaryWriterData.Write(0);
                    }
                }
                byte[] requestBytes = PackSocketHeader(1, memoryStream.ToArray());
                binaryWriter.Write(requestBytes);
            }

            UInt32 command = binaryReader.ReadUInt32();
            UInt32 dataLength = binaryReader.ReadUInt32();
            UInt32 errorCode = binaryReader.ReadUInt32();
        }

        public static void Start()
        {
            byte[] requestBytes = PackSocketHeader(2);
            binaryWriter.Write(requestBytes);

            UInt32 command = binaryReader.ReadUInt32();
            UInt32 dataLength = binaryReader.ReadUInt32();
            UInt32 errorCode = binaryReader.ReadUInt32();
        }

        public static void Stop()
        {
            byte[] requestBytes = PackSocketHeader(3);
            binaryWriter.Write(requestBytes);

            UInt32 command = binaryReader.ReadUInt32();
            UInt32 dataLength = binaryReader.ReadUInt32();
            UInt32 errorCode = binaryReader.ReadUInt32();
        }

        public static UInt32 GetRobotStatus()
        {
            byte[] requestBytes = PackSocketHeader(4);
            binaryWriter.Write(requestBytes);

            UInt32 command = binaryReader.ReadUInt32();
            UInt32 dataLength = binaryReader.ReadUInt32();
            UInt32 errorCode = binaryReader.ReadUInt32();
            UInt32 robotStatus = binaryReader.ReadUInt32();

            return robotStatus;
        }

        public static void ClearData()
        {
            byte[] requestBytes = PackSocketHeader(5);
            binaryWriter.Write(requestBytes);

            UInt32 command = binaryReader.ReadUInt32();
            UInt32 dataLength = binaryReader.ReadUInt32();
            UInt32 errorCode = binaryReader.ReadUInt32();
        }


    }
}
