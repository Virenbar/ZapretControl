using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ZapretControl.Model;

namespace ZapretControl
{
    internal static class ServiceProcess
    {
        private const string IPSetMenu = "5";
        private static readonly List<string> Buffer = new();
        private static readonly Regex IPSetRegex = new(@"ipset.*\[(?<mode>\w+)\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly ControlSettings Settings = Config.Current;
        private static Process Service;

        public static bool IsRunning => Service != null;

        public static Task<string> GetCurrentIPSetMode()
        {
            return Task.Run(() =>
            {
                StartService();
                Thread.Sleep(1000);
                StopService();
                return MatchInBuffer(IPSetRegex, "mode");
            });
        }

        public static Task SwitchIPSet()
        {
            return Task.Run(() =>
            {
                StartService();
                Thread.Sleep(1000);
                Service.StandardInput.WriteLine(IPSetMenu);
                Thread.Sleep(1000);
                //Service.StandardInput.WriteLine("0");
                StopService();
            });
        }

        private static string MatchInBuffer(Regex regex, string group)
        {
            foreach (var line in Buffer)
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    return match.Groups[group].Value;
                }
            }
            return null;
        }

        private static void Service_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Buffer.Add(e.Data);
            Debug.WriteLine(e.Data);
        }

        private static void Service_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Buffer.Add(e.Data);
            Debug.WriteLine(e.Data);
        }

        /// <summary>
        /// Starts the service process if it is not already running.
        /// </summary>
        private static void StartService()
        {
            if (IsRunning) { return; }

            Buffer.Clear();
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
        }

        /// <summary>
        /// Stops the service process if it is currently running.
        /// </summary>
        private static void StopService()
        {
            if (!IsRunning) { return; }

            Service.Kill();
            Service.WaitForExit();
            Service = null;
        }
    }
}