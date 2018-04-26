using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Xml;
using Amib.Threading;

namespace BugsBox.Pharmacy.AppClient.Side
{
    public partial class Warn : DockContent
    {        
        public Warn()
        {
            InitializeComponent();
        }
        
        private void Warn_Load(object sender, EventArgs e)
        {
            Tree_Load();
            treeView1.ExpandAll();
            ServicesProvider.Instance.PharmacyNotificationCallback.SupplyUnitLocked += new EventHandler<EventArgs<int>>(PharmacyNotificationCallback_SupplyUnitLock);
            ServicesProvider.Instance.PharmacyNotificationCallback.DrugLocked += new
EventHandler<EventArgs<int>>(PharmacyNotificationCallback_DrugLock);
            ServicesProvider.Instance.PharmacyNotificationCallback.PurchaseUnitLocked += new EventHandler<EventArgs<int>>(PharmacyNotificationCallback_PurchaseUnitLock);
            ServicesProvider.Instance.PharmacyNotificationCallback.NeedApprovaled+=new EventHandler<EventArgs<Business.Models.WarningData[]>>(PharmacyNotificationCallback_NeedApprovaled);
            ServicesProvider.Instance.PharmacyNotificationCallback.NeedDrugMaintained+=new EventHandler<EventArgs<int>>(PharmacyNotificationCallback_NeedDrugMaintained);
            ServicesProvider.Instance.PharmacyNotificationCallback.NeedHandledDoubtDruged+=new EventHandler<EventArgs<int>>(PharmacyNotificationCallback_NeedHandledDoubtDruged);
            ServicesProvider.Instance.PharmacyNotificationCallback.NeedHandleSaleed+=new EventHandler<EventArgs<Business.Models.WarningData[]>>(PharmacyNotificationCallback_NeedHandleSaleed);
            ServicesProvider.Instance.PharmacyNotificationCallback.NeedHandlePurchaseed+=new EventHandler<EventArgs<Business.Models.WarningData[]>>(PharmacyNotificationCallback_NeedHandlePurchaseed);
            ServicesProvider.Instance.PharmacyNotificationCallback.DrugOutofStocked+=new EventHandler<EventArgs<int>>(PharmacyNotificationCallback_DrugOutofStocked);
        }

        /// <summary>
        /// 缺货报警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PharmacyNotificationCallback_DrugOutofStocked(object sender, EventArgs<int> e)
        {
            string nodeName = "缺货报警";
            ShowWarn(e.Value, nodeName);
        }

        #region 采购报警
        void PharmacyNotificationCallback_NeedHandlePurchaseed(object sender, EventArgs<Business.Models.WarningData[]> e)
        {
            foreach (Business.Models.WarningData data in e.Value)
            {
                ShowWarn(data.value, data.key);
            }
        }
        #endregion
        #region 销售报警
        void PharmacyNotificationCallback_NeedHandleSaleed(object sender, EventArgs<Business.Models.WarningData[]> e)
        {
            foreach (Business.Models.WarningData data in e.Value)
            {
                ShowWarn(data.value, data.key);
            }
        }
        #endregion
        #region 疑问药品
        void PharmacyNotificationCallback_NeedHandledDoubtDruged(object sender, EventArgs<int> e)
        {
            string nodeName = "疑问药品";
            ShowWarn(e.Value, nodeName);
        }
        #endregion
        #region 养护

        void PharmacyNotificationCallback_NeedDrugMaintained(object sender, EventArgs<int> e)
        {
            string nodeName = "养护到期";
            ShowWarn(e.Value, nodeName);
        }

        #endregion
        #region 审批
        void PharmacyNotificationCallback_NeedApprovaled(object sender, EventArgs<Business.Models.WarningData[]> e)
        {
            foreach (Business.Models.WarningData data in e.Value)
            {
                ShowWarn(data.value, data.key);
            }
        }
        #endregion

        #region 锁定通知
        void PharmacyNotificationCallback_DrugLock(object sender, EventArgs<int> e)
        {
            string nodeName = "药品被锁";
            ShowWarn(e.Value, nodeName);
        }

        void PharmacyNotificationCallback_SupplyUnitLock(object sender, EventArgs<int> e)
        {
            string nodeName = "供应商被锁";
            ShowWarn(e.Value, nodeName);
            //MessageBox.Show(e.ToString());
        }

        void PharmacyNotificationCallback_PurchaseUnitLock(object sender, EventArgs<int> e)
        {
            string nodeName = "客户被锁";
            ShowWarn(e.Value, nodeName);
        }
        #endregion

        readonly SmartThreadPool smartThreadPool = new SmartThreadPool();
        private void ShowWarn(int e, string nodeName)
        {
            try
            {
                this.textBox1.Text = null;
                this.textBox1.Text = e.ToString() + "个" + nodeName;

                TreeNodeCollection n = this.treeView1.Nodes;

                foreach (TreeNode tn in n)
                {
                    foreach (TreeNode t in tn.Nodes)
                    {
                        string tTitle=t.Text;
                        if (t.Name.Contains(nodeName))
                        {
                            //t.Text += e.ToString();
                        }
                    }
                }

            }
            catch { }
        }

        private void Tree_Load()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Configuration.ConfigurationManager.AppSettings["Warn"].ToString());
                TreeNode work = treeView1.Nodes.Find("work", true)[0];
                TreeNode warn = treeView1.Nodes.Find("warn", true)[0];
                foreach (XmlNode node in doc.SelectNodes("/Group/Works/Item"))
                {
                    AddNode(work, node);
                }
                foreach (XmlNode node in doc.SelectNodes("/Group/Warns/Item"))
                {
                    AddNode(warn, node);
                }

            }
            catch
            {
                MessageBox.Show("报警配置文件错误");
            }
        }

        private void AddNode(TreeNode work, XmlNode node)
        {
            Menu.NodeTag nodeTag = new Menu.NodeTag()
            {
                id = node.Attributes["id"].Value,
                Name = node.Attributes["Name"].Value,
                Params = node.Attributes["Params"].Value,
                Title = node.Attributes["Title"].Value,
                ModuleKey = node.Attributes["ModuleKey"].Value
            };
            TreeNode Node = new TreeNode();
            Node.Text = nodeTag.Title;
            Node.Name = nodeTag.id;
            Node.Tag = nodeTag;
            Node.ImageIndex = 0;
            Node.SelectedImageIndex = 0;
            if (!string.IsNullOrWhiteSpace(nodeTag.ModuleKey))
            {
                if(PharmacyAuthorizeExtesions.Authorize(this, nodeTag.ModuleKey))
                    work.Nodes.Add(Node);
            }
        }

        delegate void Mydelegate(DockContent form, DockState? state);
        Mydelegate md = null;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            

        }

        private void ShowForm(DockContent form, DockState? state)
        {
            (this.ParentForm as frmMain).ShowForm(form, state);
            //(this.ParentForm as frmMain).s
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                Menu.NodeTag nodeTag = (Menu.NodeTag)e.Node.Tag;
                if (!string.IsNullOrWhiteSpace(nodeTag.Name))
                {
                    e.Node.Text = nodeTag.Title;
                    e.Node.ImageIndex = 0;
                    Type type = Type.GetType(System.Configuration.ConfigurationManager.AppSettings["AppNameSpace"].ToString() + "." + nodeTag.Name);
                    DockContent form = null;

                    if (!string.IsNullOrWhiteSpace(nodeTag.Params))
                    {
                        form = (DockContent)Activator.CreateInstance(type, nodeTag.Params.Split(','));
                    }
                    else
                    {
                        form = (DockContent)Activator.CreateInstance(type);
                    }
                    md = new Mydelegate(ShowForm);
                    switch (nodeTag.DockState)
                    {
                        case "left":

                            md(form, DockState.DockLeft);
                            //_formMain.ShowForm(form, DockState.DockLeft);
                            break;
                        case "right":
                            md(form, DockState.DockRight);
                            //_formMain.ShowForm(form, DockState.DockRight);
                            break;
                        case "top":
                            md(form, DockState.DockTop);
                            //_formMain.ShowForm(form, DockState.DockTop);
                            break;
                        case "bottom":
                            md(form, DockState.DockBottom);
                            //_formMain.ShowForm(form, DockState.DockBottom);
                            break;
                        default:
                            md(form, null);
                            //_formMain.ShowForm(form);
                            break;
                    }

                }
            }
        }
    }
}
