using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class Form_NearExpire : Form
    {
        /// <summary>
        /// 供货商
        /// </summary>
        private IEnumerable<Models.SupplyUnit> _NExpiredList;
        /// <summary>
        /// 客户
        /// </summary>
        private IEnumerable<Models.PurchaseUnit> _PExpiredList;
        private IEnumerable<PurchaseUnitShow> _PUS;
        /// <summary>
        /// 资质列表
        /// </summary>
        List<QualificFileName> ListQ = new List<QualificFileName>();
        bool IsSupplyer = true;

        /// <summary>
        /// 该字段需设置
        /// </summary>
        public int WarningDate { get; set; }

        public Form_NearExpire()
        {

            InitializeComponent();

            this.toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            this.GetQualificFileList();

            this.toolStripComboBox1.ComboBox.DisplayMember = "Name";
            this.toolStripComboBox1.ComboBox.ValueMember = "Value";
            this.toolStripComboBox1.ComboBox.DataSource = this.ListQ;

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ReadOnly = true;
            this.SetColumns();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
        }

        /// <summary>
        /// 供货商资质近效预警信息
        /// </summary>
        /// <param name="NExpiredList"></param>
        public Form_NearExpire(IEnumerable<Models.SupplyUnit> NExpiredList)
            : this()
        {
            if (NExpiredList.Count() <= 0)
            {
                MessageBox.Show("无近效资质！");
                return;
            }
            
            this._NExpiredList = NExpiredList;
            this.IsSupplyer = true;
            this.BindGridSupplyers();
        }

        /// <summary>
        /// 客户资质近效预警信息
        /// </summary>
        /// <param name="PExpiredList"></param>
        public Form_NearExpire(IEnumerable<Models.PurchaseUnit > PExpiredList,IEnumerable<PurchaseUnitShow> pus)
            : this()
        {
            if (PExpiredList.Count() <= 0)
            {
                MessageBox.Show("无近效资质！");
                return;
            }
            this.IsSupplyer = false;
            
            this._PUS=pus;
            this._PExpiredList = PExpiredList;
            this.dataGridView1.Columns["IsQualityAgreementOut"].Visible = false;
            this.dataGridView1.Columns["QualityAgreementOutdate"].Visible = false;
            this.dataGridView1.Columns["IsAttorneyAattorneyOut"].Visible = false;
            this.dataGridView1.Columns["AttorneyAattorneyOutdate"].Visible = false;
            this.BindGridPurchaser();
        }

        private void BindGridSupplyers()
        {
            var re = this._NExpiredList;
            if (this.toolStripComboBox1.SelectedIndex > 0)
            {
                switch (this.toolStripComboBox1.SelectedIndex)
                {
                    case 1:
                        re = this._NExpiredList.Where(r => r.QualityAgreementOutdate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.QualityAgreementOutdate > DateTime.Now.Date);
                        break;
                    case 2:
                        re = this._NExpiredList.Where(r => r.AttorneyAattorneyOutdate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.AttorneyAattorneyOutdate > DateTime.Now.Date);
                        break;
                    case 3:
                        re = this._NExpiredList.Where(r => r.GSPLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.GSPLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 4:
                        re = this._NExpiredList.Where(r => r.GMPLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.GMPLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 5:
                        re = this._NExpiredList.Where(r => r.BusinessLicenseeOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.BusinessLicenseeOutDate > DateTime.Now.Date);
                        break;
                    case 6:
                        re = this._NExpiredList.Where(r => r.MedicineProductionLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.MedicineProductionLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 7:
                        re = this._NExpiredList.Where(r => r.MedicineBusinessLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.MedicineBusinessLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 8:
                        re = this._NExpiredList.Where(r => r.InstrumentsProductionLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.InstrumentsProductionLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 9:
                        re = this._NExpiredList.Where(r => r.InstrumentsBusinessLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.InstrumentsBusinessLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 10:
                        re = this._NExpiredList.Where(r => r.HealthLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.HealthLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 11:
                        re = this._NExpiredList.Where(r => r.TaxRegisterLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.TaxRegisterLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 12:
                        re = this._NExpiredList.Where(r => r.OrganizationCodeLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.OrganizationCodeLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 13:
                        re = this._NExpiredList.Where(r => r.FoodCirculateLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.FoodCirculateLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 14:
                        re = this._NExpiredList.Where(r => r.MmedicalInstitutionPermitOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.MmedicalInstitutionPermitOutDate > DateTime.Now.Date);
                        break;
                    case 15:
                        re = this._NExpiredList.Where(r => r.LnstitutionLegalPersonLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.LnstitutionLegalPersonLicenseOutDate > DateTime.Now.Date);
                        break;
                }
            }

            #region
            var c = (from i in re
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

                         LastAnnualDte = i.LastAnnualDte.Date,
                         IsQualityAgreementOut = i.IsQualityAgreementOut ? "已过期" : "未过期",
                         QualityAgreementOutdate = i.QualityAgreementOutdate.Date,
                         IsAttorneyAattorneyOut = i.IsAttorneyAattorneyOut ? "已过期" : "未过期",
                         AttorneyAattorneyOutdate = i.AttorneyAattorneyOutdate,
                         CreateDate = i.CreateTime.ToLongDateString(),

                         SupplyCateGory = i.SupplyProductClass,
                         DelegateContent = i.AttorneyAattorneyDetail,
                         QualityAgreement = i.QualityAgreementDetail,
                         #region 资质
                         GSPLC = i.GSPLicenseId == Guid.Empty ? "无" : i.GSPLicenseOutDate.ToLongDateString(),
                         GSPLCID = i.GSPLicenseId,
                         GMPLC = i.GMPLicenseId == Guid.Empty ? "无" : i.GMPLicenseOutDate.ToLongDateString(),
                         GMPLCID = i.GMPLicenseId,
                         BusinessLC = i.BusinessLicenseId == Guid.Empty ? "无" : i.BusinessLicenseeOutDate.ToLongDateString(),
                         BusinessLCID = i.BusinessLicenseId,
                         MedicineProductionLC = i.MedicineProductionLicenseId == Guid.Empty ? "无" : i.MedicineProductionLicenseOutDate.ToLongDateString(),
                         MedicineProductionLCID = i.MedicineProductionLicenseId,
                         MedicineBusinessLC = i.MedicineBusinessLicenseId == Guid.Empty ? "无" : i.MedicineBusinessLicenseOutDate.ToLongDateString(),
                         MedicineBusinessLCID = i.MedicineBusinessLicenseId,
                         InstrumentsProductionLC = i.InstrumentsProductionLicenseId == Guid.Empty ? "无" : i.InstrumentsProductionLicenseOutDate.ToLongDateString(),
                         InstrumentsProductionLCID = i.InstrumentsProductionLicenseId,
                         InstrumentsBusinessLC = i.InstrumentsBusinessLicenseId == Guid.Empty ? "无" : i.InstrumentsBusinessLicenseOutDate.ToLongDateString(),
                         InstrumentsBusinessLCID = i.InstrumentsBusinessLicenseId,
                         HealthLC = i.HealthLicenseId == Guid.Empty ? "无" : i.HealthLicenseOutDate.ToLongDateString(),
                         HealthLCID = i.HealthLicenseId,
                         TaxRegisterLC = i.TaxRegisterLicenseId == Guid.Empty ? "无" : i.TaxRegisterLicenseOutDate.ToLongDateString(),
                         TaxRegisterLCID = i.TaxRegisterLicenseId,
                         OrganizationCodeLC = i.OrganizationCodeLicenseId == Guid.Empty ? "无" : i.OrganizationCodeLicenseOutDate.ToLongDateString(),
                         OrganizationCodeLCID = i.OrganizationCodeLicenseId,
                         FoodCirculateLC = i.FoodCirculateLicenseId == Guid.Empty ? "无" : i.FoodCirculateLicenseOutDate.ToLongDateString(),
                         FoodCirculateLCID = i.FoodCirculateLicenseId,
                         MmedicalInstitutionLC = i.MmedicalInstitutionPermitId == Guid.Empty ? "无" : i.MmedicalInstitutionPermitOutDate.ToLongDateString(),
                         MmedicalInstitutionLCID = i.MmedicalInstitutionPermitId,
                         LnstitutionLegalPersonLC = i.LnstitutionLegalPersonLicenseId == Guid.Empty ? "无" : i.LnstitutionLegalPersonLicenseOutDate.ToLongDateString(),
                         LnstitutionLegalPersonLCID = i.LnstitutionLegalPersonLicenseId
                         #endregion
                     }).ToList();
            
            this.dataGridView1.DataSource = new BindingCollection<bool2String>(c.OrderBy(r=>r.Name).ToList());
            #endregion
        }

        private void BindGridPurchaser()
        {
            var re = this._PExpiredList;
            if (this.toolStripComboBox1.SelectedIndex > 0)
            {
                switch (this.toolStripComboBox1.SelectedIndex)
                {
                    case 1:
                        re = this._PExpiredList.Where(r => r.QualityAgreementOutdate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.QualityAgreementOutdate > DateTime.Now.Date);
                        break;
                    case 2:
                        re = this._PExpiredList;
                        break;
                    case 3:
                        re = this._PExpiredList.Where(r => r.GSPLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.GSPLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 4:
                        re = this._PExpiredList.Where(r => r.GMPLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.GMPLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 5:
                        re = this._PExpiredList.Where(r => r.BusinessLicenseeOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.BusinessLicenseeOutDate > DateTime.Now.Date);
                        break;
                    case 6:
                        re = this._PExpiredList.Where(r => r.MedicineProductionLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.MedicineProductionLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 7:
                        re = this._PExpiredList.Where(r => r.MedicineBusinessLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.MedicineBusinessLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 8:
                        re = this._PExpiredList.Where(r => r.InstrumentsProductionLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.InstrumentsProductionLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 9:
                        re = this._PExpiredList.Where(r => r.InstrumentsBusinessLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.InstrumentsBusinessLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 10:
                        re = this._PExpiredList.Where(r => r.HealthLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.HealthLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 11:
                        re = this._PExpiredList.Where(r => r.TaxRegisterLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.TaxRegisterLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 12:
                        re = this._PExpiredList.Where(r => r.OrganizationCodeLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.OrganizationCodeLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 13:
                        re = this._PExpiredList.Where(r => r.FoodCirculateLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.FoodCirculateLicenseOutDate > DateTime.Now.Date);
                        break;
                    case 14:
                        re = this._PExpiredList.Where(r => r.MmedicalInstitutionPermitOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.MmedicalInstitutionPermitOutDate > DateTime.Now.Date);
                        break;
                    case 15:
                        re = this._PExpiredList.Where(r => r.LnstitutionLegalPersonLicenseOutDate.Date < DateTime.Now.Date.AddMonths(WarningDate) && r.LnstitutionLegalPersonLicenseOutDate > DateTime.Now.Date);
                        break;
                }
            }

            #region
            var c = (from i in re
                     join j in this._PUS on i.Id equals j.Id
                     select new PurchaseUnitShow
                     {
                         Id = i.Id,
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

                         Valid = i.Valid ? "有效" : "无效",
                         IsApproval = i.IsApproval ? "通过审核" : "未通过审核",

                         LastAnnualDte = i.LastAnnualDte.Date,

                         DelegateContract = i.AttorneyAattorneyDetail,

                         OutDate = i.OutDate,
                         ReceiveAddress = i.ReceiveAddress,
                         TaxRegistrationCode = i.TaxRegistrationCode,
                         UnitType = j.UnitType,
                          Creator=j.Creator,
                          District=j.District,
                         CreateDate = i.CreateTime.ToLongDateString(),

                         QualityAgreement = i.QualityAgreementDetail,
                         #region 资质
                         GSPLC = i.GSPLicenseId == Guid.Empty ? "无" : i.GSPLicenseOutDate.ToLongDateString(),
                         GSPLCID = i.GSPLicenseId,
                         GMPLC = i.GMPLicenseId == Guid.Empty ? "无" : i.GMPLicenseOutDate.ToLongDateString(),
                         GMPLCID = i.GMPLicenseId,
                         BusinessLC = i.BusinessLicenseId == Guid.Empty ? "无" : i.BusinessLicenseeOutDate.ToLongDateString(),
                         BusinessLCID = i.BusinessLicenseId,
                         MedicineProductionLC = i.MedicineProductionLicenseId == Guid.Empty ? "无" : i.MedicineProductionLicenseOutDate.ToLongDateString(),
                         MedicineProductionLCID = i.MedicineProductionLicenseId,
                         MedicineBusinessLC = i.MedicineBusinessLicenseId == Guid.Empty ? "无" : i.MedicineBusinessLicenseOutDate.ToLongDateString(),
                         MedicineBusinessLCID = i.MedicineBusinessLicenseId,
                         InstrumentsProductionLC = i.InstrumentsProductionLicenseId == Guid.Empty ? "无" : i.InstrumentsProductionLicenseOutDate.ToLongDateString(),
                         InstrumentsProductionLCID = i.InstrumentsProductionLicenseId,
                         InstrumentsBusinessLC = i.InstrumentsBusinessLicenseId == Guid.Empty ? "无" : i.InstrumentsBusinessLicenseOutDate.ToLongDateString(),
                         InstrumentsBusinessLCID = i.InstrumentsBusinessLicenseId,
                         HealthLC = i.HealthLicenseId == Guid.Empty ? "无" : i.HealthLicenseOutDate.ToLongDateString(),
                         HealthLCID = i.HealthLicenseId,
                         TaxRegisterLC = i.TaxRegisterLicenseId == Guid.Empty ? "无" : i.TaxRegisterLicenseOutDate.ToLongDateString(),
                         TaxRegisterLCID = i.TaxRegisterLicenseId,
                         OrganizationCodeLC = i.OrganizationCodeLicenseId == Guid.Empty ? "无" : i.OrganizationCodeLicenseOutDate.ToLongDateString(),
                         OrganizationCodeLCID = i.OrganizationCodeLicenseId,
                         FoodCirculateLC = i.FoodCirculateLicenseId == Guid.Empty ? "无" : i.FoodCirculateLicenseOutDate.ToLongDateString(),
                         FoodCirculateLCID = i.FoodCirculateLicenseId,
                         MmedicalInstitutionLC = i.MmedicalInstitutionPermitId == Guid.Empty ? "无" : i.MmedicalInstitutionPermitOutDate.ToLongDateString(),
                         MmedicalInstitutionLCID = i.MmedicalInstitutionPermitId,
                         LnstitutionLegalPersonLC = i.LnstitutionLegalPersonLicenseId == Guid.Empty ? "无" : i.LnstitutionLegalPersonLicenseOutDate.ToLongDateString(),
                         LnstitutionLegalPersonLCID = i.LnstitutionLegalPersonLicenseId
                         #endregion
                     }).ToList();
            #endregion
            this.dataGridView1.DataSource = new BindingCollection<PurchaseUnitShow>(c.OrderBy(r=>r.Name).ToList());
        }

        private void GetQualificFileList()
        {
            this.ListQ.Add(new QualificFileName { Name = "全部", Value = "" });
            this.ListQ.Add(new QualificFileName { Name = "质量协议书有效期止", Value = "1" });
            this.ListQ.Add(new QualificFileName { Name = "法人委托书有效期止", Value = "2" });
            this.ListQ.Add(new QualificFileName { Name = "药品经营许可证", Value = "3" });
            this.ListQ.Add(new QualificFileName { Name = "GMP证书", Value = "4" });
            this.ListQ.Add(new QualificFileName { Name = "营业执照", Value = "5" });
            this.ListQ.Add(new QualificFileName { Name = "药品生产许可证", Value = "6" });
            this.ListQ.Add(new QualificFileName { Name = "GSP证书", Value = "7" });
            this.ListQ.Add(new QualificFileName { Name = "器械生产许可证", Value = "8" });
            this.ListQ.Add(new QualificFileName { Name = "器械经营许可证", Value = "9" });
            this.ListQ.Add(new QualificFileName { Name = "卫生许可证", Value = "10" });
            this.ListQ.Add(new QualificFileName { Name = "税务登记证", Value = "11" });
            this.ListQ.Add(new QualificFileName { Name = "组织机构代码证", Value = "12" });
            this.ListQ.Add(new QualificFileName { Name = "食品流通许可证", Value = "13" });
            this.ListQ.Add(new QualificFileName { Name = "医疗机构执业许可证", Value = "14" });
            this.ListQ.Add(new QualificFileName { Name = "事业单位法人证书", Value = "15" });
        }
        private void SetColumns()
        {
            #region
            this.dataGridView1.Columns.Add("Name", "单位名称");

            this.dataGridView1.Columns.Add("LastAnnualDte", "最新年检日期");
            this.dataGridView1.Columns.Add("IsQualityAgreementOut", "质量协议书是否过期");
            this.dataGridView1.Columns.Add("QualityAgreementOutdate", "质量协议书有效期止");
            this.dataGridView1.Columns.Add("IsAttorneyAattorneyOut", "法人委托书是否过期");
            this.dataGridView1.Columns.Add("AttorneyAattorneyOutdate", "法人委托书有效期止");
            #endregion
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

        class QualificFileName
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, this.IsSupplyer ? "供货单位" : "客户单位" + "资质近效期列表");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.IsSupplyer) 
                this.BindGridSupplyers();
            else
                this.BindGridPurchaser();
        }
    }
}
