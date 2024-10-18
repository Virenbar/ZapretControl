using System.Diagnostics;
using System.Windows.Forms;
using ZapretControl.Extensions;

namespace ZapretControl
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            this.BindSettings();
            L_Version.Text = $"v{Application.ProductVersion}";
        }

        private static void OpenURL(string url) => Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

        private void LL_Control_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LL_Control.LinkVisited = true;
            OpenURL("https://github.com/Virenbar/ZapretControl");
        }

        private void LL_Icons_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LL_Icons.LinkVisited = true;
            OpenURL("https://icons8.com");
        }

        private void LL_WinDivert_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LL_WinDivert.LinkVisited = true;
            OpenURL("https://github.com/basil00/Divert");
        }

        private void LL_zapret_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LL_zapret.LinkVisited = true;
            OpenURL("https://github.com/bol-van/zapret");
        }

        private void LL_zapret_scripts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LL_zapret_scripts.LinkVisited = true;
            OpenURL("https://github.com/Flowseal/zapret-discord-youtube");
        }
    }
}