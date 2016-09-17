using System;
using System.Collections.Generic;
using System.IO;

namespace AdvancedFileMover.Helpers
{
    public class IOHelper
    {
        public static string[] GetAllFilesFromDir(string dir)
        {
            return Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
        }
        public static List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
 
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            


            return files;
        }

        public static Stream GetFileStream(string path)
        {
            Stream fileStream = File.Open(path, FileMode.Open);
            return fileStream;
            
        }



        public static void WriteFileStream(System.IO.Stream inStream, string outputFilePath)
        {
            int bufferSize = 1024 * 1024;

            using (FileStream fileStream = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.SetLength(inStream.Length);
                int bytesRead = -1;
                byte[] bytes = new byte[bufferSize];

                while ((bytesRead = inStream.Read(bytes, 0, bufferSize)) > 0)
                {
                    fileStream.Write(bytes, 0, bytesRead);
                }
            }
        }

        public static void CopyFile(string sourcePath, string targetPath, string altName = null)
        {
            string outFileName = altName ?? System.IO.Path.GetFileName(sourcePath);
            string outputFullPath = $@"{targetPath}\{outFileName}";

            Stream s = GetFileStream(sourcePath);
            WriteFileStream(s,outputFullPath);
        }
    }
}
