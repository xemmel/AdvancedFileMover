using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFileMover.Helpers
{
    public class ConfigurationHelper
    {
        public static string GetKey(string keyName)
        {
            string output = ConfigurationManager.AppSettings[keyName];
            return output;
        }
    }
}
