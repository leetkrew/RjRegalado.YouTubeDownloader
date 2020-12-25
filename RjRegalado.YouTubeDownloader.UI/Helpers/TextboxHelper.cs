using System;
using System.Linq;
using System.Windows.Forms;

namespace RjRegalado.YouTubeDownloader.UI.Helpers
{
    public static class TextboxHelper
    {
        public delegate object PopulateTextboxDelegate(ref TextBox tb, string text, bool clear = false);

        public static object PopulateTextbox(ref TextBox tb, string text, bool clear = false)
        {
            tb.Enabled = true;
            tb.ReadOnly = true;

            if (clear)
            {
                tb.Text = "";
            }

            var lastLine = tb.Text.Split('\n').Last();
            if (!lastLine.EndsWith(text))
            {
                //tb.Text += "\r\n" + text;
                tb.Text += string.Format("\r\n[{0}] {1}", DateTime.Now.ToShortTimeString(), text);
                tb.SelectionStart = tb.Text.Length;
                tb.ScrollToCaret();
                tb.Refresh();
            }
            return null;
        }
    }
}
