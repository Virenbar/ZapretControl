using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZapretControl.Model;

namespace ZapretControl
{
    internal static class ZapretProcess
    {
        private static readonly ControlSettings Settings = Config.Current;
        private static Process Zapret;
        public static bool IsRunning => Zapret != null;

        public static async Task Restart()
        {
            Stop();
            await Task.Delay(5 * 1000);
            Start();
        }

        public static void Start()
        {
            if (IsRunning) { return; }

            var zapret = new FileInfo(Settings.ZapretPath);
            var script = File.ReadAllText(Settings.ScriptPath);
            var arguments = Regex.Match(script, "--.*", RegexOptions.Singleline).Value;
            arguments = arguments.Replace("%BIN%", $@"{zapret.DirectoryName}\");

            var StartInfo = new ProcessStartInfo
            {
                FileName = zapret.FullName,
                Arguments = arguments,
                WorkingDirectory = Settings.ZapretDirectory,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            Zapret = new Process
            {
                StartInfo = StartInfo,
                EnableRaisingEvents = true
            };
            Zapret.OutputDataReceived += Zapret_OutputDataReceived;
            Zapret.ErrorDataReceived += Zapret_ErrorDataReceived;
            Zapret.Start();
            Zapret.BeginOutputReadLine();
            Zapret.BeginErrorReadLine();
        }

        public static void Stop()
        {
            if (!IsRunning) { return; }
            Zapret.Kill();
            Zapret = null;
        }

        public static void StopDriver()
        {
            var devices = ServiceController.GetDevices();
            var driver = devices.FirstOrDefault(S => S.ServiceName.Contains("WinDivert"));
            if (driver is not null && driver.CanStop)
            {
                driver.Stop();
            }
        }

        private static void Zapret_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine(e.Data);
        }

        private static void Zapret_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine(e.Data);
        }
    }
}