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
    public partial class FormMedicineBusinessLicense  : BaseFunctionForm
    {
        public bool clear = false;
        string msg = string.Empty;
        bool Readonly = false;

        public FormMedicineBusinessLicense(Guid guid, string legalPerson, string qualityCharger, string name,string address, string wareHouseAddress, bool Readonly=false)
        {
            InitializeComponent();
            this.guid = guid;
            LegalPerson = legalPerson;
            QualityCharger = qualityCharger;
            Name = name;
            this.Address = address;
            this.Readonly = Readonly;
            this.WareHouseAddress = wareHouseAddress;
        }

        public FormMedicineBusinessLicense(Guid guid,bool Readonly=false)
        {
            InitializeComponent();
            this.guid = guid;
            this.Readonly = Readonly;
        }



        public string Name { get; private set; }
        public string LegalPerson{ get; private set; }
        public string QualityCharger { get; private set; }
        public Guid guid { get; private set; }
        public string Address;
        public string WareHouseAddress { get; private set; }

        public MedicineBusinessLicense MedicineBusinessLicense { get; private set; }
        private void LoadDataFromServer()
        {
            string message = string.Empty;
            MedicineBusinessLicense = PharmacyDatabaseService.GetMedicineBusinessLicense(out message, guid);
            if (MedicineBusinessLicense == null)
            {
                MedicineBusinessLicense = new MedicineBusinessLicense();
                MedicineBusinessLicense.Id = Guid.Empty;
                MedicineBusinessLicense.StartDate = DateTime.Now;
                MedicineBusinessLicense.OutDate = DateTime.Now.AddYears(1);
                MedicineBusinessLicense.IssuanceDate = DateTime.Now;
                MedicineBusinessLicense.LegalPerson = LegalPerson;
                MedicineBusinessLicense.Header = LegalPerson;
                MedicineBusinessLicense.QualityHeader = QualityCharger;
                MedicineBusinessLicense.UnitName = Name;
                MedicineBusinessLicense.RegAddress = Address;
                MedicineBusinessLicense.WarehouseAddress = WareHouseAddress;
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
                AddRequiredValidate(label2, textBoxQualityHeader);
                AddRequiredValidate(label14, textBoxWarehouseAddress);
            }
        }

        
        private void BindInfo()
        {
            try
            {
                if (MedicineBusinessLicense != null)
                {
                    //基本信息
                    textBoxName.Text = MedicineBusinessLicense.Name;
                    textBoxLicenseCode.Text = MedicineBusinessLicense.LicenseCode;
                    textBoxUnitName.Text = MedicineBusinessLicense.UnitName;
                    textBoxRegAddress.Text = MedicineBusinessLicense.RegAddress;
                    textBoxIssuanceOrg.Text = MedicineBusinessLicense.IssuanceOrg;
                    dateTimePickerIssuanceDate.Value = MedicineBusinessLicense.IssuanceDate;
                    dateTimePickerOutDate.Value = MedicineBusinessLicense.OutDate;
                    //基本信息

                    //其他信息
                    textBoxLegalPerson.Text = MedicineBusinessLicense.LegalPerson;
                    textBoxHeader.Text = MedicineBusinessLicense.Header;
                    textBoxQualityHeader.Text = MedicineBusinessLicense.QualityHeader;
                    textBoxBusinessScope.Text = MedicineBusinessLicense.BusinessScope;
                    textBoxWarehouseAddress.Text = MedicineBusinessLicense.WarehouseAddress;
                    textBoxLicenseContain.Text = MedicineBusinessLicense.LicenseContain;
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
                if (MedicineBusinessLicense != null)
                {
                    //基本信息
                    MedicineBusinessLicense.Name = textBoxName.Text;
                    MedicineBusinessLicense.LicenseCode = textBoxLicenseCode.Text;
                    MedicineBusinessLicense.UnitName = textBoxUnitName.Text;
                    MedicineBusinessLicense.RegAddress = textBoxRegAddress.Text;
                    MedicineBusinessLicense.IssuanceOrg = textBoxIssuanceOrg.Text;
                    MedicineBusinessLicense.IssuanceDate = dateTimePickerIssuanceDate.Value;
                    MedicineBusinessLicense.OutDate = dateTimePickerOutDate.Value;
                    //基本信息

                    //其他信息
                    MedicineBusinessLicense.LegalPerson = textBoxLegalPerson.Text;
                    MedicineBusinessLicense.Header = textBoxHeader.Text;
                    MedicineBusinessLicense.QualityHeader = textBoxQualityHeader.Text;
                    MedicineBusinessLicense.BusinessScope = textBoxBusinessScope.Text;
                    MedicineBusinessLicense.WarehouseAddress = textBoxWarehouseAddress.Text;
                    MedicineBusinessLicense.LicenseContain = textBoxLicenseContain.Text;
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
                    if (this.MedicineBusinessLicense.Id!=null && (!this.MedicineBusinessLicense.Id.Equals(Guid.Empty)))
                    {
                        result = PharmacyDatabaseService.SaveMedicineBusinessLicense(out msg, this.MedicineBusinessLicense);
                    }
                    else
                    {
                        this.MedicineBusinessLicense.Id = Guid.NewGuid();
                        result = PharmacyDatabaseService.AddMedicineBusinessLicense(out msg, this.MedicineBusinessLicense);
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
            this.PharmacyDatabaseService.DeleteMedicineBusinessLicense(out msg, guid);
            this.MedicineBusinessLicense.Id = Guid.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.guid == Guid.Empty || this.guid == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1108, this.guid);
            if (!this.button1.Visible)
            {
                SetControls.SetControlReadonly(frm, true);
            }
            frm.ShowDialog();
        }
    }

    public class SetControls
    {
        public static void SetControlReadonly(Control f,bool Readonly)
        {
            foreach (Control c in f.Controls)
            {
                if (c.GetType() == typeof(GroupBox))
                {
                    SetControlReadonly(c, Readonly);
                }
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).ReadOnly = Readonly;
                }
                if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)c).Enabled = !Readonly;
                }
                if (c.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)c).Enabled = !Readonly;
                }
                if (c.GetType() == typeof(RichTextBox))
                {
                    ((RichTextBox)c).ReadOnly = Readonly;
                }
                if (c.GetType() == typeof(Button))
                {
                    c.Visible = !Readonly;
                }
                if (c.GetType() == typeof(CheckedListBox))
                {
                    ((CheckedListBox)c).Enabled = !Readonly;
                }
                if (c.GetType() == typeof(DateTimePicker))
                {
                    ((DateTimePicker)c).Enabled = !Readonly;
                }
                if (c.GetType() == typeof(PictureBox))
                {
                    c.Enabled = true;
                }
                if (c.GetType() == typeof(ToolStrip))
                {
                    ((ToolStrip)c).Enabled = !Readonly;
                }
            }
            
        }
    }
}
