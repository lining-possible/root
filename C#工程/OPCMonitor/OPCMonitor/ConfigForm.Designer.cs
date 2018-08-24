namespace WHChem.OPCMonitor
{
    partial class ConfigForm
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
            if (disposing && (components != null))
            {
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
            this.label1 = new System.Windows.Forms.Label();
            this.opcServerIPList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.opcServerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.monitorTagYT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.monitorInterval = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.monitorTagNB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "OPC服务器IP";
            // 
            // opcServerIPList
            // 
            this.opcServerIPList.FormattingEnabled = true;
            this.opcServerIPList.Location = new System.Drawing.Point(154, 12);
            this.opcServerIPList.Name = "opcServerIPList";
            this.opcServerIPList.Size = new System.Drawing.Size(232, 22);
            this.opcServerIPList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "OPC服务器名称";
            // 
            // opcServerName
            // 
            this.opcServerName.Location = new System.Drawing.Point(154, 54);
            this.opcServerName.Name = "opcServerName";
            this.opcServerName.Size = new System.Drawing.Size(232, 23);
            this.opcServerName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "烟台监控点位";
            // 
            // monitorTagYT
            // 
            this.monitorTagYT.Location = new System.Drawing.Point(154, 102);
            this.monitorTagYT.Name = "monitorTagYT";
            this.monitorTagYT.Size = new System.Drawing.Size(232, 23);
            this.monitorTagYT.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "监控时间间隔（秒）";
            // 
            // monitorInterval
            // 
            this.monitorInterval.Location = new System.Drawing.Point(154, 183);
            this.monitorInterval.Name = "monitorInterval";
            this.monitorInterval.Size = new System.Drawing.Size(232, 23);
            this.monitorInterval.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(321, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // monitorTagNB
            // 
            this.monitorTagNB.Location = new System.Drawing.Point(154, 140);
            this.monitorTagNB.Name = "monitorTagNB";
            this.monitorTagNB.Size = new System.Drawing.Size(232, 23);
            this.monitorTagNB.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "宁波监控点位";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 240);
            this.Controls.Add(this.monitorTagNB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.monitorInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.monitorTagYT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.opcServerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.opcServerIPList);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox opcServerIPList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox opcServerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox monitorTagYT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox monitorInterval;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox monitorTagNB;
        private System.Windows.Forms.Label label5;
    }
}