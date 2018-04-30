 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.UI.Common.Printer;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Business.Models;


namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugsUnqualification
{
    public partial class formDrugsUnqualificationExecution : BaseFunctionForm
    {
        DataTable dt = null;
        private bool flag;
        
        BindingList<DrugsUnqualication> bList = new BindingList<DrugsUnqualication>();
        List<DrugsUnqualication> list = new List<DrugsUnqualication>();
        string msg = string.Empty;
        double pageNum = 0.0;
        double pageSize=30.0;
        int recordCount = 0;
        
        FormUnqualificationApprovalDetail f;
        
        
        Dictionary<string,string> dic=new Dictionary<string,string>();
        public formDrugsUnqualificationExecution()
        {
            InitializeComponent();

            this.dgvDrugDetailList.AutoGenerateColumns = false;
            AutoCompleteStringCollection acNames = new AutoCompleteStringCollection();
            this.getStorageTable();

            if (list.Count <= 0||dt.Rows.Count<=0) return;

            var a = from d in dt.AsEnumerable() select d["drugName"];
            var q = a.Distinct();

            foreach (string s in q)
            {
                acNames.Add(s);
            }
            
            this.textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteCustomSource = acNames;
            this.textBox1.DataSource = acNames;
            var c = list.Take(Convert.ToInt16(this.pageSize)).Skip(Convert.ToInt16(pageNum*pageSize)) .ToList();
            foreach (var i in c)
            {
                bList.Add(i);
            }
            this.dgvDrugDetailList.DataSource = bList;

            List<int> flowTypeList = new List<int>();
            flowTypeList.Add((int)ApprovalType.drugsBreakageApproval);
            string msg = string.Empty;
            List<ApprovalFlowType> Tlist = PharmacyDatabaseService.GetApprovalFlowTypeByTypeList(out msg, flowTypeList.ToArray()).ToList();
            if (Tlist.Count <= 0) return;
            this.comboBox1.DataSource = Tlist;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.SelectedIndex = 0;
        }

        private DataTable getStorageTable()
        {           
            dt = new DataTable();
            dt.Columns.Add("drugName");
            dt.Columns.Add("batchNo");
                        
            drugsUnqualificationCondition duc=new drugsUnqualificationCondition();
            duc.dtFrom = this.checkBox1.Checked ? this.dateTimePicker1.Value:DateTime.MinValue;
            duc.dtTo = this.checkBox1.Checked ? dateTimePicker1.Value : DateTime.MaxValue;
            duc.IsApproval = true;
            duc.unqualificationType = 0;
            list = PharmacyDatabaseService.GetDrugsUnqualificationByCondition(out msg, duc).ToList();

            this.bList.Clear();
            DataRow dr = null;
            foreach (DrugsUnqualication ar in list)
            {
                dr = dt.NewRow();
                dr["drugName"] = ar.drugName;
                dr["batchNo"] = ar.batchNo;                
                dt.Rows.Add(dr);  
            }
            return dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataRow[] drs = null;
            drs= dt.Select("drugName='" + textBox1.Text+"'");
            var q= from d in drs.AsEnumerable() select d["batchNo"];
            this.cmbBatch.Text = string.Empty;
            this.cmbBatch.Items.Clear();
            
            foreach (string s in q)
            {
                this.cmbBatch.Items.Add(s);
            }
            if (this.cmbBatch.Items.Count > 0)
            {
                this.cmbBatch.SelectedIndex = 0;
            }
        }


        private void tsbtnCancel_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;            
            string batch = cmbBatch.Text.Trim();
            string drugName = textBox1.Text.Trim();
            
            DateTime dtmin =checkBox1.Checked? this.dateTimePicker1.Value:DateTime.MinValue;
            DateTime dtmax= checkBox1.Checked ? this.dateTimePicker2.Value : DateTime.MaxValue;
            
            var all = list.Where(r => r.batchNo.Contains(batch) && r.drugName.Contains(drugName) && r.createTime>dtmin && r.createTime<dtmax).ToList();

            recordCount = all.Count();
            bList.Clear();
            foreach (var c in all)
                bList.Add(c);
            
            loadData();            
        }

        void dgvDrugDetailList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||e.ColumnIndex<0) return;
            int rIdx = e.RowIndex;
            DrugsUnqualication item = bList[e.RowIndex];

            if (this.dgvDrugDetailList.Columns[e.ColumnIndex].Name != this.Column9.Name)
            {
                Guid approvalFlowId = item.flowID;
                f = new FormUnqualificationApprovalDetail();
                Business.Models.drugsUnqualificationQuery dq = PharmacyDatabaseService.getDrugsUnqualificationQueryByFlowID(approvalFlowId, out msg);

                UserControls.ucDrugsUnqualification ucf = new UserControls.ucDrugsUnqualification(dq);
                f.Height += ucf.Height;
                f.Controls.Add(ucf);
                ucf.Dock = DockStyle.Fill;
                f.ShowDialog();
                f = null;
                dq = null;
                ucf = null;
                flag = true;
            }
            else
            {
                if (MessageBox.Show("需要提交报损审批吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    item.unqualificationType = 1;
                    if (this.PharmacyDatabaseService.SaveDrugsUnqualification(out msg, item))
                    {
                        MessageBox.Show("提交成功！");
                        bList.Remove(item);
                        list.Remove(item);
                    }
                }
            }
        }
        

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.pageSize=Convert.ToInt16(this.toolStripTextBox1.Text);
            loadData();
        }


        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (pageNum >= Math.Ceiling(Convert.ToDouble(recordCount) / pageSize)-1) return;
            pageNum++;
            loadData();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (pageNum <= 0) return;
            pageNum--;
            loadData();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            pageNum = Convert.ToDouble(toolStripButton5.Text) - 1;
            double p = Math.Ceiling(Convert.ToDouble(recordCount) / pageSize);
            if (pageNum < 0 || pageNum >= p)
            {
                return;
            }
            loadData();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)c).SelectedValue = null;               
                }
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).Text = string.Empty;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePicker1.Enabled = this.dateTimePicker2.Enabled = this.checkBox1.Checked;
        }

        private void loadData()
        {
            this.toolStripLabel2.Text = "当前第" + (pageNum + 1).ToString() + "页，共计" + Math.Ceiling(recordCount / pageSize).ToString() + "页,共计" + recordCount.ToString() + "条数据";            
        }

        

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvDrugDetailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDrugDetailList.CurrentCell.OwningColumn.Name == "Column9")
                this.toolStripButton9_Click(sender, e);
        }

        private void dgvDrugDetailList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }
                

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dgvDrugDetailList, "报损申请单" + DateTime.Now.Ticks);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.dgvDrugDetailList.EndEdit();
            List<DrugsUnqualication> s = new List<DrugsUnqualication>();
            if (MessageBox.Show("需要提交选中的记录吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            foreach (DataGridViewRow r in this.dgvDrugDetailList.Rows)
            {
                if (!Convert.ToBoolean(r.Cells[0].EditedFormattedValue))
                    continue;
                int rdx = r.Index;
                DrugsUnqualication d = bList[rdx];
                DrugsBreakage db = sumbitToBreak(rdx);
                
                if (!this.PharmacyDatabaseService.AddDrugsBreakageByFlowID(db, Guid.Parse(comboBox1.SelectedValue.ToString()), "新增报损审批", out msg))
                {
                    MessageBox.Show("不合格药品报损提交失败！失败记录：\n药品名称：" + bList[rdx].drugName + "，批次号:" + bList[rdx].batchNo + "\n请稍候再试！"); continue;
                }                
                s.Add(d);
            }

            foreach (var c in s)
            {
                bList.Remove(c);
                list.Remove(c);
            }

            if (s.Count > 0)
            {
                MessageBox.Show("新建报损申请成功！");
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "批量新建报损申请成功");
            }
            else
            {
                MessageBox.Show("新建报损申请失败！");
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "批量新建报损申请失败");
            }
            s = null;

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (this.dgvDrugDetailList.CurrentRow == null)
            {
                MessageBox.Show("请选择要提交报损处理的不合格药品记录！");
                return;
            }
            DrugsUnqualication u = bList[this.dgvDrugDetailList.CurrentRow.Index];
            if (MessageBox.Show("需要提交报损审批吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int rdx = this.dgvDrugDetailList.CurrentRow.Index;
                DrugsBreakage db = this.sumbitToBreak(rdx);
                if (this.PharmacyDatabaseService.AddDrugsBreakageByFlowID(db, Guid.Parse(comboBox1.SelectedValue.ToString()), "新增报损审批："+db.drugName, out msg))
                {
                    MessageBox.Show("提交成功！");
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "提交新增报损审批操作成功"+db.drugName);
                    bList.Remove(u);
                    list.Remove(u);
                }
            }
        }

        private DrugsBreakage sumbitToBreak(int rdx)
        {
            DrugsUnqualication d = bList[rdx];
            DrugsBreakage db = new DrugsBreakage();
            db.ApprovalStatus = ApprovalStatus.Waitting;
            db.batchNo = d.batchNo;
            db.createUID = AppClient.Common.AppClientContext.CurrentUser.Id;
            db.Description = d.Description;
            db.DrugInventoryRecordID = Guid.Parse(d.DrugInventoryRecordID.ToString());
            db.drugName = d.drugName;
            db.flowID = Guid.NewGuid();
            db.Id = Guid.NewGuid();
            db.quantity = d.quantity;
            db.source = d.source;
            db.UnqualificationDocumentNumber = d.DocumentNumber;
            db.unqualificationType = d.unqualificationType;
            db.DosageType = d.DosageType;
            db.Specific = d.Specific;
            db.ExpireDate = d.ExpireDate;
            db.produceDate = d.produceDate;
            db.DrugInfoId = d.DrugInfo;
            db.Origin = d.Origin;
            db.PurchasePrice = d.PurchasePrice;
            db.DrugUnqualityId = d.Id;
            db.PurchaseOrderDocumentNumber = d.PurchaseOrderDocumentNumber;
            db.PurchaseOrderId = d.PurchaseOrderId;
            db.Supplyer = d.Supplyer;
            db.FactoryName = d.factoryName;
            db.PurchaseOrderId = d.PurchaseOrderId;
            
            return db;
        }
    }
}
