namespace Screenshotify
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                this._keyboardHook.KeyPressed -= keyboardHook_KeyPressed;
                this._keyboardHook.Dispose();

                if(components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDesktopMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLinkMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // icon
            // 
            this.icon.ContextMenuStrip = this.menu;
            this.icon.Icon = ((System.Drawing.Icon)(resources.GetObject("icon.Icon")));
            this.icon.Text = "Screenshotify";
            this.icon.Visible = true;
            this.icon.BalloonTipClicked += new System.EventHandler(this.icon_BalloonTipClicked);
            this.icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.icon_MouseClick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDesktopMode,
            this.mnuLinkMode,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.menu.Name = "contextMenuStrip1";
            this.menu.Size = new System.Drawing.Size(152, 76);
            // 
            // mnuDesktopMode
            // 
            this.mnuDesktopMode.Checked = true;
            this.mnuDesktopMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuDesktopMode.Name = "mnuDesktopMode";
            this.mnuDesktopMode.Size = new System.Drawing.Size(151, 22);
            this.mnuDesktopMode.Text = "Desktop Mode";
            this.mnuDesktopMode.Click += new System.EventHandler(this.mnuDesktopMode_Click);
            // 
            // mnuLinkMode
            // 
            this.mnuLinkMode.Name = "mnuLinkMode";
            this.mnuLinkMode.Size = new System.Drawing.Size(151, 22);
            this.mnuLinkMode.Text = "Link Mode";
            this.mnuLinkMode.Click += new System.EventHandler(this.mnuLinkMode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "Main";
            this.Text = "Main";
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon icon;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDesktopMode;
        private System.Windows.Forms.ToolStripMenuItem mnuLinkMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

