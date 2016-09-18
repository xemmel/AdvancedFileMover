using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFileMover.Helpers
{
    public class CountryTranslation
    {
        public String FolderName { get; set; }
        public String FileName { get; set; }
    }
    public class CountryHelper
    {
        public static List<CountryTranslation> GetCountryTranslations()
        {
            List<CountryTranslation> translations = new List<CountryTranslation>()
            {
                new CountryTranslation()
                {
                    FolderName = "dk2",
                    FileName = "DK"
                },
                new CountryTranslation()
                {
                    FolderName = "all.countries",
                    FileName ="GB"
                },
                new CountryTranslation()
                {
                    FolderName = "fi2",
                    FileName ="FI"
                },
                new CountryTranslation()
                {
                    FolderName = "is2",
                    FileName ="IS"
                },
                new CountryTranslation()
                {
                    FolderName = "no2",
                    FileName ="NO"
                },
                new CountryTranslation()
                {
                    FolderName = "se2",
                    FileName ="SE"
                }
            };
            return translations;
        }

 
        public static bool FileNameContainsCountryCode(string path)
        {
            var fileNameParts = FileMaskHelper.SplitFileName(path);
            List<CountryTranslation> translations = GetCountryTranslations();
            bool result = false;
            if (fileNameParts == null)
                return false;
            foreach (string fileNamePart in fileNameParts)
            {
                if (translations.Select(t => t.FileName).Contains(fileNamePart))
                return true;
            }
            return result;
        }

        public static string GetFolderCountryFileName(string path)
        {
            List<string> folders = FileMaskHelper.GetFoldersInPath(path, true);
            string result = null;
            if (folders == null)
                return null;
            List<CountryTranslation> translations = GetCountryTranslations();
            foreach (string folder in folders)
            {
                var translation = translations.Where(t => t.FolderName.ToLower() == folder.ToLower()).FirstOrDefault();
                if (translation != null)
                {
                    return translation.FileName;
                }

            }
            return result;

        }
    }
}
