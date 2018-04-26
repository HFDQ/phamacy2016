using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using System.Data.Entity;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class SalesOrderReturnBusinessHandler
    {

        protected override IQueryable<SalesOrderReturn> IncludeNavigationProperties(IQueryable<SalesOrderReturn> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable.Include(u => u.SalesOrderReturnDetails));
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<SalesOrderReturn>>(ex.Message, ex);
            }

        }

        #region 根据状态获取销退单list
        /// <summary>
        /// 获取所有未结束的销退信息
        /// </summary>
        /// <returns></returns>
        public List<SalesOrderReturn> GetAllNoOverOrderReturn()
        {
            int status = (int)OrderReturnStatus.Over;
            return this.Fetch(p => p.OrderReturnStatusValue == status).ToList();

        }
        #endregion

        #region 根据状态获取销退单list
        /// <summary>
        /// 根据状态获取销退单list
        /// </summary>
        /// <param name="queryable"></param>
        /// <returns></returns>
        public List<SalesOrderReturn> GetSalesOrderReturnByStatus(List<int> listOrderReturnStatus)
        {
            try
            {
                return this.Fetch(p => listOrderReturnStatus.Contains(p.OrderReturnStatusValue)).OrderByDescending(p=>p.UpdateTime).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<SalesOrderReturn>>("根据状态获取销退单失败", ex);
            }
        }
        #endregion

        #region 根据订单获取当前销退明实体
        /// <summary>
        /// 根据订单获取当前销退明实体
        /// </summary>
        /// <param name="outInventoryID"></param>
        /// <returns></returns>
        public SalesOrderReturn GetLastOrderReturnByReturnOrder(Guid outInventoryID)
        {
            try
            {
                return BusinessHandlerFactory.SalesOrderReturnBusinessHandler.Fetch(p => p.OutInventoryID == outInventoryID).OrderByDescending(o => o.CreateTime).FirstOrDefault();

            }
            catch (Exception ex)
            {
                return this.HandleException<SalesOrderReturn>("根据订单获取当前销退明实体失败", ex);
            }
        }
        #endregion

        #region 保存销退明细列表
        /// <summary>
        ///  销退申请单申请保存
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="detailList"></param>
        public void AddSalesOrderReturnAndDetail(SalesOrderReturn sor)
        {
            try
            {
                #region SalesOrer Save
                sor.OrderReturnCode = BusinessHandlerFactory.BillDocumentCodeBusinessHandler.GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.SalesOrderReturn).Code;
                sor.CreateTime = DateTime.Now;
                sor.UpdateTime = DateTime.Now;
                #endregion

                this.Add(sor);
                foreach (SalesOrderReturnDetail sord in sor.SalesOrderReturnDetails)
                {
                    if (sord.ReturnAmount > 0)
                    {
                        OutInventoryDetail oid = new OutInventoryDetail();
                        oid = BusinessHandlerFactory.OutInventoryDetailBusinessHandler.Get(sord.OutInventoryDetailID);
                        oid.OutAmount -= sord.ReturnAmount;
                        BusinessHandlerFactory.OutInventoryDetailBusinessHandler.Save(oid);

                        BusinessHandlerFactory.SalesOrderReturnDetailBusinessHandler.Add(sord);
                        sord.OrderReturnID = sor.Id;
                    }
                }
                
                this.Save();

            }
            catch (Exception ex)
            {
                this.HandleException("保存销退明细列表失败", ex);
            }

        }
        #endregion

        #region 销退申请单取消
        /// <summary>
        ///  销退申请单取消
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="detailList"></param>
        public void CancelSalesOrderReturn(SalesOrderReturn sor)
        {
            try
            {
                sor.OrderReturnCancelCode = BusinessHandlerFactory.BillDocumentCodeBusinessHandler.GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.OrderReturnCancel).Code;
                foreach (SalesOrderReturnDetail sord in sor.SalesOrderReturnDetails)
                {
                    OutInventoryDetail oid = new OutInventoryDetail();
                    oid = BusinessHandlerFactory.OutInventoryDetailBusinessHandler.Get(sord.OutInventoryDetailID);
                    oid.OutAmount += sord.ReturnAmount;
                    BusinessHandlerFactory.OutInventoryDetailBusinessHandler.Save(oid);
                    BusinessHandlerFactory.SalesOrderReturnDetailBusinessHandler.Delete(sord.Id);
                }
                sor.OrderReturnCancelTime = DateTime.Now;
                this.Save(sor);
                this.Save();
            }
            catch (Exception ex)
            {
                this.HandleException("保存销退明细列表失败", ex);
            }
        }
        #endregion

        /// <summary>
        /// 销退审核后处理
        /// 更新订单表
        /// 更新订单详细表
        /// </summary>
        /// <param name="so"></param>
        public void AcceptSalesOrderReturn(SalesOrderReturn sor)
        {
            SalesOrder so = BusinessHandlerFactory.SalesOrderBusinessHandler.Get(sor.SalesOrderID);
            //销退后状态为结算
            so.OrderStatus = OrderStatus.Banlaced;
            BusinessHandlerFactory.SalesOrderBusinessHandler.Save(so);
            try
            {
                var db = BusinessHandlerFactory.RepositoryProvider.Db;
                //订单信息更新
                var order = db.SalesOrders.First(p => p.Id == so.Id);
                order.OrderStatus = OrderStatus.Banlaced;//结算
                order.OrderReturnCheckCode = order.OrderReturnCheckCode;
                order.OrderReturnCheckTime = order.UpdateTime = DateTime.Now;
                order.UpdateUserId = order.OrderReturnCheckUserID;
                order.OrderReturnCheckUserID = order.OrderReturnCheckUserID;

                //获取订单信息和库存信息的集合
                var list = db.SalesOrderReturnDetails.Where(p => p.Id == order.Id)
                              .Join(db.SalesOrderDetails.Where(p => p.Id == order.Id),
                                    l => l.DrugInventoryRecordID, r => r.DrugInventoryRecordID,
                                    (l, r) => new { ReturnAmount = l.ReturnAmount, OrderDetail = r })
                              .Join(db.InventoryRecords,
                                    l => l.OrderDetail.DrugInventoryRecordID, r => r.Id,
                                    (l, r) => new { ReturnAmount = l.ReturnAmount, OrderDetail = l.OrderDetail, InvertoryInfo = r });

                foreach (var item in list)
                {
                    item.OrderDetail.Amount -= item.ReturnAmount;
                    item.OrderDetail.UpdateTime = DateTime.Now;
                    item.OrderDetail.UpdateUserId = order.UpdateUserId;

                    item.InvertoryInfo.CurrentInventoryCount += item.ReturnAmount;
                    item.InvertoryInfo.OnSalesOrderCount += item.ReturnAmount;


                    var drugIn = db.DrugInventoryRecords.First(p => p.DrugInfoId == item.InvertoryInfo.DrugInfoId);
                    drugIn.CurrentInventoryCount += item.ReturnAmount;
                    drugIn.OnSalesOrderCount += item.ReturnAmount;
                }
                BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "成功审核销退单：" + sor.OrderReturnCode });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 销退单入库保存
        /// <summary>
        ///销退单入库保存
        /// </summary>
        /// <param name="so"></param>
        public void SaveReturnOrderInventory(SalesOrderReturn sor)
        {
            try
            {
                //处理库存的退库信息
                List<SalesOrderReturnDetail> salesOrderReturnDetailList = sor.SalesOrderReturnDetails.ToList();
                OutInventory oi = null;
                int index=0;
                foreach (SalesOrderReturnDetail item in salesOrderReturnDetailList)
                {             
                    index++;
                    Guid drugInventoryID = item.DrugInventoryRecordID;
                    decimal returnQtyIn = item.CanInAmount;

                    //获取药物库存实体                    
                    DrugInventoryRecord drugInventory = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(drugInventoryID);
                    //在销售单但未出库数量 累计当前订单明细数量
                    drugInventory.SalesCount -= returnQtyIn;
                    drugInventory.CurrentInventoryCount += returnQtyIn;
                        
                    if (item.IsReissue)
                    {
                        drugInventory.OnSalesOrderCount += returnQtyIn;
                        if (oi == null)
                        {          
                            OutInventory oib=BusinessHandlerFactory.OutInventoryBusinessHandler.GetOutInventoryByOrderID(sor.SalesOrderID).ToList().First();
                            oi = new OutInventory();
                            oi.CreateUserId = oib.CreateUserId;
                            oi.OrderCode = oib.OrderCode;
                            oi.OrderOutInventoryCheckNumber = oib.OrderOutInventoryCheckNumber;
                            oi.OrderOutInventoryCheckTime = oib.OrderOutInventoryCheckTime;
                            oi.OrderOutInventoryCheckUserID = oib.OrderOutInventoryCheckUserID;
                            oi.OrderOutInventoryTime = oib.OrderOutInventoryTime;
                            oi.OrderOutInventoryUserID = oib.OrderOutInventoryUserID;
                            oi.OutInventoryDate = DateTime.Now;
                            oi.OutInventoryNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.SalesOrderOutInventory).Code;
                            oi.ReviewerId = new Guid();
                            oi.SalesOrderID = oib.SalesOrderID;
                            oi.storekeeperId = oib.storekeeperId;
                            
                            oi.Id = Guid.NewGuid();
                            oi.CreateTime = DateTime.Now;
                            oi.Deleted = false;
                            oi.Description = "销退补货出库单";
                            oi.OutInventoryStatus = OutInventoryStatus.Outing;
                            oi.OutInventoryStatusValue = (int)OutInventoryStatus.Outing;
                            oi.OutInventoryType = OutInventoryType.SalesReissue;
                            oi.OutInventoryTypeValue = (int)OutInventoryType.SalesReissue;
                            oi.SalesOrderReturnID = sor.Id;
                            oi.TotalMoney = item.ActualUnitPrice * item.ReturnAmount;
                            BusinessHandlerFactory.OutInventoryBusinessHandler.Add(oi);
                        }
                        OutInventoryDetail oid = new OutInventoryDetail();
                        oid.ActualUnitPrice = item.ActualUnitPrice;
                        oid.Amount = item.ReturnAmount;
                        oid.BatchNumber = item.BatchNumber;
                        oid.CanSaleNum = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(item.DrugInventoryRecordID).CanSaleNum+item.CanInAmount;
                        oid.CreateTime = DateTime.Now;
                        oid.CreateUserId = item.CreateUserId;
                        oid.Deleted = false;
                        oid.Description = "销退补货出库细节";
                        oid.DictionaryDosageCode = item.DictionaryDosageCode;
                        oid.DrugInventoryRecordID = item.DrugInventoryRecordID;
                        oid.FactoryName = item.FactoryName;
                        oid.Id = Guid.NewGuid();
                        oid.Index = index;
                        oid.MeasurementUnit = item.MeasurementUnit;
                        oid.Origin = item.Origin;
                        oid.OutAmount = item.ReturnAmount;
                        oid.OutValidDate = item.OutValidDate;
                        oid.Price = item.Price;
                        oid.productCode = item.productCode;
                        oid.productName = item.productName;
                        oid.PruductDate = item.PruductDate;
                        oid.SalesOrderDetailId = item.SalesOrderDetailID;
                        oid.SalesOrderDetailReturnId = item.Id;
                        oid.SalesOrderId = sor.SalesOrderID;
                        oid.SalesOrderReturnId = sor.Id;
                        oid.SalesOutInventoryID = oi.Id;
                        oid.SpecificationCode = item.SpecificationCode;
                        oid.StoreId = item.StoreId;
                        oid.UnitPrice = item.UnitPrice;
                        oid.UpdateTime = DateTime.Now;
                        oid.UpdateUserId = item.UpdateUserId;
                        OutInventoryDetail outinv=BusinessHandlerFactory.OutInventoryDetailBusinessHandler.Get(item.OutInventoryDetailID);
                        oid.WarehouseCode = outinv.WarehouseCode;
                        oid.WarehouseName = outinv.WarehouseName;
                        oid.WarehouseZoneCode = outinv.WarehouseZoneCode;
                        oid.WarehouseZoneName = outinv.WarehouseZoneName;

                        BusinessHandlerFactory.OutInventoryDetailBusinessHandler.Add(oid);
                    }
                    //drugInventory.PurchaseReturnNumber = item.ReturnAmount;
                    drugInventory.Valid = true;
                    BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(drugInventory);

                    
                    //在销售单但未出库数量 累计当前订单明细数量
                    
                    if(item.IsReissue)
                        drugInventory.OnSalesOrderCount += returnQtyIn;
                    
                    
                }
                this.Save(sor);
                this.Save();
            }
            catch (Exception ex)
            {
                this.HandleException("销退单入库保存失败", ex);
            }
        }
        #endregion

        #region 根据销退单分页检索
        /// <summary>
        ///  根据销退单分页检索
        /// </summary>
        /// <param name="totalpage"></param>
        /// <param name="searchInput"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public IEnumerable<SalesOrderReturn> GetReturnOrderCodePaged(SalesCodeSearchInput searchInput, out PagerInfo pager, int pageindex, int pageSize)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var varOrderReturn = base.Queryable;

                if (!string.IsNullOrWhiteSpace(searchInput.Code))
                    varOrderReturn = varOrderReturn.Where(p => p.OrderReturnCode.IndexOf(searchInput.Code) >= 0);
                else
                    varOrderReturn = varOrderReturn.Where(p => p.OrderReturnCode.Length>0);
                if (searchInput.FromDate != null)
                    varOrderReturn = varOrderReturn.Where(p => p.OrderReturnTime >= searchInput.FromDate);
                if (searchInput.ToDate != null)
                    varOrderReturn = varOrderReturn.Where(p => p.OrderReturnTime <= searchInput.ToDate);
                if (searchInput.OperatorID != Guid.Empty)
                    varOrderReturn = varOrderReturn.Where(p => p.CreateUserId == searchInput.OperatorID);


                pageInfo.RecordCount = varOrderReturn.Count();
                pager = pageInfo;
                varOrderReturn = varOrderReturn.OrderBy(o => o.CreateTime);
                varOrderReturn = (skipCount == 0 ? varOrderReturn.Take(pageSize) : varOrderReturn.Skip(skipCount).Take(pageSize));

                BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "成功读取销退单：" });

                return varOrderReturn.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                pager = null;
                return this.HandleException<IEnumerable<SalesOrderReturn>>("根据销退单分页检索失败", ex);
            }
        }

        #endregion

        #region 根据销退验收单单分页检索
        /// <summary>
        ///  根据销退验收单单分页检索
        /// </summary>
        /// <param name="totalpage"></param>
        /// <param name="searchInput"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public IEnumerable<Business.Models.SalesOrderReturnModel> GetReturnOrderCheckCodePaged(SalesCodeSearchInput searchInput)
        {
            try
            {                
                var varOrderReturnCheck = this.Queryable;                
                if (searchInput.FromDate != null)
                    varOrderReturnCheck = varOrderReturnCheck.Where(p => p.OrderReturnCheckTime >= searchInput.FromDate);
                if (searchInput.ToDate != null)
                    varOrderReturnCheck = varOrderReturnCheck.Where(p => p.OrderReturnCheckTime <= searchInput.ToDate);
                if (searchInput.OperatorID != Guid.Empty)
                    varOrderReturnCheck = varOrderReturnCheck.Where(p => p.OrderReturnCheckUserID == searchInput.OperatorID);

                var u= from i in RepositoryProvider.Db.Users join j in RepositoryProvider.Db.Employees on i.EmployeeId equals j.Id
                       select i;
                
                var c = from i in varOrderReturnCheck
                        join j in RepositoryProvider.Db.SalesOrders on i.SalesOrderID equals j.Id
                        join p in RepositoryProvider.Db.PurchaseUnits on j.PurchaseUnitId equals p.Id
                        join k in u on i.SellerID equals k.Id
                        join l in u on i.CreateUserId equals l.Id
                        join n in u on i.OrderReturnCheckUserID equals n.Id
                        join o in u on i.OrderReturnInInventoryUserID equals o.Id
                        join m in RepositoryProvider.Db.SalesOrderReturnDetails on i.Id equals m.OrderReturnID
                        where m.ReturnAmount>0
                        select new Business.Models.SalesOrderReturnModel
                        {
                            Creater=l.Employee.Name,
                            CreateTime=i.CreateTime,
                            DrugNum=m.ReturnAmount,
                            Id=i.Id,
                            PurchaseUnitName=p.Name,
                            PurchaseUnitPinYin=p.PinyinCode,
                            SaleOrderDocumentNumber=j.OrderCode,
                            SaleOrderReturnDocumentNumber=i.OrderReturnCode,
                            Saler=k.Employee.Name,
                            TotalPrice=m.ReturnAmount*m.ActualUnitPrice,
                            SaleOrderReturnCheckDocumentNumber=i.OrderReturnCheckCode,
                            SaleOrderReturnCheckTime=i.OrderReturnCheckTime,
                            SaleOrderReturnChecker=n.Employee.Name,
                            SaleOrderReturnINvDocumentNumber=i.OrderReturnInInventoryCode,
                            SaleOrderReturnInver=o.Employee.Name,
                            SaleOrderReturnInvTime=i.OrderReturnInInventoryTime,
                             SalesOrderId=i.SalesOrderID,
                        };
                c = c.Where(r=>r.PurchaseUnitPinYin.ToUpper().Contains(searchInput.Code.ToUpper())||r.PurchaseUnitName.Contains(searchInput.Code)||r.SaleOrderDocumentNumber.Contains(searchInput.Code)).OrderBy(o => o.CreateTime);
                
                return c;
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<Business.Models.SalesOrderReturnModel>>("根据销退验收单单分页检索失败", ex);
            }
        }
        #endregion

        #region 根据销入库单单分页检索
        /// <summary>
        ///  根据销入库单单分页检索
        /// </summary>
        /// <param name="totalpage"></param>
        /// <param name="searchInput"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public IEnumerable<SalesOrderReturn> GetReturnOrderInventoryCodePaged(SalesCodeSearchInput searchInput, out PagerInfo pager, int pageindex, int pageSize)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var varOrderReturnCheck = base.Queryable;

                if (!string.IsNullOrWhiteSpace(searchInput.Code))
                    varOrderReturnCheck = varOrderReturnCheck.Where(p => p.OrderReturnInInventoryCode.IndexOf(searchInput.Code) >= 0);
                else
                    varOrderReturnCheck = varOrderReturnCheck.Where(p => p.OrderReturnInInventoryCode.Length>0);
                if (searchInput.FromDate != null)
                    varOrderReturnCheck = varOrderReturnCheck.Where(p => p.OrderReturnInInventoryTime >= searchInput.FromDate);
                if (searchInput.ToDate != null)
                    varOrderReturnCheck = varOrderReturnCheck.Where(p => p.OrderReturnInInventoryTime <= searchInput.ToDate);
                if (searchInput.OperatorID != Guid.Empty)
                    varOrderReturnCheck = varOrderReturnCheck.Where(p => p.OrderReturnInInventoryUserID == searchInput.OperatorID);



                pageInfo.RecordCount = varOrderReturnCheck.Count();
                pager = pageInfo;
                varOrderReturnCheck = varOrderReturnCheck.OrderBy(o => o.CreateTime);
                varOrderReturnCheck = (skipCount == 0 ? varOrderReturnCheck.Take(pageSize) : varOrderReturnCheck.Skip(skipCount).Take(pageSize));
                return varOrderReturnCheck.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                pager = null;
                return this.HandleException<IEnumerable<SalesOrderReturn>>("根据销入库单单分页检索失败", ex);
            }
        }

        #endregion

        #region 根据销退取消单分页检索
        /// <summary>
        ///  根据销退取消单分页检索
        /// </summary>
        /// <param name="totalpage"></param>
        /// <param name="searchInput"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public IEnumerable<Business.Models.SalesOrderReturnModel> GetReturnOrderCancelCodePaged(SalesCodeSearchInput searchInput)
        {
            try
            {
                var varOrderReturnCheck = this.Queryable.Where(r=>r.OrderReturnStatusValue== (int)OrderReturnStatus.Canceled);
                if (searchInput.FromDate != null)
                    varOrderReturnCheck = varOrderReturnCheck.Where(p => p.OrderReturnCancelTime >= searchInput.FromDate);
                if (searchInput.ToDate != null)
                    varOrderReturnCheck = varOrderReturnCheck.Where(p => p.OrderReturnCancelTime <= searchInput.ToDate);
                if (searchInput.OperatorID != Guid.Empty)
                    varOrderReturnCheck = varOrderReturnCheck.Where(p => p.OrderReturnCancelUserID == searchInput.OperatorID);

                var u = from i in RepositoryProvider.Db.Users
                        join j in RepositoryProvider.Db.Employees on i.EmployeeId equals j.Id
                        select i;

                var c = from i in varOrderReturnCheck
                        join j in RepositoryProvider.Db.SalesOrders on i.SalesOrderID equals j.Id
                        join p in RepositoryProvider.Db.PurchaseUnits on j.PurchaseUnitId equals p.Id
                        join k in u on i.SellerID equals k.Id
                        join l in u on i.CreateUserId equals l.Id
                        join n in u on i.OrderReturnCancelUserID equals n.Id
                        join m in RepositoryProvider.Db.SalesOrderReturnDetails on i.Id equals m.OrderReturnID
                        where m.ReturnAmount > 0
                        select new Business.Models.SalesOrderReturnModel
                        {
                            Creater = l.Employee.Name,
                            CreateTime = i.CreateTime,
                            DrugNum = m.ReturnAmount,
                            Id = i.Id,
                            PurchaseUnitName = p.Name,
                            PurchaseUnitPinYin = p.PinyinCode,
                            SaleOrderDocumentNumber = j.OrderCode,
                            SaleOrderReturnDocumentNumber = i.OrderReturnCode,
                            Saler = k.Employee.Name,
                            TotalPrice = m.ReturnAmount * m.ActualUnitPrice,
                            SaleOrderReturnCancelDocumentNumber=i.OrderReturnCancelCode,
                            SaleOrderReturnCanceler=n.Employee.Name,
                            SaleOrderReturnCancelTime=i.OrderReturnCancelTime,
                            SaleOrderReturnCancelReason=i.OrderReturnCancelReason
                        };
                

                var result = c.Where(r => r.PurchaseUnitPinYin.ToUpper().Contains(searchInput.Code.ToUpper()) || r.PurchaseUnitName.Contains(searchInput.Code) || r.SaleOrderDocumentNumber.Contains(searchInput.Code)).OrderBy(o => o.CreateTime);

                return result;
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<Business.Models.SalesOrderReturnModel>>("根据销退验收单单分页检索失败", ex);
            }
        }

        #endregion

        #region 销退单出库保存
        /// <summary>
        ///销退单出库保存
        /// </summary>
        /// <param name="so"></param>
        public void SaveReturnOrderOutventory(SalesOrderReturn sor)
        {
            try
            {
                #region SalesOrer Save
                SalesOrder so = BusinessHandlerFactory.SalesOrderBusinessHandler.Get(sor.SalesOrderID);
                List<SalesOrderReturnDetail> sordList = sor.SalesOrderReturnDetails.ToList();

                foreach (SalesOrderReturnDetail sord in sordList)
                {
                    //补发的需要更新订单信息，重新出库发货
                    if (sord.IsReissue)
                    {
                        SalesOrderDetail sod = BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Get(sord.SalesOrderDetailID);
                        if (sord.IsReissue)
                            sod.ChangeAmount += sord.ReturnAmount;
                        else
                            sod.ReturnAmount += sord.ReturnAmount;

                        sod.OutAmount = sod.Amount - sod.ChangeAmount;

                        BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Save(sod);
                    }

                }

                BusinessHandlerFactory.SalesOrderBusinessHandler.Save(so);
                #endregion

                this.Save(sor);

                this.Save();
            }
            catch (Exception ex)
            {
                this.HandleException("销退单出库保存失败", ex);
            }
        }
        #endregion

        #region 销退单创建的用户
        /// <summary>
        /// 销退单创建的用户
        /// </summary>
        /// <returns></returns>
        public List<User> GetSalesReturnOperatorUser()
        {
            try
            {
                var query = from o in BusinessHandlerFactory.RepositoryProvider.Db.SalesOrderReturns
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.CreateUserId equals u.Id
                            select new
                            {
                                Id = u.Id,
                                Account = u.Account
                            };
                List<User> listUser = new List<User>();
                query = query.OrderBy(p => p.Account);
                foreach (var item in query)
                {
                    User user = new User();
                    user.Id = item.Id;
                    user.Account = item.Account;
                    listUser.Add(user);
                }
                return listUser;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<User>>(" 销退单创建的用户", ex);
            }
        }
        #endregion

        #region 销退单验收的用户列表
        /// <summary>
        /// 销退单验收的用户列表
        /// </summary>
        /// <returns></returns>
        public List<User> GetSalesReturnCheckUser()
        {
            try
            {
                var query = from o in BusinessHandlerFactory.RepositoryProvider.Db.SalesOrderReturns
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.OrderReturnCheckUserID equals u.Id

                            select new
                            {
                                Id = u.Id,
                                Account = u.Account
                            };
                List<User> listUser = new List<User>();
                query = query.OrderBy(p => p.Account);
                foreach (var item in query)
                {
                    User user = new User();
                    user.Id = item.Id;
                    user.Account = item.Account;
                    listUser.Add(user);
                }
                return listUser;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<User>>(" 销退单验收的用户列表失败", ex);
            }
        }
        #endregion

        #region 销退单入库的用户列表
        /// <summary>
        /// 销退单入库的用户列表
        /// </summary>
        /// <returns></returns>
        public List<User> GetSalesReturnInventoryUser()
        {
            try
            {
                var query = from o in BusinessHandlerFactory.RepositoryProvider.Db.SalesOrderReturns
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.OrderReturnInInventoryUserID equals u.Id

                            select new
                            {
                                Id = u.Id,
                                Account = u.Account
                            };
                List<User> listUser = new List<User>();
                query = query.OrderBy(p => p.Account);
                foreach (var item in query)
                {
                    User user = new User();
                    user.Id = item.Id;
                    user.Account = item.Account;
                    listUser.Add(user);
                }
                return listUser;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<User>>(" 销退单入库的用户列表失败", ex);
            }
        }

        #endregion

        #region 销退单取消的用户列表
        /// <summary>
        /// 销退单取消的用户列表
        /// </summary>
        /// <returns></returns>
        public List<User> GetSalesReturnCancelUser()
        {
            try
            {
                var query = from o in BusinessHandlerFactory.RepositoryProvider.Db.SalesOrderReturns
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.OrderReturnCancelUserID equals u.Id

                            select new
                            {
                                Id = u.Id,
                                Account = u.Account
                            };
                List<User> listUser = new List<User>();
                query = query.OrderBy(p => p.Account);
                foreach (var item in query)
                {
                    User user = new User();
                    user.Id = item.Id;
                    user.Account = item.Account;
                    listUser.Add(user);
                }
                return listUser;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<User>>(" 销退单取消的用户列表失败", ex);
            }
        }
        #endregion

        #region 统计销退数量和金额
        public Dictionary<int, decimal> GetSalesReturnSummary(SalesOrder[] so)
        {

            Dictionary<int, decimal> dic = new Dictionary<int, decimal>();
            var all = from i in this.Queryable.ToArray()
                      from w in so where i.SalesOrderID == w.Id
                      select new
                      {
                          count=i.SalesOrderID,
                          sum=i.SalesOrderReturnDetails.Sum(r=>r.ReturnAmount*r.ActualUnitPrice)
                      };
            var f = all.ToList();
            if (f != null)
            {
                dic.Add(f.Count,f.Sum(r=>r.sum));
                return dic;
            }
            else
            {
                return null;
            }
        }
        public SalesOrderReturn[] GetSalesOrderReturnByCreateTime(DateTime dtFrom,DateTime dtTo)
        {
            var all = this.Queryable;
            all = all.Where(r => r.OrderReturnCheckTime >= dtFrom && r.OrderReturnCheckTime <= dtTo);
            all = all.Where(r => r.Deleted == false);
            return all.ToArray();
        }


        #endregion
    }
}
