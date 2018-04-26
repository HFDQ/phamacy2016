using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.UI.UserControls;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.UserControls
{
    public partial class UcDrugBreakage : BaseFunctionUserControl
    {
        string msg = "";
        public UcDrugBreakage(Models.DrugsBreakage db,ApprovalFlow flow)
        {
            InitializeComponent();

            Forms.Common.SetControls.SetControlReadonly(this.groupBox1,true);

            this.textBox1.Text = db.drugName;
            this.textBox2.Text = db.batchNo;
            this.textBox3.Text = db.quantity.ToString();
            this.textBox4.Text = db.PurchaseOrderDocumentNumber;
            this.textBox18.Text = db.Supplyer;
            this.textBox20.Text = db.produceDate.ToLongDateString();
            this.textBox19.Text = db.ExpireDate.ToLongDateString();

            this.textBox5.Text = "不合格库区";
            this.textBox6.Text = "不合格库";
            this.textBox7.Text = db.UnqualificationDocumentNumber;

            this.textBox13.Text = db.DosageType;
            this.textBox14.Text = db.Specific;
            this.textBox15.Text = db.FactoryName;
            this.textBox17.Text = db.Origin;
            this.textBox16.Text = db.PurchasePrice.ToString();

            this.textBox8.Text = this.PharmacyDatabaseService.GetApprovalFlowType(out msg,flow.ApprovalFlowTypeId).Name;
            this.textBox9.Text = db.DocumentNumber;
            this.textBox10.Text = db.source;
            this.textBox11.Text = db.createTime.ToLongDateString();
            this.textBox12.Text = PharmacyDatabaseService.GetUser(out msg, db.createUID).Employee.Name;
            this.txtRemark.Text = db.Description;

            this.initApprovalDetail(flow.FlowId);
        }


        public void initApprovalDetail(Guid flowID)
        {
            string msg = string.Empty;
            List<ApprovalFlowRecord> list = PharmacyDatabaseService.GetFinishApproveFlowsRecord(out msg, flowID, 0).OrderBy(r => r.ApproveTime).ToList();
            Label label = null;
            TextBox tb = null;
            int i = 1;
            int appStatus = PharmacyDatabaseService.GetApproveFlowsByFlowID(out msg, flowID).Status;
            foreach (var d in list)
            {
                string name = PharmacyDatabaseService.GetUser(out msg, d.ApproveUserId).Employee.Name;

                label = new Label();
                tb = new TextBox();
                label.Text = "审批意见" + i.ToString() + "：";
                label.Left = this.label6.Left;
                label.Top = this.groupBox1.Controls[this.groupBox1.Controls.Count - 1].Top + this.groupBox1.Controls[this.groupBox1.Controls.Count - 1].Height + 10;
                tb.Left = label.Left + label.Width;
                tb.Width = this.txtRemark.Width;
                tb.Height = 40;
                tb.Top = label.Top - 3;
                tb.Multiline = true;
                tb.ScrollBars = ScrollBars.Both;
                tb.Text = d.Comment + "\r\n审核者：" + name;
                this.groupBox1.Controls.Add(label);
                this.groupBox1.Controls.Add(tb);
                this.Height += 53;
                i++;
            }
            string appSta = appStatus == 1 ? "待审" : appStatus == 2 ? "审核通过" : appStatus == 4 ? "审核未通过" : "其他";
            label = new Label();
            label.AutoSize = true;
            label.Text = "当前审批状态：'" + appSta + "'";
            label.Top = this.groupBox1.Controls[this.groupBox1.Controls.Count - 1].Top + this.groupBox1.Controls[this.groupBox1.Controls.Count - 1].Height + 10;
            label.Left = this.Width / 2 - label.Width / 2;
            this.Height += label.Height;
            this.groupBox1.Controls.Add(label);
        }
    }
}
