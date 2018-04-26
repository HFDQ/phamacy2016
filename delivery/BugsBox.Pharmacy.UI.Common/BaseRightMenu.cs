using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.UI.Common
{
    public delegate void InsertM();
    public delegate void InsertDropDownM(Guid Pid);
    public delegate void InsertDropDownM_Checking(Guid Pid);
    public class BaseRightMenu
    {
        string msg = string.Empty;
        ContextMenuStrip cms = new ContextMenuStrip();
        public DataGridView dataGridView1=null;
        
        ToolStripMenuItem PurchaseHistoryMenuItems = null;
        ToolStripMenuItem PurchaseCheckingMenuItems = null;        

        InsertDropDownM DropDownTarget;
        InsertDropDownM_Checking DropDownTarget_Checking;

        public BaseRightMenu(DataGridView dataGridView1)
        {
            this.dataGridView1 = dataGridView1;
            this.dataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_CellMouseClick);
            this.RightMenu();
        }

        private void RightMenu()
        {
            cms.Items.Add("单元格操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("复制", null, delegate(object sender, EventArgs e) { this.copy(); });
            cms.Items.Add("粘贴", null, delegate(object sender, EventArgs e) { this.paste(sender); });
            cms.Items[cms.Items.Count - 1].Name = "Paste";
            cms.Items.Add("-");
            cms.Items.Add("自动列宽", null, delegate(object sender, EventArgs e) { this.setColumnWidth(true); });
            cms.Items.Add("取消自动列宽", null, delegate(object sender, EventArgs e) { this.setColumnWidth(false); });            
            cms.Items.Add("-");
            cms.Items.Add("冻结该列", null, delegate(object sender, EventArgs e) { this.FrozeOrDefrozeColumn(true); });
            cms.Items[cms.Items.Count - 1].Name = "FrozeColumn";
            cms.Items.Add("解冻该列", null, delegate(object sender, EventArgs e) { this.FrozeOrDefrozeColumn(false); });
            cms.Items[cms.Items.Count - 1].Name = "DefrozeColumn";
            cms.Items.Add("-");
            ToolStripMenuItem tsmi = new ToolStripMenuItem("单元格计算");
            tsmi.DropDownItems.Add("求和", null, delegate(object sender, EventArgs e) { this.GetResult(0); });
            tsmi.DropDownItems.Add("平均值", null, delegate(object sender, EventArgs e) { this.GetResult(1); });
            tsmi.DropDownItems.Add("记数", null, delegate(object sender, EventArgs e) { this.GetResult(2); });
            cms.Items.Add(tsmi);
        }

        private void setColumnWidth(bool b)
        {
            if (b)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0||e.Button!=MouseButtons.Right) return;
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cms.Items["Paste"].Enabled = !this.dataGridView1.CurrentCell.ReadOnly;
           
            cms.Items["FrozeColumn"].Enabled = !this.dataGridView1.Columns[e.ColumnIndex].Frozen;
            cms.Items["DefrozeColumn"].Enabled = this.dataGridView1.Columns[e.ColumnIndex].Frozen;

            if (this.PurchaseHistoryMenuItems != null)//历史采购信息右键加入多采购单菜单
            {
                Business.Models.SupplyUnitHistoryDrugList c = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.SupplyUnitHistoryDrugList;
                this.PurchaseHistoryMenuItems.DropDownItems.Clear();
                this.PurchaseCheckingMenuItems.DropDownItems.Clear();
                var u = c.PurchaseID2DocumentNumber;
                if (u != null)
                {
                    foreach (var i in u)
                    {
                        ToolStripItem tsi = new ToolStripButton();
                        tsi.Text = i.DocumentNumber;
                        tsi.Tag = i.Id;
                        tsi.Click += new EventHandler(delegate(object o, EventArgs ex) { this.tsi_Click(tsi,0); });
                        this.PurchaseHistoryMenuItems.DropDownItems.Add(tsi);

                        tsi = new ToolStripButton();
                        tsi.Text = i.DocumentNumber;
                        tsi.Tag = i.Id;
                        tsi.Click += new EventHandler(delegate(object o, EventArgs ex) { this.tsi_Click(tsi, 1); });
                        this.PurchaseCheckingMenuItems.DropDownItems.Add(tsi);

                    }
                }
                else
                {
                    this.PurchaseHistoryMenuItems.DropDownItems.Add(c.PurchaseOrderDocumentNumber, null, delegate(object o, EventArgs ex) { DropDownTarget(c.purchaseOrderID); });

                    this.PurchaseCheckingMenuItems.DropDownItems.Add(c.PurchaseOrderDocumentNumber, null, delegate(object o, EventArgs ex) { DropDownTarget_Checking(c.purchaseOrderID); });
                }

            }

            cms.Show(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);
        }

        void tsi_Click(ToolStripItem tsi,int index)
        {
            if (index==0) this.DropDownTarget((Guid)tsi.Tag);
            if (index == 1) this.DropDownTarget_Checking((Guid)tsi.Tag);
        }

        private void GetResult(int i)
        {
            if (this.dataGridView1 == null) return;
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
        private void copy()
        {
            Clipboard.SetData(DataFormats.Text, this.dataGridView1.CurrentCell.Value.ToString());
        }
        private void paste(object sender)
        {
            IDataObject idata=Clipboard.GetDataObject();
            if (idata.GetDataPresent(DataFormats.Text))
                this.dataGridView1.CurrentCell.Value = idata.GetData(DataFormats.Text).ToString();
        }

        public void InsertMenuItem(string name, InsertM m)
        {
            cms.Items.Add("-");
            cms.Items.Add(name, null, delegate(object sender, EventArgs e) { m(); });
        }

        private void FrozeOrDefrozeColumn(bool IsFroze)
        {
            if (IsFroze)
            {
                var cIndex = this.dataGridView1.CurrentCell.ColumnIndex;
                for (int i = 0; i <= cIndex; i++)
                {
                    this.dataGridView1.Columns[i].Frozen = true;
                }
            }
            else
            {
                var cIndex = this.dataGridView1.CurrentCell.ColumnIndex;
                for (int i = cIndex; i < this.dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.Columns[i].Frozen = false;
                }
            }
        }

        public void InsertStripMenuItems(ToolStripMenuItem tsmi,InsertDropDownM m)
        {
            this.PurchaseHistoryMenuItems = tsmi;
            cms.Items.Add("-");
            cms.Items.Add(tsmi);
            DropDownTarget = m;
        }

        public void InsertStripMenuItems_Checking(ToolStripMenuItem tsmi, InsertDropDownM_Checking m)
        {
            this.PurchaseCheckingMenuItems = tsmi;
            cms.Items.Add("-");
            cms.Items.Add(tsmi);
            this.DropDownTarget_Checking = m;
        }
        
    }
}
