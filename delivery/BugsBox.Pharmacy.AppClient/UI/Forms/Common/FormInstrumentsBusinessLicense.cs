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
    public partial class FormInstrumentsBusinessLicense : BaseFunctionForm
    {
        public bool clear = false;
        string msg = string.Empty;
        public FormInstrumentsBusinessLicense(Guid guid,string legalPerson,string qualityCharger,string name,string address, string wareHouseAddress)
        {
            InitializeComponent();
            this.guid = guid;
            LegalPerson = legalPerson;
            Address = address;
            Name = name;
            QualityCharger = qualityCharger;
            WareHouseAddress = wareHouseAddress;
        }

        public string Name { get; private set; }
        public string LegalPerson { get; private set; }
        public string QualityCharger { get; private set; }
        public Guid guid { get; private set; }
        public string Address { get; private set; }
        public string WareHouseAddress { get; private set; }

        public InstrumentsBusinessLicense InstrumentsBusinessLicense { get; private set; }
        private void LoadDataFromServer()
        {
            string message = string.Empty;
            InstrumentsBusinessLicense = PharmacyDatabaseService.GetInstrumentsBusinessLicense(out message, guid);
            if (InstrumentsBusinessLicense == null)
            {
                InstrumentsBusinessLicense = new InstrumentsBusinessLicense();
                InstrumentsBusinessLicense.Id = Guid.Empty;
                InstrumentsBusinessLicense.StartDate = DateTime.Now;
                InstrumentsBusinessLicense.OutDate = DateTime.Now.AddYears(1);
                InstrumentsBusinessLicense.IssuanceDate = DateTime.Now;
                InstrumentsBusinessLicense.LegalPerson = LegalPerson;
                InstrumentsBusinessLicense.QualityHeader = QualityCharger;
                InstrumentsBusinessLicense.UnitName = Name;
                InstrumentsBusinessLicense.RegAddress = Address;
                InstrumentsBusinessLicense.WarehouseAddress = WareHouseAddress;
                InstrumentsBusinessLicense.Header = LegalPerson;
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
                AddRequiredValidate(label12, textBoxQualityHeader);
                AddRequiredValidate(label13, textBoxBusinessScope);

                AddRequiredValidate(label14, textBoxWarehouseAddress);
            }
        }

        
        private void BindInfo()
        {
            try
            {
                if (InstrumentsBusinessLicense != null)
                {
                    //基本信息
                    textBoxName.Text = InstrumentsBusinessLicense.Name;
                    textBoxLicenseCode.Text = InstrumentsBusinessLicense.LicenseCode;
                    textBoxUnitName.Text = InstrumentsBusinessLicense.UnitName;
                    textBoxRegAddress.Text = InstrumentsBusinessLicense.RegAddress;
                    textBoxIssuanceOrg.Text = InstrumentsBusinessLicense.IssuanceOrg;
                    dateTimePickerIssuanceDate.Value = InstrumentsBusinessLicense.IssuanceDate;
                    dateTimePickerOutDate.Value = InstrumentsBusinessLicense.OutDate;
                    //基本信息

                    //其他信息
                    textBoxLegalPerson.Text = InstrumentsBusinessLicense.LegalPerson;
                    textBoxHeader.Text = InstrumentsBusinessLicense.Header;
                    textBoxQualityHeader.Text = InstrumentsBusinessLicense.QualityHeader;
                    textBoxBusinessScope.Text = InstrumentsBusinessLicense.BusinessScope;
                    textBoxWarehouseAddress.Text = InstrumentsBusinessLicense.WarehouseAddress;
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
                if (InstrumentsBusinessLicense != null)
                {
                    //基本信息
                    InstrumentsBusinessLicense.Name = textBoxName.Text;
                    InstrumentsBusinessLicense.LicenseCode = textBoxLicenseCode.Text;
                    InstrumentsBusinessLicense.UnitName = textBoxUnitName.Text;
                    InstrumentsBusinessLicense.RegAddress = textBoxRegAddress.Text;
                    InstrumentsBusinessLicense.IssuanceOrg = textBoxIssuanceOrg.Text;
                    InstrumentsBusinessLicense.IssuanceDate = dateTimePickerIssuanceDate.Value;
                    InstrumentsBusinessLicense.OutDate = dateTimePickerOutDate.Value;
                    //基本信息

                    //其他信息
                    InstrumentsBusinessLicense.LegalPerson = textBoxLegalPerson.Text;
                    InstrumentsBusinessLicense.Header = textBoxHeader.Text;
                    InstrumentsBusinessLicense.QualityHeader = textBoxQualityHeader.Text;
                    InstrumentsBusinessLicense.BusinessScope = textBoxBusinessScope.Text;
                    InstrumentsBusinessLicense.WarehouseAddress = textBoxWarehouseAddress.Text;
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
                    if (this.InstrumentsBusinessLicense.Id!=null && (!this.InstrumentsBusinessLicense.Id.Equals(Guid.Empty)))
                    {
                        result = PharmacyDatabaseService.SaveInstrumentsBusinessLicense(out msg, this.InstrumentsBusinessLicense);
                    }
                    else
                    {
                        this.InstrumentsBusinessLicense.Id = Guid.NewGuid();
                        result = PharmacyDatabaseService.AddInstrumentsBusinessLicense(out msg, this.InstrumentsBusinessLicense);
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
            this.PharmacyDatabaseService.DeleteInstrumentsBusinessLicense(out msg, guid);
            this.InstrumentsBusinessLicense.Id = Guid.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.guid == Guid.Empty || this.guid == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1105, this.guid);
            if (!this.button1.Visible)
            {
                SetControls.SetControlReadonly(frm, true);
            }
            frm.ShowDialog();
        }
    }
}
