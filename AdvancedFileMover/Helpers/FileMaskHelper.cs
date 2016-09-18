using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFileMover.Helpers
{
    public class FileMaskHelper
    {
        public static string StripBasePath(string fullPath, string basePath)
        {
            if (String.IsNullOrWhiteSpace(basePath))
                return fullPath;
            return fullPath.Replace(basePath + @"\", String.Empty);

        }
        public static List<string> SplitFileName(string path)
        {
            string pureFileName = System.IO.Path.GetFileNameWithoutExtension(path);
            List<string> result = pureFileName?.Split('_').ToList();
            return result;
        }

        public static List<string> GetFoldersInPath(string fullPath, bool removeFileName = false, string basePath = null)
        {
            fullPath = StripBasePath(fullPath, basePath);
            List<string> output = fullPath.Split(new string[] {@"\"}, StringSplitOptions.None).ToList();
            if ((output.Count > 0) && (removeFileName))
            {
                output.RemoveLast();
            }
            
            //Remove C: etc
            if ((output.Count > 0) && (output[0].Contains(":")))
            {
                output.RemoveAt(0);
            }
            return output;
        }


        public static string AppendToFileName(string path, string code, bool returnFileNameOnly = false)
        {
            string fullPath = System.IO.Path.GetDirectoryName(path);
            string fileNameWithOutEx = System.IO.Path.GetFileNameWithoutExtension(path);
            string extension = System.IO.Path.GetExtension(path);

            string newFileName = $"{fileNameWithOutEx}_{code}";
            string newFullPath = $"{fullPath}\\{newFileName}{extension}";
            if (returnFileNameOnly)
            {
                return System.IO.Path.GetFileName(newFullPath);
            }
            return newFullPath;
        }

        public static string RemoveCountryCodeFromFileName(string path)
        {
            if (!CountryHelper.FileNameContainsCountryCode(path))
                return path;

            string fullPath = System.IO.Path.GetDirectoryName(path);
            string fileNameWithOutEx = System.IO.Path.GetFileNameWithoutExtension(path);
            string extension = System.IO.Path.GetExtension(path);

            List<string> fileNameParts = SplitFileName(path);
            if ((fileNameParts != null) && (fileNameParts.Count > 1))
            {
                fileNameParts.RemoveLast();
                
            }
            string newFileName = String.Join("_", fileNameParts);

            return $"{fullPath}\\{newFileName}{extension}";
        }

        public static bool FileNameChanged(string path, string newFileName)
        {
            string oldFileName = System.IO.Path.GetFileName(path);
            return (oldFileName.ToLower() != newFileName.ToLower());
        }
    }
}
