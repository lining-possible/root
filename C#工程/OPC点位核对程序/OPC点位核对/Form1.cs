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
using System.IO;
namespace OPC点位核对
{
    public partial class Form1 : Form
    {
    
        OPCServer opcServer = new OPCServer();
        OPCGroups opcGroups;
        OPCGroup opcGroup;
        OPCItems opcItems;
        OPCItem[] opcItem;
        OPCBrowser opcBrowser;
        string opcIP;
        string opcServerName;
        string path;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            path = textBoxBrowserOutPath.Text;

            comboBoxOpcIP.Items.AddRange(new object[]{
                "192.168.102.11",
                "192.168.102.12",
                "192.168.102.13",
                "192.168.102.14",
                "192.168.102.15"
            });

            comboBoxOpcServerName.Items.AddRange(new object[]{
                "Matrikon.OPC.Simulation.1",
                "OPC.DeltaV.1",
                "SUPCON.JXServer.1"          
            });
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonConnectOpc_Click(object sender, EventArgs e)
        {
            if (comboBoxOpcIP.Text == "" || comboBoxOpcServerName.Text == "")
            {
                MessageBox.Show("请输入正确的IP和服务名称    示例： 192.168.102.13   OPC.DeltaV.1");
            }
            opcIP = comboBoxOpcIP.Text;
            opcServerName = comboBoxOpcServerName.Text;


            try
            {
                opcServer.Connect(opcServerName,opcIP);
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

        public void ServerShutDown(string Reason)//服务器先行断开
        {
            opcServer.OPCGroups.RemoveAll();
            opcServer.Disconnect();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //善后，关闭之前的工作。

            if (opcServer != null)
            {
                opcServer.OPCGroups.RemoveAll();
                opcServer.Disconnect();
            }
        }
        
        private void buttonBrowserItem_Click(object sender, EventArgs e)
        {
            
 
            TreeNode tr = new TreeNode();
            tr.Text = "opc server";
            treeView1.Nodes.Add(tr);
            if (checkBoxFlat.Checked)
            { //flat 方式
                try
                {
                    
                    LoadDataToTreeFlat(opcBrowser, treeView1.Nodes[0].Nodes, "root");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法showleafs叶子节点,error: " + ex.Message);
                }
            
            
            
            }
            else {

                LoadDataToTree(opcBrowser, treeView1.Nodes[0].Nodes, "root");
            
            
            }
      
            
            
        }
        private void LoadDataToTreeFlat(OPCBrowser oPCBrowser, TreeNodeCollection treeNodeCollection, string root)
        {

            oPCBrowser.Organization.ToString();

            oPCBrowser.ShowBranches();
            opcBrowser.ShowLeafs(true);
            foreach (object turn in opcBrowser)
            {

                File.AppendAllText(path, root + "\\" + turn.ToString() + "\r\n", Encoding.UTF8);

            }
        }
        private bool LoadDataToTree(OPCBrowser oPCBrowser, TreeNodeCollection treeNodeCollection, string root)
        {

            oPCBrowser.Organization.ToString();

            oPCBrowser.ShowBranches();
            
             bool isLeaf = true;

             foreach (object turn in opcBrowser)
             {
                 TreeNode node = null;
                 node = treeNodeCollection.Add(turn.ToString());
                 opcBrowser.MoveDown(turn.ToString());
                 if (LoadDataToTree(oPCBrowser, node.Nodes, root + "\\" + turn.ToString()))
                 {
                     //if (turn.ToString().Equals("PV"))
                     //{


                     //textBoxResult.Text +=root+"\\"+turn.ToString() + "\r\n";
                     File.AppendAllText(path, root + "\\" + turn.ToString() + "\r\n", Encoding.UTF8);

                     // }
                 }
                 oPCBrowser.MoveUp();
                 isLeaf = false;
             }
            return isLeaf;
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (opcServer != null)
            {
                opcServer.OPCGroups.RemoveAll();
                opcServer.Disconnect();
            }
            labelState.Text = "no connect";
        }

        private void buttonCheckItem_Click(object sender, EventArgs e)
        {
            string inpath = textBoxInFile.Text;
            string outpath = textBoxCheckItemOutPath.Text;
            List<string> itemlist = new List<string> { };
            if (textBoxInFile.Text.Equals("")) {
                MessageBox.Show("输入文件路径不存在");
            }
            if (textBoxCheckItemOutPath.Text.Equals(""))
            {
                MessageBox.Show("输出文件路径不存在");
            }
            //FileStream chefile = new FileStream(outpath, FileMode.Create);
            if (!textBoxInFile.Text.Equals("") && !textBoxCheckItemOutPath.Text.Equals(""))
            {         
                try
                {
                    StreamReader sr = new StreamReader(inpath,Encoding.Default);
                    string line;
                    
                    while ((line = sr.ReadLine()) != null) { 
                        //读取一行outpath
                        line = line.Replace("\t", "");
                        line = line.Replace(" ", "");
                        line = line.Replace(",", "");
                        itemlist.Add(line);
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("读取文件失败");

                }
                try
                {
                    opcGroups = opcServer.OPCGroups;
                    DateTime dt = new DateTime();
                    dt = DateTime.Now;
                    dt.Second.ToString();
                    opcGroup = opcGroups.Add("Group" + dt.Hour.ToString() + dt.Second.ToString());
                    //以下设置属性
                    {
                        opcGroups.DefaultGroupIsActive = true;      //激活组
                        opcGroups.DefaultGroupDeadband = 0;         //死区值，设为0时，服务器端该组内任何数据变化都通知组
                        opcGroups.DefaultGroupUpdateRate = 5000;     //默认组群的刷新频率为200ms
                        this.labelState.Text = "UpdateRate = 5000ms";

                        opcGroup.UpdateRate = 5000;//刷新频率为5秒
                        opcGroup.IsSubscribed = true; //如果没有订阅，则该组的DataChange回调事件不会发生


                    }
                    //添加Item
                     //设置组内的Items
                    opcItems = opcGroup.OPCItems;
                    opcItem = new OPCItem[itemlist.Count];
                    for (int i = 0; i < itemlist.Count; i++)
                    {
                        opcItem[i] = opcItems.AddItem(itemlist[i], i+1);
                    }
                    //同步读
                    object ItemValues, Qualities, TimeStamps;

                    for (int i = opcItem.Count() - 1; i >= 0; i--)
                    {
                        try
                        {
                            opcItem[i].Read(1, out ItemValues, out Qualities, out TimeStamps);
                            string value = ItemValues.ToString();
                            File.AppendAllText(outpath, "Item: " + itemlist[i] + " value:" + value + "\r\n");
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText(outpath, "Item: " + itemlist[i] + " error: " + ex.Message + "\r\n");
                            //  labelState.Text = ex.Message;
                        }
                    }

                }
                catch (Exception err)
                {
                    //throw new Exception("CreateGroup:" + err.Message);
                }

   
            
            
            }
            
            
        }


    }
}
