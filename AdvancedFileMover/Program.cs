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
                    IOHelper.CopyFile(filePath,targetLocation,null);
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
