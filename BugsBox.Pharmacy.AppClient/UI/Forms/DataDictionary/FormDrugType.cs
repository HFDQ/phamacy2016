using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DataDictionary
{
    public partial class FormDrugType : BaseFunctionForm
    {       
        private DrugType unit = new DrugType();

        //控制状态
        private FormOperation _formSate = FormOperation.Empty;

        //待删除或编辑的id
        private string selectId = string.Empty;
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

        //刷新显示datagridview 数据
        private void RefreshDataView()
        {
            string msg = string.Empty;
        
            DrugType[] drugTypeArr = PharmacyDatabaseService.AllDrugTypes(out msg);

            if (string.IsNullOrEmpty(msg))
            {
                GenerateNewDataSource(drugTypeArr);                     
            }
            
        }

        private void GenerateNewDataSource(DrugType[] drugTypeArr)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Code");
            dt.Columns.Add("Decription");
            dt.Columns.Add("Enabled");
            dt.Columns.Add("DrugCategoryId");
            dt.Columns.Add("DrugCategoryName");

            DataRow row;

            foreach (DrugType type in drugTypeArr)
            {
                row = dt.NewRow();
                row["Id"] = type.Id;
                row["Name"] = type.Name;
                row["Code"] = type.Code;
                row["Decription"] = type.Decription;
                row["Enabled"] = type.Enabled;
                row["DrugCategoryId"] = type.DrugCategoryId;
                row["DrugCategoryName"] = type.DrugCategory.Name;

                dt.Rows.Add(row);

            }

            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["DrugCategoryId"].Visible = false;

            this.dataGridView1.Columns["Name"].HeaderText = "名称";
            this.dataGridView1.Columns["Code"].HeaderText = "编码";
            this.dataGridView1.Columns["Decription"].HeaderText = "描述";
            this.dataGridView1.Columns["Enabled"].HeaderText = "启用";
            this.dataGridView1.Columns["DrugCategoryName"].HeaderText = "药物分类";

        }



        public FormDrugType()
        {
            InitializeComponent();

            afterStateChanged += new AfterStateChanged(OnAfterStateChanged);
        }

        private void FormDrugType_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormState = FormOperation.Empty;

                BindCategory();
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
                MessageBox.Show("修改数据失败!", "错误");
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
                    //PharmacyDatabaseService.SaveDrugType(out msg, unit);
                    PharmacyDatabaseService.DeleteDrugType(out msg, unit.Id);
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
                MessageBox.Show("删除数据失败!", "错误");
                Log.Error(ex);
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void SaveData()
        {
            try
            {
                DrugType unit = new DrugType();

                unit.Name = txtName.Text.Trim();
                unit.Code = txtCode.Text.Trim();
                unit.Decription = txtDescription.Text.Trim();
                unit.Enabled = checkBox1.Checked;
                if (this.cbxCategory.DataSource != null)
                {
                    unit.DrugCategoryId = Guid.Parse(this.cbxCategory.SelectedValue.ToString());
                }


                string msg = string.Empty;
                if (string.IsNullOrEmpty(selectId))
                {
                    unit.Id = Guid.NewGuid();
                    PharmacyDatabaseService.AddDrugType(out msg, unit);
                }
                else
                {
                    unit.Id = Guid.Parse(selectId);
                    PharmacyDatabaseService.SaveDrugType(out msg, unit);
                }
                if (string.IsNullOrEmpty(msg))
                {
                    this.FormState = FormOperation.Empty;

                    RefreshDataView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存数据失败!", "错误");
                Log.Error(ex);
            }

        }

        private void BindCategory()
        {
            try
            {
                string msg = string.Empty;

                DrugCategory[] categoryArr = PharmacyDatabaseService.AllDrugCategorys(out msg);
                if (string.IsNullOrEmpty(msg))
                {
                    this.cbxCategory.DataSource = categoryArr;
                    this.cbxCategory.DisplayMember = "Name";
                    this.cbxCategory.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("绑定数据失败!", "错误");
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
                this.selectRow = e.RowIndex;

                this.selectId = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();

                this.txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                this.txtCode.Text = dataGridView1.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                this.txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells["Decription"].Value.ToString();

                if (Boolean.Parse(dataGridView1.Rows[e.RowIndex].Cells["Enabled"].Value.ToString()))
                {
                    this.checkBox1.Checked = true;
                }
                else
                {
                    this.checkBox1.Checked = false;
                }


                this.cbxCategory.Text = dataGridView1.Rows[e.RowIndex].Cells["DrugCategoryName"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败!", "错误");
                Log.Error(ex);
            }
        }


    }
}
