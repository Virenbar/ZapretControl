using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZapretControl.Extensions;
using ZapretControl.Forms;
using ZapretControl.Locales;
using ZapretControl.Model;
using ZapretControl.Properties;

namespace ZapretControl
{
    public partial class FormMain : Form
    {
        private readonly List<(RadioButton Button, Script Script)> RBSripts = new();
        private readonly ControlSettings Settings = Config.Current;

        public FormMain()
        {
            InitializeComponent();
            this.BindSettings();
            Icon = Resources.icon;
            Localize();

            var scripts = Directory.EnumerateFiles(Constants.StartupPath, "*.bat", SearchOption.AllDirectories)
                .Where(S => !(S.Contains("service") || S.Contains("check") || S.Contains("switch")))
                .OrderBy(S => S.Length).ThenBy(S => S)
                .Select(S => new FileInfo(S))
                .ToList();
            Settings.ZapretPath = Directory.EnumerateFiles(Constants.StartupPath, "winws.exe", SearchOption.AllDirectories).FirstOrDefault();
            Settings.ZapretDirectory = scripts.FirstOrDefault()?.DirectoryName;
            BS_ControlSettings.DataSource = Settings;

            FLP_Scripts.SuspendLayout();
            FLP_Scripts.Controls.Clear();
            foreach (var script in scripts)
            {
                var Script = new Script
                {
                    Name = script.Name.Replace(script.Extension, ""),
                    Path = script.FullName
                };
                var RB = new RadioButton()
                {
                    Text = Script.Name,
                    Tag = Script,
                    AutoSize = true
                };
                RBSripts.Add((RB, Script));
                FLP_Scripts.Controls.Add(RB);
            }
            FLP_Scripts.ResumeLayout();

            RefreshUI();
            StopZapret();
            if (string.IsNullOrEmpty(Settings.ZapretPath) || string.IsNullOrEmpty(Settings.ZapretDirectory))
            {
                UIState(false);
                MI_Start.Enabled = false;
                MI_Stop.Enabled = false;
                B_Close.Enabled = true;
                return;
            }

            if (RBSripts.FirstOrDefault(X => X.Script.Name == Settings.ScriptName).Button is RadioButton button)
            {
                button.Checked = true;
            }
            else
            {
                RBSripts.First().Button.Checked = true;
            }
            if (Settings.AutostartControl) { StartZapret(); }
        }

        private void CloseControl()
        {
            ZapretProcess.Stop();
            TrayControl.Visible = false;
            TrayControl.Icon = null;
            TrayControl.Dispose();
            if (Settings.StopDriver)
            {
                ZapretProcess.StopDriver();
            }
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Settings.ZapretPath))
            {
                this.ShowError(Strings.NoBinary);
                return;
            }
            if (string.IsNullOrEmpty(Settings.ZapretDirectory))
            {
                this.ShowError(Strings.NoScripts);
            }
        }

        private void Localize()
        {
            MI_Settings.Text = Strings.Settings;
            MI_About.Text = Strings.About;
            GB_Scripts.Text = Strings.Scripts;
            B_Restart.Text = Strings.Restart;
            B_Start.Text = Strings.Start;
            B_Close.Text = Strings.Close;

            MI_Start.Text = Strings.Start;
            MI_Stop.Text = Strings.Stop;
            MI_Show.Text = Strings.Show;
            MI_Close.Text = Strings.Close;

            MI_Service.Text = Strings.Service;
            MI_OpenList.Text = Strings.OpenList;
            MI_SwitchIP.Text = Strings.SwitchIPSet;
        }

        private void RefreshPath()
        {
            var script = RBSripts.First(X => X.Button.Checked).Script;
            Settings.ScriptName = script.Name;
            Settings.ScriptPath = script.Path;
        }

        private void RefreshUI()
        {
            B_Restart.Enabled = ZapretProcess.IsRunning;
        }

        private void ShowControl()
        {
            Show();
            Activate();
        }

        private void StartZapret()
        {
            B_Start.Text = Strings.Stop;
            B_Start.Image = Resources.winws_red;
            MI_Start.Enabled = false;
            MI_Stop.Enabled = true;
            TrayControl.Icon = Resources.icon_green;
            Icon = Resources.icon_green;
            RefreshPath();
            ZapretProcess.Start();
            RefreshUI();
        }

        private void StopZapret()
        {
            B_Start.Text = Strings.Start;
            B_Start.Image = Resources.winws_green;
            MI_Start.Enabled = true;
            MI_Stop.Enabled = false;
            TrayControl.Icon = Resources.icon_red;
            Icon = Resources.icon_red;
            ZapretProcess.Stop();
            RefreshUI();
        }

        private void UIState(bool state)
        {
            MI_Settings.Enabled = state;
            MI_About.Enabled = state;
            B_Start.Enabled = state;
            B_Close.Enabled = state;
        }

        #region UIEvents

        private void B_Close_Click(object sender, EventArgs e) => CloseControl();

        private async void B_Restart_Click(object sender, EventArgs e)
        {
            UIState(false);
            StopZapret();
            await Task.Delay(500);
            StartZapret();
            UIState(true);
        }

        private void B_Start_Click(object sender, EventArgs e)
        {
            UIState(false);
            if (ZapretProcess.IsRunning) { StopZapret(); } else { StartZapret(); }
            UIState(true);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) { return; }
            e.Cancel = true;
            Visible = false;
        }

        private void MI_About_Click(object sender, EventArgs e)
        {
            var F = new FormAbout();
            F.ShowDialog(this);
        }

        private void MI_Settings_Click(object sender, EventArgs e)
        {
            using var F = new FormSettings();
            F.ShowDialog(this);
        }

        #region Service

        private void MI_OpenList_Click(object sender, EventArgs e)
        {
            var List = Directory.EnumerateFiles(Constants.StartupPath, "list-general.txt", SearchOption.AllDirectories).FirstOrDefault();
            if (List is null) return;

            Process.Start(new ProcessStartInfo(List) { UseShellExecute = true });
        }

        private async void MI_SwitchIP_Click(object sender, EventArgs e)
        {
            MI_SwitchIP.Enabled = false;
            await ServiceProcess.Switch();
            MI_SwitchIP.Enabled = true;
        }

        #endregion Service

        #region Tray

        private void MI_Close_Click(object sender, EventArgs e) => CloseControl();

        private void MI_Show_Click(object sender, EventArgs e) => ShowControl();

        private void MI_Start_Click(object sender, EventArgs e) => StartZapret();

        private void MI_Stop_Click(object sender, EventArgs e) => StopZapret();

        private void TrayControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ShowControl(); }
        }

        #endregion Tray

        #endregion UIEvents
    }
}