namespace HostsUpdateTools
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.nico = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmlOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmlBoot = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmlAutoUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmlExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(0, 0);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(221, 94);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_ClickAsync);
            // 
            // nico
            // 
            this.nico.ContextMenuStrip = this.cms;
            this.nico.Icon = ((System.Drawing.Icon)(resources.GetObject("nico.Icon")));
            this.nico.Text = "HOSTS UPDATE";
            this.nico.Visible = true;
            this.nico.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TsmlOpen_MouseDown);
            // 
            // cms
            // 
            this.cms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmlOpen,
            this.toolStripSeparator1,
            this.tsmlBoot,
            this.tsmlAutoUpdate,
            this.toolStripSeparator2,
            this.tsmlExit});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(211, 140);
            // 
            // tsmlOpen
            // 
            this.tsmlOpen.Name = "tsmlOpen";
            this.tsmlOpen.ShowShortcutKeys = false;
            this.tsmlOpen.Size = new System.Drawing.Size(210, 24);
            this.tsmlOpen.Text = "打开";
            this.tsmlOpen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsmlOpen_MouseDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // tsmlBoot
            // 
            this.tsmlBoot.Checked = global::HostsUpdateTools.Properties.Settings.Default.IsBoot;
            this.tsmlBoot.CheckOnClick = true;
            this.tsmlBoot.Name = "tsmlBoot";
            this.tsmlBoot.Size = new System.Drawing.Size(210, 24);
            this.tsmlBoot.Text = "开机启动";
            this.tsmlBoot.CheckedChanged += new System.EventHandler(this.TsmlBoot_CheckedChanged);
            // 
            // tsmlAutoUpdate
            // 
            this.tsmlAutoUpdate.Checked = global::HostsUpdateTools.Properties.Settings.Default.IsAutoUpdate;
            this.tsmlAutoUpdate.CheckOnClick = true;
            this.tsmlAutoUpdate.Name = "tsmlAutoUpdate";
            this.tsmlAutoUpdate.ShowShortcutKeys = false;
            this.tsmlAutoUpdate.Size = new System.Drawing.Size(210, 24);
            this.tsmlAutoUpdate.Text = "自动更新";
            this.tsmlAutoUpdate.CheckedChanged += new System.EventHandler(this.TsmlAutoUpdate_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // tsmlExit
            // 
            this.tsmlExit.Name = "tsmlExit";
            this.tsmlExit.ShowShortcutKeys = false;
            this.tsmlExit.Size = new System.Drawing.Size(210, 24);
            this.tsmlExit.Text = "退出";
            this.tsmlExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsmlExit_MouseDown);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(221, 94);
            this.ContextMenuStrip = this.cms;
            this.Controls.Add(this.btnUpdate);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOSTS UPDATE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.NotifyIcon nico;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmlOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmlBoot;
        private System.Windows.Forms.ToolStripMenuItem tsmlAutoUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmlExit;
        private System.Windows.Forms.Timer timer;
    }
}

