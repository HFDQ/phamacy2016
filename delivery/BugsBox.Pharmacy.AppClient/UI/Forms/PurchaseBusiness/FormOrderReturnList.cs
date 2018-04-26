using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.UI.Common.Printer;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormOrderReturnList : BaseFunctionForm
    {
        string msg = string.Empty;
        private BindingList<ReturnPurchaseOrderList> bList = new BindingList<ReturnPurchaseOrderList>();
        private List<ReturnPurchaseOrderList> list = new List<ReturnPurchaseOrderList>();
        private string pars = string.Empty;
        DateTimePicker dtF = new DateTimePicker();
        DateTimePicker dtT = new DateTimePicker();
        private List<PurchasingPlan> ListPlan = new List<PurchasingPlan>();
        Pharmacy.UI.Common.BaseRightMenu cms;
        
        public FormOrderReturnList()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            cms = new BaseRightMenu(this.dataGridView1);
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            cms.InsertMenuItem("查看配送入库订单", this.GetPurchaseOrder);
            cms.InsertMenuItem("查看配送入库收货单", this.GetPurchaseReceivingOrder);
            cms.InsertMenuItem("查看配送入库验收单", this.GetPurchaseCheckingOrder);
            cms.InsertMenuItem("查看配送入库入库单", this.GetPurchaseInInventoryOrder);
        }

        private void GetPurchaseOrder()
        {
            Guid Pid=((ReturnPurchaseOrderList)this.dataGridView1.CurrentRow.DataBoundItem).id;
            PurchaseOrdeEntity poe = this.PharmacyDatabaseService.GetPurchaseOrderEntity(out msg, Pid);
            FormPurchaseOrderEdit frm = new FormPurchaseOrderEdit(poe,false,true);
            frm.Show(this);
        }
        private void GetPurchaseCheckingOrder()
        {
            Guid Pid = ((ReturnPurchaseOrderList)this.dataGridView1.CurrentRow.DataBoundItem).id;
            PurchaseCommonEntity pcod = this.PharmacyDatabaseService.GetPurchaseCheckingOrdersByPurchaseOrderId(out msg, Pid).FirstOrDefault();
            if (pcod == null)
            {
                MessageBox.Show("该单据无验收信息，请联系管理员！"); return;
            }
            FormCheckOrder frm = new FormCheckOrder(pcod, true);
            frm.Show(this);
        }
        private void GetPurchaseInInventoryOrder()
        {
            Guid Pid = ((ReturnPurchaseOrderList)this.dataGridView1.CurrentRow.DataBoundItem).id;
            PurchaseCommonEntity pcod = this.PharmacyDatabaseService.GetPurchaseInInventeryOrdersByPurchaseOrderId(out msg, Pid).FirstOrDefault();
            if (pcod == null)
            {
                MessageBox.Show("该单据无验收信息，请联系管理员！"); return;
            }
            FormInInventory frm = new FormInInventory(pcod, true);
            frm.Show(this);
        }
        private void GetPurchaseReceivingOrder()
        {
            Guid Pid = ((ReturnPurchaseOrderList)this.dataGridView1.CurrentRow.DataBoundItem).id;
            PurchaseCommonEntity pcod = this.PharmacyDatabaseService.GetPurchaseReceivingOrdersByPurchaseOrderId(out msg, Pid).FirstOrDefault();
            if (pcod == null)
            {
                MessageBox.Show("该单据无验收信息，请联系管理员！"); return;
            }
            FormReceivingOrder frm = new FormReceivingOrder(pcod, true);
            frm.Show(this);
        }

        public FormOrderReturnList(object parms):this()
        {
            string pars = parms.ToString();
            this.Column3.Visible = false;
            this.Column5.Visible = true;
            this.toolStripButton2.Visible = true;

            dtF.Width = 100;
            ToolStripControlHost tsc = new ToolStripControlHost(dtF);
            toolStrip1.Items.Insert(10,tsc);

            Label l = new Label();
            l.Text = "至：";
            tsc = new ToolStripControlHost(l);
            toolStrip1.Items.Insert(11,tsc);
            dtT.Width = 100;
            tsc = new ToolStripControlHost(dtT);
            toolStrip1.Items.Insert(12,tsc);
            toolStripButton3.Visible = true;
            this.Text = "采购冲差价处理平台";
        }

        private void getData()
        {
            string keyword = this.toolStripTextBox1.Text.Trim();
            //if (string.IsNullOrWhiteSpace(keyword)) return;
            string py=this.toolStripTextBox2.Text.Trim();
            string DrugName = this.toolStripTextBox3.Text.Trim();
            string batch = this.toolStripTextBox4.Text.Trim();
            var re = this.PharmacyDatabaseService.GetInventeryOrderListByReturn(keyword,py,DrugName,batch,out msg);

            var all = from i in re
                     group i by i.id into g
                     select new ReturnPurchaseOrderList
                     {
                         id = g.FirstOrDefault().id,
                         InventoryDate = g.FirstOrDefault().InventoryDate.Date,
                         PInventoryDocumentNumber = g.FirstOrDefault().PInventoryDocumentNumber,
                         POrderDocumentNumber = g.FirstOrDefault().POrderDocumentNumber,
                         py = g.FirstOrDefault().py,
                         SupplyUnitName = g.FirstOrDefault().SupplyUnitName
                     };

            bList.Clear();
            foreach (var i in all)
            {
                bList.Add(i);
                list.Add(i);
            }
            this.dataGridView1.DataSource = new BindingCollection<ReturnPurchaseOrderList>(all.ToList());
        }

        private void FormOrderReturnList_Activated(object sender, EventArgs e)
        {
            this.toolStripTextBox1.Focus();
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Return)
            getData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //for (int i = 1; i < this.dataGridView1.Columns.Count; i++)
            //{
            //    if (i <= 6)
            //    {
            //        if (i == 5) continue;
            //        this.dataGridView1.Columns[i].Visible = true;
            //    }
            //    else
            //    {
            //        this.dataGridView1.Columns[i].Visible = false;
            //    }
            //}
            //this.dataGridView1.DataSource = null;
            getData();

        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(toolStripTextBox2.Text.Trim()) || string.IsNullOrEmpty(toolStripTextBox2.Text.Trim())) return;
            if (bList.Count <= 0) return;
            var c=from i in list where i.py.Contains(toolStripTextBox2.Text.Trim()) select i;
            bList.Clear();
            foreach (var l in c)
            {
                bList.Add(l);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            //销退
            if (this.dataGridView1.CurrentCell.OwningColumn.Name.Contains("Column3"))
            {
                Guid id = bList[this.dataGridView1.CurrentRow.Index].id;
                PurchaseOrderReturnDetailEntity[] perc = this.PharmacyDatabaseService.getPurchaseInventoryDetatilEntity(id, out msg);
                if (perc == null)
                {
                    MessageBox.Show("请联系管理员，配送入库记录被删除！");
                    return;
                }
                PurchaseCommonEntity pce = this.PharmacyDatabaseService.GetPurchaseInInventeryOrdersByPurchaseOrderId(out msg, id).First();
                FormReturnOrder f = new FormReturnOrder(pce, perc.ToList());
                f.ShowDialog();
                f.Dispose();
            }

            //采购冲差价
            if (this.dataGridView1.CurrentCell.OwningColumn.Name.Contains("Column5"))
            {
                Guid id = bList[this.dataGridView1.CurrentRow.Index].id;
                Form_PurchaseRefund frm = new Form_PurchaseRefund(id,false);
                frm.ShowDialog();
                frm.Dispose();
            }

            if (this.dataGridView1.CurrentCell.OwningColumn.Name.Contains("Column11"))
            {
                Guid PurchaseOrderId = Guid.Parse(this.dataGridView1.Rows[e.RowIndex].Cells["poid"].Value.ToString());

                List<PurchasingPlan> subP = ListPlan.Where(r => r.ReleatedPurchaseOrderId == PurchaseOrderId).ToList();
                Form_PurchaseRefund frm = new Form_PurchaseRefund( PurchaseOrderId , subP.ToArray(), false);
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                if (i <= 6)
                {
                    this.dataGridView1.Columns[i].Visible = false;
                }
                else
                {
                    this.dataGridView1.Columns[i].Visible = true;
                }
            }
            List<object> Objs=new List<object>();
            Objs.Add(null);
            Objs.Add(dtF.Value);
            Objs.Add(dtT.Value);
            ListPlan = this.PharmacyDatabaseService.GetPurchaseRefunds(Objs.ToArray(), out msg).ToList();
            if (ListPlan == null) return;
            var g=from i in ListPlan group i by new {i.ReleatedPurchaseOrderId} ;
            List<PurchasingPlan> pl = new List<PurchasingPlan>();

            foreach (var u in g.ToList())
            {
                var i = u.First();
                pl.Add(i);
            }

            this.dataGridView1.DataSource = pl.ToList();

        }
    }



    
}
