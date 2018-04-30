using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using System.Linq.Expressions;
using BugsBox.Pharmacy.Repository;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class DrugInfoBusinessHandler
    {
        protected override IQueryable<DrugInfo> IncludeNavigationProperties(IQueryable<DrugInfo> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(
               queryable.Include(t => t.DrugInventoryRecords)
               );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DrugInfo>>(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询采购商有权限的药品
        /// </summary>
        /// <param name="purchaseUnitGuid"></param>
        /// <returns></returns>
        public IEnumerable<DrugInfo> GetDrugInfoByPurchaseUnit(Guid purchaseUnitGuid)
        {
            try
            {
                PurchaseUnit purchaseUnit = null;
                if (purchaseUnitGuid != Guid.Empty)
                {
                    purchaseUnit = BusinessHandlerFactory.PurchaseUnitBusinessHandler.Get(purchaseUnitGuid);

                    if (purchaseUnit == null)
                    {
                        throw new Exception("采购商不存在");
                    }
                    if (!purchaseUnit.Enabled)
                    {
                        throw new Exception("采购商没开启");
                    }
                    if (!purchaseUnit.Valid)
                    {
                        throw new Exception("采购商被锁定");
                    }

                    List<string> businessScope = BusinessHandlerFactory.PurchaseUnitBusinessHandler.GetBusinessScopeCodesByPurchaseUnit(purchaseUnit);
                    List<string> manageCategoryDetail = BusinessHandlerFactory.PurchaseUnitBusinessHandler.GetManageCategoryDetailByPurchaseUnit(purchaseUnit);
                    var result = this.Fetch(p => p.Valid && p.Enabled);//庄子不控
                    //var result = this.Fetch(p => p.Valid && p.Enabled && businessScope.Contains(p.BusinessScopeCode));
                    if (manageCategoryDetail.Count() > 0)
                    {
                        result = result.Where(p => manageCategoryDetail.Contains(p.PurchaseManageCategoryDetailCode));
                    }

                    return result;
                }
                else
                {
                    return this.Fetch(p => p.Valid && p.Enabled);
                }
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<DrugInfo>>("查询采购商有权限的药品失败", ex);
            }

        }



        /// <summary>
        /// 查询供应商有权限的药品
        /// </summary>
        /// <param name="purchaseUnitGuid"></param>
        /// <returns></returns>
        public IEnumerable<DrugInfo> GetDrugInfoBySupplyUnit(Guid supplyUnitGuid)
        {
            try
            {
                SupplyUnit supplyUnit = BusinessHandlerFactory.SupplyUnitBusinessHandler.Get(supplyUnitGuid);
                if (supplyUnit == null)
                {
                    throw new Exception("供应商不存在");
                }
                if (!supplyUnit.Enabled)
                {
                    throw new Exception("供应商未开启");
                }
                if (!supplyUnit.Valid)
                {
                    throw new Exception("供应商被锁定");
                }
                List<string> businessScope = BusinessHandlerFactory.SupplyUnitBusinessHandler.GetBusinessScopeCodesBySupplyUnit(supplyUnit);
                if (businessScope == null) return null;

                //List<string> manageCategoryDetail = BusinessHandlerFactory.SupplyUnitBusinessHandler.GetManageCategoryDetailBySupplyUnit(supplyUnit);
                var result = this.Fetch(p => p.Valid && p.Enabled && businessScope.Contains(p.BusinessScopeCode));

                return result;

            }
            catch (Exception ex)
            {
                return this.HandleException<List<DrugInfo>>("查询供应商有权限的药品结果为0", ex);
            }
            finally
            {
                this.Dispose();
            }

        }

        /// <summary>
        /// 检查数据是否已存在
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool IsExistDrugInfo(DrugInfo info)
        {
            try
            {
                if (this.Fetch(r => r.Code == info.Code).FirstOrDefault() != null)
                {
                    throw new BusinessException("'编码'已存在");
                }
                if (this.Fetch(r => r.BarCode == info.BarCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'条形码'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'药品本位码'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'药品名称'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'药品通用名'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'药品其他名称'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'厂家全称'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'厂家简称'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'拆零规格'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'拆零数量'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'特殊管理药品类型'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'批准文号'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'执行标准'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'包装'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'经营范围'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'药品管理分类详细'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'药品分类'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'医疗详细分类'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'临床分类'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'自定义类型'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'存储方式'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'药品单位'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'剂型'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'规格'已存在");
                }
                if (this.Fetch(r => r.StandardCode == info.StandardCode).FirstOrDefault() != null)
                {
                    throw new BusinessException("'拆零单位'已存在");
                }
            }
            catch (BusinessException ex)
            {
                return this.HandleException<bool>("检查数据是否已存在失败", ex);
            }

            return true;
        }

        /// <summary>
        /// 查找药品for药品选择界面
        /// </summary>
        /// <param name="purchaseUnitGuid"></param>
        /// <param name="tym"></param>
        /// <param name="bwm"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<DrugInfo> GetDrugInfoForDrugInfoForSalesSelector(Guid purchaseUnitGuid, string tym, string bwm, string code)
        {
            try
            {
                var all = GetDrugInfoByPurchaseUnit(purchaseUnitGuid).AsQueryable();
                if (!string.IsNullOrWhiteSpace(tym))
                {
                    all = all.Where(p => p.ProductGeneralName.Contains(tym));
                }
                if (!string.IsNullOrWhiteSpace(bwm))
                {
                    all = all.Where(p => p.StandardCode.Contains(bwm));
                }
                if (!string.IsNullOrWhiteSpace(code))
                {
                    all = all.Where(p => p.Code.Contains(code));
                }
                all = all.Where(p => p.DrugInventoryRecords.Sum(t => t.CanSaleNum) > 0);
                all.ForEach(p => p.DrugInventoryRecords = p.DrugInventoryRecords.Where(t => t.CanSaleNum > 0 && t.Valid).ToList());
                return all.ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<DrugInfo>>("查找药品失败", ex);
            }
        }

        /// <summary>
        /// 查询采购药品选择界面
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="productGeneralName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<DrugInfo> GetDrugInfoForPurchasing(string productName, string productGeneralName, string code)
        {
            try
            {
                //示例
                //var queryBuilder = QueryBuilder.Create<Order>()
                //.Like(c => c.Customer.ContactName, txtCustomer.Text)
                //.Between(c => c.OrderDate, DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text))
                //.Equals(c => c.EmployeeID, int.Parse(ddlEmployee.SelectedValue))
                //.In(c => c.ShipCountry, selectedCountries); 
                //                var query = BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos.Where(queryBuilder.Expression).Skip(pageIndex).Take(10);
                var queryBuilder = QueryBuilder.Create<DrugInfo>()
                 .Like(q => q.ProductName, productName)
                 .Like(q => q.ProductGeneralName, productGeneralName)
                 .Like(q => q.Code, code)
                 .Equals(q => q.Enabled, true)
                 .Equals(q => q.Valid, true);

                var query = BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos.Where(queryBuilder.Expression);
                return query.ToList();

            }
            catch (Exception ex)
            {
                return this.HandleException<List<DrugInfo>>("查询采购药品失败", ex);
            }
        }


        /// <summary>
        /// 对供货单位选择药品，有查询条件
        /// </summary>
        /// <param name="supplyUnitId"></param>
        /// <param name="generalName"></param>
        /// <param name="code"></param>
        /// <param name="standardCode"></param>
        /// <returns></returns>
        public List<DrugInfo> GetDrugInfoForSupplyUnitWithQueryParas(Guid supplyUnitId, string generalName, string code, string standardCode)//standardCode作为拼音
        {
            try
            {
                var all = GetDrugInfoBySupplyUnit(supplyUnitId).AsQueryable();
                if (!string.IsNullOrWhiteSpace(generalName))
                {
                    all = all.Where(p => p.ProductGeneralName.Contains(generalName));
                }
                if (!string.IsNullOrWhiteSpace(standardCode))
                {
                    all = all.Where(p => p.Pinyin.ToUpper().Contains(standardCode.ToUpper()));
                }
                if (!string.IsNullOrWhiteSpace(code))
                {
                    all = all.Where(p => p.Code.Contains(code));
                }

                all = all.Where(p => p.Valid);

                return all.ToList();

            }
            catch (Exception ex)
            {
                return this.HandleException<List<DrugInfo>>("对供货单位选择药品，有查询条件失败", ex);
            }
        }



        /// <summary>
        /// 药品缺货查询
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LackDrugModel> GetDrugInfoForOutofStock(int stockLower, DateTime? begindate = null, DateTime? enddate = null)
        {
            try
            {
                var dirs = RepositoryProvider.Db.DrugInventoryRecords.Where(r => !r.Deleted);
                var queryInventory = dirs.GroupBy(c => c.DrugInfoId).Select(c => new
                {
                    drugInfoId = c.Key,
                    inventoryNum = c.Sum(n => n.CurrentInventoryCount),
                    canSaleNum = c.Sum(n => n.CanSaleNum),
                    wholePrice = c.Sum(n => n.CurrentInventoryCount * n.PurchasePricce),
                    wholeSales = c.Sum(n => n.InInventoryCount) - c.Sum(n => n.CanSaleNum),
                });





                var piids = RepositoryProvider.Db.PurchaseInInventeryOrderDetails.Where(r => !r.Deleted);
                var queryInventoryOrder = piids.OrderByDescending(o => o.ArrivalDateTime).GroupBy(c => c.DrugInfoId).Select(c => new
                {
                    drugInfoId = c.Key,
                    purchasePrice = c.FirstOrDefault().PurchasePrice,
                    lastPurchaseDate = c.FirstOrDefault().ArrivalDateTime,

                });

                var listWarehouseZone = RepositoryProvider.Db.WarehouseZones.Where(w => !w.Deleted);

                var result = (from i in queryInventory
                              join j in RepositoryProvider.Db.DrugInfos on i.drugInfoId equals j.Id
                              join k in queryInventoryOrder on i.drugInfoId equals k.drugInfoId
                              join w in RepositoryProvider.Db.Warehouses on j.WareHouses equals w.Id
                              //where i.canSaleNum <= j.MinInventoryCount
                              //where i.canSaleNum <= stockLower
                              select new Business.Models.LackDrugModel
                              {
                                  BusinessScopeCode = j.BusinessScopeCode,
                                  Code = j.Code,
                                  DictionaryDosageCode = j.DictionaryDosageCode,
                                  DictionaryMeasurementUnitCode = j.DictionaryMeasurementUnitCode,
                                  DictionarySpecificationCode = j.DictionarySpecificationCode,
                                  FactoryName = j.FactoryName,
                                  Origin = j.Origin,
                                  MinInventoryCount = j.MinInventoryCount,
                                  pinyin = j.Pinyin,
                                  LicensePermissionNumber = j.LicensePermissionNumber,
                                  ProductGeneralName = j.ProductGeneralName,
                                  ProductName = j.ProductName,
                                  StandardCode = j.StandardCode,
                                  CurrentCanSaleCount = i.canSaleNum,
                                  CurrentInventoryCount = i.inventoryNum,
                                  PurchasePrice = k.purchasePrice,
                                  dtime = k.lastPurchaseDate,
                                  wholeSales = i.wholeSales,
                                  wareHouse = w.Name
                              });

                if (stockLower < 0)
                {
                    result = result.Where(o => o.CurrentCanSaleCount <= o.MinInventoryCount);
                }
                else
                {
                    result = result.Where(o => o.CurrentCanSaleCount <= stockLower);
                }


                return result;

            }
            catch (Exception ex)
            {
                return this.HandleException<List<LackDrugModel>>("药品缺货查询失败", ex);
            }
        }


        /// <summary>
        /// 根据Flowid 获取采购商
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public DrugInfo GetDrugInfoByFlowID(Guid flowId)
        {
            try
            {
                var DrugInfo = this.Fetch(p => p.FlowID == flowId).FirstOrDefault();

                return DrugInfo;
            }
            catch (Exception ex)
            {
                return this.HandleException<DrugInfo>("获取采购商失败", ex);
            }
        }

        //WFZ modified
        /// <summary>
        /// 根据Flowid 获取药品信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public DrugInfo GetGoodsInfoByFlowID(Guid flowId)
        {
            try
            {
                var DrugInfo = this.Fetch(p => p.FlowID == flowId).FirstOrDefault();

                return DrugInfo;
            }
            catch (Exception ex)
            {
                return this.HandleException<DrugInfo>("获取药品信息", ex);
            }
        }
        //end


        /// <summary>
        ///  新增一条药品和审批流程记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public void AddDrugInfoApproveFlow(DrugInfo su, Guid approvalFlowTypeID, Guid userID, string changeNote)
        {
            try
            {
                //增加药品记录
                this.Add(su);
                if (su.GoodsType != GoodsType.DrugDomestic && su.GoodsType != GoodsType.DrugImport)
                {
                    if (su.GoodsAdditionalProperty != null)
                        RepositoryProvider.Db.GoodsAdditionalPropertys.Add(su.GoodsAdditionalProperty);
                }
                if (approvalFlowTypeID != Guid.Empty)
                {
                    //增加审批流程
                    ApprovalFlow af = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(approvalFlowTypeID, su.FlowID, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowBusinessHandler.Add(af);

                    //增加审批流程记录
                    ApprovalFlowRecord afr = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(af, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(afr);
                }

                this.Save();

            }
            catch (Exception ex)
            {
                this.HandleException("新增一条药品和审批流程记录失败", ex);
            }
        }



        /// <summary>
        ///  修改一条药品和审批流程记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public void ModifyDrugInfoApproveFlow(DrugInfo su, Guid approvalFlowTypeID, Guid userID, string changeNote)
        {
            try
            {
                if (su.GoodsType != GoodsType.DrugDomestic && su.GoodsType != GoodsType.DrugImport)
                {
                    BusinessHandlerFactory.GoodsAdditionalPropertyBusinessHandler.Save(su.GoodsAdditionalProperty);
                }

                if (changeNote.Contains("审核后修改"))
                {
                    ApprovalFlow af = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(approvalFlowTypeID, su.FlowID, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowBusinessHandler.Add(af);

                    ApprovalFlowRecord afr = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(af, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(afr);
                }


                if (changeNote.Contains("审核前修改"))
                {
                    var c = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowsByFlowID(su.FlowID);
                    if (c.ApprovalFlowTypeId != approvalFlowTypeID || c == null || c.ApprovalFlowTypeId == Guid.Empty)
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
                this.HandleException("修改一条药品和审批流程记录失败", ex);
            }
        }

        /// <summary>
        /// 获取被锁定的药品
        /// </summary>
        /// <returns></returns>
        public List<DrugInfo> GetLockDrugInfo()
        {
            return this.Fetch(p => !p.Valid && p.Enabled).ToList();

        }

        /// <summary>
        /// 获取被锁定的药品的数量
        /// </summary>
        /// <returns></returns>
        public int GetLockDrugInfoCount()
        {
            return this.Fetch(p => !p.Valid && p.Enabled).Count();

        }


        /// <summary>
        ///  分页检索被锁定的药品信息
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="pageindex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<DrugInfo> GetPagedLockDrugInfo(out PagerInfo pager, int pageindex, int pageSize)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var varDrugInfo = base.Queryable;
                varDrugInfo = varDrugInfo.Where(p => !p.Valid && p.Enabled);
                pageInfo.RecordCount = varDrugInfo.Count();
                pager = pageInfo;
                varDrugInfo = varDrugInfo.OrderBy(o => o.CreateTime);
                varDrugInfo = (skipCount == 0 ? varDrugInfo.Take(pageSize) : varDrugInfo.Skip(skipCount).Take(pageSize));
                return varDrugInfo.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                pager = null;
                return this.HandleException<IEnumerable<DrugInfo>>("分页检索被锁定的药品信息失败", ex);
            }
        }

        public List<DrugInfo> SearchPagedDrugInfosByAllStrings(string keys, int index, int size, out PagerInfo pager)
        {
            pager = PagerInfo.Validate(new PagerInfo { Index = index, Size = size });
            try
            {
                List<DrugInfo> records = new List<DrugInfo>();
                var queryBuilder = QueryBuilder.Create<DrugInfo>();
                Expression<Func<DrugInventoryRecord, bool>> expression = dir => true;
                var query = this.Queryable;
                query = query.Where(PreparePredicate(queryBuilder.Expression));
                if (!string.IsNullOrWhiteSpace(keys))
                {
                    query = query.Where(d => false
                         //编码
                         || (d.Code != null && d.Code.Contains(keys))
                         //商品名称
                         || (d.ProductName != null && d.ProductName.Contains(keys))
                         //拼音码
                         || (d.Pinyin != null && d.Pinyin.Contains(keys))
                         //条形码
                         || (d.BarCode != null && d.BarCode.Contains(keys))
                         //规格
                         || (d.DictionarySpecificationCode != null && d.DictionarySpecificationCode.Contains(keys))
                         //剂型
                         || (d.DictionaryDosageCode != null && d.DictionaryDosageCode.Contains(keys))
                         //计量单位
                         || (d.DictionaryMeasurementUnitCode != null && d.DictionaryMeasurementUnitCode.Contains(keys))
                         //厂家
                         || (d.FactoryName != null && d.FactoryName.Contains(keys))
                         //特殊药物
                         || (d.SpecialDrugCategoryCode != null && d.SpecialDrugCategoryCode.Contains(keys))
                         //经营范围
                         || (d.BusinessScopeCode != null && d.BusinessScopeCode.Contains(keys))
                        );
                }
                pager.RecordCount = query.Count();  //处理总录条数
                query = query.OrderBy(d => d.BarCode)
                    .OrderBy(d => d.ProductName);
                records = query
                    .Skip((pager.Index - 1) * pager.Size)
                    .Take(pager.Size)
                    .ToList();
                return records;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<DrugInfo>>("根据字符串查询药物基础信息失败", ex);
            }
        }

        /// <summary>
        /// 查询药品基础信息
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="pager"></param>
        /// <param name="ValidCondition"></param>
        /// <returns></returns>
        public IEnumerable<Business.Models.DrugInfoModel> GetDrugInfoByCondition(string keys, int index, int size, out PagerInfo pager, bool ValidCondition)
        {
            pager = PagerInfo.Validate(new PagerInfo { Index = index, Size = size });
            try
            {
                var all = this.Queryable;
                if (!string.IsNullOrEmpty(keys))
                    all = all.Where(r => (r.Pinyin != null && r.Pinyin.ToUpper().Contains(keys.ToUpper())) || (r.ProductGeneralName != null && r.ProductGeneralName.Contains(keys)) || (r.BusinessScopeCode != null && r.BusinessScopeCode.Contains(keys)) || (r.DictionaryDosageCode != null && r.DictionaryDosageCode.Contains(keys)) || (r.DictionarySpecificationCode != null && r.DictionarySpecificationCode.Contains(keys)));

                all = all.Where(r => !r.BusinessScopeCode.Contains("医疗器械") || !r.BusinessScopeCode.Contains("保健食品"));//医疗器械和保健食品不查

                if (ValidCondition)//查询被锁定药品
                    all = all.Where(r => r.Valid == false);
                var c = from i in all
                        join w in RepositoryProvider.Db.Warehouses on i.WareHouses equals w.Id
                        join u in RepositoryProvider.Db.Users on i.CreateUserId equals u.Id
                        select new Business.Models.DrugInfoModel
                        {
                            BarCode = i.BarCode,
                            BigPackage = i.BigPackage,
                            BusinessScopeCode = i.BusinessScopeCode,
                            Code = i.Code,
                            CreateTime = i.CreateTime,
                            CreateUserId = u.Employee.Name,
                            DictionaryDosageCode = i.DictionaryDosageCode,
                            DictionaryMeasurementUnitCode = i.DictionaryMeasurementUnitCode,
                            DictionaryPiecemealUnitCode = i.DictionaryPiecemealUnitCode,
                            DictionarySpecificationCode = i.DictionarySpecificationCode,
                            DocCode = i.DocCode,
                            DrugCategoryCode = i.DrugCategoryCode,
                            DrugClinicalCategoryCode = i.DrugClinicalCategoryCode,
                            DrugStorageTypeCode = i.DrugStorageTypeCode,
                            FactoryName = i.FactoryName,
                            id = i.Id,
                            IsApproval = i.IsApproval == true ? "审批通过" : "未审批通过",
                            IsImport = i.IsImport == true ? "进口" : "非进口",
                            IsMainMaintenance = i.IsMainMaintenance ? "重点养护" : "一般养护",
                            IsMedicalInsurance = i.IsMedicalInsurance ? "医保药品" : "非医保药品",
                            IsPrescription = i.IsPrescription ? "处方药" : "非处方药",
                            IsSpecialDrugCategory = i.IsSpecialDrugCategory ? "特殊管理药品" : "非特殊管理药品",
                            LicensePermissionNumber = i.LicensePermissionNumber,
                            LimitedUpPrice = i.LimitedUpPrice,
                            MaxInventoryCount = i.MaxInventoryCount,
                            MedicalCategoryDetailCode = i.MedicalCategoryDetailCode,
                            MiddlePackage = i.MiddlePackage,
                            MinInventoryCount = i.MinInventoryCount,
                            Origin = i.Origin,
                            Package = i.Package,
                            PackageAmount = i.PackageAmount,
                            PerformanceStandards = i.PerformanceStandards,
                            PermitLicenseCode = i.PermitLicenseCode,
                            PiecemealNumber = i.PiecemealNumber,
                            PiecemealSpecification = i.PiecemealSpecification,
                            Pinyin = i.Pinyin,
                            Price = i.Price,
                            ProductGeneralName = i.ProductGeneralName,
                            ProductName = i.ProductName,
                            PurchaseManageCategoryDetailCode = i.PurchaseManageCategoryDetailCode,
                            RetailPrice = i.RetailPrice,
                            SalePrice = i.SalePrice,
                            SmallPackage = i.SmallPackage,
                            SpecialDrugCategoryCode = i.SpecialDrugCategoryCode,
                            StandardCode = i.StandardCode,
                            Valid = i.Valid ? "有效" : "无效",
                            ValidPeriod = i.ValidPeriod,
                            WareHouses = w.Name,
                            WholeSalePrice = i.WholeSalePrice,
                            Description = i.Description,
                            WareHouseZones = i.WareHouseZones
                        };
                pager.RecordCount = c.Count();
                c = c.OrderBy(d => d.Code).ThenBy(r => r.ProductGeneralName);
                var records = c
                    .Skip((pager.Index - 1) * pager.Size)
                    .Take(pager.Size)
                    .ToList();

                records.ForEach(r =>
                {
                    if (!string.IsNullOrEmpty(r.WareHouseZones))
                    {
                        Guid wzid = Guid.Parse(r.WareHouseZones);
                        var wz = RepositoryProvider.Db.WarehouseZones.FirstOrDefault(u => u.Id == wzid);
                        if (wz != null)
                            r.WareHouseZones = wz.Name;
                    }
                });
                return records;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 查询医疗器械基础信息
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="pager"></param>
        /// <param name="ValidCondition"></param>
        /// <returns></returns>
        public IEnumerable<Business.Models.InstrumentsModel> GetInstrumentsByCondition(string keys, int index, int size, out PagerInfo pager, bool ValidCondition)
        {
            pager = PagerInfo.Validate(new PagerInfo { Index = index, Size = size });
            try
            {
                var all = this.Queryable.Where(r => r.BusinessScopeCode.Contains("医疗器械"));
                if (!string.IsNullOrEmpty(keys))
                    all = all.Where(r => (r.Pinyin != null && r.Pinyin.ToUpper().Contains(keys.ToUpper())) || (r.ProductGeneralName != null && r.ProductGeneralName.Contains(keys)) || (r.DictionaryDosageCode != null && r.DictionaryDosageCode.Contains(keys)) || (r.DictionarySpecificationCode != null && r.DictionarySpecificationCode.Contains(keys)));

                if (ValidCondition)//查询被锁定器械
                    all = all.Where(r => r.Valid == false);

                var c = from i in all
                        join w in RepositoryProvider.Db.Warehouses on i.WareHouses equals w.Id
                        join u in RepositoryProvider.Db.Users on i.CreateUserId equals u.Id
                        select new Business.Models.InstrumentsModel
                        {
                            BusinessScopeCode = i.BusinessScopeCode,
                            CreateTime = i.CreateTime,
                            CreateUserName = u.Employee.Name,
                            DictionaryDosageCode = i.DictionaryDosageCode,
                            DictionaryMeasurementUnitCode = i.DictionaryMeasurementUnitCode,
                            DictionarySpecificationCode = i.DictionarySpecificationCode,
                            DocCode = i.DocCode,
                            Code = i.Code,
                            DrugCategoryCode = i.DrugCategoryCode,
                            DrugStorageTypeCode = i.DrugStorageTypeCode,
                            FactoryName = i.FactoryName,
                            Id = i.Id,
                            IsApproval = i.IsApproval == true ? "审批通过" : "未审批通过",
                            IsImport = i.IsImport == true ? "进口" : "非进口",
                            LicensePermissionNumber = i.LicensePermissionNumber,
                            LimitedUpPrice = i.LimitedUpPrice,
                            MaxInventoryCount = i.MaxInventoryCount,
                            MinInventoryCount = i.MinInventoryCount,
                            PerformanceStandards = i.PerformanceStandards,
                            Pinyin = i.Pinyin,
                            Price = i.Price,
                            ProductGeneralName = i.ProductGeneralName,
                            SalePrice = i.SalePrice,
                            StandardCode = i.StandardCode,
                            Valid = i.Valid == true ? "有效" : "无效",
                            ValidPeriod = i.ValidPeriod,
                            WareHouses = w.Name,
                            Locked = i.IsLock == true ? "锁定" : "未锁定",
                            NotValidReason = i.ValidRemark,
                            WareHouseZone = i.WareHouseZones,
                            BarCode = i.BarCode,
                            LimitedLowPrice = i.LimitedLowPrice,
                            Contact = i.FactoryNameAbbreviation,
                            Description = i.Description,
                            InstEntProductLiscencePermitNumber = i.InstEntProductLiscencePermitNumber
                        };
                pager.RecordCount = c.Count();
                c = c.OrderBy(d => d.Code).ThenBy(r => r.ProductGeneralName);
                var records = c
                    .Skip((pager.Index - 1) * pager.Size)
                    .Take(pager.Size)
                    .ToList();

                records.ForEach(r =>
                {
                    if (!string.IsNullOrEmpty(r.WareHouseZone))
                    {
                        Guid wzid = Guid.Parse(r.WareHouseZone);
                        var wz = RepositoryProvider.Db.WarehouseZones.FirstOrDefault(u => u.Id == wzid);
                        if (wz != null)
                            r.WareHouseZone = wz.Name;
                    }
                });

                return records;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 查询保健食品
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="pager"></param>
        /// <param name="ValidCondition"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<Business.Models.FoodModel> GetFoodByCondition(string keys, int index, int size, out BugsBox.Application.Core.PagerInfo pager, bool ValidCondition)
        {
            pager = PagerInfo.Validate(new PagerInfo { Index = index, Size = size });
            try
            {
                var all = this.Queryable.Where(r => r.BusinessScopeCode.Contains("保健食品"));
                if (!string.IsNullOrEmpty(keys))
                    all = all.Where(r => (r.Pinyin != null && r.Pinyin.ToUpper().Contains(keys.ToUpper())) || (r.ProductGeneralName != null && r.ProductGeneralName.Contains(keys)) || (r.DictionaryDosageCode != null && r.DictionaryDosageCode.Contains(keys)) || (r.DictionarySpecificationCode != null && r.DictionarySpecificationCode.Contains(keys)));

                if (ValidCondition)//查询被锁定保健食品
                    all = all.Where(r => r.Valid == false);

                var c = from i in all
                        join w in RepositoryProvider.Db.Warehouses on i.WareHouses equals w.Id
                        join u in RepositoryProvider.Db.Users on i.CreateUserId equals u.Id
                        select new Business.Models.FoodModel
                        {
                            BusinessScopeCode = i.BusinessScopeCode,
                            CreateTime = i.CreateTime,
                            CreateUserName = u.Employee.Name,
                            DictionaryDosageCode = i.DictionaryDosageCode,
                            DictionaryMeasurementUnitCode = i.DictionaryMeasurementUnitCode,
                            DictionarySpecificationCode = i.DictionarySpecificationCode,
                            DocCode = i.DocCode,
                            Code = i.Code,
                            DrugStorageTypeCode = i.DrugStorageTypeCode,
                            FactoryName = i.FactoryName,
                            Id = i.Id,
                            IsApproval = i.IsApproval == true ? "审批通过" : "未审批通过",
                            IsImport = i.IsImport == true ? "进口" : "非进口",
                            LicensePermissionNumber = i.LicensePermissionNumber,
                            LimitedUpPrice = i.LimitedUpPrice,
                            MaxInventoryCount = i.MaxInventoryCount,
                            MinInventoryCount = i.MinInventoryCount,
                            PerformanceStandards = i.PerformanceStandards,
                            Pinyin = i.Pinyin,
                            Price = i.Price,
                            ProductGeneralName = i.ProductGeneralName,
                            SalePrice = i.SalePrice,
                            Origin = i.Origin,
                            LicensePermissionOutValidDate = i.PermitOutDate,
                            Valid = i.Valid == true ? "有效" : "无效",
                            ValidPeriod = i.ValidPeriod,
                            WareHouses = w.Name,
                            Locked = i.IsLock == true ? "锁定" : "未锁定",
                            NotValidReason = i.ValidRemark,
                            WareHouseZone = i.WareHouseZones,
                            BarCode = i.BarCode,
                            LimitedLowPrice = i.LimitedLowPrice,
                            Contact = i.FactoryNameAbbreviation,
                            Description = i.Description,
                        };
                pager.RecordCount = c.Count();
                c = c.OrderBy(d => d.Code).ThenBy(r => r.ProductGeneralName);
                var records = c
                    .Skip((pager.Index - 1) * pager.Size)
                    .Take(pager.Size)
                    .ToList();

                records.ForEach(r =>
                {
                    if (!string.IsNullOrEmpty(r.WareHouseZone))
                    {
                        Guid wzid = Guid.Parse(r.WareHouseZone);
                        var wz = RepositoryProvider.Db.WarehouseZones.FirstOrDefault(u => u.Id == wzid);
                        if (wz != null)
                            r.WareHouseZone = wz.Name;
                    }
                });

                return records;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }

        public int GetDrugInfoCount(string BusinessScopeType)
        {
            int DrugsCount = 0;
            if (string.IsNullOrEmpty(BusinessScopeType))
            {
                DrugsCount = this.Queryable.Count();
            }
            else
            {
                DrugsCount = this.Queryable.Where(r => r.BusinessScopeCode.Contains(BusinessScopeType)).Count();
            }
            return DrugsCount;
        }

        /// <summary>
        /// 直调药品过滤
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Models.DrugInfo[] GetDrugInfoByKeyword(Business.Models.DirectSalesQueryModel m)
        {
            var d = this.Queryable.AsEnumerable().Where(r => !r.Deleted && r.Valid);
            if (m.PurchaseUnitId != null)
            {
                //待处理
            }
            if (m.SupplyUnitId != null)
            {
                //待处理
            }

            if (!string.IsNullOrEmpty(m.Keyword))
            {
                d = d.Where(r => r.Pinyin != null).Where(r => r.ProductGeneralName.Contains(m.Keyword) || r.Pinyin.ToUpper().Contains(m.Keyword.ToUpper()));
            }

            return d.OrderBy(r => r.ProductGeneralName).ToArray();
        }
    }
}
