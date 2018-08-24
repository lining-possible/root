using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WHChem.OPCMonitor
{
    public class ConfigInfo
    {
      /// <summary>
      /// OPC服务器IP列表，多台使用逗号间隔
      /// </summary>
      public string OPCServerIPList{get;set;}


      /// <summary>
      /// 当前监控的OPC服务器IP
      /// </summary>
      public string OPCServerIP{get;set;}

      /// <summary>
      /// 当前监控的OPC服务器名称
      /// </summary>
      public string OPCServerName{get;set;}
        

      /// <summary>
      /// 烟台监控点位
      /// </summary>
      public string MonitorTagYT{get;set;}

      /// <summary>
      /// 宁波监控点位
      /// </summary>
      public string MonitorTagNB{get;set;}

      /// <summary>
      /// 监控间隔时间
      /// </summary>
      public int MonitorInterval{get;set;}


      /// <summary>
      /// 短信系统用户名
      /// </summary>
      public string SMSUser {get;set;}

      /// <summary>
      /// 短信系统密码
      /// </summary>
      public string SMSPassword {get;set;}

      /// <summary>
      /// 短信通知手机号列表,多个号码使用逗号间隔
      /// </summary>
      public string SMSNoList {get;set;}


      /// <summary>
      /// 连续失败？次开始发送通知
      /// </summary>
      public int MinAlertCount { get; set; }

      /// <summary>
      /// 连续失败？次停止发送通知
      /// </summary>
      public int MaxAlertCount { get; set; }

        /// <summary>
        /// 启用短信通知
        /// </summary>
      public bool UseSMSFlag { get; set; }
    }
}
