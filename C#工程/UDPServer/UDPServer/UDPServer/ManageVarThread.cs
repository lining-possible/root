using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace UDPServer
{
    class ManageVarThread
    {
        public Kid kid;
        public void test(){
            //判断 List是否在使用状态， 放置造成访问冲突
            while (!Var.ListBusy) {
                Var.ListBusy = true;
                int index = Var.ListKids.FindIndex(s=>s.id == kid.id);
                
                if (index>=0)//该心跳已经存在列表中
                {                  
                  // Console.WriteLine("该心跳已存在，序号为："+index);
                   Var.ListKids[index] = kid;
                }
                else { //该心跳不存在，为新的心跳
                    Var.ListKids.Add(kid);
                   // Console.WriteLine("该心跳不存在，新加入");
                    Var.showListKids();
                }   
                Var.ListBusy = false;                
                break;
            }
        }
 
    }
}
