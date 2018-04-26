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
    public partial class FormLegalPersonLicense : BaseFunctionForm
    {
        public bool clear = false;
        string msg = string.Empty;


        public Guid guid { get; private set; }
        public LnstitutionLegalPersonLicense LnstitutionLegalPersonLicense { get; private set; }
        public string unitName;
        public string Address;
        public string Legalperson;

        public FormLegalPersonLicense(LnstitutionLegalPersonLicense value, string name, string address, string legalperson)
        {
            InitializeComponent();
            //this.LnstitutionLegalPersonLicense = value;
            if (value == null)
                value = new LnstitutionLegalPersonLicense();
            else
                this.LnstitutionLegalPersonLicense = value;
            this.unitName = name;
            this.Address = address;
            this.Legalperson = legalperson;
        }
        private void LoadDataFromServer()
        {
            string message = string.Empty;
            LnstitutionLegalPersonLicense = PharmacyDatabaseService.GetLnstitutionLegalPersonLicense(LnstitutionLegalPersonLicense, out message).FirstOrDefault();
            if (LnstitutionLegalPersonLicense == null)
            {

                LnstitutionLegalPersonLicense = new LnstitutionLegalPersonLicense();
                LnstitutionLegalPersonLicense.Id = Guid.Empty;
                LnstitutionLegalPersonLicense.IssuanceDate = DateTime.Now;
                LnstitutionLegalPersonLicense.OutDate = DateTime.Now.AddYears(1);
                LnstitutionLegalPersonLicense.StartDate = DateTime.Now;
                dateTimePickerOutDate.Value = DateTime.Now.AddYears(1);
                LnstitutionLegalPersonLicense.UnitName = unitName;
                LnstitutionLegalPersonLicense.RegAddress = Address;
                LnstitutionLegalPersonLicense.LegalPerson = Legalperson;

            }

        }

        public void InitRequiredControl()
        {
            if (!DesignMode)
            {
                AddRequiredValidate(label17, textBoxName);
                AddRequiredValidate(label7, textBoxLicenseCode);
                AddRequiredValidate(label6, textBoxUnitName);

                AddRequiredValidate(label14, textBoxLegalPerson);
                AddRequiredValidate(label3, textBoxCertificateName);
                AddRequiredValidate(label8, textBoxFundsSource);
                AddRequiredValidate(label11, textBoxInitiaFund);
                AddRequiredValidate(label4, textBoxRegAddress);
                AddRequiredValidate(label2, textBoxBussinessRange);

                AddRequiredValidate(label9, textBoxIssuanceOrg);


                AddRequiredValidate(label12, textBoxManageOrg);
                AddRequiredValidate(label10, dateTimePickerIssuanceDate);
                AddRequiredValidate(label13, dateTimePickerOutDate);
                AddRequiredValidate(label1, textBoxUseMedicalScope);
            }
        }


        private void BindInfo()
        {
            try
            {
                if (LnstitutionLegalPersonLicense != null)
                {
                    //基本信息
                    textBoxName.Text = LnstitutionLegalPersonLicense.Name;
                    textBoxLicenseCode.Text = LnstitutionLegalPersonLicense.LicenseCode;
                    textBoxUnitName.Text = LnstitutionLegalPersonLicense.UnitName;
                    textBoxLegalPerson.Text = LnstitutionLegalPersonLicense.LegalPerson;
                    textBoxCertificateName.Text = LnstitutionLegalPersonLicense.CertificateName;//举办单位
                    textBoxFundsSource.Text = LnstitutionLegalPersonLicense.FundsSource;//经费来源
                    textBoxInitiaFund.Text = LnstitutionLegalPersonLicense.InitiaFund;
                    textBoxRegAddress.Text = LnstitutionLegalPersonLicense.RegAddress;
                    textBoxBussinessRange.Text = LnstitutionLegalPersonLicense.BussinessRange;
                    textBoxIssuanceOrg.Text = LnstitutionLegalPersonLicense.IssuanceOrg;
                    textBoxDocNumber.Text = LnstitutionLegalPersonLicense.DocNumber;
                    textBoxManageOrg.Text = LnstitutionLegalPersonLicense.ManageOrg;
                    textBoxUseMedicalScope.Text = LnstitutionLegalPersonLicense.UseMedicalScope;

                    textBoxMemo.Text = LnstitutionLegalPersonLicense.memo;

                    dateTimePickerIssuanceDate.Value = LnstitutionLegalPersonLicense.IssuanceDate;
                    dateTimePickerOutDate.Value = LnstitutionLegalPersonLicense.OutDate;
                    //基本信息


                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //MessageBox.Show("设置证书信息到控件失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text + "设置证书信息到控件失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (LnstitutionLegalPersonLicense != null)
                {
                    //基本信息
                    LnstitutionLegalPersonLicense.Name = textBoxName.Text;
                    LnstitutionLegalPersonLicense.LicenseCode = textBoxLicenseCode.Text;
                    LnstitutionLegalPersonLicense.UnitName = textBoxUnitName.Text;
                    LnstitutionLegalPersonLicense.LegalPerson = textBoxLegalPerson.Text;
                    LnstitutionLegalPersonLicense.CertificateName = textBoxCertificateName.Text;//举办单位
                    LnstitutionLegalPersonLicense.FundsSource = textBoxFundsSource.Text;//经费来源
                    LnstitutionLegalPersonLicense.InitiaFund = textBoxInitiaFund.Text;
                    LnstitutionLegalPersonLicense.RegAddress = textBoxRegAddress.Text;
                    LnstitutionLegalPersonLicense.BussinessRange = textBoxBussinessRange.Text;
                    LnstitutionLegalPersonLicense.IssuanceOrg = textBoxIssuanceOrg.Text;
                    LnstitutionLegalPersonLicense.DocNumber = textBoxDocNumber.Text;
                    LnstitutionLegalPersonLicense.ManageOrg = textBoxManageOrg.Text;
                    LnstitutionLegalPersonLicense.UseMedicalScope = textBoxUseMedicalScope.Text;

                    LnstitutionLegalPersonLicense.memo = textBoxMemo.Text;

                    LnstitutionLegalPersonLicense.IssuanceDate = dateTimePickerIssuanceDate.Value;
                    LnstitutionLegalPersonLicense.OutDate = dateTimePickerOutDate.Value;

                    DataReady = true;
                }
            }
            catch (Exception ex)
            {
                DataReady = false;
                Log.Error(ex);
                //MessageBox.Show("从控件获取证书失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text + "从控件获取证书失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    if (this.LnstitutionLegalPersonLicense.Id != null && (!this.LnstitutionLegalPersonLicense.Id.Equals(Guid.Empty)))
                    {
                        result = PharmacyDatabaseService.OpLnstitutionLegalPersonLicense(this.LnstitutionLegalPersonLicense, 1, out msg);
                    }
                    else
                    {
                        this.LnstitutionLegalPersonLicense.Id = Guid.NewGuid();
                        result = PharmacyDatabaseService.OpLnstitutionLegalPersonLicense(this.LnstitutionLegalPersonLicense, 0, out msg);
                    }
                    if (result && string.IsNullOrWhiteSpace(msg))
                    {
                        //MessageBox.Show("证书保证成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text + "证书保证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("证书保存失败" + msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text + "证书保存失败" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("证书保存失败" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text + "证书保存失败" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            Models.LnstitutionLegalPersonLicense llp = new Models.LnstitutionLegalPersonLicense();
            llp.Id = guid;
            Models.LnstitutionLegalPersonLicense lp = this.PharmacyDatabaseService.GetLnstitutionLegalPersonLicense(llp, out msg).FirstOrDefault();
            this.PharmacyDatabaseService.OpLnstitutionLegalPersonLicense(lp, 2, out msg);
            this.LnstitutionLegalPersonLicense.Id = Guid.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.LnstitutionLegalPersonLicense == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1107, this.LnstitutionLegalPersonLicense.Id);
            if (!this.button1.Visible)
            {
                SetControls.SetControlReadonly(frm, true);
            }
            frm.ShowDialog();
        }

        private void dateTimePickerIssuanceDate_ValueChanged_1(object sender, EventArgs e)
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
    }
}
