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
using BugsBox.Pharmacy.AppClient.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugsUndeterminte
{
    public partial class PurchaseRefuse : BaseFunctionForm
    {
        string msg = string.Empty;
        BindingList<Models.DocumentRefuse> bList = new BindingList<Models.DocumentRefuse>();
        Models.DocumentRefuse currentRefuse = null;
        public PurchaseRefuse()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.toolStripComboBox1.ComboBox.SelectedIndex = 0;
            var c=PharmacyDatabaseService.QueryRefuseDocument(string.Empty, 0, string.Empty, out msg);
            this.getData(string.Empty,0,string.Empty);
            this.dataGridView1.DataSource = bList;
        }

        private void getData(string source,int proc,string keyword)
        {
            bList.Clear();
            var c = PharmacyDatabaseService.QueryRefuseDocument(source, proc, keyword, out msg).ToList();
            foreach (var i in c)
            {
                bList.Add(i);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要提交拒收报告审核吗？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            if (currentRefuse == null)
            {
                MessageBox.Show("请双击列表中的记录，然后填写相关信息后，再点击提交！");
                return;
            }
            Models.DocumentRefuse dr = currentRefuse;

            if (t2.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" 请填写拒收药品的批次号，否则无法提交！");
                return;
            }
            dr.BatchNumber = t2.Text.Trim();
            dr.updateTime = DateTime.Now;
            dr.conclusion = this.richTextBox2.Text.Trim();            
            dr.conclusionSigner = PharmacyDatabaseService.GetEmployeeByUserId(out msg, AppClientContext.CurrentUser.Id).Name;
            dr.conclusionSignDate = DateTime.Now;
            dr.proc = 1;
            System.IFormatProvider format = new System.Globalization.CultureInfo("zh-CN", true);
            try
            {
                dr.OutValidDate = DateTime.ParseExact(t10.Text, "yyyyMMdd", format);
            }
            catch (Exception ex)
            {
                MessageBox.Show("您填写的过期日格式不正确，或者没有填写，请填写正确！");
            }
            if (PharmacyDatabaseService.RefuseNextProc(dr, AppClientContext.CurrentUser.Id, out msg))
            {
                MessageBox.Show("拒收单审核成功！");
                getData(this.toolStripComboBox1.SelectedText,0,string.Empty);
                foreach (Control c in this.Controls)
                {
                    if (c.Name.Contains("t") || c.Name.Contains("c"))
                    {
                        c.Text=string.Empty;
                    }
                }
            }
            else
            {
                MessageBox.Show("提交失败\n"+msg);
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string source = string.Empty;
            toolStripButton2.Enabled = true;
            t2.ReadOnly = false;
            richTextBox2.ReadOnly = false;
            if(this.toolStripComboBox1.SelectedIndex!=0)
                source=toolStripComboBox1.SelectedItem.ToString();
             this.getData(source,0,string.Empty);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.getData(string.Empty, 1, toolStripTextBox1.Text.Trim());
            foreach (Control c in this.Controls)
            {
                t2.ReadOnly = true;
                richTextBox2.ReadOnly = true;
            }
            toolStripButton2.Enabled = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.getData(string.Empty, 0, string.Empty);
            toolStripButton2.Enabled = true;
            richTextBox2.ReadOnly = false;
            t2.ReadOnly = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (bList.Count <= 0) return;
            int rdx=e.RowIndex;
            t1.Text = bList[rdx].drugName;
            t2.Text = bList[rdx].BatchNumber;
            t3.Text = bList[rdx].DrugInfo.FactoryName;
            t4.Text = bList[rdx].DocumentNumber;

            t5.Text = bList[rdx].RefuseQuantity.ToString();
            t6.Text = bList[rdx].PurchaseUnitName;
            t7.Text = bList[rdx].PurchasePrice.ToString();
            t8.Text = bList[rdx].quantity.ToString();
            t9.Text = bList[rdx].Creator.ToString();
            t10.Text = bList[rdx].OutValidDate.ToString();
            richTextBox1.Text = bList[rdx].rsn;
            richTextBox2.Text = bList[rdx].conclusion;
            c1.Text = bList[rdx].Creator; 
            c2.Text = bList[rdx].createTime.ToLongDateString();
            c3.Text=bList[rdx].createTime==bList[rdx].conclusionSignDate?"":bList[rdx].updateTime.ToLongDateString();
            c4.Text = bList[rdx].conclusionSigner;
            currentRefuse = bList[rdx];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
