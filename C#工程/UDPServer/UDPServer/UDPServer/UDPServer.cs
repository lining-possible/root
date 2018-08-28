using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Media;
using Newtonsoft.Json.Linq;


namespace UDPServer
{
    class UDPServer
    {
        public static void UdpServer(IPEndPoint serverIP)
        {

            bool thread_flag = true;
            Console.WriteLine("UDP服务器开始监听" + serverIP.Port + "端口");
            Socket udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpServer.Bind(serverIP);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)ipep;
            new Thread(() =>
            {
                while (thread_flag)
                {
                    
                    byte[] data = new byte[1024];
                    int length = 0;
                    try
                    {
                        length = udpServer.ReceiveFrom(data, ref Remote);//接受来自服务器的数据
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("出现异常：{0}", ex.Message));
                        break;
                    }
                    string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string message = Encoding.UTF8.GetString(data, 0, length);
                    string IP = (Remote as IPEndPoint).Address.ToString();
                    string Port = (Remote as IPEndPoint).Port.ToString();
                    string ipport = (Remote as IPEndPoint).Address.ToString() + ":" + (Remote as IPEndPoint).Port.ToString();
                   // Console.WriteLine(string.Format("{0} 收到來自{1}的消息：{2}", datetime, ipport, message));

                    //将接收的心跳交给ManageVarThread线程处理
                    JObject jo = (JObject)JsonConvert.DeserializeObject(message);
                    Kid kid = new Kid(IP + jo["name"].ToString(), jo["name"].ToString(), int.Parse(jo["period"].ToString()), jo["message"].ToString(), IP, Port);
                    ManageVarThread manV = new ManageVarThread();
                    manV.kid = kid;
                    Thread man = new Thread(manV.test);
                    man.Start();

                }
                udpServer.Close();
            }).Start();
            Console.WriteLine("\n\n按[F4]键退出。");
            ConsoleKey key;
            while (true)
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.F4)
                {
                    Console.WriteLine("end waiting for udp data.");
                    thread_flag = false;
                    break;
                }
            }
        }
    }
}
