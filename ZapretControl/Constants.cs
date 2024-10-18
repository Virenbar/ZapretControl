using System;
using System.IO;

namespace ZapretControl
{
    internal static class Constants
    {
        private const string ConfigName = "Config.xml";

        public static string ConfigPath => Path.Combine(StartupPath, ConfigName);

        #region StartupPath
        /*
        .NET 6+ uses TEMP directory for packed executable
        Application.StartupPath - Real executable path
        Environment.ProcessPath - Packed executable path
        */

#if NET6_0_OR_GREATER
        public static string StartupPath => Path.GetDirectoryName(Environment.ProcessPath);
#else
        public static string StartupPath => Application.StartupPath;
#endif
        #endregion StartupPath
    }
}