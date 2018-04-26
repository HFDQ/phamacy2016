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
    public partial class FormHealthLicense : BaseFunctionForm
    {
        public bool clear = false;
        string msg = string.Empty;

        public Guid guid { get; private set; }
        public HealthLicense HealthLicense { get; private set; }
        public string unitName;
        public string Address;
        public string Legalperson;

        public FormHealthLicense()
        {
            InitializeComponent();
        }
        public FormHealthLicense( Guid guid, string name, string address,string legalperson)
        {
            InitializeComponent();
            this.guid = guid;
            this.unitName = name;
            this.Address = address;
            this.Legalperson=legalperson;
        }

        private void LoadDataFromServer()
        {
            string message = string.Empty;
            HealthLicense = this.PharmacyDatabaseService.GetHealthLicense(out message, guid);
            if (HealthLicense == null)
            {
                HealthLicense = new HealthLicense();
                HealthLicense.Id = Guid.Empty;
                HealthLicense.OutDate = DateTime.Now.AddYears(1);
                HealthLicense.UnitName = unitName;
                HealthLicense.RegAddress = Address;
                HealthLicense.Header=Legalperson;
                checkValidStatus();
            }
        }

        public void InitRequiredControl()
        {
            if (!DesignMode)
            {
                AddRequiredValidate(label1, textBoxName);
                AddRequiredValidate(label5, textBoxLegalPerson);
                AddRequiredValidate(label2, textBoxUnitName);
                AddRequiredValidate(label8, textBoxNo);
                AddRequiredValidate(label3, textBoxRegAddress);
                AddRequiredValidate(label10, dateTimePickerOutDate);
                AddRequiredValidate(label9, textBoxIssuanceOrg);
                AddRequiredValidate(label4, textBoxLicenseContent);
            }
        }


        private void BindInfo()
        {
            try
            {
                if (HealthLicense != null)
                {
                    //基本信息
                    textBoxName.Text = HealthLicense.Name;
                    textBoxLicenseCode.Text = HealthLicense.LicenseCode;
                    textBoxUnitName.Text = HealthLicense.UnitName;
                    textBoxRegAddress.Text = HealthLicense.RegAddress;
                    textBoxIssuanceOrg.Text = HealthLicense.IssuanceOrg;
                    //dateTimePickerIssuanceDate.Value = DateTime.Now.Date;
                    dateTimePickerOutDate.Value = HealthLicense.OutDate;
                    textBoxLegalPerson.Text = HealthLicense.Header;
                    //基本信息
                    textBoxOrgType.Text = HealthLicense.HealthLicenseType;
                    textBoxNo.Text = HealthLicense.Code;
                    //dateTimePickerIssuanceDate.Value = HealthLicense.IssuanceDate;
                    textBoxLicenseContent.Text = HealthLicense.LicenseContent;//许可内容
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
                if (HealthLicense != null)
                {
                    //基本信息
                    HealthLicense.Name = textBoxName.Text;
                    HealthLicense.LicenseCode = textBoxLicenseCode.Text;
                    HealthLicense.UnitName = textBoxUnitName.Text;
                    HealthLicense.RegAddress = textBoxRegAddress.Text;
                    HealthLicense.IssuanceOrg = textBoxIssuanceOrg.Text;
                    HealthLicense.IssuanceDate = dateTimePickerIssuanceDate.Value;
                    HealthLicense.OutDate = dateTimePickerOutDate.Value;
                    //基本信息

                    //其他信息
                    HealthLicense.Header = textBoxLegalPerson.Text;
                    HealthLicense.LicenseContent = textBoxLicenseContent.Text;
                    HealthLicense.Code = textBoxNo.Text;
                    //其他信息
                    DataReady = true;
                }
            }
            catch (Exception ex)
            {
                DataReady = false;
                Log.Error(ex);
                //MessageBox.Show("从控件获取证书失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"从控件获取证书失败","错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    if (this.HealthLicense.Id!=null && (!this.HealthLicense.Id.Equals(Guid.Empty)))
                    {
                        result = PharmacyDatabaseService.SaveHealthLicense(out msg, this.HealthLicense);
                    }
                    else
                    {
                        this.HealthLicense.Id = Guid.NewGuid();
                        result = PharmacyDatabaseService.AddHealthLicense(out msg, this.HealthLicense);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清除该资质吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            clear = true;
            this.PharmacyDatabaseService.DeleteHealthLicense(out msg, guid);
            this.HealthLicense.Id = Guid.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.guid == Guid.Empty || this.guid == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1104, this.guid);
            if (!this.button1.Visible)
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
