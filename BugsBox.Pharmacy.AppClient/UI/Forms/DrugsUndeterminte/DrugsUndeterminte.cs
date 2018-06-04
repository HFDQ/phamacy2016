using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.UI.Common.Helper;
using Omu.ValueInjecter;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.UI.Report;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugsUndeterminte
{
    using OrderStatus = BugsBox.Pharmacy.Models.OrderStatus;
    using BugsBox.Pharmacy.AppClient.Common;
    using BugsBox.Pharmacy.Models;

    public partial class DrugsUndeterminte : BaseFunctionForm
    {
        BindingList<DrugsUndeterminate> BList = new BindingList<DrugsUndeterminate>();
        DrugsUndeterminate currentRecord = null;
        string msg = string.Empty;
        int pro = 0;
        public DrugsUndeterminte(string type)
        {
            InitializeComponent();
            pro = Convert.ToInt16(type);
            List<int> flowTypeList = new List<int>();
            flowTypeList.Add((int)ApprovalType.drugsUnqualityApproval);
            string msg = string.Empty;
            List<ApprovalFlowType> list = PharmacyDatabaseService.GetApprovalFlowTypeByTypeList(out msg, flowTypeList.ToArray()).ToList();
            this.cmbApprovalSelector.DataSource = list;
            this.cmbApprovalSelector.DisplayMember = "Name";
            this.cmbApprovalSelector.ValueMember = "Id";

        }

        public void search()
        {

        }

        private void DrugsUndeterminte_Load(object sender, EventArgs e)
        {
            this.toolStripComboBox1.ComboBox.DataSource = Enum.GetValues(typeof(sourceType));
            this.toolStripComboBox2.ComboBox.DataSource = Enum.GetValues(typeof(sourceType));
            this.dataGridView1.AutoGenerateColumns = false;
            this.getData(pro);
            this.dataGridView1.DataSource = BList;

            this.richTextBox2.Enabled = (pro == 0);
            this.richTextBox3.Enabled = (pro == 1);
            this.textBox1.ReadOnly = !(pro == 1);
            this.textBox2.ReadOnly = !(pro == 1);
            this.cmbApprovalSelector.Enabled = !(pro == 1);

        }

        private void getData(int proc)
        {
            BList.Clear();
            string msg = string.Empty;
            string sourceStr = toolStripComboBox1.ComboBox.SelectedValue.ToString() == "全部" ? string.Empty : toolStripComboBox1.ComboBox.SelectedValue.ToString();
            var c = PharmacyDatabaseService.GetDrugsUndeterminate(proc, sourceStr, string.Empty, out msg).ToList();
            foreach (var i in c)
            {
                BList.Add(i);
            }
            this.richTextBox2.ReadOnly = !(pro == 0);
            this.richTextBox3.ReadOnly = !(pro == 1);
            this.textBox1.ReadOnly = !(pro == 1);
            this.textBox2.ReadOnly = !(pro == 1);
            this.cmbApprovalSelector.Enabled = !(pro == 1);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.getData(pro);
            this.toolStripButton2.Enabled = true;
            this.toolStripButton4.Enabled = false;
            this.cmbApprovalSelector.Enabled = !(pro == 1);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            BList.Clear();
            string msg = string.Empty;
            string search = toolStripComboBox2.ComboBox.SelectedValue.ToString();
            if (search.Contains("全部")) search = string.Empty;
            string keyword = toolStripTextBox1.Text.Trim();
            var c = PharmacyDatabaseService.GetDrugsUndeterminate(2, search, keyword, out msg).ToList();
            foreach (var i in c)
            {
                BList.Add(i);
            }
            this.richTextBox1.ReadOnly = true;
            this.richTextBox2.ReadOnly = true;
            this.toolStripButton2.Enabled = false;
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.toolStripButton4.Enabled = true;
            this.cmbApprovalSelector.Enabled = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.cmbApprovalSelector.Items.Count <= 0)
            {
                MessageBox.Show("不合格药品审批流程没有设定。\n请通知系统管理员设置不合格药品审核流程！");
                return;
            }
            Guid userId = AppClientContext.CurrentUser.Id;
            if (currentRecord == null)
            {
                MessageBox.Show("请先双击列表中的记录，填写意见后再提交！");
                return;
            }

            if (currentRecord.proc == 0)
            {
                currentRecord.sta = richTextBox2.Text.Trim();
                currentRecord.staSignDate = DateTime.Now;
                currentRecord.staSigner = PharmacyDatabaseService.GetEmployeeByUserId(out msg, userId).Name;
                currentRecord.proc = 1;
            }
            else
            {
                try
                {
                    decimal q = Convert.ToDecimal(textBox1.Text);
                    decimal un = Convert.ToDecimal(textBox2.Text);
                    if (un + q != currentRecord.quantity)
                    {
                        MessageBox.Show("合格数量与不合格数量之和应与质量复核申请数量一致，请检查！");
                        textBox1.Focus();
                        return;
                    }
                    currentRecord.QualificationQuantity = q;
                    currentRecord.UnqualificationQuantity = un;
                    currentRecord.UnqualificationApprovalID = (Guid)cmbApprovalSelector.SelectedValue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("合格数量与不合格数量应填写为数字！");
                    textBox1.Focus();
                    return;

                }
                currentRecord.conclusion = richTextBox3.Text.Trim();
                currentRecord.conclusionDate = DateTime.Now;
                currentRecord.conclusionSigner = PharmacyDatabaseService.GetEmployeeByUserId(out msg, userId).Name;
                currentRecord.proc = 2;
            }

            if (PharmacyDatabaseService.SaveToNextProc(currentRecord, userId, out msg))
            {
                MessageBox.Show("提交成功！");
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "提交质量复查报告成功！");
                currentRecord = null;
                this.getData(pro);
                this.textBox1.Text = "0";
                this.textBox2.Text = "0";
                this.richTextBox1.Text = string.Empty;
                this.richTextBox2.Text = string.Empty;
                this.richTextBox3.Text = string.Empty;
                clearLabels();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var c = BList[e.RowIndex];
            currentRecord = BList[e.RowIndex];
            t1.Text = c.DrugInfo.ProductGeneralName;
            t2.Text = c.BatchNumber;
            t3.Text = c.DrugInfo.FactoryName;
            t4.Text = c.produceDate.ToLongDateString();
            t5.Text = c.ExpireDate.ToLongDateString();
            t6.Text = c.supplyer;
            t7.Text = c.PurchasePrice.ToString();

            richTextBox1.Text = c.rsn;
            c1.Text = c.creater;
            c2.Text = c.createTime.ToLongDateString();

            richTextBox2.Text = c.sta;
            c3.Text = c.staSigner;
            c4.Text = c.staSignDate == c.createTime ? "" : c.staSignDate.ToLongDateString();

            richTextBox3.Text = c.conclusion;
            c5.Text = c.conclusionSigner;
            c6.Text = c.conclusionDate == c.createTime ? "" : c.conclusionDate.ToLongDateString();

            textBox1.Text = 0.ToString();
            textBox2.Text = c.UnqualificationQuantity.ToString();
        }

        private void clearLabels()
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name.Contains("c") || c.Name.Contains("t"))
                {
                    c.Text = string.Empty;
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (currentRecord == null)
            {
                MessageBox.Show("请先双击列表记录，再执行打印");
                return;
            }

            List<object> reportData = new List<object>();
            List<object> orderList = new List<object>();

            orderList.Add(currentRecord);
            reportData.Add(orderList);
            List<Microsoft.Reporting.WinForms.ReportParameter> ListPar = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            using (PrintHelper printHelper = new PrintHelper("BugsBox.Pharmacy.AppClient.UI.Reports.RptUndeterminate.rdlc", reportData, ListPar))
            {
                printHelper.Print();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textBox2.Text) > 0)
                {
                    cmbApprovalSelector.Enabled = true;
                }
                else
                {
                    cmbApprovalSelector.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                textBox2.Text = "0";
                MessageBox.Show("不合格药品数量填写有误，请检查！\n" + ex.Message);
                textBox2.Focus();
                return;
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.getData(pro);
            this.toolStripButton2.Enabled = true;
            this.toolStripButton4.Enabled = false;
            this.richTextBox2.ReadOnly = !(pro == 0);
            this.richTextBox3.ReadOnly = !(pro == 1);
            this.textBox1.ReadOnly = !(pro == 1);
            this.textBox2.ReadOnly = !(pro == 1);
            this.cmbApprovalSelector.Enabled = !(pro == 1);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Forms.DrugsUnqualification.Form1 frm = new DrugsUnqualification.Form1();

        }
    }
}
