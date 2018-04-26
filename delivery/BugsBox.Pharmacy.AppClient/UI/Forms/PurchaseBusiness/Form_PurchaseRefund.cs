using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.UI.Report;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class Form_PurchaseRefund : BaseFunctionForm
    {
        string msg = string.Empty;
        bool Readonly = false;
        PurchaseOrdeEntity poe = null;
        List<PurchaseOrderDetailEntity> ListP = new List<PurchaseOrderDetailEntity>();

        List<PurchasingPlan> ListPlan = new List<PurchasingPlan>();

        public Form_PurchaseRefund()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns["Column3"].ValueType = typeof(decimal);
            this.dataGridView1.Columns["TotalMoney"].ValueType = typeof(decimal);
            this.dataGridView1.Columns[13].ValueType = typeof(decimal);
            this.dataGridView1.Columns[14].ValueType = typeof(decimal);
        }

        public Form_PurchaseRefund(Guid pid,bool Readonly=true):this()
        {
            this.Readonly = Readonly;
            this.dataGridView1.ReadOnly = Readonly;
            this.toolStripButton2.Visible = false;
            this.toolStripButton3.Visible = false;
            this.toolStripButton4.Visible = false;
            poe = this.PharmacyDatabaseService.GetPurchaseOrderEntity(out msg, pid);
            label2.Text = poe.DocumentNumber;
            label6.Text = poe.TotalMoney.ToString() ;
            label8.Text = poe.PurchasedDate.ToLongDateString();
            label10.Text = poe.SupplyUnitName;

            ListP = this.PharmacyDatabaseService.GetPurchaseOrderDetails(out msg,pid).ToList();
            
            label4.Text = ListP.Count.ToString();
            this.dataGridView1.DataSource = ListP;
            
        }

        public Form_PurchaseRefund(Guid pid, PurchasingPlan[] pp,bool Readonly=true)
            : this()
        {
            this.toolStripButton1.Visible = false;
            if (pp[0].InValidDays == 999)
            {
                this.toolStripButton4.Visible = false;
                this.toolStripButton2.Visible = false;
                this.dataGridView1.ReadOnly = true;
            }

            this.Readonly = Readonly;
            this.dataGridView1.ReadOnly = Readonly;
            poe = this.PharmacyDatabaseService.GetPurchaseOrderEntity(out msg, pid);
            label2.Text = poe.DocumentNumber;
            label6.Text = poe.TotalMoney.ToString();
            label8.Text = poe.PurchasedDate.ToLongDateString();
            label10.Text = poe.SupplyUnitName;
            ListP = this.PharmacyDatabaseService.GetPurchaseOrderDetails(out msg, pid).ToList();
            label4.Text = ListP.Count.ToString();
            this.dataGridView1.DataSource = ListP;

            ListPlan = pp.ToList();
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要提交冲差价审核吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) return;
            List<PurchasingPlan> listPlan = new List<PurchasingPlan>();
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                //if (Convert.ToDecimal(dr.Cells[13].Value) == 0m) continue;
                PurchasingPlan ppd = new PurchasingPlan();
                ppd.AmountApprovalUserId = Guid.Parse(dr.Cells["id"].Value.ToString());//作为purchaseorderdetail的ID
                ppd.AmountOfTaxMoney = Convert.ToDecimal(dr.Cells[12].Value);//作为冲差价当前药品单价
                ppd.ApprovalDecription = this.label10.Text; //采购单位名称
                ppd.ApprovaledTime = DateTime.Now;//审核时间
                ppd.ApprovalUserId = new Guid(); //审核人ID
                ppd.CreateUserId = AppClientContext.CurrentUser.Id; //创建人ID
                ppd.Decription = "创建采购冲差价单";                
                ppd.Deleted = false; 
                ppd.DirectMarketing = true; 
                ppd.DocumentNumber = string.Empty; //冲差价单号
                ppd.InValidDays = 9999; 
                ppd.Id = Guid.NewGuid(); //冲差价单id
                ppd.OrderStatus = OrderStatus.purchaseRefund; //冲差价状态
                ppd.OrderStatusValue =(int)OrderStatus.purchaseRefund; 
                ppd.PaymentForGoodsMoney = Convert.ToDecimal(label13.Text);//冲差价
                ppd.PurchasedDate = poe.PurchasedDate; //采购日期
                ppd.ReleatedPurchaseOrderId = poe.Id; //采购单ID
                ppd.ShippingMethod = poe.DocumentNumber; //采购单号
                ppd.SupplyUnitId = poe.SupplyUnitId; //供货商ID
                ppd.TotalMoney = Convert.ToDecimal(label6.Text);//原定单总额
                ppd.UpdateTime = DateTime.Now;
                listPlan.Add(ppd);
            }
            if (this.PharmacyDatabaseService.SubmitRefunds(listPlan.ToArray(), 0, out msg))
            {
                MessageBox.Show("写入成功！");
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行新建采购冲差价单操作成功");
            }
            this.Dispose();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("数据数据格式有误！");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 12) return;
            if (dataGridView1.Rows[e.RowIndex].Cells[12].Value != null)
            {
                dataGridView1.Rows[e.RowIndex].Cells[13].Value = (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[12].Value) - Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[10].Value)) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
                dataGridView1.Rows[e.RowIndex].Cells[14].Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[12].Value)*Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            }
            decimal Refunsum=0m;
            decimal sum = 0m;
            foreach( DataGridViewRow dr in this.dataGridView1.Rows )
            {
                Refunsum += Convert.ToDecimal(dr.Cells[13].Value);
                sum += Convert.ToDecimal(dr.Cells[14].Value);
            }

            label12.Text = Refunsum.ToString();
            label13.Text = sum.ToString();
        }

        private void Form_PurchaseRefund_Load(object sender, EventArgs e)
        {
            if (ListPlan.Count <= 0)
            {
                foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                {
                    dr.Cells["TotalMoney"].Value = Convert.ToDecimal(dr.Cells["clmDrugNumber"].Value) * Convert.ToDecimal(dr.Cells["clmPurchasePrice"].Value);
                    dr.Cells[12].Value = dr.Cells[10].Value;
                }

            }
            else
            {
                foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                {
                    var p = this.ListPlan.Where(r => r.AmountApprovalUserId == Guid.Parse(dr.Cells["id"].Value.ToString())).FirstOrDefault();
                    decimal d = 0m;
                    if (p != null)
                    {
                        d = p.AmountOfTaxMoney;
                    }
                    dr.Cells["TotalMoney"].Value = Convert.ToDecimal(dr.Cells["clmDrugNumber"].Value) * Convert.ToDecimal(dr.Cells["clmPurchasePrice"].Value);
                    dr.Cells[12].Value = d;
                    dr.Cells[13].Value = (d - Convert.ToDecimal(dr.Cells[10].Value)) * Convert.ToDecimal(dr.Cells[9].Value);
                    dr.Cells[14].Value = Convert.ToDecimal(dr.Cells[12].Value) * Convert.ToDecimal(dr.Cells[9].Value);

                }

                decimal Refunsum = 0m;
                decimal sum = 0m;
                foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                {
                    Refunsum += Convert.ToDecimal(dr.Cells[13].Value);
                    sum += Convert.ToDecimal(dr.Cells[14].Value);
                }

                label12.Text = Refunsum.ToString();
                label13.Text = sum.ToString();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要修改冲差价吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) return;
            List<PurchasingPlan> listPlanAll = new List<PurchasingPlan>();
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                PurchasingPlan ppd = this.ListPlan.Where(r => r.AmountApprovalUserId == Guid.Parse(dr.Cells["id"].Value.ToString())).FirstOrDefault();
                ppd.AmountOfTaxMoney = Convert.ToDecimal(dr.Cells[12].Value);//作为冲差价当前药品单价
                ppd.CreateUserId = AppClientContext.CurrentUser.Id; //创建人ID
                ppd.PaymentForGoodsMoney = Convert.ToDecimal(label13.Text);//冲差价
                ppd.UpdateTime = DateTime.Now;
                listPlanAll.Add(ppd);
            }
            if (this.PharmacyDatabaseService.SubmitRefunds(listPlanAll.ToArray(), 1, out msg))
            {
                MessageBox.Show("写入成功！");
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行更新采购冲差价单操作成功");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要提交冲差价审核吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) return;
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                PurchasingPlan ppd = this.ListPlan.Where(r => r.AmountApprovalUserId == Guid.Parse(dr.Cells["id"].Value.ToString())).FirstOrDefault();
                ppd.InValidDays = 999;    
            
            }
            if (this.PharmacyDatabaseService.SubmitRefunds(ListPlan.ToArray(), 1, out msg))
            {
                MessageBox.Show("审核成功！");
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行审核采购冲差价单操作成功");
            }
            this.Dispose();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "EXCEL电子表格|*.xls";
            sfd.InitialDirectory = "c:\\";
            sfd.FileName = "采购冲差价单" + DateTime.Now.Ticks.ToString();
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            string fileName = sfd.FileName;

            DataTable dt = new DataTable("采购冲差价单");
            List<DataColumn> ldc = new List<DataColumn>();
            foreach (DataGridViewColumn dc in dataGridView1.Columns)
            {
                ldc.Add(new DataColumn((dc.HeaderText), typeof(string)));
            }
            dt.Columns.AddRange(ldc.ToArray());

            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (dgvr.Cells[i].Value == null) continue;
                    dr[i] = dgvr.Cells[i].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            if (MyExcelUtls.DataTable2Sheet(fileName, dt))
            {
                MessageBox.Show("创建成功！");
            }
            else
            {
                MessageBox.Show("创建失败,请联系管理员！");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e) //打印
        {
            try
            {
                if (ListPlan != null)
                {
                    DsSalesOrder ds = new DsSalesOrder(); ;//冲差价对象打印
                    
                    ds.ExtendedProperties.Clear();
                    ds.Tables.Clear();

                    ds.ExtendedProperties.Add("ReportTitle", PharmacyClientConfig.Config.Store.Name);

                    ds.ExtendedProperties.Add("Supplyer", label10.Text); //购买单位
                    ds.ExtendedProperties.Add("PurchaseOrderCode", this.label2.Text); //采购单号
                    ds.ExtendedProperties.Add("PurchaseRefundOrderCode", ListPlan[0].DocumentNumber);//冲单单号
                    string Creator=PharmacyDatabaseService.GetEmployeeByUserId(out msg,ListPlan[0].CreateUserId).Name;
                    ds.ExtendedProperties.Add("Creator", Creator);
                    ds.ExtendedProperties.Add("RefundMoney", label12.Text);//总差额
                    ds.ExtendedProperties.Add("PurchaseDate", label8.Text); //记录建立日期
                    ds.ExtendedProperties.Add("Date", ListPlan[0].CreateTime.ToLongDateString());
                    DsSalesOrder.tableDataTable OrderDetailTable = new DsSalesOrder.tableDataTable();

                    foreach ( DataGridViewRow dr in this.dataGridView1.Rows )
                    {
                        if (Convert.ToDecimal(dr.Cells[13].Value) == 0m) continue;
                        string part = dr.Cells[1].Value.ToString();
                        string _partType = dr.Cells[2].Value.ToString();
                        string specialCode = dr.Cells[3].Value.ToString();
                        string productUnit = dr.Cells[4].Value.ToString();
                        string Origin = string.Empty;
                        string batchNumber = dr.Cells[5].Value.ToString();
                        batchNumber=batchNumber.Contains("国药准字")?batchNumber.Substring(4,batchNumber.Length-4):batchNumber;

                        string ValidDate = dr.Cells[7].Value.ToString();
                        string unit = dr.Cells[8].Value.ToString();
                        decimal qty = Convert.ToDecimal(dr.Cells[9].Value);
                        decimal unitPrice = Convert.ToDecimal(dr.Cells[12].Value) - Convert.ToDecimal(dr.Cells[10].Value);
                        decimal price = Convert.ToDecimal(dr.Cells[13].Value);
                        string Quanlity = string.Empty;
                        OrderDetailTable.Rows.Add(new object[] { part, _partType, specialCode, productUnit, Origin,batchNumber, ValidDate, unit, qty, unitPrice, price, Quanlity });
                        OrderDetailTable.AcceptChanges();
                    }

                    ds.Tables.Add(OrderDetailTable);

                    using (PrintHelper printHelper = new PrintHelper("Reports\\RptPurchaseOrderRefundList.rdlc", ds))
                    {
                        printHelper.Print();
                    }
                }
                else
                {
                    MessageBox.Show("没有数据可以打印！！！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

    }
}
