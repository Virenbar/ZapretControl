using ZapretControl.Properties;
using System;
using System.Windows.Forms;

namespace ZapretControl.Extensions
{
    internal static class FormExtensions
    {
        public static void BindSettings(this Form form)
        {
            form.DataBindings.Add(new Binding("Font", Settings.Default, "Font", true, DataSourceUpdateMode.OnPropertyChanged));
            form.DataBindings.Add(new Binding("ForeColor", Settings.Default, "ForeColor", true, DataSourceUpdateMode.OnPropertyChanged));
            form.DataBindings.Add(new Binding("BackColor", Settings.Default, "BackColor", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        public static DialogResult ShowError(this Form form, string error)
        {
            return MessageBox.Show(form, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowError(this Form form, Exception exception)
        {
            return MessageBox.Show(form, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowError(this Form form, Exception exception, string caption)
        {
            return MessageBox.Show(form, exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowInfo(this Form form, string text)
        {
            return MessageBox.Show(form, text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowInfo(this Form form, string text, string caption)
        {
            return MessageBox.Show(form, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}