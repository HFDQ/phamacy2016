using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class FormSupplyUnitsSelector : BaseFunctionForm
    {
        public List<SupplyUnit> result = null;
        public string SupplyName = string.Empty;
        public Guid SupplyId = Guid.Empty;
        private Guid drugInfoGuid = Guid.Empty;
        private List<SupplyUnit> data;
        private string msg = string.Empty;
        private List<SupplyUnitSalesman> supplyUnitSalesman;

        /// <summary>
        /// 查供应商
        /// </summary>
        public FormSupplyUnitsSelector()
        {
            InitializeComponent();
            supplyUnitSalesman = PharmacyDatabaseService.AllSupplyUnitSalesmans(out msg).ToList();
            BindBuessess();
            BindDataForAllSupply();
        }

        /// <summary>
        /// 根据药品查供应商
        /// </summary>
        /// <param name="DrugInfoGuid">药品ID</param>
        public FormSupplyUnitsSelector(Guid DrugInfoGuid)
        {
            InitializeComponent();
            drugInfoGuid = DrugInfoGuid;
            supplyUnitSalesman = PharmacyDatabaseService.AllSupplyUnitSalesmans(out msg).ToList();
            BindBuessess();
            BindData();
            
        }

        private void BindBuessess()
        {
            try
            {
                List<BusinessScopeCategory> bs = this.PharmacyDatabaseService.AllBusinessScopeCategorys(out msg).ToList();
                bs.Insert(0, new BusinessScopeCategory() { Code = "all", Name = "所有" });
                cbJYFW.DataSource = bs;
                cbJYFW.DisplayMember = "Name";
                cbJYFW.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void BindData()
        {
            try
            {
                data = this.PharmacyDatabaseService.GetSupplyUnitForSupplyUnitSelector(out msg, drugInfoGuid, txtName.Text, txtPY.Text, new string[] { cbJYFW.SelectedValue.ToString() }).ToList();

                DrugInfo druginfo = this.PharmacyDatabaseService.GetDrugInfo(out msg,drugInfoGuid);
                string scopeCode = druginfo.BusinessScopeCode;
                var bScope = this.PharmacyDatabaseService.AllBusinessScopes(out msg);
                var bScopeIDList = from i in bScope where i.Name.Contains(scopeCode) select i.Id ;
                Guid scopeID = bScopeIDList.FirstOrDefault();

                var gmspList = this.PharmacyDatabaseService.AllGMSPLicenseBusinessScopes(out msg);
                
                var gspLiscenceIDs = from i in gmspList where i.BusinessScopeId == scopeID select i;

                var supplayUnitsList = gspLiscenceIDs.SelectMany(e =>data.Where(eo => eo.GSPLicenseId == e.GSPLicenseId));

                data = supplayUnitsList.ToList();

                dataGridView1.Rows.Clear();
                DataGridViewRow dr;
                
                foreach (var r in data)
                {
                    dr = new DataGridViewRow();
                    dr.CreateCells(this.dataGridView1);
                    dr.Cells[0].Value = r.Name;
                    dr.Cells[1].Value = r.Code;
                    dr.Cells[5].Value = r.Id;
                    var v = supplyUnitSalesman.Where(d => d.SupplyUnitId == r.Id);
                    if (v.Count() > 0)
                    {                                                
                        DataGridViewComboBoxCell c = dr.Cells[2] as DataGridViewComboBoxCell;
                        DataTable dt=new DataTable();
                        dt.Columns.Add("id");
                        dt.Columns.Add("name");
                        DataRow rr;
                        foreach(var a in v)
                        {
                            rr=dt.NewRow();
                            rr[0]=a.Id;
                            rr[1]=a.Name;
                            dt.Rows.Add(rr);
                        }
                        c.ValueMember = "id";
                        c.DisplayMember = "name";
                        c.DataSource = dt;
                        
                        SupplyUnitSalesman susm = v.First();
                        c.Style.NullValue = susm.Name;
                        dr.Cells[3].Value = susm.Tel;
                        dr.Cells[4].Value = susm.BusinessScopes;
                        dr.Cells[4].ToolTipText = susm.BusinessScopes;
                    }
                    dataGridView1.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void ProcessGridViewAppearance()
        {
            

#region
            //foreach (DataGridViewColumn clm in this.dataGridView1.Columns)
            //{
            //    switch (clm.Name)
            //    {
            //        case "Name":
            //            clm.HeaderText = "供货单位名称";
            //            clm.Visible = true;
            //            break;
            //        case "Code":
            //            clm.HeaderText = "编码";
            //            clm.Visible = true;
            //            break;
            //        case "ContactName":
            //            clm.HeaderText = "销售员";
            //            clm.Visible = true;
            //            break;
            //        case "ContactTel":
            //            clm.HeaderText = "销售员联系电话";
            //            clm.Visible = true;
            //            break;
            //        case "BusinessScope":
            //            clm.HeaderText = "生产经营范围";
            //            clm.Visible = true;
            //            break;
            //        case "采购价":
            //            clm.HeaderText = "采购价";
            //            clm.Visible = true;
            //            break;
            //        default:
            //            clm.Visible = false;
            //            break;
            //    }

            //}
#endregion
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 ||e.RowIndex==-1 || e.ColumnIndex==-1) return;
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;

            SupplyId = Guid.Parse(this.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString());
            SupplyName = this.dataGridView1.Rows[rowIndex].Cells["nameSupply"].Value.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void btnHistorySuplyUnit_Click(object sender, EventArgs e)
        {
            try
            {
                string msg=string.Empty;
                List<Business.Models.PurchaseOrderDetailEntity> pe= this.PharmacyDatabaseService.GetPurchaseHistoryForDrugInfo(out msg, drugInfoGuid).ToList();
                
                dataGridView1.Rows.Clear();
                DataGridViewRow dr;

                foreach (var r in pe)
                {
                    dr = new DataGridViewRow();
                    dr.CreateCells(this.dataGridView1);
                    dr.Cells[0].Value = r.SupplyUnitName;
                    dr.Cells[1].Value = r.SupplyUnitCode;
                    dr.Cells[5].Value = r.SupplyUnitId;
                    var v = supplyUnitSalesman.Where(d => d.SupplyUnitId == r.SupplyUnitId);
                    if (v.Count() > 0)
                    {
                        DataGridViewComboBoxCell c = dr.Cells[2] as DataGridViewComboBoxCell;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("id");
                        dt.Columns.Add("name");
                        DataRow rr;
                        foreach (var a in v)
                        {
                            rr = dt.NewRow();
                            rr[0] = a.Id;
                            rr[1] = a.Name;
                            dt.Rows.Add(rr);
                        }
                        c.ValueMember = "id";
                        c.DisplayMember = "name";
                        c.DataSource = dt;

                        SupplyUnitSalesman susm = v.First();
                        c.Style.NullValue = susm.Name;
                        dr.Cells[3].Value = susm.Tel;
                        dr.Cells[4].Value = susm.BusinessScopes;
                        dr.Cells[4].ToolTipText = susm.BusinessScopes;
                    }
                    dataGridView1.Rows.Add(dr);
                }
                
               

                //ProcessGridViewAppearance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                Guid supplyUnitId = Guid.Parse(this.dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
                FormSupplyUnitMansSelector selector = new FormSupplyUnitMansSelector(supplyUnitId);
                selector.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一条供应商纪录");
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView1.CurrentCell.ColumnIndex == 2 && this.dataGridView1.CurrentCell.RowIndex != -1)
            {
                if ((e.Control as ComboBox).Items.Count > 0)
                {
                    (e.Control as ComboBox).SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
                }
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string guid = ((ComboBox)sender).SelectedValue.ToString();
            Guid salesmanGuid=new Guid(guid);
            if (supplyUnitSalesman.Count <= 0) return;
            var g = supplyUnitSalesman.Where(r => r.Id == salesmanGuid).First();
            DataGridViewRow dr = dataGridView1.CurrentRow;
            dr.Cells[3].Value = g.Tel;
            dr.Cells[4].Value = g.BusinessScopes;
            dr.Cells[4].ToolTipText = g.BusinessScopes;
            ((ComboBox)sender).SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
        }

        private void BindDataForAllSupply()
        {
            try
            {
                string msg = string.Empty;
                data = this.PharmacyDatabaseService.GetSupplyUnitForSupplyUnitSelector(out msg, drugInfoGuid, txtName.Text, txtPY.Text, new string[] { cbJYFW.SelectedValue.ToString() }).ToList();
                data = this.PharmacyDatabaseService.AllSupplyUnits(out msg).ToList();
                this.dataGridView1.DataSource = data;
                //DrugInfo druginfo = this.PharmacyDatabaseService.GetDrugInfo(out msg, drugInfoGuid);
                //string scopeCode = druginfo.BusinessScopeCode;
                //var bScope = this.PharmacyDatabaseService.AllBusinessScopes(out msg);
                //var bScopeIDList = from i in bScope where i.Name.Contains(scopeCode) select i.Id;
                //Guid scopeID = bScopeIDList.FirstOrDefault();

                //var gmspList = this.PharmacyDatabaseService.AllGMSPLicenseBusinessScopes(out msg);

                //var gspLiscenceIDs = from i in gmspList where i.BusinessScopeId == scopeID select i;

                //var supplayUnitsList = gspLiscenceIDs.SelectMany(e => data.Where(eo => eo.GSPLicenseId == e.GSPLicenseId));

                //data = supplayUnitsList.ToList();

                //dataGridView1.Rows.Clear();
                //DataGridViewRow dr;

                //foreach (var r in data)
                //{
                //    dr = new DataGridViewRow();
                //    dr.CreateCells(this.dataGridView1);
                //    dr.Cells[0].Value = r.Name;
                //    dr.Cells[1].Value = r.Code;
                //    dr.Cells[5].Value = r.Id;
                //    var v = supplyUnitSalesman.Where(d => d.SupplyUnitId == r.Id);
                //    if (v.Count() > 0)
                //    {
                //        DataGridViewComboBoxCell c = dr.Cells[2] as DataGridViewComboBoxCell;
                //        DataTable dt = new DataTable();
                //        dt.Columns.Add("id");
                //        dt.Columns.Add("name");
                //        DataRow rr;
                //        foreach (var a in v)
                //        {
                //            rr = dt.NewRow();
                //            rr[0] = a.Id;
                //            rr[1] = a.Name;
                //            dt.Rows.Add(rr);
                //        }
                //        c.ValueMember = "id";
                //        c.DisplayMember = "name";
                //        c.DataSource = dt;

                //        SupplyUnitSalesman susm = v.First();
                //        c.Style.NullValue = susm.Name;
                //        dr.Cells[3].Value = susm.Tel;
                //        dr.Cells[4].Value = susm.BusinessScopes;
                //        dr.Cells[4].ToolTipText = susm.BusinessScopes;
                //    }
                //    dataGridView1.Rows.Add(dr);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
