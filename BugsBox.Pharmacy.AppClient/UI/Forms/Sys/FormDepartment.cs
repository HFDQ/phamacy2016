using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Common;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Business.Models;
using System.Xml;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Sys
{
    public partial class FormDepartment : BaseFunctionForm
    {

        string proname;
        private bool flag;
        private Department[] dataList = null;
        private List<Employee> employees = null;
        private Department selectedDept = null;

        private Department _deptmentInfo = new Department();
        public Department DepartmentInfo
        {
            get
            {
                return _deptmentInfo;
            }
            set
            {
                _deptmentInfo = value;
            }
        }

        public FormDepartment()
        {
            InitializeComponent();
            intEployeeDatagrid();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                try
                {
                    string message = string.Empty;

                    InitDeptTreeList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error(ex);
                }
            }
        }


        protected void LoadDataFromServer()
        {
            string msg = string.Empty;
            dataList = PharmacyDatabaseService.AllDepartments(out msg).ToArray();
            //dataList.OrderBy(d=>d.Code);
            //foreach (var s in dataList.OrderBy(d => d.Code))
            //    Console.WriteLine(s.Name);
            if (dataList == null && msg.Length > 0)
                throw new Exception("未获取部门信息！！！");
        }

        public class MyComparer: IComparer<Department>
        {          
            public int Compare(Department x, Department y)     
            {         
                return(x.Code.CompareTo(y.Code));     
            } 
        } 


        /// <summary>
        /// 初始化部门Treelist
        /// </summary>
        private void InitDeptTreeList()
        {
            LoadDataFromServer();
            foreach (Department dept in dataList)
            {
                //部门根节点
                if (dept.DepartmentId == Guid.Empty)
                {
                    this.treeViewDepartment.BeginUpdate();

                    this.treeViewDepartment.Nodes.Clear();
                    TreeNode rootNode = new TreeNode();
                    rootNode.Tag = dept;
                    rootNode.Text = dept.Name;
                    rootNode.ToolTipText = dept.Decription;
                    rootNode.ImageIndex = 0;
                    rootNode.SelectedImageIndex = 0;
                    treeViewDepartment.Nodes.Add(rootNode);

                    BindChildDepartment(rootNode);
                    this.treeViewDepartment.EndUpdate();
                    rootNode.ExpandAll();
                    //return;

                }
            }



        }


        /// <summary>
        /// 递归绑定子部门
        /// </summary>
        /// <param name="fNode"></param>
        private void BindChildDepartment(TreeNode fNode)
        {
            Department dept = (Department)fNode.Tag;//父节点数据关联的数据行
            Guid parentId = dept.Id; //父节点ID
            bool isParent = false;
            List<Department> subDeptList = new List<Department>();
            
            string msg = string.Empty;
            subDeptList = PharmacyDatabaseService.GetSubDepartments(out msg, parentId).ToList();
            //Array.Sort(subDeptList,(d1,d2)=>d1.);
            subDeptList.Sort(new MyComparer());
            //foreach (var s in subDeptList)
            //     Console.WriteLine(s.Name); 
            foreach (Department item in subDeptList)
            {
                isParent = true;
                TreeNode node = new TreeNode();
                node.Tag = item;
                node.Text = item.Name;
                node.ToolTipText = item.Decription;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                //添加子节点
                fNode.Nodes.Add(node);
                //递归
                BindChildDepartment(node);
            }

            if (isParent)
                dept.Decription = "Parent";
            else
                dept.Decription = "Child";
        }


        /// <summary>
        /// 创建右键菜单
        /// </summary>
        /// <param name="p"></param>
        private void CreatMenu(string p)
        {
            switch (p)
            {
                case "Parent":
                    {
                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem AddUser = new ToolStripMenuItem();
                        AddUser.Name = "添加";
                        AddUser.Text = "添加";
                        AddUser.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        AddUser.Click += new System.EventHandler(AddDept_Click);

                        ToolStripMenuItem ModifyUser = new ToolStripMenuItem();
                        ModifyUser.Name = "修改";
                        ModifyUser.Text = "修改";
                        ModifyUser.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        ModifyUser.Click += new System.EventHandler(ModifyDept_Click);
                        contextMenuStrip.Items.AddRange(
                     new System.Windows.Forms.ToolStripItem[] { 
                           AddUser,ModifyUser       
                        });
                    }
                    break;
                case "Child":
                    {
                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem AddUser = new ToolStripMenuItem();
                        AddUser.Name = "添加";
                        AddUser.Text = "添加";
                        AddUser.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        AddUser.Click += new System.EventHandler(AddDept_Click);

                        ToolStripMenuItem DeleteUser = new ToolStripMenuItem();
                        DeleteUser.Name = "删除";
                        DeleteUser.Text = "删除";
                        DeleteUser.Click += new System.EventHandler(DeleteDept_Click);

                        ToolStripMenuItem ModifyUser = new ToolStripMenuItem();
                        ModifyUser.Name = "修改";
                        ModifyUser.Text = "修改";
                        ModifyUser.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        ModifyUser.Click += new System.EventHandler(ModifyDept_Click);
                        contextMenuStrip.Items.AddRange(
                     new System.Windows.Forms.ToolStripItem[] { 
                          AddUser,DeleteUser,ModifyUser     
                        });
                    }
                    break;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewDepartment_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (e)
            //departmentLinkEmployee();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewDepartment_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (flag)
            {
                e.Cancel = flag;
            }
            flag = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewDepartment_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (flag)
            {
                e.Cancel = flag;
            }
            flag = false;
        }

        /// <summary>
        /// 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewDepartment_Click(object sender, EventArgs e)
        {
            string msg=string.Empty;

            try
            {
                object nodeObj = this.treeViewDepartment.GetNodeAt(this.treeViewDepartment.PointToClient(Cursor.Position));
                if (nodeObj != null)
                {
                    if ((nodeObj as TreeNode).Bounds.Contains(this.treeViewDepartment.PointToClient(Cursor.Position)))
                    {
                        flag = true;
                    }

                }
            }
            catch (Exception ex)
            {
                dataList = PharmacyDatabaseService.AllDepartments(out msg);     
            }
        }


        /// <summary>
        /// 部门删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDept_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("你确定要删除吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (this.treeViewDepartment.SelectedNode == null)
                    {
                        return;
                    }
                    Department dept = (Department)treeViewDepartment.SelectedNode.Tag;
                    string msg = string.Empty;

                    if (PharmacyDatabaseService.DeleteDepartment(out msg, dept.Id))
                    {
                        this.treeViewDepartment.Nodes.Remove(this.treeViewDepartment.SelectedNode);
                        InitDeptTreeList();
                        this.treeViewDepartment.ExpandAll();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 部门修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyDept_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectNode = this.treeViewDepartment.SelectedNode;
                Department selectedDept = (Department)selectNode.Tag;
                selectedDept.Decription = selectNode.ToolTipText;
                FormDepartmentEdit form = new FormDepartmentEdit(FormOperation.Modify, this, selectedDept);
           
                _deptmentInfo = null;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (_deptmentInfo != null)
                    {
                        string msg = string.Empty;
                        PharmacyDatabaseService.SaveDepartment(out msg, _deptmentInfo);
                        InitDeptTreeList();
                        this.treeViewDepartment.ExpandAll();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 部门新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDept_Click(object sender, EventArgs e)
        {
            try
            {
                FormDepartmentEdit form = new FormDepartmentEdit(FormOperation.Add, this);
                _deptmentInfo = null;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (_deptmentInfo != null)
                    {
                        string msg = string.Empty;
                        TreeNode selectNode = this.treeViewDepartment.SelectedNode;
                        Department selectedDept = (Department)selectNode.Tag;
                        _deptmentInfo.DepartmentId = selectedDept.Id;
                        TreeNode node = new TreeNode(_deptmentInfo.Name);
                        node.Tag = _deptmentInfo;
                        selectNode.Nodes.Add(node);
                        PharmacyDatabaseService.AddDepartment(out msg, _deptmentInfo);
                        InitDeptTreeList();
                        this.treeViewDepartment.ExpandAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 鼠标滑动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewDepartment_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Point mpt = new Point(e.X, e.Y);
                TreeNode TreeClickNode = this.treeViewDepartment.GetNodeAt(mpt);
                this.treeViewDepartment.SelectedNode = TreeClickNode;
                proname = TreeClickNode.Text;

                if (TreeClickNode != null)
                {
                    Department dept = (Department)TreeClickNode.Tag;
                    CreatMenu(dept.Decription);
                    if (e.Button == MouseButtons.Right)
                    {
                        this.contextMenuStrip.Show(this.treeViewDepartment, mpt);
                    }
                    if (e.Button == MouseButtons.Left)
                    {
                        departmentLinkEmployee();
                    }
                }
            }
            catch(Exception ex)
            {
                //Log.Error(ex);
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 部门刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picButton_Click(object sender, EventArgs e)
        {
            try
            {
                InitDeptTreeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                InitDeptTreeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void intEployeeDatagrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            string msg = string.Empty;
            employees = this.PharmacyDatabaseService.AllEmployees(out msg).ToList();
            dataGridView1.DataSource = employees;
            ProcessGridViewAppearance();
        }

        private void ProcessGridViewAppearance()
        {
            foreach (DataGridViewColumn clm in this.dataGridView1.Columns)
            {
                switch (clm.HeaderText)
                {
                    case "姓名":
                        clm.Visible = true;
                        break;
                    case "职工号":
                        clm.Visible = true;
                        break;
                    case "职务":
                        clm.Visible = true;
                        break;
                    case "职称":
                        clm.Visible = true;
                        break;
                    case "在职":
                        clm.Visible = true;
                        break;
                    case "有效":
                        clm.Visible = true;
                        break;
                    case "合同到期日":
                        clm.Visible = true;
                        break;
                    default:
                        clm.Visible = false;
                        break;
                }
            }


        }

        private void treeViewDepartment_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void departmentLinkEmployee()
        {
            string msg = string.Empty;
            TreeNode selectNode = this.treeViewDepartment.SelectedNode;

            try
            {
                if (selectNode != null)
                {
                    selectedDept = (Department)selectNode.Tag;
                    selectedDept.Decription = selectNode.ToolTipText;
                
                    //MessageBox.Show(selectedDept.Id.ToString());
                    if (selectedDept.DepartmentId == Guid.Empty)
                    {
                        employees = this.PharmacyDatabaseService.AllEmployees(out msg).ToList();
                    }
                    else
                    {
                        employees = this.PharmacyDatabaseService.AllEmployees(out msg).Where(d => d.DepartmentId == this.selectedDept.Id).ToList();
                    }
                    this.dataGridView1.DataSource = employees;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
