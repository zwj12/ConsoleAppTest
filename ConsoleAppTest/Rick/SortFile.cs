using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleAppTest.Rick
{
    public class SortFile
    {
        public static void SortFilesByName()
        {
            DirectoryInfo TheFolder = new DirectoryInfo(@"E:\MP3");
            DirectoryInfo NewFolder = Directory.CreateDirectory(@"E:\MP3New");
            foreach (var NextFile in TheFolder.GetFiles().OrderBy(f=>f.Name))
            {
                File.Move(NextFile.FullName, NewFolder.FullName + "\\" + NextFile.Name);
                File.SetCreationTime(NewFolder.FullName + "\\" + NextFile.Name, DateTime.Now);
                File.SetLastWriteTime(NewFolder.FullName + "\\" + NextFile.Name, DateTime.Now);
                Console.WriteLine(NextFile.Name);
            }
            TheFolder.Delete();
            NewFolder.MoveTo(@"E:\MP3");

        }

        

    }
}
