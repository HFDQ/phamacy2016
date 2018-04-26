using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.PS;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Service.Models;
using BugsBox.Common.Security;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.UI.Common
{
    public partial class CRUDControl
    {
        public void InitFieldValues()
        {
            _InitFieldValues.Clear();
            string msg = string.Empty;
            Rareword[] rarewords = this.PharmacyDatabaseService.AllRarewords(out msg);
            List<ListItem> rarewordItems = new List<ListItem>();
            foreach (var m in rarewords)
            {
                rarewordItems.Add(new ListItem(m.PinYin, m.Word));
            }
            _InitFieldValues.Add("Rareword", rarewordItems);

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Visible == true)
                {
                    switch (col.Name)
                    {
                        case "ModuleCatetoryId":
                            ModuleCatetory[] modulecatetoryid = this.PharmacyDatabaseService.AllModuleCatetorys(out msg);
                            List<ListItem> modulecatetoryidItems = new List<ListItem>();
                            foreach (var m in modulecatetoryid)
                            {
                                modulecatetoryidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("ModuleCatetoryId", modulecatetoryidItems);
                            break;
                        case "SupplyUnitId":
                            SupplyUnit[] supplyunitid = this.PharmacyDatabaseService.AllSupplyUnits(out msg);
                            List<ListItem> supplyunitidItems = new List<ListItem>();
                            foreach (var m in supplyunitid)
                            {
                                if (m.Enabled)
                                    supplyunitidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("SupplyUnitId", supplyunitidItems);
                            break;
                        case "PurchaseUnitId":
                            PurchaseUnit[] purchaseunitid = this.PharmacyDatabaseService.AllPurchaseUnits(out msg);
                            List<ListItem> purchaseunitidItems = new List<ListItem>();
                            foreach (var m in purchaseunitid)
                            {
                                if (m.Enabled)
                                    purchaseunitidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("PurchaseUnitId", purchaseunitidItems);
                            break;
                        case "DepartmentId":
                            Department[] departmentid = this.PharmacyDatabaseService.AllDepartments(out msg);
                            List<ListItem> departmentidItems = new List<ListItem>();
                            foreach (var m in departmentid)
                            {
                                if (m.Enabled)
                                    departmentidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("DepartmentId", departmentidItems);
                            break;

                        case "DrugCategoryId":
                            DrugCategory[] drugcategoryid = this.PharmacyDatabaseService.AllDrugCategorys(out msg);
                            List<ListItem> drugcategoryidItems = new List<ListItem>();
                            foreach (var m in drugcategoryid)
                            {
                                if (m.Enabled)
                                    drugcategoryidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("DrugCategoryId", drugcategoryidItems);
                            break;
                        case "BusinessTypeId":
                            BusinessType[] businesstypeid = this.PharmacyDatabaseService.AllBusinessTypes(out msg);
                            List<ListItem> businesstypeidItems = new List<ListItem>();
                            foreach (var m in businesstypeid)
                            {
                                if (m.Enabled)
                                    businesstypeidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("BusinessTypeId", businesstypeidItems);
                            break;
                        case "UnitTypeId":
                            UnitType[] unittypeid = this.PharmacyDatabaseService.AllUnitTypes(out msg);
                            List<ListItem> unittypeidItems = new List<ListItem>();
                            foreach (var m in unittypeid)
                            {
                                if (m.Enabled)
                                    unittypeidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("UnitTypeId", unittypeidItems);
                            break;
                        case "DistrictId":
                            District[] districtid = this.PharmacyDatabaseService.AllDistricts(out msg);
                            List<ListItem> districtidItems = new List<ListItem>();
                            foreach (var m in districtid)
                            {
                                if (m.Enabled)
                                    districtidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("DistrictId", districtidItems);
                            break;
                        case "EmployeeId":
                            Employee[] employeeid = this.PharmacyDatabaseService.AllEmployees(out msg).OrderBy(r=>r.Name).ToArray();
                            List<ListItem> employeeidItems = new List<ListItem>();
                            foreach (var m in employeeid)
                            {
                                employeeidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("EmployeeId", employeeidItems);
                            break;
                        case "WarehouseId":
                            Warehouse[] warehouseid = this.PharmacyDatabaseService.AllWarehouses(out msg);
                            List<ListItem> warehouseidItems = new List<ListItem>();
                            foreach (var m in warehouseid)
                            {
                                if (m.Enabled)
                                    warehouseidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("WarehouseId", warehouseidItems);
                            break;
                        case "DictionaryStorageTypeId":
                            DictionaryStorageType[] dictionarystoragetypeid = this.PharmacyDatabaseService.AllDictionaryStorageTypes(out msg);
                            List<ListItem> dictionarystoragetypeidItems = new List<ListItem>();
                            foreach (var m in dictionarystoragetypeid)
                            {
                                if (m.Enabled)
                                    dictionarystoragetypeidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("DictionaryStorageTypeId", dictionarystoragetypeidItems);
                            break;
                        case "DictionaryMeasurementUnitId":
                            DictionaryMeasurementUnit[] dictionarymeasurementunitid = this.PharmacyDatabaseService.AllDictionaryMeasurementUnits(out msg);
                            List<ListItem> dictionarymeasurementunitidItems = new List<ListItem>();
                            foreach (var m in dictionarymeasurementunitid)
                            {
                                if (m.Enabled)
                                    dictionarymeasurementunitidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("DictionaryMeasurementUnitId", dictionarymeasurementunitidItems);
                            break;
                        case "CreateUserId":
                            User[] createuserid = this.PharmacyDatabaseService.AllUsers(out msg);
                            List<ListItem> createuseridItems = new List<ListItem>();
                            foreach (var m in createuserid)
                            {
                                createuseridItems.Add(new ListItem(m.Id.ToString(), m.Account));
                            }
                            _InitFieldValues.Add("CreateUserId", createuseridItems);
                            break;
                        case "StoreId":
                            Store[] storeid = this.PharmacyDatabaseService.AllStores(out msg);
                            List<ListItem> storeidItems = new List<ListItem>();
                            foreach (var m in storeid)
                            {
                                if (m.Enabled)
                                    storeidItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("StoreId", storeidItems);
                            break;

                        case "WarehouseZoneTypeValue":
                            _InitFieldValues.Add("WarehouseZoneTypeValue", EnumHelper<WarehouseZoneType>.GetMapKeyValues());
                            break;
                        case "Gender":
                            List<ListItem> generItems = new List<ListItem>();
                            generItems.Add(new ListItem(ResourceStrings.Common_UnKnown, ResourceStrings.Common_UnKnown));
                            generItems.Add(new ListItem(ResourceStrings.Common_Male, ResourceStrings.Common_Male));
                            generItems.Add(new ListItem(ResourceStrings.Common_Female, ResourceStrings.Common_Female));
                            _InitFieldValues.Add("Gender", generItems);
                            break;
                        case "StoreTypeValue":
                            _InitFieldValues.Add("StoreTypeValue", EnumHelper<StoreType>.GetMapKeyValues());
                            break;
                        case "EmployStatusValue":
                            _InitFieldValues.Add("EmployStatusValue", EnumHelper<EmployStatus>.GetMapKeyValues());
                            break;
                        case "PharmacistsTitleTypeValue":
                            _InitFieldValues.Add("PharmacistsTitleTypeValue", EnumHelper<PharmacistsTitleType>.GetMapKeyValues());
                            break;
                        case "PharmacistsQualificationValue":
                            _InitFieldValues.Add("PharmacistsQualificationValue", EnumHelper<PharmacistsQualification>.GetMapKeyValues());
                            break;
                        case "OutInventoryTypeValue":
                            _InitFieldValues.Add("OutInventoryTypeValue", EnumHelper<OutInventoryType>.GetMapKeyValues());
                            break;
                        case "ApprovalTypeValue":
                            _InitFieldValues.Add("ApprovalTypeValue", EnumHelper<ApprovalType>.GetMapKeyValues());
                            break;
                        case "VehicleCategoryValue":
                            _InitFieldValues.Add("VehicleCategoryValue", EnumHelper<VehicleCategory>.GetMapKeyValues());
                            break;
                        case "AuthorizedDistrictId":
                            District[] districts = this.PharmacyDatabaseService.AllDistricts(out msg);
                            List<ListItem> districtsItems = new List<ListItem>();
                            foreach (var m in districts)
                            {
                                districtsItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("AuthorizedDistrictId", districtsItems);
                            break;
                        case "BussinessScopeId":
                            BusinessScope[] bs = this.PharmacyDatabaseService.AllBusinessScopes(out msg);
                            List<ListItem> bsItems = new List<ListItem>();
                            foreach (var m in bs)
                            {
                                if (m.Enabled)
                                    bsItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("BussinessScopeId", bsItems);
                            break;
                        case "BusinessScopeCategoryId":
                            BusinessScopeCategory[] bsc = this.PharmacyDatabaseService.AllBusinessScopeCategorys(out msg);
                            List<ListItem> bscItems = new List<ListItem>();
                            foreach (var m in bsc)
                            {
                                if (m.Enabled)
                                    bscItems.Add(new ListItem(m.Id.ToString(), m.Name));
                            }
                            _InitFieldValues.Add("BusinessScopeCategoryId", bscItems);
                            break;
                    }
                }
            }
        }

        public Entity[] AutoGeneratedSearchEntity(out string msg, Dictionary<string, object> searchConditions, out PagerInfo pageInfo)
        {
            msg = String.Empty;
            pageInfo = new PagerInfo();

            //_currentUser = AppClientContext.CurrentUser.Id;
            //listUser = PharmacyDatabaseService.GetUser(out msg, _currentUser);
            //listR = PharmacyDatabaseService.AllRoles(out msg).Where(p => p.Name == "SystemRole").FirstOrDefault();
            //listRU = PharmacyDatabaseService.GetRoleWithUserInfo(out msg, listUser.Id, listR.Id).FirstOrDefault();

            switch (GridDataSourceType)
            {
                case DataSoruceType.Store:
                    QueryStoreModel qModel0 = new QueryStoreModel();
                    BindDataToEntity(qModel0, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchStoresByQueryModel(out msg, qModel0).OrderBy(r=>r.Name).ToArray();

                case DataSoruceType.District:
                    QueryDistrictModel qModel1 = new QueryDistrictModel();
                    BindDataToEntity(qModel1, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchDistrictsByQueryModel(out msg, qModel1).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.Rareword:
                    QueryRarewordModel qModel2 = new QueryRarewordModel();
                    BindDataToEntity(qModel2, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchRarewordsByQueryModel(out msg, qModel2).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.Warehouse:
                    QueryWarehouseModel qModel3 = new QueryWarehouseModel();
                    BindDataToEntity(qModel3, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchWarehousesByQueryModel(out msg, qModel3).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.WarehouseZone:
                    QueryWarehouseZoneModel qModel4 = new QueryWarehouseZoneModel();
                    BindDataToEntity(qModel4, searchConditions);
                    pagerControl1.Visible = true;
                    return this.PharmacyDatabaseService.SearchPagedWarehouseZonesByQueryModel(out pageInfo, qModel4, pagerControl1.PageIndex, pagerControl1.PageSize).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.User:
                    QueryUserModel qModel5 = new QueryUserModel();
                    BindDataToEntity(qModel5, searchConditions);
                    pagerControl1.Visible = true;
                    if (listRU != null)
                        return this.PharmacyDatabaseService.SearchPagedUsersByQueryModel(out pageInfo, qModel5, pagerControl1.PageIndex, pagerControl1.PageSize);
                    else
                        return this.PharmacyDatabaseService.SearchPagedUsersByQueryModel(out pageInfo, qModel5, pagerControl1.PageIndex, pagerControl1.PageSize).Where(p => p.Id == _currentUser).ToArray();
                case DataSoruceType.UserLog:
                    QueryUserLogModel qModel6 = new QueryUserLogModel();
                    BindDataToEntity(qModel6, searchConditions);
                    //return this.PharmacyDatabaseService.SearchUserLogsByQueryModel(out msg, qModel6);
                    pagerControl1.Visible = true;
                    return this.PharmacyDatabaseService.SearchPagedUserLogsByQueryModel(out pageInfo, qModel6, pagerControl1.PageIndex, pagerControl1.PageSize);
                case DataSoruceType.Role:
                    QueryRoleModel qModel7 = new QueryRoleModel();
                    BindDataToEntity(qModel7, searchConditions);
                    pagerControl1.Visible = true;
                    return this.PharmacyDatabaseService.SearchPagedRolesByQueryModel(out pageInfo, qModel7, pagerControl1.PageIndex, pagerControl1.PageSize).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.ModuleCategory:
                    QueryModuleCatetoryModel qModel8 = new QueryModuleCatetoryModel();
                    BindDataToEntity(qModel8, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchModuleCatetorysByQueryModel(out msg, qModel8).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.Module:
                    QueryModuleModel qModel9 = new QueryModuleModel();
                    BindDataToEntity(qModel9, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchModulesByQueryModel(out msg, qModel9).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.Vehicle:
                    QueryVehicleModel qModel10 = new QueryVehicleModel();
                    BindDataToEntity(qModel10, searchConditions);
                    pagerControl1.Visible = false;
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchVehiclesByQueryModel(out msg, qModel10).OrderBy(r => r.Driver).ToArray();
                case DataSoruceType.DrugCategory:
                    QueryDrugCategoryModel qModel11 = new QueryDrugCategoryModel();
                    BindDataToEntity(qModel11, searchConditions);
                    pagerControl1.Visible = true;
                    return this.PharmacyDatabaseService.SearchPagedDrugCategorysByQueryModel(out pageInfo, qModel11, pagerControl1.PageIndex, pagerControl1.PageSize).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.DictionarySpecification:
                    QueryDictionarySpecificationModel qModel12 = new QueryDictionarySpecificationModel();
                    BindDataToEntity(qModel12, searchConditions);
                    pagerControl1.Visible = true;
                    return this.PharmacyDatabaseService.SearchPagedDictionarySpecificationsByQueryModel(out pageInfo, qModel12, pagerControl1.PageIndex, pagerControl1.PageSize).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.DictionaryStorageType:
                    QueryDictionaryStorageTypeModel qModel14 = new QueryDictionaryStorageTypeModel();
                    BindDataToEntity(qModel14, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchDictionaryStorageTypesByQueryModel(out msg, qModel14).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.DictionaryMeasurementUnit:
                    QueryDictionaryMeasurementUnitModel qModel15 = new QueryDictionaryMeasurementUnitModel();
                    BindDataToEntity(qModel15, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchDictionaryMeasurementUnitsByQueryModel(out msg, qModel15).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.DictionaryPiecemealUnit:
                    QueryDictionaryPiecemealUnitModel qModel16 = new QueryDictionaryPiecemealUnitModel();
                    BindDataToEntity(qModel16, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchDictionaryPiecemealUnitsByQueryModel(out msg, qModel16).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.DictionaryUserDefinedType:
                    QueryDictionaryUserDefinedTypeModel qModel17 = new QueryDictionaryUserDefinedTypeModel();
                    BindDataToEntity(qModel17, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchDictionaryUserDefinedTypesByQueryModel(out msg, qModel17).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.DictionaryDosage:
                    QueryDictionaryDosageModel qModel18 = new QueryDictionaryDosageModel();
                    BindDataToEntity(qModel18, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchDictionaryDosagesByQueryModel(out msg, qModel18).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.PurchaseUnitType:
                    QueryPurchaseUnitTypeModel qModel19 = new QueryPurchaseUnitTypeModel();
                    BindDataToEntity(qModel19, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchPurchaseUnitTypesByQueryModel(out msg, qModel19).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.PurchaseUnit:
                    QueryPurchaseUnitModel qModel20 = new QueryPurchaseUnitModel();
                    BindDataToEntity(qModel20, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchPurchaseUnitsByQueryModel(out msg, qModel20).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.PurchaseUnitBuyer:
                    QueryPurchaseUnitBuyerModel qModel21 = new QueryPurchaseUnitBuyerModel();
                    BindDataToEntity(qModel21, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchPurchaseUnitBuyersByQueryModel(out msg, qModel21);
                case DataSoruceType.PurchaseUnitDeliverer:
                    QueryPurchaseUnitDelivererModel qModel22 = new QueryPurchaseUnitDelivererModel();
                    BindDataToEntity(qModel22, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchPurchaseUnitDeliverersByQueryModel(out msg, qModel22).OrderBy(r => r.Name).ToArray();

                case DataSoruceType.SupplyPerson:
                    QuerySupplyPersonModel qMode222 = new QuerySupplyPersonModel();
                    BindDataToEntity(qMode222, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchSupplyPersonsByQueryModel(out msg, qMode222);
                //end
                case DataSoruceType.SupplyUnit:
                    QuerySupplyUnitModel qModel23 = new QuerySupplyUnitModel();
                    BindDataToEntity(qModel23, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchSupplyUnitsByQueryModel(out msg, qModel23).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.SupplyUnitSalesman:
                    QuerySupplyUnitSalesmanModel qModel24 = new QuerySupplyUnitSalesmanModel();
                    BindDataToEntity(qModel24, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchSupplyUnitSalesmansByQueryModel(out msg, qModel24);
                case DataSoruceType.Employee:
                    QueryEmployeeModel qModel25 = new QueryEmployeeModel();
                    BindDataToEntity(qModel25, searchConditions);
                    pagerControl1.Visible = true;
                    return this.PharmacyDatabaseService.SearchPagedEmployeesByQueryModel(out pageInfo, qModel25, pagerControl1.PageIndex, pagerControl1.PageSize).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.BusinessType:
                    QueryBusinessTypeModel qModel26 = new QueryBusinessTypeModel();
                    BindDataToEntity(qModel26, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchBusinessTypesByQueryModel(out msg, qModel26).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.UnitType:
                    QueryUnitTypeModel qModel27 = new QueryUnitTypeModel();
                    BindDataToEntity(qModel27, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchUnitTypesByQueryModel(out msg, qModel27).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.ApprovalFlowType:
                    QueryApprovalFlowTypeModel qModel28 = new QueryApprovalFlowTypeModel();
                    BindDataToEntity(qModel28, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchApprovalFlowTypesByQueryModel(out msg, qModel28).OrderBy(r => r.Name).ToArray();
                case DataSoruceType.BusinessScope:
                    QueryBusinessScopeModel qModel50 = new QueryBusinessScopeModel();
                    BindDataToEntity(qModel50, searchConditions);
                    pagerControl1.Visible = false;
                    return this.PharmacyDatabaseService.SearchBusinessScopesByQueryModel(out msg, qModel50).OrderBy(r => r.Code).ToArray();

            }
            return null;
        }
        public object AutoGeneratedLoadEntity(out string msg)
        {
            msg = string.Empty;
            Object entitys = new Object();
            switch (GridDataSourceType)
            {
                case DataSoruceType.BusinessScope:
                    entitys = this.PharmacyDatabaseService.AllBusinessScopes(out msg);
                    break;

                case DataSoruceType.Store:
                    entitys = this.PharmacyDatabaseService.AllStores(out msg);
                    break;
                case DataSoruceType.District:
                    entitys = this.PharmacyDatabaseService.AllDistricts(out msg);
                    break;
                case DataSoruceType.Rareword:
                    entitys = this.PharmacyDatabaseService.AllRarewords(out msg);
                    break;
                case DataSoruceType.Warehouse:
                    entitys = this.PharmacyDatabaseService.AllWarehouses(out msg);
                    break;
                case DataSoruceType.WarehouseZone:
                    entitys = this.PharmacyDatabaseService.AllWarehouseZones(out msg);
                    break;
                case DataSoruceType.User:
                    User[] users = this.PharmacyDatabaseService.AllUsers(out msg);
                    if (users != null && users.Count() > 0)
                    {
                        Employee[] employess = this.PharmacyDatabaseService.AllEmployees(out msg).OrderBy(r=>r.Name).ToArray();
                        foreach (User u in users)
                        {
                            u.Employee = employess.FirstOrDefault(e => e.Id == u.EmployeeId);
                        }
                    }
                    if (listRU != null)
                        entitys = users;
                    else
                        entitys = users.Where(p => p.Id == _currentUser).ToArray();
                    //entitys = users;
                    break;
                case DataSoruceType.UserLog:
                    entitys = this.PharmacyDatabaseService.AllUserLogs(out msg).OrderBy(d => d.CreateTime);
                    break;
                case DataSoruceType.Role:
                    entitys = this.PharmacyDatabaseService.AllRoles(out msg);
                    break;
                //拼写错误
                case DataSoruceType.ModuleCategory:
                    entitys = this.PharmacyDatabaseService.AllModuleCatetorys(out msg);
                    break;
                case DataSoruceType.Module:
                    Module[] modules = this.PharmacyDatabaseService.AllModules(out msg);
                    if (modules != null && modules.Count() > 0)
                    {
                        ModuleCatetory[] moduleCatetories = this.PharmacyDatabaseService.AllModuleCatetorys(out msg);
                        foreach (Module u in modules)
                        {
                            u.ModuleCatetory = moduleCatetories.FirstOrDefault(e => e.Id == u.ModuleCatetoryId);
                        }
                    }
                    entitys = modules;
                    break;
                case DataSoruceType.Vehicle:
                    entitys = this.PharmacyDatabaseService.AllVehicles(out msg);
                    break;
                case DataSoruceType.DrugCategory:
                    entitys = this.PharmacyDatabaseService.AllDrugCategorys(out msg);
                    break;
                case DataSoruceType.DictionarySpecification:
                    entitys = this.PharmacyDatabaseService.AllDictionarySpecifications(out msg);
                    break;
                //case DataSoruceType.DrugType:
                //    entitys = this.PharmacyDatabaseService.AllDrugTypes(out msg);
                //    break;
                case DataSoruceType.DictionaryStorageType:
                    entitys = this.PharmacyDatabaseService.AllDictionaryStorageTypes(out msg);
                    break;
                case DataSoruceType.DictionaryMeasurementUnit:
                    entitys = this.PharmacyDatabaseService.AllDictionaryMeasurementUnits(out msg);
                    break;
                case DataSoruceType.DictionaryPiecemealUnit:
                    entitys = this.PharmacyDatabaseService.AllDictionaryPiecemealUnits(out msg);
                    break;
                case DataSoruceType.DictionaryUserDefinedType:
                    entitys = this.PharmacyDatabaseService.AllDictionaryUserDefinedTypes(out msg);
                    break;
                case DataSoruceType.DictionaryDosage:
                    entitys = this.PharmacyDatabaseService.AllDictionaryDosages(out msg);
                    break;
                case DataSoruceType.PurchaseUnitType:
                    entitys = this.PharmacyDatabaseService.AllPurchaseUnitTypes(out msg);
                    break;
                case DataSoruceType.PurchaseUnitBuyer:
                    entitys = this.PharmacyDatabaseService.AllPurchaseUnitBuyers(out msg);
                    break;
                case DataSoruceType.PurchaseUnitDeliverer:
                    entitys = this.PharmacyDatabaseService.AllPurchaseUnitDeliverers(out msg);
                    break;
                case DataSoruceType.SupplyUnit:
                    entitys = this.PharmacyDatabaseService.AllSupplyUnits(out msg);
                    break;
                case DataSoruceType.SupplyUnitSalesman:
                    entitys = this.PharmacyDatabaseService.AllSupplyUnitSalesmans(out msg);
                    break;
                case DataSoruceType.Employee:
                    Employee[] employees = this.PharmacyDatabaseService.AllEmployees(out msg).OrderBy(r=>r.Name).ToArray();



                    if (employees != null && employees.Count() > 0)
                    {
                        Department[] departments = this.PharmacyDatabaseService.AllDepartments(out msg);
                        foreach (Employee e in employees)
                        {
                            e.Department = departments.FirstOrDefault(d => d.Id == e.DepartmentId);
                        }
                    }
                    entitys = employees;
                    break;
                case DataSoruceType.UnitType:
                    entitys = this.PharmacyDatabaseService.AllUnitTypes(out msg);
                    break;
                case DataSoruceType.BusinessType:
                    entitys = this.PharmacyDatabaseService.AllBusinessTypes(out msg);
                    break;
                case DataSoruceType.PurchaseUnit:
                    entitys = this.PharmacyDatabaseService.AllPurchaseUnits(out msg);
                    break;
                case DataSoruceType.ApprovalFlowType:
                    entitys = this.PharmacyDatabaseService.AllApprovalFlowTypes(out msg);
                    break;

                //WFZ
                case DataSoruceType.SupplyPerson:
                    entitys = this.PharmacyDatabaseService.AllSupplyPersons(out msg);
                    break;
            }
            return entitys;
        }

        public void AutoGeneratedDeleteEntity(out string msg)
        {

            //generate code
            //StringBuilder codes = new StringBuilder();
            //foreach (var a in EnumHelper<DataSoruceType>.GetNames(DataSoruceType.Store))
            //{
            //    codes.AppendLine(string.Format("case DataSoruceType.{0}:",a));
            //    codes.AppendLine(string.Format("this.PharmacyDatabaseService.Delete{0}(out msg, EditId);", a));
            //    codes.AppendLine("break;");
            //}
            msg = string.Empty;
            switch (GridDataSourceType)
            {
                case DataSoruceType.Employee:
                    this.PharmacyDatabaseService.DeleteEmployee(out msg, EditId);
                    break;
                case DataSoruceType.Store:
                    this.PharmacyDatabaseService.DeleteStore(out msg, EditId);
                    break;
                case DataSoruceType.Rareword:
                    this.PharmacyDatabaseService.DeleteRareword(out msg, EditId);
                    break;
                case DataSoruceType.SupplyUnit:
                    this.PharmacyDatabaseService.DeleteSupplyUnit(out msg, EditId);
                    break;
                case DataSoruceType.SupplyUnitSalesman:
                    this.PharmacyDatabaseService.DeleteSupplyUnitSalesman(out msg, EditId);
                    break;
                case DataSoruceType.District:
                    this.PharmacyDatabaseService.DeleteDistrict(out msg, EditId);
                    break;
                case DataSoruceType.Warehouse:
                    this.PharmacyDatabaseService.DeleteWarehouse(out msg, EditId);
                    break;
                case DataSoruceType.WarehouseZone:
                    this.PharmacyDatabaseService.DeleteWarehouseZone(out msg, EditId);
                    break;
                case DataSoruceType.User:
                    this.PharmacyDatabaseService.DeleteUser(out msg, EditId);
                    break;
                case DataSoruceType.UserLog:
                    this.PharmacyDatabaseService.DeleteUserLog(out msg, EditId);
                    break;
                case DataSoruceType.Role:
                    this.PharmacyDatabaseService.DeleteRole(out msg, EditId);
                    break;
                case DataSoruceType.ModuleCategory:
                    this.PharmacyDatabaseService.DeleteModuleCatetory(out msg, EditId);
                    break;
                case DataSoruceType.Module:
                    this.PharmacyDatabaseService.DeleteModule(out msg, EditId);
                    break;
                case DataSoruceType.Vehicle:
                    this.PharmacyDatabaseService.DeleteVehicle(out msg, EditId);
                    break;
                case DataSoruceType.DrugCategory:
                    this.PharmacyDatabaseService.DeleteDrugCategory(out msg, EditId);
                    break;
                case DataSoruceType.DictionarySpecification:
                    this.PharmacyDatabaseService.DeleteDictionarySpecification(out msg, EditId);
                    break;
                //case DataSoruceType.DrugType:
                //    this.PharmacyDatabaseService.DeleteDrugType(out msg, EditId);
                //    break;
                case DataSoruceType.DictionaryStorageType:
                    this.PharmacyDatabaseService.DeleteDictionaryStorageType(out msg, EditId);
                    break;
                case DataSoruceType.DictionaryMeasurementUnit:
                    this.PharmacyDatabaseService.DeleteDictionaryMeasurementUnit(out msg, EditId);
                    break;
                case DataSoruceType.DictionaryPiecemealUnit:
                    this.PharmacyDatabaseService.DeleteDictionaryPiecemealUnit(out msg, EditId);
                    break;
                case DataSoruceType.DictionaryUserDefinedType:
                    this.PharmacyDatabaseService.DeleteDictionaryUserDefinedType(out msg, EditId);
                    break;
                case DataSoruceType.DictionaryDosage:
                    this.PharmacyDatabaseService.DeleteDictionaryDosage(out msg, EditId);
                    break;
                case DataSoruceType.PurchaseUnitType:
                    this.PharmacyDatabaseService.DeletePurchaseUnitType(out msg, EditId);
                    break;
                case DataSoruceType.PurchaseUnit:
                    this.PharmacyDatabaseService.DeletePurchaseUnit(out msg, EditId);
                    break;
                case DataSoruceType.PurchaseUnitBuyer:
                    this.PharmacyDatabaseService.DeletePurchaseUnitBuyer(out msg, EditId);
                    break;
                case DataSoruceType.PurchaseUnitDeliverer:
                    this.PharmacyDatabaseService.DeletePurchaseUnitDeliverer(out msg, EditId);
                    break;
                case DataSoruceType.UnitType:
                    this.PharmacyDatabaseService.DeleteUnitType(out msg, EditId);
                    break;
                case DataSoruceType.BusinessType:
                    this.PharmacyDatabaseService.DeleteBusinessType(out msg, EditId);
                    break;
                case DataSoruceType.ApprovalFlowType:
                    this.PharmacyDatabaseService.DeleteApprovalFlowType(out msg, EditId);
                    break;

                case DataSoruceType.BusinessScope:
                    this.PharmacyDatabaseService.DeleteBusinessScope(out msg, EditId);
                    break;

                //wfz
                //case DataSoruceType.SupplyPerson:
                //    this.PharmacyDatabaseService.DeletePurchaseUnitDeliverer(out msg, EditId);
                //    break;
                //end
            }
        }
        public void AutoGeneratedAddEditEntity(Dictionary<string, object> bindValues, out string msg)
        {
            //generate code
            //StringBuilder codes = new StringBuilder();
            //int i = 0;
            //foreach (var a in EnumHelper<DataSoruceType>.GetNames(DataSoruceType.Store))
            //{
            //    codes.AppendLine(string.Format("case DataSoruceType.{0}:", a));
            //    codes.AppendLine(string.Format("{0} entity{1} = new {0}();", a, i));
            //    codes.AppendLine(string.Format("entity{0}.Id = Guid.NewGuid();", i));
            //    codes.AppendLine(string.Format(" BindDataToEntity(entity{0}, bindValues);", i));
            //    codes.AppendLine(string.Format("if (_TYPE == OperateType.Edit)"));
            //    codes.AppendLine("{");
            //    codes.AppendLine(string.Format("entity{0}.Id = EditId;", i));
            //    codes.AppendLine(string.Format("this.PharmacyDatabaseService.Save{0}(out msg, entity{1});", a, i));
            //    codes.AppendLine(" }");
            //    codes.AppendLine(string.Format("else"));
            //    codes.AppendLine("{");
            //    codes.AppendLine(string.Format(" this.PharmacyDatabaseService.Add{0}(out msg, entity{1});", a, i));
            //    codes.AppendLine("}");
            //    codes.AppendLine("break;");
            //    i++;
            //}
            msg = string.Empty;
            switch (GridDataSourceType)
            {
                case DataSoruceType.Store:
                    Store entity0 = new Store();
                    entity0.Id = Guid.NewGuid();
                    BindDataToEntity(entity0, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity0.Id = EditId;
                        this.PharmacyDatabaseService.SaveStore(out msg, entity0);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddStore(out msg, entity0);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存门店信息成功！");
                    break;
                case DataSoruceType.District:
                    District entity1 = new District();
                    entity1.Id = Guid.NewGuid();
                    BindDataToEntity(entity1, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity1.Id = EditId;
                        this.PharmacyDatabaseService.SaveDistrict(out msg, entity1);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddDistrict(out msg, entity1);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存地区信息成功！");
                    break;
                case DataSoruceType.Rareword:
                    Rareword entity2 = new Rareword();
                    entity2.Id = Guid.NewGuid();
                    BindDataToEntity(entity2, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity2.Id = EditId;
                        this.PharmacyDatabaseService.SaveRareword(out msg, entity2);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddRareword(out msg, entity2);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存字典信息成功！");
                    break;
                case DataSoruceType.Warehouse:
                    Warehouse entity3 = new Warehouse();
                    entity3.Id = Guid.NewGuid();
                    BindDataToEntity(entity3, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity3.Id = EditId;
                        this.PharmacyDatabaseService.SaveWarehouse(out msg, entity3);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddWarehouse(out msg, entity3);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存仓库信息成功！");
                    break;
                case DataSoruceType.WarehouseZone:
                    WarehouseZone entity4 = new WarehouseZone();
                    entity4.Id = Guid.NewGuid();
                    BindDataToEntity(entity4, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity4.Id = EditId;
                        this.PharmacyDatabaseService.SaveWarehouseZone(out msg, entity4);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddWarehouseZone(out msg, entity4);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存仓库货位信息成功！");
                    break;
                case DataSoruceType.User:
                    User entity5 = new User();
                    User users = null;
                    entity5.Id = Guid.NewGuid();
                    if (_TYPE == OperateType.Edit)
                    {
                        users = PharmacyDatabaseService.GetUser(out msg, EditId);
                    }
                    BindDataToEntity(entity5, bindValues);
                    if (users != null)
                    {
                        entity5.SalesManageFee = users.SalesManageFee;
                        entity5.PurchaseTaxReturn = users.PurchaseTaxReturn;
                    }
                    entity5.Pwd = EncodeHelper.Base64Encode(entity5.Pwd);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity5.Id = EditId;
                        this.PharmacyDatabaseService.SaveUser(out msg, entity5);
                    }
                    else
                    {
                        entity5.SalesManageFee = 0m;
                        entity5.PurchaseTaxReturn = 0m;
                        this.PharmacyDatabaseService.AddUser(out msg, entity5);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存单位信息系统用户信息成功！");
                    break;
                case DataSoruceType.UserLog:
                    UserLog entity6 = new UserLog();
                    entity6.Id = Guid.NewGuid();
                    BindDataToEntity(entity6, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity6.Id = EditId;
                        this.PharmacyDatabaseService.SaveUserLog(out msg, entity6);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddUserLog(out msg, entity6);
                    }
                    break;
                case DataSoruceType.Role:
                    Role entity7 = new Role();
                    entity7.Id = Guid.NewGuid();
                    BindDataToEntity(entity7, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity7.Id = EditId;
                        this.PharmacyDatabaseService.SaveRole(out msg, entity7);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddRole(out msg, entity7);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存岗位角色信息成功！");
                    break;
                case DataSoruceType.ModuleCategory:
                    ModuleCatetory entity8 = new ModuleCatetory();
                    entity8.Id = Guid.NewGuid();
                    BindDataToEntity(entity8, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity8.Id = EditId;
                        this.PharmacyDatabaseService.SaveModuleCatetory(out msg, entity8);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddModuleCatetory(out msg, entity8);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存系统菜单信息成功！");
                    break;
                case DataSoruceType.Module:
                    Module entity9 = new Module();
                    entity9.Id = Guid.NewGuid();
                    BindDataToEntity(entity9, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity9.Id = EditId;
                        this.PharmacyDatabaseService.SaveModule(out msg, entity9);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddModule(out msg, entity9);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存系统菜单分类信息成功！");
                    break;
                case DataSoruceType.Vehicle:
                    Vehicle entity10 = new Vehicle();
                    entity10.Id = Guid.NewGuid();
                    BindDataToEntity(entity10, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity10.Id = EditId;
                        this.PharmacyDatabaseService.SaveVehicle(out msg, entity10);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddVehicle(out msg, entity10);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存运输工具信息成功！");
                    break;
                case DataSoruceType.DrugCategory:
                    DrugCategory entity11 = new DrugCategory();
                    entity11.Id = Guid.NewGuid();
                    BindDataToEntity(entity11, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity11.Id = EditId;
                        this.PharmacyDatabaseService.SaveDrugCategory(out msg, entity11);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddDrugCategory(out msg, entity11);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存药品分类信息成功！");
                    break;
                case DataSoruceType.DictionarySpecification:
                    DictionarySpecification entity12 = new DictionarySpecification();
                    entity12.Id = Guid.NewGuid();
                    BindDataToEntity(entity12, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity12.Id = EditId;
                        this.PharmacyDatabaseService.SaveDictionarySpecification(out msg, entity12);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddDictionarySpecification(out msg, entity12);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存自定义规格信息成功！");
                    break;
                //case DataSoruceType.DrugType:
                //    DrugType entity13 = new DrugType();
                //    entity13.Id = Guid.NewGuid();
                //    BindDataToEntity(entity13, bindValues);
                //    if (_TYPE == OperateType.Edit)
                //    {
                //        entity13.Id = EditId;
                //        this.PharmacyDatabaseService.SaveDrugType(out msg, entity13);
                //    }
                //    else
                //    {
                //        this.PharmacyDatabaseService.AddDrugType(out msg, entity13);
                //    }
                //    break;
                case DataSoruceType.DictionaryStorageType:
                    DictionaryStorageType entity14 = new DictionaryStorageType();
                    entity14.Id = Guid.NewGuid();
                    BindDataToEntity(entity14, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity14.Id = EditId;
                        this.PharmacyDatabaseService.SaveDictionaryStorageType(out msg, entity14);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddDictionaryStorageType(out msg, entity14);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存自定义规格信息成功！");
                    break;
                case DataSoruceType.DictionaryMeasurementUnit:
                    DictionaryMeasurementUnit entity15 = new DictionaryMeasurementUnit();
                    entity15.Id = Guid.NewGuid();
                    BindDataToEntity(entity15, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity15.Id = EditId;
                        this.PharmacyDatabaseService.SaveDictionaryMeasurementUnit(out msg, entity15);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddDictionaryMeasurementUnit(out msg, entity15);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存自定义单位信息成功！");
                    break;
                case DataSoruceType.DictionaryPiecemealUnit:
                    DictionaryPiecemealUnit entity16 = new DictionaryPiecemealUnit();
                    entity16.Id = Guid.NewGuid();
                    BindDataToEntity(entity16, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity16.Id = EditId;
                        this.PharmacyDatabaseService.SaveDictionaryPiecemealUnit(out msg, entity16);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddDictionaryPiecemealUnit(out msg, entity16);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存品种拆零信息成功！");
                    break;
                case DataSoruceType.DictionaryUserDefinedType:
                    DictionaryUserDefinedType entity17 = new DictionaryUserDefinedType();
                    entity17.Id = Guid.NewGuid();
                    BindDataToEntity(entity17, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity17.Id = EditId;
                        this.PharmacyDatabaseService.SaveDictionaryUserDefinedType(out msg, entity17);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddDictionaryUserDefinedType(out msg, entity17);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存用户自定义类型信息成功！");
                    break;
                case DataSoruceType.DictionaryDosage:
                    DictionaryDosage entity18 = new DictionaryDosage();
                    entity18.Id = Guid.NewGuid();
                    BindDataToEntity(entity18, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity18.Id = EditId;
                        this.PharmacyDatabaseService.SaveDictionaryDosage(out msg, entity18);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddDictionaryDosage(out msg, entity18);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存自定义剂型信息成功！");
                    break;
                case DataSoruceType.PurchaseUnitType:
                    PurchaseUnitType entity19 = new PurchaseUnitType();
                    entity19.Id = Guid.NewGuid();
                    BindDataToEntity(entity19, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity19.Id = EditId;
                        this.PharmacyDatabaseService.SavePurchaseUnitType(out msg, entity19);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddPurchaseUnitType(out msg, entity19);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存供货商类型信息成功！");
                    break;
                case DataSoruceType.PurchaseUnit:
                    PurchaseUnit entity20 = new PurchaseUnit();
                    entity20.Id = Guid.NewGuid();
                    BindDataToEntity(entity20, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity20.Id = EditId;
                        this.PharmacyDatabaseService.SavePurchaseUnit(out msg, entity20);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddPurchaseUnit(out msg, entity20);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存购货商信息成功！");
                    break;
                case DataSoruceType.PurchaseUnitBuyer:
                    PurchaseUnitBuyer entity21 = new PurchaseUnitBuyer();
                    entity21.Id = Guid.NewGuid();
                    BindDataToEntity(entity21, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity21.Id = EditId;
                        entity21.UpdateTime = DateTime.Now;
                        this.PharmacyDatabaseService.SavePurchaseUnitBuyer(out msg, entity21);
                    }
                    else
                    {
                        entity21.CreateTime = DateTime.Now;
                        entity21.UpdateTime = DateTime.Now;
                        this.PharmacyDatabaseService.AddPurchaseUnitBuyer(out msg, entity21);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存购买人信息成功！");
                    break;
                case DataSoruceType.PurchaseUnitDeliverer:
                    PurchaseUnitDeliverer entity22 = new PurchaseUnitDeliverer();
                    entity22.Id = Guid.NewGuid();
                    BindDataToEntity(entity22, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity22.Id = EditId;
                        entity22.UpdateTime = DateTime.Now;
                        entity22.UpdateUserId = AppClientContext.CurrentUser.Id;
                        this.PharmacyDatabaseService.SavePurchaseUnitDeliverer(out msg, entity22);
                    }
                    else
                    {
                        entity22.CreateTime = DateTime.Now;
                        entity22.UpdateTime = DateTime.Now;
                        entity22.CreateUserId = AppClientContext.CurrentUser.Id;
                        entity22.UpdateUserId = AppClientContext.CurrentUser.Id;

                        this.PharmacyDatabaseService.AddPurchaseUnitDeliverer(out msg, entity22);
                    }
                    break;
                case DataSoruceType.SupplyUnit:
                    SupplyUnit entity23 = new SupplyUnit();
                    entity23.Id = Guid.NewGuid();
                    BindDataToEntity(entity23, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity23.Id = EditId;
                        this.PharmacyDatabaseService.SaveSupplyUnit(out msg, entity23);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddSupplyUnit(out msg, entity23);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存供应商信息成功！"+entity23.Name);
                    break;
                case DataSoruceType.SupplyUnitSalesman:
                    SupplyUnitSalesman entity24 = new SupplyUnitSalesman();
                    entity24.Id = Guid.NewGuid();
                    BindDataToEntity(entity24, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity24.Id = EditId;
                        this.PharmacyDatabaseService.SaveSupplyUnitSalesman(out msg, entity24);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddSupplyUnitSalesman(out msg, entity24);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存供应商供应人信息成功！"+entity24.Name);
                    break;
                case DataSoruceType.Employee:
                    Employee entity25 = new Employee();
                    entity25.Id = Guid.NewGuid();
                    BindDataToEntity(entity25, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity25.Id = EditId;
                        this.PharmacyDatabaseService.SaveEmployee(out msg, entity25);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddEmployee(out msg, entity25);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存员工信息成功！"+entity25.Name);
                    break;
                case DataSoruceType.UnitType:
                    UnitType entity26 = new UnitType();
                    entity26.Id = Guid.NewGuid();
                    BindDataToEntity(entity26, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity26.Id = EditId;
                        this.PharmacyDatabaseService.SaveUnitType(out msg, entity26);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddUnitType(out msg, entity26);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存供货商单位类型信息成功！"+entity26.Name);
                    break;
                case DataSoruceType.BusinessType:
                    BusinessType entity27 = new BusinessType();
                    entity27.Id = Guid.NewGuid();
                    BindDataToEntity(entity27, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity27.Id = EditId;
                        this.PharmacyDatabaseService.SaveBusinessType(out msg, entity27);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddBusinessType(out msg, entity27);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存经营单位类型信息成功！"+entity27.Name);
                    break;
                case DataSoruceType.ApprovalFlowType:
                    ApprovalFlowType entity28 = new ApprovalFlowType();
                    entity28.Id = Guid.NewGuid();
                    BindDataToEntity(entity28, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity28.Id = EditId;
                        this.PharmacyDatabaseService.SaveApprovalFlowType(out msg, entity28);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddApprovalFlowType(out msg, entity28);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存门店信息成功！"+entity28.Name);
                    break;

                //wfz
                case DataSoruceType.SupplyPerson:
                    SupplyPerson entity30 = new SupplyPerson();
                    entity30.Id = Guid.NewGuid();
                    BindDataToEntity(entity30, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity30.Id = EditId;
                        this.PharmacyDatabaseService.SaveSupplyPerson(out msg, entity30);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddSupplyPerson(out msg, entity30);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存供应商供货人信息成功！");
                    break;

                case DataSoruceType.BusinessScope:
                    BusinessScope entity50 = new BusinessScope();
                    entity50.Id = Guid.NewGuid();
                    BindDataToEntity(entity50, bindValues);
                    if (_TYPE == OperateType.Edit)
                    {
                        entity50.Id = EditId;
                        this.PharmacyDatabaseService.SaveBusinessScope(out msg, entity50);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.AddBusinessScope(out msg, entity50);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存地区信息成功！");
                    break;

            }
        }

    }
}
