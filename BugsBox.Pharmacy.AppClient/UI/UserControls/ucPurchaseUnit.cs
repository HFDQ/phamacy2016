using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.PS;
using CustomValidatorsLibrary;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.AppClient.UI.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.UserControls
{
    public partial class ucPurchaseUnit : BaseFunctionUserControl
    {
        public List<BusinessType> _ListbussNessType = new List<BusinessType>();
        public List<UnitType> _ListUnitType = new List<UnitType>();
        private PurchaseUnit _purchaseUnit = null;
        private List<PurchaseUnit> _ListpurchaseUnit = null;

        public Dictionary<Guid, string> dicbussnessType = new Dictionary<Guid, string>();
        private Dictionary<Guid, string> dicDistrict = new Dictionary<Guid, string>();
        public Guid FlowTypeID { get; set; }
        public OperateType operationType;
        public List<OutDateDetail> _outDateList = new List<OutDateDetail>();
        System.IFormatProvider format = new System.Globalization.CultureInfo("zh-CN", true);

        private string strQualityAgreement = null;
        private string[] strQ = null;
        private string strAttorneyAattorney = null;
        private string[] strA = null;
        ContextMenuStrip cms = new ContextMenuStrip();
        DataGridView CurrentDGV = null;
        string msg = string.Empty;
        public PurchaseUnit PurchaseUnit
        {
            get { return _purchaseUnit; }
            set { _purchaseUnit = value; }
        }
        private bool _isEditable = true;

        public ucPurchaseUnit()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                InitCombox();
                InitRequiredControl();
            }

            this.dataGridView1.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.newDataGridviewer1.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            cms.Items.Add("新增记录", null, AddNewRow);
            cms.Items.Add("删除记录", null, DelNewRow);
        }

        public ucPurchaseUnit(PurchaseUnit purchaseUnit, bool isEdit)
            : this()
        {
            _purchaseUnit = purchaseUnit;
            InitEditControl(_purchaseUnit);
            this._isEditable = isEdit;
            SetControlIsEdit(isEdit);
        }

        public ucPurchaseUnit(Guid flowID)
            : this()
        {
            string msg = string.Empty;
            if (!DesignMode)
            {
                _purchaseUnit = PharmacyDatabaseService.GetPurchaseUnitByFlowID(out msg, flowID);
            }
            InitEditControl(_purchaseUnit);
            this._isEditable = false;
            SetControlIsEdit(false);
            //this.textBoxPurchaseDelegater.Text = "CGWTS...";
        }

        #region 委托书与质量保证书右键新增与删除行
        private void AddNewRow(object sender, EventArgs args)
        {
            DataTable c = this.CurrentDGV.DataSource as DataTable;
            if (c == null)
            {
                this.CurrentDGV.Rows.Add();
            }
            else
            {
                DataRow dr = c.NewRow();
                c.Rows.Add(dr);
                this.CurrentDGV.DataSource = c;
            }
            this.CurrentDGV.FirstDisplayedScrollingRowIndex = this.CurrentDGV.Rows.Count - 1;
            this.CurrentDGV.CurrentCell = this.CurrentDGV.Rows[this.CurrentDGV.Rows.Count - 1].Cells[0];
        }

        private void DelNewRow(object sender, EventArgs args)
        {
            DataTable c = this.CurrentDGV.DataSource as DataTable;
            if (c == null)
            {
                this.CurrentDGV.Rows.Remove(this.CurrentDGV.CurrentRow);
            }
            else
            {
                int index = this.CurrentDGV.CurrentRow.Index;
                c.Rows.RemoveAt(index);
                this.CurrentDGV.DataSource = c;
            }
        }
        #endregion

        /// <summary>
        /// 初始化Required控件
        /// </summary>
        public void InitRequiredControl()
        {
            if (!DesignMode)
            {
                AddRequiredValidate(label30, cmbUnitType);
                AddRequiredValidate(label35, txtCode);
                AddRequiredValidate(label36, txtName);
                AddRequiredValidate(label12, txtLegalPerson);
                AddRequiredValidate(label23, cmbDistrict);
                AddRequiredValidate(label4, cmbApprovelFlow);
                AddRequiredValidate(label1, txtReceiveAddress);
                AddRequiredValidate(label7, txtBoxCompanyAddress);
                AddRequiredValidate(label31, txtPinyinCode);
                AddRequiredValidate(label5, txtBoxQualityCharger);
            }
        }

        /// <summary>
        /// 设置控件的可用属性
        /// </summary>
        /// <param name="isEdit"></param>
        public void SetControlIsEdit(bool isEdit)
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control ct in control.Controls)
                    {
                        if (ct is TextBox)
                            ((TextBox)ct).ReadOnly = !isEdit;
                        else if (ct is RichTextBox)
                            ((RichTextBox)ct).ReadOnly = !isEdit;
                        else if (ct is ComboBox)
                        {
                            ((ComboBox)ct).Enabled = isEdit;
                        }
                        else if (ct is DateTimePicker)
                            ((DateTimePicker)ct).Enabled = isEdit;
                        else if (ct is CheckBox)
                            ((CheckBox)ct).Enabled = isEdit;
                    }
                }
            }
        }

        #region InitPurchaseUnit
        /// <summary>
        /// InitPurchaseUnit
        /// </summary>
        /// <param name="purchaseUnit"></param>
        /// <returns></returns>
        public PurchaseUnit InitPurchaseUnit(PurchaseUnit purchaseUnit)
        {
            string msg = String.Empty;
            DateTime mindate = DateTime.Now.AddYears(10);
            _outDateList.Clear();
            if (!ValidateControls(out msg))
            {
                MessageBox.Show(msg);
                return null;
            }

            PurchaseUnit sUnit = purchaseUnit;
            if (cmbApprovelFlow.SelectedValue == null)
                FlowTypeID = Guid.Empty;
            else
                FlowTypeID = (Guid)cmbApprovelFlow.SelectedValue;
            if (sUnit == null)
            {
                sUnit = new PurchaseUnit();
                sUnit.Id = Guid.NewGuid();
                sUnit.CreateTime = DateTime.Now;
                sUnit.CreateUserId = AppClientContext.CurrentUser.Id;
                sUnit.FlowID = Guid.NewGuid();
            }

            if (this.cmbUnitType.SelectedValue != null)
                sUnit.UnitTypeId = Guid.Parse(this.cmbUnitType.SelectedValue.ToString());
            else
                sUnit.UnitTypeId = Guid.Empty;
            sUnit.Code = txtCode.Text.Trim();
            sUnit.ContactName = txtContactName.Text.Trim();
            sUnit.ContactTel = txtContactTel.Text.Trim();
            sUnit.Description = rtbDesc.Text.Trim();
            sUnit.Email = txtEmail.Text.Trim();
            sUnit.Enabled = ckEnable.Checked;

            sUnit.Fax = txtFax.Text.Trim();
            sUnit.LegalPerson = txtLegalPerson.Text.Trim();
            sUnit.Name = txtName.Text.Trim();
            sUnit.PinyinCode = txtPinyinCode.Text;
            sUnit.WebAddress = txtWebAddress.Text.Trim();
            sUnit.ReceiveAddress = txtReceiveAddress.Text.Trim();
            sUnit.UpdateTime = DateTime.Now;
            sUnit.UpdateUserId = AppClientContext.CurrentUser.Id;
            sUnit.DistrictId = Guid.Parse(cmbDistrict.SelectedValue.ToString());
            sUnit.DetailedAddress = txtBoxCompanyAddress.Text.Trim();
            sUnit.DocNumber = txtDocNumber.Text.Trim();
            sUnit.QualityCharger = txtBoxQualityCharger.Text.Trim();
            //法人委托书数据
            if (this.newDataGridviewer1.Rows.Count > 0)
            {
                List<DateTime> OutDateAttorneyAattorney = new List<DateTime>();
                string strOutDate = DateTime.Now.Date.ToString("yyyyMMdd");
                DateTime OutDate = DateTime.ParseExact(strOutDate, "yyyyMMdd", format);
                try
                {
                    strAttorneyAattorney = string.Empty;
                    foreach (DataGridViewRow item in this.newDataGridviewer1.Rows)
                    {

                        for (int i = 0; i < this.newDataGridviewer1.Columns.Count; i++)
                        {
                            if (item.Cells[i].Value != null)
                            {
                                strAttorneyAattorney += item.Cells[i].Value.ToString();
                                if (i != this.newDataGridviewer1.Columns.Count - 1)
                                    strAttorneyAattorney += ",";
                            }
                            else
                            {
                                MessageBox.Show("法人委托书有未填项，请检查!");
                                strAttorneyAattorney = null;
                                return null;
                            }
                        }
                        strAttorneyAattorney = strAttorneyAattorney + "||";

                        {
                            OutDate = DateTime.ParseExact(item.Cells["colEndTime"].Value.ToString(), "yyyyMMdd", format);
                            OutDateAttorneyAattorney.Add(OutDate);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return null;
                }
                sUnit.BusinessLicenseeOutDate = OutDateAttorneyAattorney.Max();//BusinessLicenseeOutDate表示法人委托书过期日

                //if (OutDateAttorneyAattorney.Max() < DateTime.Now.Date)
                //{
                //    MessageBox.Show("法人委托书日期填写过期，请检查！");
                //    return null;
                //}
                if (strAttorneyAattorney == "")
                {
                    MessageBox.Show("请输入法人委托书信息！");
                    return null;
                }
                else
                {
                    sUnit.AttorneyAattorneyDetail = strAttorneyAattorney;
                }
            }
            else
                sUnit.BusinessLicenseeOutDate = DateTime.ParseExact(DateTime.Now.Date.ToString(), "yyyyMMdd", format);

            //质量协议书数据
            if (this.dataGridView1.Rows.Count > 0)
            {
                List<DateTime> OutDateQualityAgreement = new List<DateTime>();
                string strOutDate = DateTime.Now.Date.ToString("yyyyMMdd");
                DateTime OutDate = DateTime.ParseExact(strOutDate, "yyyyMMdd", format);
                strQualityAgreement = string.Empty;
                foreach (DataGridViewRow item in this.dataGridView1.Rows)
                {
                    for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                    {
                        if (item.Cells[i].Value != null)
                        {
                            strQualityAgreement += item.Cells[i].Value.ToString();
                            if (i != this.dataGridView1.Columns.Count - 1)
                                strQualityAgreement += ",";
                        }
                        else
                        {
                            MessageBox.Show("质量协议书有未填项，请检查!");
                            strQualityAgreement = null;
                            return null;

                        }
                    }
                    strQualityAgreement = strQualityAgreement + "||";

                    {
                        bool isDate = DateTime.TryParseExact(item.Cells["colOutDate"].Value.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out OutDate);

                        OutDateQualityAgreement.Add(OutDate);
                    }
                }
                //if (OutDateQualityAgreement.Max()<DateTime.Now.Date)
                //{
                //    MessageBox.Show("质量委托书填写过期！");
                //    return null;
                //}

                sUnit.QualityAgreementOutdate = OutDateQualityAgreement.Max();
                sUnit.QualityAgreemenStartdate = DateTime.Now;
                sUnit.QualityAgreementFile = Guid.Empty;
                if (strQualityAgreement == "")
                {
                    MessageBox.Show("请输入质量协议书信息！");
                    return null;
                }
                else
                {
                    sUnit.QualityAgreementDetail = strQualityAgreement;
                }
            }
            else
                sUnit.QualityAgreementOutdate = DateTime.Now.Date;

            _outDateList.Add(new OutDateDetail() { Content = "法人委托书", outDate = sUnit.BusinessLicenseeOutDate });
            _outDateList.Add(new OutDateDetail() { Content = "质量协议书", outDate = sUnit.QualityAgreementOutdate });

            string message;

            #region 药品经营范围证书
            sUnit.GSPLicenseId = this.buttonGSPLicense.Tag == null ? Guid.Empty : (Guid)this.buttonGSPLicense.Tag;
            if (sUnit.GSPLicenseId != Guid.Empty)
            {
                try
                {
                    sUnit.GSPLicenseOutDate = PharmacyDatabaseService.GetGSPLicense(out message, sUnit.GSPLicenseId)
                        .OutDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("药品经营许可证或药品经营许可范围读取失败，请稍候提交或者打开该资质，并点击清空按钮!"); return null;
                }
                _outDateList.Add(new OutDateDetail() { Content = "药品经营范围/药品许可范围", outDate = sUnit.GSPLicenseOutDate });
            }
            else
            {
                sUnit.GSPLicenseOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region GMP证书
            sUnit.GMPLicenseId = this.buttonGMPLicense.Tag == null ? Guid.Empty : (Guid)this.buttonGMPLicense.Tag;
            if (sUnit.GMPLicenseId != Guid.Empty)
            {
                try
                {
                    sUnit.GMPLicenseOutDate = PharmacyDatabaseService.GetGMPLicense(out message, sUnit.GMPLicenseId)
                        .OutDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("GMP证书读取失败，请稍候提交或者打开该资质，并点击清空按钮!"); return null;
                }
                _outDateList.Add(new OutDateDetail() { Content = "GMP证书", outDate = sUnit.GMPLicenseOutDate });
            }
            else
            {
                sUnit.GMPLicenseOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region 营业执照
            sUnit.BusinessLicenseId = this.buttonBusinessLicense.Tag == null ? Guid.Empty : (Guid)this.buttonBusinessLicense.Tag;
            if (sUnit.BusinessLicenseId != Guid.Empty)
            {
                try
                {
                    sUnit.BusinessLicenseeOutDate = PharmacyDatabaseService.GetBusinessLicense(out message, sUnit.BusinessLicenseId)
                        .OutDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("营业执照读取失败，请稍候提交或者打开该资质，并点击清空按钮!"); return null;
                }
                _outDateList.Add(new OutDateDetail() { Content = "营业执照", outDate = sUnit.BusinessLicenseeOutDate });
            }
            else
            {
                sUnit.BusinessLicenseeOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region 药品生产许可证
            sUnit.MedicineProductionLicenseId = this.buttonMedicineProductionLicense.Tag == null ? Guid.Empty : (Guid)this.buttonMedicineProductionLicense.Tag;
            if (sUnit.MedicineProductionLicenseId != Guid.Empty)
            {
                try
                {
                    sUnit.MedicineProductionLicenseOutDate = PharmacyDatabaseService.GetMedicineProductionLicense(out message, sUnit.MedicineProductionLicenseId)
                        .OutDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("药品生产许可证读取失败，请稍候提交或者打开该资质，并点击清空按钮!"); return null;
                }
                _outDateList.Add(new OutDateDetail() { Content = "药品生产许可证", outDate = sUnit.MedicineProductionLicenseOutDate });
            }
            else
            {
                sUnit.MedicineProductionLicenseOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region GSP证书
            sUnit.MedicineBusinessLicenseId = this.buttonMedicineBusinessLicense.Tag == null
                || (Guid)this.buttonMedicineBusinessLicense.Tag == Guid.Empty ? Guid.Empty : (Guid)this.buttonMedicineBusinessLicense.Tag;
            if (sUnit.MedicineBusinessLicenseId != Guid.Empty)
            {
                try
                {
                    sUnit.MedicineBusinessLicenseOutDate = PharmacyDatabaseService.GetMedicineBusinessLicense(out message, sUnit.MedicineBusinessLicenseId)
                        .OutDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("GSP证书读取失败，请稍候提交或者打开该资质，并点击清空按钮!"); return null;
                }
                _outDateList.Add(new OutDateDetail() { Content = "GSP证书", outDate = sUnit.MedicineBusinessLicenseOutDate });
            }
            else
            {
                sUnit.MedicineBusinessLicenseOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region 器械生产许可证
            sUnit.InstrumentsProductionLicenseId = this.buttonInstrumentsProductionLicense.Tag == null
                || (Guid)this.buttonInstrumentsProductionLicense.Tag == Guid.Empty ? Guid.Empty : (Guid)this.buttonInstrumentsProductionLicense.Tag;
            if (sUnit.InstrumentsProductionLicenseId != Guid.Empty)
            {
                try
                {
                    sUnit.InstrumentsProductionLicenseOutDate = PharmacyDatabaseService.GetInstrumentsProductionLicense(out message, sUnit.InstrumentsProductionLicenseId)
                        .OutDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("器械生产许可证读取失败，请稍候提交或者打开该资质，并点击清空按钮!"); return null;
                }
                _outDateList.Add(new OutDateDetail() { Content = "器械生产许可证", outDate = sUnit.InstrumentsProductionLicenseOutDate });
            }
            else
            {
                sUnit.InstrumentsProductionLicenseOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region 器械经营许可证
            sUnit.InstrumentsBusinessLicenseId = this.buttonInstrumentsBusinessLicense.Tag == null ? Guid.Empty : (Guid)this.buttonInstrumentsBusinessLicense.Tag;
            if (sUnit.InstrumentsBusinessLicenseId != Guid.Empty)
            {
                try
                {
                    sUnit.InstrumentsBusinessLicenseOutDate = PharmacyDatabaseService.GetInstrumentsBusinessLicense(out message, sUnit.InstrumentsBusinessLicenseId)
                        .OutDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("器械经营许可证读取失败，请稍候提交或者打开该资质，并点击清空按钮！"); return null;
                }
                _outDateList.Add(new OutDateDetail() { Content = "器械经营许可证", outDate = sUnit.InstrumentsBusinessLicenseOutDate });
            }
            else
            {
                sUnit.InstrumentsBusinessLicenseOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region 税务登记证
            sUnit.TaxRegisterLicenseId = this.buttontxtTaxRegistrationCode.Tag == null ? Guid.Empty : (Guid)this.buttontxtTaxRegistrationCode.Tag;
            if (sUnit.TaxRegisterLicenseId != Guid.Empty)
            {
                try
                {
                    sUnit.TaxRegisterLicenseOutDate = PharmacyDatabaseService.GetTaxRegisterLicense(out message, sUnit.TaxRegisterLicenseId)
                        .OutDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("税务登记证读取失败，请稍候提交或者打开该资质，并点击清空按钮!"); return null;
                }
                _outDateList.Add(new OutDateDetail() { Content = "税务登记证", outDate = sUnit.TaxRegisterLicenseOutDate });
            }
            else
            {
                sUnit.TaxRegisterLicenseOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region 组织机构代码证
            sUnit.OrganizationCodeLicenseId = this.buttonOrgnize.Tag == null ? Guid.Empty : (Guid)this.buttonOrgnize.Tag;
            if (sUnit.OrganizationCodeLicenseId != Guid.Empty)
            {
                try
                {
                    sUnit.OrganizationCodeLicenseOutDate = PharmacyDatabaseService.GetOrganizationCodeLicense(out message, sUnit.OrganizationCodeLicenseId)
                        .OutDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("组织机构代码证读取失败，请稍候提交或者打开该资质，并点击清空按钮！"); return null;
                }
                _outDateList.Add(new OutDateDetail() { Content = "组织机构代码证", outDate = sUnit.OrganizationCodeLicenseOutDate });
            }
            else
            {
                sUnit.OrganizationCodeLicenseOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region 卫生许可证
            sUnit.HealthLicenseId = this.buttonhygiene.Tag == null ? Guid.Empty : (Guid)this.buttonhygiene.Tag;
            if (sUnit.HealthLicenseId != Guid.Empty)
            {
                try
                {
                    sUnit.HealthLicenseOutDate = PharmacyDatabaseService.GetHealthLicense(out message, sUnit.HealthLicenseId)
                        .OutDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("卫生许可证读取失败，请稍候提交或者打开该资质，并点击清空按钮！"); return null;
                }
                _outDateList.Add(new OutDateDetail() { Content = "卫生许可证", outDate = sUnit.HealthLicenseOutDate });
            }
            else
            {
                sUnit.HealthLicenseOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region 事业单位法人证书
            sUnit.LnstitutionLegalPersonLicenseId = this.btnLegalPerson.Tag == null ? Guid.Empty : (Guid)this.btnLegalPerson.Tag;
            if (sUnit.LnstitutionLegalPersonLicenseId != Guid.Empty)
            {
                try
                {
                    LnstitutionLegalPersonLicense legalLicense = new LnstitutionLegalPersonLicense();
                    legalLicense.Id = sUnit.LnstitutionLegalPersonLicenseId;
                    sUnit.LnstitutionLegalPersonLicenseOutDate = PharmacyDatabaseService.GetLnstitutionLegalPersonLicense(legalLicense, out message).First()
                        .OutDate;
                    _outDateList.Add(new OutDateDetail() { Content = "事业单位法人证书", outDate = sUnit.LnstitutionLegalPersonLicenseOutDate });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("事业单位法人证书读取失败，请稍候提交或者打开该资质，并点击清空按钮！"); return null;
                }
            }
            else
            {
                sUnit.LnstitutionLegalPersonLicenseOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region 医疗机构执业许可证
            sUnit.MmedicalInstitutionPermitId = this.buttonMedInst.Tag == null ? Guid.Empty : (Guid)this.buttonMedInst.Tag;
            if (sUnit.MmedicalInstitutionPermitId != Guid.Empty)
            {
                try
                {

                    sUnit.MmedicalInstitutionPermitOutDate = PharmacyDatabaseService.GetMmedicalInstitutionPermit(sUnit.MmedicalInstitutionPermitId, out message).First().OutDate;

                    _outDateList.Add(new OutDateDetail() { Content = "医疗执业许可证书", outDate = sUnit.MmedicalInstitutionPermitOutDate });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("医疗执业许可证书读取失败，请稍候提交或者打开该资质，并点击清空按钮！"); return null;
                }
            }
            else
            {
                sUnit.MmedicalInstitutionPermitOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            #region 食品流通许可证
            sUnit.FoodCirculateLicenseId = this.buttonfood.Tag == null ? Guid.Empty : (Guid)this.buttonfood.Tag;
            if (sUnit.FoodCirculateLicenseId != Guid.Empty)
            {
                try
                {
                    sUnit.FoodCirculateLicenseOutDate = PharmacyDatabaseService.GetFoodCirculateLicense(out message, sUnit.FoodCirculateLicenseId)
                        .OutDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("食品流通许可证读取失败，请稍候提交或者打开该资质，并点击清空按钮！"); return null;
                }
                _outDateList.Add(new OutDateDetail() { Content = "食品流通许可证", outDate = sUnit.FoodCirculateLicenseOutDate });
            }
            else
            {
                sUnit.FoodCirculateLicenseOutDate = DateTime.MaxValue.AddYears(-1);
            }
            #endregion

            //sUnit.GSPLicenseOutDate;
            if (_outDateList.Count > 0)
            {
                DateTime dtime = _outDateList.Min(r => r.outDate);
                sUnit.OutDate = dtime;
                OutDateDetail od = _outDateList.Where(r => r.outDate < DateTime.Now).FirstOrDefault();
                if (od != null)
                {
                    var v = MessageBox.Show(od.Content + "过期,请检查,需要继续保存吗?", "提示", MessageBoxButtons.YesNo);
                    if (v == DialogResult.No)
                    {
                        return null;
                    }
                }

                if (sUnit.OutDate > DateTime.Now)
                    sUnit.IsOutDate = false;
            }
            else
                sUnit.OutDate = DateTime.Now.Date;

            return sUnit;

        }
        #endregion

        /// <summary>
        /// 根据PurchaseUnit 对象初始化控件
        /// </summary>
        /// <param name="purchaseUnit"></param>
        public void InitEditControl(PurchaseUnit purchaseUnit)
        {
            if (purchaseUnit != null)
            {
                _purchaseUnit = purchaseUnit;
                IntiApproveFlowType(purchaseUnit);


                strQ = null;
                strA = null;

                DataTable dtQ = new DataTable();
                dtQ.Columns.Add("c1");
                dtQ.Columns.Add("c2");
                dtQ.Columns.Add("c3");
                dtQ.Columns.Add("c4");
                dtQ.Columns.Add("c5");

                DataTable dtA = new DataTable();
                dtA.Columns.Add("c1");
                dtA.Columns.Add("c2");
                dtA.Columns.Add("c3");
                dtA.Columns.Add("c4");
                dtA.Columns.Add("c5");
                dtA.Columns.Add("c6");
                dtA.Columns.Add("c7");
                dtA.Columns.Add("c8");

                DataTable dtB = new DataTable();
                dtB.Columns.Add("c1");
                dtB.Columns.Add("c2");
                dtB.Columns.Add("c3");
                dtB.Columns.Add("c4");

                string[] strQSub = null;

                strQ = purchaseUnit.QualityAgreementDetail.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var subStr in strQ)
                {


                    strQSub = subStr.Split(new string[] { "," }, StringSplitOptions.None);
                    if (strQSub.Length > 5)
                    {
                        var s = strQSub.Skip(1).Take(strQSub.Length - 4);
                        strQSub[1] = string.Join(",", s);
                        strQSub[2] = strQSub[strQSub.Length - 3];
                        strQSub[3] = strQSub[strQSub.Length - 2];
                        strQSub[4] = strQSub[strQSub.Length - 1];
                    }

                    DataRow dr = dtQ.NewRow();
                    for (int i = 0; i < dtQ.Columns.Count; i++)
                        dr[i] = strQSub[i];
                    dtQ.Rows.Add(dr);
                }
                this.dataGridView1.Columns["colEnterpriseName"].DataPropertyName = "c1";
                this.dataGridView1.Columns["colContext"].DataPropertyName = "c2";
                this.dataGridView1.Columns["colAwardTime"].DataPropertyName = "c3";
                this.dataGridView1.Columns["colOutDate"].DataPropertyName = "c4";
                this.dataGridView1.Columns["colDocNo"].DataPropertyName = "c5";
                this.dataGridView1.DataSource = dtQ;

                string[] strASub = null;
                strA = purchaseUnit.AttorneyAattorneyDetail.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var subStr in strA)
                {
                    strASub = subStr.Split(new string[] { "," }, StringSplitOptions.None);

                    if (strASub.Length > 8)
                    {
                        var s = strASub.Skip(1).Take(strASub.Length - 7);
                        strASub[1] = string.Join(",", s);
                        strASub[2] = strASub[strASub.Length - 6];
                        strASub[3] = strASub[strASub.Length - 5];
                        strASub[4] = strASub[strASub.Length - 4];
                        strASub[5] = strASub[strASub.Length - 3];
                        strASub[6] = strASub[strASub.Length - 2];
                        strASub[7] = strASub[strASub.Length - 1];
                    }

                    DataRow dr = dtA.NewRow();
                    for (int i = 0; i < dtA.Columns.Count; i++)
                        dr[i] = strASub[i];
                    dtA.Rows.Add(dr);
                }
                this.newDataGridviewer1.Columns["dataGridViewTextBoxColumn2"].DataPropertyName = "c1";
                this.newDataGridviewer1.Columns["dataGridViewTextBoxColumn3"].DataPropertyName = "c2";
                this.newDataGridviewer1.Columns["colLegalPerson"].DataPropertyName = "c3";
                this.newDataGridviewer1.Columns["colAuthorizedPerson"].DataPropertyName = "c4";
                this.newDataGridviewer1.Columns["colAuthorizedPersonPaper"].DataPropertyName = "c5";
                this.newDataGridviewer1.Columns["colAuthStartTime"].DataPropertyName = "c6";
                this.newDataGridviewer1.Columns["colEndTime"].DataPropertyName = "c7";
                this.newDataGridviewer1.Columns["dataGridViewTextBoxColumn7"].DataPropertyName = "c8";
                this.newDataGridviewer1.DataSource = dtA;

                cmbUnitType.SelectedValue = purchaseUnit.UnitTypeId;
                this.bindUnitType();

                txtCode.Text = purchaseUnit.Code;
                txtContactName.Text = purchaseUnit.ContactName;
                txtContactTel.Text = purchaseUnit.ContactTel;
                rtbDesc.Text = purchaseUnit.Description;
                txtEmail.Text = purchaseUnit.Email;
                ckEnable.Checked = purchaseUnit.Enabled;
                txtFax.Text = purchaseUnit.Fax;
                txtBoxCompanyAddress.Text = purchaseUnit.DetailedAddress;
                txtDocNumber.Text = purchaseUnit.DocNumber;

                txtLegalPerson.Text = purchaseUnit.LegalPerson;
                txtName.Text = purchaseUnit.Name;
                txtPinyinCode.Text = purchaseUnit.PinyinCode;
                txtWebAddress.Text = purchaseUnit.WebAddress;
                txtReceiveAddress.Text = purchaseUnit.ReceiveAddress;
                txtBoxQualityCharger.Text = purchaseUnit.QualityCharger;

                var u = this.PharmacyDatabaseService.GetApproveFlowsByFlowID(out msg, purchaseUnit.FlowID);
                if (u != null)
                {
                    FlowTypeID = u.ApprovalFlowTypeId;
                    cmbApprovelFlow.SelectedValue = FlowTypeID;
                    if (cmbApprovelFlow.SelectedIndex == -1) cmbApprovelFlow.SelectedIndex = 0;
                }
                cmbApprovelFlow.Enabled = purchaseUnit.ApprovalStatus != ApprovalStatus.Waitting;

                cmbDistrict.SelectedValue = purchaseUnit.DistrictId;

                this.buttonGSPLicense.Tag = purchaseUnit.GSPLicenseId;
                this.buttonGMPLicense.Tag = purchaseUnit.GMPLicenseId;
                this.buttonBusinessLicense.Tag = purchaseUnit.BusinessLicenseId;
                this.buttonMedicineProductionLicense.Tag = purchaseUnit.MedicineProductionLicenseId;
                this.buttonMedicineBusinessLicense.Tag = purchaseUnit.MedicineBusinessLicenseId;
                this.buttonInstrumentsProductionLicense.Tag = purchaseUnit.InstrumentsProductionLicenseId;
                this.buttonInstrumentsBusinessLicense.Tag = purchaseUnit.InstrumentsBusinessLicenseId;
                this.btnLegalPerson.Tag = purchaseUnit.LnstitutionLegalPersonLicenseId;
                this.buttontxtTaxRegistrationCode.Tag = purchaseUnit.TaxRegisterLicenseId;
                this.buttonOrgnize.Tag = purchaseUnit.OrganizationCodeLicenseId;
                this.buttonMedInst.Tag = purchaseUnit.MmedicalInstitutionPermitId;
                this.buttonhygiene.Tag = purchaseUnit.HealthLicenseId;
                this.buttonfood.Tag = purchaseUnit.FoodCirculateLicenseId;

                foreach (Control c in this.groupBox7.Controls)
                {
                    if ((Guid)c.Tag != Guid.Empty)
                        c.BackColor = Color.LightBlue;
                    else
                        c.BackColor = Color.LightGray;
                }
            }
            else
            {
                IntiApproveFlowType(purchaseUnit);
            }

        }

        /// <summary>
        /// 绑定combox
        /// </summary>
        private void InitCombox()
        {
            try
            {
                #region clear combox 
                this.cmbDistrict.Items.Clear();
                //this.cmpApproveStatus.Items.Clear();
                #endregion

                #region bind district
                string msg = string.Empty;
                //Provinces[] Provinces = PharmacyDatabaseService.AllProvinces(out msg);
                District[] districts = PharmacyDatabaseService.AllDistricts(out msg);
                this.cmbDistrict.DataSource = districts;
                this.cmbDistrict.DisplayMember = "Name";
                this.cmbDistrict.ValueMember = "Id";
                foreach (District district in districts)
                {
                    dicDistrict.Add(district.Id, district.Name);
                }

                #endregion
                _ListUnitType = PharmacyDatabaseService.AllUnitTypes(out msg).ToList();
                this.cmbUnitType.DataSource = _ListUnitType.OrderBy(d => d.Code).ToList();
                this.cmbUnitType.DisplayMember = "Name";
                this.cmbUnitType.ValueMember = "Id";


                #region bind ApproveStatus
                //this.cmpApproveStatus.Items.Add(new ListItem(ApprovalStatus.Waitting.ToString(), "待审"));
                //this.cmpApproveStatus.Items.Add(new ListItem(ApprovalStatus.Approvaled.ToString(), "已审"));
                //this.cmpApproveStatus.Items.Add(new ListItem(BugsBox.Pharmacy.AppClient.PS.ApprovalStatus.Reject.ToString(), "审查未通过"));
                //this.cmpApproveStatus.Items.Add(new ListItem(BugsBox.Pharmacy.AppClient.PS.ApprovalStatus.Abate.ToString(), "失效"));
                //this.cmpApproveStatus.Items.Add(new ListItem(BugsBox.Pharmacy.AppClient.PS.ApprovalStatus.Canceled.ToString(), "取消"));
                #endregion
                //string msg = string.Empty;

                //#region bind UnitType
                //GetUnitType();
                ////this.cmbUnitType.DataSource = _ListUnitType;
                ////this.cmbUnitType.DisplayMember = "Name";
                ////this.cmbUnitType.ValueMember = "Id";
                //#endregion

            }
            catch (Exception ex)
            {
                //MessageBox.Show("初始化数据失败", "系统错误", MessageBoxButtons.OK);
                //Log.Error(ex);
            }


        }

        /// <summary>
        /// IntiApproveFlowType
        /// </summary>
        private void IntiApproveFlowType(PurchaseUnit purchaseUnit)
        {
            string msg = string.Empty;
            List<int> flowTypeList = new List<int>();
            if (purchaseUnit == null)
            {
                flowTypeList.Add((int)ApprovalType.PurchaseUnitApproval);
            }
            else
            {
                flowTypeList.Add((int)ApprovalType.PurchaseUnitEditApproval);
            }

            List<ApprovalFlowType> list = PharmacyDatabaseService.GetApprovalFlowTypeByTypeList(out msg, flowTypeList.ToArray()).Where(r => r.Deleted == false).ToList();
            this.cmbApprovelFlow.DataSource = list;
            this.cmbApprovelFlow.DisplayMember = "Name";
            this.cmbApprovelFlow.ValueMember = "Id";
            if (cmbApprovelFlow.Items.Count > 0)
            {
                this.cmbApprovelFlow.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// 获取经营方式
        /// </summary>
        private void GetBusinessType()
        {
            string msg = string.Empty;
            _ListbussNessType = PharmacyDatabaseService.AllBusinessTypes(out msg).ToList();
            foreach (BusinessType bt in _ListbussNessType)
            {
                dicbussnessType.Add(bt.Id, bt.Name);
            }

        }

        /// <summary>
        /// 清空所有控件值
        /// </summary>
        public void ClearControl()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control ct in control.Controls)
                    {
                        if (ct is TextBox)
                        {
                            ((TextBox)ct).Text = string.Empty;
                            //if (ct.Name == "textBoxPurchaseDelegater")
                            //textBoxPurchaseDelegater.Text = "CGWTS...";
                        }
                        else if (ct is RichTextBox)
                            ((RichTextBox)ct).Text = string.Empty;
                        else if (ct is ComboBox)
                        {
                            //if (ct.Name == "cmbBusinessType" || ct.Name == "cmbDistrict" || ct.Name == "cmbApprovelFlow")
                            //    ((ComboBox)ct).SelectedValue = Guid.Empty;
                            //else
                            //    ((ComboBox)ct).SelectedValue = null;
                            ((ComboBox)ct).SelectedValue = Guid.Empty;
                        }
                        else if (ct is DateTimePicker)
                        {
                            ((DateTimePicker)ct).Value = DateTime.Now;
                            if (ct.Name == "dtpQualityAgreementOutDate")
                                ((DateTimePicker)ct).Value = DateTime.Now.AddYears(1);
                        }
                        //else if (ct is CheckBox)
                        //    ((CheckBox)ct).Checked = false;
                        //MessageBox.Show("hello");
                    }
                }
            }
        }

        /// <summary>
        /// Add By Shen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFile_Click(object sender, EventArgs e)
        {

        }

        private void buttonLicense_Click(object sender, EventArgs e)
        {
            Button btnLicense = sender as Button;
            Guid LicenseId = Guid.Empty;
            if (btnLicense.Tag != null)
            {
                LicenseId = (Guid)btnLicense.Tag;
            }

            string legalPerson = txtLegalPerson.Text.Trim();
            string name = txtName.Text.Trim();
            string address = txtBoxCompanyAddress.Text.Trim();
            string qualityCharger = txtBoxQualityCharger.Text.Trim();
            string wareHouseAddress = txtReceiveAddress.Text.Trim();

            switch (btnLicense.Text)
            {
                case "药品经营许可证":
                    FormGSPLicense FormGSPLicense = new FormGSPLicense(LicenseId, legalPerson, qualityCharger, name, address, wareHouseAddress);
                    SetControls.SetControlReadonly(FormGSPLicense, !this._isEditable);
                    if (FormGSPLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormGSPLicense.GSPLicense.Id;
                    }
                    break;
                case "品种许可范围":
                    FormGSPLicense frm = new FormGSPLicense(LicenseId, legalPerson, qualityCharger, name, address, wareHouseAddress, false);
                    SetControls.SetControlReadonly(frm, !this._isEditable);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = frm.GSPLicense.Id;
                    }
                    break;
                case "GMP证书":
                    FormGMPLicense FormGMPLicense = new FormGMPLicense(LicenseId, name, address);
                    SetControls.SetControlReadonly(FormGMPLicense, !this._isEditable);
                    if (FormGMPLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormGMPLicense.GMPLicense.Id;
                    }
                    break;
                case "营业执照":
                    FormBusinessLicense FormBusinessLicense = new FormBusinessLicense(LicenseId, name, address);
                    SetControls.SetControlReadonly(FormBusinessLicense, !this._isEditable);
                    if (FormBusinessLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormBusinessLicense.BusinessLicense.Id;
                    }
                    break;
                case "药品生产许可证":
                    FormMedicineProductionLicense FormMedicineProductionLicense = new FormMedicineProductionLicense(LicenseId, legalPerson, name, address);
                    SetControls.SetControlReadonly(FormMedicineProductionLicense, !this._isEditable);
                    if (FormMedicineProductionLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormMedicineProductionLicense.MedicineProductionLicense.Id;
                    }
                    break;
                case "GSP证书":
                    FormMedicineBusinessLicense FormMedicineBusinessLicense = new FormMedicineBusinessLicense(LicenseId, legalPerson, qualityCharger, name, address, wareHouseAddress);
                    SetControls.SetControlReadonly(FormMedicineBusinessLicense, !this._isEditable);
                    if (FormMedicineBusinessLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormMedicineBusinessLicense.MedicineBusinessLicense.Id;
                    }
                    break;
                case "器械生产许可证":
                    FormInstrumentsProductionLicense FormInstrumentsProductionLicense = new FormInstrumentsProductionLicense(LicenseId, legalPerson, address, name);
                    SetControls.SetControlReadonly(FormInstrumentsProductionLicense, !this._isEditable);
                    if (FormInstrumentsProductionLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormInstrumentsProductionLicense.InstrumentsProductionLicense.Id;
                    }
                    break;
                case "器械经营许可证":
                    FormInstrumentsBusinessLicense FormInstrumentsBusinessLicense = new FormInstrumentsBusinessLicense(LicenseId, legalPerson, qualityCharger, name, address, wareHouseAddress);
                    SetControls.SetControlReadonly(FormInstrumentsBusinessLicense, !this._isEditable);
                    if (FormInstrumentsBusinessLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormInstrumentsBusinessLicense.InstrumentsBusinessLicense.Id;
                    }
                    break;
                case "组织机构代码证":
                    FormOrganizationCodeLicense FormOrganizationCodeLicense = new FormOrganizationCodeLicense(LicenseId, name, address);
                    SetControls.SetControlReadonly(FormOrganizationCodeLicense, !this._isEditable);
                    if (FormOrganizationCodeLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormOrganizationCodeLicense.OrganizationCodeLicense.Id;
                    }
                    break;
                case "卫生许可证":
                    FormHealthLicense FormHealthLicense = new FormHealthLicense(LicenseId, name, address, legalPerson);
                    SetControls.SetControlReadonly(FormHealthLicense, !this._isEditable);
                    if (FormHealthLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormHealthLicense.HealthLicense.Id;
                    }
                    break;
                case "事业单位法人证书":
                    LnstitutionLegalPersonLicense LegalPersonLicense = new LnstitutionLegalPersonLicense();
                    LegalPersonLicense.Id = LicenseId;
                    FormLegalPersonLicense FormLegalPersonLicense = new FormLegalPersonLicense(LegalPersonLicense, name, address, legalPerson);
                    SetControls.SetControlReadonly(FormLegalPersonLicense, !this._isEditable);
                    if (FormLegalPersonLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormLegalPersonLicense.LnstitutionLegalPersonLicense.Id;
                    }
                    break;
                case "医疗机构执业许可证":
                    MmedicalInstitutionPermit InstitutionPermit = new MmedicalInstitutionPermit();
                    InstitutionPermit.Id = LicenseId;
                    FormMmedicalInstitutionPermit FormMmedicalInstitutionPermit = new FormMmedicalInstitutionPermit(InstitutionPermit, name, address, legalPerson, wareHouseAddress);
                    SetControls.SetControlReadonly(FormMmedicalInstitutionPermit, !this._isEditable);
                    if (FormMmedicalInstitutionPermit.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormMmedicalInstitutionPermit.MmedicalInstitutionPermit.Id;
                    }
                    break;
                case "税务登记证":
                    TaxRegisterLicense TaxRegisterLicense = new TaxRegisterLicense();
                    TaxRegisterLicense.Id = LicenseId;
                    FormTaxRegisterLicense FormTaxRegisterLicense = new FormTaxRegisterLicense(LicenseId, name, address, legalPerson);
                    SetControls.SetControlReadonly(FormTaxRegisterLicense, !this._isEditable);
                    if (FormTaxRegisterLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormTaxRegisterLicense.TaxRegisterLicense.Id;
                    }
                    break;
                case "食品流通许可证":
                    FoodCirculateLicense FoodCirculateLicense = new FoodCirculateLicense();
                    FoodCirculateLicense.Id = LicenseId;
                    FormFoodCirculateLicense FormFoodCirculateLicense = new FormFoodCirculateLicense(LicenseId, name, address, legalPerson);
                    SetControls.SetControlReadonly(FormFoodCirculateLicense, !this._isEditable);
                    if (FormFoodCirculateLicense.ShowDialog() == DialogResult.OK)
                    {
                        btnLicense.Tag = FormFoodCirculateLicense.FoodCirculateLicense.Id;
                    }
                    break;
                default:
                    break;
            }
            if (!(btnLicense.Tag == null))
                if (!btnLicense.Tag.Equals(Guid.Empty))// ||!btnLicense.Tag.Equals(Guid.Empty)
                    btnLicense.BackColor = Color.LightBlue;
                else
                    btnLicense.BackColor = Color.LightGray;
        }

        private void buttonQualityAgreementFile_Click(object sender, EventArgs e)
        {

        }

        private void buttonOrgnize_Click(object sender, EventArgs e)
        {

        }

        private void btnPurchaseDelegater_Click(object sender, EventArgs e)
        {

        }

        private void cmbUnitType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.bindUnitType();
            //foreach (Control c in this.groupBox7.Controls)
            //    if (c.Enabled == true)
            //        c.BackColor = Color.SkyBlue;
        }

        private void bindUnitType()
        {
            if (operationType == OperateType.Add)
            {
                string msg = string.Empty;
                _ListpurchaseUnit = PharmacyDatabaseService.AllPurchaseUnits(out msg).ToList();

                 
                int _count = _ListpurchaseUnit.Select(o => int.Parse(o.DocNumber.Replace("DA", ""))).Max();

                //int _count = _ListpurchaseUnit.Count;
                int len = Convert.ToString(_count).Length;
                string strCode = "GHDW" + DateTime.Now.ToString("yyMMdd");
                string strDocNumber = "DA";
                for (int i = 1; i <= 6 - len; i++)
                {
                    strCode += "0";
                    strDocNumber += "0";
                }

                this.txtCode.Text = strCode + (_count + 1).ToString();
                this.txtDocNumber.Text = strDocNumber + (_count + 1).ToString();
            }

            this.groupBox7.Visible = true;
            this.groupBox7.Height = 90;

            foreach (Control c in this.groupBox7.Controls)
                c.BackColor = Color.LightGray;
            int indexItem = this.cmbUnitType.SelectedIndex;
            List<UnitType> listitem = _ListUnitType.OrderBy(d => d.Code).ToList();
            string str = listitem[indexItem].Name;
            if (str == "批发企业" || str == "零售连锁" || str == "零售" || str == "经营企业")
            {
                this.buttonGMPLicense.Visible = false;
                this.buttonInstrumentsProductionLicense.Visible = false;
                this.buttonMedicineProductionLicense.Visible = false;
                this.buttonBusinessLicense.Visible = true;
                this.buttonOrgnize.Visible = true;
                this.buttonhygiene.Visible = true;

                this.buttonGSPLicense.Visible = true;
                this.buttonInstrumentsBusinessLicense.Visible = true;
                this.buttonMedicineBusinessLicense.Visible = true;
                this.buttonMedInst.Visible = false;
                this.buttonfood.Visible = false;
                this.btnLegalPerson.Visible = false;
                this.buttontxtTaxRegistrationCode.Visible = true;

                this.buttonGSPLicense.Left = 32;
                this.buttonGSPLicense.Top = 25;
                this.buttonInstrumentsBusinessLicense.Left = this.buttonGSPLicense.Width + buttonGSPLicense.Left + 5;
                this.buttonInstrumentsBusinessLicense.Top = 25;
                this.buttonMedicineBusinessLicense.Left = this.buttonInstrumentsBusinessLicense.Width + buttonInstrumentsBusinessLicense.Left + 5;
                this.buttonMedicineBusinessLicense.Top = 25;
                this.buttonBusinessLicense.Left = this.buttonMedicineBusinessLicense.Width + buttonMedicineBusinessLicense.Left + 5;
                this.buttonBusinessLicense.Top = 25;
                this.buttonOrgnize.Left = this.buttonBusinessLicense.Width + buttonBusinessLicense.Left + 5;
                this.buttonOrgnize.Top = 25;
                this.buttonhygiene.Left = this.buttonOrgnize.Width + buttonOrgnize.Left + 5;
                this.buttonhygiene.Top = 25;
                this.buttontxtTaxRegistrationCode.Left = this.buttonhygiene.Width + buttonhygiene.Left + 5;
                this.buttontxtTaxRegistrationCode.Top = 25;
                this.buttonGSPLicense.Text = "药品经营许可证";

            }
            if (str == "医疗机构" || str == "计划生育技术服务机构" || str == "其他医疗机构" || str == "部队医疗机构")
            {
                this.buttonGMPLicense.Visible = false;
                this.buttonInstrumentsProductionLicense.Visible = false;
                this.buttonMedicineProductionLicense.Visible = false;
                this.buttonMedInst.Visible = true;
                this.buttonfood.Visible = false;
                this.btnLegalPerson.Visible = true;
                this.buttonGSPLicense.Visible = true;
                this.buttonInstrumentsBusinessLicense.Visible = false;
                this.buttonMedicineBusinessLicense.Visible = false;
                this.buttonBusinessLicense.Visible = true;
                this.buttonOrgnize.Visible = true;
                this.buttonhygiene.Visible = false;
                this.buttontxtTaxRegistrationCode.Visible = false;

                this.buttonGSPLicense.Left = 32;
                this.buttonGSPLicense.Top = 25;
                this.buttonMedInst.Left = this.buttonGSPLicense.Width + buttonGSPLicense.Left + 5;
                this.buttonMedInst.Top = 25;
                this.buttonBusinessLicense.Left = this.buttonMedInst.Width + buttonMedInst.Left + 5;
                this.buttonBusinessLicense.Top = 25;
                this.buttonOrgnize.Left = this.buttonBusinessLicense.Width + buttonBusinessLicense.Left + 5;
                this.buttonOrgnize.Top = 25;
                this.btnLegalPerson.Left = this.buttonOrgnize.Width + buttonOrgnize.Left + 5;
                this.btnLegalPerson.Top = 25;
                this.buttonGSPLicense.Text = "品种许可范围";
            }
            if (str == "生产企业")
            {
                this.buttonGMPLicense.Visible = true;
                this.buttonInstrumentsProductionLicense.Visible = true;
                this.buttonMedicineProductionLicense.Visible = true;
                this.buttonBusinessLicense.Visible = true;
                this.buttonOrgnize.Visible = true;
                this.buttonhygiene.Visible = true;

                this.buttonGSPLicense.Visible = true;
                this.buttonInstrumentsBusinessLicense.Visible = false;
                this.buttonMedicineBusinessLicense.Visible = false;
                this.buttonMedInst.Visible = false;
                this.buttonfood.Visible = false;
                this.btnLegalPerson.Visible = false;

                this.buttonGSPLicense.Left = 32;
                this.buttonGSPLicense.Top = 25;
                this.buttonGMPLicense.Left = this.buttonGSPLicense.Width + buttonGSPLicense.Left + 5;
                this.buttonGMPLicense.Top = 25;
                this.buttonInstrumentsProductionLicense.Left = this.buttonGMPLicense.Width + buttonGMPLicense.Left + 5;
                this.buttonInstrumentsProductionLicense.Top = 25;
                this.buttonMedicineProductionLicense.Left = this.buttonInstrumentsProductionLicense.Width + buttonInstrumentsProductionLicense.Left + 5;
                this.buttonMedicineProductionLicense.Top = 25;
                this.buttonBusinessLicense.Left = this.buttonMedicineProductionLicense.Width + buttonMedicineProductionLicense.Left + 5;
                this.buttonBusinessLicense.Top = 25;
                this.buttonOrgnize.Left = this.buttonBusinessLicense.Width + buttonBusinessLicense.Left + 5;
                this.buttonOrgnize.Top = 25;
                this.buttonhygiene.Left = this.buttonOrgnize.Width + buttonOrgnize.Left + 5;
                this.buttonhygiene.Top = 25;
                this.buttonGSPLicense.Text = "品种许可范围";
            }
            if (str == "卫生防疫机构/疾病预防控制中心" || str == "学校科研机构")
            {
                this.buttonGMPLicense.Visible = false;
                this.buttonInstrumentsProductionLicense.Visible = false;
                this.buttonMedicineProductionLicense.Visible = false;
                this.buttonMedInst.Visible = false;
                this.buttonfood.Visible = false;
                this.btnLegalPerson.Visible = true;
                this.buttonGSPLicense.Visible = true;
                this.buttonInstrumentsBusinessLicense.Visible = false;
                this.buttonMedicineBusinessLicense.Visible = false;
                this.buttonBusinessLicense.Visible = false;
                this.buttonOrgnize.Visible = true;
                this.buttonhygiene.Visible = false;
                this.buttontxtTaxRegistrationCode.Visible = false;

                this.buttonGSPLicense.Left = 32;
                this.buttonGSPLicense.Top = 25;
                this.buttonOrgnize.Left = this.buttonGSPLicense.Width + this.buttonGSPLicense.Left + 5;
                this.buttonOrgnize.Top = 25;
                this.btnLegalPerson.Left = this.buttonOrgnize.Width + this.buttonOrgnize.Left + 5;
                this.btnLegalPerson.Top = 25;
                this.buttonGSPLicense.Text = "品种许可范围";
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            string chineseSpell = CreateChineseSpell.CreatePY(this.txtName.Text);
            this.txtPinyinCode.Text = chineseSpell;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BeginEdit(true);
            //dataGridView1.Rows[e.RowIndex].Cells[0].Value = txtName.Text.Trim();
            //dataGridView1.Rows[e.RowIndex].Cells[4].Value = txtDocNumber.Text.Trim();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == colAwardTime.Name || this.dataGridView1.Columns[e.ColumnIndex].Name == this.colOutDate.Name)
            {
                try
                {
                    DateTime output;
                    bool b = DateTime.TryParseExact(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out output);
                    if (!b)
                    {
                        MessageBox.Show("请输入8位时间码！例如:20140101");
                        string dts = DateTime.Now.Year.ToString() + "0101";
                        string dte = DateTime.Now.Year.ToString() + "1231";
                        this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.dataGridView1.Columns[e.ColumnIndex].Name == this.colAwardTime.Name ? dts : dte;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("请输入8位时间码！例如:20140101");
                    string dts = DateTime.Now.Year.ToString() + "0101";
                    string dte = DateTime.Now.Year.ToString() + "1231";
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.dataGridView1.Columns[e.ColumnIndex].Name == this.colAwardTime.Name ? dts : dte;
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (operationType == OperateType.Add)
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = txtName.Text.Trim();
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = txtDocNumber.Text.Trim();
            }
        }

        private void newDataGridviewer1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.newDataGridviewer1.Columns[e.ColumnIndex].Name == colAuthStartTime.Name || this.newDataGridviewer1.Columns[e.ColumnIndex].Name == colEndTime.Name)
            {
                try
                {
                    DateTime output;
                    bool b = DateTime.TryParseExact(this.newDataGridviewer1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out output);
                    if (!b)
                    {
                        MessageBox.Show("请输入8位时间码！例如:20140101");
                        string dts = DateTime.Now.Year.ToString() + "0101";
                        string dte = DateTime.Now.Year.ToString() + "1231";
                        this.newDataGridviewer1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.newDataGridviewer1.Columns[e.ColumnIndex].Name == colAuthStartTime.Name ? dts : dte;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("请输入8位时间码！例如:20140101");
                    string dts = DateTime.Now.Year.ToString() + "0101";
                    string dte = DateTime.Now.Year.ToString() + "1231";
                    this.newDataGridviewer1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.newDataGridviewer1.Columns[e.ColumnIndex].Name == colAuthStartTime.Name ? dts : dte;
                }
            }
        }

        private void newDataGridviewer1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (operationType == OperateType.Add)
            {
                newDataGridviewer1.Rows[e.RowIndex].Cells[0].Value = txtName.Text.Trim();
                newDataGridviewer1.Rows[e.RowIndex].Cells[2].Value = txtLegalPerson.Text.Trim();
                newDataGridviewer1.Rows[e.RowIndex].Cells[7].Value = txtDocNumber.Text.Trim();
            }
        }

        private void newDataGridviewer1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.newDataGridviewer1.AutoGenerateColumns = false;
            newDataGridviewer1.BeginEdit(true);
            //newDataGridviewer1.Rows[e.RowIndex].Cells[0].Value = txtName.Text.Trim();
            //newDataGridviewer1.Rows[e.RowIndex].Cells[2].Value = txtLegalPerson.Text.Trim();
            //newDataGridviewer1.Rows[e.RowIndex].Cells[7].Value = txtDocNumber.Text.Trim();
        }

        public void EndDatagridEdit()
        {
            this.dataGridView1.EndEdit();
            this.newDataGridviewer1.EndEdit();
        }


        private void newDataGridviewer1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (_purchaseUnit == null) return;
            Forms.BaseDataManage.Form_Photo frm = new Forms.BaseDataManage.Form_Photo(5, this._purchaseUnit.Id);
            frm.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (_purchaseUnit == null) return;
            Forms.BaseDataManage.Form_Photo frm = new Forms.BaseDataManage.Form_Photo(6, this._purchaseUnit.Id);
            frm.ShowDialog();
        }

        private void newDataGridviewer1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            this.CurrentDGV = (DataGridView)sender;

            cms.Items[1].Enabled = this.CurrentDGV.Rows.Count > 0;

            cms.Show(MousePosition.X, MousePosition.Y);
        }

        private void newDataGridviewer1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            this.CurrentDGV = (DataGridView)sender;
            cms.Items[1].Enabled = this.CurrentDGV.Rows.Count > 0;


            cms.Show(MousePosition.X, MousePosition.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.newDataGridviewer1.Rows.Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.Rows.Add();
        }
    }
}
