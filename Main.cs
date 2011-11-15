using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Screenshotify
{
    public partial class Main : Form
    {
        private readonly KeyboardHook _keyboardHook;
        private string lastPath;

        public Main()
        {
            InitializeComponent();
            _keyboardHook = new KeyboardHook();
            _keyboardHook.RegisterHotKey(Screenshotify.ModifierKeys.Alt, Keys.PrintScreen);
            _keyboardHook.RegisterHotKey(Screenshotify.ModifierKeys.None, Keys.PrintScreen);
            _keyboardHook.KeyPressed += keyboardHook_KeyPressed;
        }

        void keyboardHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Bitmap bmp;

            if (e.Modifier == Screenshotify.ModifierKeys.Alt)
                bmp = Screenshotify.Capture.ActiveWindow();
            else
                bmp = Screenshotify.Capture.Desktop();

            SaveScreenShot(bmp);
        }

        private void SaveScreenShot(Bitmap bmp)
        {
            if (bmp == null)
                return;

            using (bmp)
            {
                if (this.SaveToDesktop)
                {
                    var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    var path = Path.Combine(desktop, DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".png");
                    bmp.Save(path, ImageFormat.Png, 100);
                    ScreenshotComplete(path);
                }
                else
                {
                    var xml = Imgur.Post(bmp);
                    var document = new XmlDocument();
                    document.LoadXml(xml);
                    var node = document.SelectSingleNode("//original");

                    if (node == null) 
                        return;

                    var url = node.InnerText;
                    ScreenshotComplete(url);
                }
            }
        }

        private void ScreenshotComplete(string url)
        {
            lastPath = url;
            Clipboard.SetText(url);
            this.icon.ShowBalloonTip(2000, "Screenshot Saved.", url, ToolTipIcon.Info);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuDesktopMode_Click(object sender, EventArgs e)
        {
            this.SaveToDesktop = true;
        }

        private void mnuLinkMode_Click(object sender, EventArgs e)
        {
            this.SaveToDesktop = false;
        }

        private bool _saveToDesktop = true;
        public bool SaveToDesktop
        {
            get { return _saveToDesktop; }
            set
            {
                mnuDesktopMode.Checked = value;
                mnuLinkMode.Checked = !value;
                _saveToDesktop = value;
            }
        }

        private void icon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (lastPath == null) 
                return;

            Process.Start(new ProcessStartInfo(lastPath) {UseShellExecute = true});
        }

        private void icon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) 
                return;

            var bmp = Screenshotify.Capture.Desktop();
            SaveScreenShot(bmp);
        }
    }
}
