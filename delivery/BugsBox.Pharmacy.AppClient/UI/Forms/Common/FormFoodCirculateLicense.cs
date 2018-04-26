using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class FormFoodCirculateLicense : BaseFunctionForm
    {
        public FormFoodCirculateLicense(Guid guid, string name, string address, string legalperson)
        {
            InitializeComponent();
            this.guid = guid;
            this.unitName = name;
            this.Address = address;
            this.Legalperson = legalperson;
        }

        public Guid guid { get; private set; }
        public FoodCirculateLicense FoodCirculateLicense { get; private set; }
        public string unitName;
        public string Address;
        public string Legalperson;

        private void LoadDataFromServer()
        {
            string message = string.Empty;
            FoodCirculateLicense = PharmacyDatabaseService.GetFoodCirculateLicense(out message, guid);
            if (FoodCirculateLicense == null)
            {                
                FoodCirculateLicense = new FoodCirculateLicense();
                FoodCirculateLicense.Id = Guid.Empty;
                FoodCirculateLicense.StartDate = DateTime.Now;
                FoodCirculateLicense.OutDate = DateTime.Now;
                FoodCirculateLicense.IssuanceDate = DateTime.Now;
                dateTimePickerOutDate.Value = DateTime.Now.AddYears(1);
                FoodCirculateLicense.UnitName = unitName;
                FoodCirculateLicense.RegAddress = Address;
                FoodCirculateLicense.Header = Legalperson;
            }
            checkValidStatus();
        }

        public void InitRequiredControl()
        {
            if (!DesignMode)
            {
                AddRequiredValidate(label1, textBoxName);
                AddRequiredValidate(label7, textBoxLicenseCode);
                AddRequiredValidate(label8, textBoxNo);
                AddRequiredValidate(label2, textBoxUnitName);
                AddRequiredValidate(label6, textBoxOrgType);
                AddRequiredValidate(label4, textBoxLegalPerson);
                AddRequiredValidate(label3, textBoxRegAddress);
                AddRequiredValidate(label11, textBoxLicenseRange);
                AddRequiredValidate(label9, textBoxIssuanceOrg);
                AddRequiredValidate(label10, dateTimePickerOutDate);
            }
        }

        private void BindInfo()
        {
            try
            {
                if (FoodCirculateLicense != null)
                {
                    //基本信息
                    textBoxName.Text = FoodCirculateLicense.Name;
                    textBoxLicenseCode.Text = FoodCirculateLicense.LicenseCode;
                    textBoxUnitName.Text = FoodCirculateLicense.UnitName;
                    textBoxRegAddress.Text = FoodCirculateLicense.RegAddress;
                    textBoxIssuanceOrg.Text = FoodCirculateLicense.IssuanceOrg;
                    dateTimePickerIssuanceDate.Value = FoodCirculateLicense.IssuanceDate;
                    dateTimePickerOutDate.Value = FoodCirculateLicense.OutDate;
                    textBoxLegalPerson.Text = FoodCirculateLicense.Header;
                    textBoxOrgType.Text = FoodCirculateLicense.OrgType;
                    textBoxLicenseRange.Text = FoodCirculateLicense.memo;

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //MessageBox.Show("设置证书信息到控件失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"设置证书信息到控件失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool DataReady { get; set; }

        private void CellectInfo()
        {
            DataReady = false;
            try
            {
                string msg = String.Empty;
                if (!ValidateControls(out msg))
                {
                    MessageBox.Show(msg);
                    return;
                }
                if (FoodCirculateLicense != null)
                {
                    FoodCirculateLicense.Name=textBoxName.Text;
                    FoodCirculateLicense.LicenseCode=textBoxLicenseCode.Text;
                    FoodCirculateLicense.UnitName=textBoxUnitName.Text;
                    FoodCirculateLicense.RegAddress=textBoxRegAddress.Text;
                    FoodCirculateLicense.IssuanceOrg=textBoxIssuanceOrg.Text;
                    FoodCirculateLicense.IssuanceDate=dateTimePickerIssuanceDate.Value;
                    FoodCirculateLicense.OutDate=dateTimePickerOutDate.Value;
                    FoodCirculateLicense.Header= textBoxLegalPerson.Text;
                    FoodCirculateLicense.OrgType =textBoxOrgType.Text;
                    FoodCirculateLicense.memo =textBoxLicenseRange.Text;

                    DataReady = true;
                }
            }
            catch (Exception ex)
            {
                DataReady = false;
                Log.Error(ex);
                //MessageBox.Show("从控件获取证书失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"从控件获取证书失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dateTimePickerIssuanceDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.dateTimePickerIssuanceDate.Value.Date >= this.dateTimePickerOutDate.Value.Date)
            {
                this.textBoxStatus.Text = "证书日期无效";
                return;
            }
            else
            {
                this.textBoxStatus.Text = "证书日期有效";
            }
            if (DateTime.Now.Date >= this.dateTimePickerOutDate.Value.Date)
            {
                this.textBoxStatus.Text = "证书已经过期";
            }
            else
            {
                this.textBoxStatus.Text = "证书有效";
            }
        }

        private void dateTimePickerOutDate_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerIssuanceDate_ValueChanged(sender, e);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                CellectInfo();
                if (DataReady)
                {
                    string msg = string.Empty;
                    bool result = false;
                    if (this.FoodCirculateLicense.Id!=null && (!this.FoodCirculateLicense.Id.Equals(Guid.Empty)))
                    {
                        result = PharmacyDatabaseService.SaveFoodCirculateLicense(out msg, this.FoodCirculateLicense);
                    }
                    else
                    {
                        this.FoodCirculateLicense.Id = Guid.NewGuid();
                        result = PharmacyDatabaseService.AddFoodCirculateLicense(out msg, this.FoodCirculateLicense);
                    }
                    if (result && string.IsNullOrWhiteSpace(msg))
                    {
                        //MessageBox.Show("证书保证成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text+"证书保证成功","错误" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("证书保存失败" + msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                        MessageBox.Show(this.Text+"证书保存失败" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        return;
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("证书保存失败" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"证书保存失败" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
              this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
              this.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            InitRequiredControl();
            LoadDataFromServer();
            BindInfo();
        }

       /* private void buttonCommitFiles_Click(object sender, EventArgs e)
        {
            Button btnFile = sender as Button;
            Guid fileId = Guid.Empty;
            if (btnFile.Tag != null)
            {
                fileId = (Guid)btnFile.Tag;
            }
            string msg;
            UserControlPharmacyFile form = new UserControlPharmacyFile(true);
            form.Title = btnFile.Parent.Text;
            form.OldPharmacyFile = PharmacyDatabaseService.GetPharmacyFile(out msg, fileId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                btnFile.Tag = form.PharmacyFile.Id;
            }
        }*/

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.guid == Guid.Empty || this.guid == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1103, this.guid);
            if (!this.buttonSave.Visible)
            {
                SetControls.SetControlReadonly(frm, true);
            }
            frm.ShowDialog();
        }

        private void checkValidStatus()
        {
            if (DateTime.Now.Date < dateTimePickerOutDate.Value.Date)
            {
                this.textBoxStatus.Text = "证书日期有效";
            }
            else
            {
                this.textBoxStatus.Text = "证书已过期";
            }
        }

        private void dateTimePickerOutDate_ValueChanged_1(object sender, EventArgs e)
        {
            checkValidStatus();
        }
    }
}
