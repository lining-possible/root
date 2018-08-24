using log4net;
using OPCAutomation;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace WHChem.OPCMonitor
{
    public partial class MainForm : Form
    {
        #region 变量定义
        //是否启用调试模式，启用则窗体前台会持续输出实时信息
        //默认不开启，调试模式长时间开启会导致显示文本空间内容过多
        private  bool debugFlag = false;
        //Log4j日志服务
        private static readonly ILog LogService = LogManager.GetLogger("MyLog");
        //配置信息
        private ConfigInfo configInfo;
        //组名
        private  readonly  string GROUP_NAME="MONITOR_GROUP";
        //点位质量 192为Good,即成功读取到值
        private readonly string MES_DATA_GOOD_QUALITY = "192"; 
        //连接失败次数
        private int connectfailureCount;
        //读取烟台点位值失败次数
        private int readFailureCountYT;
        //读取宁波点位值失败次数
        private int readFailureCountNB;

        //烟台点位值无效发送短信标识
        private bool sendSMSFlagYT;

        //宁波点位值无效发送短信标识
        private bool sendSMSFlagNB;
      
        ///OPC服务器     
        private OPCServer opcServer;

        //OPC组
        private OPCGroup opcGroup;
        //烟台监控点
        private OPCItem monitorItemYT;
        //宁波监控点
        private OPCItem monitorItemNB;
        //烟台点位名有效
        private bool validTagFlagYT;

        //宁波点位名有效
        private bool validTagFlagNB;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// 窗体初次加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {           
               
                //读取配置文件
                configInfo=ConfigHelper.GetConfigureInfo();
                //发送启动短信通知
                string msgContent = "监控程序启动";
                SendSmsMessage(msgContent);
                WriteMsg(msgContent);

                //初始化客户端
                InitClient();
   

                //设置定时器间隔时间并启动
                timer.Interval = configInfo.MonitorInterval * 1000;
                timer.Start();
            }
            catch (Exception ex)
            {
                LogService.Error(ex.Message, ex);
                WriteMsg("错误：" + ex.Message);
            }
        }
      
        /// <summary>
        /// 初始化连接、创建组以及加入监控点
        /// </summary>
        private void InitClient()
        {
            
            ConnectOPCServer();
            if (opcServer!=null && opcServer.ServerState == (int)OPCServerState.OPCRunning)
            {
                CreateGroup(GROUP_NAME);
                AddTag();
            }
        }


        /// <summary>
        /// 连接服务器
        /// </summary>
        private void ConnectOPCServer()
        {
            //连接服务器
            opcServer = new OPCServer();
            try
            {
                opcServer.Connect(configInfo.OPCServerName, configInfo.OPCServerIP);
                if (opcServer.ServerState == (int)OPCServerState.OPCRunning)
                {
                    WriteMsg("成功连接OPC服务器");
                    //若曾达到起始值，则提醒恢复正常
                    if (connectfailureCount >= configInfo.MinAlertCount)
                    {
                        string smsContent = string.Format("OPC服务器{0}在连接失败{1}次后恢复正常.", configInfo.OPCServerIP,connectfailureCount);
                        SendSmsMessage(smsContent);
                    }
                    //只要任何一次连上服务器，则将报警计数置为0
                    connectfailureCount = 0;
                }
                else
                {

                    ConnectFailureOp(configInfo.OPCServerIP);

                }
            }
            catch(Exception ex)
            {
                LogService.Error(ex.Message, ex);
                ConnectFailureOp(configInfo.OPCServerIP);

            }
        }

        /// <summary>
        /// 创建组
        /// </summary>
        /// <param name="goupName"></param>
        public void CreateGroup(string goupName)
        {
            opcServer.OPCGroups.DefaultGroupIsActive = true;
            opcServer.OPCGroups.DefaultGroupDeadband = 0;


            opcGroup = opcServer.OPCGroups.Add(goupName);
            opcGroup.UpdateRate = 5000;   //更新时间 5秒
            opcGroup.IsActive = true;
            opcGroup.IsSubscribed = true;
            WriteMsg("成功创建组");
        }
        /// <summary>
        /// 添加监控点
        /// </summary>
        /// <param name="tagName"></param>
        public void AddTag()
        {
            try
            {
                monitorItemYT = opcGroup.OPCItems.AddItem(configInfo.MonitorTagYT, 1);
                validTagFlagYT = true;
                if (sendSMSFlagYT == true)
                {
                    string smsContent = string.Format("烟台监控点位值恢复有效.");
                    SendSmsMessage(smsContent);
                   
                }
                sendSMSFlagYT = false;
            }
            catch 
            {
                validTagFlagYT = false;
                WriteMsg("烟台点位名有误，无法监控，请确认");

                if (sendSMSFlagYT == false)
                {
                    string smsContent = string.Format("烟台监控点位值无效.");
                    SendSmsMessage(smsContent);
                    sendSMSFlagYT = true;
                }
            }


            try
            {

                monitorItemNB = opcGroup.OPCItems.AddItem(configInfo.MonitorTagNB, 2);
                validTagFlagNB = true;
                if (sendSMSFlagNB == true)
                {
                    string smsContent = string.Format("宁波监控点位值恢复有效.");
                    SendSmsMessage(smsContent);

                }
                sendSMSFlagNB = false;
              
            }
            catch 
            {
                validTagFlagNB = false;
                WriteMsg("宁波点位名有误，无法监控，请确认");
                if (sendSMSFlagNB == false)
                {
                    string smsContent = string.Format("宁波监控点位值无效.");
                    SendSmsMessage(smsContent);
                    sendSMSFlagNB = true;
                }
            }
           
            WriteMsg("成功添加监控点");
        }






        /// <summary>
        /// 使用同步方法读取烟台监控点位置
        /// </summary>
        public void ReadYTTag()
        {
            
                if (validTagFlagYT)
                {
                    object value, quality, timeStamp;
                    try
                    {
                        monitorItemYT.Read(1, out value, out quality, out timeStamp);
                    }
                    catch (Exception ex)
                    {

                        WriteMsg("读取烟台点位值失败：" + ex.Message);
                        ReadFailureOpYT();
                        return;
                    }

                    if (quality != null && quality.ToString() == MES_DATA_GOOD_QUALITY)
                    {
                        WriteMsg("成功获取烟台点位值：" + value + " 时间：" + DateTime.Parse(timeStamp.ToString()).AddHours(8).ToString("G"));
                        //若曾达到失败起始值，则提醒恢复正常
                        if (readFailureCountYT >= configInfo.MinAlertCount)
                        {
                            string smsContent = string.Format("烟台监控点位值在读取失败{0}次后恢复正常.", readFailureCountYT);
                            SendSmsMessage(smsContent);
                        }
                        //只要任何读到正常值，则将报警计数置为0
                        readFailureCountYT = 0;
                    }
                    else
                    {
                        WriteMsg("获取烟台点位质量属性为Bad：" + quality.ToString());
                        ReadFailureOpYT();

                    }


                }
                else
                {
                    WriteMsg("烟台点位名无效");


                }
        }

        /// <summary>
        /// 使用同步方法读取宁波监控点位置
        /// </summary>
        public void ReadNBTag()
        {

            if (validTagFlagNB)
            {
                object value, quality, timeStamp;
                try
                {
                    monitorItemNB.Read(1, out value, out quality, out timeStamp);
                }
                catch (Exception ex)
                {

                    WriteMsg("读取宁波点位值失败：" + ex.Message);
                    ReadFailureOpNB();
                    return;
                }

                if (quality != null && quality.ToString() == MES_DATA_GOOD_QUALITY)
                {
                    WriteMsg("成功获取宁波点位值：" + value + " 时间：" + DateTime.Parse(timeStamp.ToString()).AddHours(8).ToString("G"));
                    //若曾达到失败起始值，则提醒恢复正常
                    if (readFailureCountNB >= configInfo.MinAlertCount)
                    {
                        string smsContent = string.Format("宁波监控点位在读取失败{0}次后恢复正常.", readFailureCountNB);
                        SendSmsMessage(smsContent);
                    }
                    //只要任何读到正常值，则将报警计数置为0
                    readFailureCountNB = 0;
                }
                else
                {
                    WriteMsg("获取宁波点位质量属性为Bad：" + quality.ToString());
                    ReadFailureOpNB();

                }
            }
            else
            {
                WriteMsg("宁波点位名无效");

            }



        }

     /// <summary>
     /// 关闭窗体
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
     {
         try
         {
             DisconnectOPCServer();
             string msgContent = "监控程序关闭";
             SendSmsMessage(msgContent);
             WriteMsg(msgContent);
         }
         catch (Exception ex)
         {

             LogService.Error(ex.Message, ex);
         }
         

     }

     /// <summary>
     /// 断开连接，清除创建的组
     /// </summary>
     private void DisconnectOPCServer()
     {
         if (opcServer != null)
         {
             if (opcServer.OPCGroups.Count > 0)
             {
                 opcServer.OPCGroups.Remove(GROUP_NAME);
             }
             opcServer.Disconnect(); //断开连接
         }
     } 
        
 
    /// <summary>
    /// 打开配置窗体
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
        private void configMenu_Click(object sender, EventArgs e)
        {
            ConfigForm form = new ConfigForm();
            if(form.ShowDialog()==DialogResult.OK)
            {
                //更改过配置，先断开原连接，后重新连接
                configInfo = ConfigHelper.GetConfigureInfo();
                timer.Interval = configInfo.MonitorInterval * 1000;
                connectfailureCount = 0;
                 DisconnectOPCServer();
                try
                {
                   
                    InitClient();
                }
                catch (Exception ex)
                {
                    WriteMsg("错误：" + ex.Message);
                    LogService.Error(ex.Message, ex);
                }
                
            }
        }

      
        /// <summary>
        /// 错误处理，连接失败时发送短信通知
        /// </summary>
        /// <param name="opcServerIP"></param>
        private void ConnectFailureOp(string opcServerIP)
        {
            connectfailureCount++;
            WriteMsg("连接OPC服务器失败");
            string smsContent = string.Empty;
            if (connectfailureCount >= configInfo.MinAlertCount && connectfailureCount < configInfo.MaxAlertCount)
            {
                //发送短信
                smsContent = string.Format("OPC服务器{0}：第{1}次 连接失败.", opcServerIP, connectfailureCount);
                SendSmsMessage(smsContent);
            }
            else if (connectfailureCount == configInfo.MaxAlertCount)
            {
                smsContent = string.Format("OPC服务器{0}：第{1}次 连接失败.已达到提醒上限值，不再提醒连接失败。恢复连接后再次提醒。", opcServerIP, connectfailureCount);
                SendSmsMessage(smsContent);
            }
            
        }

        /// <summary>
        /// 读取烟台点位失败时发送短信通知
        /// </summary>
        /// <param name="opcServerIP"></param>
        private void ReadFailureOpYT()
        {

            readFailureCountYT++;
            string smsContent = string.Empty;
            if (readFailureCountYT >= configInfo.MinAlertCount && readFailureCountYT < configInfo.MaxAlertCount)
            {
                //发送短信
                smsContent = string.Format("第{0}次读取烟台点位值失败.", readFailureCountYT);
                SendSmsMessage(smsContent);
            }
            else if (readFailureCountYT == configInfo.MaxAlertCount)
            {
                smsContent = string.Format("第{0}次读取烟台点位值失败.已达到提醒上限值，不再提醒。读取正常后再次提醒。", readFailureCountYT);
                SendSmsMessage(smsContent);
            }
            
        }

        /// <summary>
        /// 读取宁波点位失败时发送短信通知
        /// </summary>
        /// <param name="opcServerIP"></param>
        private void ReadFailureOpNB()
        {

            readFailureCountNB++;
            string smsContent = string.Empty;
            if (readFailureCountNB >= configInfo.MinAlertCount && readFailureCountNB < configInfo.MaxAlertCount)
            {
                //发送短信
                smsContent = string.Format("第{0}次读取宁波点位值失败.", readFailureCountNB);
                SendSmsMessage(smsContent);

            }
            else if (readFailureCountNB == configInfo.MaxAlertCount)
            {
                smsContent = string.Format("第{0}次读取宁波点位值失败.已达到提醒上限值，不再提醒。读取正常后再次提醒。", readFailureCountNB);
                SendSmsMessage(smsContent);
            }
            
        }
       

     
        /// <summary>
        /// 输出调试信息至主窗体
        /// </summary>
        /// <param name="msg"></param>
        private void WriteMsg(string msg)
        {
            if (debugFlag == true)
            {
                this.msg.Text = DateTime.Now.ToString("G") + " " + msg + "\r\n" + this.msg.Text;
            }
            LogService.Info(msg);
        }
       /// <summary>
       /// 定时器触发读数据操作
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (opcServer != null && opcServer.ServerState == (int)OPCServerState.OPCRunning)
            {
                ReadYTTag();
                ReadNBTag();
            }
            else
            {
                //若服务器连接为空或者服务器非运行状态，断开重连
                DisconnectOPCServer();
                InitClient();               
            }
           
        }
   

      /// <summary>
      /// 调用短信接口发送错误消息
      /// </summary>
      /// <param name="smsContent">要发送的消息</param>
      public  void SendSmsMessage(string smsContent)
      {
          try
          {
              if (configInfo.UseSMSFlag == true)
              {
                  SMSServiceReference.ServiceSoapClient client = new SMSServiceReference.ServiceSoapClient();
                  var ressult = client.SendSMSOfInterface(configInfo.SMSUser, configInfo.SMSPassword, configInfo.SMSNoList, smsContent); //调用短信webservice发送短信

                  if (ressult == 1)
                  {
                      LogService.Info("发送短信成功:" + smsContent);
                  }
                  else
                  {
                      LogService.Info("发送短信失败:" + smsContent);
                  }
              }
          }
          catch (Exception ex)
          {
              LogService.Error("发送短信出错:" + ex.Message);
          }

      }

      private void btnStartDebug_Click(object sender, EventArgs e)
      {
          debugFlag = true;
      }

      private void btnStopDebug_Click(object sender, EventArgs e)
      {
          debugFlag = false;
      }

      private void btnClearInfo_Click(object sender, EventArgs e)
      {
          this.msg.Text = string.Empty;
      }

      private void notifyIcon_Click(object sender, EventArgs e)
      {
          if (this.WindowState == FormWindowState.Minimized)
          {
              this.Show();
              this.WindowState = FormWindowState.Normal; //还原窗体 
          }
      }

      private void MainForm_SizeChanged(object sender, EventArgs e)
      {
          if (this.WindowState == FormWindowState.Normal)
          {
              notifyIcon.Visible = true; //托盘图标隐藏
          }
          if (this.WindowState == FormWindowState.Minimized)//最小化事件
          {
              this.Hide();//最小化时窗体隐藏
          }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
          DialogResult result;
          result = MessageBox.Show("确定退出吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
          if (result == DialogResult.OK)
          {

              Application.ExitThread();
          }
          else
          {
              e.Cancel = true;
          }
      }

      private void helpMenu_Click(object sender, EventArgs e)
      {
          HelpForm form = new HelpForm();
          form.ShowDialog();
      }

     
    }
}
