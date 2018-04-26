using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DataDictionary
{
    public partial class FormDictionaryUserDefinedType : BaseFunctionForm
    {
        private DictionaryUserDefinedType unit;

        //控制状态
        private FormOperation _formSate;

        //待删除或编辑的id
        private string selectId = string.Empty;
        //待删除或编辑的数据行
        private int selectRow = -1;

        private delegate void AfterStateChanged(FormOperation state);
        private new AfterStateChanged afterStateChanged = null;

        public FormOperation FormState
        {
            get
            {
                return _formSate;
            }
            set
            {
                _formSate = value;
                if (afterStateChanged != null)
                {
                    afterStateChanged(_formSate);
                }
            }
        }
        private void OnAfterStateChanged(FormOperation state)
        {
            switch (state)
            {
                #region case state of empty
                case FormOperation.Empty:
                    this.txtName.Text = "";
                    this.txtCode.Text = "";
                    this.txtDescription.Text = "";
                    this.checkBox1.Checked = false;

                    this.selectId = string.Empty;
                    this.selectRow = -1;

                    break;
                #endregion

                #region case state of edit 双击数据行，可删除或修改
                case FormOperation.Modify:


                    break;
                #endregion

                default:
                    break;
            }
        }
        public FormDictionaryUserDefinedType()
        {
            InitializeComponent();

            unit = new DictionaryUserDefinedType();
            _formSate = FormOperation.Empty;
            selectId = string.Empty;
            selectRow = -1;
            afterStateChanged += new AfterStateChanged(OnAfterStateChanged);
        }

        private void FormDictionaryUserDefinedType_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormState = FormOperation.Empty;
                RefreshDataView();
            }
            catch (Exception ex)
            {                
                MessageBox.Show("窗口启动失败！", "错误");
                Log.Error(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.requiredFieldValidator1.IsValid)
                    return;

                this.selectId = string.Empty;
                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增数据失败！", "错误");
                Log.Error(ex);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectId))
                {
                    MessageBox.Show("未选择修改数据!");
                    return;
                }

                if (!this.requiredFieldValidator1.IsValid)
                    return;

                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改数据失败！", "错误");
                Log.Error(ex);
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectId))
                {
                    MessageBox.Show("未选择要删除的数据!");
                    return;
                }

                if (MessageBox.Show("确定要删除吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //删除数据
                    unit.Id = Guid.Parse(selectId);

                    string msg = string.Empty;
                    PharmacyDatabaseService.DeleteDictionaryUserDefinedType(out msg, unit.Id);
                    if (string.IsNullOrEmpty(msg))
                    {
                        //删除成功
                        this.FormState = FormOperation.Empty;
                        //refresh datview
                        RefreshDataView();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除数据失败！", "错误");
                Log.Error(ex);
            }

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RefreshDataView()
        {
            try
            {
                string msg = string.Empty;
                //DictionaryUserDefinedType[] unitArr = PharmacyDatabaseService.QueryDictionaryUserDefinedTypes(out msg, null, null, null, false, false, false, true);
                DictionaryUserDefinedType[] unitArr = PharmacyDatabaseService.AllDictionaryUserDefinedTypes(out msg);
                if (string.IsNullOrEmpty(msg))
                {
                    this.dataGridView1.DataSource = unitArr;
                    ProcessGridViewAppearance();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("刷新数据失败！", "错误");
                Log.Error(ex);
            }
        }

        private void SaveData()
        {
            try
            {
                unit.Name = txtName.Text.Trim();
                unit.Code = txtCode.Text.Trim();
                unit.Decription = txtDescription.Text.Trim();

                unit.Enabled = checkBox1.Checked;

                string msg = string.Empty;
                if (string.IsNullOrEmpty(selectId))
                {
                    unit.Id = Guid.NewGuid();
                    PharmacyDatabaseService.AddDictionaryUserDefinedType(out msg, unit);
                }
                else
                {
                    unit.Id = Guid.Parse(selectId);
                    PharmacyDatabaseService.SaveDictionaryUserDefinedType(out msg, unit);
                }
                if (string.IsNullOrEmpty(msg))
                {
                    this.FormState = FormOperation.Empty;

                    RefreshDataView();
                }
                else
                {
                    MessageBox.Show(msg, "Error");                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存数据失败！", "错误");
                Log.Error(ex);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;

                this.FormState = FormOperation.Modify;

                int rowIndex = e.RowIndex;

                //获取选中行的id值
                //将选中行数据显示在上面的textbox 中

                this.selectId = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                this.txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                this.txtCode.Text = dataGridView1.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                this.txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells["Decription"].Value.ToString();

                if ((bool)dataGridView1.Rows[e.RowIndex].Cells["Enabled"].Value == true)
                {
                    this.checkBox1.Checked = true;
                }
                else
                {
                    this.checkBox1.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！", "错误");
                Log.Error(ex);
            }
        }

        private void ProcessGridViewAppearance()
        {
            foreach (DataGridViewColumn clm in this.dataGridView1.Columns)
            {
                switch (clm.Name)
                {
                    case "Name":
                        clm.HeaderText = "名称";
                        clm.Visible = true;
                        break;
                    case "Code":
                        clm.HeaderText = "编码";
                        clm.Visible = true;
                        break;
                    case "Decription":
                        clm.HeaderText = "描述";
                        clm.Visible = true;
                        break;
                    case "Enabled":
                        clm.HeaderText = "启用";
                        clm.Visible = true;
                        break;
                    default:
                        clm.Visible = false;
                        break;
                }
            }


        }

    }
}
