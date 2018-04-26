
 
 
 
  


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.WebService
{
    /// <summary>
    /// UploadData 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class UploadData : System.Web.Services.WebService
    {
	 
        [WebMethod]
        public bool UpWarehouseZone(List<WarehouseZone> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                WarehouseZoneBusinessHandler handler = new WarehouseZoneBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (WarehouseZone item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseOrderReturn(List<PurchaseOrderReturn> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseOrderReturnBusinessHandler handler = new PurchaseOrderReturnBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseOrderReturn item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseOrder(List<PurchaseOrder> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseOrderBusinessHandler handler = new PurchaseOrderBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseOrder item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpAuthorizationDoc(List<AuthorizationDoc> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                AuthorizationDocBusinessHandler handler = new AuthorizationDocBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (AuthorizationDoc item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpBillDocumentCode(List<BillDocumentCode> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                BillDocumentCodeBusinessHandler handler = new BillDocumentCodeBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (BillDocumentCode item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpVehicle(List<Vehicle> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                VehicleBusinessHandler handler = new VehicleBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (Vehicle item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpDistrict(List<District> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                DistrictBusinessHandler handler = new DistrictBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (District item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpWaringSet(List<WaringSet> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                WaringSetBusinessHandler handler = new WaringSetBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (WaringSet item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseUnit(List<PurchaseUnit> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseUnitBusinessHandler handler = new PurchaseUnitBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseUnit item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpUser(List<User> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                UserBusinessHandler handler = new UserBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (User item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpSalesOrderDeliverRecord(List<SalesOrderDeliverRecord> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                SalesOrderDeliverRecordBusinessHandler handler = new SalesOrderDeliverRecordBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (SalesOrderDeliverRecord item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseUnitDeliverer(List<PurchaseUnitDeliverer> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseUnitDelivererBusinessHandler handler = new PurchaseUnitDelivererBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseUnitDeliverer item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpModule(List<Module> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                ModuleBusinessHandler handler = new ModuleBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (Module item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpDrugCategory(List<DrugCategory> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                DrugCategoryBusinessHandler handler = new DrugCategoryBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (DrugCategory item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpSalesOrderReturnDetail(List<SalesOrderReturnDetail> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                SalesOrderReturnDetailBusinessHandler handler = new SalesOrderReturnDetailBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (SalesOrderReturnDetail item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpSalesOrderDetail(List<SalesOrderDetail> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                SalesOrderDetailBusinessHandler handler = new SalesOrderDetailBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (SalesOrderDetail item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpRoleWithUser(List<RoleWithUser> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                RoleWithUserBusinessHandler handler = new RoleWithUserBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (RoleWithUser item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseAgreement(List<PurchaseAgreement> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseAgreementBusinessHandler handler = new PurchaseAgreementBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseAgreement item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpDrugApprovalNumber(List<DrugApprovalNumber> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                DrugApprovalNumberBusinessHandler handler = new DrugApprovalNumberBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (DrugApprovalNumber item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpDoubtDrug(List<DoubtDrug> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                DoubtDrugBusinessHandler handler = new DoubtDrugBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (DoubtDrug item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseCheckingOrderDetail(List<PurchaseCheckingOrderDetail> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseCheckingOrderDetailBusinessHandler handler = new PurchaseCheckingOrderDetailBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseCheckingOrderDetail item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpDelivery(List<Delivery> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                DeliveryBusinessHandler handler = new DeliveryBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (Delivery item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpOutInventory(List<OutInventory> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                OutInventoryBusinessHandler handler = new OutInventoryBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (OutInventory item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseReceivingOrderDetail(List<PurchaseReceivingOrderDetail> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseReceivingOrderDetailBusinessHandler handler = new PurchaseReceivingOrderDetailBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseReceivingOrderDetail item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseReceivingOrder(List<PurchaseReceivingOrder> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseReceivingOrderBusinessHandler handler = new PurchaseReceivingOrderBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseReceivingOrder item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseInInventeryOrderDetail(List<PurchaseInInventeryOrderDetail> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseInInventeryOrderDetailBusinessHandler handler = new PurchaseInInventeryOrderDetailBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseInInventeryOrderDetail item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpManufacturer(List<Manufacturer> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                ManufacturerBusinessHandler handler = new ManufacturerBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (Manufacturer item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpDictionaryUserDefinedType(List<DictionaryUserDefinedType> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                DictionaryUserDefinedTypeBusinessHandler handler = new DictionaryUserDefinedTypeBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (DictionaryUserDefinedType item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpRole(List<Role> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                RoleBusinessHandler handler = new RoleBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (Role item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseInInventeryOrder(List<PurchaseInInventeryOrder> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseInInventeryOrderBusinessHandler handler = new PurchaseInInventeryOrderBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseInInventeryOrder item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpDepartment(List<Department> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                DepartmentBusinessHandler handler = new DepartmentBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (Department item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpRetailOrderDetail(List<RetailOrderDetail> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                RetailOrderDetailBusinessHandler handler = new RetailOrderDetailBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (RetailOrderDetail item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseOrderReturnDetail(List<PurchaseOrderReturnDetail> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseOrderReturnDetailBusinessHandler handler = new PurchaseOrderReturnDetailBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseOrderReturnDetail item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpModuleWithRole(List<ModuleWithRole> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                ModuleWithRoleBusinessHandler handler = new ModuleWithRoleBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (ModuleWithRole item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpApprovalFlowNode(List<ApprovalFlowNode> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                ApprovalFlowNodeBusinessHandler handler = new ApprovalFlowNodeBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (ApprovalFlowNode item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpSalesOrderDeliverDetail(List<SalesOrderDeliverDetail> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                SalesOrderDeliverDetailBusinessHandler handler = new SalesOrderDeliverDetailBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (SalesOrderDeliverDetail item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPharmacyFile(List<PharmacyFile> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PharmacyFileBusinessHandler handler = new PharmacyFileBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PharmacyFile item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpEmployee(List<Employee> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                EmployeeBusinessHandler handler = new EmployeeBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (Employee item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpDrugInventoryRecord(List<DrugInventoryRecord> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                DrugInventoryRecordBusinessHandler handler = new DrugInventoryRecordBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (DrugInventoryRecord item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpOutInventoryDetail(List<OutInventoryDetail> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                OutInventoryDetailBusinessHandler handler = new OutInventoryDetailBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (OutInventoryDetail item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseUnitBuyer(List<PurchaseUnitBuyer> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseUnitBuyerBusinessHandler handler = new PurchaseUnitBuyerBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseUnitBuyer item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseOrderDetail(List<PurchaseOrderDetail> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseOrderDetailBusinessHandler handler = new PurchaseOrderDetailBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseOrderDetail item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpInventoryRecord(List<InventoryRecord> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                InventoryRecordBusinessHandler handler = new InventoryRecordBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (InventoryRecord item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpWarehouse(List<Warehouse> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                WarehouseBusinessHandler handler = new WarehouseBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (Warehouse item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpUserLog(List<UserLog> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                UserLogBusinessHandler handler = new UserLogBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (UserLog item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpSupplyUnitSalesman(List<SupplyUnitSalesman> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                SupplyUnitSalesmanBusinessHandler handler = new SupplyUnitSalesmanBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (SupplyUnitSalesman item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpSalesOrderReturn(List<SalesOrderReturn> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                SalesOrderReturnBusinessHandler handler = new SalesOrderReturnBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (SalesOrderReturn item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpSalesOrder(List<SalesOrder> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                SalesOrderBusinessHandler handler = new SalesOrderBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (SalesOrder item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseCheckingOrder(List<PurchaseCheckingOrder> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseCheckingOrderBusinessHandler handler = new PurchaseCheckingOrderBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseCheckingOrder item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpRetailOrder(List<RetailOrder> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                RetailOrderBusinessHandler handler = new RetailOrderBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (RetailOrder item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpGSPLicense(List<GSPLicense> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                GSPLicenseBusinessHandler handler = new GSPLicenseBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (GSPLicense item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpGMPLicense(List<GMPLicense> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                GMPLicenseBusinessHandler handler = new GMPLicenseBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (GMPLicense item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpBusinessLicense(List<BusinessLicense> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                BusinessLicenseBusinessHandler handler = new BusinessLicenseBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (BusinessLicense item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpMedicineProductionLicense(List<MedicineProductionLicense> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                MedicineProductionLicenseBusinessHandler handler = new MedicineProductionLicenseBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (MedicineProductionLicense item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpMedicineBusinessLicense(List<MedicineBusinessLicense> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                MedicineBusinessLicenseBusinessHandler handler = new MedicineBusinessLicenseBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (MedicineBusinessLicense item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpInstrumentsBusinessLicense(List<InstrumentsBusinessLicense> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                InstrumentsBusinessLicenseBusinessHandler handler = new InstrumentsBusinessLicenseBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (InstrumentsBusinessLicense item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpInstrumentsProductionLicense(List<InstrumentsProductionLicense> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                InstrumentsProductionLicenseBusinessHandler handler = new InstrumentsProductionLicenseBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (InstrumentsProductionLicense item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpApprovalFlowRecord(List<ApprovalFlowRecord> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                ApprovalFlowRecordBusinessHandler handler = new ApprovalFlowRecordBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (ApprovalFlowRecord item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpApprovalFlow(List<ApprovalFlow> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                ApprovalFlowBusinessHandler handler = new ApprovalFlowBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (ApprovalFlow item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpRetailMember(List<RetailMember> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                RetailMemberBusinessHandler handler = new RetailMemberBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (RetailMember item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpModuleCatetory(List<ModuleCatetory> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                ModuleCatetoryBusinessHandler handler = new ModuleCatetoryBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (ModuleCatetory item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpGMSPLicenseBusinessScope(List<GMSPLicenseBusinessScope> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                GMSPLicenseBusinessScopeBusinessHandler handler = new GMSPLicenseBusinessScopeBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (GMSPLicenseBusinessScope item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpApprovalFlowType(List<ApprovalFlowType> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                ApprovalFlowTypeBusinessHandler handler = new ApprovalFlowTypeBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (ApprovalFlowType item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpSupplyUnit(List<SupplyUnit> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                SupplyUnitBusinessHandler handler = new SupplyUnitBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (SupplyUnit item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
 
        [WebMethod]
        public bool UpPurchaseCashOrder(List<PurchaseCashOrder> items, Guid storeId,string token ,int i)
        {
            try
            {
                if (!Help.CheckToken(token, i))
                    return false;
                PurchaseCashOrderBusinessHandler handler = new PurchaseCashOrderBusinessHandler(new BugsBox.Pharmacy.Repository.RepositoryProvider(new Repository.Db()), null);
                foreach (PurchaseCashOrder item in handler.Fetch(p => p.StoreId.Equals(storeId)))
                {
                    handler.Delete(item.Id);
                }

                items.ForEach(a => handler.Add(a));
                return handler.Save();
            }
            catch { 
                //do 写日志
                return false; }
        }
    }
}
