using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using ZapretControl.Model;

namespace ZapretControl
{
    internal static class ServiceProcess
    {
        private static readonly ControlSettings Settings = Config.Current;
        private static Process Service;
        public static bool IsRunning => Service != null;

        public static async Task Switch()
        {
            var StartInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(Settings.ZapretDirectory, "service.bat"),
                Arguments = "admin",
                WorkingDirectory = Settings.ZapretDirectory,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                Verb = "runas"
            };
            Service = new Process
            {
                StartInfo = StartInfo,
                EnableRaisingEvents = true
            };
            Service.OutputDataReceived += Service_OutputDataReceived;
            Service.ErrorDataReceived += Service_ErrorDataReceived;
            Service.Start();
            Service.BeginOutputReadLine();
            Service.BeginErrorReadLine();
            await Task.Delay(1000);
            Service.StandardInput.WriteLine("7");
            await Task.Delay(1000);
            //Service.StandardInput.WriteLine("0");
            Service.Kill();
        }

        private static void Service_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine(e.Data);
        }

        private static void Service_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine(e.Data);
        }
    }
}