using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPC_DC_Forms.CLASS;
using OPC_DC_Forms.Properties;
namespace OPC_DC_Forms
{
    class ReadItems
    {
        List<Item> ItemList = new List<Item> { };
        public ReadItems() {
           ItemList.Add(new Item("dianwei1"));
           ItemList.Add(new Item("dianwei2"));
           Item te = ItemList.SingleOrDefault(p => p.name == "dianwei2");
           Item te1 = ItemList[0];
           
        }
        public void Connect() { 
        
        }
        public void StartRead() { 
        
        }
    }
}
