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

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugsUnqualification
{
    public partial class FormDrugUnqualificationDestroy : BaseFunctionForm
    {
        string msg = string.Empty;
        DrugsBreakage dq = null;
        List<DrugsBreakage> ListDrugBreakage = new List<DrugsBreakage>();
        public bool ok;
        public FormDrugUnqualificationDestroy()
        {
            InitializeComponent();
        }
        public FormDrugUnqualificationDestroy(DrugsBreakage[] dbs):this()
        {
            this.ListDrugBreakage = dbs.ToList();
            this.groupBox3.Enabled = false;
        }

        public FormDrugUnqualificationDestroy(  DrugsBreakage d )
        {
            InitializeComponent();
            this.GetDrugBreakageInfo(d);
            ListDrugBreakage.Add(d);
        }
        private void GetDrugBreakageInfo(DrugsBreakage d)
        {
            dq = d;
            t1.Text = d.drugName;
            t2.Text = d.batchNo;
            t3.Text = d.quantity.ToString();
            t4.Text = d.PurchasePrice.ToString() + "元";
            t5.Text = d.Specific;
            t6.Text = d.DosageType;
            t7.Text = d.FactoryName;
            t8.Text = d.produceDate.ToLongDateString();
            t9.Text = d.ExpireDate.ToLongDateString();
            t10.Text = d.Supplyer;
            t11.Text = "不合格库区";            
            t13.Text = (d.quantity * d.PurchasePrice).ToString();
            this.textBox1.Text = "不合格库";
            this.textBox3.Text = d.Origin;
            this.textBox4.Text = d.source;
            this.textBox2.Text = d.PurchaseOrderDocumentNumber;
            this.textBox5.Text = d.UnqualificationDocumentNumber;
            this.textBox6.Text = d.DocumentNumber;
            Forms.Common.SetControls.SetControlReadonly(this.groupBox3, true);
        }

        public FormDrugUnqualificationDestroy(DrugsUnqualificationDestroy d)
        {
            InitializeComponent();
            this.toolStripButton1.Enabled = true;
            DrugsBreakage dbk =this.PharmacyDatabaseService.GetDrugsBreakage(d.DrugsUnqualicationID,out msg);
            this.GetDrugBreakageInfo(dbk);

            q1.Text = d.DestroyPlace;
            q2.Text = d.DestroyTime.ToLongDateString();
            q3.Text = d.DestroyCargo;
            q4.Text = d.Destroyer;
            q5.Text = d.DestroyMan;
            q6.Text = d.DestroyMethod;
            q7.Text = d.DestroyReason;
            q8.Text = d.DestroyState;
            q9.Text = d.SupervisorOpinion;

            Forms.Common.SetControls.SetControlReadonly(this.groupBox2, true);

            toolStrip1.Enabled = false;
            button1.Visible = false;
            toolStripButton3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            #region 批量提交
            if (ListDrugBreakage != null)
            {
                Models.DrugsUnqualificationDestroy d = new DrugsUnqualificationDestroy();
                d.createUID = AppClientContext.CurrentUser.Id;

                d.DestroyPlace = q1.Text.Trim();
                if (string.IsNullOrEmpty(d.DestroyPlace))
                {
                    MessageBox.Show("销毁地点没有填写，请填写!");
                    q1.Focus();
                    return;
                }

                d.DestroyCargo = q3.Text.Trim();
                if (string.IsNullOrEmpty(d.DestroyCargo))
                {
                    MessageBox.Show("销毁车辆没有填写，请填写!");
                    q3.Focus();
                    return;
                }

                d.Destroyer = q4.Text.Trim();
                if (string.IsNullOrEmpty(d.Destroyer))
                {
                    MessageBox.Show("销毁运输员没有填写，请填写!");
                    q4.Focus();
                    return;
                }

                d.DestroyMan = q5.Text.Trim();
                if (string.IsNullOrEmpty(d.DestroyMan))
                {
                    MessageBox.Show("销毁人没有填写，请填写!");
                    q5.Focus();
                    return;
                }

                d.DestroyMethod = q6.Text.Trim();
                if (string.IsNullOrEmpty(d.DestroyMethod))
                {
                    MessageBox.Show("销毁方法没有填写，请填写!");
                    q6.Focus();
                    return;
                }

                d.DestroyReason = q7.Text.Trim();
                if (string.IsNullOrEmpty(d.DestroyReason))
                {
                    MessageBox.Show("销毁原因没有填写，请填写!");
                    q7.Focus();
                    return;
                }

                d.DestroyState = q8.Text.Trim();
                if (string.IsNullOrEmpty(d.DestroyState))
                {
                    MessageBox.Show("销毁状态没有填写，请填写!");
                    q8.Focus();
                    return;
                }

                d.DestroyTime = q2.Value;

                d.SupervisorOpinion = q9.Text.Trim();
                if (string.IsNullOrEmpty(d.SupervisorOpinion))
                {
                    MessageBox.Show("药监部门意见没有填写，请填写!");
                    q9.Focus();
                    return;
                }
                

                if (this.PharmacyDatabaseService.CreateDestroyByDrugsBreakage(ListDrugBreakage.ToArray(), d, out msg))
                {
                    MessageBox.Show("写入成功！");
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "新建药品销毁信息成功");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
            #endregion
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.button1_Click(sender,e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
