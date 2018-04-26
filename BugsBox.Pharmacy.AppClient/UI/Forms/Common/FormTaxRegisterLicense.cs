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
    public partial class FormTaxRegisterLicense : BaseFunctionForm
    {
        public bool clear = false;
        string msg = string.Empty;
        public Guid guid { get; private set; }
        public TaxRegisterLicense TaxRegisterLicense { get; private set; }
        public string unitName;
        public string Address;
        public string Legalperson;

        public FormTaxRegisterLicense(Guid guid, string name, string address, string legalperson)
        {
            InitializeComponent();
            this.guid = guid;
            this.unitName = name;
            this.Address = address;
            this.Legalperson = legalperson;
        }

        private void LoadDataFromServer()
        {
            string message = string.Empty;
            TaxRegisterLicense = this.PharmacyDatabaseService.GetTaxRegisterLicense(out message, guid);
            if (TaxRegisterLicense == null)
            {
                TaxRegisterLicense = new TaxRegisterLicense();
                TaxRegisterLicense.Id = Guid.Empty;
                TaxRegisterLicense.IssuanceDate = DateTime.Now;
                TaxRegisterLicense.OutDate = DateTime.Now.AddYears(1);
                TaxRegisterLicense.StartDate = DateTime.Now;
                //dateTimePickerIssuanceDate.Value = DateTime.Now;
                dateTimePickerOutDate.Value = DateTime.Now.AddYears(1);
                TaxRegisterLicense.UnitName = unitName;
                TaxRegisterLicense.RegAddress = Address;
                TaxRegisterLicense.LegalPerson = Legalperson;
            }
        }

        public void InitRequiredControl()
        {
            if (!DesignMode)
            {
                AddRequiredValidate(label1, textBoxName);
                AddRequiredValidate(label7, textBoxLicenseCode);
                AddRequiredValidate(label2, textBoxUnitName);
                AddRequiredValidate(label5, textBoxtaxpayerNumber);
                AddRequiredValidate(label14, textBoxLegalPerson);
                AddRequiredValidate(label4, textBoxBusinessScope);
                AddRequiredValidate(label3, textBoxRegAddress);
                AddRequiredValidate(label9, textBoxIssuanceOrg);
                AddRequiredValidate(label6, dateTimePickerOutDate);
                AddRequiredValidate(label10, dateTimePickerIssuanceDate);
            }
        }

        private void BindInfo()
        {
            try
            {
                if (TaxRegisterLicense != null)
                {
                    //基本信息
                    textBoxName.Text = TaxRegisterLicense.Name;
                    textBoxLicenseCode.Text = TaxRegisterLicense.LicenseCode;
                    textBoxUnitName.Text = TaxRegisterLicense.UnitName;
                    textBoxtaxpayerNumber.Text = TaxRegisterLicense.taxpayerNumber;
                    textBoxLegalPerson.Text = TaxRegisterLicense.LegalPerson;
                    textBoxDocNumber.Text = TaxRegisterLicense.DocNumber;
                    textBoxBusinessScope.Text = TaxRegisterLicense.BusinessScope;
                    textBoxRegAddress.Text = TaxRegisterLicense.RegAddress;
                    textBoxIssuanceOrg.Text = TaxRegisterLicense.IssuanceOrg;
                    dateTimePickerIssuanceDate.Value = TaxRegisterLicense.IssuanceDate;
                    dateTimePickerOutDate.Value = TaxRegisterLicense.OutDate;

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
                if (TaxRegisterLicense != null)
                {
                    TaxRegisterLicense.Name = textBoxName.Text.Trim();
                    TaxRegisterLicense.LicenseCode = textBoxLicenseCode.Text.Trim();
                    TaxRegisterLicense.UnitName = textBoxUnitName.Text.Trim();
                    TaxRegisterLicense.taxpayerNumber = textBoxtaxpayerNumber.Text.Trim();
                    TaxRegisterLicense.LegalPerson = textBoxLegalPerson.Text.Trim();
                    TaxRegisterLicense.DocNumber = textBoxDocNumber.Text.Trim();
                    TaxRegisterLicense.BusinessScope=textBoxBusinessScope.Text;
                    TaxRegisterLicense.RegAddress =textBoxRegAddress.Text;
                    TaxRegisterLicense.IssuanceOrg=textBoxIssuanceOrg.Text;
                    TaxRegisterLicense.IssuanceDate=dateTimePickerIssuanceDate.Value;
                    TaxRegisterLicense.OutDate =dateTimePickerOutDate.Value;
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
            string str = "";
            foreach (Control c in this.groupBox2.Controls)
            {
                if (c is CheckBox)
                    if (((CheckBox)c).Checked)
                        str += ((CheckBox)c).Text + "，";

            }
            this.textBoxBusinessScope.Text += str;
            try
            {
                CellectInfo();
                if (DataReady)
                {
                    string msg = string.Empty;
                    bool result = false;
                    if (this.TaxRegisterLicense.Id!=null && (!this.TaxRegisterLicense.Id.Equals(Guid.Empty)))
                    {
                        result = PharmacyDatabaseService.SaveTaxRegisterLicense(out msg, this.TaxRegisterLicense);
                    }
                    else
                    {
                        this.TaxRegisterLicense.Id = Guid.NewGuid();
                        result = PharmacyDatabaseService.AddTaxRegisterLicense(out msg, this.TaxRegisterLicense);
                    }
                    if (result && string.IsNullOrWhiteSpace(msg))
                    {
                        //MessageBox.Show("证书保证成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text+"证书保证成功","成功" , MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /*private void buttonCommitFiles_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清除该资质吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            clear = true;
            this.PharmacyDatabaseService.DeleteTaxRegisterLicense(out msg, guid);
            this.TaxRegisterLicense.Id = Guid.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.guid == Guid.Empty || this.guid == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1112, this.guid);
            if (!this.button1.Visible)
            {
                SetControls.SetControlReadonly(frm, true);
            }
            frm.ShowDialog();
        }

    }
}
