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
    public partial class FormInstrumentsProductionLicense : BaseFunctionForm
    {
        public bool clear = false;
        string msg = string.Empty;
        public FormInstrumentsProductionLicense(Guid guid, string legalPerson, string address, string name)
        {
            InitializeComponent();
            this.guid = guid;
            this.LegalPerson = legalPerson;
            this.Name = name;
            this.Address = address;
        }

        public string LegalPerson { get; private set; }
        public string Name { get; private set; }
        public Guid guid { get; private set; }
        public string Address;

        public InstrumentsProductionLicense InstrumentsProductionLicense { get; private set; }
        private void LoadDataFromServer()
        {
            string message = string.Empty;
            InstrumentsProductionLicense = PharmacyDatabaseService.GetInstrumentsProductionLicense(out message, guid);
            if (InstrumentsProductionLicense == null)
            {                
                InstrumentsProductionLicense = new InstrumentsProductionLicense();
                InstrumentsProductionLicense.Id = Guid.Empty;
                InstrumentsProductionLicense.StartDate = DateTime.Now;
                InstrumentsProductionLicense.OutDate = DateTime.Now.AddYears(1);
                InstrumentsProductionLicense.IssuanceDate = DateTime.Now;
                InstrumentsProductionLicense.UnitName = Name;
                InstrumentsProductionLicense.LegalPerson = LegalPerson;
                InstrumentsProductionLicense.Header = LegalPerson;
                InstrumentsProductionLicense.RegAddress = Address;
                InstrumentsProductionLicense.ProductAddress = Address;
            }

        }

        public void InitRequiredControl()
        {
            if (!DesignMode)
            {
                AddRequiredValidate(label1, textBoxName);
                AddRequiredValidate(label7, textBoxLicenseCode);
                AddRequiredValidate(label2, textBoxUnitName);
                AddRequiredValidate(label3, textBoxRegAddress);
                AddRequiredValidate(label9, textBoxIssuanceOrg);
                AddRequiredValidate(label10, dateTimePickerIssuanceDate);
                AddRequiredValidate(label11, dateTimePickerOutDate);
                AddRequiredValidate(label4, textBoxLegalPerson);
                AddRequiredValidate(label6, textBoxHeader);
                AddRequiredValidate(label12, textBoxProductScope);
                AddRequiredValidate(label13, textBoxProductAddress);
            }
        }
                
        private void BindInfo()
        {
            try
            {
                if (InstrumentsProductionLicense != null)
                {
                    //基本信息
                    textBoxName.Text = InstrumentsProductionLicense.Name;
                    textBoxLicenseCode.Text = InstrumentsProductionLicense.LicenseCode;
                    textBoxUnitName.Text = InstrumentsProductionLicense.UnitName;
                    textBoxRegAddress.Text = InstrumentsProductionLicense.RegAddress;
                    textBoxIssuanceOrg.Text = InstrumentsProductionLicense.IssuanceOrg;
                    dateTimePickerIssuanceDate.Value = InstrumentsProductionLicense.IssuanceDate;
                    dateTimePickerOutDate.Value = InstrumentsProductionLicense.OutDate;
                    //基本信息

                    //其他信息
                    textBoxLegalPerson.Text = InstrumentsProductionLicense.LegalPerson;
                    textBoxHeader.Text = InstrumentsProductionLicense.Header;
                    textBoxProductAddress.Text = InstrumentsProductionLicense.ProductAddress;
                    textBoxProductScope.Text = InstrumentsProductionLicense.ProductScope; 
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
                if (InstrumentsProductionLicense != null)
                {
                    //基本信息
                    InstrumentsProductionLicense.Name = textBoxName.Text;
                    InstrumentsProductionLicense.LicenseCode = textBoxLicenseCode.Text;
                    InstrumentsProductionLicense.UnitName = textBoxUnitName.Text;
                    InstrumentsProductionLicense.RegAddress = textBoxRegAddress.Text;
                    InstrumentsProductionLicense.IssuanceOrg = textBoxIssuanceOrg.Text;
                    InstrumentsProductionLicense.IssuanceDate = dateTimePickerIssuanceDate.Value;
                    InstrumentsProductionLicense.OutDate = dateTimePickerOutDate.Value;
                    //基本信息

                    //其他信息
                    InstrumentsProductionLicense.LegalPerson = textBoxLegalPerson.Text;
                    InstrumentsProductionLicense.Header = textBoxHeader.Text;
                    InstrumentsProductionLicense.ProductAddress = textBoxProductAddress.Text;
                    InstrumentsProductionLicense.ProductScope = textBoxProductScope.Text; 
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
                    if (this.InstrumentsProductionLicense.Id!=null && (!this.InstrumentsProductionLicense.Id.Equals(Guid.Empty)))
                    {
                        result = PharmacyDatabaseService.SaveInstrumentsProductionLicense(out msg, this.InstrumentsProductionLicense);
                    }
                    else
                    {
                        this.InstrumentsProductionLicense.Id = Guid.NewGuid();
                        result = PharmacyDatabaseService.AddInstrumentsProductionLicense(out msg, this.InstrumentsProductionLicense);
                    }
                    if (result && string.IsNullOrWhiteSpace(msg))
                    {
                        //MessageBox.Show("证书保证成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text+"证书保证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("证书保存失败" + msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text+"证书保存失败" + msg,"错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                //else
                //{
                //    MessageBox.Show("从控件获取证书信息失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //}

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清除该资质吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            clear = true;
            this.PharmacyDatabaseService.DeleteInstrumentsProductionLicense(out msg, guid);
            this.InstrumentsProductionLicense.Id = Guid.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.guid == Guid.Empty || this.guid == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1106, this.guid);
            if (!this.button1.Visible)
            {
                SetControls.SetControlReadonly(frm, true);
            }
            frm.ShowDialog();
        }
    }
}
