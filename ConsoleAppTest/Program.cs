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

        public enum ItmsrcTriggerType
        {
            TRIGGER_NOT_USED,
            TRIGGER_TYPE_DISTANCE,
            TRIGGER_TYPE_IO,
        }

        public enum ItmsrcSourceTypes
        {
            ITMSRC_UNDEFINED_TYPE = 0,
            ITMSRC_PICK_TYPE,
            ITMSRC_PLACE_TYPE
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct ItmsrcSetupDataParam
        {
            public ItemSourceMessageVersion version;
            public ItmsrcTriggerType trigger_type;
            public bool log_used;
            public Int32 trigg_distance;
            public bool cnv_start_stop_limits_used;
            public Int32 work_area_enter;
            public Int32 work_area_exit;
            public Int32 cnv_stop_limit;
            public Int32 cnv_start_limit;
            public ItmsrcSourceTypes source_type;
            public float itmtgt_tune_x;
            public float itmtgt_tune_y;
            public float itmtgt_tune_z;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] pos_gen_trig_eio_name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] trig_eio_name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] strobe_eio_name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] rob_exe_eio_name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] queue_idle_eio_name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] pos_available_eio_name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public char[] convey_name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] cnv_control_eio_name;
        }
        public static void Main(string[] args)
        {
            DateTime PMOPStopTime = DateTime.Now;
            DateTime PMOPStartTime= DateTime.Now.AddDays(-4);

            TimeSpan sdf = PMOPStopTime - PMOPStartTime;

            Console.WriteLine($"{sdf}");

            //sfdsfdsf
            ItmsrcSetupDataParam itmsrcStatisticsData = new ItmsrcSetupDataParam();
            int size1 = Marshal.SizeOf(itmsrcStatisticsData);

            Console.ReadKey();
        }

     

    }


}

