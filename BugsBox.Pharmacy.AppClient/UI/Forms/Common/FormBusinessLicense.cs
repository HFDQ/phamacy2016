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
    public partial class FormBusinessLicense : BaseFunctionForm
    {
        public bool clear = false;
        string msg = string.Empty;
        public FormBusinessLicense(Guid guid, string name, string address)
        {
            InitializeComponent();
            this.guid = guid;
            this.Name = name;
            this.Address = address;
        }

        public string Name { get; private set; }

        public Guid guid { get; private set; }
        public BusinessLicense BusinessLicense { get; private set; }
        public string Address;

        private void LoadDataFromServer()
        {
            string message = string.Empty;
            BusinessLicense = PharmacyDatabaseService.GetBusinessLicense(out message, guid);
            if (BusinessLicense == null)
            {
                BusinessLicense = new BusinessLicense();
                BusinessLicense.Id = Guid.Empty;
                BusinessLicense.IssuanceDate = DateTime.Now;
                BusinessLicense.StartDate = DateTime.Now;
                BusinessLicense.OutDate = DateTime.Now.AddYears(1);
                BusinessLicense.EstablishmentDate = DateTime.Now;
                BusinessLicense.UnitName = Name;
                BusinessLicense.RegAddress = Address;
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
                AddRequiredValidate(label12, textBoxCorporateNature);
                AddRequiredValidate(label16, dateTimePickerEstablishmentDate);
                AddRequiredValidate(label17, dateTimePickerOutDate);

                AddRequiredValidate(label14, textBoxInspectionDate);
            }
        }

        private void BindInfo()
        {
            try
            {
                if (BusinessLicense != null)
                {
                    //基本信息
                    textBoxName.Text = BusinessLicense.Name;
                    textBoxLicenseCode.Text = BusinessLicense.LicenseCode;
                    textBoxUnitName.Text = BusinessLicense.UnitName;
                    textBoxRegAddress.Text = BusinessLicense.RegAddress;
                    textBoxIssuanceOrg.Text = BusinessLicense.IssuanceOrg;
                    dateTimePickerIssuanceDate.Value = BusinessLicense.IssuanceDate;
                    dateTimePickerOutDate.Value = BusinessLicense.OutDate;
                    dateTimePickerBeginning.Value = BusinessLicense.StartDate;
                    numericUpDownRegisteredCapital.Value = BusinessLicense.RegisteredCapital;
                    numericUpDownPaidinCapital.Value = BusinessLicense.PaidinCapital;
                    textBoxCorporateNature.Text = BusinessLicense.CorporateNature;
                    textBoxBusinessScope.Text = BusinessLicense.BusinessScope;
                    textBoxInspectionDate.Text = BusinessLicense.InspectionDate;
                    dateTimePickerEstablishmentDate.Value = BusinessLicense.EstablishmentDate;
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
                if (BusinessLicense != null)
                {
                    //基本信息
                    BusinessLicense.Name = textBoxName.Text;
                    BusinessLicense.LicenseCode = textBoxLicenseCode.Text;
                    BusinessLicense.UnitName = textBoxUnitName.Text;
                    BusinessLicense.RegAddress = textBoxRegAddress.Text;
                    BusinessLicense.IssuanceOrg = textBoxIssuanceOrg.Text;
                    BusinessLicense.IssuanceDate = dateTimePickerIssuanceDate.Value;
                    BusinessLicense.OutDate = dateTimePickerOutDate.Value;
                    BusinessLicense.StartDate = dateTimePickerBeginning.Value;
                    //基本信息

                    //其他信息
                    BusinessLicense.RegisteredCapital = (int)numericUpDownRegisteredCapital.Value;
                    BusinessLicense.PaidinCapital = (int)numericUpDownPaidinCapital.Value;
                    BusinessLicense.CorporateNature = textBoxCorporateNature.Text;
                    BusinessLicense.BusinessScope = textBoxBusinessScope.Text;
                    BusinessLicense.InspectionDate = textBoxInspectionDate.Text;
                    BusinessLicense.EstablishmentDate = dateTimePickerEstablishmentDate.Value;
                    //其他信息
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
         string str = "";
            foreach (Control c in this.groupBox4.Controls)
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
                    if ((!this.BusinessLicense.Id.Equals(Guid.Empty)) && this.BusinessLicense.Id != null)
                    {
                        result = PharmacyDatabaseService.SaveBusinessLicense(out msg, this.BusinessLicense);
                    }
                    else
                    {
                        this.BusinessLicense.Id = Guid.NewGuid();
                        result = PharmacyDatabaseService.AddBusinessLicense(out msg, this.BusinessLicense);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清除该资质吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            clear = true;
            this.PharmacyDatabaseService.DeleteBusinessLicense(out msg, guid);
            this.BusinessLicense.Id = Guid.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.guid == Guid.Empty || this.guid == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1113, this.guid);
            if (!this.button1.Visible)
            {
                SetControls.SetControlReadonly(frm, true);
            }
            frm.ShowDialog();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
