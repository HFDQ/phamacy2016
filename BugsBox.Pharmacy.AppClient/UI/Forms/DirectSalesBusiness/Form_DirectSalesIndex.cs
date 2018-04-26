using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DirectSalesBusiness
{
    public partial class Form_DirectSalesIndex :BaseFunctionForm
    {
        string msg = string.Empty;

        List<DirectSalesCheckedStates> ListStatus = new List<DirectSalesCheckedStates>();
        Business.Models.DirectSalesQueryModel dsq = new Business.Models.DirectSalesQueryModel();

        public Form_DirectSalesIndex()
        {
            InitializeComponent();

            this.dateTimePicker1.Value = DateTime.Now.AddYears(-3);
            this.dataGridView2.AutoGenerateColumns = false;

            #region comboBox1绑定验收状态
            ListStatus.Add(new DirectSalesCheckedStates { StatesValue = -1, Name = "全部" });
            ListStatus.Add(new DirectSalesCheckedStates { StatesValue = (int)Models.DirectSalesSatus.UnChecked, Name = "未验收" });
            ListStatus.Add(new DirectSalesCheckedStates { StatesValue = (int)Models.DirectSalesSatus.Checked, Name = "已验收" });
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "StatesValue";
            this.comboBox1.DataSource = ListStatus;
            this.comboBox1.SelectedIndex = 1;
            #endregion

            #region 事件
            this.toolStripButton1.Click += this.button1_Click;
            this.dataGridView2.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
            #endregion
        }

        void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Business.Models.DirectSalesModel dsom=this.dataGridView2.Rows[e.RowIndex].DataBoundItem as Business.Models.DirectSalesModel;
            #region 查看详情            
            //var dso = this.PharmacyDatabaseService.GetDirectSalesOrder(dsom.DirectSalesOrderId,out msg);
            //using (Forms.DrugsUnqualification.FormUnqualificationApprovalDetail f = new Forms.DrugsUnqualification.FormUnqualificationApprovalDetail())
            //{
            //    using (UserControls.UCDirectSales ucf = new UserControls.UCDirectSales(dso))
            //    {
            //        f.Height += ucf.Height;
            //        f.Controls.Add(ucf);
            //        ucf.Dock = DockStyle.Fill;
            //        f.ShowDialog();
            //    }
            //}
            #endregion

            #region 打开验收单据
            using (Form_CheckingOrder frm = new Form_CheckingOrder(dsom))
            {
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.Search();
                }
            }
            
            #endregion
        }

        public Form_DirectSalesIndex(params object[] args)
            : this()
        {
            this.Search();
        }

        //查询
        private void Search()
        {
            dsq.Sdt = this.dateTimePicker1.Value.Date;
            dsq.Edt = this.dateTimePicker2.Value.AddDays(1).Date;
            dsq.SupplyUnitKW = this.textBox2.Text.Trim();
            dsq.PurchaseUnitKW = this.textBox3.Text.Trim();
            dsq.DocumentNumber = this.textBox1.Text.Trim();
            int[] approvalStatus = { (int)Models.ApprovalStatus.Approvaled };
            dsq.ApprovalStatus = approvalStatus;
            int checkedStatus = (int)this.comboBox1.SelectedValue;
            dsq.CheckedStatusValue = checkedStatus;
            var c = this.PharmacyDatabaseService.GetDirectSalesModelByApprovalStatus(dsq, out msg).OrderBy(r=>r.Createtime).ToList();
            this.dataGridView2.DataSource = new BindingCollection<Business.Models.DirectSalesModel>(c);
        }

        class DirectSalesCheckedStates
        {
            public int StatesValue { get; set; }
            public string Name { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView2, "直调销售单据" + DateTime.Now.Ticks.ToString());
        }
    }
}
