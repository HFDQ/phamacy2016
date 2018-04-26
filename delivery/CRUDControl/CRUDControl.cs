using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRUDControl
{
    public partial class CRUDControl : UserControl
    {
        private bool _isGeneated = false;
        public CRUDControl()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
           
            this.btnAdd.Click += new System.EventHandler(this.OnButtonAddClick); 
        }
       
        private void SetEditMode(bool isEdit)
        {
            tabPageEdit.Show();
            btnAdd.Enabled = !isEdit;
            btnDelete.Enabled = !isEdit;
            btnModify.Enabled = !isEdit;
            btnBrowse.Enabled = !isEdit;
            btnSave.Enabled = isEdit;
            btnCancel.Enabled = isEdit;
            if(isEdit)
                tabControl1.SelectedIndex = 1;
            else
                tabControl1.SelectedIndex = 0;
        }

        private void ShowData(bool bindData)
        {
            if (!_isGeneated)
            {
                Utility.Generate_Controls(dataGridView1, tabPageEdit);
                _isGeneated = true;
            }

            if (bindData && dataGridView1.CurrentRow != null)
            {
                Utility.AssignValueToControl(dataGridView1.CurrentRow, tabPageEdit);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowData(false);
            SetEditMode(true);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                SetEditMode(true);
                ShowData(true);
            }
            else
                MessageBox.Show("没有选择要修改的记录!");
           
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SetEditMode(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetEditMode(false);
        }

        [Browsable(true), Description("DataGridView 数据源"), Category("自定义")]
        public object DataGridViewDataSource
        {
            get { return this.dataGridView1.DataSource; }
            set
            {
                this.dataGridView1.DataSource = value;
                //隐藏字段
                if (this.dataGridView1.Columns["Id"] != null)
                    this.dataGridView1.Columns["Id"].Visible = false;
                if (this.dataGridView1.Columns["Deleted"] != null)
                    this.dataGridView1.Columns["Deleted"].Visible = false;
                if (this.dataGridView1.Columns["DeleteTime"] != null)
                    this.dataGridView1.Columns["DeleteTime"].Visible = false;
                //设置中文字段名
                if (HeaderTexts != null)
                {
                    foreach (var h in HeaderTexts)
                    {
                        this.dataGridView1.Columns[h.Key].HeaderText = h.Value;
                    }
                }

            }
        }

        [Browsable(true), Description("选择按钮单击事件。"), Category("操作")]
        public event EventHandler ButtonAddClick; protected virtual void OnButtonAddClick(object sender, EventArgs e) { if (ButtonAddClick != null) ButtonAddClick(this, e); }


        [Browsable(true), Description("DataGridView中文标题"), Category("自定义")]
        public Dictionary<string, string> HeaderTexts
        {
            get;
            set;
        }
    }
}
