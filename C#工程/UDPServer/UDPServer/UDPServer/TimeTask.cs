using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;

using System.Timers;
namespace UDPServer
{
    class TimeTask
    {
        public static double IntervalTime;
        public void StartTimeTask(double Interval)
        {

           // Console.WriteLine("start time task");
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = Interval; //执行间隔时间,单位为毫秒; 这里实际间隔为10分钟  
            IntervalTime = Interval;
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(task);
        }
        private void task(object source, ElapsedEventArgs e)
        {
            if (Var.ListKids.Count > 0)
            {
                while (!Var.ListBusy)
                {
                    Var.ListBusy = true;
                    for (int i = Var.ListKids.Count - 1; i >= 0; i--)
                    {
                        RefreshOverTime(Var.ListKids[i]);
                    }
                    Var.ListBusy = false;
                    break;
                }
            }
            

        }
        private void RefreshOverTime(Kid kid) {
            
            
            if (kid.overTime > IntervalTime)
            {
                kid.overTime = kid.overTime - IntervalTime;
                //Console.WriteLine("reduce program time:" + kid.name+"  time:"+kid.overTime);
            }
            else {
                Var.ListKids.Remove(kid);
                //Console.WriteLine("remove program and send message:" + kid.name+"   message:"+kid.message);
                SendMSM sendMSM = new SendMSM();
                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string context = "失去心跳连接，详细信息---IP：" + kid.ip + "  名称：" + kid.name + "  预留信息：" + kid.message + "    时间：" + datetime;
                Console.WriteLine(context);
                Var.showListKids();
                //发送短信
                //sendMSM.SendSmsMessage(context);
            }
        }
    }

   
}
