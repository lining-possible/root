using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WHChem.OPCMonitor
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            try
            {
                //读取配置文件，初始化窗体控件值
                ConfigInfo configInfo = ConfigHelper.GetConfigureInfo();
                string[] ipList = configInfo.OPCServerIPList.Split(',');
                opcServerIPList.DataSource = ipList;
               
                for (int i = 0; i < opcServerIPList.Items.Count; i++)
                {
                    if (opcServerIPList.Items[i] as string == configInfo.OPCServerIP)
                    {
                        opcServerIPList.SelectedIndex = i;
                    }

                }

                opcServerName.Text = configInfo.OPCServerName;
                monitorTagYT.Text = configInfo.MonitorTagYT;
                monitorTagNB.Text = configInfo.MonitorTagNB;
                monitorInterval.Text = configInfo.MonitorInterval.ToString();
              
            }
            catch (Exception ex)
            {

                MessageBox.Show("初始化配置信息出错，请检查配置文件："+ex.Message);
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //数据验证
            if(string.IsNullOrEmpty(opcServerIPList.SelectedValue as string))
            {
                MessageBox.Show("请选择opc服务器ip地址");
                return;
            }

            if (string.IsNullOrEmpty(opcServerName.Text.Trim()))
            {
                MessageBox.Show("请输入opc服务器名称");
                return;
            }

            if (string.IsNullOrEmpty(monitorTagYT.Text.Trim()))
            {
                MessageBox.Show("请输入烟台监控点位名");
                return;
            }

            if (string.IsNullOrEmpty(monitorTagNB.Text.Trim()))
            {
                MessageBox.Show("请输入宁波监控点位名");
                return;
            }

            if (string.IsNullOrEmpty(monitorInterval.Text.Trim()))
            {
                MessageBox.Show("请输入监控时间间隔");
                return;
            }
            int interval=-1;
            bool flag=int.TryParse(monitorInterval.Text.Trim(),out interval);
            if (flag == false || interval<=0)
            {
                MessageBox.Show("监控时间间隔请输入正整数值");
                return;
            }

            //写入配置文件
            ConfigurationManager.AppSettings["OPCServerIP"] = opcServerIPList.SelectedValue as string;
            ConfigurationManager.AppSettings["OPCServerName"] = opcServerName.Text.Trim();
            ConfigurationManager.AppSettings["MonitorTagYT"] = monitorTagYT.Text.Trim();
            ConfigurationManager.AppSettings["MonitorTagNB"] = monitorTagNB.Text.Trim();
            ConfigurationManager.AppSettings["MonitorInterval"] = monitorInterval.Text.Trim();

            //通知父窗体为ok
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
