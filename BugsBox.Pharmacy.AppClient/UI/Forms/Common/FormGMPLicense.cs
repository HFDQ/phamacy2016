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
    public partial class FormGMPLicense : BaseFunctionForm
    {
        public bool clear = false;
        string msg = string.Empty;
        public GMPLicense GMPLicense = null;
        ToolTip tt = new ToolTip();

        List<TextBox> ListValidator = new List<TextBox>();
        public FormGMPLicense(Guid guid, string name, string address, bool Readonly = false)
        {
            InitializeComponent();
            this.AddTextBoxToValidator(this);

            this.GMPLicense = this.PharmacyDatabaseService.GetGMPLicense(out msg, guid);

            if (this.GMPLicense == null)
            {
                this.GMPLicense = new GMPLicense
                {
                    CertificationScope = "无",
                    Name = "GMP证书",
                    RegAddress = address,
                    StartDate = DateTime.Now.Date,
                    OutDate = DateTime.Now.AddYears(5).Date,
                    IssuanceDate = DateTime.Now.Date,
                    UnitName = name,
                    Id=Guid.Empty
                };
            }
            this.gMPLicenseBindingSource.Add(this.GMPLicense);
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
            this.Validate();
            if (!this.ValidateRequiredTextBox()) return;

            try
            {
                bool result = false;
                if (this.GMPLicense.Id != null && (!this.GMPLicense.Id.Equals(Guid.Empty)))
                {
                    this.GMPLicense.OutDate = this.dateTimePickerOutDate.Value.Date;
                    this.GMPLicense.IssuanceDate = this.dateTimePickerIssuanceDate.Value.Date;
                    result = PharmacyDatabaseService.SaveGMPLicense(out msg, this.GMPLicense);
                }
                else
                {
                    this.GMPLicense.Id = Guid.NewGuid();
                    this.GMPLicense.OutDate = this.dateTimePickerOutDate.Value.Date;
                    this.GMPLicense.IssuanceDate = this.dateTimePickerIssuanceDate.Value.Date;
                    result = PharmacyDatabaseService.AddGMPLicense(out msg, this.GMPLicense);
                }

                if (result && string.IsNullOrWhiteSpace(msg))
                {
                    MessageBox.Show(this.Text + "证书保证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this.Text + "证书保存失败" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Text + "证书保存失败" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// 将界面所有文本框加入验证列表
        /// </summary>
        /// <param name="control"></param>
        private void AddTextBoxToValidator(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    this.ListValidator.Add((TextBox)c);
                }
                if (c.GetType() == typeof(GroupBox))
                {
                    AddTextBoxToValidator(c);
                }
            }
        }

        private bool ValidateRequiredTextBox()
        {
            foreach (TextBox t in this.ListValidator.OrderBy(r => r.TabIndex).ToList())
            {
                if (string.IsNullOrEmpty(t.Text.Trim()))
                {
                    tt.Dispose();
                    tt = new ToolTip
                    {
                        ToolTipTitle = "提示!",
                        AutoPopDelay = 5000,
                        InitialDelay = 1000,
                        ReshowDelay = 500,
                        ShowAlways = true,
                        ToolTipIcon = ToolTipIcon.Warning,
                        IsBalloon = true
                    };
                    tt.SetToolTip(t, "NoText!");
                    this.tt.Show("请填写信息", t, 5000);
                    t.Focus();
                    return false;
                }
            }
            return true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清除该资质吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            
            this.PharmacyDatabaseService.DeleteGMPLicense(out msg, this.GMPLicense.Id);
            this.GMPLicense.Id=Guid.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.GMPLicense.Id == Guid.Empty || this.GMPLicense.Id == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1102, this.GMPLicense.Id);
            if (!this.button1.Visible)
            {
                SetControls.SetControlReadonly(frm, true);
            }
            frm.ShowDialog();
        }
    }
}
