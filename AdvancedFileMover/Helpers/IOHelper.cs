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
    }
}
