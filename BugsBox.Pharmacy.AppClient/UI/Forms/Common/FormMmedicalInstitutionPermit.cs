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
using BugsBox.Pharmacy.AppClient.Common.Commands;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class FormMmedicalInstitutionPermit : BaseFunctionForm
    {
        public bool clear = false;
        public Guid guid { get; private set; }
        public MmedicalInstitutionPermit MmedicalInstitutionPermit { get; private set; }
        public string unitName;
        public string Address;
        public string WareHouseAddress;
        public string Legalperson;
        string msg = string.Empty;

        private MmedicalInstitutionPermit entity;

        public FormMmedicalInstitutionPermit(MmedicalInstitutionPermit value, string name, string address, string legalperson, string wareHouseAddress)
        {
            InitializeComponent();
            if (value == null)
                value = new MmedicalInstitutionPermit();
            else
                this.entity = value;
            this.unitName = name;
            this.Address = address;
            this.Legalperson = legalperson;
            WareHouseAddress = wareHouseAddress;
        }

        private void LoadDataFromServer()
        {
            string message = string.Empty;
            try
            {
                MmedicalInstitutionPermit = PharmacyDatabaseService.GetMmedicalInstitutionPermit(entity.Id, out message).FirstOrDefault();
                if (MmedicalInstitutionPermit == null)
                {
                    MmedicalInstitutionPermit = new MmedicalInstitutionPermit();
                    MmedicalInstitutionPermit.Id = Guid.Empty;
                    MmedicalInstitutionPermit.IssuanceDate = DateTime.Now;
                    MmedicalInstitutionPermit.OutDate = DateTime.Now.AddYears(1);
                    MmedicalInstitutionPermit.StartDate = DateTime.Now;
                    this.dateTimePickerOutDate.Value = DateTime.Now.AddYears(1);
                    MmedicalInstitutionPermit.UnitName = unitName;
                    MmedicalInstitutionPermit.RegAddress = Address;
                    MmedicalInstitutionPermit.LegalPerson = Legalperson;
                    MmedicalInstitutionPermit.WarehouseAddress = WareHouseAddress;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("证书信息不存在或已被删除！", "警告！");
            }

        }

        public void InitRequiredControl()
        {
            if (!DesignMode)
            {
                AddRequiredValidate(label8, textBoxName);
                AddRequiredValidate(label6, textBoxUnitName);
                AddRequiredValidate(label14, textBoxLegalPerson);
                AddRequiredValidate(label7, textBoxLicenseCode);
                AddRequiredValidate(label2, textBoxRegAddress);//注册地址
                AddRequiredValidate(label3, textBoxRegAddress);//举办单位
                AddRequiredValidate(label11, txtOgnTpye);//资金
                AddRequiredValidate(label4, txtWareHouseAddress);
                AddRequiredValidate(label9, textBoxIssuanceOrg);
                AddRequiredValidate(label10, dateTimePickerIssuanceDate);
                AddRequiredValidate(label13, dateTimePickerOutDate);

                AddRequiredValidate(label1, txtUseMedicalScope);
            }
        }

        private void BindInfo()
        {
            try
            {
                if (MmedicalInstitutionPermit != null)
                {
                    //基本信息
                    textBoxName.Text = MmedicalInstitutionPermit.Name;
                    txtUseMedicalScope.Text = MmedicalInstitutionPermit.UseMedicalScope;
                    textBoxLegalPerson.Text = MmedicalInstitutionPermit.LegalPerson;
                    textBoxLicenseCode.Text = MmedicalInstitutionPermit.LicenseCode;
                    textBoxUnitName.Text = MmedicalInstitutionPermit.UnitName;
                    textBoxRegAddress.Text = MmedicalInstitutionPermit.RegAddress;
                    textBoxRegisterAddress.Text = MmedicalInstitutionPermit.RegisterAddress;//举办单位
                    txtOgnTpye.Text = MmedicalInstitutionPermit.OgnTpye;//开办资金
                    txtWareHouseAddress.Text = MmedicalInstitutionPermit.WarehouseAddress;
                    textBoxIssuanceOrg.Text = MmedicalInstitutionPermit.IssuanceOrg;
                    txtDocNumber.Text = MmedicalInstitutionPermit.DocNumber;

                    dateTimePickerOutDate.Value = MmedicalInstitutionPermit.OutDate;
                    dateTimePickerIssuanceDate.Value = MmedicalInstitutionPermit.IssuanceDate;
                    txtMemo.Text = MmedicalInstitutionPermit.memo;
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
                if (MmedicalInstitutionPermit != null)
                {
                    //基本信息
                    MmedicalInstitutionPermit.Name = textBoxName.Text.Trim();
                    MmedicalInstitutionPermit.UnitName = textBoxUnitName.Text.Trim();
                    MmedicalInstitutionPermit.LicenseCode = textBoxLicenseCode.Text.Trim();
                    MmedicalInstitutionPermit.LegalPerson = textBoxLegalPerson.Text.Trim();
                    MmedicalInstitutionPermit.RegAddress = textBoxRegAddress.Text.Trim();
                    MmedicalInstitutionPermit.RegisterAddress = textBoxRegisterAddress.Text.Trim();
                    MmedicalInstitutionPermit.OgnTpye = txtOgnTpye.Text.Trim();
                    MmedicalInstitutionPermit.IssuanceOrg = textBoxIssuanceOrg.Text;
                    MmedicalInstitutionPermit.IssuanceDate = dateTimePickerIssuanceDate.Value;
                    MmedicalInstitutionPermit.OutDate = dateTimePickerOutDate.Value;
                    MmedicalInstitutionPermit.UseMedicalScope = txtUseMedicalScope.Text.Trim();
                    MmedicalInstitutionPermit.WarehouseAddress = txtWareHouseAddress.Text.Trim();
                    MmedicalInstitutionPermit.DocNumber = txtDocNumber.Text.Trim();
                    MmedicalInstitutionPermit.memo = txtMemo.Text.Trim();

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
                    if (this.MmedicalInstitutionPermit.Id != null && (!this.MmedicalInstitutionPermit.Id.Equals(Guid.Empty)))
                    {
                        SaveMmedicalInstitutionPermitCmd cmd = new SaveMmedicalInstitutionPermitCmd();
                        cmd.MmedicalInstitutionPermit = this.MmedicalInstitutionPermit;
                        cmd.IsAdd = false;
                        result = (bool)cmd.Execute();
                    }
                    else
                    {
                        this.MmedicalInstitutionPermit.Id = Guid.NewGuid();
                        SaveMmedicalInstitutionPermitCmd cmd = new SaveMmedicalInstitutionPermitCmd();
                        cmd.MmedicalInstitutionPermit = this.MmedicalInstitutionPermit;
                        cmd.IsAdd = true;
                        result = (bool)cmd.Execute();
                    }
                    if (result && string.IsNullOrWhiteSpace(msg))
                    {
                        //MessageBox.Show("证书保证成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text + "证书保证成功", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.PharmacyDatabaseService.SaveMmedicalInstitutionPermit(this.MmedicalInstitutionPermit, out msg);
            this.MmedicalInstitutionPermit.Id = Guid.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.MmedicalInstitutionPermit == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1110, this.MmedicalInstitutionPermit.Id);
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
