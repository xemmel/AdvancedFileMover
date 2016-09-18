using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedFileMover.Helpers;

namespace AdvancedFileMover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourceLocation = ConfigurationHelper.GetKey("SourceLocation");
                string targetLocation = ConfigurationHelper.GetKey("TargetLocation");
                bool force = false;
                if (args.Length > 0)
                {
                    force = (args[0].ToLower() == "force");

                }

                if ((String.IsNullOrWhiteSpace(sourceLocation)) || (String.IsNullOrWhiteSpace(targetLocation)))
                {
                    throw new ArgumentException($"SourceLocation and/or TargetLocation is required");
                }

                //Load mother Directory
                //var motherDirectory = System.IO.Directory.GetDirectories()

                string[] filePaths = IOHelper.GetAllFilesFromDir(sourceLocation);
                foreach (var filePath in filePaths)
                {
                    Console.WriteLine($"Copying file: '{filePath}'");
                    string targetFileName = null;
                    string newFilePath = filePath;
                    bool fileAlreadyHasCountryName = CountryHelper.FileNameContainsCountryCode(filePath);
                    if (force)
                    {
                        if (fileAlreadyHasCountryName)
                        {
                            //Remove existing countryCode
                            newFilePath = FileMaskHelper.RemoveCountryCodeFromFileName(filePath);
                            fileAlreadyHasCountryName = false;
                        }

                    }
                    if (!fileAlreadyHasCountryName)
                    {
                        //Append a countryName if folder structure conforms!
                        string countryCode = CountryHelper.GetFolderCountryFileName(filePath);
                        if (!string.IsNullOrWhiteSpace(countryCode))
                        {
                            targetFileName = FileMaskHelper.AppendToFileName(newFilePath, countryCode, true);
                            bool fileNameChanged = FileMaskHelper.FileNameChanged(filePath, targetFileName);
                            ConsoleColor defaultColor = Console.ForegroundColor;
                            if (fileNameChanged)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.WriteLine($"Changed filename to '{targetFileName}'");
                            Console.ForegroundColor = defaultColor;
                        }
                    }
 
                    IOHelper.CopyFile(filePath, targetLocation,targetFileName);
                }
                Console.WriteLine("Done...");
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine($"Configuration Error: {Environment.NewLine} '{aex.Message}");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ex.Message}\r\n{ex.InnerException?.Message}");
            }
        }
    }
}
