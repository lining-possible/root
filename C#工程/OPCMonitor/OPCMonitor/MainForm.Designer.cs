namespace WHChem.OPCMonitor
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelConncetDBResult = new System.Windows.Forms.Label();
            this.labelConncetOPCResult = new System.Windows.Forms.Label();
            this.labelCreateGroupResult = new System.Windows.Forms.Label();
            this.labelGetFireOPCVlauesResult = new System.Windows.Forms.Label();
            this.labelAlarmResult = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.configMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.msg = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnStartDebug = new System.Windows.Forms.Button();
            this.btnStopDebug = new System.Windows.Forms.Button();
            this.btnClearInfo = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelConncetDBResult
            // 
            this.labelConncetDBResult.AutoSize = true;
            this.labelConncetDBResult.Location = new System.Drawing.Point(12, 56);
            this.labelConncetDBResult.Name = "labelConncetDBResult";
            this.labelConncetDBResult.Size = new System.Drawing.Size(0, 12);
            this.labelConncetDBResult.TabIndex = 4;
            // 
            // labelConncetOPCResult
            // 
            this.labelConncetOPCResult.AutoSize = true;
            this.labelConncetOPCResult.Location = new System.Drawing.Point(12, 82);
            this.labelConncetOPCResult.Name = "labelConncetOPCResult";
            this.labelConncetOPCResult.Size = new System.Drawing.Size(0, 12);
            this.labelConncetOPCResult.TabIndex = 5;
            // 
            // labelCreateGroupResult
            // 
            this.labelCreateGroupResult.AutoSize = true;
            this.labelCreateGroupResult.Location = new System.Drawing.Point(12, 107);
            this.labelCreateGroupResult.Name = "labelCreateGroupResult";
            this.labelCreateGroupResult.Size = new System.Drawing.Size(0, 12);
            this.labelCreateGroupResult.TabIndex = 6;
            // 
            // labelGetFireOPCVlauesResult
            // 
            this.labelGetFireOPCVlauesResult.AutoSize = true;
            this.labelGetFireOPCVlauesResult.Location = new System.Drawing.Point(12, 130);
            this.labelGetFireOPCVlauesResult.Name = "labelGetFireOPCVlauesResult";
            this.labelGetFireOPCVlauesResult.Size = new System.Drawing.Size(0, 12);
            this.labelGetFireOPCVlauesResult.TabIndex = 8;
            // 
            // labelAlarmResult
            // 
            this.labelAlarmResult.AutoSize = true;
            this.labelAlarmResult.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAlarmResult.ForeColor = System.Drawing.Color.Red;
            this.labelAlarmResult.Location = new System.Drawing.Point(12, 156);
            this.labelAlarmResult.Name = "labelAlarmResult";
            this.labelAlarmResult.Size = new System.Drawing.Size(0, 20);
            this.labelAlarmResult.TabIndex = 10;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(676, 24);
            this.menuStrip.TabIndex = 13;
            this.menuStrip.Text = "menuStrip";
            // 
            // configMenu
            // 
            this.configMenu.Name = "configMenu";
            this.configMenu.Size = new System.Drawing.Size(41, 20);
            this.configMenu.Text = "配置";
            this.configMenu.Click += new System.EventHandler(this.configMenu_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(41, 20);
            this.helpMenu.Text = "帮助";
            this.helpMenu.Click += new System.EventHandler(this.helpMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 14;
            // 
            // msg
            // 
            this.msg.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.msg.Location = new System.Drawing.Point(15, 59);
            this.msg.Multiline = true;
            this.msg.Name = "msg";
            this.msg.ReadOnly = true;
            this.msg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.msg.Size = new System.Drawing.Size(643, 320);
            this.msg.TabIndex = 15;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnStartDebug
            // 
            this.btnStartDebug.Location = new System.Drawing.Point(15, 30);
            this.btnStartDebug.Name = "btnStartDebug";
            this.btnStartDebug.Size = new System.Drawing.Size(91, 23);
            this.btnStartDebug.TabIndex = 16;
            this.btnStartDebug.Text = "启动调试模式";
            this.btnStartDebug.UseVisualStyleBackColor = true;
            this.btnStartDebug.Click += new System.EventHandler(this.btnStartDebug_Click);
            // 
            // btnStopDebug
            // 
            this.btnStopDebug.Location = new System.Drawing.Point(129, 30);
            this.btnStopDebug.Name = "btnStopDebug";
            this.btnStopDebug.Size = new System.Drawing.Size(91, 23);
            this.btnStopDebug.TabIndex = 17;
            this.btnStopDebug.Text = "停止调试模式";
            this.btnStopDebug.UseVisualStyleBackColor = true;
            this.btnStopDebug.Click += new System.EventHandler(this.btnStopDebug_Click);
            // 
            // btnClearInfo
            // 
            this.btnClearInfo.Location = new System.Drawing.Point(246, 30);
            this.btnClearInfo.Name = "btnClearInfo";
            this.btnClearInfo.Size = new System.Drawing.Size(91, 23);
            this.btnClearInfo.TabIndex = 18;
            this.btnClearInfo.Text = "清空调试信息";
            this.btnClearInfo.UseVisualStyleBackColor = true;
            this.btnClearInfo.Click += new System.EventHandler(this.btnClearInfo_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "OPC服务器监控";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(676, 390);
            this.Controls.Add(this.btnClearInfo);
            this.Controls.Add(this.btnStopDebug);
            this.Controls.Add(this.btnStartDebug);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAlarmResult);
            this.Controls.Add(this.labelGetFireOPCVlauesResult);
            this.Controls.Add(this.labelCreateGroupResult);
            this.Controls.Add(this.labelConncetOPCResult);
            this.Controls.Add(this.labelConncetDBResult);
            this.Controls.Add(this.menuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OPC服务器监控程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConncetDBResult;
        private System.Windows.Forms.Label labelConncetOPCResult;
        private System.Windows.Forms.Label labelCreateGroupResult;
        private System.Windows.Forms.Label labelGetFireOPCVlauesResult;
        private System.Windows.Forms.Label labelAlarmResult;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem configMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox msg;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnStartDebug;
        private System.Windows.Forms.Button btnStopDebug;
        private System.Windows.Forms.Button btnClearInfo;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

