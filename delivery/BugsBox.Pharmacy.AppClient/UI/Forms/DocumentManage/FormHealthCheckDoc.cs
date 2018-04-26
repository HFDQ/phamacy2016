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
    public partial class FormHealthCheckDoc : BaseFunctionForm
    {
        private List<HealthCheckDocument> HealthCheckDocuments = null;
        private HealthCheckDocument healthCheckDocument = null;
        private List<HealthCheckDetail> HealthCheckDetails = null;
        private HealthCheckDetail healthCheckDetail = null;
        private BindingSource _source = new BindingSource();
        private BindingSource _source2 = new BindingSource();
        private string _searchKeyword = string.Empty;
        private int AddorEditFlag = 0;
        private List<Employee> Employees = null;
        private PagerInfo pageInfo = new PagerInfo();
        
        public FormHealthCheckDoc()
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
            this.splitContainer1.SplitterDistance = 75;
            this.splitContainer2.SplitterDistance = 75;
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

            if (this.tabControlHealthDocManage.SelectedIndex == 0)
            {
                foreach (var c in this.EditGroup.Controls)
                    if (c.GetType().Name == "TextBox")
                        ((TextBox)c).Text = "";
                this.textBoxPersonNumber.Text = "0";
                this.textBoxPassNumber.Text = "0";
                this.EditGroup.Visible = true;
                this.SearchGroup.Visible = false;
                this.splitContainer1.SplitterDistance = 155;
                healthCheckDocument = new HealthCheckDocument();
            }
            if (this.tabControlHealthDocManage.SelectedIndex == 1)
            {
                foreach (var c in this.groupBox1.Controls)
                    if (c.GetType().Name == "TextBox")
                        ((TextBox)c).Text = "";
                
                this.groupBox1.Visible = true;
                this.groupBox2.Visible = false;
                this.splitContainer2.SplitterDistance = 199;

                this.comboBoxDocName.DataSource = HealthCheckDocuments;
                comboBoxDocName.DisplayMember = "DocumentName";
                comboBoxDocName.ValueMember = "ID";
                if (comboBoxDocName.Items.Count > 0)
                {
                    comboBoxDocName.SelectedIndex = 0;

                }
                this.cmbEployeeName.DataSource = Employees;
                cmbEployeeName.DisplayMember = "Name";
                cmbEployeeName.ValueMember = "ID";
                if ( this.cmbEployeeName.Items.Count > 0)
                {
                    cmbEployeeName.SelectedIndex = 0;

                }
                healthCheckDetail = new HealthCheckDetail(); 
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (this.tabControlHealthDocManage.SelectedIndex == 0)
            {
                saveHealthDocument();

                this.EditGroup.Visible = false;
                this.SearchGroup.Visible = true;
                this.refreshBtn.Enabled = true;
                this.searchBtn.Enabled = true;
                this.SaveBtn.Enabled = false;
                this.CancelBtn.Enabled = false;
            }
            if (this.tabControlHealthDocManage.SelectedIndex == 1)
            {
                saveDocDetails();


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
                    
                HealthCheckDocuments = this.PharmacyDatabaseService.AllHealthCheckDocuments(out msg).ToList();
                initDataGridView();
                this.dataGridView2.AutoGenerateColumns = false;
                Employees = this.PharmacyDatabaseService.AllEmployees(out msg).ToList();
                HealthCheckDetails = this.PharmacyDatabaseService.AllHealthCheckDetails(out msg).ToList();
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
                if (healthCheckDocument.Id == Guid.Empty)
                {
                    this.healthCheckDocument.Id = new Guid();
                }
                this.healthCheckDocument.DocumentNumber = this.textBoxDocNumber.Text.Trim();
                this.healthCheckDocument.DocumentName = this.textBoxDocName.Text.Trim();
                this.healthCheckDocument.CheckTime = this.dateTimePickerCheck.Value.Date;
                this.healthCheckDocument.CheckContext = this.textBoxCheckContext.Text.Trim();
                this.healthCheckDocument.CheckOrganize = this.textBoxCheckOrgnize.Text.Trim();
                this.healthCheckDocument.CheckAdress = this.textBoxAddress.Text.Trim();
                this.healthCheckDocument.CheckContext = this.textBoxCheckContext.Text.Trim();
                this.healthCheckDocument.HepatitisDoctor = this.textBoxHepatitisDoctor.Text.Trim();
                this.healthCheckDocument.IssuanceOrg = this.textBoxIssuanceOrg.Text.Trim();
                this.healthCheckDocument.MedicineDoctor = this.textBoxMedicineDoctor.Text.Trim();
                this.healthCheckDocument.OptometryDoctor = this.textBoxOptometryDoctor.Text.Trim();
                this.healthCheckDocument.SkinDoctor = this.textBoxSkinDoctor.Text.Trim();
                this.healthCheckDocument.XCheckDoctor = this.textBoxXCheckDoctor.Text.Trim();
                Regex reg = new Regex(@"[^0-9]");
                if (reg.IsMatch(this.textBoxPersonNumber.Text.Trim()))
                {
                    MessageBox.Show("仅能输入数字!");
                    this.textBoxPersonNumber.Focus();
                    return;
                }
                else
                {
                    this.healthCheckDocument.CheckEployeesSum = decimal.Parse(this.textBoxPersonNumber.Text.Trim());
                }
                if (reg.IsMatch(this.textBoxPassNumber.Text.Trim()))
                {
                    MessageBox.Show("仅能输入数字!");
                    this.textBoxPassNumber.Focus();
                    return;
                }
                else
                {
                    this.healthCheckDocument.CheckPassNumber = decimal.Parse(this.textBoxPassNumber.Text.Trim());
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
                if (tabControlHealthDocManage.SelectedIndex == 0)
                {
                    if (healthCheckDocument != null)
                    {
                        this.textBoxDocNumber.Text = this.healthCheckDocument.DocumentNumber;
                        this.textBoxDocName.Text = this.healthCheckDocument.DocumentName;
                        this.dateTimePickerCheck.Value = this.healthCheckDocument.CheckTime;
                        this.textBoxCheckContext.Text = this.healthCheckDocument.CheckContext;

                        this.textBoxCheckOrgnize.Text = this.healthCheckDocument.CheckOrganize;
                        this.textBoxAddress.Text = this.healthCheckDocument.CheckAdress;
                        this.textBoxCheckContext.Text = this.healthCheckDocument.CheckContext;
                        this.textBoxHepatitisDoctor.Text = this.healthCheckDocument.HepatitisDoctor;
                        this.textBoxIssuanceOrg.Text = this.healthCheckDocument.IssuanceOrg;
                        this.textBoxMedicineDoctor.Text = this.healthCheckDocument.MedicineDoctor;
                        this.textBoxOptometryDoctor.Text = this.healthCheckDocument.OptometryDoctor;
                        this.textBoxSkinDoctor.Text = this.healthCheckDocument.SkinDoctor;
                        this.textBoxXCheckDoctor.Text = this.healthCheckDocument.XCheckDoctor;

                        this.textBoxPersonNumber.Text = this.healthCheckDocument.CheckEployeesSum.ToString("0");
                        this.textBoxPersonNumber.Text = this.healthCheckDocument.CheckPassNumber.ToString("0");
                    }
                }
                if (tabControlHealthDocManage.SelectedIndex == 1)
                {
                    if (healthCheckDetail != null)
                    {
                        Employee listitem = Employees.Where(d => d.Id == healthCheckDetail.EmployeeId).First();
                        this.cmbEployeeName.SelectedItem = listitem;
                        HealthCheckDocument listitem1 = HealthCheckDocuments.Where(d => d.Id == healthCheckDetail.DocumentId).First();
                        this.comboBoxDocName.SelectedItem = listitem1;
                        this.txtMResult.Text = healthCheckDetail.Medicine;
                        this.txtSResult.Text = healthCheckDetail.Skin;
                        this.txtHResult.Text = healthCheckDetail.Hepatitis;
                        this.txtOResult.Text = healthCheckDetail.Optometry;
                        this.txtXResult.Text = healthCheckDetail.XCheck;
                        this.textBoxConclution.Text = healthCheckDetail.CheckResult;
                        this.checkBoxPass.Checked = healthCheckDetail.IsCheckPass;
                        this.textBoxMemo.Text = healthCheckDetail.Memo;
                        this.txtCheckYear.Text = healthCheckDetail.CheckYear;
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
            if (tabControlHealthDocManage.SelectedIndex == 0)
            {
                pageSize = this.pagerControl1.PageSize;
            }
            if (tabControlHealthDocManage.SelectedIndex == 1)
            {
                pageSize = this.pagerControl2.PageSize;
            }
            GetListHealthDoc(pageIndex, pageSize);
        }

        private void GetListHealthDoc(int pageIndex, int pageSize)
        {
            try
            {
                if (this.tabControlHealthDocManage.SelectedIndex == 1)
                {
                    _searchKeyword = txtSearchKeyword2.Text.Trim();
                    string msg = string.Empty;
                    HealthCheckDetails = null;
                    HealthCheckDetails = PharmacyDatabaseService.SearchPagedHealthCheckDetailByAllStrings(out pageInfo,
                        out msg, _searchKeyword, pageIndex, pageSize).ToList();
                    initDataGridView2();
                    //this.dataGridView1.DataSource = _listDrugInfo;
                    this.pagerControl1.RecordCount = pageInfo.RecordCount;
                    this.pagerControl1.PageIndex = 1;
                }
                if (this.tabControlHealthDocManage.SelectedIndex == 0)
                {
                    _searchKeyword = txtSearchKeyword.Text.Trim();
                    string msg = string.Empty;
                    HealthCheckDocuments = null;
                    HealthCheckDocuments = PharmacyDatabaseService.SearchPagedHealthCheckDocumentByAllStrings(out pageInfo, out msg, _searchKeyword, pageIndex, pageSize).ToList();
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
            _source.DataSource = HealthCheckDocuments;
            dataGridView1.RowCount = HealthCheckDocuments.Count;

            for (int i = 0; i < HealthCheckDocuments.Count; i++)
            {
                if (i == 0)
                {
                    dataGridView1.Rows[i].Cells["ColCheck"].Value = SelectedStatus.Selected;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["ColCheck"].Value = SelectedStatus.NoSelected;
                }
                dataGridView1.Rows[i].Cells["colDocNumber"].Value = HealthCheckDocuments[i].DocumentNumber;
                dataGridView1.Rows[i].Cells["colDocName"].Value = HealthCheckDocuments[i].DocumentName;
                dataGridView1.Rows[i].Cells["colCheckTime"].Value = HealthCheckDocuments[i].CheckTime;
                dataGridView1.Rows[i].Cells["colCheckContext"].Value = HealthCheckDocuments[i].CheckContext;
                dataGridView1.Rows[i].Cells["colCheckOrgniaze"].Value = HealthCheckDocuments[i].CheckOrganize;
                dataGridView1.Rows[i].Cells["colAdress"].Value = HealthCheckDocuments[i].CheckAdress;
                dataGridView1.Rows[i].Cells["colCheckSum"].Value = HealthCheckDocuments[i].CheckEployeesSum;
                dataGridView1.Rows[i].Cells["colCheckPassNumber"].Value = HealthCheckDocuments[i].CheckPassNumber;
            }

            //dataGridView1.Sort(dataGridView1.Columns["colCode"], ListSortDirection.Ascending);
        }

        private void initDataGridView2()
        {
            _source2.DataSource = HealthCheckDetails;
            dataGridView2.RowCount = HealthCheckDetails.Count;

            for (int i = 0; i < HealthCheckDetails.Count; i++)
            {
                if (i == 0)
                {
                    dataGridView2.Rows[i].Cells["columnCheck"].Value = SelectedStatus.Selected;
                }
                else
                {
                    dataGridView2.Rows[i].Cells["columnCheck"].Value = SelectedStatus.NoSelected;
                }
               
                Employee emp = Employees.Where(d => d.Id == (Guid)(HealthCheckDetails[i].EmployeeId)).FirstOrDefault();
                if (emp == null) return;
                dataGridView2.Rows[i].Cells["colEployee"].Value = emp.Name;

                HealthCheckDocument hDoc = HealthCheckDocuments.Where(d => d.Id == (Guid)(HealthCheckDetails[i].DocumentId)).FirstOrDefault();
                if (hDoc == null) return;
                dataGridView2.Rows[i].Cells["colDocId"].Value = hDoc.DocumentName;
                dataGridView2.Rows[i].Cells["colCheckYear"].Value = HealthCheckDetails[i].CheckYear;
                dataGridView2.Rows[i].Cells["colMedicine"].Value = HealthCheckDetails[i].Medicine;
                dataGridView2.Rows[i].Cells["colSkin"].Value = HealthCheckDetails[i].Skin;
                dataGridView2.Rows[i].Cells["colXCheck"].Value = HealthCheckDetails[i].XCheck;
                dataGridView2.Rows[i].Cells["colHepatitis"].Value = HealthCheckDetails[i].Hepatitis;
                dataGridView2.Rows[i].Cells["colOptometry"].Value = HealthCheckDetails[i].Optometry;
                dataGridView2.Rows[i].Cells["colCheckResult"].Value = HealthCheckDetails[i].CheckResult;
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
            if (this.tabControlHealthDocManage.SelectedIndex == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewDisableCheckBoxCell cel = dataGridView1.Rows[i].Cells["ColCheck"] as DataGridViewDisableCheckBoxCell;
                    if (!cel.Equals(cell))
                    {
                        cel.Value = status;
                    }
                }
            }
            if (this.tabControlHealthDocManage.SelectedIndex == 1)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewDisableCheckBoxCell cel = dataGridView2.Rows[i].Cells["columnCheck"] as DataGridViewDisableCheckBoxCell;
                    if (!cel.Equals(cell))
                    {
                        cel.Value = status;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;//
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "ColCheck")
            //{
            healthCheckDocument = HealthCheckDocuments[e.RowIndex];
            //    //this.btnDetails.Enabled = true;
            //}

            DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
            if (column is DataGridViewCheckBoxColumn)
            {
                DataGridViewDisableCheckBoxCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewDisableCheckBoxCell;
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

        private void updateBtn_Click(object sender, EventArgs e)
        {
            AddorEditFlag = 2;
            this.refreshBtn.Enabled = false;
            this.searchBtn.Enabled = false;
            this.SaveBtn.Enabled = true;
            this.CancelBtn.Enabled = true;

            if (this.tabControlHealthDocManage.SelectedIndex == 0)
            {
                this.EditGroup.Visible = true;
                this.SearchGroup.Visible = false;
                this.pagerControl1.Visible = false;
                this.splitContainer1.SplitterDistance = 155;
            }
            if (this.tabControlHealthDocManage.SelectedIndex == 1)
            {
                this.groupBox1.Visible = true;
                this.groupBox2.Visible = false;
                this.pagerControl2.Visible = false;
                this.splitContainer2.SplitterDistance = 199;
                this.comboBoxDocName.DataSource = HealthCheckDocuments;
                comboBoxDocName.DisplayMember = "DocumentName";
                comboBoxDocName.ValueMember = "ID";
                if (comboBoxDocName.Items.Count > 0)
                {
                    comboBoxDocName.SelectedIndex = 0;

                }
                this.cmbEployeeName.DataSource = Employees;
                cmbEployeeName.DisplayMember = "Name";
                cmbEployeeName.ValueMember = "ID";
                if (this.cmbEployeeName.Items.Count > 0)
                {
                    cmbEployeeName.SelectedIndex = 0;

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
                    if (this.tabControlHealthDocManage.SelectedIndex == 0)
                    {
                        if (dataGridView1.CurrentRow != null)
                        {
                            //执行删除操作
                            int currRowIndex = dataGridView1.CurrentRow.Cells[0].RowIndex;
                            healthCheckDocument = HealthCheckDocuments[currRowIndex];

                            string msg = string.Empty;
                            PharmacyDatabaseService.DeleteHealthCheckDocument(healthCheckDocument.Id, out msg);

                            refreshBtn_Click(this, null);
                        }
                        else
                            MessageBox.Show("没有选择要删除的记录!");
                    }
                    if (this.tabControlHealthDocManage.SelectedIndex == 1)
                    {
                        if (dataGridView2.CurrentRow != null)
                        {
                            //执行删除操作
                            int currRowIndex = dataGridView2.CurrentRow.Cells[0].RowIndex;
                            healthCheckDetail = HealthCheckDetails[currRowIndex];

                            string msg = string.Empty;
                            PharmacyDatabaseService.DeleteHealthCheckDetail(healthCheckDetail.Id, out msg);

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

        private void saveDocDetails()
        {
            string msg = string.Empty;
            //CollectionDetails();
            try
            {
                if (AddorEditFlag == 1)
                {
                    CollectionDetails();
                    if (this.PharmacyDatabaseService.AddHealthCheckDetail(healthCheckDetail, out msg))
                    {
                        MessageBox.Show("保存成功！");
                        this.splitContainer2.SplitterDistance = 75;
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
                    healthCheckDetail.updateTime = DateTime.Now.Date;
                    
                    if (this.PharmacyDatabaseService.SaveHealthCheckDetail(healthCheckDetail, out msg))
                    {
                        MessageBox.Show("修改成功！");
                        this.splitContainer2.SplitterDistance = 75;
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
                if (healthCheckDetail.Id == Guid.Empty)
                {
                    this.healthCheckDetail.Id = new Guid();
                }
                
                this.healthCheckDetail.EmployeeId = (Guid)(this.cmbEployeeName.SelectedValue);
                this.healthCheckDetail.DocumentId = (Guid)this.comboBoxDocName.SelectedValue;
                this.healthCheckDetail.Medicine = this.txtMResult.Text.Trim();
                this.healthCheckDetail.Skin = this.txtSResult.Text.Trim();
                this.healthCheckDetail.Hepatitis = this.txtHResult.Text.Trim();
                this.healthCheckDetail.Optometry = this.txtOResult.Text.Trim();
                this.healthCheckDetail.XCheck = this.txtXResult.Text.Trim();
                this.healthCheckDetail.CheckResult = this.textBoxConclution.Text.Trim();
                this.healthCheckDetail.IsCheckPass = this.checkBoxPass.Checked;
                this.healthCheckDetail.Memo = this.textBoxMemo.Text.Trim();
                this.healthCheckDetail.CheckYear = this.txtCheckYear.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void comboBoxDocName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.comboBoxDocName.SelectedIndex >= 0)
            {
                HealthCheckDocument healthDocument = HealthCheckDocuments.Where(d=>d.Id==(Guid)(this.comboBoxDocName.SelectedValue)).First();
                this.textBoxDocNumberD.Text = healthDocument.DocumentNumber;
                this.dateTimePicker1.Value = healthDocument.CheckTime.Date;
                this.textBoxOrgnize.Text = healthDocument.CheckOrganize;
                this.textBoxMDoctor.Text = healthDocument.MedicineDoctor;
                this.textBoxSDoctor.Text = healthDocument.SkinDoctor;
                this.textBoxXDoctor.Text = healthDocument.XCheckDoctor;
                this.textBoxHDoctor.Text = healthDocument.HepatitisDoctor;
                this.textBoxOpDoctor.Text = healthDocument.OptometryDoctor;
                this.textBoxCharger.Text = healthDocument.ChargeDoctor;
                this.textBoxCheckAdress.Text = healthDocument.CheckAdress;
            }
        }

        private void saveHealthDocument()
        {
            string msg = string.Empty;
            try
            {
                if (AddorEditFlag == 1)
                {
                    CollectionData();
                    if (this.PharmacyDatabaseService.AddHealthCheckDocument(healthCheckDocument, out msg))
                    {
                        MessageBox.Show("保存成功！");
                        this.splitContainer1.SplitterDistance = 75;
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
                    healthCheckDocument.updateTime = DateTime.Now.Date;
                    if (this.PharmacyDatabaseService.SaveHealthCheckDocument(healthCheckDocument, out msg))
                    {
                        MessageBox.Show("修改成功！");
                        this.splitContainer1.SplitterDistance = 196;
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
            healthCheckDetail = HealthCheckDetails[e.RowIndex];

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
            GetListHealthDoc(pageIndex, pageSize);
        }

        private void pagerControl2_DataPaging()
        {
            int pageIndex = this.pagerControl2.PageIndex;
            int pageSize = this.pagerControl2.PageSize;
            GetListHealthDoc(pageIndex, pageSize);

        }

        private void FormHealthCheckDoc_Load(object sender, EventArgs e)
        {
            this.pagerControl1.RecordCount = pageInfo.RecordCount;
            this.pagerControl2.RecordCount = pageInfo.RecordCount;
            this.pagerControl1.PageIndex = 1;
            this.pagerControl2.PageIndex = 1;
        }
    }
}
