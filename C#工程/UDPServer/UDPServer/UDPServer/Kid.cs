using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer
{
    class Kid
    {
        public String id = "";//ID采用IP+name实现
        public String name=""; //IP+name
        public double periodTime=5000; //心跳周期
        public double overTime; //心跳周期
        public String message = ""; //预留信息
        public String ip = ""; //IP
        public String port = ""; //Port
        public Kid(string ID, string IpName, double pT, string msg, string Ip, string Port)
        {
            name = IpName;
            periodTime = pT;
            overTime = pT * 3; //丢失心跳次数，达到三次后短信通知
            message = msg;
            ip = Ip;
            port = Port;
            id = ID;
        }
    }
}
