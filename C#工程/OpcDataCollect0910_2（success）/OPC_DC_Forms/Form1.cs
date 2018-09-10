using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPCAutomation;
using OPC_DC_Forms.CLASS;
using System.Threading;
using System.IO;
using System.Configuration;
namespace OPC_DC_Forms
{
    public partial class Form1 : Form
    {

        List<Item> ItemList = new List<Item> { };
        OPCServer opcServer = new OPCServer();
        OPCGroups opcGroups;
        OPCGroup opcGroup;
        OPCItems opcItems;
        OPCItem[] opcItem;
        OPCBrowser opcBrowser;
        //string opcIP = "192.168.102.13";
       // string opcServerName = "Matrikon.OPC.Simulation.1";
       // string opcIP = "192.168.102.11";
       // string opcServerName = "OPC.DeltaV.1";
      //  string opcIP = "10.12.100.78";
      //  string opcServerName = "Matrikon.OPC.iHistorian";
        string opcIP;
        string opcServerName;
        string outPath;
        int groupItemCount = 30;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            opcIP = ConfigurationManager.AppSettings["opcIP"];
            opcServerName = ConfigurationManager.AppSettings["opcName"];
            outPath = ConfigurationManager.AppSettings["outPath"];
            groupItemCount = Convert.ToInt32(ConfigurationManager.AppSettings["groupItemCount"]);
            string itemliststring = ConfigurationManager.AppSettings["itemList"];
            itemliststring = itemliststring.Replace("\r\n","");
            itemliststring = itemliststring.Replace("\t", "");
            itemliststring = itemliststring.Replace(" ", "");
            string[] itemtabl = itemliststring.Split(',');
   
           // GetLocalServer();
            this.textBox_IP.Text = opcIP;
            this.textBoxName.Text = opcServerName;
            //string[] itemtabl = new ItemTable().NBitemtable;
            for (int i = 0; i < itemtabl.Count(); i++)
            {
                //handler 是从1开始的
                ItemList.Add(new Item(itemtabl[i], "0", "", i + 1));
            }
            //for (int i = 0; i < 4000; i++) {
            //    //handler 是从1开始的
            //    ItemList.Add(new Item("safer." + (i + 1).ToString(), "0", "", i + 1));
            //}
            //ItemList.Add(new Item( "FI-22115C/ALM1/PV.CV", "0", "",  1));
            //ItemList.Add(new Item("FI-22215B/ALM1/PV.CV", "0", "", 2));
            //ItemList.Add(new Item("FI-29020/ALM1/PV.CV", "0", "", 3));
            //ItemList.Add(new Item("FI-29020/ALM1/PV.CV", "0", "", 4));
            //ItemList.Add(new Item("FI-29022/ALM1/PV.CV", "0", "", 5));


  
        }
     

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                opcServer.Connect(this.textBoxName.Text,this.textBox_IP.Text);
              //  MyServer.Connect(comboBox_ServerNames.SelectedItem.ToString(), strHostIP);
                //连接本机,后面的IP就不需要了
    




                    if (opcServer.ServerState == (int)OPCServerState.OPCRunning)         //判断是否连接上了
                    {
                        opcBrowser = opcServer.CreateBrowser();
                        labelState.Text = "connected";
                    }
                    else
                    {
                        labelState.Text = "connect fail";
                        throw new Exception("ServerState: " + opcServer.ServerState);
                    }

                opcServer.ServerShutDown += ServerShutDown;//服务器断开事件,没有发现他在哪里用的。

            }
            catch (Exception err)
            {
                MessageBox.Show("ConnectServer:" + err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateGroup();
        }
        private bool CreateGroup()
        {
            try
            {

                opcGroups = opcServer.OPCGroups;
                
                opcGroup = opcGroups.Add("Group1");

                //以下设置属性
                {

                    opcGroups.DefaultGroupIsActive = true;      //激活组
                    opcGroups.DefaultGroupDeadband = 0;         //死区值，设为0时，服务器端该组内任何数据变化都通知组
                    opcGroups.DefaultGroupUpdateRate = 5000;     //默认组群的刷新频率为200ms
                    this.labelState.Text = "UpdateRate = 5000ms";


                    opcGroup.UpdateRate = 5000;//刷新频率为5秒
                    opcGroup.IsSubscribed = true; //如果没有订阅，则该组的DataChange回调事件不会发生

                   
                }
 
                     
                   //  opcGroup2.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(GroupDataChange);
               // MyGroup2.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(GroupDataChange2);
               //  opcGroup.AsyncReadComplete += new DIOPCGroupEvent_AsyncReadCompleteEventHandler(GroupAsyncReadComplete);
               // MyGroup2.AsyncReadComplete += new DIOPCGroupEvent_AsyncReadCompleteEventHandler(GroupAsyncReadComplete);

                //添加Item
                AddGroupItems();  //设置组内的Items
                InitValue();
                opcGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(GroupDataChange);
            }
            catch (Exception err)
            {
                throw new Exception("CreateGroup:" + err.Message);
            }
            return true;
        }
        private void AddGroupItems()
        {

            opcItems = opcGroup.OPCItems;
           
            opcItem = new OPCItem[ItemList.Count];


            for (int i = 0; i < ItemList.Count; i++)
            {
                opcItem[i] = opcItems.AddItem(ItemList[i].name, ItemList[i].handler);
            }
   

        }
        private void InitValue()
        {
            //同步读
            object ItemValues, Qualities, TimeStamps;
            textBoxResult.Text = "";
            for (int i = opcItem.Count()-1; i >= 0; i--)
            {
                try
                {

                    opcItem[i].Read(1, out ItemValues, out Qualities, out TimeStamps);

                    ItemList[i].value = ItemValues.ToString();
                    labelState.Text = "Item: " + ItemList[i].name+" value:"+ItemList[i].value;
                    
                }
                catch (Exception ex)
                {
                    textBoxResult.Text += "Item: " + ItemList[i].name + " error: " + ex.Message+"\r\n";
                  //  labelState.Text = ex.Message;
                }
            }
            

        }
        public void ServerShutDown(string Reason)//服务器先行断开
        {
            opcServer.OPCGroups.RemoveAll();
            opcServer.Disconnect();
        }
        void GroupDataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
           

            for (int i = 1; i <= NumItems; i++)
            {

                int index = Convert.ToInt32(ClientHandles.GetValue(i)) - 1;
                ItemList[index].value = ItemValues.GetValue(i).ToString();
                ItemList[index].qualities = Qualities.GetValue(i).ToString();
                ItemList[index].timestamp = TimeStamps.GetValue(i).ToString();

            }
            this.textBoxA0.Text = ItemList[0].value;
            this.textBoxA1.Text = ItemList[1].value;
            this.textBoxA2.Text = ItemList[2].value;
            this.textBoxA3.Text = ItemList[3].value;
            this.textBoxA4.Text = ItemList[4].value;
            writefile();
        }

        void writefile() {
            FileStream fs = new FileStream(outPath, FileMode.Create);
            DateTime ds = new DateTime();
            ds = System.DateTime.Now;
            string time = string.Format("{0:yy:MM:dd:HH:mm:ss}", ds);
            string content = "";
            int ItemCount = ItemList.Count;
            int index = 0;
            int unitCount = 0;
            int groupcount = 30;
            while (index < ItemCount) {
                content += "Unit #" + (unitCount+1).ToString() + "\t" + time + "\t" + "Unit Status: OK" + "\t";
                for (int i = 0; i < groupcount; i++)
                {
                    int index2 = i + unitCount * groupcount;
                    if (index2 < ItemCount)
                    {
                        content += ItemList[i + unitCount * groupcount].name + "\t" + "ppm" + "\t" + ItemList[i + unitCount * groupcount].value + "\t" + "OK" + "\t";
                    }
                }
                content += "\r\n";
                index += groupcount;
                unitCount++;
            }
            byte[] data = System.Text.Encoding.Default.GetBytes(content);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();

        
        }
     


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //善后，关闭之前的工作。
            if (opcGroup != null)
            {
                opcGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(GroupDataChange);
            }


            if (opcServer != null)
            {
                opcServer.OPCGroups.RemoveAll();
                opcServer.Disconnect();
            }
        }

        private void buttonSysRead_Click_1(object sender, EventArgs e)
        {
            //同步读
            object ItemValues, Qualities, TimeStamps;
            try {
                opcItem[0].Read(1, out ItemValues, out Qualities, out TimeStamps);
                this.textBoxB1_1.Text = Convert.ToString(ItemValues);
                opcItem[1].Read(1, out ItemValues, out Qualities, out TimeStamps);
                this.textBoxB1_2.Text = Convert.ToString(ItemValues);

                opcItem[2].Read(1, out ItemValues, out Qualities, out TimeStamps);
                this.textBoxB1_3.Text = Convert.ToString(ItemValues);
                opcItem[3].Read(1, out ItemValues, out Qualities, out TimeStamps);
                this.textBoxB1_4.Text = Convert.ToString(ItemValues);
                opcItem[4].Read(1, out ItemValues, out Qualities, out TimeStamps);
                this.textBoxB1_5.Text = Convert.ToString(ItemValues);
            }
            catch(Exception ex){

                labelState.Text = ex.Message; 
            }

            labelState.Text = "reade ok";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream chefile = new FileStream("D:\\itemresult.txt", FileMode.Create);
            byte[] data = System.Text.Encoding.Default.GetBytes("test");
            chefile.Write(data, 0, data.Length);
            chefile.Flush();
            chefile.Close();
            File.AppendAllText("D:\\itemresult.txt", "d"+"\r\n", Encoding.UTF8);
            File.AppendAllText("D:\\itemresult.txt", "e" + "\r\n", Encoding.UTF8);
            File.AppendAllText("D:\\itemresult.txt", "f" + "\r\n", Encoding.UTF8);
            TreeNode tr = new TreeNode();
            tr.Text = "o";
            treeView1.Nodes.Add(tr);
            LoadDataToTree(opcBrowser,treeView1.Nodes[0].Nodes,"root");

            
           // opcBrowser.ShowLeafs(true);
     

        }
        private bool LoadDataToTree(OPCBrowser oPCBrowser, TreeNodeCollection treeNodeCollection,string root) { 
        
           opcBrowser.Organization.ToString();
            opcBrowser.ShowBranches();
            bool isLeaf = true;
            foreach (object turn in opcBrowser) {
                TreeNode node = null; 
                node = treeNodeCollection.Add(turn.ToString());
                opcBrowser.MoveDown(turn.ToString());
                if (LoadDataToTree(oPCBrowser, node.Nodes, root+"\\"+turn.ToString()))
                {
                    if (turn.ToString().Equals("PV"))
                    {
                        //textBoxResult.Text +=root+"\\"+turn.ToString() + "\r\n";
                        File.AppendAllText("D:\\itemresult.txt", root + "\\" + turn.ToString() + "\r\n", Encoding.UTF8);
                    }
                }
                oPCBrowser.MoveUp();
                isLeaf = false;
            }
            return isLeaf;
        }
    





    }
}
