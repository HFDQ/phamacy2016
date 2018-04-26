using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormPurchaseHistoryBySupplyer : BaseFunctionForm
    {

        DateTimePicker dtpf = new DateTimePicker();
        DateTimePicker dtpt = new DateTimePicker();

        string msg = string.Empty;
        private List<Business.Models.SupplyUnitHistoryDrugList> ListS = new List<Business.Models.SupplyUnitHistoryDrugList>();
        BugsBox.Pharmacy.UI.Common.BaseRightMenu cms = null;
        ToolStripMenuItem tsmi;
        Form_FormPurchaseHistoryBySupplyer_Batch BtchFrm;

        public FormPurchaseHistoryBySupplyer()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            dtpf.Value = DateTime.Now.AddMonths(-3).Date;
            dtpt.Value = DateTime.Now.Date;
            this.toolStrip1.Items.Insert(5,new ToolStripControlHost(dtpf));
            this.toolStrip1.Items.Insert(7, new ToolStripControlHost(dtpt));
            cms = new Pharmacy.UI.Common.BaseRightMenu(this.dataGridView1);
            cms.InsertMenuItem("查询选中供货商", SupplyStatic);

            cms.InsertMenuItem("查看选中供货商资料", delegate()
            {
                var u = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.SupplyUnitHistoryDrugList;
                Models.SupplyUnit su = this.PharmacyDatabaseService.GetSupplyUnit(out msg, u.SupplyUnitId);
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
            });

            cms.InsertMenuItem("查看选中品种资料", delegate()
            {
                var u = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.SupplyUnitHistoryDrugList;
                Models.DrugInfo di = this.PharmacyDatabaseService.GetDrugInfo(out msg, u.DrugInfoId);
                if (di == null) return;
                
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
                    Forms.Common.SetControls.SetControlReadonly(f, true);
                    f.ShowDialog();
            });

            cms.InsertMenuItem("按选中品种批号查询", delegate()
            {
                if (this.ListS.Count > 0)
                {
                    var c = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.SupplyUnitHistoryDrugList;
                    if(BtchFrm==null || BtchFrm.IsDisposed)
                        BtchFrm = new Form_FormPurchaseHistoryBySupplyer_Batch(c.batchNumber);
                    BtchFrm.StartPosition = FormStartPosition.CenterScreen;
                    BtchFrm.TopMost = true;
                    BtchFrm.Show(this);
                    BtchFrm.GetBatch += (sender, ex) =>
                    {
                        if (ex.IsPrecise)
                        {
                            var qre = this.ListS.Where(r => r.batchNumber==ex.Batch);
                            this.dataGridView1.DataSource = qre.ToList();
                        }
                        else
                        {
                            var qre = this.ListS.Where(r => r.batchNumber.Contains(ex.Batch));
                            this.dataGridView1.DataSource = qre.ToList();
                        }
                    };
                }
            });
            cms.InsertMenuItem("采购品种汇总", DrugStatic);
            cms.InsertMenuItem("全部显示", ShowAll);
            cms.InsertMenuItem("统计该药品购销情况", SupplyAndSale);
            tsmi = new ToolStripMenuItem("打开采购单");
            cms.InsertStripMenuItems(tsmi, InsertDropDownMenuEvt);
            tsmi = new ToolStripMenuItem("打开验收单");
            cms.InsertStripMenuItems_Checking(tsmi, this.InsertDropDownMenuEvt_Checking);
        }

        private void InsertDropDownMenuEvt(Guid Pid)
        {
            var po = this.PharmacyDatabaseService.GetPurchaseOrderEntity(out msg, Pid);
            PurchaseBusiness.FormPurchaseOrderEdit frm = new FormPurchaseOrderEdit(po, false, true);
            frm.Show(this);
        }

        private void InsertDropDownMenuEvt_Checking(Guid Pid)
        {
            var poc = this.PharmacyDatabaseService.GetPurchaseCheckingOrdersByPurchaseOrderId(out msg, Pid);
            if (poc.Count() <= 0)
            {
                MessageBox.Show("该品种暂未验收！"); return;
            }
            var po = poc.First();
            PurchaseBusiness.FormCheckOrder frm = new FormCheckOrder(po,true);
            frm.Show(this);
        }

        #region 右键事件
        private void SupplyStatic()
        {
            var sid = ((Business.Models.SupplyUnitHistoryDrugList)this.dataGridView1.CurrentRow.DataBoundItem).SupplyUnitId;

            this.search(string.Empty, sid, dtpf.Value.Date, dtpt.Value.AddDays(1).Date);
        }

        private void DrugStatic()
        {
            if (this.ListS.Count <= 1) return;

            var gr = from i in this.ListS
                     group i by new { i.drugName, i.SupplyUnitName } into g
                     let OrderId2Number = from j in g select new Business.Models.PurchaseID2DocumentNumber { Id=j.purchaseOrderID,DocumentNumber=j.PurchaseOrderDocumentNumber}
                     select new Business.Models.SupplyUnitHistoryDrugList
                     {
                         batchNumber = g.FirstOrDefault().batchNumber,
                         drugName = g.FirstOrDefault().drugName,
                         cansaleNum = g.Sum(r => r.cansaleNum),
                         Checker = g.FirstOrDefault().Checker,
                         CheckTime = g.FirstOrDefault().CheckTime,
                         CreateTime = g.FirstOrDefault().CreateTime,
                         Creator = g.FirstOrDefault().Creator,
                         dosage = g.FirstOrDefault().dosage,
                         DrugInfoId = g.FirstOrDefault().DrugInfoId,
                         factoryName = g.FirstOrDefault().factoryName,
                         InInventoryMan = g.FirstOrDefault().InInventoryMan,
                         InventoryNum = decimal.Round(g.Sum(r => r.InventoryNum), 2),
                         InventorySum = decimal.Round(g.Sum(r => r.InventorySum), 2),
                         InventoryTime = g.FirstOrDefault().InventoryTime,
                         Origin = g.FirstOrDefault().Origin,
                         outValidDate = g.FirstOrDefault().outValidDate,
                         permitNumber = g.FirstOrDefault().permitNumber,
                         PurchaseNum = g.Sum(r => r.PurchaseNum),
                         PurchaseOrderDocumentNumber = "共计" + OrderId2Number.Count() + "单",
                         PurchaseID2DocumentNumber = OrderId2Number,
                         purchaseOrderID = Guid.Empty,
                         PurchasePrice = g.Max(r => r.PurchasePrice),
                         Receiver = g.FirstOrDefault().Receiver,
                         ReceiveTime = g.FirstOrDefault().ReceiveTime,
                         specific = g.FirstOrDefault().specific,
                         SupplyUnitName = g.FirstOrDefault().SupplyUnitName,
                         SupplyUnitId = g.FirstOrDefault().SupplyUnitId,
                         WareHouseZone = g.FirstOrDefault().WareHouseZone
                     };
            var ListR = gr.OrderBy(r=>r.SupplyUnitName).ToList();
            
            //最后加一个汇总
            Business.Models.SupplyUnitHistoryDrugList s = new Business.Models.SupplyUnitHistoryDrugList();
            s.SupplyUnitName = "汇总结果";
            s.InventoryNum = decimal.Round(ListR.Sum(r => r.InventoryNum),2);
            s.InventorySum = decimal.Round(ListR.Sum(r => r.InventorySum),2);
            s.cansaleNum = decimal.Round(ListR.Sum(r => r.cansaleNum), 2);
            var Summary = from i in gr
                          group i by i.SupplyUnitName into g
                          select new Business.Models.SupplyUnitHistoryDrugList
                          {
                               SupplyUnitName="合计",
                               InventoryNum=decimal.Round(g.Sum(r=>r.InventoryNum),2),
                               InventorySum=decimal.Round(g.Sum(r=>r.InventorySum),2),
                               cansaleNum=decimal.Round(g.Sum(r=>r.cansaleNum),2),
                               SupplyUnitId=g.FirstOrDefault().SupplyUnitId
                          };
            List<int> ListIndex = new List<int>();
            foreach (var i in Summary)
            {
                var et=ListR.LastOrDefault(r => r.SupplyUnitId == i.SupplyUnitId);
                int index=ListR.LastIndexOf(et);
                ListR.Insert(index+1, i);
                ListIndex.Add(index + 1);
            }
            
            ListR.Insert(ListR.Count, s);
            
            this.dataGridView1.DataSource = ListR;
        }

        private void ShowAll()
        {
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.SupplyUnitHistoryDrugList>(this.ListS);
        }
        private void SupplyAndSale()
        {
            var c = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.SupplyUnitHistoryDrugList;
            Storage.Form_DrugPath frm = new Storage.Form_DrugPath(c.DrugInfoId, 3);
            frm.Show(this);
        }
        #endregion

        public FormPurchaseHistoryBySupplyer(string Kw,Guid sid,DateTime dtf,DateTime dtt)
            : this()
        {
            this.search(Kw, sid, dtf, dtt);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string kw = this.toolStripTextBox1.Text.Trim();
            this.search(kw, Guid.Empty, dtpf.Value.Date, dtpt.Value.AddDays(1).Date);
        }

        private void search(string kw, Guid sid, DateTime dtf, DateTime dtt)
        {
            var c = this.PharmacyDatabaseService.GetSupplyUnitHistoryDrugList(kw, this.toolStripTextBox2.Text.Trim(),sid, dtf, dtt, out msg).OrderBy(r => r.CreateTime);
            this.ListS = c.ToList();

            this.dataGridView1.DataSource = new BindingCollection<Business.Models.SupplyUnitHistoryDrugList>(ListS);

            if (this.ListS.Count > 0)
            {
                this.dataGridView1.Columns["Column18"].DefaultCellStyle.BackColor = Color.LightCyan;
                this.dataGridView1.Columns["Column11"].DefaultCellStyle.BackColor = Color.Yellow;
                this.dataGridView1.Columns["Column1"].DefaultCellStyle.BackColor = Color.LightYellow;
                this.dataGridView1.Columns["Column17"].DefaultCellStyle.BackColor = Color.LimeGreen;
            }

            if (this.ListS.Count > 0)
            {
                this.toolStripStatusLabel1.Text = "当前查询供货商名称：" + this.ListS.First().SupplyUnitName;
            }
            else
            {
                this.toolStripStatusLabel1.Text = "当前查询供货商供应数据为空";
            }
        }



        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1,"供应商供货记录查询结果");
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
    }
}
