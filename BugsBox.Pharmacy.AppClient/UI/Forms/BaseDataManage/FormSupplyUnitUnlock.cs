using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    using RetailPaymentMethod = BugsBox.Pharmacy.Models.RetailPaymentMethod;
    using RetailCustomerType = BugsBox.Pharmacy.Models.RetailCustomerType;
    using BugsBox.Pharmacy.Service.Models;
    using BugsBox.Application.Core;

    public partial class FormSupplyUnitUnlock : BaseFunctionForm
    {
        private List<SupplyUnit> _listSupplyUnit = new List<SupplyUnit>();
        private PagerInfo pageInfo = new PagerInfo();
        private ContextMenuStrip cms = new ContextMenuStrip();
        string msg = string.Empty;
        private IList<UnitType> _UnitType = null;

        public FormSupplyUnitUnlock()
        {
            try
            {
                InitializeComponent();
                this.dataGridView1.AutoGenerateColumns = false;
                this.RightMenu();
                this.SetColumns();
                _UnitType = this.PharmacyDatabaseService.AllUnitTypes(out msg);
                this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSupplyUnitUnlock_Load(object sender, EventArgs e)
        {
            this.search();
        }

        //查询
        private void search()
        {
            try
            {
                int pageIndex = this.pcMain.PageIndex;
                int pageSize = this.pcMain.PageSize;

                string msg = string.Empty;
                _listSupplyUnit = PharmacyDatabaseService.GetPagedLockSupplyUnitUnit(out pageInfo, out msg, pageIndex, pageSize).ToList();
                var c = from i in _listSupplyUnit
                        join j in _UnitType on i.UnitTypeId equals j.Id
                        select new bool2String
                        {
                            id = i.Id,
                            Name = i.Name,
                            Code = i.Code,
                            PinyinCode = i.PinyinCode,
                            ContactName = i.ContactName,
                            ContactTel = i.ContactTel,
                            LegalPerson = i.LegalPerson,
                            BusinessScope = i.BusinessScope,
                            SalesAmount = i.SalesAmount,
                            Fax = i.Fax,
                            Email = i.Email,
                            WebAddress = i.WebAddress,
                            DetailedAddress = i.DetailedAddress,

                            IsOutDate = i.IsOutDate ? "已过期" : "未过期",
                            SupplyProductClass = i.SupplyProductClass,
                            QualityCharger = i.QualityCharger,
                            BankAccount = i.Bank,
                            Valid = i.Valid ? "有效" : "无效",
                            IsApproval = i.IsApproval ? "通过审核" : "未通过审核",
                            IsLock = i.IsLock ? "被锁定" : "未锁定",
                            UnitType = j.Name,
                            LastAnnualDte = i.LastAnnualDte,
                            IsQualityAgreementOut = i.IsQualityAgreementOut ? "已过期" : "未过期",
                            QualityAgreementOutdate = i.QualityAgreementOutdate,
                            IsAttorneyAattorneyOut = i.IsAttorneyAattorneyOut ? "已过期" : "未过期",
                            AttorneyAattorneyOutdate = i.AttorneyAattorneyOutdate,

                            #region 资质
                            GSPLC = i.GSPLicenseId == Guid.Empty ? "无" : i.GSPLicenseOutDate.ToLongDateString(),
                            GMPLC = i.GMPLicenseId == Guid.Empty ? "无" : i.GMPLicenseOutDate.ToLongDateString(),
                            BusinessLC = i.BusinessLicenseId == Guid.Empty ? "无" : i.BusinessLicenseeOutDate.ToLongDateString(),
                            MedicineProductionLC = i.MedicineProductionLicenseId == Guid.Empty ? "无" : i.MedicineProductionLicenseOutDate.ToLongDateString(),
                            MedicineBusinessLC = i.MedicineBusinessLicenseId == Guid.Empty ? "无" : i.MedicineBusinessLicenseOutDate.ToLongDateString(),
                            InstrumentsProductionLC = i.InstrumentsProductionLicenseId == Guid.Empty ? "无" : i.InstrumentsProductionLicenseOutDate.ToLongDateString(),
                            InstrumentsBusinessLC = i.InstrumentsBusinessLicenseId == Guid.Empty ? "无" : i.InstrumentsBusinessLicenseOutDate.ToLongDateString(),
                            HealthLC = i.HealthLicenseId == Guid.Empty ? "无" : i.HealthLicenseOutDate.ToLongDateString(),
                            TaxRegisterLC = i.TaxRegisterLicenseId == Guid.Empty ? "无" : i.TaxRegisterLicenseOutDate.ToLongDateString(),
                            OrganizationCodeLC = i.OrganizationCodeLicenseId == Guid.Empty ? "无" : i.OrganizationCodeLicenseOutDate.ToLongDateString(),
                            FoodCirculateLC = i.FoodCirculateLicenseId == Guid.Empty ? "无" : i.FoodCirculateLicenseOutDate.ToLongDateString(),
                            MmedicalInstitutionLC = i.MmedicalInstitutionPermitId == Guid.Empty ? "无" : i.MmedicalInstitutionPermitOutDate.ToLongDateString(),
                            LnstitutionLegalPersonLC = i.LnstitutionLegalPersonLicenseId == Guid.Empty ? "无" : i.LnstitutionLegalPersonLicenseOutDate.ToLongDateString()
                            #endregion
                        };
                
                this.dataGridView1.DataSource = c.OrderBy(r => r.Code).ToList();
                if (this.dataGridView1.Columns.Count > 1)
                {
                    this.dataGridView1.Columns[0].Frozen = true;
                }
                this.pcMain.RecordCount = pageInfo.RecordCount;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pcMain_DataPaging()
        {
            this.search();
        }      
        
        private void RightMenu()
        {
            ToolStripMenuItem tsmiR;
            ToolStripMenuItem tsmi;

            cms.Items.Add("查看审核详情", null, delegate(object sender, EventArgs e)
            {
                if (this.dataGridView1.CurrentRow.Index < 0) return;
                if (this.dataGridView1.SelectedRows.Count <= 0) return;
                var u = this.dataGridView1.SelectedRows[0].DataBoundItem as bool2String;
                SupplyUnit su = this.PharmacyDatabaseService.GetSupplyUnit(out msg, u.id);
                Forms.Approval.FormApprovalFlowCenter form = new Forms.Approval.FormApprovalFlowCenter(null, su.FlowID, false);
                form.ShowDialog();
            });
            cms.Items.Add("-");

            tsmiR = new ToolStripMenuItem("资质查看");
            tsmiR.Name = "资质查看";
            cms.Items.Add(tsmiR);
            cms.Items.Add("-");
            #region 资质查看
            tsmi = new ToolStripMenuItem("GSP证书", null, delegate(object sender, EventArgs e) { this.GetResource(0); });
            tsmiR.DropDownItems.Add(tsmi);
            tsmi = new ToolStripMenuItem("GMP证书", null, delegate(object sender, EventArgs e) { this.GetResource(1); });
            tsmiR.DropDownItems.Add(tsmi);
            tsmi = new ToolStripMenuItem("药品生产许可证", null, delegate(object sender, EventArgs e) { this.GetResource(2); });
            tsmiR.DropDownItems.Add(tsmi);
            tsmi = new ToolStripMenuItem("营业执照", null, delegate(object sender, EventArgs e) { this.GetResource(3); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("器械生产许可证", null, delegate(object sender, EventArgs e) { this.GetResource(4); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("器械经营许可证", null, delegate(object sender, EventArgs e) { this.GetResource(5); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("组织机构代码证", null, delegate(object sender, EventArgs e) { this.GetResource(6); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("卫生许可证", null, delegate(object sender, EventArgs e) { this.GetResource(7); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("事业单位法人证书", null, delegate(object sender, EventArgs e) { this.GetResource(8); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("税务登记证", null, delegate(object sender, EventArgs e) { this.GetResource(9); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("食品流通许可证", null, delegate(object sender, EventArgs e) { this.GetResource(10); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("品种许可范围", null, delegate(object sender, EventArgs e) { this.GetResource(11); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("医疗机构执业许可证", null, delegate(object sender, EventArgs e) { this.GetResource(12); });
            tsmiR.DropDownItems.Add(tsmi);
            #endregion
            cms.Items.Add("查看供货单位信息", null, delegate(object sender, EventArgs e)
            {
                if (this.dataGridView1.SelectedRows.Count <= 0) return;
                var u = this.dataGridView1.SelectedRows[0].DataBoundItem as bool2String;
                SupplyUnit su = this.PharmacyDatabaseService.GetSupplyUnit(out msg, u.id);
                UserControls.ucSupplyUnit us = new UserControls.ucSupplyUnit(su, false);
                Form f = new Form();
                f.Text = su.Name;
                f.AutoSize = true;
                f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                Panel p = new Panel();
                p.AutoSize = true;
                p.Controls.Add(us);
                f.Controls.Add(p);
                f.ShowDialog();
            });
            
            cms.Items.Add("-");
            cms.Items.Add("导出EXCEL表格", null, toolStripButton2_Click);

            cms.Items.Add("-");
            cms.Items.Add("刷新列表", null, this.toolStripButton1_Click);
        }
        private void GetResource(int i)
        {
            bool2String b = this.dataGridView1.SelectedRows[0].DataBoundItem as bool2String;
            SupplyUnit su = _listSupplyUnit.Where(r => r.Id == b.id).FirstOrDefault();
            switch (i)
            {
                case 0:
                    FormMedicineBusinessLicense FormMedicineBusinessLicense = new FormMedicineBusinessLicense(su.MedicineBusinessLicenseId, true);
                    SetControls.SetControlReadonly(FormMedicineBusinessLicense, true);
                    FormMedicineBusinessLicense.ShowDialog();
                    break;
                case 1:
                    FormGMPLicense FormGMPLiscense = new FormGMPLicense(su.GMPLicenseId, string.Empty, string.Empty, true);
                    SetControls.SetControlReadonly(FormGMPLiscense, true);
                    FormGMPLiscense.ShowDialog();
                    break;
                case 2:
                    FormMedicineProductionLicense FormMedicineProductionLicense = new FormMedicineProductionLicense(su.MedicineProductionLicenseId, true);
                    SetControls.SetControlReadonly(FormMedicineProductionLicense, true);
                    FormMedicineProductionLicense.ShowDialog();
                    break;
                case 3:
                    FormBusinessLicense FormBusinessLicense = new FormBusinessLicense(su.BusinessLicenseId, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormBusinessLicense, true);
                    FormBusinessLicense.ShowDialog();
                    break;
                case 4:
                    FormInstrumentsProductionLicense FormInstrumentsProductionLicense = new FormInstrumentsProductionLicense(su.InstrumentsProductionLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormInstrumentsProductionLicense, true);
                    FormInstrumentsProductionLicense.ShowDialog();
                    break;
                case 5:
                    FormInstrumentsBusinessLicense FormInstrumentsBusinessLicense = new FormInstrumentsBusinessLicense(su.InstrumentsBusinessLicenseId, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormInstrumentsBusinessLicense, true);
                    FormInstrumentsBusinessLicense.ShowDialog();
                    break;
                case 6:
                    FormOrganizationCodeLicense FormOrganizationCodeLicense = new FormOrganizationCodeLicense(su.OrganizationCodeLicenseId, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormOrganizationCodeLicense, true);
                    FormOrganizationCodeLicense.ShowDialog();
                    break;
                case 7:
                    FormHealthLicense FormHealthLicense = new FormHealthLicense(su.HealthLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormHealthLicense, true);
                    FormHealthLicense.ShowDialog();
                    break;
                case 8:
                    LnstitutionLegalPersonLicense LegalPersonLicense = new LnstitutionLegalPersonLicense();
                    LegalPersonLicense.Id = su.LnstitutionLegalPersonLicenseId;
                    FormLegalPersonLicense FormLegalPersonLicense = new FormLegalPersonLicense(LegalPersonLicense, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormLegalPersonLicense, true);
                    FormLegalPersonLicense.ShowDialog();
                    break;
                case 9:
                    FormTaxRegisterLicense FormTaxRegisterLicense = new FormTaxRegisterLicense(su.TaxRegisterLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormTaxRegisterLicense, true);
                    FormTaxRegisterLicense.ShowDialog();
                    break;
                case 10:
                    FormFoodCirculateLicense FormFoodCirculateLicense = new FormFoodCirculateLicense(su.FoodCirculateLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormFoodCirculateLicense, true);
                    FormFoodCirculateLicense.ShowDialog();
                    break;
                case 11:
                    FormGSPLicense FormGSPLicense = new FormGSPLicense(su.GSPLicenseId, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormGSPLicense, true);
                    FormGSPLicense.ShowDialog();
                    break;
                case 12:
                    MmedicalInstitutionPermit InstitutionPermit = new MmedicalInstitutionPermit();
                    InstitutionPermit.Id = su.MmedicalInstitutionPermitId;
                    FormMmedicalInstitutionPermit FormMmedicalInstitutionPermit = new FormMmedicalInstitutionPermit(InstitutionPermit, string.Empty, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormMmedicalInstitutionPermit, true);
                    FormMmedicalInstitutionPermit.ShowDialog();
                    break;
            }
        }

        //设置列
        private void SetColumns()
        {
            this.dataGridView1.Columns.Add("Name", "单位名称");
            this.dataGridView1.Columns.Add("Code", "代码");
            this.dataGridView1.Columns.Add("PinyinCode", "拼音码");
            this.dataGridView1.Columns.Add("ContactName", "联系人");
            this.dataGridView1.Columns.Add("ContactTel", "联系电话");
            this.dataGridView1.Columns.Add("LegalPerson", "法人");
            this.dataGridView1.Columns.Add("BusinessScope", "生产经营范围");
            this.dataGridView1.Columns.Add("SalesAmount", "年销售额");
            this.dataGridView1.Columns.Add("Fax", "传真");
            this.dataGridView1.Columns.Add("Email", "邮箱");
            this.dataGridView1.Columns.Add("WebAddress", "网站");
            this.dataGridView1.Columns.Add("DetailedAddress", "详细地址");
            //this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Visible = false;
            this.dataGridView1.Columns.Add("IsOutDate", "是否过期");
            this.dataGridView1.Columns.Add("OutDate", "过期日");
            this.dataGridView1.Columns.Add("SupplyProductClass", "拟供品种");
            this.dataGridView1.Columns.Add("QualityCharger", "质量负责人");
            this.dataGridView1.Columns.Add("BankAccount", "银行帐号");
            this.dataGridView1.Columns.Add("Valid", "是否有效");
            this.dataGridView1.Columns.Add("IsApproval", "是否审批通过");
            this.dataGridView1.Columns.Add("IsLock", "人为锁定");

            this.dataGridView1.Columns.Add("UnitType", "企业类型");

            this.dataGridView1.Columns.Add("LastAnnualDte", "最新年检日期");
            this.dataGridView1.Columns.Add("IsQualityAgreementOut", "质量协议书是否过期");
            this.dataGridView1.Columns.Add("QualityAgreementOutdate", "质量协议书有效期止");
            this.dataGridView1.Columns.Add("IsAttorneyAattorneyOut", "法人委托书是否过期");
            this.dataGridView1.Columns.Add("AttorneyAattorneyOutdate", "法人委托书有效期止");
            #region 资质
            this.dataGridView1.Columns.Add("GSPLC", "药品经营许可证");
            this.dataGridView1.Columns.Add("GMPLC", "GMP证书");
            this.dataGridView1.Columns.Add("BusinessLC", "营业执照");
            this.dataGridView1.Columns.Add("MedicineProductionLC", "药品生产许可证");
            this.dataGridView1.Columns.Add("MedicineBusinessLC", "GSP证书");
            this.dataGridView1.Columns.Add("InstrumentsProductionLC", "器械生产许可证");
            this.dataGridView1.Columns.Add("InstrumentsBusinessLC", "器械经营许可证");
            this.dataGridView1.Columns.Add("HealthLC", "卫生许可证");
            this.dataGridView1.Columns.Add("TaxRegisterLC", "税务登记证");
            this.dataGridView1.Columns.Add("OrganizationCodeLC", "组织机构代码证");
            this.dataGridView1.Columns.Add("FoodCirculateLC", "食品流通许可证");
            this.dataGridView1.Columns.Add("MmedicalInstitutionLC", "医疗机构执业许可证");
            this.dataGridView1.Columns.Add("LnstitutionLegalPersonLC", "事业单位法人证书");

            #endregion
            foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
            {
                dc.DataPropertyName = dc.Name;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            dataGridView1.ClearSelection();
            if (e.RowIndex < 0) return;
            dataGridView1.Rows[e.RowIndex].Selected = true;
            var c = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as bool2String;
            dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            SupplyUnit su = this._listSupplyUnit.Where(r => r.Id == c.id).FirstOrDefault();
            if (su == null) return;
            ToolStripMenuItem ti = cms.Items["资质查看"] as ToolStripMenuItem;
            ti.DropDownItems[0].Enabled = !Guid.Empty.Equals(su.MedicineBusinessLicenseId);
            ti.DropDownItems[1].Enabled = !Guid.Empty.Equals(su.GMPLicenseId);
            ti.DropDownItems[2].Enabled = !Guid.Empty.Equals(su.MedicineProductionLicenseId);
            ti.DropDownItems[3].Enabled = !Guid.Empty.Equals(su.BusinessLicenseId);
            ti.DropDownItems[4].Enabled = !Guid.Empty.Equals(su.InstrumentsProductionLicenseId);
            ti.DropDownItems[5].Enabled = !Guid.Empty.Equals(su.InstrumentsBusinessLicenseId);
            ti.DropDownItems[6].Enabled = !Guid.Empty.Equals(su.OrganizationCodeLicenseId);
            ti.DropDownItems[7].Enabled = !Guid.Empty.Equals(su.HealthLicenseId);
            ti.DropDownItems[8].Enabled = !Guid.Empty.Equals(su.LnstitutionLegalPersonLicenseId);
            ti.DropDownItems[9].Enabled = !Guid.Empty.Equals(su.TaxRegisterLicenseId);
            ti.DropDownItems[10].Enabled = !Guid.Empty.Equals(su.FoodCirculateLicenseId);
            ti.DropDownItems[11].Enabled = !Guid.Empty.Equals(su.GSPLicenseId);
            ti.DropDownItems[12].Enabled = !Guid.Empty.Equals(su.MmedicalInstitutionPermitId);

            cms.Show(MousePosition.X, MousePosition.Y);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.search();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1,"已锁定供应商查询结果");
        }


    }
}
