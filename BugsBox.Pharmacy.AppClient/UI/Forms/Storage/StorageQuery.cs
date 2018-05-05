using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Storage
{
    public partial class StorageQuery : BaseFunctionForm
    {
        List<Business.Models.InventeryModel> storage = null;
        BindingList<Business.Models.InventeryModel> bList = new BindingList<Business.Models.InventeryModel>();
        string msg = string.Empty;
        ToolTip tt = new ToolTip();
        ContextMenuStrip cms = new ContextMenuStrip();
        string type = string.Empty;
        public StorageQuery(string type)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            this.type = type;
            if (type == "ProfitOrLoss")
            {
                this.Text = "库存损益处理";
                CurrentInventoryCount.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button5.Visible = true;
                colProcess.Visible = true;
                colPLNum.Visible = true;
                CurrentInventoryCount.Visible = false;
                this.PurchasePrice.Visible = false;
                this.PruductDate.Visible = false;
                this.button4.Visible = true;
                this.button5.Left = button2.Left;
                this.button4.Left = button5.Left + button5.Width + 5;
                button6.Visible = true;
            }
            if (type == "Now")
            {
                this.Text = "现有库存";
                CanSaleNum.Visible = false;
            }
            else if (type == "CanUse")
            {
                this.Text = "可用库存";
                CurrentInventoryCount.Visible = false;
            }
            else if (type == "OutofStock")
            {
                this.Text = "缺货查询";
                CanSaleNum.Visible = true;
                CurrentInventoryCount.Visible = true;
            }
            BindComboBoxWarehouseZones();
            this.dataGridView1.DataSource = bList;

            tt.SetToolTip(this.dataGridView1, "批次详细");
            tt.UseFading = true;
            tt.InitialDelay = 2000;
            tt.UseAnimation = true;

            tt.AutoPopDelay = 10000;
            tt.BackColor = Color.Blue;
            tt.IsBalloon = true;

            //移库至
            ToolStripMenuItem tsi = new ToolStripMenuItem("移至－>");
            WarehouseZone[] warehousezoneArr = this.comboBox1.DataSource as WarehouseZone[];

            foreach (var i in warehousezoneArr)
            {
                tsi.DropDownItems.Add(i.Name, null, DrugInventoryMoveClick);
                tsi.DropDownItems[tsi.DropDownItems.Count - 1].Tag = i;
            }
            cms.Items.Add("表格操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("自动调整列宽", null, delegate (object sender, EventArgs e) { this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; });
            cms.Items.Add("取消自动调整列宽", null, delegate (object sender, EventArgs e) { this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; });
            cms.Items.Add("-");
            cms.Items.Add("流向查看");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("查看购销流向", null, this.button3_Click);
            cms.Items.Add("查看品种来源", null, DrugSouce_Click);
            cms.Items.Add("查看品种批次来源", null, DrugBatchSource_Click);
            cms.Items.Add("-");
            cms.Items.Add("移库操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add(tsi);
            cms.Items.Add("查看移库记录", null, delegate (object sender, EventArgs e)
                {
                    Form_DrugInventoryMove frm = new Form_DrugInventoryMove();
                    frm.ShowDialog();
                });
        }

        /// <summary>
        /// 移库右键菜单
        /// </summary>
        /// <param name="sender">sender内含tag属性为warehousezone对象</param>
        /// <param name="e"></param>
        private void DrugInventoryMoveClick(object sender, EventArgs e)
        {
            WarehouseZone wz = ((ToolStripDropDownItem)sender).Tag as WarehouseZone;
            if (wz.Name == this.comboBox1.SelectedText) return;

            ApprovalFlowType aft = this.PharmacyDatabaseService.GetApprovalFlowTypeByBusiness(out msg, ApprovalType.drugsInventoryMove).FirstOrDefault();
            if (aft == null)
            {
                MessageBox.Show("请先通知管理员设定移库审批，并设定其审批节点！"); return;
            }

            if (MessageBox.Show("确定需要申请该药品移库至:" + wz.Name + "吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            Guid InventoryID = storage[this.dataGridView1.SelectedCells[0].RowIndex].InventoryID;
            DrugInventoryRecord dir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, InventoryID);
            if (dir == null)
            {
                MessageBox.Show("读取库存表失败！");
                return;
            }

            DrugsInventoryMove dim = new DrugsInventoryMove();
            dim.Id = Guid.NewGuid();
            dim.ApprovalStatusValue = 1;
            dim.batchNo = dir.BatchNumber;
            dim.createTime = DateTime.Now;
            dim.createUID = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id;
            dim.Deleted = false;
            dim.Description = "移库至" + wz.Name;
            dim.drugName = dir.DrugInfo.ProductGeneralName;
            dim.flowID = Guid.NewGuid();
            dim.inventoryRecordID = dir.Id;
            dim.OriginWareHouseID = dir.WarehouseZoneId;
            dim.quantity = dir.CanSaleNum;
            dim.updateTime = DateTime.Now;
            dim.WareHouseID = wz.Id;
            bool b = this.PharmacyDatabaseService.AddDrugsInventoryMoveByFlowID(dim, aft.Id, "新增移库审批", out msg);
            if (b)
            {
                this.PharmacyDatabaseService.WriteLog(dim.createUID, "成功提交移库申请信息：" + dim.drugName + "被成功申请移至" + dim.OriginWareHouseID);
                if (MessageBox.Show("成功申请移库信息" + wz.Name + "，请至右键菜单－>移库记录查询界面查询！需要打开移库记录查询窗口吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
                Form_DrugInventoryMove frm = new Form_DrugInventoryMove();
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            try
            {
                Guid[] warehouseZonesIds = new Guid[] { };
                if (this.comboBox1.SelectedIndex != -1)
                {
                    warehouseZonesIds = new Guid[] { Guid.Parse(comboBox1.SelectedValue.ToString()) };
                }
                string msg = String.Empty;

                bool combine = BatchCombineCheck.Checked;
                bool showZeo = false;

                storage = PharmacyDatabaseService.StorageQuery(out msg, this.textBox1.Text.Trim(), this.textBox2.Text.Trim(), this.textBox3.Text.Trim(), warehouseZonesIds, this.pagerControl1.PageIndex, this.pagerControl1.PageSize, new object[] { combine, showZeo }).OrderBy(o => o.ProductGeneralName).ToList();
                storage.ForEach(r => r.PruductDate = r.PruductDate.Date);
                if (storage == null)
                {
                    MessageBox.Show("查询结果为空！");
                    return;
                }
                if (storage.Count > 0)
                {
                    this.pagerControl1.RecordCount = storage[0].RecordCount;

                    if (this.type == "CanUse")
                    {
                        storage.Add(new Business.Models.InventeryModel
                        {
                            InventoryID = Guid.Empty,
                            CanSaleNum = storage.Sum(r => r.CanSaleNum),
                            ProductGeneralName = "统计",
                            RecordCount = storage.Count(r => r.isValid),
                            PriceCount = storage.Sum(r => r.CanSaleNum * r.PurchasePrice),
                            OutValidDate = DateTime.Parse("2050-12-31")
                        });
                    }

                    label5.Text = string.Format("总数：{0}", storage[0].TotalQuantityCount);
                    label6.Text = string.Format("总价值:{0}元", storage[0].TotalPriceCount); ;
                }
                else
                {
                    this.pagerControl1.RecordCount = 0;
                }

                this.dataGridView1.DataSource = storage;


            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误,请联系管理员" + ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void BindComboBoxWarehouseZones()
        {
            string msg = string.Empty;
            WarehouseZone[] listWarehouseZone = PharmacyDatabaseService.AllWarehouseZones(out msg);
            this.comboBox1.DataSource = listWarehouseZone;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.SelectedIndex = -1;
        }
        private void pagerControl1_DataPaging()
        {
            Search();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        private void BatchCombineCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "可用库存表");


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            if (e.ColumnIndex == this.dataGridView1.ColumnCount - 1)
            {
                return;
            }
            if (e.ColumnIndex == this.dataGridView1.ColumnCount - 2)
            {
                return;
            }

            if (e.RowIndex < 0) return;
            Guid gid = storage[e.RowIndex].InventoryID;
            if (gid == null || gid == Guid.Empty) return;
            Guid druginfoid = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, gid).DrugInfoId;
            Storage.Form_DrugPath frm = new Storage.Form_DrugPath(druginfoid, 3);
            frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count <= 0) return;
            int rdx = this.dataGridView1.SelectedCells[0].RowIndex;
            Guid gid = storage[rdx].InventoryID;
            Guid druginfoid = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, gid).DrugInfoId;
            Storage.Form_DrugPath frm = new Storage.Form_DrugPath(druginfoid, 3);
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_InventoryPL frm = new Form_InventoryPL();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Search();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.EndEdit();
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != this.dataGridView1.ColumnCount - 1) return;
            if (MessageBox.Show("注意：需要提交损益申请吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) return;

            DrugInventoryRecord dir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, storage[e.RowIndex].InventoryID);


            dir.DismantingAmount = storage[e.RowIndex].DismantingAmount;
            dir.Valid = false;
            if (this.PharmacyDatabaseService.SaveDrugInventoryRecord(out msg, dir))
            {
                MessageBox.Show("申请成功！");
            }
            else
            {
                MessageBox.Show("申请失败！请联系管理员！");
            }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (this.dataGridView1.CurrentCell.OwningColumn.Name != this.colPLNum.Name) return;

            decimal cansale = storage[e.RowIndex].CanSaleNum;
            if (storage[e.RowIndex].DismantingAmount < -cansale)
            {
                MessageBox.Show("损溢数量有误，最低不能超过负的可销数量！");
                storage[e.RowIndex].DismantingAmount = 0;
                return;
            }
        }
        /// <summary>
        /// 查看品种来源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrugBatchSource_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                Guid InvID = storage[this.dataGridView1.SelectedCells[0].RowIndex].InventoryID;
                DrugInventoryRecord diir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, InvID);
                Guid pinId = diir.PurchaseInInventeryOrderDetailId;

                if (pinId != Guid.Empty)
                {
                    Common.Form_HistoryPurchase frm = new Common.Form_HistoryPurchase(pinId);
                    frm.ShowDialog();
                    this.dataGridView1.Focus();
                }
            }
        }

        private void DrugSouce_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                Guid InvID = storage[this.dataGridView1.SelectedCells[0].RowIndex].InventoryID;
                DrugInventoryRecord diir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, InvID);
                Guid pinId = diir.PurchaseInInventeryOrderDetailId;

                if (pinId != Guid.Empty)
                {
                    Common.Form_HistoryPurchase frm = new Common.Form_HistoryPurchase(pinId, 1);
                    frm.ShowDialog();
                    this.dataGridView1.Focus();
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            this.dataGridView1.ClearSelection();
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            this.dataGridView1.Rows[e.RowIndex].Selected = true;
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Business.Models.InventeryModel im = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.InventeryModel;
                if (im.InventoryID == Guid.Empty) return;

                cms.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form_InventoryPLRecord frm = new Form_InventoryPLRecord();
            frm.Show();
        }
    }
}
