using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    /// <summary>
    /// 药品选择供销售时生成明细时使用 
    /// 1.加载药品库存中可销售和可零售的数量大于0的药品库存.且该药品在信息表中必须符合可以销售可零售条件(此窗口完成)
    /// 2.生成明细时要求再次检查可以销售可零售数量(销售相关窗体完成)
    /// 3.在点完此窗品的OK之后,要检查销售窗体中所选择的采购商,是否要以采购此药品,由药品信息的经营范围参与检查.(销售相关窗体完成)
    /// </summary>
    public partial class FormDrugForSalesSelector : BaseFunctionForm
    {
        public Common.GoodsTypeClass GoodsType { get; set; }

        private Guid purchaseUnitGuid;
        private List<DrugInventoryRecord> drugInventoryRecord = null;
        private string msg = string.Empty;
        public SalesDrugType salesDrugType = new SalesDrugType();

        public List<DrugInventoryRecord> result = null;
        public BindingList<bindingDrugsForsale> bList = new BindingList<bindingDrugsForsale>();
        public List<bindingDrugsForsale> list = new List<bindingDrugsForsale>();

        BindingList<bindingDrugsForsale> bListDown = new BindingList<bindingDrugsForsale>();
        public bool isExist = false;

        /// <summary>
        /// 药品选择构造
        /// </summary>
        /// <param name="_purchaseUnitGuid">采购商guid</param>
        public FormDrugForSalesSelector(Guid _purchaseUnitGuid)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            purchaseUnitGuid = _purchaseUnitGuid;
            this.dataGridView2.DataSource = bListDown;
            this.Load += (sender, e) => getData();
        }

        private void getData()
        {
            bList.Clear();
            list.Clear();
            try
            {
                drugInventoryRecord = this.PharmacyDatabaseService.GetDrugInventoryRecordForDrugInfoForSalesSelector(out msg, purchaseUnitGuid, txtTYM.Text, string.Empty, txtCode.Text).OrderBy(r => r.DrugInfo.ProductGeneralName).ToList();

                foreach (var i in drugInventoryRecord)
                {
                    int IndexB = i.BatchNumber.LastIndexOf("(");
                    if (IndexB > 1)
                    {
                        i.BatchNumber = i.BatchNumber.Substring(0, IndexB).Trim();
                    }
                }

                if (!string.IsNullOrWhiteSpace(msg))
                {
                    MessageBox.Show(msg);
                    this.Dispose();
                    return;
                }

                if (drugInventoryRecord.Count > 0)
                {
                    var c = (from i in drugInventoryRecord
                             group i by new
                             {
                                 i.BatchNumber,
                                 i.DrugInfoId,
                                 i.Decription,
                                 i.PurchasePricce
                             } into g
                             select new bindingDrugsForsale
                      {
                          ProductGeneralName = g.FirstOrDefault().DrugInfo.ProductGeneralName,
                          ProductName = g.FirstOrDefault().DrugInfo.ProductName,
                          Code = g.FirstOrDefault().DrugInfo.DictionaryDosageCode,
                          specific = g.FirstOrDefault().DrugInfo.DictionarySpecificationCode,
                          StandardCode = g.FirstOrDefault().DrugInfo.StandardCode,
                          BatchNumber = g.FirstOrDefault().BatchNumber,
                          OutValidDate = g.FirstOrDefault().OutValidDate,
                          CanSaleNum = g.Sum(a => a.CanSaleNum),
                          purchasePrice = g.FirstOrDefault().PurchasePricce,
                          SalePrice = g.FirstOrDefault().DrugInfo.SalePrice,
                          FactoryName = g.FirstOrDefault().DrugInfo.FactoryName,
                          Id = g.FirstOrDefault().Id,
                          PY = g.FirstOrDefault().DrugInfo.Pinyin,
                          saleNum = 0,
                          measurement = g.FirstOrDefault().DrugInfo.DictionaryMeasurementUnitCode,
                          purchaseInInventoryID = g.FirstOrDefault().PurchaseInInventeryOrderDetailId,
                          druginfoId = g.FirstOrDefault().DrugInfoId,
                          BusinessScopeCode = g.FirstOrDefault().DrugInfo.BusinessScopeCode,
                          Decription = g.FirstOrDefault().Decription,
                          ProductDate = g.FirstOrDefault().PruductDate,
                          DrugInfo = g.FirstOrDefault().DrugInfo
                      }).OrderBy(r => r.ProductName).ThenBy(r => r.OutValidDate).ToList();



                    #region 医疗器械过滤
                    if (this.GoodsType == GoodsTypeClass.药品)
                    {
                        c = c.Where(r => r.BusinessScopeCode != GoodsTypeClass.医疗器械.ToString()).ToList();
                    }
                    else if (this.GoodsType == GoodsTypeClass.医疗器械)
                    {
                        this.checkBox1.Visible = false;
                        c = c.Where(r => r.BusinessScopeCode == GoodsTypeClass.医疗器械.ToString()).ToList();
                    }
                    #endregion

                    foreach (var i in c)
                    {
                        bList.Add(i);
                        list.Add(i);
                    }

                    this.dataGridView1.DataSource = bList;
                    isExist = true;
                }
                else
                {
                    MessageBox.Show("没有可以配送出库的药品，请查询库存或客户经营范围！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.submit();
        }
        /// <summary>
        /// 提交
        /// </summary>
        private void submit()
        {
            if (this.dataGridView2.IsCurrentCellInEditMode) this.dataGridView1.EndEdit();
            if (this.dataGridView2.Rows.Count <= 0) return;

            foreach (DataGridViewRow dgvr in this.dataGridView2.Rows)
            {
                if (Convert.ToDecimal(dgvr.Cells[this.Column12.Name].Value) > Convert.ToDecimal(dgvr.Cells[dataGridViewTextBoxColumn9.Name].Value))
                {
                    MessageBox.Show("填写数量超过可用库存，请修改销售数量！");
                    this.dataGridView2.CurrentCell = dgvr.Cells[this.Column12.Name];
                    this.dataGridView2.BeginEdit(true);
                    return;
                }
            }

            result = new List<DrugInventoryRecord>();
            if (this.bListDown.Count > 0)
            {

                var re = from i in bListDown
                         select new DrugInventoryRecord
                         {
                             BatchNumber = i.BatchNumber,
                             CanSaleNum = i.CanSaleNum,
                             CurrentInventoryCount = i.CanSaleNum,
                             SalesCount = i.saleNum,
                             DrugInfoId = i.druginfoId,
                             Id = i.Id,
                             InInventoryCount = i.CanSaleNum,
                             OutValidDate = i.OutValidDate,
                             PurchaseInInventeryOrderDetailId = i.purchaseInInventoryID,
                             Decription = i.Decription,
                             PruductDate = i.ProductDate,
                             PurchasePricce = i.purchasePrice,
                             DrugInfo = i.DrugInfo,
                             OnRetailCount = i.SalePrice,  //本字段借用来表示本界面定义的销售价，

                         };

                result = re.ToList();

                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("采购药品列表没有任何记录，请单击药品列表中的记录后再点击提交。");
            }
        }

        private void FormDrugForSalesSelector_Load(object sender, EventArgs e)
        {

        }

        private void txtBWM_TextChanged(object sender, EventArgs e)
        {
            var all = list.Where(r => r.PY != null && (r.PY.Contains(txtBWM.Text) || r.PY.Contains(txtBWM.Text.ToUpper())));
            bList.Clear();
            foreach (var c in all)
            {
                bList.Add(c);
            }
        }

        private void FormDrugForSalesSelector_Activated(object sender, EventArgs e)
        {
            txtBWM.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || this.dataGridView2.CurrentRow == null || this.dataGridView2.CurrentCell.OwningColumn.Name == Column12.Name) return;
            DataGridViewRow dgvr = this.dataGridView2.CurrentRow;
            bindingDrugsForsale b = (bindingDrugsForsale)dgvr.DataBoundItem;
            bListDown.Remove(b);
            list.Add(b);
            bList.Add(b);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || this.dataGridView1.CurrentRow == null) return;
            DataGridViewRow dgvr = this.dataGridView1.CurrentRow;
            bindingDrugsForsale b = (bindingDrugsForsale)dgvr.DataBoundItem;
            bListDown.Add(b);
            list.Remove(b);
            bList.Remove(b);
        }

        private void txtBWM_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBWM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (this.dataGridView1.Rows.Count <= 0) return;
                this.dataGridView1.Focus();
                this.dataGridView1.Rows[0].Selected = true;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return) return;
            this.dataGridView2.Focus();
            DataGridViewRow dgvr = this.dataGridView1.CurrentRow;
            bindingDrugsForsale b = (bindingDrugsForsale)dgvr.DataBoundItem;
            bListDown.Add(b);
            list.Remove(b);
            bList.Remove(b);
            this.dataGridView2.CurrentCell = this.dataGridView2.Rows[this.dataGridView2.RowCount - 1].Cells[Column12.Name];
            this.dataGridView2.BeginEdit(true);
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (this.dataGridView2.CurrentCell == null) return;
                if (this.dataGridView2.CurrentCell.OwningColumn.Name == this.Column12.Name)
                {
                    decimal SaleNum = Convert.ToDecimal(this.dataGridView2.CurrentCell.Value);
                    decimal canSaleNum = Convert.ToDecimal(this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells[dataGridViewTextBoxColumn9.Name].Value);
                    if (SaleNum <= 0) return;
                    if (SaleNum > canSaleNum)
                    {
                        this.dataGridView2.EndEdit();
                        MessageBox.Show("超出可用库存：" + canSaleNum.ToString());
                        this.dataGridView2.BeginEdit(true);
                        return;
                    }
                    else
                    {
                        this.dataGridView2.CurrentCell = this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells[this.Column11.Name];
                        this.dataGridView2.BeginEdit(true);
                        return;
                    }
                }

                if (this.dataGridView2.CurrentCell.OwningColumn.Name == this.Column11.Name)
                {
                    this.dataGridView2.EndEdit();
                    txtBWM.Clear();
                    txtBWM.Focus();
                }
            }

            if (e.KeyCode == Keys.F2)
            {
                #region F2提交
                //result = new List<DrugInventoryRecord>();
                //if (this.bListDown.Count > 0)
                //{
                //    if (this.dataGridView1.Rows.Count <= 0) return;

                //    foreach (DataGridViewRow dgvr in this.dataGridView2.Rows)
                //    {
                //        if (Convert.ToDecimal(dgvr.Cells[this.Column12.Name].Value) > Convert.ToDecimal(dgvr.Cells[dataGridViewTextBoxColumn9.Name].Value))
                //        {
                //            MessageBox.Show("填写数量超过可用库存，请修改销售数量！");
                //            this.dataGridView2.CurrentCell = dgvr.Cells[this.Column12.Name];
                //            this.dataGridView2.BeginEdit(true);
                //            return;
                //        }
                //    }


                //    foreach (var i in bListDown)
                //    {
                //        var c = drugInventoryRecord.Where(r => r.Id == i.Id).First();
                //        c.CanSaleNum = i.CanSaleNum;
                //        c.SalesCount = i.saleNum;
                //        result.Add(c);
                //    }
                //    this.DialogResult = DialogResult.OK;
                //    this.Dispose();
                //}
                //else
                //{
                //    MessageBox.Show("采购药品列表没有任何记录，请单击药品列表中的记录后再点击提交。");
                //}
                #endregion

                //this.submit();
            }

            if (e.KeyCode == Keys.F3)
            {

                DataGridViewRow dgvr = this.dataGridView2.CurrentRow;
                bindingDrugsForsale b = (bindingDrugsForsale)dgvr.DataBoundItem;
                bListDown.Remove(b);
                list.Add(b);
                bList.Add(b);
                this.txtBWM.Focus();
            }

            if (e.KeyCode == Keys.F4)
            {
                this.dataGridView2.CurrentCell.Value = this.dataGridView2.Rows[this.dataGridView2.CurrentCell.RowIndex].Cells[this.dataGridViewTextBoxColumn9.Name].Value;
            }

        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void FormDrugForSalesSelector_KeyDown(object sender, KeyEventArgs e)
        {

        }
        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            string message = string.Empty;
            if (keyData == Keys.F6)
            {
                if (this.dataGridView1.SelectedCells.Count > 0)
                {
                    Guid InID = Guid.Parse(this.dataGridView1.Rows[this.dataGridView1.SelectedCells[0].RowIndex].Cells[Column13.Name].Value.ToString());
                    if (InID != Guid.Empty)
                    {
                        Form_HistoryPurchase frm = new Form_HistoryPurchase(InID);
                        frm.ShowDialog();
                        this.dataGridView1.Focus();
                    }
                }
                return true;
            }

            if (keyData == Keys.F5)
            {
                Guid InID = Guid.Parse(this.dataGridView1.Rows[this.dataGridView1.SelectedCells[0].RowIndex].Cells[this.ColumnDrugInfoID.Name].Value.ToString());
                if (InID != Guid.Empty)
                {
                    Form_HistoryPurchase frm = new Form_HistoryPurchase(InID, 1);
                    frm.ShowDialog();

                }
                return true;
            }

            if (keyData == (Keys.Alt | Keys.F))
            {
                if (this.dataGridView2.SelectedCells.Count > 0)
                {
                    Guid druginfoID = Guid.Parse(this.dataGridView2.Rows[this.dataGridView2.SelectedCells[0].RowIndex].Cells[this.druginfoid.Name].Value.ToString());

                    if (druginfoID != Guid.Empty)
                    {
                        Form_HistoryPurchase frm = new Form_HistoryPurchase(druginfoID, 3);
                        frm.ShowDialog();
                        this.dataGridView2.BeginEdit(true);
                    }
                }
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D))
            {
                if (this.dataGridView2.SelectedCells.Count > 0)
                {
                    Guid druginvID = Guid.Parse(this.dataGridView2.Rows[this.dataGridView2.SelectedCells[0].RowIndex].Cells[this.dataGridViewTextBoxColumn1.Name].Value.ToString());

                    if (druginvID != Guid.Empty)
                    {
                        Form_HistoryPurchase frm = new Form_HistoryPurchase(druginvID, 2);
                        frm.ShowDialog();
                        this.dataGridView2.BeginEdit(true);
                    }
                }
                return true;
            }

            if (keyData == Keys.F2)
            {
                this.submit();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var all = list.Where(r => r.BusinessScopeCode == "中药材" || r.BusinessScopeCode == "中药饮片");
                bList.Clear();
                foreach (var c in all)
                {
                    bList.Add(c);
                }
                this.dataGridView1.Columns["Column9"].Visible = false;
                this.dataGridView1.Columns["Column7"].Visible = false;
                this.dataGridView2.Columns["dataGridViewTextBoxColumn7"].Visible = false;
                this.dataGridView2.Columns["dataGridViewTextBoxColumn8"].Visible = false;
                salesDrugType = SalesDrugType.ChineseDrug;
            }
            else
            {
                var all = list.Where(r => r.BusinessScopeCode != "中药材" && r.BusinessScopeCode != "中药饮片");

                bList.Clear();
                foreach (var c in all)
                {
                    bList.Add(c);
                }
                this.dataGridView1.Columns["origin"].Visible = false;
                this.dataGridView2.Columns["colOrigin"].Visible = false;
                salesDrugType = SalesDrugType.Drug;
            }
        }

    }
    public class bindingDrugsForsale
    {
        public string ProductGeneralName { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public string specific { get; set; }
        public string StandardCode { get; set; }
        public string BatchNumber { get; set; }
        public decimal purchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime OutValidDate { get; set; }
        public decimal CanSaleNum { get; set; }
        public string FactoryName { get; set; }
        public System.Guid Id { get; set; }
        public string PY { get; set; }
        public decimal saleNum { get; set; }
        public string measurement { get; set; }
        public Guid purchaseInInventoryID { get; set; }
        public Guid druginfoId { get; set; }
        public string BusinessScopeCode { get; set; }
        public string Decription { get; set; }

        public DateTime ProductDate { get; set; }

        public DrugInfo DrugInfo { get; set; }
    }
}
