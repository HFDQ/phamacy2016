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
    public partial class DirectSalesCreate : BaseFunctionForm
    {
        Guid _Id = Guid.NewGuid();
        Models.SupplyUnit _SupplyUnit=null;
        Models.PurchaseUnit _PurchaseUnit = null;
        BindingList<Business.Models.DirectSalesOrderDetailModel> _ListDirectSalesDetail = new BindingList<Business.Models.DirectSalesOrderDetailModel>();
        DirectSalesOrder dsOrder = null;
        private FormStatus FStatus = new FormStatus(FormStatusEnum.New);
        string msg = string.Empty;
        //构造函数1
        public DirectSalesCreate()
        {
            InitializeComponent();
            this.toolStripComboBox1.SelectedIndex = 0;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = this._ListDirectSalesDetail;

            this.toolStripComboBox1.SelectedIndex = -1;//强制触发事件，先设定为-1
            
            #region 审批流程绑定Combo
            var c=this.PharmacyDatabaseService.GetApprovalFlowTypeByBusiness(out msg, ApprovalType.DirectSalesApproval);
            if (c.Count() <=0)
            {
                MessageBox.Show("直调审批流程没有设置，请通知管理员设置直调审批项并为其设定审批节点。");
                this.Enabled = false;
            }
            this.toolStripComboBox2.ComboBox.DisplayMember = "Name";
            this.toolStripComboBox2.ComboBox.ValueMember = "Id";
            this.toolStripComboBox2.ComboBox.DataSource = c;
            #endregion

            #region 行号
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dataGridView2.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            #endregion

            #region 事件
            this.toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
            this.dataGridView1.DataError += dataGridView1_DataError;
            this.textBox1.KeyDown += textBox1_KeyDown;
            this.textBox2.KeyDown += textBox2_KeyDown;
            this.textBox3.KeyDown += textBox3_KeyDown;
            this.dataGridView1.CellClick += dataGridView1_CellClick;
            this.dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;

            this.dataGridView2.CellClick += dataGridView2_CellClick;
            this.dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;

            FStatus.FormStatusChanged += FStatus_FormStatusChanged;
            #endregion

            this.ClearCurrent();
            this.toolStripComboBox1.SelectedIndex = 0;//强制触发事件，由-1变为0，触发事件
        }

        void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView2.Columns[e.ColumnIndex].Name != this.Column22.Name) return;
            if (MessageBox.Show("确定要删除该单据吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            Business.Models.DirectSalesModel dsm = this.dataGridView2.Rows[e.RowIndex].DataBoundItem as Business.Models.DirectSalesModel;
            Models.DirectSalesOrder ds = this.PharmacyDatabaseService.GetDirectSalesOrder(dsm.DirectSalesOrderId, out msg);
            if (this.PharmacyDatabaseService.DeleteDirectSalesOrder(ds.Id, out msg))
            {
                MessageBox.Show("删除成功！单号：" + ds.DocumentNumber);
                this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "删除直调单成功，单号：" + ds.DocumentNumber);
                this.ClearCurrent();
            }
            else
            {
                MessageBox.Show("删除失败！单号：" + ds.DocumentNumber);
            }
        }

        void FStatus_FormStatusChanged(object sender, FormStatusChangeEventArgs e)
        {
            this.toolStripButton4.Enabled = this.toolStripButton5.Enabled= this.toolStripButton3.Enabled = e.fs == FormStatusEnum.Edit;
            this.toolStripButton2.Enabled =!(e.fs == FormStatusEnum.Edit);
        }

        void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView2.Columns[e.ColumnIndex].Name == this.Column22.Name) return;

            this.ClearCurrent();
            this.FStatus.FStatus = FormStatusEnum.Edit;
            Business.Models.DirectSalesModel dsom = this.dataGridView2.Rows[e.RowIndex].DataBoundItem as Business.Models.DirectSalesModel;           

            var dsod = this.PharmacyDatabaseService.GetDirectSalesOrderDetailModelByDirectSalesModel(dsom.DirectSalesOrderId,out msg);
            
            dsod.ToList<Business.Models.DirectSalesOrderDetailModel>().ForEach(r=>{this._ListDirectSalesDetail.Add(r);});
            this.label2.Text =dsom.SupplyUnitName;
            this.label5.Text = dsom.PurchaseUnitName;
            this.textBox4.Text = dsom.Checker;
            this.richTextBox1.Text = dsom.Memo;
            this._SupplyUnit = this.PharmacyDatabaseService.GetSupplyUnit(out msg, dsom.SupplyUnitId);
            this._PurchaseUnit =this.PharmacyDatabaseService.GetPurchaseUnit(out msg, dsom.PurchaseUnitId);
            this.dsOrder = this.PharmacyDatabaseService.GetDirectSalesOrder(dsom.DirectSalesOrderId, out msg);

            this._Id = dsom.DirectSalesOrderId;
            this.dataGridView1.Refresh();
        }

        void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox5.Enabled = !(this.toolStripComboBox1.SelectedIndex == (int)DirectSaleType.直调委托验收);
            this.textBox4.Enabled = !this.textBox5.Enabled;            
            this.textBox4.Text = this.textBox5.Text = string.Empty;
        }

        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Business.Models.DirectSalesOrderDetailModel dsodm = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Business.Models.DirectSalesOrderDetailModel;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == this.Column7.Name || this.dataGridView1.Columns[e.ColumnIndex].Name == this.Column8.Name || this.dataGridView1.Columns[e.ColumnIndex].Name == this.Column9.Name)
            {
                dsodm.SaleWholePrice = dsodm.SalePrice * dsodm.Amount;
                dsodm.SupplyWholePrice = dsodm.SupplyPrice * dsodm.Amount;
                dsodm.DirectDiffPrice = dsodm.SaleWholePrice - dsodm.SupplyWholePrice;
            }
            this.dataGridView1.Refresh();
        }
        
        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name != this.Column1.Name) return;
            if (MessageBox.Show("确定要删除该品种吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == this.Column1.Name)//删除药品
            {
                this._ListDirectSalesDetail.RemoveAt(e.RowIndex);
            }
        }

        void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            Business.Models.DirectSalesQueryModel dsq = new Business.Models.DirectSalesQueryModel();
            dsq.Keyword = this.textBox3.Text.Trim();

            if (this._PurchaseUnit == null)
            {
                MessageBox.Show("请先选择直调购货单位！"); return;
            }
            if (this._SupplyUnit == null)
            {
                MessageBox.Show("请先选择直调供货单位！"); return;
            }

            dsq.PurchaseUnitId = this._PurchaseUnit.Id;
            dsq.SupplyUnitId = this._SupplyUnit.Id;
            dsq.Keyword = this.textBox3.Text.Trim();
            if (e.KeyCode != Keys.Return) return;
            using (Form_DrugInfo frm = new Form_DrugInfo(dsq))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Business.Models.DirectSalesOrderDetailModel dsod = new Business.Models.DirectSalesOrderDetailModel 
                    {
                        Id=Guid.NewGuid(),
                        ProducGeneralName=frm._DI.ProductGeneralName,
                        Dosage=frm._DI.DictionaryDosageCode,
                        Specific=frm._DI.DictionarySpecificationCode,
                        PermitNumber=frm._DI.LicensePermissionNumber,
                        MeasurementUnitCode =frm._DI.DictionaryMeasurementUnitCode,    
                        FactoryName=frm._DI.FactoryName,
                        Amount=0,
                        DrugInfoId=frm._DI.Id,                            
                        SalePrice=0m,
                        SupplyPrice=0m,     
                        SaleWholePrice=0m,
                        SupplyWholePrice=0m,
                        DirectDiffPrice=0m
                    };
                    this._ListDirectSalesDetail.Add(dsod);
                }
            }
        }

        void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return) return;

            using (Form_PurchaseUnit frm = new Form_PurchaseUnit(this.textBox2.Text.Trim()))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.label5.Text = frm._PU.Name;
                    this.label6.Text = "地址：" + frm._PU.DetailedAddress;
                    this.label7.Text = "联系电话：" + frm._PU.ContactTel;
                    this.label10.Text = "负责人：" + frm._PU.Header;
                    this.label11.Text = "企业法人：" + frm._PU.LegalPerson;
                    this._PurchaseUnit = frm._PU;
                }
            }
        }

        void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return) return;

            using (Form_SupplyUnits frm = new Form_SupplyUnits(this.textBox1.Text.Trim()))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.label2.Text = frm._SU.Name;
                    this._SupplyUnit = frm._SU;
                }
            }
        }
        
        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        #region 新建并清空界面，并读取直调单信息
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.ClearCurrent();
        }
        private void ClearCurrent()
        {
            this.dsOrder = null;
            this._Id = Guid.NewGuid();
            this._ListDirectSalesDetail.Clear();
            this.FStatus.FStatus = FormStatusEnum.New;
            this._PurchaseUnit=null;
            this._SupplyUnit = null;
            this.textBox1.Text = this.textBox2.Text = this.textBox3.Text = string.Empty;
            this.textBox4.Text = this.textBox5.Text = string.Empty;
            this.label5.Text =this.label2.Text= "无";
            this.label6.Text = "地址：";
            this.label7.Text = "联系电话：";
            this.label10.Text = "负责人：";
            this.label11.Text = "企业法人：";
            this.richTextBox1.Text = string.Empty;
            this.GetDirectSalesOrderUnapproved();
            this.dataGridView1.Refresh();

        }
        #endregion

        //暂存
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();

            if (string.IsNullOrEmpty(this.richTextBox1.Text.Trim()))
            {
                MessageBox.Show("请填写直调申请说明！"); return;
            }

            if (this._SupplyUnit == null || this._PurchaseUnit == null || this._ListDirectSalesDetail.Count <= 0)
            {
                MessageBox.Show("请选择完整的直调供货单位或者购货单位信息！"); return;
            }

            if (string.IsNullOrEmpty(this.textBox5.Text) && string.IsNullOrEmpty(this.textBox4.Text))
            {
                string checkermsg = this.toolStripComboBox1.SelectedIndex == (int)DirectSaleType.直调委托验收?"直调委托验收员":checkermsg = "直调派驻验收员";                
                MessageBox.Show("请填写"+checkermsg+"信息！"); return;
            }

            #region 检查提交的品种信息
            if (this._ListDirectSalesDetail == null)
            {
                MessageBox.Show("请选择直调药品！");
            }
            else
            {                
                int count=1;
                this._ListDirectSalesDetail.ForEach(r=>{r.Sequence=count;count++;});
                var check=this._ListDirectSalesDetail.Where(r => r.Amount <= 0 || r.SalePrice <= 0 || r.SaleWholePrice <= 0 || r.SupplyPrice <= 0 || r.SupplyWholePrice <= 0);
                if (check.Count()>0)
                {
                    MessageBox.Show("请检查，有未填写完整的信息！" + "品名："+check.First().ProducGeneralName);
                    return;
                }
            }
            #endregion

            var s = from i in this._ListDirectSalesDetail
                    select new Models.DirectSalesOrderDetail
                    {
                        Amount = i.Amount,
                        DirectSaleDiff = (i.SalePrice-i.SupplyPrice)*i.Amount,
                        UnQualityAmount = 0m,
                        SalePrice = i.SalePrice,
                        SupplyPrice = i.SupplyPrice,
                        ProductDate = DateTime.Now,
                        QualityAmount = 0m,
                        DrugInfoId = i.DrugInfoId,
                        DirectSalesOrderId = this._Id,
                        OutValidDate = DateTime.Now,
                        Id = i.Id,
                        Squence = i.Sequence,
                    };

            if (((ToolStripButton)sender).Name == this.toolStripButton2.Name)
            {
                dsOrder = new DirectSalesOrder();
                dsOrder.CreateUserId = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id;
                dsOrder.CheckUserId = Guid.Empty;
                dsOrder.ApprovalStatusValue = (int)ApprovalStatus.NonApproval;
                dsOrder.ApprovalUserId = Guid.Empty;
                dsOrder.FlowId = Guid.NewGuid();
                dsOrder.Id = this._Id;
                dsOrder.PurchaseUnitId = this._PurchaseUnit.Id;
                dsOrder.SupplyUnitId = this._SupplyUnit.Id;
                dsOrder.UpdateUserId = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id;
                dsOrder.ApprovalDateTime = DateTime.Now;
                dsOrder.CheckUserName = this.toolStripComboBox1.SelectedIndex == (int)DirectSaleType.直调委托验收 ? this.textBox4.Text.Trim() : this.textBox5.Text.Trim();
                dsOrder.Memo = this.richTextBox1.Text.Trim();
                dsOrder.CheckStatusValue = (int)DirectSalesSatus.UnChecked;
                dsOrder.DirectSalesOrderDetails = s.ToArray();
                if (this.PharmacyDatabaseService.AddDirectSalesOrderAndDetail(dsOrder, out msg))
                {
                    var c = this.PharmacyDatabaseService.GetDirectSalesOrder(dsOrder.Id, out msg);
                    MessageBox.Show("提交成功！单号：" + c.DocumentNumber);
                    this.PharmacyDatabaseService.WriteLog(dsOrder.CreateUserId, "成功提交销售直调单，单号：" + c.DocumentNumber);
                    this.ClearCurrent();
                }
                this.GetDirectSalesOrderUnapproved();
            }

            if (((ToolStripButton)sender).Name == this.toolStripButton4.Name)
            {
                this.dsOrder.UpdateUserId = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id;
                dsOrder.PurchaseUnitId = this._PurchaseUnit.Id;
                dsOrder.SupplyUnitId = this._SupplyUnit.Id;
                dsOrder.CheckUserName = this.toolStripComboBox1.SelectedIndex == (int)DirectSaleType.直调委托验收 ? this.textBox4.Text.Trim() : this.textBox5.Text.Trim();
                dsOrder.DirectSalesOrderDetails = s.ToArray();
                dsOrder.Memo = this.richTextBox1.Text.Trim();
                if (this.PharmacyDatabaseService.SaveDirectSalesOrderAndDetail(dsOrder, out msg))
                {
                    MessageBox.Show("修改成功！单号：" + dsOrder.DocumentNumber);
                    this.PharmacyDatabaseService.WriteLog(dsOrder.CreateUserId, "成功修改销售直调单，单号：" + this.dsOrder.DocumentNumber);
                    this.ClearCurrent();
                }
                else
                {
                    MessageBox.Show("修改失败，请联系管理员!");
                }
            }
        }        
        //提交审批
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
            
            if (this.dsOrder == null)
            {
                MessageBox.Show("请双击直调列表中要审批的记录！");
                return;
            }
            if (MessageBox.Show("提交前请检查单据是否已经正确保存，确定要提交该记录至直调销售审批流程吗？审核不通过后，该单据将返回本界面，您可以继续编辑该单据！", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;

            this.dsOrder.ApprovalStatusValue = (int)ApprovalStatus.Waitting;

            ApprovalFlowType at = ((ApprovalFlowType)this.toolStripComboBox2.SelectedItem);
            bool b = this.PharmacyDatabaseService.AddDirectSaleApproval(this.dsOrder, at.Id, BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "新增直调销售审批，单号："+dsOrder.DocumentNumber, out msg);

            if (b)
            {
                MessageBox.Show("申请成功,请审批人员及时审批该单据！");
                this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "新增直调审批成功！单号：" + dsOrder.DocumentNumber);
            }
            else
            {
                MessageBox.Show("申请失败，请联系系统管理员！");
                return;
            }
            this.ClearCurrent();
        }

        private void GetDirectSalesOrderUnapproved()
        {
            int[] approvalstates={(int)Models.ApprovalStatus.NonApproval,(int)Models.ApprovalStatus.Reject};
            Business.Models.DirectSalesQueryModel dsq = new Business.Models.DirectSalesQueryModel();
            dsq.ApprovalStatus = approvalstates;
            dsq.CheckedStatusValue = (int)Models.DirectSalesSatus.UnChecked;
            dsq.Edt = DateTime.Now.AddDays(1).Date;
            dsq.Sdt = DateTime.Now.AddYears(-10).Date;

            var c = this.PharmacyDatabaseService.GetDirectSalesModelByApprovalStatus(dsq, out msg).OrderByDescending(r=>r.Createtime);
            this.dataGridView2.DataSource = new BindingCollection<Business.Models.DirectSalesModel>(c.ToList());
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.toolStripButton2_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (this.dsOrder == null)
            {
                MessageBox.Show("请双击直调列表中要删除的记录！");
                return;
            }
            if (MessageBox.Show("确定要取消该记录吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;

            this.dsOrder.ApprovalStatusValue = (int)ApprovalStatus.Canceled;

            bool b=this.PharmacyDatabaseService.SaveDirectSalesOrder(this.dsOrder, out msg);
            if (b)
            {
                MessageBox.Show("取消成功！");
                this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "取消直调单成功，单号：" + this.dsOrder.DocumentNumber);
                this.GetDirectSalesOrderUnapproved();
            }
        }
    }
}
