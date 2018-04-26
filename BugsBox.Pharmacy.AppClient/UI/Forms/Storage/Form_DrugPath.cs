using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Storage
{
    public partial class Form_DrugPath :BaseFunctionForm
    {
        Guid _id;
        string msg = string.Empty;
        List< DrugPathExpandable > ListDrugPath = new List<DrugPathExpandable>();
        List<Business.Models.DrugPath> ListDrugPathAll = new List<Business.Models.DrugPath>();
        int _type = 0;
        ContextMenuStrip cms = new ContextMenuStrip();

        DataGridViewCellStyle dcs=new DataGridViewCellStyle();
        Forms.PurchaseBusiness.Form_FormPurchaseHistoryBySupplyer_Batch Batchfrm;

        DateTimePicker dtpT = new DateTimePicker();
        DateTimePicker dtpF = new DateTimePicker();
        /// <summary>
        /// 获取方式
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type">GUID 类型 0-从库存获取；1-从销售细节ID获取；2-从采购单获取</param>
        public Form_DrugPath(Guid id,int type)
        {
            InitializeComponent();

            dcs.BackColor = Color.LightYellow;

            dtpF.Value = DateTime.Now.AddMonths(-1);
            dtpT.Value = DateTime.Now.Date;
            this.toolStrip1.Items.Insert(1, new ToolStripControlHost(dtpF));
            this.toolStrip1.Items.Insert(3, new ToolStripControlHost(dtpT));
            
            this._id = id;
            this._type = type;
            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs e)
            {
                var dpe = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as DrugPathExpandable;
                if (dpe.IsExpandable)
                {
                    Rectangle HeaderRectangle = new Rectangle(e.RowBounds.Location, new Size(this.dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height));
                    string ExpandedFlag = dpe.IsExpanded ? "-" : "+";
                    TextRenderer.DrawText(e.Graphics, ExpandedFlag, this.dataGridView1.DefaultCellStyle.Font, HeaderRectangle, this.dataGridView1.DefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                }
            };

            this.dataGridView1.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_RowHeaderMouseClick);
            this.dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);
            this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
            this.RightMenu();
        }

        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 ||e.ColumnIndex>12) return;
            if (!((DrugPathExpandable)this.dataGridView1.Rows[e.RowIndex].DataBoundItem).IsExpandable) return;
            using (Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            {
                using (Pen gridLinePen = new Pen(gridBrush))
                {
                    var currentRow = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as DrugPathExpandable;                    
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    if (e.RowIndex != this.dataGridView1.RowCount - 1)
                    {
                        var nexrRow = this.dataGridView1.Rows[e.RowIndex + 1].DataBoundItem as DrugPathExpandable;
                        if (currentRow.batchNumber!=nexrRow.batchNumber)
                        {
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        }
                    }
                    else
                    {
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    }                                   
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1,
                        e.CellBounds.Bottom - 1);

                    if (e.RowIndex == 0)
                    {
                        if (e.Value != null)
                        {
                            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Crimson, e.CellBounds.X + (e.CellBounds.Width - e.Graphics.MeasureString(e.Value.ToString().Trim(), e.CellStyle.Font).Width) / 2, e.CellBounds.Y + 2, StringFormat.GenericDefault);
                        }
                    }
                    else
                    {
                        var preRow = this.dataGridView1.Rows[e.RowIndex-1].DataBoundItem as DrugPathExpandable;

                        if (preRow.batchNumber!=currentRow.batchNumber)
                        {
                            if (e.Value != null)
                            {
                                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Crimson, e.CellBounds.X + (e.CellBounds.Width - e.Graphics.MeasureString(e.Value.ToString().Trim(), e.CellStyle.Font).Width) / 2, e.CellBounds.Y + 2, StringFormat.GenericDefault);
                            }
                        }
                    }
                }
            }
            e.Handled = true;
        }

        void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in this.dataGridView1.Rows)
            {
                if (((DrugPathExpandable)r.DataBoundItem).IsExpandable)
                {
                    r.DefaultCellStyle = dcs;
                }
            }
        }

        void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var c = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as DrugPathExpandable;
            if (!c.IsExpandable) return;
            if (c.IsExpanded)
            {
                int removeCount = this.ListDrugPath.Where(r => r.salesOrderID == c.salesOrderID && r.IsExpandable==false).Count();
                this.ListDrugPath.RemoveRange(e.RowIndex+1, removeCount);                
            }
            else
            {
                var de=this.ListDrugPath.Where(r=>r.batchNumber==c.batchNumber && r.IsExpandable==false).ToList();


                var l = (from i in this.ListDrugPathAll.Where(r => r.salesOrderID == c.salesOrderID && r.batchNumber==c.batchNumber)
                         select new DrugPathExpandable
                         {
                             drugName="    "+i.drugName,
                             purchaseOrderID = i.purchaseOrderID,
                             PurchaseOrderDocumentNumber = i.PurchaseOrderDocumentNumber,
                             SupplyUintId = i.SupplyUintId,
                             SupplyUnitName = i.SupplyUnitName,
                             inInventoryDate = i.inInventoryDate,
                             invenotryNumber = i.invenotryNumber,
                             InventoryRecordId = i.InventoryRecordId,
                             IsExpandable = false,
                             IsExpanded = false,
                             salesOrderID = c.salesOrderID,
                             cansaleNum=i.cansaleNum,
                             batchNumber=i.batchNumber,
                             dosage=i.dosage,
                             specific=i.specific,
                             factoryName=i.factoryName,
                             permitNumber=i.permitNumber,
                              MeasurementUnit=i.MeasurementUnit
                         }).ToList();

                l.ForEach(r =>
                {
                    this.ListDrugPath.Insert(e.RowIndex + 1, r);
                });
                de.ForEach(r => { this.ListDrugPath.Remove(r); });
                this.ListDrugPath.Where(r => r.batchNumber == c.batchNumber && r.IsExpandable).ToList().ForEach(r => { r.IsExpanded = false; });
            }
            c.IsExpanded = !c.IsExpanded;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.ListDrugPath;
            this.dataGridView1.Refresh();
        }

        //右键菜单项
        private void RightMenu()
        {
            cms.Items.Add("表格操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("手动设置列宽", null, delegate(object sender, EventArgs e) {this.dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.None; });
            cms.Items.Add("自动设置列宽", null, delegate(object sender, EventArgs e) { this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; });
            cms.Items.Add("-");
            cms.Items.Add("导出当前列表", null, this.toolStripButton2_Click); 
            cms.Items.Add("-");
            cms.Items.Add("单据操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("查看销售单 Alt+S", null, delegate(object sender, EventArgs e) { this.RightMenuClick(0); });
            cms.Items.Add("查看出库复核单", null, delegate(object sender, EventArgs e) { this.OpenSalesOrderCheck(); });
            cms.Items[cms.Items.Count - 1].Name = "OpenSaleOrder";
            cms.Items.Add("查看采购单 Alt+D", null, delegate(object sender, EventArgs e) { this.RightMenuClick(1); });
            cms.Items[cms.Items.Count - 1].Name = "OpenPurchaseOrder";
            cms.Items.Add("-");
            cms.Items.Add("筛选操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("查看该批次 Alt+F", null, delegate(object sender, EventArgs e) { this.RightMenuClick(2); });
            cms.Items.Add("按批号查询 Alt+Q", null, delegate(object sender, EventArgs e) { this.RightMenuClick(8); });
            cms.Items.Add("该品种最近入库记录 Alt+G", null, delegate(object sender, EventArgs e) { this.RightMenuClick(3); });
            cms.Items.Add("该批次最近入库记录 Alt+H", null, delegate(object sender, EventArgs e) { this.RightMenuClick(4); });
            cms.Items[cms.Items.Count - 1].Visible = false;//暂时不用
            cms.Items.Add("查看全部 Alt+A", null, delegate(object sender, EventArgs e) { this.RightMenuClick(5); });
            cms.Items.Add("-");
            cms.Items.Add("计算操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("求和操作 Alt+C", null, delegate(object sender, EventArgs e) { this.RightMenuClick(6); });
            cms.Items[cms.Items.Count - 1].Name = "Sum";
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("汇总操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("汇总各批次 Alt+W", null, delegate(object sender, EventArgs e) { this.RightMenuClick(7); });

        }

        //右键方法
        private void RightMenuClick(int qType)
        {
            if (qType == 0)//查销售单
            {
                Guid sid = ((Business.Models.DrugPath)this.dataGridView1.CurrentRow.DataBoundItem).salesOrderID;
                SalesBusiness.FormSalesOrderEdit frm = new SalesBusiness.FormSalesOrderEdit(this.PharmacyDatabaseService.GetSalesOrder(out msg, sid), true);
                frm.ShowDialog();
            }
            if (qType == 1)//查采购单
            {
                Guid pid = ((Business.Models.DrugPath)this.dataGridView1.CurrentRow.DataBoundItem).purchaseOrderID;
                if (pid.Equals(Guid.Empty))
                {
                    MessageBox.Show("前期库存，无入信息");
                    return;
                }
                Business.Models.PurchaseOrdeEntity poe = this.PharmacyDatabaseService.GetPurchaseOrderEntity(out msg, pid);
                Forms.PurchaseBusiness.FormPurchaseOrderEdit frm = new Forms.PurchaseBusiness.FormPurchaseOrderEdit(poe, false, true);
                frm.ShowDialog();
            }
            if (qType == 2)//查看该批号
            {
                string batchNumber=((DrugPathExpandable)this.dataGridView1.CurrentRow.DataBoundItem ).batchNumber;
                Guid sid = ((DrugPathExpandable)this.dataGridView1.CurrentRow.DataBoundItem).salesOrderID;
                this.dataGridView1.DataSource = null;
                this.ListDrugPath = this.GetListPathExpandable(batchNumber,Guid.Empty);
                this.dataGridView1.DataSource = this.ListDrugPath;
            }
            if (qType == 8)//按批号查询
            {
                string batchNumber = ((DrugPathExpandable)this.dataGridView1.CurrentRow.DataBoundItem).batchNumber;
                if(this.Batchfrm==null || this.Batchfrm.IsDisposed)
                    this.Batchfrm = new PurchaseBusiness.Form_FormPurchaseHistoryBySupplyer_Batch(batchNumber);
                Batchfrm.StartPosition = FormStartPosition.CenterScreen;
                Batchfrm.Show(this);
                Batchfrm.GetBatch += (sender, ex) =>
                {
                    this.dataGridView1.DataSource = null;
                    this.ListDrugPath = this.GetListPathExpandable(batchNumber, Guid.Empty,ex.IsPrecise);
                    this.dataGridView1.DataSource = this.ListDrugPath;
                };
            }
            if (qType == 3)//查看该品种最近入库的购销记录
            {
                var d = this.ListDrugPathAll.Where(r => r.inInventoryDate != null);
                if (d.Count()<=0)
                {
                    MessageBox.Show("前期库存，无入信息");
                    return;
                }
                var LastInventoryDate = d.Max(r => r.inInventoryDate);
                string batch=this.ListDrugPathAll.Where(r=>r.inInventoryDate==LastInventoryDate).FirstOrDefault().batchNumber;
                this.ListDrugPath = this.GetListPathExpandable(batch,Guid.Empty);

                this.dataGridView1.DataSource =new BindingCollection<DrugPathExpandable>( this.ListDrugPath);
            }
            if (qType == 4)//查看该批次最近入库的购销记录
            {
                string batchNumber = ((Business.Models.DrugPath)this.dataGridView1.CurrentRow.DataBoundItem).batchNumber;
                var c = this.ListDrugPathAll.Where(r => r.batchNumber == batchNumber);
                var d = c.Where(r => r.inInventoryDate != null);
                if (d.Count() <= 0)
                {
                    MessageBox.Show("前期库存，无入信息");
                    return;
                }
                var LastInventoryDate = d.Max(r => r.inInventoryDate);
                string batch = this.ListDrugPathAll.Where(r => r.inInventoryDate == LastInventoryDate).FirstOrDefault().batchNumber;
                this.ListDrugPath = this.GetListPathExpandable(batch,Guid.Empty);
                this.dataGridView1.DataSource = new BindingCollection<DrugPathExpandable>(this.ListDrugPath);
            }
            if (qType == 5)//查看全部
            {
                this.ListDrugPath=this.GetListPathExpandable(string.Empty,Guid.Empty);
                this.dataGridView1.DataSource = this.ListDrugPath;
            }
            if (qType == 6)//求和
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
                decimal result = ListD.Sum();
                MessageBox.Show("统计结果是：" + result.ToString("F4"));
                cms.Items["Sum"].Enabled = false;
            }
            if (qType == 7)//汇总
            {
                var c = from i in this.GetListPathExpandable(string.Empty,Guid.Empty)
                        group i by i.batchNumber into g
                        select new DrugPathExpandable
                        {
                            drugName = g.FirstOrDefault().drugName,
                            batchNumber = g.FirstOrDefault().batchNumber,
                            PurchaseOrderDocumentNumber = g.FirstOrDefault().PurchaseOrderDocumentNumber,
                            dosage = g.FirstOrDefault().dosage,
                            specific = g.FirstOrDefault().specific,
                            factoryName = g.FirstOrDefault().factoryName,
                            permitNumber = g.FirstOrDefault().permitNumber,
                            saleCount = g.Sum(r => r.saleCount),
                            invenotryNumber = g.FirstOrDefault().invenotryNumber,
                            
                            cansaleNum = g.FirstOrDefault().cansaleNum,
                            SupplyUnitName=g.FirstOrDefault().SupplyUnitName,
                            IsExpandable=false,
                            IsExpanded=false
                        };
                this.dataGridView1.DataSource = new BindingCollection<DrugPathExpandable>(c.OrderBy(r => r.batchNumber).ToList());
                cms.Items["OpenSaleOrder"].Enabled = false;
                cms.Items["OpenPurchaseOrder"].Enabled = false;
            }
            else
            {
                cms.Items["OpenSaleOrder"].Enabled = true;
                cms.Items["OpenPurchaseOrder"].Enabled = true;
            }
        }

        private void OpenSalesOrderCheck()
        {
            var c = this.dataGridView1.CurrentRow.DataBoundItem as DrugPathExpandable;

            using (Forms.SalesBusiness.FormOutInventory form = new Forms.SalesBusiness.FormOutInventory(c.salesOrderID, true))
            {
                form.ShowDialog();
            }

        }


        //快捷键
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt|Keys.S:
                    this.RightMenuClick(0);
                    break;
                case Keys.Alt | Keys.D:
                    this.RightMenuClick(1);
                    break;
                case Keys.Alt | Keys.F:
                    this.RightMenuClick(2);
                    break;
                case Keys.Alt | Keys.G:
                    this.RightMenuClick(3);
                    break;
                case Keys.Alt | Keys.H:
                    this.RightMenuClick(4);
                    break;
                case Keys.Alt | Keys.A:
                    this.RightMenuClick(5);
                    break;
                case Keys.Alt | Keys.C:
                    this.RightMenuClick(6);
                    break;
                case Keys.Alt | Keys.W:
                    this.RightMenuClick(7);
                    break;
            }
            return true;
            //return base.ProcessCmdKey(ref msg, keyData);
        }

        //查询
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Business.Models.QueryModelForDrugPath m = new Business.Models.QueryModelForDrugPath();
            m.Id = _id;
            m.DTT = this.dtpT.Value.AddDays(1).Date;
            m.DTF = this.dtpF.Value.Date;
            m.DrugPathQueryType = _type;
            var c= this.PharmacyDatabaseService.GetDrugPath(m, out msg);
            this.ListDrugPathAll= c.OrderBy(r=>r.batchNumber).ThenBy(r=>r.purchaseUnitName).ToList();

            this.ListDrugPath = this.GetListPathExpandable(string.Empty,Guid.Empty);

            this.dataGridView1.DataSource = new BindingCollection<DrugPathExpandable>(this.ListDrugPath);

            if (this.ListDrugPath.Count > 0)
            {
                toolStripStatusLabel2.Text = this.ListDrugPath.First().drugName;
                toolStripStatusLabel4.Text = this.ListDrugPath.Count.ToString();
                toolStripStatusLabel6.Text = this.ListDrugPath.First().cansaleNum.ToString();
                toolStripStatusLabel8.Text = this.ListDrugPath.Sum(r => r.saleCount).ToString();
            }
        }

        private List<DrugPathExpandable> GetListPathExpandable(string batchNumber,Guid SaleorderId,bool IsPrecise=true)
        {
            var m = this.ListDrugPathAll;

            if(!string.IsNullOrEmpty(batchNumber))
                if(IsPrecise)
                    m = m.Where(r => r.batchNumber == batchNumber).ToList();
                else
                    m = m.Where(r => r.batchNumber.Contains(batchNumber)).ToList();
            if (SaleorderId != Guid.Empty)
            {
                m = m.Where(r => r.salesOrderID == SaleorderId).ToList();
            }
            return (from i in m
                    group i by new { so = i.salesOrderID, sb = i.batchNumber } into g
                    select new DrugPathExpandable
                    {
                        MeasurementUnit=g.FirstOrDefault().MeasurementUnit,
                        batchNumber = g.FirstOrDefault().batchNumber,
                        dosage = g.FirstOrDefault().dosage,
                        DrugInfoId = g.FirstOrDefault().DrugInfoId,
                        drugName = g.FirstOrDefault().drugName,
                        factoryName = g.FirstOrDefault().factoryName,
                        id = g.FirstOrDefault().id,
                        invenotryNumber = g.Sum(r => r.invenotryNumber),
                        permitNumber = g.FirstOrDefault().permitNumber,
                        InventoryRecordId = g.FirstOrDefault().InventoryRecordId,
                        saleCount = g.FirstOrDefault().saleCount,
                        saleDate = g.FirstOrDefault().saleDate,
                        salePrice = g.FirstOrDefault().salePrice,
                        salesOrderID = g.FirstOrDefault().salesOrderID,
                        saleOrderCode = g.FirstOrDefault().saleOrderCode,
                        saler = g.FirstOrDefault().saler,
                        purchaseUnitId = g.FirstOrDefault().purchaseUnitId,
                        purchaseUnitName = g.FirstOrDefault().purchaseUnitName,
                        specific = g.FirstOrDefault().specific,
                        businessman = g.FirstOrDefault().businessman,
                        cansaleNum = g.FirstOrDefault().cansaleNum,
                        IsExpandable = true,
                        IsExpanded = false
                    }).OrderBy(r => r.batchNumber).ToList();
        }

        private void Form_DrugPath_Load(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }
       
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "品种购销流向");
        }

        //弹出右键
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            
            {
                cms.Items["Sum"].Enabled = true;
                var c = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as DrugPathExpandable;
                cms.Items["OpenSaleOrder"].Enabled =!(c.salesOrderID == null || c.salesOrderID==Guid.Empty);
                cms.Items["OpenPurchaseOrder"].Enabled = !(c.purchaseOrderID == null ||c.purchaseOrderID==Guid.Empty);
                
            }
            
            {
                this.dataGridView1.ClearSelection();
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
            cms.Show(MousePosition.X, MousePosition.Y);
        }
    }

    public class DrugPathExpandable:Business.Models.DrugPath
    {
        public bool IsExpandable { get; set; }
        public bool IsExpanded { get; set; }
    }
}
