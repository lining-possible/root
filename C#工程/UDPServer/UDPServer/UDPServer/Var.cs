using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer
{
    class Var
    {
        public static List<Kid> ListKids = new List<Kid>();
        public static bool ListBusy = false;

        public static void showListKids() {
            int a = 30, b = 40, c = 20;
            Console.WriteLine("============================= 当前心跳状态==============================================");
            Console.WriteLine("Name".PadRight(a) + "IpPort".PadRight(b) + "Period(s)".PadRight(c));
            for (int i=0; i < ListKids.Count; i++) {
                Console.WriteLine(ListKids[i].name.PadRight(a) + (ListKids[i].ip + ":" + ListKids[i].port).PadRight(b) + ListKids[i].periodTime.ToString().PadRight(c));
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
