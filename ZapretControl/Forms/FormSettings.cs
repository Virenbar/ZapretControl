using System;
using System.Windows.Forms;
using ZapretControl.Extensions;
using ZapretControl.Locales;
using ZapretControl.Model;

namespace ZapretControl.Forms
{
    public partial class FormSettings : Form
    {
        private readonly ControlSettings Settings = Config.Current;

        public FormSettings()
        {
            InitializeComponent();
            this.BindSettings();
            CB_Minimized.Checked = Settings.LaunchMinimized;
            CB_Autostart.Checked = Settings.AutostartControl;
            CB_StopDriver.Checked = Settings.StopDriver;
            //
            var mode = Settings.GameFilterMode;
            CB_TCP.Checked = mode.TCP;
            TB_TCP.Text = mode.TCPRange;
            CB_UDP.Checked = mode.UDP;
            TB_UDP.Text = mode.UDPRange;
            //
            Text = Strings.Settings;
            CB_Minimized.Text = Strings.SettingsMinimized;
            CB_Autostart.Text = Strings.SettingsAutostart;
            CB_StopDriver.Text = Strings.SettingsStop;
            GB_GameFilter.Text = Strings.SettingsGameFilter;
            L_Note.Text = Strings.SettingsGameFilterNote;
            //
            B_OK.Text = Strings.OK;
            B_Cancel.Text = Strings.Cancel;
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            Settings.LaunchMinimized = CB_Minimized.Checked;
            Settings.AutostartControl = CB_Autostart.Checked;
            Settings.StopDriver = CB_StopDriver.Checked;
            var mode = new GameFilterMode();
            // TODO Add regex check
            // https://regex101.com/r/IGp7iB/1
            // private readonly Regex R = new("^(\\d+(?:-\\d+)?(?:,\\d+(?:-\\d+)?)*)$", RegexOptions.Compiled);
            if (!string.IsNullOrWhiteSpace(TB_TCP.Text)) { mode.TCPRange = TB_TCP.Text; }
            mode.TCP = CB_TCP.Checked;
            if (!string.IsNullOrWhiteSpace(CB_UDP.Text)) { mode.UDPRange = CB_UDP.Text; }
            mode.UDP = CB_UDP.Checked;
            Settings.GameFilterMode = mode;

            Close();
        }
    }
}