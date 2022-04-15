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
                textWriterTraceListener = new TextWriterTraceListener(@"D:\Michael.log");
                //System.Diagnostics.Trace.Listeners.Clear();
                Trace.AutoFlush = true;
                Trace.Listeners.Add(textWriterTraceListener);
            }
            Trace.WriteLine(DateTime.Now.ToString() + " " + strLog);
        }
    }
}
