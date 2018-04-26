using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using Omu.ValueInjecter;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class SupplyUnitBusinessHandler
    {
        /// <summary>
        /// 供货商的经营范围的Code集合
        /// </summary>
        /// <param name="supplyUnitGuid"></param>
        /// <returns></returns>
        public List<string> GetBusinessScopeCodesBySupplyUnitGuid(Guid supplyUnitGuid)
        {
            try
            {
                SupplyUnit supplyUnit = this.Get(supplyUnitGuid);
                if (supplyUnit == null)
                {
                    throw new Exception("供货商不存在");
                }
                return GetBusinessScopeCodesBySupplyUnit(supplyUnit);
            }
            catch (Exception ex)
            {
                return this.HandleException<List<string>>("方法GetBusinessScopeCodesBySupplyUnitGuid出错！！！", ex);
            }
        }

        /// <summary>
        /// 供货商的经营范围的Code集合
        /// </summary>
        /// <param name="supplyUnit"></param>
        /// <returns></returns>
        public List<string> GetBusinessScopeCodesBySupplyUnit(SupplyUnit supplyUnit)
        {
            try
            {
                //var gMSPLicense = BusinessHandlerFactory.GMSPLicenseBusinessHandler
                // .Get(supplyUnit.GMSPLicenseId);
                //return gMSPLicense.GMSPLicenseBusinessScopes.Select(p => p.BusinessScope.Code).ToList();
                List<string> l=new List<string>();
                
                var gSPLicense = BusinessHandlerFactory.GSPLicenseBusinessHandler.Get(supplyUnit.GSPLicenseId);
                if (gSPLicense == null) return null;
                List<GMSPLicenseBusinessScope> gms = gSPLicense.GMSPLicenseBusinessScopes.ToList();
                List<BusinessScope> bs=BusinessHandlerFactory.BusinessScopeBusinessHandler.Queryable.ToList();
                string s=string.Empty;
                var dd = gms.Join(bs, r => r.BusinessScopeId, o => o.Id,(r,o)=>new{Name=o.Name}).ToList();
                if (dd == null) return null;
                foreach (var c in dd)
                {
                    l.Add(c.Name);
                }
                BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "成功读取供货商经营范围：" });
                return l;

            }
            catch (Exception ex)
            {
                return this.HandleException<List<string>>("方法GetBusinessScopeCodesBySupplyUnit出错！！！", ex);
            }
        }

        /// <summary>
        /// 供货商的管理分类的Code集合
        /// </summary>
        /// <param name="supplyUnitGuid"></param>
        /// <returns></returns>
        public List<string> GetManageCategoryDetailBySupplyUnitGuid(Guid supplyUnitGuid)
        {
            try
            {
                SupplyUnit supplyUnit = this.Get(supplyUnitGuid);
                if (supplyUnit == null)
                {
                    throw new Exception("供货商不存在");
                }
                return GetManageCategoryDetailBySupplyUnit(supplyUnit);
            }
            catch (Exception ex)
            {
                return this.HandleException<List<string>>("方法GetManageCategoryDetailBySupplyUnitGuid出错！！！", ex);
            }
        }

        /// <summary>
        /// 供货商的管理分类的Code集合
        /// </summary>
        /// <param name="supplyUnit"></param>
        /// <returns></returns>
        public List<string> GetManageCategoryDetailBySupplyUnit(SupplyUnit supplyUnit)
        {
            try
            {
                //  var gMSPLicense = BusinessHandlerFactory.GMSPLicenseBusinessHandler
                //.Get(supplyUnit.GMSPLicenseId);
                //  return gMSPLicense.BusinessType.BusinessTypeManageCategoryDetails.Select(p => p.PurchaseManageCategoryDetail.Code).ToList();
                var gSPLicense = BusinessHandlerFactory.GSPLicenseBusinessHandler
              .Get(supplyUnit.GMPLicenseId);
                var bt = BusinessHandlerFactory.BusinessTypeBusinessHandler.Get(gSPLicense.BusinessTypeId);
                
                return bt.BusinessTypeManageCategoryDetails.Select(p => p.PurchaseManageCategoryDetail.Code).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<string>>("方法GetManageCategoryDetailBySupplyUnit出错！！！", ex);
            }
        }

        /// <summary>
        /// 根据Flowid 获取供货商
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public SupplyUnit GetSupplyUnitByFlowID(Guid flowId)
        {
            try
            {
                var supplyUnit = this.Fetch(p => p.FlowID == flowId).FirstOrDefault();

                return supplyUnit;
            }
            catch (Exception ex)
            {
                return this.HandleException<SupplyUnit>("方法GetSupplyUnitByFlowID出错！！！", ex);
            }
        }


        /// <summary>
        ///  新增一条供货商和审批流程记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public void AddSupplyUnitApproveFlow(SupplyUnit su, Guid approvalFlowTypeID, Guid userID, string changeNote)
        {
            try
            {
                //增加供货商记录
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
                this.HandleException("方法AddSupplyUnitApproveFlow出错！！！", ex);
            }
        }



        /// <summary>
        ///  修改一条供货商和审批流程记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public void ModifySupplyUnitApproveFlow(SupplyUnit su, Guid approvalFlowTypeID, Guid userID, string changeNote)
        {
            try
            {
                this.Save(su);

                if (changeNote.Contains("审批后修改"))
                {
                    ApprovalFlow af = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(approvalFlowTypeID, su.FlowID, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowBusinessHandler.Add(af);

                    ApprovalFlowRecord afr = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(af, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(afr);
                }
                else
                {
                    var c = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowsByFlowID(su.FlowID);
                    if (c == null || c.ApprovalFlowTypeId.Equals(Guid.Empty)||c.ApprovalFlowTypeId!=approvalFlowTypeID)
                    {
                        
                        ApprovalFlow af = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(approvalFlowTypeID, su.FlowID, userID, changeNote);
                        BusinessHandlerFactory.ApprovalFlowBusinessHandler.Add(af);

                        ApprovalFlowRecord afr = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(af, userID, changeNote);
                        BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(afr);
                    }
                }
                
                this.Save();
            }
            catch (Exception ex)
            {
                this.HandleException("方法AddSupplyUnitApproveFlow出错！！！", ex);
            }
        }

        /// <summary>
        /// 查找供应商For选择界面
        /// </summary>
        /// <param name="drugGuid"></param>
        /// <param name="name"></param>
        /// <param name="pinyin"></param>
        /// <param name="jyfwcode"></param>
        /// <returns></returns>
        public List<SupplyUnit> GetSupplyUnitForSupplyUnitSelector(Guid drugGuid, string name, string pinyin, string[] jyfwcode)
        {
            try
            {
                var all = this.Queryable.Where(p => p.Valid == true && p.Enabled == true);
                if (!string.IsNullOrWhiteSpace(name))
                {
                    all = all.Where(p => p.Name.Contains(name));
                }
                if (!string.IsNullOrWhiteSpace(pinyin))
                {
                    all = all.Where(p => p.PinyinCode.Contains(pinyin));
                }
                
                return all.ToList();
            }
            catch (Exception ex)
            {
                this.HandleException("方法GetSupplyUnitForSupplyUnitSelector出错！！！", ex);
                return null;
            }
        }


        /// <summary>
        /// 查找供应商单位名称是否已存在
        /// </summary> 
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool IsExistSupplyUnitByName(string name)
        {
            try
            {
                SupplyUnit a = this.Fetch(r => r.Name == name).FirstOrDefault();
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
                this.HandleException("方法IsExistSupplyUnitByName出错！！！", ex);
                return false;
            }
        }

        /// <summary>
        /// 根据Name获取供应商单位 
        /// </summary> 
        /// <param name="name"></param> 
        /// <returns></returns>
        public SupplyUnit GetSupplyUnitByName(string name)
        {
            try
            {
                SupplyUnit a = this.Fetch(r => r.Name == name).FirstOrDefault();
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
                this.HandleException("方法GetSupplyUnitByName出错！！！", ex);
                return null;
            }
        }

        /// <summary>
        /// 根据Name更新供应商单位 
        /// </summary> 
        /// <param name="name"></param> 
        /// <returns></returns>
        public bool UpdateSupplyUnitByName(string name, SupplyUnit item)
        {
            try
            {
                SupplyUnit a = this.Fetch(r => r.Name == name).FirstOrDefault();
                if (a != null)
                {
                    a.QualityAgreementOutdate = item.QualityAgreementOutdate;
                    a.AttorneyAattorneyOutdate = item.AttorneyAattorneyOutdate;
                    a.SupplyProductClass = item.SupplyProductClass;
                    a.QualityCharger = item.QualityCharger;
                    a.BankAccountName = item.BankAccountName;
                    a.Bank = item.Bank;
                    a.BankAccount = item.BankAccount;
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
                    a.UnitTypeId = item.UnitTypeId;

                    BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "根据名称成功更新供货商" });
                    //抽空测试
                    //a.InjectFrom(item);
                    this.Save();
                    return true;
                }
                else
                {
                    throw new BusinessException("不存在单位名称为'" + name + "'的供应商");
                }
            }
            catch (Exception ex)
            {
                this.HandleException("方法UpdateSupplyUnitByName出错！！！", ex);
                return false;
            }
        }

        /// <summary>
        /// 获取被锁定的供应商
        /// </summary>
        /// <returns></returns>
        public List<SupplyUnit> GetLockSupplyUnitUnit()
        {
            try
            {
                return this.Fetch(p => !p.Valid && p.Enabled).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<SupplyUnit>>("方法获取被锁定的供应商出错！！！", ex);

            }
        }

        /// <summary>
        ///  分页检索被锁定的供应商
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="pageindex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<SupplyUnit> GetPagedLockSupplyUnitUnit(out PagerInfo pager, int pageindex, int pageSize)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var varSupply = base.Queryable.Where(r=>r.Deleted==false).AsEnumerable();
                varSupply=varSupply.Where(p => p.Valid==false ||p.Enabled==false );  
              
                pageInfo.RecordCount = varSupply.Count();
                pager = pageInfo;
                varSupply = varSupply.OrderBy(o => o.CreateTime);
                varSupply = (skipCount == 0 ? varSupply.Take(pageSize) : varSupply.Skip(skipCount).Take(pageSize));
                return varSupply;
            }
            catch (Exception ex)
            {
                pager = null;
                return this.HandleException<IEnumerable<SupplyUnit>>("分页检索被锁定的供应商！！！", ex);
            }
        }

        /// <summary>
        /// 获取被锁定的供应商的数量
        /// </summary>
        /// <returns></returns>
        public int GetLockSupplyUnitCount()
        {
            return this.Fetch(p => !p.Valid && p.Enabled).Count();

        }

        public Models.SupplyUnit[] GetSupplyUnitsByKeywords(string Keyword,bool IsAccurate)
        {
            var c = IsAccurate ? this.Queryable.AsEnumerable().Where(r => r.Valid && !r.Deleted && r.PinyinCode != null).Where(r => r.PinyinCode.ToUpper() == Keyword.ToUpper() || r.Name == Keyword) : this.Queryable.Where(r => r.Valid && !r.Deleted && r.PinyinCode != null).Where(r => r.Name.Contains(Keyword) || r.PinyinCode.ToUpper().Contains(Keyword.ToUpper()));
            return c.OrderBy(r=>r.Name).ToArray();
        }


        public System.Collections.Generic.IEnumerable<Business.Models.Model_IdName> GetSuplyUnitIdNamesByQueryModel( Business.Models.BaseQueryModel q)
        {
            var all = this.RepositoryProvider.Db.SupplyUnits.Where(r=>r.Deleted==false);

            if (!string.IsNullOrEmpty(q.Keyword))
            {
                all = all.Where(r => r.PinyinCode.Contains(q.Keyword) || r.Name.Contains(q.Keyword));
            }
            var re = all.ToList().Select(r => new Business.Models.Model_IdName
            {
                Id=r.Id,
                Name=r.Name,
                PinYin=r.PinyinCode,
                IsValid=r.Valid
            });
            return re.OrderBy(r => r.Name);
        }
    }
}
