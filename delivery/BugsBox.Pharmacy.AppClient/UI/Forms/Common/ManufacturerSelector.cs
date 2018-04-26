using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class ManufacturerSelector : BaseFunctionForm
    {
        public DialogResult Result = DialogResult.None;
        public string ManufactureName = string.Empty;
        public string ManufacturePinYin = string.Empty;

        private string _searchName = string.Empty;
        private string _searchPinYin = string.Empty;
        private string _searchAddress = string.Empty;
        private string _searchCode = string.Empty;

        private List<Manufacturer> _listManufacturers = new List<Manufacturer>();
        PagerInfo pageInfo = new PagerInfo();

        public ManufacturerSelector()
        {
            InitializeComponent();
        }

        private void ManufacturerSelector_Load(object sender, EventArgs e)
        {
            try
            {
                GetListManufacturers(1, this.pagerControl1.PageSize);
                this.pagerControl1.RecordCount = pageInfo.RecordCount;
                this.pagerControl1.PageIndex = 1;
                this.dataGridView1.DataSource = _listManufacturers;
                ProcessDataViewAppearance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }

        }

        private void GetListManufacturers(int pageIndex, int pageSize)
        {
            try
            {
                _listManufacturers = PharmacyDatabaseService.QueryPagedManufacturers(
                    out pageInfo, 
                    _searchName, 
                    _searchPinYin, 
                    string.Empty,
                    _searchCode,
                    false,
                    false,
                    _searchAddress,
                    string.Empty,
                    string.Empty, 
                    pageIndex,
                    pageSize).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                _searchAddress = this.txtAddress.Text.Trim();
                _searchCode = this.txtCode.Text.Trim();
                _searchName = this.txtName.Text.Trim();
                _searchPinYin = this.txtPinYin.Text.Trim();
                
                GetListManufacturers(1, this.pagerControl1.PageSize);
                this.pagerControl1.RecordCount = pageInfo.RecordCount;
                this.pagerControl1.PageIndex = 1;
                this.dataGridView1.DataSource = _listManufacturers;
                ProcessDataViewAppearance();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.CurrentRow != null)
                {             
                    this.ManufactureName = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                    this.ManufacturePinYin = dataGridView1.CurrentRow.Cells["ShortPinYin"].Value.ToString();
                    this.Result = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("没有选择记录!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
            
        }

        private void pagerControl1_DataPaging()
        {

            GetListManufacturers(this.pagerControl1.PageIndex, this.pagerControl1.PageSize);
            
            this.dataGridView1.DataSource = _listManufacturers;
            ProcessDataViewAppearance();
        }

        private void ProcessDataViewAppearance()
        {
            foreach (DataGridViewColumn clm in this.dataGridView1.Columns)
            {
                switch (clm.Name)
                {
                    case "Name":
                        clm.HeaderText = "厂家名称";
                        clm.Visible = true;
                        break;
                    case "ShortPinYin":
                        clm.HeaderText = "简拼";
                        clm.Visible = true;
                        break;
                    case "Code":
                        clm.HeaderText = "编码";
                        clm.Visible = true;
                        break;
                    case "Address":
                        clm.HeaderText = "地址";
                        clm.Visible = true;
                        break;
                    case "Tel":
                        clm.HeaderText = "电话";
                        clm.Visible = true;
                        break;
                    case "Contact":
                        clm.HeaderText = "联系人";
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
