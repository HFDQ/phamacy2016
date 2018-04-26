using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;

namespace BugsBox.Pharmacy.AppClient
{
    public partial class Menu : DockContent
    {
        private frmMain _formMain;
        public Menu(frmMain formMain)
        {
            InitializeComponent();
            _formMain = formMain;
        }
        /// <summary>
        /// 展开节点
        /// </summary>
        public string ExpandNode
        {
            set
            {
                TreeNode nodeF = treeView1.Nodes[0];
                TreeNode tnode = nodeF.Nodes.Find(value, true).FirstOrDefault();
                if (tnode != null)
                {
                    treeView1.CollapseAll();
                    nodeF.Expand();
                    tnode.Expand();
                }
            }
        }
        
        private void Menu_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Configuration.ConfigurationManager.AppSettings["Menu"].ToString());


                foreach (XmlNode node in doc.SelectNodes("/MenusGroup/Menu"))
                {
                    AddTree(node, null);
                }

            }
            catch
            {
                MessageBox.Show("菜单配置文件不存在");
                return;
            }
            treeView1.HideSelection = true;
            treeView1.ShowLines = true;
            treeView1.Nodes[0].Expand();
        }

        /// <summary>
        /// 节点上绑定的数据
        /// </summary>
        public class NodeTag
        {
            public string id { get; set; }
            public string Title { get; set; }
            public string Name { get; set; }
            public string Params { get; set; }
            public string DockState { get; set; }
            public string ModuleKey { get; set; }
        }

        private bool AddTree(XmlNode node,TreeNode pnode)
        {
            
            bool hasPermission = false;
            try
            {
                NodeTag nodeTag = new NodeTag()
                {
                    id = node.Attributes["id"].Value,
                    Name = node.Attributes["Name"].Value,
                    Params = node.Attributes["Params"].Value,
                    DockState = node.Attributes["DockState"].Value,
                    Title = node.Attributes["Title"].Value,
                    ModuleKey = node.Attributes["ModuleKey"].Value
                };
                TreeNode Node = new TreeNode();
                Node.Text = nodeTag.Title;
                Node.Name = nodeTag.id;
                Node.Tag = nodeTag;
                Node.ImageIndex = 1;
                if (!string.IsNullOrWhiteSpace(nodeTag.ModuleKey))
                {
                    hasPermission = PharmacyAuthorizeExtesions.Authorize(this, nodeTag.ModuleKey);
                }

                foreach (XmlNode snode in node.ChildNodes)
                {
                    if (AddTree(snode, Node))
                    {
                        hasPermission = true;
                    }
                }
                if (hasPermission)
                {
                    if (pnode == null)
                    {
                        treeView1.Nodes.Add(Node);
                    }
                    else
                    {
                        pnode.Nodes.Add(Node);
                    }
                }
            }
            catch (Exception ex)
            {
 
            }
            return hasPermission;
        }
         
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ImageChange(e);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // 设置显示图标的变换
            if (null == e.Node.FirstNode)
            {
                e.Node.ImageIndex = 1;
                e.Node.SelectedImageIndex = 0;
            }
            NodeTag nodeTag = (NodeTag)e.Node.Tag;
            if (!string.IsNullOrWhiteSpace(nodeTag.Name))
            {
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
        /// <summary>
        /// 变换文件夹图标
        /// </summary>
        /// <param name="e"></param>
        public void ImageChange(TreeNodeMouseClickEventArgs e)
        {
            if (null == e.Node.FirstNode)
            {
                e.Node.ImageIndex = 0;
                e.Node.SelectedImageIndex = 0;
            }
            else
            {
                if (e.Node.IsExpanded)
                {
                    e.Node.ImageIndex = 0;
                    e.Node.SelectedImageIndex = 0;
                }
                else
                {
                    e.Node.ImageIndex = 1;
                    e.Node.SelectedImageIndex = 1;
                }
            }
        }


         delegate void Mydelegate(DockContent form, DockState? state);
         Mydelegate md = null;
         
         /// <summary>
         /// 打开新窗口
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
         {
             // 设置显示图标的变换
             if(null== e.Node.FirstNode)
             {
                 e.Node.ImageIndex = 1;
                 e.Node.SelectedImageIndex = 0;
             }
             NodeTag nodeTag = (NodeTag)e.Node.Tag;
             if (!string.IsNullOrWhiteSpace(nodeTag.Name))
             {
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

         private void ShowForm(DockContent form, DockState? state)
         {
             _formMain.ShowForm(form,state);
         }
    }
}
