using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WHChem.OPCMonitor
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            this.richTextBox.Text = @"【功能说明】
   程序启动后会自动根据配置文件信息进行连接，每隔固定时间间隔读取点位值，发现连接断开后会自动重连，多次连接失败或读取失败以及连接恢复和读取恢复后会发送短信提醒，主窗体最小化后会入驻系统托盘图标，单击还原，关闭前会弹出确认操作窗口，全程记录日志。
主窗体
启动调试模式：在主窗体下方文本区域实时输出调试信息
停止调试模式：停止向主窗体下方文本区域输出调试信息
清空调试信息：将主窗体下方文本区域调试信息清空
注意：
1.是否启用调试模式，仅影响是否输出到文本区域，系统始终会将运行信息记录到日志文件
2.避免长时间使用调试模式，否则会向文本区域加入大量文本信息，占用服务器资源偏高。

【配置说明】
配置文件为程序同目录下的OPCMoniter.exe.config。
常用的配置通过菜单“配置”打开配置窗体进行查看和修改。
不常用的配置可直接用记事本打开程序目录下的修改，重要的参数有以下几个：
OPCServerIPList：OPC服务器IP列表，多台服务器用逗号间隔
UseSMSFlag ：true 启用短信通知， false 停用短信通知，默认为true
MinAlertCount：发送通知起始值，初始值为1
MaxAlertCount：发送通知结束值，初始值为3
SMSNoList：短信通知用户手机号列表，多个用户用逗号间隔



【短信通知策略】
程序启动，发送一次短信提醒。
程序退出，发送一次短信提醒。
连接服务器失败，从第MinAlertCount次发送首条，共发送MaxAlertCount-MinAlertCount+1条，例如MinAlertCount设定为1，MaxAlertCount设定为3，则从第一次失败发送第一条短信，一共发送3条短信，服务器连接恢复，发送一条短信提醒。

烟台与宁波两地各设一个监控点位，分别进行监控和处理。
点位值无效，发送一次短信提醒。
点位值从无效变有效，发送一次短信提醒
点位值读取失败，发送短信策略与连接服务器失败类似，短信内容不同。
";
        }
    }
}
