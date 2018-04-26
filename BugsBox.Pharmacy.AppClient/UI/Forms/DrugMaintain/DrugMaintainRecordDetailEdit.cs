using BugsBox.Pharmacy.AppClient.PS;
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

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugMaintain
{
   public partial class DrugMaintainRecordDetailEdit : BaseFunctionForm 
    {
       public static bool IsEdit;//只读/编辑
       public DrugMaintainRecordDetailEdit()
        {
            InitializeComponent();
        }

       private void DrugMaintainRecordDetailEdit_Load(object sender, EventArgs e)
       {
           if (DrugMaintainRecordDetailEdit.IsEdit)
           {
               txtCheckDate.Enabled = true;
               txtCheckqualifiedNumber.Enabled = true;
               txtCheckResult.ReadOnly = false; 
               BuSave.Visible = true;
               this.Text = "药品养护记录明细编辑";
           }
           else
           {
               txtCheckDate.Enabled = false;
               txtCheckqualifiedNumber.Enabled = false;
               txtCheckResult.ReadOnly = true;
               BuSave.Visible = false;
               this.Text = "药品养护记录明细查看";
           }

           string msg;
           DrugMaintainRecordDetail detail = PharmacyDatabaseService.GetDrugMaintainRecordDetail(out msg, DrugMaintainRecordDetails.DrugMaintainRecordDetailId);
           txtProductName.Text = detail.ProductName;
           txtMaintainCount.Text = detail.MaintainCount.ToString();

           if (detail.CheckDate != null)
           {
               txtCheckDate.Text = Convert.ToDateTime(detail.CheckDate).ToString("yyyy-MM-dd");
           }
           txtCheckqualifiedNumber.Text = detail.CheckqualifiedNumber;
           txtCheckResult.Text = detail.CheckResult;

           //txtQualitySituation.Text = detail.QualitySituation;
           //txtMaintainMeasure.Text = detail.MaintainMeasure;
           //txtMaintainResult.Text = detail.MaintainResult; 
       }
       

        //保存
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string msg;
            DrugMaintainRecordDetail detail = PharmacyDatabaseService.GetDrugMaintainRecordDetail(out msg, DrugMaintainRecordDetails.DrugMaintainRecordDetailId);

            //detail.QualitySituation = txtQualitySituation.Text.Trim();
            //detail.MaintainMeasure = txtMaintainMeasure.Text.Trim();
            detail.CheckResult = txtCheckResult.Text.Trim();
            detail.CheckDate = txtCheckDate.Value;
            detail.CheckqualifiedNumber = txtCheckqualifiedNumber.Value.ToString();
            detail.UserId = AppClientContext.CurrentUser.Id; 
            //detail.CheckDate = DateTime.Now.Date;

            bool result = PharmacyDatabaseService.SaveDrugMaintainRecordDetail(out msg, detail);
            if (result)
            {
                bool Iscomplete = true;
                List<DrugMaintainRecordDetail> list = PharmacyDatabaseService.GetDrugMaintainRecordDetailByCondition(out msg, detail.BillDocumentNo, null).ToList();
                foreach (DrugMaintainRecordDetail item in list)
                {
                    if (item.UserId == null)
                    {
                        Iscomplete = false;
                        break;
                    }
                }
                if (Iscomplete)
                {
                    PharmacyDatabaseService.SaveDrugMaintainRecordByBillDocumentNo(out msg, detail.BillDocumentNo, Iscomplete);
                }

                MessageBox.Show("数据保存成功");
                this.Close();
            } 
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
