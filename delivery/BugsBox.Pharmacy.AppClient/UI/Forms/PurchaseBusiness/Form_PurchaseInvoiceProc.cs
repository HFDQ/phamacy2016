using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Models;
using System.Xml;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class Form_PurchaseInvoiceProc : BaseFunctionForm
    {
        List<SupplyUnit> ListSupplyUnit = null;
        string msg = string.Empty;
        ContextMenuStrip cms = new ContextMenuStrip();
        List<Business.Models.PurchaseTaxReturn> ListPurchaseTaxReturn = new List<Business.Models.PurchaseTaxReturn>();        
        List<Business.Models.PurchaseTaxReturn> ListOrigin = new List<Business.Models.PurchaseTaxReturn>();
        
        bool searchAll = false;
        bool Editable = false;

        public Form_PurchaseInvoiceProc()
        {
            InitializeComponent();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            User usr = BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser;

            var allRoles = this.PharmacyDatabaseService.AllRoles(out msg).Where(r=>r.Name.Contains("SystemRole")||r.Name.Contains("adminRole"));
            var allrolew = from m in this.PharmacyDatabaseService.AllRoleWithUsers(out msg) join a in allRoles on
                           m.RoleId equals a.Id where m.UserId==usr.Id select m;


            if (allrolew.ToList().Count <= 0)
            {
                this.toolStripButton3.Visible = false;
            }
            else
            {
                Editable = true;
            }

            this.dataGridView1.AutoGenerateColumns = false;

            ListSupplyUnit = this.PharmacyDatabaseService.AllSupplyUnits(out msg).Where(r=>r.Valid && r.Deleted==false).ToList();

            this.comboBox1.DataSource = ListSupplyUnit;
            this.comboBox1.DisplayMember="PinyinCode";
            this.comboBox1.ValueMember="Id";
            this.comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.comboBox1.SelectedValue = ListSupplyUnit.First().Id;

            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1).AddHours(-DateTime.Now.Hour).AddMinutes(-DateTime.Now.Minute);
            this.dateTimePicker2.Value = DateTime.Now.AddDays(1).AddHours(-DateTime.Now.Hour-1).AddMinutes(-DateTime.Now.Minute);

            #region 权限控制
            this.金额未付报警ToolStripMenuItem.Enabled=this.Column4.Visible = this.Column5.Visible = Editable || (this.Authorize(ModuleKeys.PIsPayed));//采购已付款＋实付金额
            this.税票未到报警ToolStripMenuItem.Enabled = this.Column6.Visible = this.Column7.Visible = this.Column8.Visible = Editable || (this.Authorize(ModuleKeys.PInvoiceArrived));

            
            #endregion

            #region 右键菜单
            Font font=new System.Drawing.Font("楷体",8,FontStyle.Bold);
            ToolStripMenuItem tsmi = null;

            cms.Items.Add("表格操作", null, null);
            cms.Items[cms.Items.Count - 1].Font = font;
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("自动调整列宽", null, AutoColums);
            cms.Items.Add("自动调整行高", null, AutoRows);

            cms.Items.Add("-");
            tsmi = new ToolStripMenuItem("批量信息填充");
            tsmi.DropDownItems.Add("实付金额", null, delegate(object sender, EventArgs e) { this.BactchFillData("实付金额"); });
            tsmi.DropDownItems.Add("已打款项", null, delegate(object sender, EventArgs e) { this.BactchFillData("已打款"); });
            tsmi.DropDownItems.Add("发票已到项", null, delegate(object sender, EventArgs e) { this.BactchFillData("发票已到"); });
            tsmi.DropDownItems.Add("票面金额项", null, delegate(object sender, EventArgs e) { this.BactchFillData("票面金额"); });
            cms.Items.Add(tsmi);
            cms.Items[cms.Items.Count - 1].Visible = false;

            cms.Items.Add("查询方式",null,null);
            cms.Items[cms.Items.Count - 1].Font=font;
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("该业务员记录",null,Invoice_Query);
            cms.Items.Add("全部业务员记录", null, Invoice_QueryByAll);
            cms.Items.Add("查看单据详细", null, 打开单据详细ToolStripMenuItem_Click);
            cms.Items.Add("-");
            cms.Items.Add("合并操作");
            cms.Items[cms.Items.Count - 1].Font=font;
            cms.Items[cms.Items.Count - 1].Enabled = false;
            //cms.Items.Add("-");
            //cms.Items.Add("合并标记", null, Concat_Record);
            //cms.Items.Add("解除合并标记", null, DeConcat_Record);
            //cms.Items.Add("显示合并记录", null, ShowConcatRecord);
            //cms.Items.Add("分解合并记录", null, ShowDeConcatRecord);
            cms.Items.Add("-");
            cms.Items.Add("保存操作");
            cms.Items[cms.Items.Count - 1].Font=font;
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("保存当前状态",null,SaveStatus);
            cms.Items.Add("-");
            cms.Items.Add("统计");
            cms.Items[cms.Items.Count - 1].Font = font;
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            
            tsmi = new ToolStripMenuItem("手工统计");
            tsmi.DropDownItems.Add("求和", null, delegate(object sender, EventArgs e) { this.GetResult(0); });
            tsmi.DropDownItems.Add("平均", null, delegate(object sender, EventArgs e) { this.GetResult(1); });
            tsmi.DropDownItems.Add("记数", null, delegate(object sender, EventArgs e) { this.GetResult(2); });
            cms.Items.Add(tsmi);
            ToolStripMenuItem tsmi2 = new ToolStripMenuItem("自动统计");
            tsmi2.DropDownItems.Add("按销售员统计图表", null, delegate(object sender, EventArgs e) { this.statics(0); });
            tsmi2.DropDownItems.Add("按销售员统计表格", null, delegate(object sender, EventArgs e) { this.statics(1); });
            tsmi2.DropDownItems.Add("按供货商统计表格", null, delegate(object sender, EventArgs e) { this.statics(2); });
            cms.Items.Add(tsmi2);

            #endregion
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label2.Text = ((SupplyUnit)this.comboBox1.SelectedItem).Name;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.search(false);
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="isAll">true为全查，只按时间</param>
        private void search(bool isAll)
        {
            if (!isAll)
            {                
                Guid SupplyUnitId = this.comboBox1.SelectedValue==null?Guid.Empty: (Guid)this.comboBox1.SelectedValue ;
                var c = this.PharmacyDatabaseService.GetPurchaseTaxReturn(SupplyUnitId, this.dateTimePicker1.Value.Date, this.dateTimePicker2.Value.AddDays(1).Date, out msg);
                ListPurchaseTaxReturn = c.OrderByDescending(r => r.EmployeeName).ToList();
                ListOrigin = this.PharmacyDatabaseService.GetPurchaseTaxReturn(SupplyUnitId, this.dateTimePicker1.Value, this.dateTimePicker2.Value, out msg).OrderByDescending(r => r.EmployeeName).ToList();
            }
            else
            {
                var c = this.PharmacyDatabaseService.GetPurchaseTaxReturn(Guid.Empty,this.dateTimePicker1.Value.Date,this.dateTimePicker2.Value.AddDays(1).Date,out msg);
                ListPurchaseTaxReturn = c.OrderByDescending(r=>r.EmployeeName).ToList();
                ListOrigin = this.PharmacyDatabaseService.GetPurchaseTaxReturn(Guid.Empty, this.dateTimePicker1.Value, this.dateTimePicker2.Value, out msg).OrderByDescending(r => r.EmployeeName).ToList();
            }

            this.searchAll = isAll;
            this.dataGridView1.DataSource =new BindingCollection<Business.Models.PurchaseTaxReturn> (this.ListPurchaseTaxReturn);

            //控制单元格是否可编辑
            if (Editable) return;
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                var c = dr.DataBoundItem as Business.Models.PurchaseTaxReturn;
                if (c.PayMoney != null && c.PayMoney>0m)
                {
                    dr.Cells[this.Column4.Name].ReadOnly = true;
                }
                if (c.InvoiceMoney != null && c.InvoiceMoney>0m)
                {
                    dr.Cells[this.Column7.Name].ReadOnly = true;
                }
            }
        }

        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.search(true);
        }

        private void 打开单据详细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.getPurchaseOrderDetails();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void 按销售员统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
                

        #region 右键菜单功能
        //调整列宽
        private void AutoColums(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        //调整行高
        private void AutoRows(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }
        //自动填充
        private void BactchFillData(string ColName)
        {
            switch (ColName)
            {
                case "实付金额":
                    foreach (var st in this.ListPurchaseTaxReturn)
                    {
                        st.PayMoney= st.TotalMoney;
                    }
                    break;
                case "已打款":
                    foreach (var st in this.ListPurchaseTaxReturn)
                    {
                        st.IsPayed = true;
                    }
                    break;
                case "发票已到":
                    foreach (var st in this.ListPurchaseTaxReturn)
                    {
                        st.IsInvoiceArrival = true;
                    }
                    break;
                case "票面金额":
                    foreach (var st in this.ListPurchaseTaxReturn)
                    {
                        st.InvoiceMoney = st.PayMoney;
                    }
                    break;                
            }
            this.dataGridView1.Refresh();
        }
        /// <summary>
        /// 1、按gridView选中业务员查询该业务员的所有记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Invoice_Query(object sender,EventArgs e)
        {
            string name=((Business.Models.PurchaseTaxReturn)this.dataGridView1.CurrentRow.DataBoundItem).TaxReturnUserName;
            var c = this.ListPurchaseTaxReturn.Where(r => r.TaxReturnUserName == name).OrderBy(r => r.DocumentNumber);
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.PurchaseTaxReturn>(c.ToList());
        }
        private void Invoice_QueryByAll(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.PurchaseTaxReturn>(this.ListPurchaseTaxReturn.ToList());
        }
        
        private void SaveStatus(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
            if (MessageBox.Show("确定要保存当前列表数据？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            

            if (this.PharmacyDatabaseService.SavePurchaseOrdersByPurchaseTaxReturn(ListPurchaseTaxReturn.ToArray(), out msg))
            {
                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("保存失败，请联系管理员！");
            }
            this.search(searchAll);

        }
        //手工统计
        private void GetResult(int i)
        {
            DataGridViewSelectedCellCollection sc = this.dataGridView1.SelectedCells;

            List<decimal> ListD = new List<decimal>();

            foreach (DataGridViewCell r in sc)
            {
                decimal d = 0m;
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
        //自动统计
        private void statics(int i)
        {
            if (i == 0)
            {
                var c = from p in ListPurchaseTaxReturn
                        group p by p.EmployeeName into g
                        select new
                        {
                            em = g.First().EmployeeName,
                            Rc = g.Count(),
                            payMoney = g.Sum(r => r.PayMoney),
                            invoice = g.Count(r => r.IsInvoiceArrival??false),
                            invoiceMoney = g.Sum(r => r.InvoiceMoney),
                            taxRate = g.First().Rate,
                            returnTax = g.Sum(r => r.ReturnTax),
                            payedCount = g.Count(r => r.IsPayed??false)
                        };
                Form_staticsChart frm = new Form_staticsChart(c.ToList<object>());
                frm.ShowDialog();
            }
            if (i == 1)
            {
                var c = from p in ListPurchaseTaxReturn
                        group p by p.EmployeeName into g
                        select new
                        {
                            em=g.First().EmployeeName,
                            Rc=g.Count(),
                            payMoney=g.Sum(r=>r.PayMoney),
                            invoice=g.Count(r=>r.IsInvoiceArrival??false),
                            invoiceMoney=g.Sum(r=>r.InvoiceMoney),
                            taxRate=g.First().Rate,
                            returnTax=g.Sum(r=>r.ReturnTax),
                            payedCount=g.Count(r=>r.IsPayed??false)
                        };
                
                Form_staticsTable frm = new Form_staticsTable(c.ToList());
                frm.ShowDialog();
            }
            if (i == 2)
            {
                var c = from p in ListPurchaseTaxReturn
                        group p by p.SupplyUnitName into g
                        select new
                        {
                            SupplyUnit = g.First().SupplyUnitName,
                            Rc = g.Count(),
                            payMoney = g.Sum(r => r.PayMoney),
                            invoice = g.Count(r => r.IsInvoiceArrival??false),
                            invoiceMoney = g.Sum(r => r.InvoiceMoney),
                            taxRate = g.First().Rate,
                            returnTax = g.Sum(r => r.ReturnTax),
                            payedCount = g.Count(r => r.IsPayed??false),
                            diff=g.Sum(r=>r.Diff)
                        };

                Form_staticsTable frm = new Form_staticsTable(c.ToList(),1);
                frm.ShowDialog();
            }
        }
        #endregion

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex == -1)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                return;
            }
            if (e.ColumnIndex == -1)
            {
                this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            }
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            if (e.RowIndex < 0 || e.ColumnIndex<0) return;
            
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cms.Show(MousePosition.X, MousePosition.Y);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            this.dataGridView1.ClearSelection();
            this.dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form_SalerTaxRate frm = new Form_SalerTaxRate();
            frm.ShowDialog();
            this.search(true);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Rows[e.RowIndex].Cells[this.Column4.Name].Value == null)
                dataGridView1.Rows[e.RowIndex].Cells[this.Column4.Name].Value = 0.00m;
            if (dataGridView1.Rows[e.RowIndex].Cells[this.Column7.Name].Value == null)
                dataGridView1.Rows[e.RowIndex].Cells[this.Column7.Name].Value = 0.00m;
            if (dataGridView1.Rows[e.RowIndex].Cells[this.Column5.Name].Value == null)
                dataGridView1.Rows[e.RowIndex].Cells[this.Column5.Name].Value = false;
            if (dataGridView1.Rows[e.RowIndex].Cells[this.Column6.Name].Value == null)
                dataGridView1.Rows[e.RowIndex].Cells[this.Column6.Name].Value = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            SaveStatus(sender, e);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (this.ListPurchaseTaxReturn.Count <= 0) return;
            var c = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Business.Models.PurchaseTaxReturn;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == this.Column4.Name)
            {              
                if(c.PayMoney!=null&&c.PayMoney>0m)
                    c.IsPayed = true;
            }
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == this.Column7.Name)
            {
                if(c.InvoiceMoney!=null && c.InvoiceMoney>0m)
                    c.IsInvoiceArrival = true;
            }
            this.dataGridView1.RefreshEdit();
        }

        private void Form_PurchaseInvoiceProc_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.dataGridView1.EndEdit();
            var c=this.ListPurchaseTaxReturn.Except(ListOrigin, new CompareD()).ToList();
            if (c.Count<=0)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = (MessageBox.Show("刚才修改了数据，还未执行保存操作，是否需要保存？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK);
                if (e.Cancel)
                {
                    this.SaveStatus(sender ,e);
                }
                e.Cancel = false;
            }
        }

        class CompareD : IEqualityComparer<Business.Models.PurchaseTaxReturn>
        {
            public bool Equals(Business.Models.PurchaseTaxReturn x,Business.Models.PurchaseTaxReturn y)
            {
                return x.IsPayed == y.IsPayed &&
                    x.IsInvoiceArrival == y.IsInvoiceArrival &&
                    x.InvoiceMoney == y.InvoiceMoney &&
                    x.PayMoney == y.PayMoney;
            }
            public int GetHashCode(Business.Models.PurchaseTaxReturn obj)
            {
                unchecked
                {
                    if (obj == null)
                        return 0;
                    int hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Id.GetHashCode();
                    return hashCode;
                }
            } 
        }

        private void 税票未到报警ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            var c = this.ListPurchaseTaxReturn.Where(r=>(r.IsInvoiceArrival??false)==false) .OrderBy(r => r.DocumentNumber);
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.PurchaseTaxReturn>(c.ToList());
        }

        /// <summary>
        /// 获取定单详细
        /// </summary>
        private void getPurchaseOrderDetails()
        {
            Guid PID = ((Business.Models.PurchaseTaxReturn)this.dataGridView1.CurrentRow.DataBoundItem).Id;
            Business.Models.PurchaseOrdeEntity poe = this.PharmacyDatabaseService.GetPurchaseOrderEntity(out msg, PID);
            FormPurchaseOrderEdit frm = new FormPurchaseOrderEdit(poe, false, true);
            frm.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "采购税费处理详细列表");
        }

        private void 金额未付报警ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var c = this.ListPurchaseTaxReturn.Where(r => (r.PayMoney??0m)==0m).OrderBy(r=>r.DocumentNumber);
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.PurchaseTaxReturn>(c.ToList());
        }

        private void 金额未付完报警ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            var c = this.ListPurchaseTaxReturn.Where(r => ((r.TotalMoney)-(r.PayMoney??0m))!=0).OrderBy(r => r.DocumentNumber);
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.PurchaseTaxReturn>(c.ToList());
        }
    }

    
}
