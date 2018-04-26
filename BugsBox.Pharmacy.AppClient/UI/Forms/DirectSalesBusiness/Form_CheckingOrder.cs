using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DirectSalesBusiness
{
    public partial class Form_CheckingOrder :BaseFunctionForm
    {
        string msg = string.Empty;
        private Business.Models.DirectSalesModel _dso;
        private Models.DirectSalesOrder _CurrentDso = null;
        private List<Business.Models.DirectSalesOrderDetailModel> _CurrentDirectSalesOrderDetailModel;

        public Form_CheckingOrder(Business.Models.DirectSalesModel dso)
        {
            InitializeComponent();

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this._dso = dso;
            this._CurrentDso = this.PharmacyDatabaseService.GetDirectSalesOrder(dso.DirectSalesOrderId, out msg);

            bool IsUnChecked = this._CurrentDso.CheckStatusValue == (int)DirectSalesSatus.UnChecked;
            this.toolStripButton1.Enabled = IsUnChecked;
            this.textBox1.Enabled = IsUnChecked;
            this.dataGridView1.ReadOnly = !IsUnChecked;
            this.dataGridView1.AutoGenerateColumns = false;

            #region 事件
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dataGridView1.DataError += dataGridView1_DataError;
            #endregion

            #region 数据绑定
            var dsod = this.PharmacyDatabaseService.GetDirectSalesOrderDetailModelByDirectSalesModel( dso.DirectSalesOrderId , out msg).OrderBy(r => r.ProducGeneralName);

            if (IsUnChecked)
            {
                dsod.ForEach(v =>
                {
                    v.BatchNumber = string.Empty;
                    v.CheckMethod = "正常";
                    v.Origin = string.Empty;
                    v.OutValidDate = DateTime.Now.Date;
                    v.ProductDate = DateTime.Now;
                    v.QualityNumber = v.Amount;
                    v.QualityMemo = "验收合格";
                    v.UnqualityNumber = 0;
                    v.UnqualityMemo = "无";
                });
            }
            
            this._CurrentDirectSalesOrderDetailModel = dsod.ToList();
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.DirectSalesOrderDetailModel>(this._CurrentDirectSalesOrderDetailModel);
            this.label8.Text = dso.SupplyUnitName;
            this.label9.Text = dso.PurchaseUnitName;
            this.label7.Text = dso.DocumentNumber;
            this.richTextBox1.Text = dso.Memo;
            this.label12.Text = dso.Createtime.ToString();
            this.label10.Text = dso.Checker;
            this.textBox1.Text =IsUnChecked? dso.ReceivingAddress:dso.CheckAddress;
            this.richTextBox1.Text = dso.Memo;
            this.dateTimePicker1.Value = this._CurrentDso.CheckTime.Date;
            this.dateTimePicker1.Enabled = IsUnChecked;
            #endregion
        }

        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                MessageBox.Show("验收地址必须要填写，请填写完整！");
                this.textBox1.Focus();
                return;
            }
            this._CurrentDso.CheckTime = this.dateTimePicker1.Value.Date;//验收日期
            this._CurrentDso.CheckAddress = this.textBox1.Text.Trim();
            this._CurrentDso.CheckStatusValue = (int)DirectSalesSatus.Checked;
            this._CurrentDso.DirectSalesOrderDetails.Where(r=>!r.Deleted).ForEach(r =>
            {
                var v=this._CurrentDirectSalesOrderDetailModel.Where(u => u.Id == r.Id).FirstOrDefault();
                if (v != null)
                {
                    r.BatchNumber = v.BatchNumber;
                    r.CheckMethod = v.CheckMethod;
                    r.Origin = v.Origin;
                    r.OutValidDate = v.OutValidDate;
                    r.ProductDate = v.ProductDate;
                    r.QualityAmount = v.QualityNumber;
                    r.QualityMemo = v.QualityMemo;
                    r.UnQualityAmount = v.UnqualityNumber;
                    r.UnqualityMemo = v.UnqualityMemo;
                }
            });
            
            if (this.PharmacyDatabaseService.SaveDirectSalesOrderAndDetail(this._CurrentDso, out msg))
            {
                MessageBox.Show("验收成功！单号：" + this._CurrentDso.DocumentNumber);
                this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id,"直调验收单验收成功！单号："+this._CurrentDso.DocumentNumber);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("验收失败，请联系管理员！单号：" + this._CurrentDso.DocumentNumber);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
