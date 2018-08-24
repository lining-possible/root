using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WHChem.OPCMonitor
{
    public static class ConfigHelper
    {
        /// <summary>
        /// //读取配置文件
        /// </summary>
        /// <returns></returns>
        public static ConfigInfo   GetConfigureInfo()
        {
            ConfigInfo configInfo = new ConfigInfo();
            var settings = ConfigurationManager.AppSettings;
            configInfo.OPCServerIPList = settings["OPCServerIPList"];
            configInfo.OPCServerIP = settings["OPCServerIP"];
            configInfo.OPCServerName = settings["OPCServerName"];
            configInfo.MonitorTagYT = settings["MonitorTagYT"];
            configInfo.MonitorTagNB = settings["MonitorTagNB"];
            configInfo.MonitorInterval = int.Parse(settings["MonitorInterval"]);

            configInfo.SMSUser = settings["SMSUser"];
            configInfo.SMSPassword = settings["SMSPassword"];
            configInfo.SMSNoList = settings["SMSNoList"];

            configInfo.MinAlertCount = int.Parse(settings["MinAlertCount"]);
            configInfo.MaxAlertCount = int.Parse(settings["MaxAlertCount"]);

            configInfo.UseSMSFlag = bool.Parse(settings["UseSMSFlag"]);
            return configInfo;
            
        }
    }
}
