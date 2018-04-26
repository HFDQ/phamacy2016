using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugMaintain
{
    public partial class DrugMaintainSetForm : BaseFunctionForm
    {
        public DrugMaintainSetForm()
        {
            InitializeComponent();
        }

        private void DrugMaintenanceSet_Load(object sender, EventArgs e)
        {
            string msg = "";
            DrugMaintainSet normaldws = PharmacyDatabaseService.GetDrugMaintainSetByDrugMaintainTypeValue(out msg, (int)DrugMaintainType.Normal);
            if (normaldws != null)
            {
                txtNormalName.Text = normaldws.Name;

                txtNormalRemindBeforeDay.Value = normaldws.RemindBeforeDay; 
            }
            DrugMaintainSet specialdws = PharmacyDatabaseService.GetDrugMaintainSetByDrugMaintainTypeValue(out msg, (int)DrugMaintainType.Special);
            if (specialdws != null)
            {
                txtSpecialName.Text = specialdws.Name; 
                txtSpecialRemindBeforeDay.Value = specialdws.RemindBeforeDay; 
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                DrugMaintainSet normaldws = PharmacyDatabaseService.GetDrugMaintainSetByDrugMaintainTypeValue(out msg, (int)DrugMaintainType.Normal);
                if (normaldws != null)//修改
                {
                    normaldws.Name = txtNormalName.Text.Trim(); 
                    normaldws.RemindBeforeDay =Convert.ToInt16( txtNormalRemindBeforeDay.Value); 
                    PharmacyDatabaseService.SaveDrugMaintainSet(out msg, normaldws);
                }
                else//新增
                {
                    normaldws = new DrugMaintainSet();
                    normaldws.DrugMaintainTypeValue = (int)DrugMaintainType.Normal;
                    normaldws.Name = txtNormalName.Text.Trim(); 
                    normaldws.RemindBeforeDay = Convert.ToInt16(txtNormalRemindBeforeDay.Value); 
                    PharmacyDatabaseService.AddDrugMaintainSet(out msg, normaldws);
                }

                DrugMaintainSet specialdws = PharmacyDatabaseService.GetDrugMaintainSetByDrugMaintainTypeValue(out msg, (int)DrugMaintainType.Special);
                //重点药品无最少维护百分比
                if (specialdws != null)//修改
                {
                    specialdws.Name = txtSpecialName.Text.Trim(); 
                    specialdws.RemindBeforeDay = Convert.ToInt16(txtSpecialRemindBeforeDay.Value); 
                    PharmacyDatabaseService.SaveDrugMaintainSet(out msg, specialdws);
                }
                else//新增
                {
                    specialdws = new DrugMaintainSet();
                    specialdws.DrugMaintainTypeValue = (int)DrugMaintainType.Special;
                    specialdws.Name = txtSpecialName.Text.Trim(); 
                    specialdws.RemindBeforeDay = Convert.ToInt16(txtSpecialRemindBeforeDay.Value); 
                    PharmacyDatabaseService.AddDrugMaintainSet(out msg, specialdws);
                }
                MessageBox.Show("数据保存成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
            }
        }
    }
}
