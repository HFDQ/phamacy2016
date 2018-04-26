using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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

namespace BugsBox.Pharmacy.AppClient.UI.UserControls
{
    public partial class ucDrugsUnqualification : BaseFunctionUserControl
    {
        string msg = string.Empty;

        public ucDrugsUnqualification()
        {
            InitializeComponent();
        }

        public ucDrugsUnqualification(Business.Models.drugsUnqualificationQuery dq)
        {
            InitializeComponent();
            if (dq == null) return;
            this.textBox1.Text = dq.drugName;
            this.textBox2.Text = dq.batchNo;
            this.textBox3.Text = dq.quantity.ToString();
            this.textBox4.Text = dq.CurrentInventoryCount.ToString();
            this.textBox5.Text = dq.WarehouseZone;
            this.textBox6.Text = dq.Warehouse;
            this.textBox7.Text = dq.Source;
            this.textBox8.Text = "不合格药品审核流程";   

            this.textBox9.Text = dq.Dosage;
            this.textBox10.Text = dq.Specific;
            this.textBox11.Text = dq.OutValidDate.ToLongDateString();
            this.textBox12.Text = dq.FactoryName;
            this.textBox13.Text = string.IsNullOrEmpty(dq.SupplyUnitName)?"前期库存，无入库信息":dq.SupplyUnitName;
            this.textBox14.Text = dq.InInventoryDate.ToLongDateString();
            this.textBox15.Text = (DateTime.Now.Date-dq.InInventoryDate).Days.ToString()+"天";
            this.textBox16.Text = dq.Origin;
            this.textBox19.Text = dq.PurchaseOrderDocumentNumber;
            this.textBox20.Text = dq.productDate.ToLongDateString();
            this.txtRemark.Text = dq.Description;

            this.initApprovalDetail(dq.flowID);

            foreach (Control c in this.groupBox1.Controls)
            {                
                if (c.GetType()==typeof(TextBox))
                {
                    ((TextBox)c).ReadOnly = true;
                }
            }
        }

        public void initApprovalDetail( Guid flowID )
        {
            string msg=string.Empty;
            List<ApprovalFlowRecord> list = PharmacyDatabaseService.GetFinishApproveFlowsRecord(out msg, flowID, 0).OrderBy(r=>r.ApproveTime).ToList();
            Label label = null;
            TextBox tb = null;
            int i = 1;
            int appStatus =PharmacyDatabaseService.GetApproveFlowsByFlowID(out msg,flowID).Status;
            foreach (var d in list)
            {
                string name = PharmacyDatabaseService.GetUser(out msg, d.ApproveUserId).Employee.Name;
                
                label = new Label();
                tb = new TextBox();
                label.Text = "审批意见" + i.ToString()+"：";
                label.Left = this.label6.Left;
                label.Top = this.groupBox1.Controls[this.groupBox1.Controls.Count - 1].Top + this.groupBox1.Controls[this.groupBox1.Controls.Count - 1].Height+10;
                tb.Left = label.Left + label.Width;
                tb.Width = this.txtRemark.Width;
                tb.Height = 40;
                tb.Top = label.Top-3;
                tb.Multiline = true;
                tb.ScrollBars = ScrollBars.Both;
                tb.Text = d.Comment+"\r\n审核者："+name;
                this.groupBox1.Controls.Add(label);
                this.groupBox1.Controls.Add(tb);
                this.Height += 53;
                i++;
            }
            string appSta=appStatus==1?"待审":appStatus==2?"审核通过":appStatus==4?"审核未通过":"其他";
            label = new Label();
            label.AutoSize = true;
            label.Text = "当前审批状态：'" + appSta+"'";
            label.Top = this.groupBox1.Controls[this.groupBox1.Controls.Count - 1].Top + this.groupBox1.Controls[this.groupBox1.Controls.Count - 1].Height + 10;
            label.Left = this.Width/2-label.Width/2;
            this.Height += label.Height;
            this.groupBox1.Controls.Add(label);
        }
    }
}
