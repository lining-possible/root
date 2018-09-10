namespace OPC_DC_Forms
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
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSysRead = new System.Windows.Forms.Button();
            this.labelState = new System.Windows.Forms.Label();
            this.textBoxB1_1 = new System.Windows.Forms.TextBox();
            this.textBoxA0 = new System.Windows.Forms.TextBox();
            this.textBoxA1 = new System.Windows.Forms.TextBox();
            this.textBoxA2 = new System.Windows.Forms.TextBox();
            this.textBoxA3 = new System.Windows.Forms.TextBox();
            this.textBoxA4 = new System.Windows.Forms.TextBox();
            this.textBoxB1_2 = new System.Windows.Forms.TextBox();
            this.textBoxB1_3 = new System.Windows.Forms.TextBox();
            this.textBoxB1_4 = new System.Windows.Forms.TextBox();
            this.textBoxB1_5 = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(2, 12);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(100, 21);
            this.textBox_IP.TabIndex = 2;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(4, 44);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(48, 23);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSysRead
            // 
            this.buttonSysRead.Location = new System.Drawing.Point(137, 44);
            this.buttonSysRead.Name = "buttonSysRead";
            this.buttonSysRead.Size = new System.Drawing.Size(75, 23);
            this.buttonSysRead.TabIndex = 4;
            this.buttonSysRead.Text = "同步读取";
            this.buttonSysRead.UseVisualStyleBackColor = true;
            this.buttonSysRead.Click += new System.EventHandler(this.buttonSysRead_Click_1);
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(12, 219);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(29, 12);
            this.labelState.TabIndex = 6;
            this.labelState.Text = "状态";
            // 
            // textBoxB1_1
            // 
            this.textBoxB1_1.Location = new System.Drawing.Point(137, 73);
            this.textBoxB1_1.Name = "textBoxB1_1";
            this.textBoxB1_1.Size = new System.Drawing.Size(100, 21);
            this.textBoxB1_1.TabIndex = 7;
            // 
            // textBoxA0
            // 
            this.textBoxA0.Location = new System.Drawing.Point(4, 73);
            this.textBoxA0.Name = "textBoxA0";
            this.textBoxA0.Size = new System.Drawing.Size(100, 21);
            this.textBoxA0.TabIndex = 9;
            // 
            // textBoxA1
            // 
            this.textBoxA1.Location = new System.Drawing.Point(4, 98);
            this.textBoxA1.Name = "textBoxA1";
            this.textBoxA1.Size = new System.Drawing.Size(100, 21);
            this.textBoxA1.TabIndex = 10;
            // 
            // textBoxA2
            // 
            this.textBoxA2.Location = new System.Drawing.Point(4, 126);
            this.textBoxA2.Name = "textBoxA2";
            this.textBoxA2.Size = new System.Drawing.Size(100, 21);
            this.textBoxA2.TabIndex = 11;
            // 
            // textBoxA3
            // 
            this.textBoxA3.Location = new System.Drawing.Point(4, 154);
            this.textBoxA3.Name = "textBoxA3";
            this.textBoxA3.Size = new System.Drawing.Size(100, 21);
            this.textBoxA3.TabIndex = 12;
            // 
            // textBoxA4
            // 
            this.textBoxA4.Location = new System.Drawing.Point(4, 182);
            this.textBoxA4.Name = "textBoxA4";
            this.textBoxA4.Size = new System.Drawing.Size(100, 21);
            this.textBoxA4.TabIndex = 13;
            // 
            // textBoxB1_2
            // 
            this.textBoxB1_2.Location = new System.Drawing.Point(137, 100);
            this.textBoxB1_2.Name = "textBoxB1_2";
            this.textBoxB1_2.Size = new System.Drawing.Size(100, 21);
            this.textBoxB1_2.TabIndex = 14;
            // 
            // textBoxB1_3
            // 
            this.textBoxB1_3.Location = new System.Drawing.Point(137, 128);
            this.textBoxB1_3.Name = "textBoxB1_3";
            this.textBoxB1_3.Size = new System.Drawing.Size(100, 21);
            this.textBoxB1_3.TabIndex = 15;
            // 
            // textBoxB1_4
            // 
            this.textBoxB1_4.Location = new System.Drawing.Point(137, 155);
            this.textBoxB1_4.Name = "textBoxB1_4";
            this.textBoxB1_4.Size = new System.Drawing.Size(100, 21);
            this.textBoxB1_4.TabIndex = 16;
            // 
            // textBoxB1_5
            // 
            this.textBoxB1_5.Location = new System.Drawing.Point(137, 182);
            this.textBoxB1_5.Name = "textBoxB1_5";
            this.textBoxB1_5.Size = new System.Drawing.Size(100, 21);
            this.textBoxB1_5.TabIndex = 17;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(108, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(184, 21);
            this.textBoxName.TabIndex = 18;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(14, 234);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(265, 127);
            this.textBoxResult.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "监测";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(218, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "浏览所有点位";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(275, 78);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 373);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxB1_5);
            this.Controls.Add(this.textBoxB1_4);
            this.Controls.Add(this.textBoxB1_3);
            this.Controls.Add(this.textBoxB1_2);
            this.Controls.Add(this.textBoxA4);
            this.Controls.Add(this.textBoxA3);
            this.Controls.Add(this.textBoxA2);
            this.Controls.Add(this.textBoxA1);
            this.Controls.Add(this.textBoxA0);
            this.Controls.Add(this.textBoxB1_1);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.buttonSysRead);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBox_IP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSysRead;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.TextBox textBoxB1_1;
        private System.Windows.Forms.TextBox textBoxA0;
        private System.Windows.Forms.TextBox textBoxA1;
        private System.Windows.Forms.TextBox textBoxA2;
        private System.Windows.Forms.TextBox textBoxA3;
        private System.Windows.Forms.TextBox textBoxA4;
        private System.Windows.Forms.TextBox textBoxB1_2;
        private System.Windows.Forms.TextBox textBoxB1_3;
        private System.Windows.Forms.TextBox textBoxB1_4;
        private System.Windows.Forms.TextBox textBoxB1_5;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView1;
    }
}

