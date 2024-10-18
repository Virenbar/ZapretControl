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

            CB_Minimized.Text = Strings.SettingsMinimized;
            CB_Autostart.Text = Strings.SettingsAutostart;
            CB_StopDriver.Text = Strings.SettingsStop;
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

            Close();
        }
    }
}