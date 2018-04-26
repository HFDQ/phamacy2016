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
    public partial class FormMedicineProductionLicense : BaseFunctionForm
    {
        public bool clear = false;
        string msg = string.Empty;

        public FormMedicineProductionLicense(Guid guid, string legalPerson, string name, string address)
        {
            InitializeComponent();
            this.guid = guid;
            this.Name = name;
            this.LegalPerson = legalPerson;
            this.Address = address;
        }

        public FormMedicineProductionLicense(Guid guid,bool Readonly=false)
        {
            InitializeComponent();
            this.guid = guid;
        }

        public string LegalPerson { get; private set; }
        public string Name { get; private set; }
        //public string QualityCharger { get; private set; }
        public Guid guid { get; private set; }
        public string Address;

        public MedicineProductionLicense MedicineProductionLicense { get; private set; }
        private void LoadDataFromServer()
        {
            string message = string.Empty;
            MedicineProductionLicense = PharmacyDatabaseService.GetMedicineProductionLicense(out message, guid);
            if (MedicineProductionLicense == null)
            {
                MedicineProductionLicense = new MedicineProductionLicense();
                MedicineProductionLicense.Id = Guid.Empty;
                MedicineProductionLicense.IssuanceDate = DateTime.Now;
                MedicineProductionLicense.StartDate = DateTime.Now;
                MedicineProductionLicense.OutDate = DateTime.Now.AddYears(1);
                MedicineProductionLicense.UnitName = Name;
                MedicineProductionLicense.LegalPerson = LegalPerson;
                MedicineProductionLicense.Header = LegalPerson;
                MedicineProductionLicense.RegAddress = Address;
                MedicineProductionLicense.ProductAddress = Address;
            }
        }

        public void InitRequiredControl()
        {
            if (!DesignMode)
            {
                AddRequiredValidate(label1, textBoxName);
                AddRequiredValidate(label7, textBoxLicenseCode);
                AddRequiredValidate(label2, textBoxUnitName);
                AddRequiredValidate(label3, textBoxRegAddress);//注册地址
                AddRequiredValidate(label9, textBoxIssuanceOrg);
                AddRequiredValidate(label10, dateTimePickerIssuanceDate);
                AddRequiredValidate(label11, dateTimePickerOutDate);
                AddRequiredValidate(label4, textBoxLegalPerson);
                AddRequiredValidate(label6, textBoxHeader);//
                AddRequiredValidate(label12, textBoxCorporateNature);//
                AddRequiredValidate(label13, textBoxProductScope);
                AddRequiredValidate(label5, textBoxProductAddress);
            }
        }
                
        private void BindInfo()
        {
            try
            {
                if (MedicineProductionLicense != null)
                {
                    //基本信息
                    textBoxName.Text = MedicineProductionLicense.Name;
                    textBoxLicenseCode.Text = MedicineProductionLicense.LicenseCode;
                    textBoxUnitName.Text = MedicineProductionLicense.UnitName;
                    textBoxRegAddress.Text = MedicineProductionLicense.RegAddress;
                    textBoxIssuanceOrg.Text = MedicineProductionLicense.IssuanceOrg;
                    dateTimePickerIssuanceDate.Value = MedicineProductionLicense.IssuanceDate;
                    dateTimePickerOutDate.Value = MedicineProductionLicense.OutDate;
                    //基本信息

                    //其他信息
                    textBoxLegalPerson.Text = MedicineProductionLicense.LegalPerson;
                    textBoxHeader.Text = MedicineProductionLicense.Header;
                    textBoxCorporateNature.Text = MedicineProductionLicense.CorporateNature;
                    textBoxProductScope.Text = MedicineProductionLicense.ProductScope;
                    textBoxCategoryCode.Text = MedicineProductionLicense.CategoryCode;
                    textBoxProductAddress.Text = MedicineProductionLicense.ProductAddress;
                    //其他信息
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
                if (MedicineProductionLicense != null)
                {
                    //基本信息
                    MedicineProductionLicense.Name = textBoxName.Text;
                    MedicineProductionLicense.LicenseCode = textBoxLicenseCode.Text;
                    MedicineProductionLicense.UnitName = textBoxUnitName.Text;
                    MedicineProductionLicense.RegAddress = textBoxRegAddress.Text;
                    MedicineProductionLicense.IssuanceOrg = textBoxIssuanceOrg.Text;
                    MedicineProductionLicense.IssuanceDate = dateTimePickerIssuanceDate.Value;
                    MedicineProductionLicense.OutDate = dateTimePickerOutDate.Value;
                    //基本信息

                    //其他信息
                    MedicineProductionLicense.LegalPerson = textBoxLegalPerson.Text;
                    MedicineProductionLicense.Header = textBoxHeader.Text;
                    MedicineProductionLicense.CorporateNature = textBoxCorporateNature.Text;
                    MedicineProductionLicense.ProductScope = textBoxProductScope.Text;
                    MedicineProductionLicense.CategoryCode = textBoxCategoryCode.Text;
                    MedicineProductionLicense.ProductAddress = textBoxProductAddress.Text;
                    //其他信息
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
                    if ((!this.MedicineProductionLicense.Id.Equals(Guid.Empty)) && this.MedicineProductionLicense.Id!=null)
                    {
                        result = PharmacyDatabaseService.SaveMedicineProductionLicense(out msg, this.MedicineProductionLicense);
                    }
                    else
                    {
                        this.MedicineProductionLicense.Id = Guid.NewGuid();
                        result = PharmacyDatabaseService.AddMedicineProductionLicense(out msg, this.MedicineProductionLicense);
                    }
                    if (result && string.IsNullOrWhiteSpace(msg))
                    {
                        //MessageBox.Show("证书保证成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text+"证书保证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("证书保存失败" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"证书保存失败" + ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清除该资质吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            clear = true;
            this.PharmacyDatabaseService.DeleteMedicineProductionLicense(out msg, guid);
            MedicineProductionLicense.Id = Guid.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.guid == Guid.Empty || this.guid == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1109, this.guid);
            if (!this.button1.Visible)
            {
                SetControls.SetControlReadonly(frm, true);
            }
            frm.ShowDialog();
        }
    }
}
