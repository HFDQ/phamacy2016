using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Word;

namespace BugsBox.Pharmacy.AppClient
{
    public class CreateWinWord
    {
        public List<Models.User> ListUsers { get; set; }
        public UI.Forms.BaseDataManage.bool2String b { get; set; }
        public Business.Models.DrugInfoModel d { get; set; }

        public Business.Models.InstrumentsModel Inst { get; set; }

        public Business.Models.FoodModel Food { get; set; }
        public UI.Forms.BaseDataManage.PurchaseUnitShow p { get; set; }

        Pharmacy.AppClient.UI.BaseFunctionForm baseform = new UI.BaseFunctionForm();
        string msg = string.Empty;

        public CreateWinWord()
        {

        }
        /// <summary>
        /// 导出审批表word
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="Type">0-首营供货商，1-首营客户，2-首营药品</param>
        /// <returns></returns>
        public bool CreateWord(string Filename, string Name, int Type)
        {
            Word._Application oWord = new Word.Application();
            Word._Document oDoc = null;
            try
            {
                object oMissing = System.Reflection.Missing.Value;

                oWord.Visible = false;
                object oTemplate = Filename;
                oDoc = oWord.Documents.Open(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);
                oDoc.Activate();

                #region 这是首营信息们
                if (b != null)
                {
                    this.insertMarks(oDoc, 0);
                    this.insertGsp(oDoc, b.GSPLCID, b.id);
                    this.insertMedicineBussiness(oDoc, b.MedicineBusinessLCID);
                    this.insertBussiness(oDoc, b.BusinessLCID);
                    this.insertOrg(oDoc, b.OrganizationCodeLCID);
                    this.insertTax(oDoc, b.TaxRegisterLCID);
                    this.insertInstB(oDoc, b.InstrumentsBusinessLCID);
                    this.insertInstP(oDoc, b.InstrumentsProductionLCID);
                    this.insertHealth(oDoc, b.HealthLCID);
                    this.InsertGMP(oDoc, b.GMPLCID);
                    this.insertDelegate(oDoc);
                    this.insertSCXKZ(oDoc, b.MedicineProductionLCID);
                    this.insertQualityAgreement(oDoc);
                    this.insertBank(oDoc);

                    Service.Models.QueryApprovalFlowRecordModel aq = new Service.Models.QueryApprovalFlowRecordModel
                    {
                        FlowId = b.ApprovalFlowId
                    };

                    var c = baseform.PharmacyDatabaseService.SearchApprovalFlowRecordsByQueryModel(out msg, aq).OrderBy(r => r.ApproveTime).ToList();

                    if (oDoc.Bookmarks["flow1"] != null)
                    {
                        for (int i = 0; i < c.Count; i++)
                        {
                            oDoc.Bookmarks["flow" + (i + 1)].Select();
                            oDoc.Bookmarks["flow" + (i + 1)].Range.Text = c[i].Comment;
                            var o = ListUsers.Where(r => r.Id == c[i].ApproveUserId).FirstOrDefault();

                            oDoc.Bookmarks["flowuser" + (i + 1)].Range.Text = o != null ? o.Employee.Name : "" + "  " + c[i].ApproveTime.ToLongDateString();
                        }
                    }
                }

                if (p != null)
                {
                    this.insertPurchaseBasicInfo(oDoc);
                    this.insertGsp(oDoc, p.GSPLCID, p.Id);
                    this.insertMedicineBussiness(oDoc, p.MedicineBusinessLCID);
                    this.insertBussiness(oDoc, p.BusinessLCID);
                    this.insertOrg(oDoc, p.OrganizationCodeLCID);
                    this.insertTax(oDoc, p.TaxRegisterLCID);
                    this.insertInstB(oDoc, p.InstrumentsBusinessLCID);
                    this.insertInstP(oDoc, p.InstrumentsProductionLCID);
                    this.insertHealth(oDoc, p.HealthLCID);
                    this.InsertGMP(oDoc, p.GMPLCID);
                    this.insertLn(oDoc, p.LnstitutionLegalPersonLCID);
                    this.InsertMMInst(oDoc, p.MmedicalInstitutionLCID);
                    this.insertDelegate(oDoc);
                    this.insertQualityAgreement(oDoc);
                }


                if (d != null)
                {
                    if (d.BusinessScopeCode == "中药材" || d.BusinessScopeCode == "中药饮片")
                    {
                        oDoc.Bookmarks["D1"].Range.Text = d.ProductGeneralName;
                        oDoc.Bookmarks["D3"].Range.Text = d.LicensePermissionNumber;

                        oDoc.Bookmarks["D6"].Range.Text = d.DocCode;
                        oDoc.Bookmarks["D13"].Range.Text = d.DictionarySpecificationCode;
                        oDoc.Bookmarks["D15"].Range.Text = d.Origin;
                        oDoc.Bookmarks["D21"].Range.Text = d.DrugStorageTypeCode;
                        oDoc.Bookmarks["D37"].Range.Text = d.ValidPeriod + "个月";
                        oDoc.Bookmarks["D48"].Range.Text = string.Format("{0:D}", d.CreateTime);
                    }
                    else
                    {
                        if (d != null)
                        {
                            this.InsertDrugInfo(oDoc);
                        }

                    }
                }


                #region 医疗器械信息
                if (Inst != null)
                {
                    oDoc.Bookmarks["T1"].Select();
                    oDoc.Bookmarks["T1"].Range.Text = BugsBox.Pharmacy.AppClient.Common.PharmacyClientConfig.Config.Store.Name;

                    oDoc.Bookmarks["D1"].Range.Text = Inst.ProductGeneralName;
                    oDoc.Bookmarks["D2"].Range.Text = Inst.LicensePermissionNumber;
                    oDoc.Bookmarks["D3"].Range.Text = Inst.PerformanceStandards;
                    oDoc.Bookmarks["D4"].Range.Text = Inst.StandardCode;
                    oDoc.Bookmarks["D5"].Range.Text = Inst.Code;
                    oDoc.Bookmarks["D6"].Range.Text = Inst.DocCode;
                    oDoc.Bookmarks["D7"].Range.Text = Inst.Pinyin;
                    oDoc.Bookmarks["D8"].Range.Text = Inst.BarCode;
                    oDoc.Bookmarks["D11"].Range.Text = Inst.DictionaryMeasurementUnitCode;
                    oDoc.Bookmarks["D12"].Range.Text = Inst.DictionaryDosageCode;
                    oDoc.Bookmarks["D13"].Range.Text = Inst.DictionarySpecificationCode;
                    oDoc.Bookmarks["D14"].Range.Text = Inst.FactoryName;
                    oDoc.Bookmarks["D15"].Range.Text = Inst.Contact;
                    oDoc.Bookmarks["D16"].Range.Text = Inst.BusinessScopeCode;
                    oDoc.Bookmarks["D17"].Range.Text = Inst.IsApproval;
                    oDoc.Bookmarks["D18"].Range.Text = Inst.Valid;
                    oDoc.Bookmarks["D19"].Range.Text = Inst.WareHouses;
                    oDoc.Bookmarks["D20"].Range.Text = Inst.WareHouseZone;
                    oDoc.Bookmarks["D21"].Range.Text = Inst.DrugStorageTypeCode;
                    oDoc.Bookmarks["D22"].Range.Text = Inst.MaxInventoryCount.ToString();
                    oDoc.Bookmarks["D23"].Range.Text = Inst.MinInventoryCount.ToString();
                    oDoc.Bookmarks["D24"].Range.Text = Inst.ValidPeriod.ToString() + "个月";
                    oDoc.Bookmarks["D25"].Range.Text = Inst.DrugCategoryCode;
                    oDoc.Bookmarks["D26"].Range.Text = Inst.Price.ToString();
                    oDoc.Bookmarks["D27"].Range.Text = Inst.SalePrice.ToString();
                    oDoc.Bookmarks["D28"].Range.Text = Inst.LimitedUpPrice.ToString();
                    oDoc.Bookmarks["D29"].Range.Text = Inst.LimitedLowPrice.ToString();
                    // oDoc.Bookmarks["D31"].Range.Text = Inst.Description;
                    oDoc.Bookmarks["D48"].Range.Text = Inst.CreateTime.ToString();
                    oDoc.Bookmarks["D49"].Range.Text = Inst.CreateUserName;

                }
                #endregion

                #region 保健食品信息
                if (this.Food != null)
                {
                    oDoc.Bookmarks["T1"].Select();
                    oDoc.Bookmarks["T1"].Range.Text = BugsBox.Pharmacy.AppClient.Common.PharmacyClientConfig.Config.Store.Name;

                    oDoc.Bookmarks["D1"].Range.Text = Food.ProductGeneralName;
                    oDoc.Bookmarks["D2"].Range.Text = Food.LicensePermissionNumber;
                    oDoc.Bookmarks["D3"].Range.Text = Food.PerformanceStandards;
                    oDoc.Bookmarks["D4"].Range.Text = Food.LicensePermissionOutValidDate.ToShortDateString();
                    oDoc.Bookmarks["D5"].Range.Text = Food.Code;
                    oDoc.Bookmarks["D6"].Range.Text = Food.DocCode;
                    oDoc.Bookmarks["D7"].Range.Text = Food.Pinyin;
                    oDoc.Bookmarks["D8"].Range.Text = Food.BarCode;
                    oDoc.Bookmarks["D11"].Range.Text = Food.DictionaryMeasurementUnitCode;
                    oDoc.Bookmarks["D12"].Range.Text = Food.DictionaryDosageCode;
                    oDoc.Bookmarks["D13"].Range.Text = Food.DictionarySpecificationCode;
                    oDoc.Bookmarks["D14"].Range.Text = Food.FactoryName;
                    oDoc.Bookmarks["D15"].Range.Text = Food.Contact;
                    oDoc.Bookmarks["D16"].Range.Text = Food.BusinessScopeCode;
                    oDoc.Bookmarks["D17"].Range.Text = Food.IsApproval;
                    oDoc.Bookmarks["D18"].Range.Text = Food.Valid;
                    oDoc.Bookmarks["D19"].Range.Text = Food.WareHouses;
                    oDoc.Bookmarks["D20"].Range.Text = Food.WareHouseZone;
                    oDoc.Bookmarks["D21"].Range.Text = Food.DrugStorageTypeCode;
                    oDoc.Bookmarks["D22"].Range.Text = Food.MaxInventoryCount.ToString();
                    oDoc.Bookmarks["D23"].Range.Text = Food.MinInventoryCount.ToString();
                    oDoc.Bookmarks["D24"].Range.Text = Food.ValidPeriod.ToString() + "个月";
                    oDoc.Bookmarks["D25"].Range.Text = Food.IsImport;



                    oDoc.Bookmarks["D26"].Range.Text = Food.Price.ToString();
                    oDoc.Bookmarks["D27"].Range.Text = Food.SalePrice.ToString();
                    oDoc.Bookmarks["D28"].Range.Text = Food.LimitedUpPrice.ToString();
                    oDoc.Bookmarks["D29"].Range.Text = Food.LimitedLowPrice.ToString();

                    oDoc.Bookmarks["D30"].Range.Text = Food.Origin;
                    oDoc.Bookmarks["D31"].Range.Text = Food.Description;

                    oDoc.Bookmarks["D48"].Range.Text = Food.CreateTime.ToString();
                    oDoc.Bookmarks["D49"].Range.Text = Food.CreateUserName;

                }

                #endregion

                #endregion

                #region word保存
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "Word Document(*.doc)|*.doc";
                sfd.DefaultExt = "Word Document(*.doc)|*.doc";
                sfd.FileName = Name + DateTime.Now.Ticks + ".doc";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    object filename = sfd.FileName;
                    oDoc.SaveAs(ref filename, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);
                    oDoc.Close(ref oMissing, ref oMissing, ref oMissing);
                    if (oDoc != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc);
                        oDoc = null;
                    }
                    if (oWord != null)
                    {
                        oWord.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord);
                        oWord = null;
                    }
                    return true;
                }
                else
                {
                    if (oDoc != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc);
                        oDoc = null;
                    }
                    if (oWord != null)
                    {
                        oWord.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord);
                        oWord = null;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(Name + "：审批信息表导出失败！" + e.Message);
                if (oWord != null)
                {
                    oWord.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord);
                    oWord = null;
                }
                if (oDoc != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc);
                    oDoc = null;
                }
                return false;
            }
            finally
            {
                if (oWord != null)
                {
                    oWord.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord);
                    oWord = null;
                }
                if (oDoc != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc);
                    oDoc = null;
                }
            }
            #endregion
        }



        private void insertMarks(Word._Document oDoc, int type)
        {
            oDoc.Bookmarks["M0"].Select();
            oDoc.Bookmarks["M0"].Range.Text = BugsBox.Pharmacy.AppClient.Common.PharmacyClientConfig.Config.Store.Name;
            oDoc.Bookmarks["M1"].Range.Text = b.CreateDate;
            oDoc.Bookmarks["M2"].Range.Text = b.Code;
            oDoc.Bookmarks["M3"].Range.Text = b.Name;
            oDoc.Bookmarks["M4"].Range.Text = b.UnitType;
            oDoc.Bookmarks["M5"].Range.Text = b.Code;
            oDoc.Bookmarks["M6"].Range.Text = b.SupplyCateGory;
            oDoc.Bookmarks["M7"].Range.Text = b.DetailedAddress;
            oDoc.Bookmarks["M8"].Range.Text = b.ContactName;
            oDoc.Bookmarks["M9"].Range.Text = b.ContactTel;
            oDoc.Bookmarks["M10"].Range.Text = b.Fax;
            oDoc.Bookmarks["M11"].Range.Text = b.PinyinCode;
        }

        private void insertPurchaseBasicInfo(Word._Document oDoc)
        {
            oDoc.Bookmarks["M0"].Select();
            oDoc.Bookmarks["M0"].Range.Text = BugsBox.Pharmacy.AppClient.Common.PharmacyClientConfig.Config.Store.Name;
            oDoc.Bookmarks["M1"].Range.Text = p.CreateDate;
            oDoc.Bookmarks["M2"].Range.Text = p.Code;
            oDoc.Bookmarks["B1"].Range.Text = p.Name;
            oDoc.Bookmarks["B2"].Range.Text = p.Code;
            oDoc.Bookmarks["B3"].Range.Text = p.UnitType;
            oDoc.Bookmarks["B4"].Range.Text = p.LegalPerson;
            oDoc.Bookmarks["B5"].Range.Text = p.ContactName;
            oDoc.Bookmarks["B6"].Range.Text = p.Fax;
            oDoc.Bookmarks["B7"].Range.Text = p.PinyinCode;
            oDoc.Bookmarks["B8"].Range.Text = p.Email;
            oDoc.Bookmarks["B9"].Range.Text = p.WebAddress;
            oDoc.Bookmarks["B10"].Range.Text = p.District;
            oDoc.Bookmarks["B11"].Range.Text = string.Empty;
            oDoc.Bookmarks["B12"].Range.Text = p.ReceiveAddress;
            oDoc.Bookmarks["B13"].Range.Text = p.DetailedAddress;
        }

        private void insertGsp(Word._Document oDoc, Guid id, Guid UnitId)
        {
            if (id == Guid.Empty) return;
            Models.GSPLicense gsp = baseform.PharmacyDatabaseService.GetGSPLicense(out msg, id);
            if (gsp == null) return;


            if (p.UnitType != "医疗机构")
            {

                oDoc.Bookmarks["GSP1"].Select();
                oDoc.Bookmarks["GSP1"].Range.Text = gsp.Name;
                oDoc.Bookmarks["GSP2"].Range.Text = gsp.LicenseCode;
                oDoc.Bookmarks["GSP3"].Range.Text = gsp.UnitName;
                oDoc.Bookmarks["GSP4"].Range.Text = gsp.IssuanceOrg;
                oDoc.Bookmarks["GSP5"].Range.Text = gsp.RegAddress;

                oDoc.Bookmarks["GSP6"].Range.Text = gsp.IssuanceDate.ToLongDateString();
                oDoc.Bookmarks["GSP7"].Range.Text = gsp.OutDate.ToLongDateString();

                oDoc.Bookmarks["GSP8"].Range.Text = baseform.PharmacyDatabaseService.GetBusinessType(out msg, gsp.BusinessTypeId).Name;
                oDoc.Bookmarks["GSP9"].Range.Text = gsp.Header;
                oDoc.Bookmarks["GSP10"].Range.Text = gsp.LegalPerson;
                oDoc.Bookmarks["GSP11"].Range.Text = gsp.QualityHeader;
            }
            oDoc.Bookmarks["GSP12"].Range.Text = gsp.WarehouseAddress;
            string[] Bscope = b == null ? baseform.PharmacyDatabaseService.GetBusinessScopeCodesByPurchaseUnitGuid(out msg, UnitId) : baseform.PharmacyDatabaseService.GetBusinessScopeCodesBySupplyUnitGuid(out msg, UnitId); ;
            oDoc.Bookmarks["GSP13"].Range.Text = string.Join(",", Bscope);
        }

        private void insertMedicineBussiness(Word._Document oDoc, Guid id)
        {
            if (id == Guid.Empty) return;
            var mb = baseform.PharmacyDatabaseService.GetMedicineBusinessLicense(out msg, id);
            if (mb == null) return;
            oDoc.Bookmarks["MB1"].Select();
            oDoc.Bookmarks["MB1"].Range.Text = mb.Name;
            oDoc.Bookmarks["MB2"].Range.Text = mb.LicenseCode;
            oDoc.Bookmarks["MB3"].Range.Text = mb.UnitName;
            oDoc.Bookmarks["MB4"].Range.Text = mb.RegAddress;
            oDoc.Bookmarks["MB5"].Range.Text = mb.IssuanceOrg;
            oDoc.Bookmarks["MB6"].Range.Text = mb.IssuanceDate.ToLongDateString();
            oDoc.Bookmarks["MB7"].Range.Text = mb.OutDate.ToLongDateString();
            oDoc.Bookmarks["MB8"].Range.Text = mb.LegalPerson;
            oDoc.Bookmarks["MB9"].Range.Text = mb.Header;
            oDoc.Bookmarks["MB10"].Range.Text = mb.QualityHeader;
            oDoc.Bookmarks["MB11"].Range.Text = mb.WarehouseAddress;
            oDoc.Bookmarks["MB12"].Range.Text = mb.BusinessScope;
        }

        private void insertBussiness(Word._Document oDoc, Guid id)
        {
            if (id == Guid.Empty) return;
            var c = baseform.PharmacyDatabaseService.GetBusinessLicense(out msg, id);
            oDoc.Bookmarks["YYZZ1"].Select();
            oDoc.Bookmarks["YYZZ1"].Range.Text = c.Name;
            oDoc.Bookmarks["YYZZ2"].Range.Text = c.LicenseCode;
            oDoc.Bookmarks["YYZZ3"].Range.Text = c.UnitName;
            oDoc.Bookmarks["YYZZ4"].Range.Text = c.RegAddress;
            oDoc.Bookmarks["YYZZ5"].Range.Text = c.IssuanceOrg;
            oDoc.Bookmarks["YYZZ6"].Range.Text = c.IssuanceDate.ToLongDateString();
            oDoc.Bookmarks["YYZZ7"].Range.Text = c.RegisteredCapital.ToString();
            oDoc.Bookmarks["YYZZ8"].Range.Text = c.PaidinCapital.ToString();
            oDoc.Bookmarks["YYZZ9"].Range.Text = c.CorporateNature;
            oDoc.Bookmarks["YYZZ10"].Range.Text = c.EstablishmentDate.ToLongDateString();
            oDoc.Bookmarks["YYZZ11"].Range.Text = c.BusinessScope;
            oDoc.Bookmarks["YYZZ12"].Range.Text = c.OutDate.ToLongDateString();
        }

        private void insertOrg(Word._Document oDoc, Guid id)
        {
            if (id == Guid.Empty) return;
            var c = baseform.PharmacyDatabaseService.GetOrganizationCodeLicense(out msg, id);
            if (c == null) return;
            oDoc.Bookmarks["ZZJG1"].Select();
            oDoc.Bookmarks["ZZJG1"].Range.Text = c.Name;
            oDoc.Bookmarks["ZZJG2"].Range.Text = c.LicenseCode;
            oDoc.Bookmarks["ZZJG3"].Range.Text = c.UnitName;
            oDoc.Bookmarks["ZZJG4"].Range.Text = c.OrgnizationType;
            oDoc.Bookmarks["ZZJG5"].Range.Text = c.IssuanceOrg;
            oDoc.Bookmarks["ZZJG6"].Range.Text = c.Code;
            oDoc.Bookmarks["ZZJG7"].Range.Text = c.RegAddress;
            oDoc.Bookmarks["ZZJG8"].Range.Text = c.IssuanceDate.ToLongDateString();
            oDoc.Bookmarks["ZZJG9"].Range.Text = "无";
            oDoc.Bookmarks["ZZJG10"].Range.Text = c.RegisterNo;
            oDoc.Bookmarks["ZZJG11"].Range.Text = c.DocNumber;
        }

        private void insertTax(Word._Document oDoc, Guid id)
        {
            if (id == Guid.Empty) return;
            var c = baseform.PharmacyDatabaseService.GetTaxRegisterLicense(out msg, id);
            if (c == null) return;
            oDoc.Bookmarks["SW1"].Select();
            oDoc.Bookmarks["SW1"].Range.Text = c.Name;
            oDoc.Bookmarks["SW2"].Range.Text = c.LicenseCode;
            oDoc.Bookmarks["SW3"].Range.Text = c.taxpayerName;
            oDoc.Bookmarks["SW4"].Range.Text = c.taxpayerNumber;
            oDoc.Bookmarks["SW5"].Range.Text = c.LegalPerson;
            oDoc.Bookmarks["SW6"].Range.Text = c.DocNumber;
            oDoc.Bookmarks["SW7"].Range.Text = c.IssuanceOrg;
            oDoc.Bookmarks["SW8"].Range.Text = c.BusinessScope;
            oDoc.Bookmarks["SW9"].Range.Text = c.RegAddress;
            oDoc.Bookmarks["SW10"].Range.Text = c.IssuanceDate.ToLongDateString();
            oDoc.Bookmarks["SW11"].Range.Text = c.OutDate.ToLongDateString();
        }

        private void insertInstB(Word._Document oDoc, Guid id)
        {
            if (id == Guid.Empty) return;
            var c = baseform.PharmacyDatabaseService.GetInstrumentsBusinessLicense(out msg, id);
            if (c == null) return;
            oDoc.Bookmarks["QXJY1"].Select();
            oDoc.Bookmarks["QXJY1"].Range.Text = c.Name;
            oDoc.Bookmarks["QXJY2"].Range.Text = c.LicenseCode;
            oDoc.Bookmarks["QXJY3"].Range.Text = c.UnitName;
            oDoc.Bookmarks["QXJY4"].Range.Text = c.IssuanceOrg;
            oDoc.Bookmarks["QXJY5"].Range.Text = c.RegAddress;
            oDoc.Bookmarks["QXJY6"].Range.Text = c.IssuanceDate.ToLongDateString();
            oDoc.Bookmarks["QXJY7"].Range.Text = c.OutDate.ToLongDateString();
            oDoc.Bookmarks["QXJY8"].Range.Text = c.LegalPerson;
            oDoc.Bookmarks["QXJY9"].Range.Text = c.Header;
            oDoc.Bookmarks["QXJY10"].Range.Text = c.QualityHeader;
            oDoc.Bookmarks["QXJY11"].Range.Text = c.BusinessScope;
            oDoc.Bookmarks["QXJY12"].Range.Text = c.WarehouseAddress;
        }

        private void insertInstP(Word._Document oDoc, Guid id)
        {
            if (id == Guid.Empty) return;
            var c = baseform.PharmacyDatabaseService.GetInstrumentsProductionLicense(out msg, id);
            if (c == null) return;
            oDoc.Bookmarks["QXSC1"].Select();
            oDoc.Bookmarks["QXSC1"].Range.Text = c.Name;
            oDoc.Bookmarks["QXSC2"].Range.Text = c.LicenseCode;
            oDoc.Bookmarks["QXSC3"].Range.Text = c.UnitName;
            oDoc.Bookmarks["QXSC4"].Range.Text = c.IssuanceOrg;
            oDoc.Bookmarks["QXSC5"].Range.Text = c.RegAddress;
            oDoc.Bookmarks["QXSC6"].Range.Text = c.IssuanceDate.ToLongDateString();
            oDoc.Bookmarks["QXSC7"].Range.Text = c.OutDate.ToLongDateString();
            oDoc.Bookmarks["QXSC8"].Range.Text = c.LegalPerson;
            oDoc.Bookmarks["QXSC9"].Range.Text = c.Header;
            oDoc.Bookmarks["QXSC10"].Range.Text = c.ProductScope;
            oDoc.Bookmarks["QXSC11"].Range.Text = c.ProductAddress;
        }

        private void insertHealth(Word._Document oDoc, Guid id)
        {
            if (id == Guid.Empty) return;
            var c = baseform.PharmacyDatabaseService.GetHealthLicense(out msg, id);
            if (c == null) return;
            oDoc.Bookmarks["WS1"].Select();
            oDoc.Bookmarks["WS1"].Range.Text = c.Name;
            oDoc.Bookmarks["WS2"].Range.Text = c.LicenseCode;
            oDoc.Bookmarks["WS3"].Range.Text = c.UnitName;
            oDoc.Bookmarks["WS4"].Range.Text = c.Header;
            oDoc.Bookmarks["WS5"].Range.Text = c.RegAddress;
            oDoc.Bookmarks["WS6"].Range.Text = c.LicenseContent;
            oDoc.Bookmarks["WS7"].Range.Text = c.DocNumber;
            oDoc.Bookmarks["WS8"].Range.Text = c.OutDate.ToLongDateString();
            oDoc.Bookmarks["WS9"].Range.Text = c.IssuanceOrg;
        }

        private void InsertGMP(Word._Document oDoc, Guid id)
        {
            if (id == Guid.Empty) return;
            var c = baseform.PharmacyDatabaseService.GetGMPLicense(out msg, id);
            if (c == null) return;
            oDoc.Bookmarks["GMP1"].Select();
            oDoc.Bookmarks["GMP1"].Range.Text = c.Name;
            oDoc.Bookmarks["GMP2"].Range.Text = c.LicenseCode;
            oDoc.Bookmarks["GMP3"].Range.Text = c.UnitName;
            oDoc.Bookmarks["GMP4"].Range.Text = c.IssuanceOrg;
            oDoc.Bookmarks["GMP5"].Range.Text = c.IssuanceDate.ToLongDateString();
            oDoc.Bookmarks["GMP6"].Range.Text = c.OutDate.ToLongDateString();
            oDoc.Bookmarks["GMP7"].Range.Text = c.RegAddress;
            oDoc.Bookmarks["GMP8"].Range.Text = c.CertificationScope;
        }
        //委托书
        private void insertDelegate(Word._Document oDoc)
        {
            string delegateDetail = b == null ? p.DelegateContract : b.DelegateContent;
            var c = delegateDetail.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            string dw = string.Empty;
            string fr = string.Empty;
            string wtr = string.Empty;
            string wtrzh = string.Empty;
            string wtqs = string.Empty;
            string wtjs = string.Empty;
            string dah = string.Empty;

            foreach (var r in c)
            {
                var detail = r.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                dw += detail[0] + "\r\n";
                fr += detail[2] + "\r\n";
                wtr += detail[3] + "\r\n";
                wtrzh += detail[4] + "\r\n";
                DateTime dts = DateTime.Now;
                DateTime.TryParseExact(detail[5], "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dts);
                wtqs += dts.ToLongDateString() + "\r\n";
                DateTime.TryParseExact(detail[6], "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dts);
                wtjs += dts.ToLongDateString() + "\r\n";
                if (detail.Count() >= 8)
                    dah += detail[7] == null ? "\r\n" : detail[7] + "\r\n";
            }

            oDoc.Bookmarks["WT1"].Select();
            oDoc.Bookmarks["WT1"].Range.Text = dw.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["WT3"].Range.Text = fr.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["WT4"].Range.Text = wtr.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["WT5"].Range.Text = wtrzh.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["WT6"].Range.Text = dah.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["WT7"].Range.Text = wtqs.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["WT8"].Range.Text = wtjs.Trim(new char[] { '\r', '\n' });
        }
        //质量协议书
        private void insertQualityAgreement(Word._Document oDoc)
        {
            string qa = b == null ? p.QualityAgreement : b.QualityAgreement;
            var c = qa.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            string unitName = string.Empty;
            string SignDate = "";
            string outvalidDate = "";
            string DocNumber = "";

            c.ForEach(r =>
            {
                var detail = r.Split(new string[] { "," }, StringSplitOptions.None);
                unitName += detail[0] + "\r\n";
                DateTime dt = DateTime.Now;
                DateTime.TryParseExact(detail[2], "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dt);
                SignDate += dt.ToLongDateString() + "\r\n";
                DateTime.TryParseExact(detail[3], "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dt);
                outvalidDate += dt.ToLongDateString() + "\r\n";
                DocNumber += detail[4] + "\r\n";
            });
            oDoc.Bookmarks["QA1"].Select();
            oDoc.Bookmarks["QA1"].Range.Text = unitName.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["QA2"].Range.Text = SignDate.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["QA3"].Range.Text = outvalidDate.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["QA4"].Range.Text = DocNumber.Trim(new char[] { '\r', '\n' });
        }
        //银行账号
        private void insertBank(Word._Document oDoc)
        {

            string bank = b.BankAccount;
            var c = bank.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            string unitName = "";
            string bankName = "";
            string acount = "";
            string memo = "";

            c.ForEach(r =>
            {
                var detail = r.Split(new string[] { "," }, StringSplitOptions.None);
                unitName += detail[0] + "\r\n";
                bankName += detail[1] + "\r\n";
                acount += detail[2] + "\r\n";
                memo += detail[3] + "\r\n";
            });
            oDoc.Bookmarks["BK1"].Select();
            oDoc.Bookmarks["BK1"].Range.Text = unitName.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["BK2"].Range.Text = bankName.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["BK3"].Range.Text = acount.Trim(new char[] { '\r', '\n' });
            oDoc.Bookmarks["BK4"].Range.Text = memo.Trim(new char[] { '\r', '\n' });

        }

        private void InsertDrugInfo(Word._Document oDoc)
        {
            oDoc.Bookmarks["T1"].Select();
            oDoc.Bookmarks["T1"].Range.Text = BugsBox.Pharmacy.AppClient.Common.PharmacyClientConfig.Config.Store.Name;
            System.Reflection.PropertyInfo[] pinfos = d.GetType().GetProperties();
            for (int i = 1; i <= 49; i++)
            {
                var v = pinfos[i].GetValue(d, null);
                string idx = "D" + i.ToString();
                oDoc.Bookmarks[idx].Select();
                oDoc.Bookmarks[idx].Range.Text = v == null ? "" : v.ToString();
            }
        }

        private void InsertMMInst(Word._Document oDoc, Guid id)
        {
            if (id == Guid.Empty) return;
            Models.MmedicalInstitutionPermit mp = new Models.MmedicalInstitutionPermit();
            mp.Id = id;
            var c = baseform.PharmacyDatabaseService.GetMmedicalInstitutionPermit(id, out msg).FirstOrDefault();
            if (c == null) return;
            oDoc.Bookmarks["JG1"].Select();
            oDoc.Bookmarks["JG1"].Range.Text = c.Name;
            oDoc.Bookmarks["JG2"].Range.Text = c.UnitName;
            oDoc.Bookmarks["JG3"].Range.Text = c.LegalPerson;
            oDoc.Bookmarks["JG4"].Range.Text = c.LicenseCode;
            oDoc.Bookmarks["JG5"].Range.Text = c.RegAddress;
            oDoc.Bookmarks["JG6"].Range.Text = c.RegisterAddress;
            oDoc.Bookmarks["JG7"].Range.Text = c.OgnTpye;
            oDoc.Bookmarks["JG8"].Range.Text = c.WarehouseAddress;
            oDoc.Bookmarks["JG9"].Range.Text = c.IssuanceOrg;
            oDoc.Bookmarks["JG10"].Range.Text = c.DocNumber;
            oDoc.Bookmarks["JG11"].Range.Text = c.IssuanceDate.ToLongDateString();
            oDoc.Bookmarks["JG12"].Range.Text = c.OutDate.ToLongDateString();
            oDoc.Bookmarks["JG13"].Range.Text = c.UseMedicalScope;
            oDoc.Bookmarks["JG14"].Range.Text = c.memo;
        }

        private void insertLn(Word._Document oDoc, Guid id)
        {
            if (id == Guid.Empty) return;
            Models.LnstitutionLegalPersonLicense ln = new Models.LnstitutionLegalPersonLicense();
            ln.Id = id;
            var c = baseform.PharmacyDatabaseService.GetLnstitutionLegalPersonLicense(ln, out msg).FirstOrDefault();
            if (c == null) return;

            oDoc.Bookmarks["SY1"].Select();
            oDoc.Bookmarks["SY1"].Range.Text = c.Name;
            oDoc.Bookmarks["SY2"].Range.Text = c.LicenseCode;
            oDoc.Bookmarks["SY3"].Range.Text = c.UnitName;
            oDoc.Bookmarks["SY4"].Range.Text = c.LegalPerson;
            oDoc.Bookmarks["SY5"].Range.Text = c.CertificateName;
            oDoc.Bookmarks["SY6"].Range.Text = c.FundsSource;
            oDoc.Bookmarks["SY7"].Range.Text = c.InitiaFund;
            oDoc.Bookmarks["SY8"].Range.Text = c.Address;
            oDoc.Bookmarks["SY9"].Range.Text = c.BussinessRange;
            oDoc.Bookmarks["SY10"].Range.Text = c.IssuanceOrg;
            oDoc.Bookmarks["SY11"].Range.Text = c.DocNumber;
            oDoc.Bookmarks["SY12"].Range.Text = c.ManageOrg;
            oDoc.Bookmarks["SY13"].Range.Text = c.IssuanceDate.ToLongDateString();
            oDoc.Bookmarks["SY14"].Range.Text = c.OutDate.ToLongDateString();
            oDoc.Bookmarks["SY15"].Range.Text = c.UseMedicalScope;
            oDoc.Bookmarks["SY16"].Range.Text = c.memo;
        }

        private void insertSCXKZ(Word._Document oDoc, Guid id)
        {
            if (id == Guid.Empty) return;
            var c = baseform.PharmacyDatabaseService.GetMedicineProductionLicense(out msg, id);
            if (c == null) return;

            oDoc.Bookmarks["SCXKZ1"].Select();
            oDoc.Bookmarks["SCXKZ1"].Range.Text = c.Name;
            oDoc.Bookmarks["SCXKZ2"].Range.Text = c.LicenseCode;
            oDoc.Bookmarks["SCXKZ3"].Range.Text = b.Name;
            oDoc.Bookmarks["SCXKZ4"].Range.Text = c.RegAddress;
            oDoc.Bookmarks["SCXKZ5"].Range.Text = c.IssuanceOrg;
            oDoc.Bookmarks["SCXKZ6"].Range.Text = c.IssuanceDate.ToLongDateString();
            oDoc.Bookmarks["SCXKZ7"].Range.Text = c.OutDate.ToLongDateString();
            oDoc.Bookmarks["SCXKZ8"].Range.Text = c.LegalPerson;
            oDoc.Bookmarks["SCXKZ9"].Range.Text = c.Header;
            oDoc.Bookmarks["SCXKZ10"].Range.Text = c.CorporateNature;
            oDoc.Bookmarks["SCXKZ11"].Range.Text = c.ProductScope;
            oDoc.Bookmarks["SCXKZ12"].Range.Text = c.ProductAddress;
            oDoc.Bookmarks["SCXKZ13"].Range.Text = c.CategoryCode;

        }
    }
}
