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
            cms.InsertMenuItem("采购品种汇总", DrugStatic);
            cms.InsertMenuItem("全部显示", ShowAll);
            cms.InsertMenuItem("统计该药品购销情况", SupplyAndSale);   
            cms.InsertMenuItem("abc",GetAbc);
        }
        #region 右键事件
        private void SupplyStatic(string name)
        {
            var sid = ((Business.Models.SupplyUnitHistoryDrugList)this.dataGridView1.CurrentRow.DataBoundItem).SupplyUnitId;
            this.search(string.Empty, sid, dtpf.Value.Date, dtpt.Value.AddDays(1).Date);
        }
        private void DrugStatic(string name)
        {
            if (this.ListS.Count <= 1) return;

            var gr = from i in this.ListS
                     group i by new { i.drugName,i.SupplyUnitName} into g
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
                         InventoryNum = decimal.Round(g.Sum(r => r.InventoryNum),2),
                         InventorySum = decimal.Round(g.Sum(r => r.InventorySum),2),
                         InventoryTime = g.FirstOrDefault().InventoryTime,
                         Origin = g.FirstOrDefault().Origin,
                         outValidDate = g.FirstOrDefault().outValidDate,
                         permitNumber = g.FirstOrDefault().permitNumber,
                         PurchaseNum = g.Sum(r => r.PurchaseNum),
                         PurchaseOrderDocumentNumber = string.Empty,
                         purchaseOrderID = Guid.Empty,
                         PurchasePrice = g.Max(r => r.PurchasePrice),
                         Receiver = g.FirstOrDefault().Receiver,
                         ReceiveTime = g.FirstOrDefault().ReceiveTime,
                         specific = g.FirstOrDefault().specific,
                         SupplyUnitName = g.FirstOrDefault().SupplyUnitName,
                         SupplyUnitId=g.FirstOrDefault().SupplyUnitId,
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
            
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.SupplyUnitHistoryDrugList>(ListR);

        }
        private void ShowAll(string name)
        {
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.SupplyUnitHistoryDrugList>(this.ListS);
        }
        private void SupplyAndSale(string name)
        {
            var c = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.SupplyUnitHistoryDrugList;
            Storage.Form_DrugPath frm = new Storage.Form_DrugPath(c.DrugInfoId, 3);
            frm.Show(this);
        }
        private void GetAbc(string name)
        {
            
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
            var c = this.PharmacyDatabaseService.GetSupplyUnitHistoryDrugList(kw, sid, dtf, dtt, out msg).OrderBy(r => r.CreateTime);
            this.ListS = c.ToList();

            this.dataGridView1.DataSource = new BindingCollection<Business.Models.SupplyUnitHistoryDrugList>(ListS);
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
