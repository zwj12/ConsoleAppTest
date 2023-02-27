using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Zip
{
    internal class ZipHelper
    {
        public void Unpack(string zipPath, string targetDir)
        {
            using (ZipFile z = new ZipFile(zipPath))
            {
                z.ExtractAll(targetDir, ExtractExistingFileAction.OverwriteSilently);
            }
        }

        public void Pack(string targetDir, string targetPath)
        {
            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }

            using (Ionic.Zip.ZipFile zipFile = new Ionic.Zip.ZipFile(targetPath))
            {
                zipFile.UseZip64WhenSaving = Ionic.Zip.Zip64Option.AsNecessary;
                zipFile.AddDirectory(targetDir);

                foreach (var entry in zipFile.Entries.Where(e => e.FileName.EndsWith(".rsstn", StringComparison.OrdinalIgnoreCase) || e.FileName.EndsWith(".rslib")))
                {
                    entry.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
                }

                zipFile.Save();
            }
        }
    }
}
