using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class Form_SalesInvoiceProc :BaseFunctionForm
    {
        List<Models.PurchaseUnit> ListPurchaseUnit = null;
        List<Models.User> ListUser = null;
        List<Business.Models.SalerTaxManage> ListST = new List<Business.Models.SalerTaxManage>();
        string msg = string.Empty;
        ContextMenuStrip cms = new ContextMenuStrip();
        bool Editable = false;
        bool searchMethod = false;
        int locker = -1;

        public Form_SalesInvoiceProc()
        {
            InitializeComponent();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            User usr = BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser;

            var allRoles = this.PharmacyDatabaseService.AllRoles(out msg).Where(r => r.Name.Contains("SystemRole") || r.Name.Contains("adminRole"));
            var allrolew = from m in this.PharmacyDatabaseService.AllRoleWithUsers(out msg)
                           join a in allRoles on
                               m.RoleId equals a.Id
                           where m.UserId == usr.Id
                           select m;

            if (allrolew.ToList().Count <= 0)
            {
                this.toolStripButton2.Visible = false;
            }
            else
            {
                Editable = true;
            }

            ListUser = this.PharmacyDatabaseService.AllUsers(out msg).OrderBy(r => r.Employee.Name).ToList();
            ListPurchaseUnit = this.PharmacyDatabaseService.AllPurchaseUnits(out msg).OrderBy(r => r.Name).ToList();

            this.comboBox2.DisplayMember = "Account";
            this.comboBox2.ValueMember = "Id";
            this.comboBox2.DataSource = ListUser;

            this.comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.dateTimePicker1.Value = DateTime.Now.Date;
            this.dateTimePicker2.Value = DateTime.Now.Date.AddDays(1);
            this.dataGridView1.AutoGenerateColumns = false;
            this.RightMenu();

            #region 权限控制
            this.Column8.ReadOnly=this.Column14.ReadOnly = !(Editable||this.Authorize(ModuleKeys.SMoneyCollection));
            this.Column8.Visible = this.Column9.Visible = this.Column14.Visible = Editable || this.Authorize(ModuleKeys.PIsPayed) || this.Authorize(ModuleKeys.SMoneyCollection);

            this.Column10.Visible = this.Column11.Visible = this.Column12.Visible = Editable || this.Authorize(ModuleKeys.SInvoiceCollection);
            this.Column5.Visible = this.Column6.Visible = Editable || this.Authorize(ModuleKeys.PIsPayed);

            this.Column13.Visible = this.Column15.Visible = this.Column16.Visible = this.Column17.Visible = Editable||this.Authorize(ModuleKeys.PIsPayed)||this.Authorize(ModuleKeys.SMoneyCollection);
            
            if(Editable)locker=0;
            if (this.Authorize(ModuleKeys.SMoneyCollection)) locker = 1;//已收款            
            if (this.Authorize(ModuleKeys.SInvoiceCollection)) locker = 2;//发票金额
            
            #endregion
        }
          
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.Items.Count <= 0) return;
            if (this.comboBox2.SelectedIndex < 0)
            {
                label3.Text = "";
                return;
            }
            Guid gid = (Guid)(this.comboBox2.SelectedValue);
            label3.Text = this.ListUser.Where(r => r.Id == gid).First().Employee.Name;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.searchMethod = false;
            this.search(this.searchMethod);
        }
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="b"></param>
        private void search(bool b)
        {
            if (b)
            {
                ListST = this.PharmacyDatabaseService.GetSalerTaxManage(this.dateTimePicker1.Value.Date, this.dateTimePicker2.Value.AddDays(1).Date, Guid.Empty, string.Empty, out msg).OrderBy(r => r.EmployeeName).ThenBy(r => r.SaleOrderDocumentNumber).ToList();
                
                foreach (var i in ListST)
                {
                    decimal returnDiff = i.ReturnDiff ?? 0.0m;
                    i.Money = (i.PayMoney +(i.ReturnDiff??0m)) * ((i.MRate??0m) + (i.IRate??0m))/100 + (i.ReceiveMoneyAfterReturn??0m);
                }
                dataGridView1.DataSource = new BindingCollection<Business.Models.SalerTaxManage>(ListST);
                this.SetCellReadOnly();
            }
            else
            {
                Guid pid = this.comboBox1.SelectedValue == null ? Guid.Empty : (Guid)this.comboBox1.SelectedValue;
                ListST = this.PharmacyDatabaseService.GetSalerTaxManage(this.dateTimePicker1.Value.Date, this.dateTimePicker2.Value.AddDays(1).Date, pid, this.label3.Text, out msg).OrderBy(r => r.EmployeeName).ThenBy(r => r.SaleOrderDocumentNumber).ToList();

                foreach (var i in ListST)
                {
                    decimal returnDiff = i.ReturnDiff ?? 0.0m;
                    i.Money = (i.PayMoney + (i.ReturnDiff ?? 0m)) * ((i.MRate ?? 0m) + (i.IRate ?? 0m)) / 100 + (i.ReceiveMoneyAfterReturn ?? 0m);
                }
                dataGridView1.DataSource = new BindingCollection<Business.Models.SalerTaxManage>(ListST);
                this.SetCellReadOnly();
            }

            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                Business.Models.SalerTaxManage stm = dr.DataBoundItem as Business.Models.SalerTaxManage;
                if (stm.SaleOrderDate < this.dateTimePicker1.Value.Date)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else
                {
                    if (stm.SalesReturnMoney != null)
                    {
                        dr.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    }
                    else
                    {
                        dr.DefaultCellStyle.BackColor = Color.Silver;
                    }
                }
            }
        }

        private void RightMenu()
        {
            ToolStripMenuItem tsmi = new ToolStripMenuItem("手工统计");
            tsmi.DropDownItems.Add("求和", null, delegate(object sender, EventArgs e) { this.GetResult(0); });
            tsmi.DropDownItems.Add("平均", null, delegate(object sender, EventArgs e) { this.GetResult(1); });
            tsmi.DropDownItems.Add("记数", null, delegate(object sender, EventArgs e) { this.GetResult(2); });
            cms.Items.Add(tsmi);
            
            cms.Items.Add("-");
            tsmi = new ToolStripMenuItem("调整表格显示");
            tsmi.DropDownItems.Add("调整列宽", null, delegate(object sender, EventArgs e) { this.AdjustColumn(0); });
            tsmi.DropDownItems.Add("调整行高", null, delegate(object sender, EventArgs e) { this.AdjustColumn(1); });
            tsmi.DropDownItems.Add("取消调整", null, delegate(object sender, EventArgs e) { this.AdjustColumn(2); });
            cms.Items.Add(tsmi); 
           
            cms.Items.Add("-");
            tsmi = new ToolStripMenuItem("批量信息填充");
            tsmi.DropDownItems.Add("已付款项", null, delegate(object sender, EventArgs e) { this.BactchFillData("已付款"); });
            tsmi.DropDownItems[tsmi.DropDownItems.Count - 1].Enabled = Editable || this.Authorize(ModuleKeys.SMoneyCollection);
            
            tsmi.DropDownItems.Add("发票金额项", null, delegate(object sender, EventArgs e) { this.BactchFillData("发票金额"); });
            tsmi.DropDownItems[tsmi.DropDownItems.Count - 1].Enabled = Editable || this.Authorize(ModuleKeys.SInvoiceCollection);

            cms.Items.Add(tsmi);

            cms.Items.Add("-");
            cms.Items.Add("查看销售单据", null, delegate(object sender, EventArgs e) { this.querySaleOrder(); });
            cms.Items.Add("-");

            tsmi = new ToolStripMenuItem("查看销退单据");
            tsmi.Name = "查看销退单据";
            cms.Items.Add(tsmi);
            

            cms.Items.Add("-");
            cms.Items.Add("销售单冲差", null, delegate(object sender, EventArgs e) { this.DiffSaleOrder(); });
            cms.Items[cms.Items.Count-1].Enabled=this.Authorize(ModuleKeys.SRefund)||Editable;//控制销售冲差功能
            tsmi = new ToolStripMenuItem("冲差查询");
            tsmi.DropDownItems.Add("查询未冲差单据", null, delegate(object sender, EventArgs e) { this.DiffSaleOrderQuery(0); });
            tsmi.DropDownItems.Add("查询已冲差单据",null,delegate(object sender, EventArgs e) { this.DiffSaleOrderQuery(1); });
            tsmi.DropDownItems.Add("查询全部单据", null, delegate(object sender, EventArgs e) { this.DiffSaleOrderQuery(2); });
            cms.Items.Add(tsmi);
            cms.Items[cms.Items.Count - 1].Enabled = this.Authorize(ModuleKeys.SRefund) || Editable;//控制销售冲差查询功能

            cms.Items.Add("-");
            cms.Items.Add("销售单结算", null, delegate(object sender, EventArgs e) { this.BalanceSaleOrder(); });
            cms.Items[cms.Items.Count - 1].Enabled = this.Authorize(ModuleKeys.BalanceSalesOrder) || this.Authorize(ModuleKeys.SMoneyCollection) || Editable;//控制销售结算功能

            cms.Items.Add("-");
            cms.Items.Add("发票项查询");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("查询发票未开项", null, delegate(object sender, EventArgs e) { this.SearchInVoiceState(false); });
            cms.Items[cms.Items.Count - 1].Enabled = this.Authorize(ModuleKeys.SInvoiceCollection) || Editable;//查询未开发票项
            cms.Items.Add("查询发票已开项", null, delegate(object sender, EventArgs e) { this.SearchInVoiceState(true); });
            cms.Items[cms.Items.Count - 1].Enabled = this.Authorize(ModuleKeys.SInvoiceCollection) || Editable;//查询已开发票项
            cms.Items.Add("查询全部", null, delegate(object sender, EventArgs e) { this.SearchInVoiceState(true,true); });
            cms.Items[cms.Items.Count - 1].Enabled = this.Authorize(ModuleKeys.SInvoiceCollection) || Editable;//查询已开发票项


            cms.Items.Add("-");
            tsmi = new ToolStripMenuItem("统计方式");
            tsmi.DropDownItems.Add("按销售员统计", null, delegate(object sender, EventArgs e) { this.GoStatic(0); });
            tsmi.DropDownItems.Add("按购货商统计", null, delegate(object sender, EventArgs e) { this.GoStatic(1); });
            //tsmi.DropDownItems.Add("按销售员统计图表", null, delegate(object sender, EventArgs e) { this.GoStatic(2); });
            cms.Items.Add(tsmi);
        }
        #region 右键菜单项
        private void AdjustColumn(int flag)
        {
            if(flag==0)
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (flag == 1)
                this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            if (flag == 2)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            }
        }
        private void GetResult(int i)
        {
            DataGridViewSelectedCellCollection sc = this.dataGridView1.SelectedCells;

            List<decimal> ListD = new List<decimal>();

            foreach (DataGridViewCell r in sc)
            {
                decimal d = 0m;
                if (r.Value == null) r.Value = 0.0m;
                bool b = Decimal.TryParse(r.Value.ToString(), out d);
                if (!b)
                {
                    MessageBox.Show("您所选择的单元格含有非数字，请取消其选择，谢谢！");
                    return;
                }
                ListD.Add(d);
            }

            decimal result = i == 0 ? ListD.Sum() : i == 1 ? ListD.Average() : ListD.Count;
            MessageBox.Show("统计结果是：" + result.ToString("F4"));
        }
        private void BactchFillData(string ColName)
        {
            switch (ColName)
            {
                case "已付款":
                    foreach ( Business.Models.SalerTaxManage st in ListST )
                    {
                        st.IsPayed = true;
                    }
                    break;
                case "实收金额":
                    foreach (Business.Models.SalerTaxManage st in ListST)
                    {
                        st.ReceivedMoney=st.PayMoney;
                    }
                    break;
                case "需要发票":
                    foreach (Business.Models.SalerTaxManage st in ListST)
                    {
                        st.IsNeedInvoice = true;
                    }
                    break;
                case "发票已开":
                    foreach (Business.Models.SalerTaxManage st in ListST)
                    {
                        st.IsInvoice = true;
                    }
                    break;
                case "发票金额":
                    foreach (Business.Models.SalerTaxManage st in ListST)
                    {
                        st.InvoiceMoney = st.ReceivedMoney;
                    }
                    break;
            }
            this.dataGridView1.Refresh();
        }
        private void querySaleOrder()
        {
            if (this.dataGridView1.SelectedCells.Count <= 0) return;
            int rdx = this.dataGridView1.SelectedCells[this.dataGridView1.SelectedCells.Count-1].RowIndex;
            Models.SalesOrder c=this.PharmacyDatabaseService.GetSalesOrder(out msg, this.ListST[rdx].Id);
            Forms.SalesBusiness.FormSalesOrderEdit frm = new FormSalesOrderEdit(c, true);
            frm.ShowDialog();
        }

        private void DiffSaleOrder()
        {
            if (this.dataGridView1.SelectedCells.Count <= 0) return;
            int rdx = this.dataGridView1.SelectedCells[this.dataGridView1.SelectedCells.Count - 1].RowIndex;
            Models.SalesOrder c = this.PharmacyDatabaseService.GetSalesOrder(out msg, this.ListST[rdx].Id);
            Forms.SalesBusiness.FormSalesOrderEdit frm = new FormSalesOrderEdit(c, true,true,Editable);
            frm.ShowDialog();
        }
        private void GoStatic(int type)
        {            
            var c = from i in ListST
                    group i by i.EmployeeName into g
                    select new { 
                        Saler=g.First().EmployeeName,
                        SCount=g.Count(),
                        SSaleAmount=g.Sum(r=>r.PayMoney),
                        SReceivedMoney=g.Sum(r=>r.ReceivedMoney),
                        SIC=g.Count(r=>r.IsInvoice!=null && (bool)r.IsInvoice),
                        InvoiceMoney=g.Sum(r=>r.InvoiceMoney),
                        MRate=g.First().MRate,
                        IRate=g.First().IRate,
                        ReturnMoney=g.Sum(r=>r.PayedMoney)
                    };

            var d = from i in ListST
                    group i by i.PurchaseUnitName into g
                    select new
                    {
                        PName = g.First().PurchaseUnitName,
                        SCount = g.Count(),
                        SSaleAmount = g.Sum(r => r.PayMoney),
                        SReceivedMoney = g.Sum(r => r.ReceivedMoney),
                        SIC = g.Count(r => (bool)r.IsInvoice),
                        InvoiceMoney = g.Sum(r => r.InvoiceMoney),
                        MRate = g.First().MRate,
                        IRate = g.First().IRate,
                        ReturnMoney = g.Sum(r => r.PayedMoney)
                    }; 
            
            Form_SaleTaxStatics frm = new Form_SaleTaxStatics(this.dateTimePicker1.Value,dateTimePicker2.Value);
            frm.sList = c.ToList<object>();
            frm.pList = d.ToList<object>();
            frm.result = (decimal)ListST.Sum(r => r.PayedMoney);
            frm.type = type;
            frm.ShowDialog();
        }
        //查询发票未到项
        private void SearchInVoiceState(bool b,bool all=false)
        {
            if (!all)
            {
                var c = this.ListST.Where(r => (bool)r.IsInvoice == b);
                dataGridView1.DataSource = new BindingCollection<Business.Models.SalerTaxManage>(c.ToList());
            }
            else
            {
                dataGridView1.DataSource = new BindingCollection<Business.Models.SalerTaxManage>(this.ListST);
            }
            this.SetCellReadOnly();

        }
        private void BalanceSaleOrder()
        {
            if (this.dataGridView1.SelectedCells.Count <= 0) return;
            int rdx = this.dataGridView1.SelectedCells[this.dataGridView1.SelectedCells.Count - 1].RowIndex;
            Models.SalesOrder c = this.PharmacyDatabaseService.GetSalesOrder(out msg, this.ListST[rdx].Id);
            Forms.SalesBusiness.FormSalesOrderEdit frm = new FormSalesOrderEdit(c, false);
            frm.ShowDialog();
            if (frm.IsBalanced)this.search(this.searchMethod);
        }
        private void DiffSaleOrderQuery(int i)
        {
            if (this.ListST.Count <= 0) return;
            if (i == 0)
            {
                this.dataGridView1.DataSource = this.ListST.Where(r=>r.Diff==0m).ToList();
            }
            if (i == 1)
            {
                this.dataGridView1.DataSource = this.ListST.Where(r => r.Diff != 0).ToList();
            }
            if (i == 2)
            {
                this.dataGridView1.DataSource = this.ListST;
            } 
            this.dataGridView1.Refresh();
        }

        private void querySaleOrderReturn(Guid ReturnOrderId)
        {
            if (ReturnOrderId == null) return;
            var orderReturn = PharmacyDatabaseService.GetSalesOrderReturn(out msg, ReturnOrderId);
            FormSalesOrderReturn form = new FormSalesOrderReturn(orderReturn);
            form.ShowDialog();
        }
        #endregion

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.searchMethod = true;
            this.search(this.searchMethod);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string qStr = this.textBox3.Text.Trim();
            this.label8.Text = string.Empty;
            var c = this.ListPurchaseUnit.Where(r => r.Name.Contains(qStr) || r.PinyinCode.ToUpper().Contains(qStr.ToUpper())).ToList();
            if (c.Count <= 0) return;

            this.comboBox1.DataSource = c;
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.SelectedIndex = 0;
            this.label8.Text = ((PurchaseUnit)this.comboBox1.SelectedItem).Name;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Items.Count <= 0) return;
            label8.Text = ((PurchaseUnit)this.comboBox1.SelectedItem).Name;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
            
            if (this.PharmacyDatabaseService.SaveSaleOrderTaxRate(ListST,locker, out msg))
            {
                MessageBox.Show("保存成功!");
            }
            else
            {
                MessageBox.Show("保存失败,请联系管理员");
            }
            this.search(this.searchMethod);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Forms.SalesBusiness.Form_SalerTaxRateManage frm = new SalesBusiness.Form_SalerTaxRateManage();
            frm.Show();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            //Business.Models.SalerTaxManage st = ListST[e.RowIndex];
            
            //if (this.dataGridView1.Columns[e.ColumnIndex].Name == this.Column12.Name)
            //{
            //    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.dataGridView1.Rows[e.RowIndex].Cells[this.Column9.Name].Value;
            //}
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

            var c = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.SalerTaxManage;

            ToolStripMenuItem tsmi = this.cms.Items["查看销退单据"] as ToolStripMenuItem;
            tsmi.DropDownItems.Clear();
            foreach (var i in c.ReturnOrderCol)
            {
                string MenuTex = i.code;
                Guid ReturnId = i.Gid;
                tsmi.DropDownItems.Add(MenuTex, null, delegate(object o, EventArgs ex) { this.querySaleOrderReturn(ReturnId); });
            }
            

            cms.Show(MousePosition.X, MousePosition.Y);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.comboBox2.Text)) return;
            this.label3.Text = string.Empty;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
           if (this.dataGridView1.Rows.Count <= 0) return;
           MyExcelUtls.DataGridview2Sheet(this.dataGridView1,"销售管理、税票费情况("+DateTime.Now.ToLongDateString()+")");
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void SetCellReadOnly()
        {
            if (Editable) return;
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[this.Column8.Name].Value))
                {
                    dr.Cells[this.Column8.Name].ReadOnly = true;
                }
                if (dr.Cells[this.Column9.Name].Value!=null)
                {
                    dr.Cells[this.Column9.Name].ReadOnly = true;
                }

                if (Convert.ToBoolean(dr.Cells[this.Column10.Name].Value))
                {
                    dr.Cells[this.Column10.Name].ReadOnly = true;
                }
                if (Convert.ToBoolean(dr.Cells[this.Column11.Name].Value))
                {
                    dr.Cells[this.Column11.Name].ReadOnly = true;
                }
                if (dr.Cells[this.Column12.Name].Value != null)
                {
                    dr.Cells[this.Column12.Name].ReadOnly = true;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {           
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == this.Column9.Name)
            {
                var c = (Business.Models.SalerTaxManage)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;
                c.IsPayed =c.ReceivedMoney==null?false: true;
                this.dataGridView1.Refresh();
            }

            if (this.dataGridView1.Columns[e.ColumnIndex].Name == this.Column12.Name)
            {
                var c = (Business.Models.SalerTaxManage)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;
                c.IsNeedInvoice=c.IsInvoice = c.InvoiceMoney == null ||c.InvoiceMoney==0m ? false : true;
                this.dataGridView1.Refresh();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region 快捷键
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {            
            if (keyData == (Keys.F2))
            {
                
                if (this.dataGridView1.CurrentCell.OwningColumn.Name == this.Column12.Name)
                {
                    var c = (Business.Models.SalerTaxManage)this.dataGridView1.CurrentRow.DataBoundItem;
                    if (Editable || c.InvoiceMoney ==0m)
                    {
                        c.InvoiceMoney = c.PayMoney;
                        c.IsNeedInvoice = c.InvoiceMoney == null ? false : true;
                        c.IsInvoice = c.InvoiceMoney == null ? false : true;
                        this.dataGridView1.Refresh();
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
