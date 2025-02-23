using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace ZapretControl
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
#if DEBUG
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
#endif

            using Mutex mutex = new(true, "ZapretControl", out var created);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!created)
            {
                MessageBox.Show($"Another instance of {Application.ProductName} is already running.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Config.Load();
            var Form = new FormMain();
            if (!Config.Current.LaunchMinimized) { Form.Show(); }

            Application.ApplicationExit += Application_ApplicationExit;
            Application.Run();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Config.Save();
        }
    }
}