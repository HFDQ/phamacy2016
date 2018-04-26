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

    public partial class FormPurchaseUnitUnlock : BaseFunctionForm
    {
        private List<PurchaseUnit> _listPurchaseUnit = new List<PurchaseUnit>();
        private PagerInfo pageInfo = new PagerInfo();
        string msg = string.Empty;

        List<UnitType> UnitTypes = new List<UnitType>();
        private ContextMenuStrip cms = new ContextMenuStrip();


        public FormPurchaseUnitUnlock()
        {
            try
            {
                InitializeComponent();
                this.dgvMain.AutoGenerateColumns = false;
                this.SetColumnDictionary();
                UnitTypes = this.PharmacyDatabaseService.AllUnitTypes(out msg).ToList();
                this.RightMenu();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPurchaseUnitUnlock_Load(object sender, EventArgs e)
        {
            this.search();
        }
        /// <summary>
        /// 查询方法并且绑定DGV
        /// </summary>
        public void search()
        {
            try
            {
                int pageIndex = this.pcMain.PageIndex;
                int pageSize = this.pcMain.PageSize;
                _listPurchaseUnit = PharmacyDatabaseService.GetPagedLockPurchaseUnit(out pageInfo, out msg, pageIndex, pageSize).ToList();
                var c = from i in this._listPurchaseUnit
                        join j in UnitTypes on i.UnitTypeId equals j.Id
                        select new Forms.BaseDataManage.PurchaseUnitShow
                        {
                            Id = i.Id,
                            BusinessScope = i.BusinessScope,
                            Code = i.Code,
                            ContactName = i.ContactName,
                            ContactTel = i.ContactTel,
                            Email = i.Email,
                            DetailedAddress = i.DetailedAddress,
                            Fax = i.Fax,
                            IsApproval = i.IsApproval ? "已通过审批" : "未通过审批",
                            IsOutDate = i.IsOutDate ? "已过期" : "未过期",
                            LastAnnualDte = i.LastAnnualDte,
                            LegalPerson = i.LegalPerson,
                            Name = i.Name,
                            OutDate = i.OutDate,
                            PinyinCode = i.PinyinCode,
                            SalesAmount = i.SalesAmount,
                            TaxRegistrationCode = i.TaxRegistrationCode,
                            UnitType = j.Name,
                            Valid = i.Valid ? "有效" : "无效",
                            WebAddress = i.WebAddress,
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

                this.dgvMain.DataSource = c.ToList();
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

        private void SetColumnDictionary()//显示列
        {
            this.dgvMain.Columns.Add("Name", "单位名称");
            this.dgvMain.Columns.Add("PinyinCode", "拼音码");
            this.dgvMain.Columns.Add("Code", "代码");
            this.dgvMain.Columns.Add("UnitType", "企业类型");
            this.dgvMain.Columns.Add("IsApproval", "是否审批通过");
            this.dgvMain.Columns.Add("Valid", "是否有效");
            this.dgvMain.Columns.Add("IsOutDate", "是否过期");
            this.dgvMain.Columns.Add("OutDate", "过期日");
            this.dgvMain.Columns.Add("ContactName", "联系人");
            this.dgvMain.Columns.Add("ContactTel", "联系电话");
            this.dgvMain.Columns.Add("DetailedAddress", "详细地址");
            this.dgvMain.Columns.Add("LegalPerson", "法人");
            this.dgvMain.Columns.Add("SalesAmount", "年销售额");
            this.dgvMain.Columns.Add("Fax", "传真");
            this.dgvMain.Columns.Add("Email", "邮箱");
            this.dgvMain.Columns.Add("WebAddress", "网站");
            this.dgvMain.Columns.Add("TaxRegistrationCode", "税务登记号");
            this.dgvMain.Columns.Add("LastAnnualDte", "最新年检日期");

            #region 资质
            this.dgvMain.Columns.Add("GSPLC", "药品经营许可证");
            this.dgvMain.Columns.Add("GMPLC", "GMP证书");
            this.dgvMain.Columns.Add("BusinessLC", "营业执照");
            this.dgvMain.Columns.Add("MedicineProductionLC", "药品生产许可证");
            this.dgvMain.Columns.Add("MedicineBusinessLC", "GSP证书");
            this.dgvMain.Columns.Add("InstrumentsProductionLC", "器械生产许可证");
            this.dgvMain.Columns.Add("InstrumentsBusinessLC", "器械经营许可证");
            this.dgvMain.Columns.Add("HealthLC", "卫生许可证");
            this.dgvMain.Columns.Add("TaxRegisterLC", "税务登记证");
            this.dgvMain.Columns.Add("OrganizationCodeLC", "组织机构代码证");
            this.dgvMain.Columns.Add("FoodCirculateLC", "食品流通许可证");
            this.dgvMain.Columns.Add("MmedicalInstitutionLC", "医疗机构执业许可证");
            this.dgvMain.Columns.Add("LnstitutionLegalPersonLC", "事业单位法人证书");

            #endregion
            foreach (DataGridViewColumn dc in this.dgvMain.Columns)
            {
                dc.DataPropertyName = dc.Name;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.search();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dgvMain,"已锁定客户查询结果");
        }
        
        private void RightMenu()
        {
            ToolStripMenuItem tsmiR;
            ToolStripMenuItem tsmi;

            cms.Items.Add("查看审核详情", null, delegate(object sender, EventArgs e)
            {
                if (this.dgvMain.CurrentRow.Index < 0) return;
                PurchaseUnitShow ps = this.dgvMain.CurrentRow.DataBoundItem as PurchaseUnitShow;
                PurchaseUnit pu = this._listPurchaseUnit.Where(r => r.Id == ps.Id).FirstOrDefault();
                if (pu == null) return;
                Forms.Approval.FormApprovalFlowCenter form = new Forms.Approval.FormApprovalFlowCenter(null, pu.FlowID, false);
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
            cms.Items.Add("查看购货单位信息", null, delegate(object sender, EventArgs e)
            {
                PurchaseUnitShow ps = this.dgvMain.SelectedRows[0].DataBoundItem as PurchaseUnitShow;
                PurchaseUnit pu = this.PharmacyDatabaseService.GetPurchaseUnit(out msg, ps.Id);
                if (pu == null) return;
                UserControls.ucPurchaseUnit us = new UserControls.ucPurchaseUnit(pu, false);
                Form f = new Form();
                f.Text = pu.Name;
                f.AutoSize = true;
                f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                f.StartPosition = FormStartPosition.CenterScreen;
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
            PurchaseUnitShow ps = this.dgvMain.CurrentRow.DataBoundItem as PurchaseUnitShow;
            PurchaseUnit pu = this._listPurchaseUnit.Where(r => r.Id == ps.Id).FirstOrDefault();
            if (pu == null) return;
            switch (i)
            {
                case 0:
                    FormMedicineBusinessLicense FormMedicineBusinessLicense = new FormMedicineBusinessLicense(pu.MedicineBusinessLicenseId, true);
                    FormMedicineBusinessLicense.ShowDialog();
                    break;
                case 1:
                    FormGMPLicense frm = new FormGMPLicense(pu.GMPLicenseId, string.Empty, string.Empty, true);
                    frm.ShowDialog();
                    break;
                case 2:
                    FormMedicineProductionLicense FormMedicineProductionLicense = new FormMedicineProductionLicense(pu.MedicineProductionLicenseId, true);
                    SetControls.SetControlReadonly(FormMedicineProductionLicense, true);
                    FormMedicineProductionLicense.ShowDialog();
                    break;
                case 3:
                    FormBusinessLicense FormBusinessLicense = new FormBusinessLicense(pu.BusinessLicenseId, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormBusinessLicense, true);
                    FormBusinessLicense.ShowDialog();
                    break;
                case 4:
                    FormInstrumentsProductionLicense FormInstrumentsProductionLicense = new FormInstrumentsProductionLicense(pu.InstrumentsProductionLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormInstrumentsProductionLicense, true);
                    FormInstrumentsProductionLicense.ShowDialog();
                    break;
                case 5:
                    FormInstrumentsBusinessLicense FormInstrumentsBusinessLicense = new FormInstrumentsBusinessLicense(pu.InstrumentsBusinessLicenseId, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormInstrumentsBusinessLicense, true);
                    FormInstrumentsBusinessLicense.ShowDialog();
                    break;
                case 6:
                    FormOrganizationCodeLicense FormOrganizationCodeLicense = new FormOrganizationCodeLicense(pu.OrganizationCodeLicenseId, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormOrganizationCodeLicense, true);
                    FormOrganizationCodeLicense.ShowDialog();
                    break;
                case 7:
                    FormHealthLicense FormHealthLicense = new FormHealthLicense(pu.HealthLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormHealthLicense, true);
                    FormHealthLicense.ShowDialog();
                    break;
                case 8:
                    LnstitutionLegalPersonLicense LegalPersonLicense = new LnstitutionLegalPersonLicense();
                    LegalPersonLicense.Id = pu.LnstitutionLegalPersonLicenseId;
                    FormLegalPersonLicense FormLegalPersonLicense = new FormLegalPersonLicense(LegalPersonLicense, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormLegalPersonLicense, true);
                    FormLegalPersonLicense.ShowDialog();
                    break;
                case 9:
                    FormTaxRegisterLicense FormTaxRegisterLicense = new FormTaxRegisterLicense(pu.TaxRegisterLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormTaxRegisterLicense, true);
                    FormTaxRegisterLicense.ShowDialog();
                    break;
                case 10:
                    FormFoodCirculateLicense FormFoodCirculateLicense = new FormFoodCirculateLicense(pu.FoodCirculateLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormFoodCirculateLicense, true);
                    FormFoodCirculateLicense.ShowDialog();
                    break;
                case 11:
                    FormGSPLicense FormGSPLicense = new FormGSPLicense(pu.GSPLicenseId, string.Empty, string.Empty, string.Empty, string.Empty,string.Empty);
                    SetControls.SetControlReadonly(FormGSPLicense, true);
                    FormGSPLicense.ShowDialog();
                    break;
                case 12:
                    MmedicalInstitutionPermit InstitutionPermit = new MmedicalInstitutionPermit();
                    InstitutionPermit.Id = pu.MmedicalInstitutionPermitId;
                    FormMmedicalInstitutionPermit FormMmedicalInstitutionPermit = new FormMmedicalInstitutionPermit(InstitutionPermit, string.Empty, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormMmedicalInstitutionPermit, true);
                    FormMmedicalInstitutionPermit.ShowDialog();
                    break;
            }
        }

        private void dgvMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dgvMain.Rows[e.RowIndex].Selected = true;
            if (e.RowIndex < 0||e.ColumnIndex<0) return;
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            dgvMain.ClearSelection();
            if (e.RowIndex < 0) return;
            dgvMain.Rows[e.RowIndex].Selected = true;
            dgvMain.CurrentCell = this.dgvMain.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var c = this.dgvMain.Rows[e.RowIndex].DataBoundItem as PurchaseUnitShow;

            PurchaseUnit pu = this._listPurchaseUnit.Where(r => r.Id == c.Id).FirstOrDefault();
            if (pu == null) return;
            ToolStripMenuItem ti = cms.Items["资质查看"] as ToolStripMenuItem;
            ti.DropDownItems[0].Enabled = !Guid.Empty.Equals(pu.MedicineBusinessLicenseId);
            ti.DropDownItems[1].Enabled = !Guid.Empty.Equals(pu.GMPLicenseId);
            ti.DropDownItems[2].Enabled = !Guid.Empty.Equals(pu.MedicineProductionLicenseId);
            ti.DropDownItems[3].Enabled = !Guid.Empty.Equals(pu.BusinessLicenseId);
            ti.DropDownItems[4].Enabled = !Guid.Empty.Equals(pu.InstrumentsProductionLicenseId);
            ti.DropDownItems[5].Enabled = !Guid.Empty.Equals(pu.InstrumentsBusinessLicenseId);
            ti.DropDownItems[6].Enabled = !Guid.Empty.Equals(pu.OrganizationCodeLicenseId);
            ti.DropDownItems[7].Enabled = !Guid.Empty.Equals(pu.HealthLicenseId);
            ti.DropDownItems[8].Enabled = !Guid.Empty.Equals(pu.LnstitutionLegalPersonLicenseId);
            ti.DropDownItems[9].Enabled = !Guid.Empty.Equals(pu.TaxRegisterLicenseId);
            ti.DropDownItems[10].Enabled = !Guid.Empty.Equals(pu.FoodCirculateLicenseId);
            ti.DropDownItems[11].Enabled = !Guid.Empty.Equals(pu.GSPLicenseId);
            ti.DropDownItems[12].Enabled = !Guid.Empty.Equals(pu.MmedicalInstitutionPermitId);

            cms.Show(MousePosition.X, MousePosition.Y);
        }
    }
}
