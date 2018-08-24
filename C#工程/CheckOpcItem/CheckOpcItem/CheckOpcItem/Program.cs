using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPCAutomation;
using System.Configuration;
namespace CheckOpcItem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("hello");
            var settings = ConfigurationManager.AppSettings;
            String ser = settings["OPCServerIP"];
            String opcName = "OPC.DeltaV.1";
            String opcUrl = "192.168.102.11";
            opcName = Console.ReadLine();
            opcUrl = Console.ReadLine();
            OPCServer opcserver = new OPCServer();
            try
            {
                opcserver.Connect(opcName,opcUrl);
                if (opcserver.ServerState == (int)OPCServerState.OPCRunning) {
                    Console.Out.WriteLine("opc running");
                }
            
                
            }
            catch (Exception e) {
                Console.Out.WriteLine(e.Message);
            }
            opcserver.Disconnect();
            Console.Out.WriteLine("hello");
            while (true) { }
        
        }
    }
}
