using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.PS;
using CustomValidatorsLibrary;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Service.Models;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormSalesOrderRecordIndex : BaseFunctionForm
    {
        private List<SalesOrderRecordOutput> _salesOrderList = new List<SalesOrderRecordOutput>();
        private PagerInfo pageInfo = new PagerInfo();
        private string message = string.Empty;
        
        BugsBox.Pharmacy.UI.Common.BaseRightMenu BM = null;

        Common.GoodsTypeClass GoodsType { get; set; }

        public FormSalesOrderRecordIndex()
        {
            try
            {
                InitializeComponent();
                this.dgvMain.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

                var t = this.PharmacyDatabaseService.AllBusinessScopes(out message).Where(r => !r.Deleted).OrderBy(r => r.Name).ToList();
                t.Insert(0, new BusinessScope { Id = Guid.Empty, Name = "全部" });

                this.cmbGoodsType.DisplayMember = "Name";
                this.cmbGoodsType.ValueMember = "Name";
                this.cmbGoodsType.DataSource = t;
                this.cmbGoodsType.SelectedIndex = 0;

                this.comboBoxSpeci.SelectedIndex = 0;
                
                DefineGridColumn();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
               // MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  传入药品类型的构造函数
        /// </summary>
        /// <param name="outInventoryStatus"></param>
        public FormSalesOrderRecordIndex(object goodsType)
        {
            try
            {
                InitializeComponent();
                if (goodsType.ToString() == "ylqx")
                    this.GoodsType = GoodsTypeClass.医疗器械;

                this.dgvMain.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
                DefineGridColumn();

                this.lblDrugTyp.Visible = false;
                this.cmbGoodsType.Visible = false;
                this.label3.Visible = false;
                this.comboBoxSpeci.Visible = false;
            }
            catch (Exception ex)
            {
                 Log.Error(ex);
            }
            

        }

        private void FormSalesOrderRecordIndex_Load(object sender, EventArgs e)
        {
            #region 菜单-删除
            //cm.Items.Add("记录操作");
            //cm.Items[cm.Items.Count - 1].Enabled = false;
            //cm.Items.Add("-");
            //MenuItem miBatch = new MenuItem("查询该药品购销记录", new EventHandler(miBatch_Click), Shortcut.CtrlS);
            //cm.Items.Add(miBatch.Text, null, miBatch_Click);
            //MenuItem miDrugInfo = new MenuItem("查询该药品历史销售记录", new EventHandler(miDrugInfo_Click), Shortcut.CtrlD);
            //cm.Items.Add(miDrugInfo.Text, null, miDrugInfo_Click);
            //cm.Items.Add("-");
            //cm.Items.Add("计算操作");
            //cm.Items[cm.Items.Count - 1].Enabled = false;
            //cm.Items.Add("-");
            //cm.Items.Add("求和操作 Alt+C", null, delegate(object o, EventArgs ex) {
            //    DataGridViewSelectedCellCollection sc = this.dgvMain.SelectedCells;
            //    List<decimal> ListD = new List<decimal>();
            //    foreach (DataGridViewCell r in sc)
            //    {
            //        decimal d = 0m;
            //        bool b = Decimal.TryParse(r.Value.ToString(), out d);
            //        if (!b)
            //        {
            //            MessageBox.Show("您所选择的单元格含有非数字，请取消其选择，谢谢！");
            //            return;
            //        }
            //        ListD.Add(d);
            //    }
            //    decimal result = ListD.Sum();
            //    MessageBox.Show("统计结果是：" + result.ToString("F4"));
            //    cm.Items["Sum"].Enabled = false;
            //});
            //cm.Items[cm.Items.Count - 1].Name = "Sum";
            //cm.Items[cm.Items.Count - 1].Enabled = false;
            #endregion

            BM = new BugsBox.Pharmacy.UI.Common.BaseRightMenu(this.dgvMain);
            BM.InsertMenuItem("查询该药品批次历史销售记录", miBatch_Click);
            BM.InsertMenuItem("查询该药品历史销售记录", miDrugInfo_Click);
            BM.InsertMenuItem("获取本品销售单", miSalesOrder);
        }



        /// <summary>
        /// 定义GridView 的列
        /// </summary>
        private void DefineGridColumn()
        {
            dgvMain.AutoGenerateColumns = false;
            Dictionary<string, string> dicGridViewTilte = new Dictionary<string, string>();

            dicGridViewTilte.Add("id","id");
            dicGridViewTilte.Add("DrugInventoryRecordID", "DrugInventoryRecordID");
            dicGridViewTilte.Add("ProductGeneralName", "通用名称");
            dicGridViewTilte.Add("permitCode", "国药准字");
            dicGridViewTilte.Add("productCode", "规格");
            dicGridViewTilte.Add("drugType", "剂型");
            dicGridViewTilte.Add("DictionaryMeasurmentUnitCode", "计量单位");
            dicGridViewTilte.Add("BatchNumber", "批号");
            dicGridViewTilte.Add("OutValidDate", "有效期");
            dicGridViewTilte.Add("FactoryName", "生产厂商");
            dicGridViewTilte.Add("PurchaseUnit", "购货单位");
            dicGridViewTilte.Add("SalesOrderCode", "销售单号");
            dicGridViewTilte.Add("Amount", "销售数量");
            dicGridViewTilte.Add("MeasurementUnit", "单位");
            dicGridViewTilte.Add("ActualUnitPrice", "单价");
            dicGridViewTilte.Add("Price", "金额");
            dicGridViewTilte.Add("SalesDate", "销售日期");
            dicGridViewTilte.Add("Saler","销售员");
            

            //根据字典构造DataGridView 列
            foreach (KeyValuePair<string, string> kv in dicGridViewTilte)
            {
                DataGridViewTextBoxColumn dgvtb = new DataGridViewTextBoxColumn();
                dgvtb.DataPropertyName = kv.Key;
                dgvtb.HeaderText = kv.Value;
                dgvtb.Name = kv.Key;
                this.dgvMain.Columns.Add(dgvtb);
            }

            this.dgvMain.Columns[0].Visible = false;
            this.dgvMain.Columns[1].Visible = false;

            this.dgvMain.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        private void pcMain_DataPaging()
        {
            try
            {
                int pageIndex = this.pcMain.PageIndex;
                int pageSize = this.pcMain.PageSize;
                GetSalesOrderList(pageIndex, pageSize);
                dgvMain.DataSource =new BindingCollection<Business.Models.SalesOrderRecordOutput>( _salesOrderList);
            }
            catch (Exception ex)
            {
                 Log.Error(ex);
            }
        }

        /// <summary>
        ///  获取查询结果
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        private void GetSalesOrderList(int pageIndex, int pageSize)
        {
            _salesOrderList = null;
            string msg = string.Empty;
            SalesOrderRecordInput scsi = InitSalesOrderRecordInput();
            _salesOrderList = PharmacyDatabaseService.GetSalesOrderRecordPaged(out pageInfo, out msg, scsi, pageIndex, pageSize).ToList();

            if (this.GoodsType == GoodsTypeClass.医疗器械)
            {
                this.dgvMain.Columns["permitCode"].HeaderText = "注册证或备案凭证编号";
                this.dgvMain.Columns["productCode"].HeaderText = "规格(型号)";
                this.dgvMain.Columns["drugType"].Visible = false;
            }
        }

        /// <summary>
        /// 初始化查询条件
        /// </summary>
        /// <returns></returns>
        private SalesOrderRecordInput InitSalesOrderRecordInput() 
        {
            SalesOrderRecordInput sori = new SalesOrderRecordInput();
            
            sori.SalesFromDate = dtFrom.Value.Date;
            sori.SalesToDate = dtTo.Value.AddDays(1).Date;
            
            sori.productName = this.txtDrugName.Text;
            sori.BatchNumber = this.txtBatchNo.Text;
            sori.FactoryName = this.txtFactoryName.Text.Trim();
            
            if (cmbPurchase.SelectedValue != null)
                sori.PurchaseUnitID = (Guid)cmbPurchase.SelectedValue;
            else
                sori.PurchaseUnitID = Guid.Empty;

            if (this.GoodsType == GoodsTypeClass.药品)
                sori.GoodsTypeValue = cmbGoodsType.SelectedValue.ToString() == "全部" ? string.Empty : cmbGoodsType.SelectedValue.ToString();
            else if(this.GoodsType == GoodsTypeClass.医疗器械)
            {
                sori.GoodsTypeValue = "医疗器械";
            }

            sori.IsSpecial = this.comboBoxSpeci.SelectedIndex;

            sori.Seller = this.textBox1.Text.Trim();

            return sori;
        }

        /// <summary>
        /// 搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        ///  购货单位下拉列表框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPurchase_DropDown(object sender, EventArgs e)
        {
            try
            {
                //打开购货单位窗体
                FormPurchaseSelector form = new FormPurchaseSelector();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.cmbPurchase.DataSource = new List<PurchaseUnit> { form.Result };
                    this.cmbPurchase.DisplayMember = "Name";
                    this.cmbPurchase.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("打开购货单位窗体失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void dgvMain_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        void miBatch_Click()
        {
            Guid saleOrderDetailID = Guid.Empty;
            var c = this.dgvMain.CurrentRow.DataBoundItem as Business.Models.SalesOrderRecordOutput;
            saleOrderDetailID = c.id;
            Storage.Form_DrugPath frm = new Storage.Form_DrugPath(saleOrderDetailID,1);
            frm.ShowDialog();
        }

        void miDrugInfo_Click()
        {
            Guid saleOrderDetailID = Guid.Empty;
            Guid InvID = _salesOrderList[this.dgvMain.CurrentRow.Index].DrugInventoryRecordID;
            DrugInventoryRecord diir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out message, InvID);
            Guid druginfoID = diir.DrugInfoId;
            if (diir.Id != Guid.Empty)
            {
                Form_HistoryPurchase frm = new Form_HistoryPurchase(druginfoID, 3);
                frm.ShowDialog();
                this.dgvMain.Focus();
            }
        }

        void miSalesOrder()
        {
            Business.Models.SalesOrderRecordOutput soro = this.dgvMain.CurrentRow.DataBoundItem as Business.Models.SalesOrderRecordOutput;

            SalesOrder so = this.PharmacyDatabaseService.GetSalesOrder(out message, soro.SalesOrderId);

            SalesBusiness.FormSalesOrderEdit frm = new FormSalesOrderEdit(so,true);
            frm.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dgvMain,"药品销售记录查询单");
        }

        private void txtDrugName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        private void Search()
        {
            try
            {
                int pageIndex = this.pcMain.PageIndex;
                int pageSize = this.pcMain.PageSize;
                GetSalesOrderList(pageIndex, pageSize);
                dgvMain.DataSource = new BindingCollection<Business.Models.SalesOrderRecordOutput>( _salesOrderList);

                //将总记录数赋值给分页控件
                pcMain.RecordCount = pageInfo.RecordCount;
                pcMain.PageIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("检索数据失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }
    }
}
