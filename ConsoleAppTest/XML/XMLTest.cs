using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleAppTest.XML
{
    class XMLTest
    {
        public void ReadFromString()
        {
            StringReader strRdr = new StringReader(@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<root>
    <cat color=""white"">I'm a Cat</cat>
    <dog color=""yellow""/>
</root>");

            XmlReader rdr = XmlReader.Create(strRdr);


            while (rdr.Read())
            {
                Console.WriteLine("rdr.NodeType = " + rdr.NodeType);
                if (rdr.NodeType == XmlNodeType.Element)
                {
                    string elementName = rdr.Name;
                    Console.WriteLine(elementName + " element start");
                    if (elementName == "root")
                    {

                    }
                    else if (elementName == "cat")
                    {
                        string colorVal = rdr["color"];
                        Console.WriteLine("\tcat's color is " + colorVal);
                        if (rdr.Read())
                        {
                            Console.WriteLine("\t cat said:" + rdr.Value);
                        }
                    }
                }
                else if (rdr.NodeType == XmlNodeType.EndElement)
                {
                    string elementName = rdr.Name;
                    Console.WriteLine(elementName + " element end");
                }
            }

            rdr.Close();
            strRdr.Close();
        }
    }

}

