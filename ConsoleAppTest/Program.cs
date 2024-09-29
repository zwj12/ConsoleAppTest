using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ConsoleAppTest
{

    public static class Program
    {
        public enum ItemSourceMessageVersion
        {
            ITMSRC_MESSAGE_VERSION_1 = 1,
            ITMSRC_MESSAGE_VERSION_2,
            ITMSRC_MESSAGE_VERSION_3,
            ITMSRC_MESSAGE_VERSION_4,
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct ItmsrcItemStatisticsV2
        {
            public bool used;
            public Int32 item_type;
            public Int32 no_of_used;
            public Int32 no_of_skipped;
            public Int32 overflow;
            public Int32 total_overflow;
            public Int32 incoming;
            public Int32 total_incoming;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct ItmsrcContainerStatistics
        {
            public Int32 no_of_completed;
            public Int32 no_of_incompleted;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct ItmsrcStatisticsDataV2
        {
            public ItemSourceMessageVersion version;
            public Int64 ct_time;
            public Int32 itmtgt_number;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public ItmsrcItemStatisticsV2[] item_stat;
            public ItmsrcContainerStatistics container_stat;
            public Int32 no_of_cnv_stops;
        }

        public static void Main(string[] args)
        {
            ItmsrcStatisticsDataV2 itmsrcStatisticsData = new ItmsrcStatisticsDataV2();
            ItmsrcContainerStatistics itmsrcContainerStatistics= new ItmsrcContainerStatistics();
            ItmsrcItemStatisticsV2 itmsrcItemStatisticsV2 = new ItmsrcItemStatisticsV2();
            int size1 = Marshal.SizeOf(itmsrcStatisticsData);
            int size2 = Marshal.SizeOf(itmsrcItemStatisticsV2);
            int size3 = Marshal.SizeOf(itmsrcContainerStatistics);

            Console.ReadKey();
        }

     

    }


}

