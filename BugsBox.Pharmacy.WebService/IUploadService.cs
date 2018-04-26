
 
 
 
  


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Models;
using System.ServiceModel;
namespace BugsBox.Pharmacy.WebService
{
   [ServiceContract]
    public interface IUploadService
    {
	 
       [OperationContract]
        bool UpWarehouseZone(List<WarehouseZone> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseOrderReturn(List<PurchaseOrderReturn> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseOrder(List<PurchaseOrder> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpAuthorizationDoc(List<AuthorizationDoc> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpBillDocumentCode(List<BillDocumentCode> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpVehicle(List<Vehicle> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpDistrict(List<District> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpWaringSet(List<WaringSet> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseUnit(List<PurchaseUnit> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpUser(List<User> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpSalesOrderDeliverRecord(List<SalesOrderDeliverRecord> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseUnitDeliverer(List<PurchaseUnitDeliverer> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpModule(List<Module> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpDrugCategory(List<DrugCategory> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpSalesOrderReturnDetail(List<SalesOrderReturnDetail> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpSalesOrderDetail(List<SalesOrderDetail> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpRoleWithUser(List<RoleWithUser> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseAgreement(List<PurchaseAgreement> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpDrugApprovalNumber(List<DrugApprovalNumber> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpDoubtDrug(List<DoubtDrug> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseCheckingOrderDetail(List<PurchaseCheckingOrderDetail> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpDelivery(List<Delivery> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpOutInventory(List<OutInventory> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseReceivingOrderDetail(List<PurchaseReceivingOrderDetail> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseReceivingOrder(List<PurchaseReceivingOrder> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseInInventeryOrderDetail(List<PurchaseInInventeryOrderDetail> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpManufacturer(List<Manufacturer> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpDictionaryUserDefinedType(List<DictionaryUserDefinedType> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpRole(List<Role> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseInInventeryOrder(List<PurchaseInInventeryOrder> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpDepartment(List<Department> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpRetailOrderDetail(List<RetailOrderDetail> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseOrderReturnDetail(List<PurchaseOrderReturnDetail> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpModuleWithRole(List<ModuleWithRole> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpApprovalFlowNode(List<ApprovalFlowNode> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpSalesOrderDeliverDetail(List<SalesOrderDeliverDetail> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPharmacyFile(List<PharmacyFile> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpEmployee(List<Employee> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpDrugInventoryRecord(List<DrugInventoryRecord> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpOutInventoryDetail(List<OutInventoryDetail> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseUnitBuyer(List<PurchaseUnitBuyer> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseOrderDetail(List<PurchaseOrderDetail> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpInventoryRecord(List<InventoryRecord> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpWarehouse(List<Warehouse> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpUserLog(List<UserLog> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpSupplyUnitSalesman(List<SupplyUnitSalesman> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpSalesOrderReturn(List<SalesOrderReturn> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpSalesOrder(List<SalesOrder> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseCheckingOrder(List<PurchaseCheckingOrder> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpRetailOrder(List<RetailOrder> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpGSPLicense(List<GSPLicense> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpGMPLicense(List<GMPLicense> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpBusinessLicense(List<BusinessLicense> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpMedicineProductionLicense(List<MedicineProductionLicense> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpMedicineBusinessLicense(List<MedicineBusinessLicense> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpInstrumentsBusinessLicense(List<InstrumentsBusinessLicense> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpInstrumentsProductionLicense(List<InstrumentsProductionLicense> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpApprovalFlowRecord(List<ApprovalFlowRecord> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpApprovalFlow(List<ApprovalFlow> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpRetailMember(List<RetailMember> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpModuleCatetory(List<ModuleCatetory> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpGMSPLicenseBusinessScope(List<GMSPLicenseBusinessScope> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpApprovalFlowType(List<ApprovalFlowType> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpSupplyUnit(List<SupplyUnit> items, Guid storeId,string token ,int i); 
 
       [OperationContract]
        bool UpPurchaseCashOrder(List<PurchaseCashOrder> items, Guid storeId,string token ,int i); 
    }
}
