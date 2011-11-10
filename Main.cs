using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            if(bmp == null)
                return;

            using(bmp)
            {
                var xml = Imgur.Post(bmp);
                var document = new XmlDocument();
                document.LoadXml(xml);
                var node = document.SelectSingleNode("//original");

                if(node != null)
                {
                    var url = node.InnerText;
                    Clipboard.SetText(url);
                    this.icon.ShowBalloonTip(2000, "Screenshot Saved.", url, ToolTipIcon.Info);
                }
                
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
