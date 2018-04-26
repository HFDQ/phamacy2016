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
    public partial class FormPurchaseOrderGenerator : BaseFunctionForm
    {
        private List<string> listSupply = new List<string>();
        private BindingList<DrugInfo> bList = new BindingList<DrugInfo>();
        private Guid _SupplyID = Guid.Empty;
        int TaxReturnStatus = -1;
        List<User> ListUsr;
        UI.Forms.BaseForm.BasicInfoRightMenu Bcms = null;
        string msg = string.Empty;

        private Common.GoodsTypeClass GoodsType = Common.GoodsTypeClass.药品;

        public FormPurchaseOrderGenerator()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            string msg = String.Empty;
            CellDataValidBackColor = clmDrugName.DefaultCellStyle.BackColor;
            string employeeName = AppClientContext.CurrentUser.Employee.Name;
            label10.Text = employeeName;
            label4.Text = "";
            lblCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分");
            this.dataGridView1.Rows.Clear();

            Bcms = new BaseForm.BasicInfoRightMenu(this.dataGridView1);
            Bcms.InsertDrugBasicInfo();
            Bcms.InsertSupplyUnitBasicInfo();

            this.dataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_CellMouseClick); //右键菜单查询品种ID


            #region 采购返税点操作。
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml");
            XmlNodeList xmlNode = doc.SelectNodes("/SalePriceType/TaxReturn");
            if (xmlNode == null || xmlNode.Count<=0) return;
            TaxReturnStatus = Convert.ToInt16(xmlNode[0].Attributes[0].Value);
            if (this.TaxReturnStatus == 1)
            {
                this.label18.Visible = this.label17.Visible = this.comboBox1.Visible = false;
                ListUsr = this.PharmacyDatabaseService.AllUsers(out msg).ToList();                
                this.comboBox1.DisplayMember = "Account";
                this.comboBox1.ValueMember = "Id";
                this.comboBox1.DataSource = ListUsr;
                this.comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.comboBox1.SelectedValue = ListUsr.First().Id;
                this.comboBox1.Focus();
                this.ckDirectMarketing.Visible = false;
            }
            #endregion
        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            Bcms.DrugId = (this.dataGridView1.Rows[e.RowIndex].DataBoundItem as DrugInfo).Id;
        }

        private void GetDrugInfo()
        {
            if (this.dataGridView1.CurrentRow == null) return;
            var d = this.dataGridView1.CurrentRow.DataBoundItem as DrugInfo;
            
            var di = this.PharmacyDatabaseService.GetDrugInfo(out msg, d.Id);
            UI.UserControls.ucGoodsInfo ucControl = new UserControls.ucGoodsInfo(di);
            Form f = new Form();
            f.WindowState = FormWindowState.Normal;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Text = di.ProductGeneralName;
            f.AutoSize = true;
            f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Panel p = new Panel();
            p.AutoSize = true;
            p.Controls.Add(ucControl);
            f.Controls.Add(p);
            SetControls.SetControlReadonly(f, true);
            f.ShowDialog();
        }

        //查看供货商信息
        private void GetSupplyUnitInfo()
        {
            if (_SupplyID == null || _SupplyID == Guid.Empty) return;
            SupplyUnit su = this.PharmacyDatabaseService.GetSupplyUnit(out msg, _SupplyID);
            UserControls.ucSupplyUnit us = new UserControls.ucSupplyUnit(su, false);
            Form f = new Form();
            f.Text = su.Name;
            f.AutoSize = true;
            f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Panel p = new Panel();
            p.AutoSize = true;
            p.Controls.Add(us);
            f.Controls.Add(p);
            f.ShowDialog();
        }

        /// <summary>
        /// 根据选择的药品构造datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectDrugs_Click(object sender, EventArgs e)
        {
            try
            {
                FormDrugForPurchaseSelector drugSelect = new FormDrugForPurchaseSelector();
                drugSelect.ShowDialog();
                Dictionary<Guid, DrugInfo> addList = drugSelect.ListDrugsSelected;
                dataGridViewAdd(addList);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }

        }

        /// <summary>
        /// 对gridview中数据进行处理，自动生成采购单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeneratePurchaseRecords_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("请选择入库药品", "错误", MessageBoxButtons.OK);
                    return;
                }
                string msg = string.Empty;
                
                listSupply.Clear();
                string OrderNumber=string.Empty;
                if (GetSupplyList())
                {
                    for (int i = 0; i < listSupply.Count; i++)
                    {
                        #region 构造主表
                        PurchaseOrder order = new PurchaseOrder();
                        List<PurchaseOrderDetail> orderDetails = new List<PurchaseOrderDetail>();

                        order.Decription = richTextBox1.Text;

                        if (!string.IsNullOrEmpty(msg))
                        {
                            MessageBox.Show(msg);
                            return;
                        }

                        order.SupplyUnitId = Guid.Parse(listSupply[i]);
                        order.CreateUserId = AppClientContext.CurrentUser.Id;
                        order.OrderStatusValue = (int)OrderStatus.Waitting;
                        order.AllReceiptedDate = DateTime.Now;
                        order.DirectMarketing = ckDirectMarketing.Checked;
                        order.ShippingMethod = string.Empty;
                        order.PurchasedDate = DateTime.Now;

                        //if(!ckDirectMarketing.Checked)
                        //    order.TaxReturnUserID =(Guid)this.comboBox1.SelectedValue;
                        #endregion

                        #region 构造明细表
                        for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                        {
                            if (listSupply[i].Equals(this.dataGridView1.Rows[j].Cells["clmSupplyUnitId"].Value.ToString()))
                            {
                                PurchaseOrderDetail detail = new PurchaseOrderDetail();
                                detail.sequence = j;
                                detail.DrugInfoId = Guid.Parse(this.dataGridView1.Rows[j].Cells["clmDrugId"].Value.ToString());
                                detail.Amount = Decimal.Parse(this.dataGridView1.Rows[j].Cells["clmDrugNumber"].Value.ToString());
                                orderDetails.Add(detail);
                                if ( detail.DrugInfoId == Guid.Empty || detail.Amount <= 0m)
                                {
                                    MessageBox.Show("第"+(j+1).ToString()+"行有数据为0，或者小于0，请检查数据！");
                                    this.dataGridView1.Rows[j].Selected = true;
                                    return;
                                }
                            }
                        }
                        #endregion

                        OrderNumber=this.PharmacyDatabaseService.CreatePurchaseOrder(out msg, order, orderDetails.ToArray());
                        if (!String.IsNullOrEmpty(msg))
                        {
                            btnGeneratePurchaseRecords.Enabled = true;
                            MessageBox.Show(msg, "错误", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    MessageBox.Show("入库记录创建成功，单号：" + OrderNumber, "提示", MessageBoxButtons.OK);
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行入库单生成操作成功，单号：" + OrderNumber);
                    (Parent.FindForm() as frmMain).ShowForm(new FormPurchaseOrderWaittingList());
                    this.FormClosing-=new FormClosingEventHandler(FormPurchaseOrderGenerator_FormClosing);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                btnGeneratePurchaseRecords.Enabled = true;
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }
        
        private void dataGridViewAdd(Dictionary<Guid, DrugInfo> listDrugInfo)
        {
            try
            {
                foreach (var unit in listDrugInfo)
                {
                    bool exist = false;
                    foreach (DataGridViewRow r in this.dataGridView1.Rows)
                    {
                        if (r.Cells["clmDrugId"].Value.ToString().Contains( unit.Value.Id.ToString()))
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {
                        string msg = string.Empty;
                        decimal currentInventoryCount = 0;
                        Guid drugId = Guid.Parse(unit.Value.Id.ToString());
                        DrugInfo drg = this.PharmacyDatabaseService.GetDrugInfo(out msg, drugId);
                        DrugInventoryRecord[] drgInv = this.PharmacyDatabaseService.AllDrugInventoryRecords(out msg);
                        for (int i = 0; i < drgInv.Length; i++)
                            if (drgInv[i].DrugInfoId == drugId)
                                currentInventoryCount = drgInv[i].CurrentInventoryCount;
                                                
                        int index = this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[index].Cells["clmDrugId"].Value = unit.Value.Id.ToString();
                        this.dataGridView1.Rows[index].Cells["clmDrugName"].Value = unit.Value.ProductGeneralName;
                        this.dataGridView1.Rows[index].Cells["clmDrugNumber"].Value =0;
                        this.dataGridView1.Rows[index].Cells["clmSupplyUnitId"].Value = string.Empty;
                        this.dataGridView1.Rows[index].Cells["clmSupplyName"].Value = string.Empty;
                        this.dataGridView1.Rows[index].Cells["clmPurchasePrice"].Value = unit.Value.PurchasePrice;
                        this.dataGridView1.Rows[index].Cells["clmActualPrice"].Value = unit.Value.PurchasePrice;
                        this.dataGridView1.Rows[index].Cells["AmountOfTax"].Value = "17";
                        this.dataGridView1.Rows[index].Cells["DictionarySpecificationCode"].Value = unit.Value.DictionarySpecificationCode;
                        this.dataGridView1.Rows[index].Cells["DictionaryMeasurementUnitCode"].Value = unit.Value.DictionaryMeasurementUnitCode;
                        this.dataGridView1.Rows[index].Cells["FactoryName"].Value = unit.Value.FactoryName;
                        this.dataGridView1.Rows[index].Cells["DictionaryDosageCode"].Value = unit.Value.DictionaryDosageCode;
                        this.dataGridView1.Rows[index].Cells["LicensePermissionNumber"].Value = unit.Value.LicensePermissionNumber;                         
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }

        }

        /// <summary>
        /// 控制药品名列不能被编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "clmDrugName")
                e.Cancel = true;
        }

        /// <summary>
        /// 控制数量一列只能输入正整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].IsNewRow) 
                    return;

                decimal ii;
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "clmDrugNumber")
                {
                    if (e.FormattedValue != null && e.FormattedValue.ToString().Length > 0)
                    {
                        if (!Decimal.TryParse(e.FormattedValue.ToString(), out ii) || ii < 0)
                        {
                            e.Cancel = true;
                            MessageBox.Show("请输入有效数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }

        }

        /// <summary>
        /// 验证数据
        /// </summary>
        private bool GetSupplyList()
        {
            try
            {
                //计算中药品种（包含中药材和中药饮片）
                int zcount = bList.Where(r => r.BusinessScopeCode.Contains("中药")).Count();
                if (zcount > 0 && zcount < bList.Count)
                {
                    MessageBox.Show("你的采购定单单据中包含有中药品种，中西药品请分别开具至不同采购定单，您此时可删除某些采购品种或者该品种的经营范围！");
                    return false;
                }

                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    string supplyUnitId = this.dataGridView1.Rows[i].Cells["clmSupplyUnitId"].Value.ToString();
                    if (supplyUnitId == "" || new Guid(supplyUnitId) == Guid.Empty)
                    {
                        this.dataGridView1.Rows[i].Cells["clmSupplyName"].Style.BackColor = CellDataErrorBackColor;
                        MessageBox.Show("请选择供应商", "提示", MessageBoxButtons.OK);
                        return false;
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Cells["clmSupplyName"].Style.BackColor = CellDataValidBackColor;
                    }
                    if (!listSupply.Contains(supplyUnitId))
                    {
                        listSupply.Add(supplyUnitId);
                    }
                    decimal drugAmount = Decimal.Parse(this.dataGridView1.Rows[i].Cells["clmDrugNumber"].EditedFormattedValue.ToString());
                    if (drugAmount <= 0)
                    {
                        this.dataGridView1.Rows[i].Cells["clmDrugNumber"].Style.BackColor = CellDataErrorBackColor;
                        MessageBox.Show("采购数量不能小于零", "提示", MessageBoxButtons.OK);
                        return false;
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Cells["clmDrugNumber"].Style.BackColor = CellDataValidBackColor;
                    }
                
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
            return false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();            
        }

        /// <summary>
        /// 根据选择的药品构造datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                FormDrugForPurchaseSelector drugSelect = new FormDrugForPurchaseSelector();
                drugSelect.ShowDialog();
                Dictionary<Guid, DrugInfo> addList = drugSelect.ListDrugsSelected;
                dataGridViewAdd(addList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                int rdx = this.dataGridView1.CurrentRow.Index;
                if (MessageBox.Show("确定要删除此条记录吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    List<DrugInfo> l = this.dataGridView1.DataSource as List<DrugInfo>;

                    if (bList.Count <= 0) return;
                    bList.RemoveAt(rdx);

                }
            }
        }
        /// <summary>
        /// 选择每行药品的供应商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex < 0)
            //        return;

            //    if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("clmSupplyName"))
            //    {
            //        Guid drugId = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["clmDrugId"].Value.ToString());
            //        FormSupplyUnitsSelector selector = new FormSupplyUnitsSelector(drugId);
            //        selector.ShowDialog();
            //        this.dataGridView1.Rows[e.RowIndex].Cells["clmSupplyName"].Value = selector.SupplyName;
            //        this.dataGridView1.Rows[e.RowIndex].Cells["clmSupplyUnitId"].Value = selector.SupplyId.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
            //    Log.Error(ex);
            //}
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("clmDrugNumber"))
            {
                //wfz
                string msg = string.Empty;
                
                DataGridViewCell numberCell=this.dataGridView1.Rows[e.RowIndex].Cells["clmDrugNumber"];
                //DataGridViewCell purchasePriceCell = this.dataGridView1.Rows[e.RowIndex].Cells["clmPurchasePrice"];
                //DataGridViewCell taxCell = this.dataGridView1.Rows[e.RowIndex].Cells["AmountOfTax"];
                

                numberCell.Value = numberCell.FormattedValue.ToString() == string.Empty ? 0 : numberCell.FormattedValue;
               // purchasePriceCell.Value = purchasePriceCell.FormattedValue.ToString() == string.Empty ? 0 : purchasePriceCell.FormattedValue;

                //if (numberCell.Value != null || purchasePriceCell.Value != null)
                //{

                //    this.dataGridView1.Rows[e.RowIndex].Cells["TotalMoney"].Value = (Double.Parse(numberCell.Value.ToString())) * (Double.Parse(purchasePriceCell.Value.ToString()));
                //}
                //decimal sum = 0.0m;
                //foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                //{
                //    if (Convert.ToDecimal(dr.Cells[6].Value) <= 0) return;
                //    sum += Convert.ToDecimal(dr.Cells[6].Value);
                //}
                //this.textBox1.Text = sum.ToString();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DataGridViewCell numberCell = this.dataGridView1.Rows[e.RowIndex].Cells["clmDrugNumber"];
            //DataGridViewCell purchasePriceCell = this.dataGridView1.Rows[e.RowIndex].Cells["clmPurchasePrice"];
            //DataGridViewCell taxCell = this.dataGridView1.Rows[e.RowIndex].Cells["AmountOfTax"];
            //if (numberCell.Value != null && purchasePriceCell.Value != null)
            //{
            //    this.dataGridView1.Rows[e.RowIndex].Cells["TotalMoney"].Value = (Double.Parse(numberCell.Value.ToString())) * (Double.Parse(purchasePriceCell.Value.ToString()));
            //}
        }
        
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void fromSupplyUnitMenu_Click(object sender, EventArgs e)
        {
            try
            {
                FormSupplyUnitsSelector purchaseSelector = new FormSupplyUnitsSelector();
                purchaseSelector.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void fromDrugInfoMenu_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            FormPurchaseOrderCreateBySupplyer frm = new FormPurchaseOrderCreateBySupplyer();
            frm.GoodsType = this.GoodsType;//供货商品类型控制
            frm.Show(this);
            frm.submitEvent+=new FormPurchaseOrderCreateBySupplyer.SubmitEventHandler(frm_submitEvent);
        }

        private void frm_submitEvent(object sender,FormPurchaseOrderCreateBySupplyer.SubmitEventArgs e)
        {
            this.label4.Text = ((FormPurchaseOrderCreateBySupplyer)sender).Supplyer;

            this.dataGridView1.DataSource = bList;

            this.dataGridView1.Focus();

            Guid sid=Guid.Parse(((FormPurchaseOrderCreateBySupplyer)sender).SupplyerID);

            if (_SupplyID != Guid.Empty && _SupplyID != sid)
            {
                bList.Clear();
            }

            foreach (var c in e.listDrug)
            {
                if(bList.FirstOrDefault(r=>r.ProductGeneralName==c.ProductGeneralName && r.DictionaryDosageCode==c.DictionaryDosageCode && r.DictionarySpecificationCode==c.DictionarySpecificationCode && r.FactoryName==c.FactoryName)==null)
                bList.Add(c);
            }

            _SupplyID = sid;

            foreach (DataGridViewRow d in this.dataGridView1.Rows)
            {
                d.Cells[clmSupplyUnitId.Name].Value = ((FormPurchaseOrderCreateBySupplyer)sender).SupplyerID;
                d.Cells[clmSupplyName.Name].Value = ((FormPurchaseOrderCreateBySupplyer)sender).Supplyer;
            }

            this.Bcms.Sid = sid;        //右键查看供货商基础信息
        }
        
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.ToolTipTitle = "该药品库存数量：";
            tt.UseAnimation = true;
            tt.ToolTipIcon = ToolTipIcon.Info;
            tt.IsBalloon = true;
            tt.InitialDelay = 1000;
            tt.UseFading = true;
            tt.Show("库存数量", this.dataGridView1, e.X, e.Y);
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string msg = string.Empty;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            Guid drugid = Guid.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[clmDrugId.Name].Value.ToString());
            InventoryRecord ir=this.PharmacyDatabaseService.GetInventoryRecordByDrugInfoID(out msg, drugid);
            DrugInventoryRecord[] dir = this.PharmacyDatabaseService.GetDrugInventoryRecordByCondition(out msg, this.dataGridView1.Rows[e.RowIndex].Cells[clmDrugName.Name].Value.ToString(),string.Empty);
            
            if (dir == null) return;
            if (dir.Count() <= 0) return;
            List<DrugInventoryRecord> listDrugInventoryRecord = dir.OrderByDescending(r => r.OutValidDate).ToList();
            //if (this.dataGridView1.CurrentCell.OwningColumn.Name == clmPurchasePrice.Name)
            //{
            //    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = listDrugInventoryRecord.First().PurchasePricce;
            //}
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //快捷键
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.dataGridView1.CurrentCell!=null && keyData.ToString() == "Return")
            {
                if (this.dataGridView1.CurrentCell.RowIndex == this.dataGridView1.Rows.Count - 1 && this.dataGridView1.CurrentCell.ColumnIndex == 5)
                {
                    this.dataGridView1.EndEdit();
                    return true;
                }

                if (this.dataGridView1.CurrentCell.ColumnIndex == 4)
                    System.Windows.Forms.SendKeys.Send("{tab}");
                if (this.dataGridView1.CurrentCell.ColumnIndex == 5 && this.dataGridView1.CurrentCell.RowIndex < this.dataGridView1.Rows.Count - 1)
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex + 1].Cells[4];
                return true;
            }

            if (keyData == Keys.F5)
            {
                if (this.dataGridView1.SelectedCells.Count > 0)
                {
                    Guid druginfoID = Guid.Parse(this.dataGridView1.Rows[this.dataGridView1.SelectedCells[0].RowIndex].Cells[this.clmDrugId.Name].FormattedValue.ToString());
                    if (druginfoID != Guid.Empty)
                    {
                        Form_HistoryPurchase frm = new Form_HistoryPurchase(druginfoID, 1);
                        frm.ShowDialog();
                        this.dataGridView1.Focus();
                    }
                }
                return true;
            }

            if (keyData == (Keys.Alt | Keys.D))
            {
                Bcms.GetDrugInfo();
            }

            if (keyData == (Keys.Alt | Keys.F))
            {
                Bcms.GetSupplyUnit();
            }

            if (keyData == (Keys.Alt | Keys.S))
            {
                this.btnGeneratePurchaseRecords_Click(this, null);
                return true;
            }

            if (keyData == (Keys.Alt | Keys.X))
            {
                var ids = from i in bList
                          select i.Id;

                var pi = this.PharmacyDatabaseService.GetLastInInventoryDetail(ids.ToArray());
                this.dataGridView1.Focus();
                foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                {
                    DrugInfo di = dr.DataBoundItem as DrugInfo;
                    var p = pi.Where(r => r.DrugInfoId == di.Id).FirstOrDefault();
                    
                    dr.Cells["clmPurchasePrice"].Value =p==null?0m: p.PurchasePrice;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FormPurchaseOrderGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
        }

        private void FormPurchaseOrderGenerator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            //foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            //{
            //    if (dr.Cells[this.AmountOfTax.Name].EditedFormattedValue.ToString() == string.Empty)
            //    {
            //        MessageBox.Show("税率为空！"); 
            //        dr.Selected = true;
            //        e.Cancel = true;
            //        return;
            //    }
            //    if (dr.Cells[TotalMoney.Name].EditedFormattedValue == null || Convert.ToDecimal(dr.Cells[TotalMoney.Name].EditedFormattedValue) == 0m)
            //    {
            //        MessageBox.Show("数量或价格为0！");
            //        dr.Selected = true;
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            if (MessageBox.Show("单据暂未保存，是否要保存？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;

            this.btnGeneratePurchaseRecords_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label17.Text = ((User)this.comboBox1.SelectedItem).Employee.Name;
        }

        private void ckDirectMarketing_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBox1.Enabled = !this.ckDirectMarketing.Checked;
        }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                this.GoodsType = this.checkBox1.Checked ? Common.GoodsTypeClass.医疗器械 : Common.GoodsTypeClass.药品;

                if (this.GoodsType == GoodsTypeClass.医疗器械)
                {
                    this.LicensePermissionNumber.HeaderText = "注册证或备案凭证编号";
                }
                if (this.GoodsType == GoodsTypeClass.药品)
                {
                    this.LicensePermissionNumber.HeaderText = "批准文号";
                }
                return;
            }

            if (this.GoodsType == Common.GoodsTypeClass.药品)
            {
                if (this.checkBox1.Checked)
                {
                    var re=MessageBox.Show("列表已经选择了非医疗器械商品，如果您选择采购医疗器械，则采购列表将被清空，需要确定吗？","提示",MessageBoxButtons.OKCancel);
                    if (re == System.Windows.Forms.DialogResult.OK)
                    {
                        this.GoodsType = Common.GoodsTypeClass.医疗器械;
                        this.bList.Clear();
                        this.dataGridView1.DataSource = null;
                        this.LicensePermissionNumber.HeaderText = "注册证或备案凭证编号";
                    }
                    else
                    {
                        this.checkBox1.Checked = !this.checkBox1.Checked;
                    }
                }
            }
            if (this.GoodsType == Common.GoodsTypeClass.医疗器械)
            {
                if (!this.checkBox1.Checked)
                {
                    var re = MessageBox.Show("列表已经选择了医疗器械商品，如果您选择采购其他商品，则采购列表将被清空，需要确定吗？", "提示", MessageBoxButtons.OKCancel);
                    if (re == System.Windows.Forms.DialogResult.OK)
                    {
                        this.GoodsType = Common.GoodsTypeClass.药品;
                        this.bList.Clear();
                        this.dataGridView1.DataSource = null;
                        this.LicensePermissionNumber.HeaderText = "批准文号";
                    }
                    else
                    {
                        this.checkBox1.Checked = !this.checkBox1.Checked;
                    }
                }
            }

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "采购单细节");
        }
        
    }

    public enum PurchaseDrugTypes
    {
        药品,
        医疗器械,
        食品
    }
}
