using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPaste.Net.Common
{
    internal static class Constants
    {
        public static string AppDataPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QuickPaste");

        public static string DataStorePath => Path.Combine(AppDataPath, "Data.json");
    }
}
