using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Log
{
    class SystemTrace
    {
        private static TextWriterTraceListener textWriterTraceListener;

        public void WriteMichaelLog(string strLog)
        {
            if (textWriterTraceListener == null)
            {
                //System.Diagnostics.Trace.Listeners.Clear();

                textWriterTraceListener = new TextWriterTraceListener(@"D:\Michael.log");
                //textWriterTraceListener.Filter = new EventTypeFilter(SourceLevels.Verbose);
                Trace.Listeners.Add(textWriterTraceListener);

                //EventLogTraceListener myTraceListener = new EventLogTraceListener("myEventLogSource1");
                //Trace.Listeners.Add(myTraceListener);

                Trace.AutoFlush = true;
            }
            Trace.TraceInformation("TraceInformation");
            Trace.TraceError("TraceError");
            Trace.TraceWarning("TraceWarning");
            Trace.WriteLine("WriteLine", "Category");
            Trace.WriteLine(DateTime.Now.ToString() + " " + strLog);
        }

        private static void WriteLog(string strLog)
        {
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss ") + strLog + Environment.NewLine);
        }

        private static void WriteLog(Exception ex)
        {
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss ") + ex.Message + Environment.NewLine + "Source:" + ex.Source + Environment.NewLine + ex.StackTrace + Environment.NewLine);
        }
    }
}
