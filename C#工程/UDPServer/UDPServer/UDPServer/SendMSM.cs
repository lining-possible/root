using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace UDPServer
{
    class SendMSM
    {
        /// <summary>
        /// 调用短信接口发送错误消息
        /// </summary>
        /// <param name="smsContent">要发送的消息</param>
        public void SendSmsMessage(string smsContent)
        {
            try
            {
                var settings = ConfigurationManager.AppSettings;
                string OPCServerIPList = settings["SMSNoList"];
                if (true)
                {
                    com.whchem.sms.Service ser = new com.whchem.sms.Service();
                    var result = ser.SendSMSOfInterface(settings["SMSUser"], settings["SMSPassword"], settings["SMSNoList"], smsContent);
                    //SMSServiceReference.ServiceSoapClient client = new SMSServiceReference.ServiceSoapClient();
                    //var result = client.SendSMSOfInterface(settings["SMSUser"], settings["SMSPassword"], settings["SMSNoList"], smsContent); //调用短信webservice发送短信
                    
                    if (result == 1)
                    {
                        Console.WriteLine("发送短信成功:" + smsContent);
                    }
                    else
                    {
                        Console.WriteLine("发送短信失败:" + smsContent);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("发送短信出错:" + ex.Message);
            }

        }
    }
}
