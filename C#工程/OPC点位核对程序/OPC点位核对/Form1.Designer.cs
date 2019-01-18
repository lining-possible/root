namespace OPC点位核对
{
    partial class Form1
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
            this.buttonConnectOpc = new System.Windows.Forms.Button();
            this.buttonCheckItem = new System.Windows.Forms.Button();
            this.buttonBrowserItem = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCheckItemOutPath = new System.Windows.Forms.TextBox();
            this.textBoxBrowserOutPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxInFile = new System.Windows.Forms.TextBox();
            this.labelState = new System.Windows.Forms.Label();
            this.checkBoxFlat = new System.Windows.Forms.CheckBox();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.comboBoxOpcServerName = new System.Windows.Forms.ComboBox();
            this.comboBoxOpcIP = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonConnectOpc
            // 
            this.buttonConnectOpc.Location = new System.Drawing.Point(12, 12);
            this.buttonConnectOpc.Name = "buttonConnectOpc";
            this.buttonConnectOpc.Size = new System.Drawing.Size(41, 23);
            this.buttonConnectOpc.TabIndex = 0;
            this.buttonConnectOpc.Text = "连接";
            this.buttonConnectOpc.UseVisualStyleBackColor = true;
            this.buttonConnectOpc.Click += new System.EventHandler(this.buttonConnectOpc_Click);
            // 
            // buttonCheckItem
            // 
            this.buttonCheckItem.Location = new System.Drawing.Point(12, 76);
            this.buttonCheckItem.Name = "buttonCheckItem";
            this.buttonCheckItem.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckItem.TabIndex = 1;
            this.buttonCheckItem.Text = "依次检查点位";
            this.buttonCheckItem.UseVisualStyleBackColor = true;
            this.buttonCheckItem.Click += new System.EventHandler(this.buttonCheckItem_Click);
            // 
            // buttonBrowserItem
            // 
            this.buttonBrowserItem.Location = new System.Drawing.Point(12, 116);
            this.buttonBrowserItem.Name = "buttonBrowserItem";
            this.buttonBrowserItem.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowserItem.TabIndex = 2;
            this.buttonBrowserItem.Text = "浏览所有点位";
            this.buttonBrowserItem.UseVisualStyleBackColor = true;
            this.buttonBrowserItem.Click += new System.EventHandler(this.buttonBrowserItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 168);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(517, 278);
            this.treeView1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "OPC IP：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "ServerName：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "输出路径：";
            // 
            // textBoxCheckItemOutPath
            // 
            this.textBoxCheckItemOutPath.Location = new System.Drawing.Point(187, 77);
            this.textBoxCheckItemOutPath.Name = "textBoxCheckItemOutPath";
            this.textBoxCheckItemOutPath.Size = new System.Drawing.Size(342, 21);
            this.textBoxCheckItemOutPath.TabIndex = 9;
            this.textBoxCheckItemOutPath.Text = "D:\\CheckItemResult.txt";
            // 
            // textBoxBrowserOutPath
            // 
            this.textBoxBrowserOutPath.Location = new System.Drawing.Point(84, 141);
            this.textBoxBrowserOutPath.Name = "textBoxBrowserOutPath";
            this.textBoxBrowserOutPath.Size = new System.Drawing.Size(444, 21);
            this.textBoxBrowserOutPath.TabIndex = 11;
            this.textBoxBrowserOutPath.Text = "D:\\BroswerItemResult.txt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "输出路径：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "输入点位(一个点位一行)：";
            // 
            // textBoxInFile
            // 
            this.textBoxInFile.Location = new System.Drawing.Point(187, 52);
            this.textBoxInFile.Name = "textBoxInFile";
            this.textBoxInFile.Size = new System.Drawing.Size(341, 21);
            this.textBoxInFile.TabIndex = 13;
            this.textBoxInFile.Tag = "";
            this.textBoxInFile.Text = "D:\\ItemList.txt";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(12, 449);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(41, 12);
            this.labelState.TabIndex = 14;
            this.labelState.Text = "label6";
            // 
            // checkBoxFlat
            // 
            this.checkBoxFlat.AutoSize = true;
            this.checkBoxFlat.Location = new System.Drawing.Point(93, 119);
            this.checkBoxFlat.Name = "checkBoxFlat";
            this.checkBoxFlat.Size = new System.Drawing.Size(264, 16);
            this.checkBoxFlat.TabIndex = 15;
            this.checkBoxFlat.Text = "是否采用flat方式查询(艾默生的暂时不支持)";
            this.checkBoxFlat.UseVisualStyleBackColor = true;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(69, 12);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(41, 23);
            this.buttonDisconnect.TabIndex = 16;
            this.buttonDisconnect.Text = "断开";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // comboBoxOpcServerName
            // 
            this.comboBoxOpcServerName.FormattingEnabled = true;
            this.comboBoxOpcServerName.Location = new System.Drawing.Point(358, 14);
            this.comboBoxOpcServerName.Name = "comboBoxOpcServerName";
            this.comboBoxOpcServerName.Size = new System.Drawing.Size(170, 20);
            this.comboBoxOpcServerName.TabIndex = 17;
            // 
            // comboBoxOpcIP
            // 
            this.comboBoxOpcIP.FormattingEnabled = true;
            this.comboBoxOpcIP.Location = new System.Drawing.Point(178, 14);
            this.comboBoxOpcIP.Name = "comboBoxOpcIP";
            this.comboBoxOpcIP.Size = new System.Drawing.Size(106, 20);
            this.comboBoxOpcIP.TabIndex = 18;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(541, 473);
            this.Controls.Add(this.comboBoxOpcIP);
            this.Controls.Add(this.comboBoxOpcServerName);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.checkBoxFlat);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.textBoxInFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxBrowserOutPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCheckItemOutPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buttonBrowserItem);
            this.Controls.Add(this.buttonCheckItem);
            this.Controls.Add(this.buttonConnectOpc);
            this.Name = "Form1";
            this.Text = "OPC点位检查";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnectOpc;
        private System.Windows.Forms.Button buttonCheckItem;
        private System.Windows.Forms.Button buttonBrowserItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCheckItemOutPath;
        private System.Windows.Forms.TextBox textBoxBrowserOutPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxInFile;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.CheckBox checkBoxFlat;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.ComboBox comboBoxOpcServerName;
        private System.Windows.Forms.ComboBox comboBoxOpcIP;
    }
}

