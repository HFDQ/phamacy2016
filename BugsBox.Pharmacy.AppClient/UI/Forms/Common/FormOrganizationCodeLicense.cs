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
    public partial class FormOrganizationCodeLicense : BaseFunctionForm
    {
        public bool clear = false;
        string msg = string.Empty;

        public FormOrganizationCodeLicense(Guid guid, string name, string address)
        {
            InitializeComponent();
            this.guid = guid;
            this.unitName = name;
            this.Address = address;
        }
        public string unitName;
        public string Address;
        public Guid guid { get; private set; }
        public OrganizationCodeLicense OrganizationCodeLicense { get; private set; }
        private void LoadDataFromServer()
        {
            string message = string.Empty;
            OrganizationCodeLicense = PharmacyDatabaseService.GetOrganizationCodeLicense(out message, guid);
            if (OrganizationCodeLicense == null)
            {                
                OrganizationCodeLicense = new OrganizationCodeLicense();
                OrganizationCodeLicense.Id = Guid.Empty;
                OrganizationCodeLicense.StartDate = DateTime.Now;
                OrganizationCodeLicense.OutDate = DateTime.Now.AddYears(1);
                OrganizationCodeLicense.IssuanceDate = DateTime.Now;
                //dateTimePickerIssuanceDate.Value = DateTime.Now;
                dateTimePickerOutDate.Value = DateTime.Now.AddYears(1);
                OrganizationCodeLicense.UnitName = unitName;
                OrganizationCodeLicense.RegAddress = Address;
                OrganizationCodeLicense.YearCheckDate = DateTime.Now;    
            }
        }

        public void InitRequiredControl()
        {
            if (!DesignMode)
            {
                AddRequiredValidate(label1, textBoxName);
                AddRequiredValidate(label7, textBoxLicenseCode);
                AddRequiredValidate(label2, textBoxUnitName);
                AddRequiredValidate(label6, textBoxOrgType);
                AddRequiredValidate(label8, textBoxNo);
                AddRequiredValidate(label3, textBoxRegAddress);
                AddRequiredValidate(label10, dateTimePickerIssuanceDate);
                AddRequiredValidate(label11, dateTimePickerOutDate);
                AddRequiredValidate(label9, textBoxIssuanceOrg);
                AddRequiredValidate(label4, textBoxregistNo);
                //AddRequiredValidate(label12, checkBox1);
                AddRequiredValidate(label13, dateTimePickerYearCheck);
            }
        }

        
        private void BindInfo()
        {
            try
            {
                if (OrganizationCodeLicense != null)
                {
                    //基本信息
                    textBoxName.Text = OrganizationCodeLicense.Name;
                    textBoxLicenseCode.Text = OrganizationCodeLicense.LicenseCode;
                    textBoxUnitName.Text = OrganizationCodeLicense.UnitName;
                    textBoxRegAddress.Text = OrganizationCodeLicense.RegAddress;
                    textBoxIssuanceOrg.Text = OrganizationCodeLicense.IssuanceOrg;
                    dateTimePickerOutDate.Value = OrganizationCodeLicense.OutDate;
                    //基本信息

                    //其他信息
                    textBoxOrgType.Text = OrganizationCodeLicense.OrgnizationType;
                    textBoxNo.Text = OrganizationCodeLicense.LicenseNo;
                    dateTimePickerIssuanceDate.Value = OrganizationCodeLicense.IssuanceDate;
                    textBoxregistNo.Text = OrganizationCodeLicense.RegisterNo;
                    txtDocNumber.Text = OrganizationCodeLicense.DocNumber;
                    txtmemo.Text = OrganizationCodeLicense.memo;
                    checkBox1.Checked = OrganizationCodeLicense.isCheck;
                    dateTimePickerYearCheck.Value = OrganizationCodeLicense.YearCheckDate;

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
                if (OrganizationCodeLicense != null)
                {
                    //基本信息
                    OrganizationCodeLicense.Name = textBoxName.Text;
                    OrganizationCodeLicense.UnitName = textBoxUnitName.Text.Trim();
                    OrganizationCodeLicense.LicenseCode = textBoxLicenseCode.Text.Trim();
                    OrganizationCodeLicense.UnitName = textBoxUnitName.Text.Trim();
                    OrganizationCodeLicense.RegAddress = textBoxRegAddress.Text.Trim();
                    OrganizationCodeLicense.IssuanceOrg = textBoxIssuanceOrg.Text.Trim();
                    OrganizationCodeLicense.IssuanceDate = dateTimePickerIssuanceDate.Value;
                    OrganizationCodeLicense.OutDate = dateTimePickerOutDate.Value;
                    //基本信息

                    //其他信息
                    OrganizationCodeLicense.OrgnizationType = textBoxOrgType.Text.Trim();
                    OrganizationCodeLicense.LicenseNo = textBoxNo.Text.Trim();
                    OrganizationCodeLicense.RegisterNo = textBoxregistNo.Text.Trim();
                    OrganizationCodeLicense.isCheck = checkBox1.Checked ;
                    OrganizationCodeLicense.YearCheckDate = dateTimePickerYearCheck.Value;
                    OrganizationCodeLicense.DocNumber = txtDocNumber.Text.Trim();
                    OrganizationCodeLicense.memo = txtmemo.Text.Trim();
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
                    if ((!this.OrganizationCodeLicense.Id.Equals(Guid.Empty) )&& this.OrganizationCodeLicense.Id!=null)
                    {
                        result = PharmacyDatabaseService.SaveOrganizationCodeLicense(out msg, this.OrganizationCodeLicense);
                    }
                    else
                    {
                        this.OrganizationCodeLicense.Id = Guid.NewGuid();
                        result = PharmacyDatabaseService.AddOrganizationCodeLicense(out msg, this.OrganizationCodeLicense);
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

            }
            catch (Exception ex)
            {
                //MessageBox.Show("证书保存失败" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
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

      /*  private void buttonCommitFiles_Click(object sender, EventArgs e)
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
            this.PharmacyDatabaseService.DeleteOrganizationCodeLicense(out msg, guid);
            this.OrganizationCodeLicense.Id = Guid.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.guid == Guid.Empty || this.guid == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1111, this.guid);
            if (!this.button1.Visible)
            {
                SetControls.SetControlReadonly(frm, true);
            }
            frm.ShowDialog();
        }
    }
}
