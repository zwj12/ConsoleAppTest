using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using System.Text.RegularExpressions;

namespace ConsoleAppTest.Rick
{
    public static class SortFile
    {
        private static Regex reg = new Regex(@"[0-9]+");

        public static void SortFilesByName()
        {
            DirectoryInfo TheFolder = new DirectoryInfo(@"E:\三国演义");
            DirectoryInfo NewFolder = Directory.CreateDirectory(@"E:\MP3New");

            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                string strNewFileName = "";
                Match mc = reg.Match(NextFile.Name);
                if (mc.Length == 1)
                {
                    strNewFileName = reg.Replace(NextFile.Name, "000" + mc.Value, 1);
                    Console.WriteLine(strNewFileName);
                    File.Move(NextFile.FullName, Path.Combine(NextFile.Directory.FullName, strNewFileName));
                }
                else if (mc.Length == 2)
                {
                    strNewFileName = reg.Replace(NextFile.Name, "00" + mc.Value, 1);
                    Console.WriteLine(strNewFileName);
                    File.Move(NextFile.FullName, Path.Combine(NextFile.Directory.FullName, strNewFileName));
                }
                else if (mc.Length == 3)
                {
                    strNewFileName = reg.Replace(NextFile.Name, "0" + mc.Value, 1);
                    Console.WriteLine(strNewFileName);
                    File.Move(NextFile.FullName, Path.Combine(NextFile.Directory.FullName, strNewFileName));
                }
                else
                {
                    File.Move(NextFile.FullName, Path.GetFileNameWithoutExtension(NextFile.FullName));
                }

            }

            foreach (FileInfo NextFile in TheFolder.GetFiles().OrderBy(f => f.Name))
            {
                File.Move(NextFile.FullName, NewFolder.FullName + "\\" + NextFile.Name);
                File.SetCreationTime(NewFolder.FullName + "\\" + NextFile.Name, DateTime.Now);
                File.SetLastWriteTime(NewFolder.FullName + "\\" + NextFile.Name, DateTime.Now);
                Console.WriteLine(NextFile.Name);
            }

            //TheFolder.Delete();
            //NewFolder.MoveTo(@"E:\MP3");

        }

       

    }
}
