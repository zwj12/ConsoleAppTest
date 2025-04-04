using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

namespace ConsoleAppTestNet
{
    internal class Program
    {
        static void Main()
        {
            XDocument  xDocument = new XDocument();

            XElement  xProjCommList = new XElement("ProjCommList");
            XElement  xProjCmd = new XElement("RisCmd", "A");
            xProjCommList.Add(xProjCmd);
            xProjCmd = new XElement("RisCmd", "C");
            xProjCommList.Add(xProjCmd);
            xProjCmd = new XElement("RisCmd", "D");
            xProjCommList.Add(xProjCmd);
            xProjCmd = new XElement("RisCmd", "B");
            xProjCommList.Add(xProjCmd);
            var x=   xProjCommList.Elements().OrderBy(x => x.Value);

            XElement xProjCommList2 = new XElement("ProjCommList");
            xProjCommList2.Add(xProjCommList.Elements().OrderBy(x => x.Value));
            xProjCommList2.Add(x);
            xDocument.Add(xProjCommList2);

            xDocument.Save("test.xml");
        }

        static Encoding GetFileEncoding(string filePath)
        {
            // Default to UTF8 if no BOM is found
            Encoding encoding = Encoding.UTF8;

            using (var reader = new StreamReader(filePath, true))
            {
                if (reader.Peek() >= 0)
                {
                    reader.Read();
                    encoding = reader.CurrentEncoding;
                }
            }

            return encoding;
        }
    }

}
