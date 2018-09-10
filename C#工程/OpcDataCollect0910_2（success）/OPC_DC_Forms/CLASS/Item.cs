using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_DC_Forms.CLASS
{
    class Item
    {
        
        public string name;
        public string value;
        public string qualities;
        public string timestamp;
        public int handler;
        public Item(string tagName)
        {
            this.name = tagName;
            this.value = "null";
            this.timestamp = "null";
            this.handler = 0;
            this.qualities = "";

        }
        public Item(string tagName,string tagVale,string tagTimestamp, int tagHandler) {
            this.name = tagName;
            this.value = tagVale;
            this.timestamp = tagTimestamp;
            this.handler = tagHandler;
        
        }
    }
}
