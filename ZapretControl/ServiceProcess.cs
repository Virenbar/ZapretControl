using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ZapretControl.Model;

namespace ZapretControl
{
    internal static class ServiceProcess
    {
        private const string IPSetMenu = "5";
        private const int OutputTimeout = 10_000;
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
                var match = WaitForMatch(IPSetRegex);
                StopService();
                return match?.Groups["mode"].Value;
            });
        }

        public static Task SwitchIPSet()
        {
            return Task.Run(() =>
            {
                StartService();
                WaitForMatch(IPSetRegex);
                Buffer.Clear();
                Service.StandardInput.WriteLine(IPSetMenu);
                WaitForBuffer(1);
                //Service.StandardInput.WriteLine("0");
                StopService();
            });
        }

        private static Match MatchInBuffer(Regex regex)
        {
            var buffer = Buffer.ToList();
            foreach (var line in buffer)
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    return match;
                }
            }
            return null;
        }

        private static void WaitForBuffer(int count)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (watch.Elapsed.TotalMilliseconds < OutputTimeout)
            {
                Thread.Sleep(250);
                var buffer = Buffer.ToList();
                if (buffer.Count >= count)
                {
                    return;
                }
            }
        }

        private static Match WaitForMatch(Regex regex)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (watch.Elapsed.TotalMilliseconds < OutputTimeout)
            {
                Thread.Sleep(250);
                if (MatchInBuffer(regex) is Match match)
                {
                    return match;
                }
            }
            return null;
        }

        #region Service

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

        #endregion Service
    }
}