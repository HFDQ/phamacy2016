using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class Form_PurchaseOrderGenerator : BaseFunctionForm
    {
        string msg = string.Empty;

        PurchaseDrugTypes _selectedDrugType = PurchaseDrugTypes.药品;

        private BugsBox.Pharmacy.Models.PurchaseOrder CurrentPurchaseOrder = new Models.PurchaseOrder
        {
            CreateUserId = AppClient.Common.AppClientContext.CurrentUser.Id,
            UpdateUserId = AppClient.Common.AppClientContext.CurrentUser.Id,

            Id = Guid.NewGuid(),
            OrderStatus = OrderStatus.Waitting,
        };

        BindingList<Business.Models.PurchaseOrderImpt> CurrentListDetail = new BindingList<Business.Models.PurchaseOrderImpt>();

        BaseRightMenu brm = null;

        public PurchaseOrderTaxRate PurchaseOrderDefaultTaxRate { get; private set; }

        public Form_PurchaseOrderGenerator()
        {
            InitializeComponent();

            this.CurrentListDetail.ListChanged += (s, e) => { this.InputTotalPriceToTextBox2(); };

            #region 采购创建初始化
            this.label10.Text = BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Employee.Name;
            this.label11.Text = DateTime.Now.ToLongDateString();

            var types = EnumToListHelper.ConverEnumToList(typeof(PurchaseDrugTypes)).Where(r => r.Name != PurchaseDrugTypes.食品.ToString()).ToList();//暂时不支持食品类

            this.toolStripComboBox1.ComboBox.DisplayMember = "Name";
            this.toolStripComboBox1.ComboBox.ValueMember = "Id";
            this.toolStripComboBox1.ComboBox.DataSource = types;
            this.toolStripComboBox1.ComboBox.SelectedIndex = 0;

            this.toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;

            this.Shown += (s, e) =>
            {
                var tt = new ToolTip
                {
                    ToolTipTitle = "提示!",
                    AutoPopDelay = 5000,
                    InitialDelay = 1000,
                    ReshowDelay = 500,
                    ShowAlways = false,
                    ToolTipIcon = ToolTipIcon.Warning,
                    IsBalloon = true,
                    UseFading = true,
                    UseAnimation = true,
                };

                tt.SetToolTip(this.textBox1, "提示");
                tt.Show("从这里开始，先选择一个供货单位！", this.textBox1, 5000);
                this.textBox1.Focus();
            };
            #endregion

            #region 从服务器端读入采购默认税率值
            var sets = this.PharmacyDatabaseService.GetSalePriceControlRules(out msg);
            PurchaseOrderDefaultTaxRate = sets.PurchaseOrderDefaultTaxRate ?? new PurchaseOrderTaxRate
            {
                DefaultTaxRate = 17
            };
            #endregion

            #region 按钮事件
            this.toolStripButton1.Click += (s, e) => this.GetDrugInfo();
            this.toolStripButton3.Click += (s, e) => this.Submit();
            this.btnGeneratePurchaseRecords.Click += (s, e) => this.Submit();
            this.toolStripButton6.Click += (s, e) => this.FromXls();
            this.toolStripButton2.Click += (s, e) => this.DeleteDrugInfo();
            this.FormClosing += (s, e) =>
            {
                e.Cancel = MessageBox.Show("确定要关闭？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel;
            };//窗口关闭提示

            this.toolStripButton5.Click += (s, e) =>
            {
                using (Form_PurchaseOrder_Set frm = new Form_PurchaseOrder_Set())
                {
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        this.PurchaseOrderDefaultTaxRate = frm.CurrentTaxRateModel;
                    }

                };
            };//默认税率值设置
            #endregion

            #region 供货单位信息处理
            this.textBox1.KeyPress += (s, e) =>
            {
                if (e.KeyChar != 13) return;
                this.SearchSupplyUnit();
            };
            this.button1.Click += (s, e) => this.SearchSupplyUnit();
            #endregion

            #region 用户信息处理
            Business.Models.BaseQueryModel q2 = new Business.Models.BaseQueryModel { };
            var allusers = this.PharmacyDatabaseService.GetUserIdNamesByQueryModel(q2, out msg).ToList();
            this.comboBox2.ValueMember = "Id";
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.DataSource = allusers;
            #endregion

            #region 右键菜单
            this.brm = new BaseRightMenu(this.dataGridView1);
            this.brm.InsertMenuItem("一键填写最近采购价格", this.GetLastUnitPrice);
            this.brm.InsertMenuItem("删除品种", this.DeleteDrugInfo);
            this.brm.InsertMenuItem("查看品种基本资料", this.OpenDrugInfo);
            this.brm.InsertMenuItem("税率一键填写", this.InsertTaxRate);
            #endregion

            #region Datagriview处理
            this.dataGridView1.DataSource = this.CurrentListDetail;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.DataError += (s, e) => { };

            this.dataGridView1.Columns["DrugInfoId"].Visible = false;

            DataGridViewCellStyle dgvcs = new DataGridViewCellStyle
            {
                BackColor = Color.Yellow
            };
            this.dataGridView1.Columns["UnitPrice"].DefaultCellStyle = dgvcs;
            this.dataGridView1.Columns["Amount"].DefaultCellStyle = dgvcs;
            this.dataGridView1.Columns["TaxRate"].DefaultCellStyle = dgvcs;

            #region 设置datagridview只读性和可编辑
            this.dataGridView1.CellEnter += (s, e) =>
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "UnitPrice" || dataGridView1.Columns[e.ColumnIndex].Name == "Amount" || dataGridView1.Columns[e.ColumnIndex].Name == "TaxRate")
                    {
                        this.dataGridView1.ReadOnly = false;
                    }
                    else
                    {
                        this.dataGridView1.ReadOnly = true;
                    }
                };
            #endregion

            #region 计算总额
            this.dataGridView1.CellEndEdit += (s, e) =>
            {
                this.textBox2.Text = decimal.Round(this.CurrentListDetail.Sum(r => r.UnitPrice * r.Amount), 4).ToString();
            };
            #endregion
            #endregion

            #region 绑定采购单CurrentPurchaseOrder实体
            this.purchaseOrderBindingSource.Add(this.CurrentPurchaseOrder);
            #endregion

            #region 获取供应商基础信息
            this.linkLabel1.Click += (s, e) => this.GetSupplyUnitInfo();
            #endregion
        }

        #region 采购类型变更
        void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var currentSelectedType = (PurchaseDrugTypes)((int)this.toolStripComboBox1.ComboBox.SelectedValue);
            if (this.CurrentListDetail.Count > 0 && this._selectedDrugType != currentSelectedType)
            {
                var dlg = MessageBox.Show("确定要更换采购类型吗？如果更换，则您当前所选品种将被清空！", "提示", MessageBoxButtons.OKCancel);
                if (dlg == DialogResult.Cancel)
                {
                    this.toolStripComboBox1.ComboBox.SelectedValue = (int)this._selectedDrugType;
                }
                else
                {
                    this.CurrentListDetail.Clear();
                    this.CurrentPurchaseOrder.PayMoney = 0;
                }
            }
        }
        #endregion

        #region 供货单位选择
        private void SearchSupplyUnit(bool showdrugWindow = true)
        {
            string s = this.textBox1.Text.Trim();
            //if (s.Length < 1)
            //{
            //    MessageBox.Show("您至少需要提供一个字符:（可以是供货单位助记码或者供货单位名称）来查询供货单位！");
            //    return;
            //}
            Form_SupplyerQuest frm = new Form_SupplyerQuest(s);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
            frm.OnSupplyUnitSelect += (e) =>
            {
                if (this.CurrentPurchaseOrder.SupplyUnitId != Guid.Empty)
                {
                    if (this.CurrentPurchaseOrder.SupplyUnitId != e.Id && this.CurrentListDetail.Count > 0)
                    {
                        var dlg = MessageBox.Show("您选择的供货单位与当前的不同，当前选择的品种将被清空，需要继续吗？", "提示", MessageBoxButtons.OKCancel);
                        if (dlg == DialogResult.Cancel) return;

                        this.CurrentPurchaseOrder.SupplyUnitId = e.Id;
                        this.linkLabel1.Text = e.Name;
                        this.CurrentListDetail.Clear();
                    }
                }
                this.CurrentPurchaseOrder.SupplyUnitId = e.Id;
                this.linkLabel1.Text = e.Name;
                if (showdrugWindow)
                {
                    this.GetDrugInfo();
                }

                frm.Close();
            };
        }
        #endregion

        #region 采购单提交
        private void Submit()
        {
            if (this.CurrentListDetail.Count <= 0)
            {
                MessageBox.Show("请添加需要采购的品种信息！"); return;
            }

            if (this.CurrentPurchaseOrder.SupplyUnitId == Guid.Empty)
            {
                MessageBox.Show("供货单位没有选择，不得提交"); return;
            }

            var re = MessageBox.Show("确定要提交吗？", "提示", MessageBoxButtons.OKCancel);
            if (re == DialogResult.Cancel) return;
            this.Validate();
            this.dataGridView1.EndEdit();
            List<PurchaseOrderDetail> details = new List<PurchaseOrderDetail>();
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                var i = row.DataBoundItem as Business.Models.PurchaseOrderImpt;
                if (i.Price <= 0)
                {
                    MessageBox.Show("请注意有一个品种：" + i.ProductGeneralName + "的价格或数量小于等于0，不得提交");
                    this.dataGridView1.CurrentCell = row.Cells["UnitPrice"];
                    return;
                }

                PurchaseOrderDetail pod = new PurchaseOrderDetail
                {
                    Amount = i.Amount,
                    AmountOfTax = i.TaxRate,
                    CreateUserId = this.CurrentUser.Id,
                    UpdateUserId = this.CurrentUser.Id,
                    Id = Guid.NewGuid(),
                    DrugInfoId = i.DrugInfoId,
                    PurchaseOrderId = this.CurrentPurchaseOrder.Id,
                    PurchasePrice = i.UnitPrice,
                    sequence = row.Index,
                };
                details.Add(pod);
            }

            var result = this.PharmacyDatabaseService.CreatePurchaseOrder(out msg, this.CurrentPurchaseOrder, details.ToArray());
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("提交成功！单号是：" + result);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("提交失败，异常：" + msg);
            }
        }
        #endregion

        #region 从xls导入
        private void FromXls()
        {
            if (this.CurrentPurchaseOrder.SupplyUnitId == Guid.Empty)
            {
                //请选择供货商
                SearchSupplyUnit(false);
                return;
            }
            Form_PurchaseOrderImpt frm = new Form_PurchaseOrderImpt();
            frm.Show(this);
            frm.OnPurchaseOrderImpt += (args) =>
            {
                args.ImptList.ForEach(r =>
                {
                    r.TaxRate = this.PurchaseOrderDefaultTaxRate.DefaultTaxRate;
                    if (!this.CurrentListDetail.Any(a => a.DrugInfoId == r.DrugInfoId))
                        this.CurrentListDetail.Add(r);
                });
            };
        }
        #endregion

        #region 直接选择药品
        private void GetDrugInfo()
        {
            if (this.CurrentPurchaseOrder.SupplyUnitId == Guid.Empty)
            {
                MessageBox.Show("请选择供货商"); return;
            }
            Form_DrugInfoForPurchaseSelector frm = new Form_DrugInfoForPurchaseSelector(this.CurrentPurchaseOrder.SupplyUnitId, (PurchaseDrugTypes)((int)this.toolStripComboBox1.ComboBox.SelectedValue));
            frm.Show(this);
            frm.OnPurchaseOrderImpt += (re) =>
            {
                re.ImptList.ForEach(r =>
                {
                    r.TaxRate = this.PurchaseOrderDefaultTaxRate.DefaultTaxRate;
                    if (!this.CurrentListDetail.Any(a => a.DrugInfoId == r.DrugInfoId))
                        this.CurrentListDetail.Add(r);
                });
            };
        }
        #endregion

        #region 删除药品
        void DeleteDrugInfo()
        {
            var currentRow = this.dataGridView1.CurrentRow;
            if (currentRow == null) return;
            var dlg = MessageBox.Show("确定要删除品（：" + currentRow.Cells["ProductGeneralName"].Value.ToString() + "）吗", "提示", MessageBoxButtons.OKCancel);
            if (dlg == DialogResult.Cancel) return;
            this.CurrentListDetail.Remove(currentRow.DataBoundItem as Business.Models.PurchaseOrderImpt);
        }
        #endregion

        #region 获取最近的采购价格
        private void GetLastUnitPrice()
        {
            if (this.CurrentListDetail.Count <= 0) return;
            var dids = this.CurrentListDetail.Select(r => r.DrugInfoId);

            var c = this.PharmacyDatabaseService.GetLastPurchaseUnitPrice(dids.ToArray(), out msg);

            foreach (var row in c)
            {
                var u = this.CurrentListDetail.FirstOrDefault(r => r.DrugInfoId == row.DrugInfoId);
                if (u != null)
                    u.UnitPrice = row.UnitPrice;
            }
            this.InputTotalPriceToTextBox2();
            this.dataGridView1.Refresh();

        }
        #endregion

        #region 获取品种基础信息
        public void OpenDrugInfo()
        {
            var dr = this.dataGridView1.CurrentRow;
            if (dr == null) return;

            var druginfo = dr.DataBoundItem as Business.Models.PurchaseOrderImpt;
            Guid DrugId = druginfo.DrugInfoId;

            using (BaseFunctionForm bf = new Pharmacy.AppClient.UI.BaseFunctionForm())
            {
                var di = bf.PharmacyDatabaseService.GetDrugInfo(out msg, DrugId);
                if (di == null) return;
                if (di.BusinessScopeCode.Contains("医疗器械"))
                {
                    Forms.BaseDataManage.FormInstrument frm = new BaseDataManage.FormInstrument();
                    frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    frm.entity = di;
                    Common.SetControls.SetControlReadonly(frm, true);
                    frm.ShowDialog();
                    return;
                }

                if (di.BusinessScopeCode.Contains("保健食品"))
                {
                    Forms.BaseDataManage.FormFood frm = new BaseDataManage.FormFood();
                    frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    frm.entity = di;
                    Common.SetControls.SetControlReadonly(frm, true);
                    frm.ShowDialog();
                    return;
                }

                UI.UserControls.ucGoodsInfo ucControl = new UserControls.ucGoodsInfo(di);
                System.Windows.Forms.Form f = new System.Windows.Forms.Form();
                f.WindowState = System.Windows.Forms.FormWindowState.Normal;
                f.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                f.Text = di.ProductGeneralName;
                f.AutoSize = true;
                f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
                p.AutoSize = true;
                p.Controls.Add(ucControl);
                f.Controls.Add(p);
                Forms.Common.SetControls.SetControlReadonly(f, true);
                f.ShowDialog();
                f.Dispose();
            }
        }
        #endregion

        #region 获取采购供货单位基础信息
        private void GetSupplyUnitInfo()
        {
            if (this.CurrentPurchaseOrder.SupplyUnitId == Guid.Empty)
            {
                this.SearchSupplyUnit();
                return;
            }
            SupplyUnit su = this.PharmacyDatabaseService.GetSupplyUnit(out msg, this.CurrentPurchaseOrder.SupplyUnitId);
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
        #endregion

        #region 快捷键
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.dataGridView1.CurrentCell != null && keyData.ToString() == "Return")
            {
                if (this.dataGridView1.CurrentCell.RowIndex == this.dataGridView1.Rows.Count - 1 && this.dataGridView1.CurrentCell.OwningColumn.Name == "UnitPrice")
                {
                    this.dataGridView1.EndEdit();
                    this.dataGridView1.Refresh();
                    return true;
                }

                if (this.dataGridView1.CurrentCell.OwningColumn.Name == "Amount")
                    System.Windows.Forms.SendKeys.Send("{tab}");
                if (this.dataGridView1.CurrentCell.OwningColumn.Name == "UnitPrice" && this.dataGridView1.CurrentCell.RowIndex < this.dataGridView1.Rows.Count - 1)
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex + 1].Cells["Amount"];
                this.dataGridView1.Refresh();
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region 计算采购细节总价并输出到TextBox2
        public void InputTotalPriceToTextBox2()
        {
            this.textBox2.Text = Math.Round(this.CurrentListDetail.Sum(r => r.UnitPrice * r.Amount), 4).ToString();
        }
        #endregion

        #region 一键填写税率
        public void InsertTaxRate()
        {
            if (this.dataGridView1.CurrentRow == null) return;
            var cr = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.PurchaseOrderImpt;
            decimal taxrate = cr.TaxRate;
            foreach (var r in this.CurrentListDetail)
            {
                r.TaxRate = taxrate;
            }
            this.dataGridView1.Refresh();
        }
        #endregion

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            new Form_PurchaseOrderImpt().DownlodExcel();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }
    }
}
