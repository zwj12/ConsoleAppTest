using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.CRC
{
    public class CRCAlgorithm
    {
        public void ModBusCRC16(ref byte[] cmd, int len)
        {
            ushort i, j, tmp, CRC16;

            CRC16 = 0xFFFF;             //CRC寄存器初始值
            for (i = 0; i < len; i++)
            {
                CRC16 ^= cmd[i];
                for (j = 0; j < 8; j++)
                {
                    tmp = (ushort)(CRC16 & 0x0001);
                    CRC16 >>= 1;
                    if (tmp == 1)
                    {
                        CRC16 ^= 0xA001;    //异或多项式
                    }
                }
            }
            cmd[i++] = (byte)(CRC16 & 0x00FF);
            Console.WriteLine(string.Format("{0:X}", cmd[i-1]));
            cmd[i++] = (byte)((CRC16 & 0xFF00) >> 8);
            Console.WriteLine(string.Format("{0:X}", cmd[i - 1]));

        }
    }
}
