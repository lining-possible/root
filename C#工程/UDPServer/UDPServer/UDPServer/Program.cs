using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Media;
using System.Collections.Generic;
using System.Timers;
using System.Configuration; 
namespace UDPServer
{
  
    class Program
    {
       
        /// <summary>
        /// 控制台主函数
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var settings = ConfigurationManager.AppSettings;
            int UdpPort = int.Parse( settings["UdpPort"]);
            double CheckPeriod = double.Parse(settings["CheckPeriod"]);
            //启动定时周期任务
            TimeTask timetask = new TimeTask();
            timetask.StartTimeTask(CheckPeriod);
            //启动UDP服务来接收数据
            UDPServer.UdpServer(new IPEndPoint(0, UdpPort));
        }
     

    }
}