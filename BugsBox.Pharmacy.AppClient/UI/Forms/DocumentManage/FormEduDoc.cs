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
using System.Text.RegularExpressions;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DocumentManage
{
    public partial class FormEduDoc : BaseFunctionForm
    {
        private List<EduDocument> EduDocument = null;
        private EduDocument _eduDocument = null;
        private List<EduDetails> EduDetails = null;
        private EduDetails _eduDetails = null;
        private BindingSource _source = new BindingSource();
        private BindingSource _source2 = new BindingSource();
        private string _searchKeyword = string.Empty;
        private int AddorEditFlag = 0;
        private List<Employee> Employees = null;
        private List<Department> Departments = null;
        private PagerInfo pageInfo = new PagerInfo();

        public FormEduDoc()
        {
            InitializeComponent();
            this.EditGroup.Visible = false;
            this.SearchGroup.Visible = true;
            this.groupBox1.Visible = false;
            this.groupBox2.Visible = true;
            this.refreshBtn.Enabled = true;
            this.searchBtn.Enabled = true;
            this.SaveBtn.Enabled = false;
            this.CancelBtn.Enabled = false;
            this.splitContainer1.SplitterDistance = 66;
            this.splitContainer2.SplitterDistance = 66;
            search();
        }
        
        private void AddBtn_Click(object sender, EventArgs e)
        {
            this.refreshBtn.Enabled = false;
            this.searchBtn.Enabled = false;
            this.SaveBtn.Enabled = true;
            this.CancelBtn.Enabled = true;
            this.pagerControl1.Visible = false;
            this.pagerControl2.Visible = false;
            AddorEditFlag = 1;
            search();

            if (this.tabControl1.SelectedIndex == 0)
            {
                foreach (var c in this.EditGroup.Controls)
                    if (c.GetType().Name == "TextBox")
                        ((TextBox)c).Text = "";
                this.textBoxPersonNumber.Text = "0";
                this.textBoxPassNumber.Text = "0";
                this.EditGroup.Visible = true;
                this.SearchGroup.Visible = false;
                this.splitContainer1.SplitterDistance = 132;
                _eduDocument = new EduDocument();
            }
            if (this.tabControl1.SelectedIndex == 1)
            {
                foreach (var c in this.groupBox1.Controls)
                    if (c.GetType().Name == "TextBox")
                        ((TextBox)c).Text = "";
                
                this.groupBox1.Visible = true;
                this.groupBox2.Visible = false;
                this.splitContainer2.SplitterDistance = 145;

                this.comboBox3.DataSource = EduDocument;
                comboBox3.DisplayMember = "eduDocumentName";
                comboBox3.ValueMember = "ID";
                if (comboBox3.Items.Count > 0)
                {
                    comboBox3.SelectedIndex = 0;

                }
                //this.cmbEployeeName.DataSource = Employees;
                //cmbEployeeName.DisplayMember = "Name";
                //cmbEployeeName.ValueMember = "ID";
                //if ( this.cmbEployeeName.Items.Count > 0)
                //{
                //    cmbEployeeName.SelectedIndex = 0;

                //}
                this.cmbDepartment.DataSource = Departments;
                cmbDepartment.DisplayMember = "Name";
                cmbDepartment.ValueMember = "ID";
                if (this.cmbDepartment.Items.Count > 0)
                {
                    cmbDepartment.SelectedIndex = 0;

                }

                _eduDocument = new EduDocument(); 
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                saveEduDocument();

                this.EditGroup.Visible = false;
                this.SearchGroup.Visible = true;
                this.refreshBtn.Enabled = true;
                this.searchBtn.Enabled = true;
                this.SaveBtn.Enabled = false;
                this.CancelBtn.Enabled = false;
            }
            if (this.tabControl1.SelectedIndex == 1)
            {
                saveEduDetails();
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = true;
                this.refreshBtn.Enabled = true;
                this.searchBtn.Enabled = true;
                this.SaveBtn.Enabled = false;
                this.CancelBtn.Enabled = false;
            }
            this.pagerControl1.Visible = true;
            this.pagerControl2.Visible = true;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.EditGroup.Visible = false;
            this.SearchGroup.Visible = true;
            this.groupBox1.Visible = false;
            this.groupBox2.Visible = true;
            this.refreshBtn.Enabled = true;
            this.searchBtn.Enabled = true;
            this.SaveBtn.Enabled = false;
            this.CancelBtn.Enabled = false;
            this.splitContainer1.SplitterDistance = 75;
            this.splitContainer2.SplitterDistance = 75;
            AddorEditFlag = 0;
            this.pagerControl1.Visible = true;
            this.pagerControl2.Visible = true;
        }

        private void search()
        {
            try
            {
                string msg = string.Empty;
                this.dataGridView1.AutoGenerateColumns = false;
                EduDocument = this.PharmacyDatabaseService.AllEduDocuments(out msg).ToList();
                initDataGridView();
                this.dataGridView2.AutoGenerateColumns = false;
                Employees = this.PharmacyDatabaseService.AllEmployees(out msg).ToList();
                Departments = this.PharmacyDatabaseService.AllDepartments(out msg).ToList();
                EduDetails = this.PharmacyDatabaseService.AllEduDetailss(out msg).ToList();
                initDataGridView2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库读取出错！");
            }
            
        }

        private void CollectionData()
        {
            try
            {
                if ( _eduDocument.Id == Guid.Empty)
                {
                    this._eduDocument.Id = new Guid();
                }
                this._eduDocument.eduDocumentNumber = this.textBoxDocNumber.Text.Trim();
                this._eduDocument.eduDocumentName = this.textBoxDocName.Text.Trim();
                this._eduDocument.eduTimeStart = this.dateTimePicker2.Value.Date;
                this._eduDocument.eduTimeEnd = this.dateTimePicker3.Value.Date;

                this._eduDocument.eduOrganize = this.textBoxEduOrganize.Text.Trim();
                this._eduDocument.eduTeacher = this.textBox10.Text.Trim();
                this._eduDocument.eduContext = this.textBoxEduContext.Text.Trim();
                this._eduDocument.eduAdress = this.textBoxEduAdress.Text.Trim();
                Regex reg = new Regex(@"[^0-9]");
                if (reg.IsMatch(this.textBoxPersonNumber.Text.Trim()))
                {
                    MessageBox.Show("仅能输入数字!");
                    this.textBoxPersonNumber.Focus();
                    return;
                }
                else
                {
                    _eduDocument.eduEployeesSum = decimal.Parse(this.textBoxPersonNumber.Text.Trim());
                }
                if (reg.IsMatch(this.textBoxPassNumber.Text.Trim()))
                {
                    MessageBox.Show("仅能输入数字!");
                    this.textBoxPassNumber.Focus();
                    return;
                }
                else
                {
                    this._eduDocument.eduEployeesPassNumber = decimal.Parse(this.textBoxPassNumber.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void BindingDataToControls()
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    int currRowIndex = dataGridView1.CurrentRow.Cells[0].RowIndex;
                    _eduDocument = EduDocument[currRowIndex];
                    if (_eduDocument != null)
                    {
                        this.textBoxDocNumber.Text = _eduDocument.eduDocumentNumber;
                        this.textBoxDocName.Text = _eduDocument.eduDocumentName;
                        this.dateTimePicker2.Value = _eduDocument.eduTimeStart;
                        this.dateTimePicker3.Value = _eduDocument.eduTimeEnd;

                        this.textBoxEduOrganize.Text = _eduDocument.eduOrganize;
                        this.textBox10.Text = _eduDocument.eduTeacher;
                        this.textBoxEduContext.Text = _eduDocument.eduContext;
                        this.textBoxEduAdress.Text = _eduDocument.eduAdress;

                        this.textBoxPersonNumber.Text = this._eduDocument.eduEployeesSum.ToString("0");
                        this.textBoxPersonNumber.Text = this._eduDocument.eduEployeesPassNumber.ToString("0");
                    }
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    if (_eduDetails != null)
                    {
                        Employee listitem = Employees.Where(d => d.Id == _eduDetails.EmployeeId).First();
                        this.cmbEployeeName.SelectedItem = listitem;
                        EduDocument listitem1 = EduDocument.Where(d => d.Id == _eduDetails.DocumentId).First();
                        this.comboBox3.SelectedItem = listitem1;
                        Department listitem2 = Departments.Where(d => d.Id == listitem.DepartmentId).First();
                        this.cmbDepartment.SelectedItem = listitem2;
                        this.checkBox1.Checked = _eduDetails.IsEduPass;
                        //this.textBox8.Text = listitem1.eduDocumentName;
                        //this.textBox7.Text = listitem1.eduOrganize;
                        //this.textBox6.Text = listitem1.eduTeacher;
                        //this.textBox3.Text = listitem1.eduAdress;
                        //this.textBox2.Text = listitem1.eduContext;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("控件绑定数据出错！");
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //int pageIndex = 1;
            //int pageSize = this.pagerControl1.PageSize;
            search();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            int pageIndex = 1;
            int pageSize = 20;
            if (this.tabControl1.SelectedIndex == 0)
            {
                pageSize = this.pagerControl1.PageSize;
            }
            if (this.tabControl1.SelectedIndex == 1)
            {
                pageSize = this.pagerControl2.PageSize;
            }
            GetListEduDoc(pageIndex, pageSize);
        }

        private void GetListEduDoc(int pageIndex, int pageSize)
        {
            try
            {
                if (this.tabControl1.SelectedIndex == 1)
                {
                    _searchKeyword = txtSearchKeyword2.Text.Trim();
                    string msg = string.Empty;
                    EduDetails = null;
                    EduDetails = PharmacyDatabaseService.SearchPagedEduDetailsByAllStrings(out pageInfo,
                        out msg, _searchKeyword, pageIndex, pageSize).ToList();
                    initDataGridView2();
                    //this.dataGridView1.DataSource = _listDrugInfo;
                    this.pagerControl1.RecordCount = pageInfo.RecordCount;
                    this.pagerControl1.PageIndex = 1;
                }
                if (this.tabControl1.SelectedIndex == 0)
                {
                    _searchKeyword = txtSearchKeyword.Text.Trim();
                    string msg = string.Empty;
                    EduDocument = null;
                    EduDocument = PharmacyDatabaseService.SearchPagedEduDocumentByAllStrings(out pageInfo, out msg, _searchKeyword, pageIndex, pageSize).ToList();
                    initDataGridView();
                    //this.dataGridView1.DataSource = _listDrugInfo;
                    this.pagerControl1.RecordCount = pageInfo.RecordCount;
                    this.pagerControl1.PageIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void initDataGridView()
        {
            _source.DataSource = EduDocument;
            dataGridView1.RowCount = EduDocument.Count;

            for (int i = 0; i < EduDocument.Count; i++)
            {
                if (i == 0)
                {
                    dataGridView1.Rows[i].Cells["ColCheck"].Value = SelectedStatus.Selected;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["ColCheck"].Value = SelectedStatus.NoSelected;
                }
                dataGridView1.Rows[i].Cells["colDocNumber"].Value = EduDocument[i].eduDocumentNumber;
                dataGridView1.Rows[i].Cells["colDocName"].Value = EduDocument[i].eduDocumentName;
                dataGridView1.Rows[i].Cells["colCheckTime"].Value = EduDocument[i].eduTimeStart;
                dataGridView1.Rows[i].Cells["colCheckContext"].Value = EduDocument[i].eduContext;
                dataGridView1.Rows[i].Cells["colCheckOrgniaze"].Value = EduDocument[i].eduOrganize;
                dataGridView1.Rows[i].Cells["colAdress"].Value = EduDocument[i].eduAdress;
                dataGridView1.Rows[i].Cells["colCheckSum"].Value = EduDocument[i].eduEployeesSum;
                dataGridView1.Rows[i].Cells["colCheckPassNumber"].Value = EduDocument[i].eduEployeesPassNumber;
                dataGridView1.Rows[i].Cells["colTeacher"].Value = EduDocument[i].eduTeacher;
            }

            //dataGridView1.Sort(dataGridView1.Columns["colCode"], ListSortDirection.Ascending);
        }

        private void initDataGridView2()
        {
            _source2.DataSource = EduDetails;
            dataGridView2.RowCount = EduDetails.Count;

            for (int i = 0; i < EduDetails.Count; i++)
            {
                if (i == 0)
                {
                    dataGridView2.Rows[i].Cells["colRadioButton"].Value = SelectedStatus.Selected;
                }
                else
                {
                    dataGridView2.Rows[i].Cells["colRadioButton"].Value = SelectedStatus.NoSelected;
                }

                Employee emp = Employees.Where(d => d.Id == EduDetails[i].EmployeeId).First();
                EduDocument hDoc = EduDocument.Where(d => d.Id == EduDetails[i].DocumentId).First();
                Department dpmt = Departments.Where(d => d.Id == emp.DepartmentId).First();

                dataGridView2.Rows[i].Cells["colEmployee"].Value = emp.Name;
                dataGridView2.Rows[i].Cells["colDepartment"].Value = dpmt.Name;
                dataGridView2.Rows[i].Cells["colDNo"].Value = hDoc.eduDocumentName;
                
                dataGridView2.Rows[i].Cells["colDName"].Value = this.textBox8.Text.Trim();
                dataGridView2.Rows[i].Cells["colDTime"].Value = this.dateTimePicker1.Value.Date;
                dataGridView2.Rows[i].Cells["colContext"].Value = this.textBox2.Text.Trim();
                dataGridView2.Rows[i].Cells["colPass"].Value = EduDetails[i].IsEduPass;
                dataGridView2.Rows[i].Cells["colEduOgn"].Value = this.textBox7.Text.Trim();
                dataGridView2.Rows[i].Cells["colAddress"].Value = this.textBox3.Text.Trim();
            }
        }

        private void SetRadioButtonValue(DataGridViewDisableCheckBoxCell cell)
        {
            SelectedStatus status = (SelectedStatus)cell.Value;
            if (status == SelectedStatus.Selected)
            {
                status = SelectedStatus.NoSelected;
            }
            else
            {
                status = SelectedStatus.Selected;
            }
            if (this.tabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewDisableCheckBoxCell cel = dataGridView1.Rows[i].Cells["colCheck"] as DataGridViewDisableCheckBoxCell;
                    if (!cel.Equals(cell))
                    {
                        cel.Value = status;
                    }
                }
            }
            if (this.tabControl1.SelectedIndex == 1)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewDisableCheckBoxCell cel = dataGridView2.Rows[i].Cells["colRadioButton"] as DataGridViewDisableCheckBoxCell;
                    if (!cel.Equals(cell))
                    {
                        cel.Value = status;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            AddorEditFlag = 2;
            this.refreshBtn.Enabled = false;
            this.searchBtn.Enabled = false;
            this.SaveBtn.Enabled = true;
            this.CancelBtn.Enabled = true;

            if (this.tabControl1.SelectedIndex == 0)
            {
                this.EditGroup.Visible = true;
                this.SearchGroup.Visible = false;
                this.pagerControl1.Visible = false;
                this.splitContainer1.SplitterDistance = 155;
            }
            if (this.tabControl1.SelectedIndex == 1)
            {
                this.groupBox1.Visible = true;
                this.groupBox2.Visible = false;
                this.pagerControl2.Visible = false;
                this.splitContainer2.SplitterDistance = 199;

                this.comboBox3.DataSource = EduDocument;
                comboBox3.DisplayMember = "DocumentName";
                comboBox3.ValueMember = "ID";
                if (comboBox3.Items.Count > 0)
                {
                    comboBox3.SelectedIndex = 0;

                }
                //this.cmbEployeeName.DataSource = Employees;
                //cmbEployeeName.DisplayMember = "Name";
                //cmbEployeeName.ValueMember = "ID";
                //if (this.cmbEployeeName.Items.Count > 0)
                //{
                //    cmbEployeeName.SelectedIndex = 0;

                //}
                this.cmbDepartment.DataSource = Departments;
                cmbDepartment.DisplayMember = "Name";
                cmbDepartment.ValueMember = "ID";
                if (this.cmbDepartment.Items.Count > 0)
                {
                    cmbDepartment.SelectedIndex = 0;

                }

            }
            BindingDataToControls();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (this.tabControl1.SelectedIndex == 0)
                    {
                        if (dataGridView1.CurrentRow != null)
                        {
                            //执行删除操作
                            int currRowIndex = dataGridView1.CurrentRow.Cells[0].RowIndex;
                            _eduDocument = EduDocument[currRowIndex];

                            string msg = string.Empty;
                            PharmacyDatabaseService.DeleteEduDocument(_eduDocument.Id, out msg);

                            refreshBtn_Click(this, null);
                        }
                        else
                            MessageBox.Show("没有选择要删除的记录!");
                    }
                    if (this.tabControl1.SelectedIndex == 1)
                    {
                        if (dataGridView2.CurrentRow != null)
                        {
                            //执行删除操作
                            int currRowIndex = dataGridView2.CurrentRow.Cells[0].RowIndex;
                            _eduDetails = EduDetails[currRowIndex];

                            string msg = string.Empty;
                            PharmacyDatabaseService.DeleteEduDetails(_eduDetails.Id, out msg);

                            refreshBtn_Click(this, null);
                        }
                        else
                            MessageBox.Show("没有选择要删除的记录!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void saveEduDetails()
        {
            string msg = string.Empty;
            //CollectionDetails();
            try
            {
                if (AddorEditFlag == 1)
                {
                    CollectionDetails();
                    if (this.PharmacyDatabaseService.AddEduDetails(_eduDetails, out msg))
                    {
                        MessageBox.Show("保存成功！");
                        this.splitContainer2.SplitterDistance = 66;
                        refreshBtn_Click(this, null);
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                        return;
                    }
                }
                if (AddorEditFlag == 2)
                {
                    CollectionDetails();
                    _eduDetails.updateTime = DateTime.Now.Date;
                    
                    if (this.PharmacyDatabaseService.SaveEduDetails(_eduDetails, out msg))
                    {
                        MessageBox.Show("修改成功！");
                        this.splitContainer2.SplitterDistance = 66;
                        refreshBtn_Click(this, null);
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                        return;
                    }
                }
                AddorEditFlag = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CollectionDetails()
        {
            try
            {
                if (this._eduDetails == null)
                {
                    _eduDetails = new EduDetails();
                    this._eduDetails.Id = new Guid();
                }

                this._eduDetails.EmployeeId = (Guid)(this.cmbEployeeName.SelectedValue);
                this._eduDetails.DocumentId = (Guid)this.comboBox3.SelectedValue;
                this._eduDetails.IsEduPass = this.checkBox1.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void saveEduDocument()
        {
            string msg = string.Empty;
            try
            {
                if (AddorEditFlag == 1)
                {
                    CollectionData();
                    if (this.PharmacyDatabaseService.AddEduDocument(_eduDocument, out msg))
                    {
                        MessageBox.Show("保存成功！");
                        this.splitContainer1.SplitterDistance = 66;
                        refreshBtn_Click(this, null);
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                        return;
                    }
                }
                if (AddorEditFlag == 2)
                {
                    CollectionData();
                    this._eduDocument.updateTime = DateTime.Now.Date;
                    if (this.PharmacyDatabaseService.SaveEduDocument(_eduDocument, out msg))
                    {
                        MessageBox.Show("修改成功！");
                        this.splitContainer1.SplitterDistance = 145;
                        refreshBtn_Click(this, null);
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                        return;
                    }
                }
                AddorEditFlag = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtMResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;//
            _eduDetails = EduDetails[e.RowIndex];

            DataGridViewColumn column = dataGridView2.Columns[e.ColumnIndex];
            if (column is DataGridViewCheckBoxColumn)
            {
                DataGridViewDisableCheckBoxCell cell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewDisableCheckBoxCell;
                if (!cell.Enabled)
                {
                    return;
                }
                if ((SelectedStatus)cell.Value == SelectedStatus.NoSelected)
                {
                    cell.Value = SelectedStatus.Selected;
                    SetRadioButtonValue(cell);
                }
                else
                {
                    cell.Value = SelectedStatus.NoSelected;
                }
            }
        }

        private void tabControlHealthDocManage_Selected(object sender, TabControlEventArgs e)
        {
                this.SaveBtn.Enabled = false;
                this.CancelBtn.Enabled = false;
                this.pagerControl1.Visible = true;
                this.pagerControl2.Visible = true;
        }

        private void pagerControl1_DataPaging()
        {
            int pageIndex = this.pagerControl1.PageIndex;
            int pageSize = this.pagerControl1.PageSize;
            GetListEduDoc(pageIndex, pageSize);
        }

        private void pagerControl2_DataPaging()
        {
            int pageIndex = this.pagerControl2.PageIndex;
            int pageSize = this.pagerControl2.PageSize;
            GetListEduDoc(pageIndex, pageSize);

        }

        private void FormEduDoc_Load(object sender, EventArgs e)
        {
            this.pagerControl1.RecordCount = pageInfo.RecordCount;
            this.pagerControl2.RecordCount = pageInfo.RecordCount;
            this.pagerControl1.PageIndex = 1;
            this.pagerControl2.PageIndex = 1;
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.comboBox3.SelectedIndex >= 0)
            {
                EduDocument eduDocument = EduDocument.Where(d => d.Id == (Guid)(this.comboBox3.SelectedValue)).First();
                this.textBox8.Text = eduDocument.eduDocumentNumber;
                this.dateTimePicker1.Value = eduDocument.eduTimeStart.Date;
                this.textBox7.Text = eduDocument.eduOrganize;
                this.textBox6.Text = eduDocument.eduTeacher;
                this.textBox3.Text = eduDocument.eduAdress;
                this.textBox2.Text = eduDocument.eduContext;
            }
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<Employee> emps = null;
            Guid dptId = (Guid)this.cmbDepartment.SelectedValue;
            emps = Employees.Where(d => d.DepartmentId == dptId).ToList();
            this.cmbEployeeName.DataSource = emps;
            cmbEployeeName.DisplayMember = "Name";
            cmbEployeeName.ValueMember = "ID";
            if (this.cmbEployeeName.Items.Count > 0)
            {
                cmbEployeeName.SelectedIndex = 0;
            }
        }
    }
}
