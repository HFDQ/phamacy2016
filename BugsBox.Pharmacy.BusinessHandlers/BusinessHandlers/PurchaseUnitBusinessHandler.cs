using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class PurchaseUnitBusinessHandler
    {
        /// <summary>
        /// 采购商的经营范围的Code集合
        /// </summary>
        /// <param name="purchaseUnitGuid"></param>
        /// <returns></returns>
        public List<string> GetBusinessScopeCodesByPurchaseUnitGuid(Guid purchaseUnitGuid)
        {
            try
            {
                PurchaseUnit purchaseUnit = this.Get(purchaseUnitGuid);
                if (purchaseUnit == null)
                {
                    throw new Exception("采购商不存在");
                }
                return GetBusinessScopeCodesByPurchaseUnit(purchaseUnit);
            }
            catch (Exception ex)
            {
                return this.HandleException<List<string>>("根据采购商编号获取采购商经营范围失败", ex);
            }
        }

        /// <summary>
        /// 采购商的经营范围的Code集合
        /// </summary>
        /// <param name="purchaseUnit"></param>
        /// <returns></returns>
        public List<string> GetBusinessScopeCodesByPurchaseUnit(PurchaseUnit purchaseUnit)
        {
            try
            {
                if (purchaseUnit != null)
                {
                    var gSPLicense = BusinessHandlerFactory.GSPLicenseBusinessHandler
                        .Get(purchaseUnit.GSPLicenseId);
                    if (gSPLicense == null)
                        return new List<string>();
                    
                    var ids = gSPLicense.GMSPLicenseBusinessScopes.Select(p => p.BusinessScopeId).AsQueryable();
                    var result = from i in BusinessHandlerFactory.BusinessScopeBusinessHandler.Queryable
                                 join j in ids on i.Id equals j
                                 select i.Name;

                    //var ids = gSPLicense.GMSPLicenseBusinessScopes.Where(r => r.GSPLicenseId.Equals(gSPLicense.Id)).Select(p => p.BusinessScopeId).AsQueryable();

                    //var result = from id in ids join j in BusinessHandlerFactory.BusinessScopeBusinessHandler.Queryable on id equals j.Id select j.Name;

                    return result.ToList();
                }
                else
                {
                    return BusinessHandlerFactory.BusinessScopeBusinessHandler.Queryable.Select(p => p.Name).ToList();
                }
            
            }
            catch (Exception ex)
            {
                return this.HandleException<List<string>>("获取采购商经营范围失败", ex);
            }
        }

        /// <summary>
        /// 采购商的管理分类的Code集合
        /// </summary>
        /// <param name="purchaseUnitGuid"></param>
        /// <returns></returns>
        public List<string> GetManageCategoryDetailByPurchaseUnitGuid(Guid purchaseUnitGuid)
        {
            try
            {
                PurchaseUnit purchaseUnit = this.Get(purchaseUnitGuid);
                if (purchaseUnit == null)
                {
                    throw new Exception("采购商不存在");
                }
                return GetManageCategoryDetailByPurchaseUnit(purchaseUnit);
            }
            catch (Exception ex)
            {
                return this.HandleException<List<string>>("根据采购商编号获取采购商经营范围失败", ex);
            }
        }

        /// <summary>
        /// 采购商的管理分类的Code集合
        /// </summary>
        /// <param name="purchaseUnit"></param>
        /// <returns></returns>
        public List<string> GetManageCategoryDetailByPurchaseUnit(PurchaseUnit purchaseUnit)
        {
            try
            {
                //var gMSPLicense = BusinessHandlerFactory.GMSPLicenseBusinessHandler
                //  .Get(purchaseUnit.GMSPLicenseId);
                //return gMSPLicense.BusinessType.BusinessTypeManageCategoryDetails.Select(p => p.PurchaseManageCategoryDetail.Code).ToList();
                if (purchaseUnit != null)
                {
                    var gSPLicense = BusinessHandlerFactory.GSPLicenseBusinessHandler
                    .Get(purchaseUnit.GSPLicenseId);
                    if (gSPLicense == null)
                        return new List<string>();
                    if (gSPLicense.BusinessType != null)
                    {
                        return gSPLicense.BusinessType.BusinessTypeManageCategoryDetails.Select(p => p.PurchaseManageCategoryDetail.Name).ToList();
                    }
                    else
                    {
                        return new List<string>();
                    }
                }
                else
                {
                    return BusinessHandlerFactory.PurchaseManageCategoryDetailBusinessHandler.Queryable.Select(p => p.Name).ToList();
                }
                
            }
            catch (Exception ex)
            {
                return this.HandleException<List<string>>("获取采购商经营范围失败", ex);
            }
        }

        /// <summary>
        /// 采购商搜索界面方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="py"></param>
        /// <returns></returns>
        public List<PurchaseUnit> GetPurchaseUnitsForSelector(string name, string code, string py)
        {
            try
            {
                var all = this.Fetch(p => p.Valid & p.Enabled);
                if (!string.IsNullOrWhiteSpace(name))
                {
                    all = all.Where(p => p.Name.Contains(name));
                }
                if (!string.IsNullOrWhiteSpace(code))
                {
                    all = all.Where(p => p.Code.Contains(code));
                }
                if (!string.IsNullOrWhiteSpace(py))
                {
                    all = all.Where(p => p.PinyinCode.Contains(py));
                }

                return all.ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseUnit>>("采购商搜索失败", ex);
            }
        }



        /// <summary>
        /// 查找购买单位名称是否已存在
        /// </summary> 
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistPurchaseUnitByName(string name)
        {
            try
            {
                PurchaseUnit a = this.Fetch(r => r.Name == name).FirstOrDefault();
                if (a != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.HandleException("根据名称检查采购商是否存在失败", ex);
                return false;
            }
        }

        /// <summary>
        /// 根据Name获取购买单位 
        /// </summary> 
        /// <param name="name"></param> 
        /// <returns></returns>
        public PurchaseUnit GetPurchaseUnitByName(string name)
        {
            try
            {
                PurchaseUnit a = this.Fetch(r => r.Name == name).FirstOrDefault();
                if (a != null)
                {
                    return a;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                this.HandleException("根据名称获取采购商失败 ", ex);
                return null;
            }
        }

        public PurchaseUnit[] GetPurchaseUnitsByKeywords(string keyword,bool isAccurate)
        {
            var c = isAccurate ? this.Queryable.AsEnumerable().Where(r => r.Valid && !r.Deleted && r.PinyinCode!=null).Where(r => r.PinyinCode.ToUpper() == (keyword.ToUpper()) || r.Name == keyword) : this.Queryable.AsEnumerable().Where(r => r.Valid && !r.Deleted && r.PinyinCode!=null).Where(r => r.PinyinCode.ToUpper().Contains(keyword.ToUpper()) || r.Name.Contains(keyword));

            return c.OrderBy(r=>r.Name).ToArray();
        }

        /// <summary>
        /// 根据Name更新购买单位 
        /// </summary> 
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool UpdatePurchaseUnitByName(string name, PurchaseUnit item)
        {
            try
            {
                PurchaseUnit a = this.Fetch(r => r.Name == name).FirstOrDefault();
                if (a != null)
                {
                    a.Code = item.Code;
                    a.PinyinCode = item.PinyinCode;
                    a.ContactName = item.ContactName;
                    a.ContactTel = item.ContactTel;
                    a.Description = item.Description;
                    a.LegalPerson = item.LegalPerson;
                    a.BusinessScope = item.BusinessScope;
                    a.SalesAmount = item.SalesAmount;
                    a.Fax = item.Fax;
                    a.Email = item.Email;
                    a.WebAddress = item.WebAddress;
                    a.OutDate = item.OutDate;
                    //a.GSPGMPLicCode = item.GSPGMPLicCode;
                    //a.GSPGMPLicOutdate = item.GSPGMPLicOutdate;
                    //a.BusinessLicCode = item.BusinessLicCode;
                    //a.BusinessLicOutdate = item.BusinessLicOutdate;
                    //a.PharmaceuticalTradingLicCode = item.PharmaceuticalTradingLicCode;
                    //a.PharmaceuticalTradingLicOutdate = item.PharmaceuticalTradingLicOutdate;

                    a.GSPLicenseOutDate = item.GSPLicenseOutDate;
                    a.GMPLicenseOutDate = item.GMPLicenseOutDate;
                    a.BusinessLicenseeOutDate = item.BusinessLicenseeOutDate;
                    a.MedicineProductionLicenseOutDate = item.MedicineProductionLicenseOutDate;
                    a.MedicineBusinessLicenseOutDate = item.MedicineBusinessLicenseOutDate;
                    a.InstrumentsProductionLicenseOutDate = item.InstrumentsProductionLicenseOutDate;
                    a.InstrumentsBusinessLicenseOutDate = item.InstrumentsBusinessLicenseOutDate;

                    a.TaxRegistrationCode = item.TaxRegistrationCode;
                    a.LastAnnualDte = item.LastAnnualDte;
                    this.Save();
                    return true;
                }
                else
                {
                    throw new BusinessException("不存在单位名称为'" + name + "'的采购商");
                }
            }
            catch (Exception ex)
            {
                this.HandleException("根据名称更新购买单位失败", ex);
                return false;
            }
        }



        /// <summary>
        /// 根据Flowid 获取采购商
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public PurchaseUnit GetPurchaseUnitByFlowID(Guid flowId)
        {
            try
            {
                var purchaseUnit = this.Fetch(p => p.FlowID == flowId).FirstOrDefault();

                return purchaseUnit;
            }
            catch (Exception ex)
            {
                return this.HandleException<PurchaseUnit>("根据流程获编号取采购商失败", ex);
            }
        }


        /// <summary>
        ///  新增一条采购商和审批流程记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public void AddPurchaseUnitApproveFlow(PurchaseUnit su, Guid approvalFlowTypeID, Guid userID, string changeNote)
        {
            try
            {
                //增加采购商记录
                this.Add(su);

                //增加审批流程
                ApprovalFlow af = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(approvalFlowTypeID, su.FlowID, userID, changeNote);
                BusinessHandlerFactory.ApprovalFlowBusinessHandler.Add(af);

                //增加审批流程记录
                ApprovalFlowRecord afr = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(af, userID, changeNote);
                BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(afr);

                this.Save();

            }
            catch (Exception ex)
            {
                this.HandleException("新增一条采购商和审批流程记录失败", ex);
            }
        }



        /// <summary>
        ///  修改一条采购商和审批流程记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public void ModifyPurchaseUnitApproveFlow(PurchaseUnit su, Guid approvalFlowTypeID, Guid userID, string changeNote)
        {
            try
            {
                

                if (changeNote.Contains("审批后修改"))
                {
                    ApprovalFlow af = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(approvalFlowTypeID, su.FlowID, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowBusinessHandler.Add(af);
                    ApprovalFlowRecord afr = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(af, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(afr);
                }
                if (changeNote.Contains("审批前修改"))
                {
                    var c = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowsByFlowID(su.FlowID);
                    if (c.ApprovalFlowTypeId != approvalFlowTypeID||c==null||c.ApprovalFlowTypeId==Guid.Empty)
                    {
                        su.FlowID = Guid.NewGuid();
                        ApprovalFlow af = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(approvalFlowTypeID, su.FlowID, userID, changeNote);
                        BusinessHandlerFactory.ApprovalFlowBusinessHandler.Add(af);
                        ApprovalFlowRecord afr = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(af, userID, changeNote);
                        BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(afr);
                    }
                }
                this.Save(su);
                this.Save();

            }
            catch (Exception ex)
            {
                this.HandleException("修改一条采购商和审批流程记录失败", ex);
            }
        }

        /// <summary>
        /// 获取被锁定的采购商
        /// </summary>
        /// <returns></returns>
        public List<PurchaseUnit> GetLockPurchaseUnit()
        {
            return this.Fetch(p => !p.Valid && p.Enabled).ToList();

        }

        /// <summary>
        /// 获取被锁定的采购商的数量
        /// </summary>
        /// <returns></returns>
        public int GetLockPurchaseUnitCount()
        {
            return this.Fetch(p => !p.Valid && p.Enabled).Count();
        }


        /// <summary>
        ///  分页检索被锁定的采购商
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="pageindex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<PurchaseUnit> GetPagedLockPurchaseUnit(out PagerInfo pager, int pageindex, int pageSize)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var varPurchaseUnit = base.Queryable.Where(r=>r.Deleted==false).AsEnumerable();
                varPurchaseUnit = varPurchaseUnit.Where(p => p.Valid==false ||p.Enabled==false);
                pageInfo.RecordCount = varPurchaseUnit.Count();
                pager = pageInfo;
                varPurchaseUnit = varPurchaseUnit.OrderBy(o => o.CreateTime);
                varPurchaseUnit = (skipCount == 0 ? varPurchaseUnit.Take(pageSize) : varPurchaseUnit.Skip(skipCount).Take(pageSize));
                return varPurchaseUnit;
            }
            catch (Exception ex)
            {
                pager = null;
                return this.HandleException<IEnumerable<PurchaseUnit>>("分页检索被锁定的采购商失败", ex);
            }
        }
    }
}
