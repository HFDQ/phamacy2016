
 
  
  
 
 
 
 
  
 
 
using System.Net;
using System.ServiceModel;
using System.Xml;
using BugsBox.Common;
using BugsBox.Pharmacy.AppClient.PS;
using System;  
using System.Net.Sockets;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Service.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models; 
using BugsBox.Pharmacy.Business.Models.QueryModelExtesion; 
namespace BugsBox.Pharmacy.AppClient.PS
{
	//此代码由PharmacyService.tt自动生成 
    partial class PharmacyDatabaseService:IPharmacyDatabaseService
    {
		private PharmacyDatabaseServiceClient pharmacyServcie
        {
            get
            {
                return new PharmacyDatabaseServiceClient("NetTcpBinding_IPharmacyDatabaseService");
            }
        }
         private ILogger Log = LoggerHelper.Instance; 

 


        //public PharmacyDatabaseService()
        //{
        //    try
        //    {
        //         //var factory = new ChannelFactory<IPharmacyDatabaseServiceChannel>("NetTcpBinding_IPharmacyDatabaseService");
        //        //pharmacyServcie = new PharmacyDatabaseServiceClient("NetTcpBinding_IPharmacyDatabaseService");
               

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message);
        //    }
          
        //}

				#region 错误处理

        public TReturn HandleException<TReturn>(Exception ex = null)
        {
            HandleException(ex);
            return default(TReturn);
        }

        public void HandleException(Exception ex = null)
        {          
            if (ex is TimeoutException)
            {
                //服务超时
                ex = new Exception("服务超时", ex);
                Log.Error(ex);
                throw ex;
            }
            else if (ex is FaultException<ServiceExceptionDetail>)
            {
                //自定义Fault
                FaultException<ServiceExceptionDetail> exDetail = ex as FaultException<ServiceExceptionDetail>;
                if (exDetail != null)
                {
                    ServiceExceptionDetail detail = exDetail.Detail;
                    if (detail != null)
                    {
                        ex = new Exception(detail.Message, ex);
                    }
                    else
                    {
                        ex = new Exception("未知自定义Fault", ex);
                    }
                }
                else
                {
                    ex = new Exception( "未知自定义Fault", ex);
                }
                Log.Error(ex);
                throw ex;
            }
            else if (ex is FaultException)
            {
                //Fault
                ex = new Exception( "自定义Fault", ex);
                Log.Error(ex);
                throw ex;
            }
            else if (ex is EndpointNotFoundException || ex is CommunicationException)
            {
                //服务连接错误 
                ex = new Exception( "服务连接错误", ex);
                Log.Error(ex);
                throw ex;
            } 
            else if (ex is ObjectDisposedException)
            {
                //服务已经释放 
                ex = new Exception( "服务通道出错", ex);
                Log.Error(ex);
                throw ex;
            }
            ex = new Exception("未知错误", ex);
            Log.Error(ex);
            throw ex;
               
        }

        #endregion 错误处理
		      
		 
		      
			public BusinessPersonModel[] QueryBusinessPerson(out String message,QueryBusinessPersonModel queryBusinessPersonModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryBusinessPerson....."));
				try
				{ 
					return pharmacyServcie.QueryBusinessPerson(out message,queryBusinessPersonModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryBusinessPerson."));
				}
			}
		 
		      
			public InventoryRecord GetInventoryRecordByDrugInfoID(out String message,Guid drugInfoID)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetInventoryRecordByDrugInfoID....."));
				try
				{ 
					return pharmacyServcie.GetInventoryRecordByDrugInfoID(out message,drugInfoID);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetInventoryRecordByDrugInfoID."));
				}
			}
		 
		      
			public PharmacyLicense[] QueryPharmacyLicenseForOutdate(out String message,QueryPharmacyLicenseModel queryModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPharmacyLicenseForOutdate....."));
				try
				{ 
					return pharmacyServcie.QueryPharmacyLicenseForOutdate(out message,queryModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPharmacyLicenseForOutdate."));
				}
			}
		 
		      
			public String[] GetAuthorityKeys(out String message,Guid userId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetAuthorityKeys....."));
				try
				{ 
					return pharmacyServcie.GetAuthorityKeys(out message,userId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetAuthorityKeys."));
				}
			}
		 
		      
			public ModuleWithRole[] GetModuleWithRolesByRoleId(out String message,Guid roleId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetModuleWithRolesByRoleId....."));
				try
				{ 
					return pharmacyServcie.GetModuleWithRolesByRoleId(out message,roleId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetModuleWithRolesByRoleId."));
				}
			}
		 
		      
			public ModuleWithRole[] GetModuleWithRolesByModuleId(out String message,Guid moduleId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetModuleWithRolesByModuleId....."));
				try
				{ 
					return pharmacyServcie.GetModuleWithRolesByModuleId(out message,moduleId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetModuleWithRolesByModuleId."));
				}
			}
		 
		      
			public bool AuthModuleWithRoleCatetoryAuthModuleIds(out String message,Role role,ModuleCatetory catetory,Guid[] authModuleIds)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AuthModuleWithRoleCatetoryAuthModuleIds....."));
				try
				{ 
					return pharmacyServcie.AuthModuleWithRoleCatetoryAuthModuleIds(out message,role,catetory,authModuleIds);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AuthModuleWithRoleCatetoryAuthModuleIds."));
				}
			}
		 
		      
			public PurchaseRecord[] GetPurchaseRecords(out String message,int type,String productGeneralName,DateTime startTime,DateTime endTime,Guid[] purchaseUnits,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseRecords....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseRecords(out message,type,productGeneralName,startTime,endTime,purchaseUnits,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseRecords."));
				}
			}
		 
		      
			public PurchaseRCRecord[] GetPurchaseRCRecords(out String message,int type,String productGeneralName,DateTime startTime,DateTime endTime,Guid[] purchaseUnits,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseRCRecords....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseRCRecords(out message,type,productGeneralName,startTime,endTime,purchaseUnits,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseRCRecords."));
				}
			}
		 
		      
			public PurchaseOrderDetailEntity[] GetPurchaseHistoryForDrugInfo(out String message,Guid drupInfoId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseHistoryForDrugInfo....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseHistoryForDrugInfo(out message,drupInfoId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseHistoryForDrugInfo."));
				}
			}
		 
		      
			public PurchaseOrdeEntity GetPurchaseOrderEntity(out String message,Guid purchaseOrderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseOrderEntity....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseOrderEntity(out message,purchaseOrderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseOrderEntity."));
				}
			}
		 
		      
			public PurchaseOrdeEntity[] GetPurchaseOrders(out String message,String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseOrders....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseOrders(out message,documentNumber,startTime,endTime,orderStatusValue,purchaseUnits,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseOrders."));
				}
			}
		 
		      
			public PurchaseOrderDetailEntity[] GetPurchaseOrderDetails(out String message,Guid purchaseOrderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseOrderDetails....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseOrderDetails(out message,purchaseOrderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseOrderDetails."));
				}
			}
		 
		      
			public String CreatePurchaseOrder(out String message,PurchaseOrder order,PurchaseOrderDetail[] orderDetails)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreatePurchaseOrder....."));
				try
				{ 
					return pharmacyServcie.CreatePurchaseOrder(out message,order,orderDetails);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreatePurchaseOrder."));
				}
			}
		 
		      
			public String HandlePurchaseReceinvingAmountDiff(PurchaseOrder purchaseOrder)
			{
			    //Log.Warning(string.Format("开始调用服务方法:HandlePurchaseReceinvingAmountDiff....."));
				try
				{ 
					return pharmacyServcie.HandlePurchaseReceinvingAmountDiff(purchaseOrder);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:HandlePurchaseReceinvingAmountDiff."));
				}
			}
		 
		      
			public PurchaseCommonEntity[] GetPurchaseReceivingOrdersByPurchaseOrderId(out String message,Guid purchaseOrderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseReceivingOrdersByPurchaseOrderId....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseReceivingOrdersByPurchaseOrderId(out message,purchaseOrderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseReceivingOrdersByPurchaseOrderId."));
				}
			}
		 
		      
			public String CreatePurchaseReceivingOrderByEnity(out String message,PurchaseCommonEntity order,PurchaseReceivingOrderDetailEntity[] orderDetails)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreatePurchaseReceivingOrderByEnity....."));
				try
				{ 
					return pharmacyServcie.CreatePurchaseReceivingOrderByEnity(out message,order,orderDetails);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreatePurchaseReceivingOrderByEnity."));
				}
			}
		 
		      
			public String CreatePurchaseReceivingOrder(out String message,PurchaseReceivingOrder order,PurchaseReceivingOrderDetail[] orderDetails)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreatePurchaseReceivingOrder....."));
				try
				{ 
					return pharmacyServcie.CreatePurchaseReceivingOrder(out message,order,orderDetails);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreatePurchaseReceivingOrder."));
				}
			}
		 
		      
			public PurchaseCommonEntity[] GetPurchaseReceivingOrders(out String message,String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseReceivingOrders....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseReceivingOrders(out message,documentNumber,startTime,endTime,orderStatusValue,purchaseUnits,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseReceivingOrders."));
				}
			}
		 
		      
			public PurchaseReceivingOrderDetailEntity[] GetPurchaseReceivingOrderDetails(out String message,Guid orderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseReceivingOrderDetails....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseReceivingOrderDetails(out message,orderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseReceivingOrderDetails."));
				}
			}
		 
		      
			public PurchaseCommonEntity[] GetPurchaseCheckingOrdersByPurchaseOrderId(out String message,Guid purchaseOrderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseCheckingOrdersByPurchaseOrderId....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseCheckingOrdersByPurchaseOrderId(out message,purchaseOrderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseCheckingOrdersByPurchaseOrderId."));
				}
			}


            public String CreatePurchaseCheckingOrderByEnity(out String message, PurchaseCommonEntity order, PurchaseCheckingOrderDetailEntity[] orderDetails, System.Collections.Generic.List<DrugsUndeterminate> ListUndeterminate)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreatePurchaseCheckingOrderByEnity....."));
				try
				{ 
					return pharmacyServcie.CreatePurchaseCheckingOrderByEnity(out message,order,orderDetails,ListUndeterminate);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreatePurchaseCheckingOrderByEnity."));
				}
			}


            public String CreatePurchaseCheckingOrder(out String message, PurchaseCheckingOrder order, PurchaseCheckingOrderDetail[] orderDetails, System.Collections.Generic.List<DrugsUndeterminate> ListUndeterminate)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreatePurchaseCheckingOrder....."));
				try
				{ 
					return pharmacyServcie.CreatePurchaseCheckingOrder(out message,order,orderDetails,ListUndeterminate);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreatePurchaseCheckingOrder."));
				}
			}
		 
		      
			public PurchaseCommonEntity[] GetPurchaseCheckingOrders(out String message,String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseCheckingOrders....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseCheckingOrders(out message,documentNumber,startTime,endTime,orderStatusValue,purchaseUnits,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseCheckingOrders."));
				}
			}
		 
		      
			public PurchaseCheckingOrderDetailEntity[] GetPurchaseCheckingOrderDetails(out String message,Guid orderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseCheckingOrderDetails....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseCheckingOrderDetails(out message,orderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseCheckingOrderDetails."));
				}
			}
		 
		      
			public PurchaseCommonEntity[] GetPurchaseInInventeryOrdersByPurchaseOrderId(out String message,Guid purchaseOrderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseInInventeryOrdersByPurchaseOrderId....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseInInventeryOrdersByPurchaseOrderId(out message,purchaseOrderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseInInventeryOrdersByPurchaseOrderId."));
				}
			}
		 
		      
			public String CreatePurchaseInInventeryOrderByEnity(out String message,PurchaseCommonEntity order,PurchaseInInventeryOrderDetailEntity[] orderDetails)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreatePurchaseInInventeryOrderByEnity....."));
				try
				{ 
					return pharmacyServcie.CreatePurchaseInInventeryOrderByEnity(out message,order,orderDetails);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreatePurchaseInInventeryOrderByEnity."));
				}
			}
		 
		      
			public String CreatePurchaseInInventeryOrder(out String message,PurchaseInInventeryOrder order,PurchaseInInventeryOrderDetail[] orderDetails)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreatePurchaseInInventeryOrder....."));
				try
				{ 
					return pharmacyServcie.CreatePurchaseInInventeryOrder(out message,order,orderDetails);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreatePurchaseInInventeryOrder."));
				}
			}
		 
		      
			public PurchaseInInventeryOrderDetailEntity[] GetPurchaseInInventeryOrderDetails(out String message,Guid orderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseInInventeryOrderDetails....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseInInventeryOrderDetails(out message,orderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseInInventeryOrderDetails."));
				}
			}
		 
		      
			public PurchaseCommonEntity[] GetPurchaseInInventeryOrders(out String message,String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseInInventeryOrders....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseInInventeryOrders(out message,documentNumber,startTime,endTime,orderStatusValue,purchaseUnits,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseInInventeryOrders."));
				}
			}
		 
		      
			public PurchaseCommonEntity[] GetPurchaseOrderReturnsByPurchaseOrderId(out String message,Guid purchaseOrderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseOrderReturnsByPurchaseOrderId....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseOrderReturnsByPurchaseOrderId(out message,purchaseOrderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseOrderReturnsByPurchaseOrderId."));
				}
			}
		 
		      
			public String CreatePurchaseOrderReturnByEnity(out String message,PurchaseCommonEntity order,PurchaseOrderReturnDetailEntity[] orderDetails)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreatePurchaseOrderReturnByEnity....."));
				try
				{ 
					return pharmacyServcie.CreatePurchaseOrderReturnByEnity(out message,order,orderDetails);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreatePurchaseOrderReturnByEnity."));
				}
			}
		 
		      
			public String SaveReturnOrderOutventory(SalesOrderReturn sor)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveReturnOrderOutventory....."));
				try
				{ 
					return pharmacyServcie.SaveReturnOrderOutventory(sor);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveReturnOrderOutventory."));
				}
			}
		 
		      
			public User[] GetSalesReturnOperatorUser(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesReturnOperatorUser....."));
				try
				{ 
					return pharmacyServcie.GetSalesReturnOperatorUser(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesReturnOperatorUser."));
				}
			}
		 
		      
			public User[] GetSalesReturnCheckUser(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesReturnCheckUser....."));
				try
				{ 
					return pharmacyServcie.GetSalesReturnCheckUser(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesReturnCheckUser."));
				}
			}
		 
		      
			public User[] GetSalesReturnInventoryUser(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesReturnInventoryUser....."));
				try
				{ 
					return pharmacyServcie.GetSalesReturnInventoryUser(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesReturnInventoryUser."));
				}
			}
		 
		      
			public User[] GetSalesReturnCancelUser(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesReturnCancelUser....."));
				try
				{ 
					return pharmacyServcie.GetSalesReturnCancelUser(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesReturnCancelUser."));
				}
			}
		 
		      
			public SalesOrderReturnDetail[] getOrderReturnDetailListByOrderID(out String message,Guid orderID)
			{
			    //Log.Warning(string.Format("开始调用服务方法:getOrderReturnDetailListByOrderID....."));
				try
				{ 
					return pharmacyServcie.getOrderReturnDetailListByOrderID(out message,orderID);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:getOrderReturnDetailListByOrderID."));
				}
			}
		 
		      
			public SalesOrderReturnDetail[] GetLastReturnDetailByReturnOrder(out String message,Guid orderID)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetLastReturnDetailByReturnOrder....."));
				try
				{ 
					return pharmacyServcie.GetLastReturnDetailByReturnOrder(out message,orderID);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetLastReturnDetailByReturnOrder."));
				}
			}
		 
		      
			public String SaveOrderReturnDetailList(SalesOrder orderInfo,SalesOrderReturnDetail[] detailList)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveOrderReturnDetailList....."));
				try
				{ 
					return pharmacyServcie.SaveOrderReturnDetailList(orderInfo,detailList);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveOrderReturnDetailList."));
				}
			}
		 
		      
			public OutInventory[] GetSubmitedOutInventoryByCondition(out PagerInfo pager,out String message,SalesCodeSearchInput condition,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSubmitedOutInventoryByCondition....."));
				try
				{ 
					return pharmacyServcie.GetSubmitedOutInventoryByCondition(out pager,out message,condition,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSubmitedOutInventoryByCondition."));
				}
			}
		 
		      
			public OutInventory[] GetAcceptedOutInventoryByCondition(out PagerInfo pager,out String message,SalesCodeSearchInput condition,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetAcceptedOutInventoryByCondition....."));
				try
				{ 
					return pharmacyServcie.GetAcceptedOutInventoryByCondition(out pager,out message,condition,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetAcceptedOutInventoryByCondition."));
				}
			}
		 
		      
			public OutInventory[] GetOutInventoryByStatus(out String message,int iStatus)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetOutInventoryByStatus....."));
				try
				{ 
					return pharmacyServcie.GetOutInventoryByStatus(out message,iStatus);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetOutInventoryByStatus."));
				}
			}
		 
		      
			public OutInventory[] GetAllNotApprovalOutInventory(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetAllNotApprovalOutInventory....."));
				try
				{ 
					return pharmacyServcie.GetAllNotApprovalOutInventory(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetAllNotApprovalOutInventory."));
				}
			}
		 
		      
			public OutInventory[] GetOutInventoryByOrderID(out String message,Guid orderID)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetOutInventoryByOrderID....."));
				try
				{ 
					return pharmacyServcie.GetOutInventoryByOrderID(out message,orderID);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetOutInventoryByOrderID."));
				}
			}
		 
		      
			public String SubmitOutInventory(OutInventory entity)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SubmitOutInventory....."));
				try
				{ 
					return pharmacyServcie.SubmitOutInventory(entity);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SubmitOutInventory."));
				}
			}
		 
		      
			public String AcceptOutInverntory(OutInventory entity)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AcceptOutInverntory....."));
				try
				{ 
					return pharmacyServcie.AcceptOutInverntory(entity);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AcceptOutInverntory."));
				}
			}
		 
		      
			public OutInventoryDetail[] GetOutInventoryDetailFromOrderDetail(out String message,Guid orderID)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetOutInventoryDetailFromOrderDetail....."));
				try
				{ 
					return pharmacyServcie.GetOutInventoryDetailFromOrderDetail(out message,orderID);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetOutInventoryDetailFromOrderDetail."));
				}
			}
		 
		      
			public String CreateSetSpeicalDrugRecords(SetSpeicalDrugRecord item)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreateSetSpeicalDrugRecords....."));
				try
				{ 
					return pharmacyServcie.CreateSetSpeicalDrugRecords(item);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreateSetSpeicalDrugRecords."));
				}
			}
		 
		      
			public SetSpeicalDrugRecord[] GetSetSpeicalDrugRecords(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSetSpeicalDrugRecords....."));
				try
				{ 
					return pharmacyServcie.GetSetSpeicalDrugRecords(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSetSpeicalDrugRecords."));
				}
			}
		 
		      
			public String[] GetBusinessScopeCodesBySupplyUnitGuid(out String message,Guid supplyUnitGuid)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetBusinessScopeCodesBySupplyUnitGuid....."));
				try
				{ 
					return pharmacyServcie.GetBusinessScopeCodesBySupplyUnitGuid(out message,supplyUnitGuid);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetBusinessScopeCodesBySupplyUnitGuid."));
				}
			}
		 
		      
			public String[] GetBusinessScopeCodesBySupplyUnit(out String message,SupplyUnit supplyUnit)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetBusinessScopeCodesBySupplyUnit....."));
				try
				{ 
					return pharmacyServcie.GetBusinessScopeCodesBySupplyUnit(out message,supplyUnit);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetBusinessScopeCodesBySupplyUnit."));
				}
			}
		 
		      
			public String[] GetManageCategoryDetailBySupplyUnitGuid(out String message,Guid supplyUnitGuid)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetManageCategoryDetailBySupplyUnitGuid....."));
				try
				{ 
					return pharmacyServcie.GetManageCategoryDetailBySupplyUnitGuid(out message,supplyUnitGuid);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetManageCategoryDetailBySupplyUnitGuid."));
				}
			}
		 
		      
			public String[] GetManageCategoryDetailBySupplyUnit(out String message,SupplyUnit supplyUnit)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetManageCategoryDetailBySupplyUnit....."));
				try
				{ 
					return pharmacyServcie.GetManageCategoryDetailBySupplyUnit(out message,supplyUnit);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetManageCategoryDetailBySupplyUnit."));
				}
			}
		 
		      
			public SupplyUnit GetSupplyUnitByFlowID(out String message,Guid flowId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSupplyUnitByFlowID....."));
				try
				{ 
					return pharmacyServcie.GetSupplyUnitByFlowID(out message,flowId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSupplyUnitByFlowID."));
				}
			}
		 
		      
			public String AddSupplyUnitApproveFlow(SupplyUnit su,Guid approvalFlowTypeID,Guid userID,String changeNote)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSupplyUnitApproveFlow....."));
				try
				{ 
					return pharmacyServcie.AddSupplyUnitApproveFlow(su,approvalFlowTypeID,userID,changeNote);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSupplyUnitApproveFlow."));
				}
			}
		 
		      
			public String ModifySupplyUnitApproveFlow(SupplyUnit su,Guid approvalFlowTypeID,Guid userID,String changeNote)
			{
			    //Log.Warning(string.Format("开始调用服务方法:ModifySupplyUnitApproveFlow....."));
				try
				{ 
					return pharmacyServcie.ModifySupplyUnitApproveFlow(su,approvalFlowTypeID,userID,changeNote);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:ModifySupplyUnitApproveFlow."));
				}
			}
		 
		      
			public SupplyUnit[] GetSupplyUnitForSupplyUnitSelector(out String message,Guid drugGuid,String name,String pinyin,String[] jyfwcode)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSupplyUnitForSupplyUnitSelector....."));
				try
				{ 
					return pharmacyServcie.GetSupplyUnitForSupplyUnitSelector(out message,drugGuid,name,pinyin,jyfwcode);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSupplyUnitForSupplyUnitSelector."));
				}
			}
		 
		      
			public bool IsExistSupplyUnitByName(out String message,String name)
			{
			    //Log.Warning(string.Format("开始调用服务方法:IsExistSupplyUnitByName....."));
				try
				{ 
					return pharmacyServcie.IsExistSupplyUnitByName(out message,name);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:IsExistSupplyUnitByName."));
				}
			}
		 
		      
			public SupplyUnit GetSupplyUnitByName(out String message,String name)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSupplyUnitByName....."));
				try
				{ 
					return pharmacyServcie.GetSupplyUnitByName(out message,name);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSupplyUnitByName."));
				}
			}
		 
		      
			public bool UpdateSupplyUnitByName(out String message,String name,SupplyUnit item)
			{
			    //Log.Warning(string.Format("开始调用服务方法:UpdateSupplyUnitByName....."));
				try
				{ 
					return pharmacyServcie.UpdateSupplyUnitByName(out message,name,item);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:UpdateSupplyUnitByName."));
				}
			}
		 
		      
			public SupplyUnit[] GetLockSupplyUnitUnit(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetLockSupplyUnitUnit....."));
				try
				{ 
					return pharmacyServcie.GetLockSupplyUnitUnit(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetLockSupplyUnitUnit."));
				}
			}
		 
		      
			public SupplyUnit[] GetPagedLockSupplyUnitUnit(out PagerInfo pager,out String message,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPagedLockSupplyUnitUnit....."));
				try
				{ 
					return pharmacyServcie.GetPagedLockSupplyUnitUnit(out pager,out message,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPagedLockSupplyUnitUnit."));
				}
			}
		 
		      
			public int GetLockSupplyUnitCount(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetLockSupplyUnitCount....."));
				try
				{ 
					return pharmacyServcie.GetLockSupplyUnitCount(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetLockSupplyUnitCount."));
				}
			}
		 
		      
			public ApprovalFlow[] GetApproveFlowsByUser(out String message,Guid userId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApproveFlowsByUser....."));
				try
				{ 
					return pharmacyServcie.GetApproveFlowsByUser(out message,userId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApproveFlowsByUser."));
				}
			}
		 
		      
			public ApprovalFlow[] GetApproveFlowsByUserType(out String message,Guid userId,int type)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApproveFlowsByUserType....."));
				try
				{ 
					return pharmacyServcie.GetApproveFlowsByUserType(out message,userId,type);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApproveFlowsByUserType."));
				}
			}
		 
		      
			public ApprovalFlow GetApproveFlowInstance(out String message,Guid approvalFlowTypeID,Guid flowID,Guid userID,String comment)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApproveFlowInstance....."));
				try
				{ 
					return pharmacyServcie.GetApproveFlowInstance(out message,approvalFlowTypeID,flowID,userID,comment);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApproveFlowInstance."));
				}
			}
		 
		      
			public ApprovalFlow[] GetApproveFlowsInfo(out String message,Guid flowTypeId,String changeNote)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApproveFlowsInfo....."));
				try
				{ 
					return pharmacyServcie.GetApproveFlowsInfo(out message,flowTypeId,changeNote);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApproveFlowsInfo."));
				}
			}
		 
		      
			public ApprovalFlow GetApproveFlowsByFlowID(out String message,Guid flowId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApproveFlowsByFlowID....."));
				try
				{ 
					return pharmacyServcie.GetApproveFlowsByFlowID(out message,flowId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApproveFlowsByFlowID."));
				}
			}
		 
		      
			public ApprovalDetailsModel[] GetApprovalDetails(out String message,Guid FlowID,int historyID,Object[] searchConditions)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApprovalDetails....."));
				try
				{ 
					return pharmacyServcie.GetApprovalDetails(out message,FlowID,historyID,searchConditions);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApprovalDetails."));
				}
			}
		 
		      
			public String SetApproveAction(ApprovalFlow flow,String action,Guid userID,String comment)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SetApproveAction....."));
				try
				{ 
					return pharmacyServcie.SetApproveAction(flow,action,userID,comment);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SetApproveAction."));
				}
			}
		 
		      
			public int GetNextSubflowIDByFlowId(out String message,Guid flowid)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetNextSubflowIDByFlowId....."));
				try
				{ 
					return pharmacyServcie.GetNextSubflowIDByFlowId(out message,flowid);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetNextSubflowIDByFlowId."));
				}
			}
		 
		      
			public int GetNeedApprovalCount(out String message,int approvalTypeValue)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetNeedApprovalCount....."));
				try
				{ 
					return pharmacyServcie.GetNeedApprovalCount(out message,approvalTypeValue);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetNeedApprovalCount."));
				}
			}
		 
		      
			public ApprovalFlowNode[] GetFinishApproveFlowsNodes(out String message,Guid FlowID,int historyID)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetFinishApproveFlowsNodes....."));
				try
				{ 
					return pharmacyServcie.GetFinishApproveFlowsNodes(out message,FlowID,historyID);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetFinishApproveFlowsNodes."));
				}
			}
		 
		      
			public ApprovalFlowNode GetNextApproveFlowsNode(out String message,Guid flowTypeId,Guid flowNodeID)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetNextApproveFlowsNode....."));
				try
				{ 
					return pharmacyServcie.GetNextApproveFlowsNode(out message,flowTypeId,flowNodeID);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetNextApproveFlowsNode."));
				}
			}
		 
		      
			public ApprovalFlowNode GetFirstApproveFlowsNode(out String message,Guid flowTypeId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetFirstApproveFlowsNode....."));
				try
				{ 
					return pharmacyServcie.GetFirstApproveFlowsNode(out message,flowTypeId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetFirstApproveFlowsNode."));
				}
			}
		 
		      
			public ApprovalFlowType[] GetApprovalFlowTypeByBusiness(out String message,ApprovalType approveType)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApprovalFlowTypeByBusiness....."));
				try
				{ 
					return pharmacyServcie.GetApprovalFlowTypeByBusiness(out message,approveType);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApprovalFlowTypeByBusiness."));
				}
			}
		 
		      
			public ApprovalFlowType[] GetApprovalFlowTypeByTypeList(out String message,Int32[] approveTypeList)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApprovalFlowTypeByTypeList....."));
				try
				{ 
					return pharmacyServcie.GetApprovalFlowTypeByTypeList(out message,approveTypeList);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApprovalFlowTypeByTypeList."));
				}
			}
		 
		      
			public ApprovalFlowRecord[] GetFinishApproveFlowsRecord(out String message,Guid FlowID,int historyID)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetFinishApproveFlowsRecord....."));
				try
				{ 
					return pharmacyServcie.GetFinishApproveFlowsRecord(out message,FlowID,historyID);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetFinishApproveFlowsRecord."));
				}
			}
		 
		      
			public ApprovalFlowRecord GetApproveFlowRecordInstance(out String message,ApprovalFlow flow,Guid userID,String comment)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApproveFlowRecordInstance....."));
				try
				{ 
					return pharmacyServcie.GetApproveFlowRecordInstance(out message,flow,userID,comment);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApproveFlowRecordInstance."));
				}
			}
		 
		      
			public BillDocumentCode GenerateBillDocumentCodeByTypeValue(out String message,int typeValue)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GenerateBillDocumentCodeByTypeValue....."));
				try
				{ 
					return pharmacyServcie.GenerateBillDocumentCodeByTypeValue(out message,typeValue);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GenerateBillDocumentCodeByTypeValue."));
				}
			}
		 
		      
			public Delivery[] GetSubmitedDeliveryByCondition(out PagerInfo pager,out String message,SalesCodeSearchInput condition,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSubmitedDeliveryByCondition....."));
				try
				{ 
					return pharmacyServcie.GetSubmitedDeliveryByCondition(out pager,out message,condition,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSubmitedDeliveryByCondition."));
				}
			}
		 
		      
			public Delivery[] GetCanceledDeliveryByCondition(out PagerInfo pager,out String message,SalesCodeSearchInput condition,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetCanceledDeliveryByCondition....."));
				try
				{ 
					return pharmacyServcie.GetCanceledDeliveryByCondition(out pager,out message,condition,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetCanceledDeliveryByCondition."));
				}
			}
		 
		      
			public Delivery[] GetOutedDeliveryByCondition(out PagerInfo pager,out String message,SalesCodeSearchInput condition,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetOutedDeliveryByCondition....."));
				try
				{ 
					return pharmacyServcie.GetOutedDeliveryByCondition(out pager,out message,condition,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetOutedDeliveryByCondition."));
				}
			}
		 
		      
			public Delivery[] GetSignedDeliveryByCondition(out PagerInfo pager,out String message,SalesCodeSearchInput condition,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSignedDeliveryByCondition....."));
				try
				{ 
					return pharmacyServcie.GetSignedDeliveryByCondition(out pager,out message,condition,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSignedDeliveryByCondition."));
				}
			}
		 
		      
			public Delivery[] GetReturnedDeliveryByCondition(out PagerInfo pager,out String message,SalesCodeSearchInput condition,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetReturnedDeliveryByCondition....."));
				try
				{ 
					return pharmacyServcie.GetReturnedDeliveryByCondition(out pager,out message,condition,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetReturnedDeliveryByCondition."));
				}
			}
		 
		      
			public Delivery[] GetDeliveryList(out String message,PagerInfo pager,DeliveryStatus deliveryStatus)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDeliveryList....."));
				try
				{ 
					return pharmacyServcie.GetDeliveryList(out message,pager,deliveryStatus);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDeliveryList."));
				}
			}
		 
		      
			public Delivery[] GetDeliveryPaged(out PagerInfo pager,out String message,DeliveryIndexInput deliveryIndexInput,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDeliveryPaged....."));
				try
				{ 
					return pharmacyServcie.GetDeliveryPaged(out pager,out message,deliveryIndexInput,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDeliveryPaged."));
                    
				}
			}
		 
		      
			public String SubmitDelivery(Delivery delivery)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SubmitDelivery....."));
				try
				{ 
					return pharmacyServcie.SubmitDelivery(delivery);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SubmitDelivery."));
				}
			}
		 
		      
			public String UpdateDelivery(Delivery delivery)
			{
			    //Log.Warning(string.Format("开始调用服务方法:UpdateDelivery....."));
				try
				{ 
					return pharmacyServcie.UpdateDelivery(delivery);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:UpdateDelivery."));
				}
			}
		 
		      
			public Department[] GetSubDepartments(out String message,Guid pDepartmentId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSubDepartments....."));
				try
				{ 
					return pharmacyServcie.GetSubDepartments(out message,pDepartmentId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSubDepartments."));
				}
			}
		 
		      
			public Department GetParentDepartment(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetParentDepartment....."));
				try
				{ 
					return pharmacyServcie.GetParentDepartment(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetParentDepartment."));
				}
			}
		 
		      
			public bool DeleteSubDepartment(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSubDepartment....."));
				try
				{ 
					return pharmacyServcie.DeleteSubDepartment(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSubDepartment."));
				}
			}
		 
		      
			public DoubtDrug[] QueryPagedDoubtDrugsForManage(out PagerInfo pager,out String message,String drugInfoName,String batchNumber,DateTimeRange inInventoryDateRange,DateTimeRange productDateRange,DateTimeRange outDataRange,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDoubtDrugsForManage....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDoubtDrugsForManage(out pager,out message,drugInfoName,batchNumber,inInventoryDateRange,productDateRange,outDataRange,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDoubtDrugsForManage."));
				}
			}
		 
		      
			public int GetNeedHandledDoubtDrug(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetNeedHandledDoubtDrug....."));
				try
				{ 
					return pharmacyServcie.GetNeedHandledDoubtDrug(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetNeedHandledDoubtDrug."));
				}
			}
		 
		      
			public DrugInfo[] GetDrugInfoByPurchaseUnit(out String message,Guid purchaseUnitGuid)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugInfoByPurchaseUnit....."));
				try
				{ 
					return pharmacyServcie.GetDrugInfoByPurchaseUnit(out message,purchaseUnitGuid);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugInfoByPurchaseUnit."));
				}
			}
		 
		      
			public DrugInfo[] GetDrugInfoBySupplyUnit(out String message,Guid supplyUnitGuid)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugInfoBySupplyUnit....."));
				try
				{ 
					return pharmacyServcie.GetDrugInfoBySupplyUnit(out message,supplyUnitGuid);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugInfoBySupplyUnit."));
				}
			}
		 
		      
			public bool IsExistDrugInfo(out String message,DrugInfo info)
			{
			    //Log.Warning(string.Format("开始调用服务方法:IsExistDrugInfo....."));
				try
				{ 
					return pharmacyServcie.IsExistDrugInfo(out message,info);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:IsExistDrugInfo."));
				}
			}
		 
		      
			public DrugInfo[] GetDrugInfoForDrugInfoForSalesSelector(out String message,Guid purchaseUnitGuid,String tym,String bwm,String code)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugInfoForDrugInfoForSalesSelector....."));
				try
				{ 
					return pharmacyServcie.GetDrugInfoForDrugInfoForSalesSelector(out message,purchaseUnitGuid,tym,bwm,code);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugInfoForDrugInfoForSalesSelector."));
				}
			}
		 
		      
			public DrugInfo[] GetDrugInfoForPurchasing(out String message,String productName,String productGeneralName,String code)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugInfoForPurchasing....."));
				try
				{ 
					return pharmacyServcie.GetDrugInfoForPurchasing(out message,productName,productGeneralName,code);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugInfoForPurchasing."));
				}
			}
		 
		      
			public DrugInfo[] GetDrugInfoForSupplyUnitWithQueryParas(out String message,Guid supplyUnitId,String generalName,String code,String standardCode)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugInfoForSupplyUnitWithQueryParas....."));
				try
				{ 
					return pharmacyServcie.GetDrugInfoForSupplyUnitWithQueryParas(out message,supplyUnitId,generalName,code,standardCode);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugInfoForSupplyUnitWithQueryParas."));
				}
			}
		 
		      
			public LackDrugModel[] GetDrugInfoForOutofStock(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugInfoForOutofStock....."));
				try
				{ 
					return pharmacyServcie.GetDrugInfoForOutofStock(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugInfoForOutofStock."));
				}
			}
		 
		      
			public DrugInfo GetDrugInfoByFlowID(out String message,Guid flowId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugInfoByFlowID....."));
				try
				{ 
					return pharmacyServcie.GetDrugInfoByFlowID(out message,flowId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugInfoByFlowID."));
				}
			}

            //WFZ modified
            public DrugInfo GetGoodsInfoByFlowID(out String message, Guid flowId)
            {
                //Log.Warning(string.Format("开始调用服务方法:GetDrugInfoByFlowID....."));
                try
                {
                    return pharmacyServcie.GetGoodsInfoByFlowID(out message, flowId);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:GetDrugInfoByFlowID."));
                }
            }
            //modified end
		 
		      
			public String AddDrugInfoApproveFlow(DrugInfo su,Guid approvalFlowTypeID,Guid userID,String changeNote)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDrugInfoApproveFlow....."));
				try
				{ 
					return pharmacyServcie.AddDrugInfoApproveFlow(su,approvalFlowTypeID,userID,changeNote);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDrugInfoApproveFlow."));
				}
			}
		 
		      
			public String ModifyDrugInfoApproveFlow(DrugInfo su,Guid approvalFlowTypeID,Guid userID,String changeNote)
			{
			    //Log.Warning(string.Format("开始调用服务方法:ModifyDrugInfoApproveFlow....."));
				try
				{ 
					return pharmacyServcie.ModifyDrugInfoApproveFlow(su,approvalFlowTypeID,userID,changeNote);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:ModifyDrugInfoApproveFlow."));
				}
			}
		 
		      
			public DrugInfo[] GetLockDrugInfo(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetLockDrugInfo....."));
				try
				{ 
					return pharmacyServcie.GetLockDrugInfo(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetLockDrugInfo."));
				}
			}
		 
		      
			public int GetLockDrugInfoCount(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetLockDrugInfoCount....."));
				try
				{ 
					return pharmacyServcie.GetLockDrugInfoCount(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetLockDrugInfoCount."));
				}
			}
		 
		      
			public DrugInfo[] GetPagedLockDrugInfo(out PagerInfo pager,out String message,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPagedLockDrugInfo....."));
				try
				{ 
					return pharmacyServcie.GetPagedLockDrugInfo(out pager,out message,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPagedLockDrugInfo."));
				}
			}
		 
		      
			public DrugInfo[] SearchPagedDrugInfosByAllStrings(out PagerInfo pager,out String message,String keys,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDrugInfosByAllStrings....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDrugInfosByAllStrings(out pager,out message,keys,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDrugInfosByAllStrings."));
				}
			}
		 
		      
			public DrugInventoryRecord[] GetDrugInventoryRecordForDrugInfoForSalesSelector(out String message,Guid purchaseUnitGuid,String tym,String bwm,String code)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugInventoryRecordForDrugInfoForSalesSelector....."));
				try
				{ 
					return pharmacyServcie.GetDrugInventoryRecordForDrugInfoForSalesSelector(out message,purchaseUnitGuid,tym,bwm,code);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugInventoryRecordForDrugInfoForSalesSelector."));
                    
                    GC.Collect();
				}
			}
		 
		      
			public DrugInventoryRecord[] GetDrugInventoryRecordByCondition(out String message,String ProductName,String BatchNumber)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugInventoryRecordByCondition....."));
				try
				{ 
					return pharmacyServcie.GetDrugInventoryRecordByCondition(out message,ProductName,BatchNumber);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugInventoryRecordByCondition."));
				}
			}
		 
		      
			public DrugInventoryRecord[] QueryPagedAllDrugInventoryRecordSelector(out PagerInfo pager,out String message,QueryDrugInventoryRecordBusinessModel queryModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedAllDrugInventoryRecordSelector....."));
				try
				{ 
					return pharmacyServcie.QueryPagedAllDrugInventoryRecordSelector(out pager,out message,queryModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedAllDrugInventoryRecordSelector."));
				}
			}
		 
		      
			public InventeryModel[] StorageQuery(out String message,String ProductGeneralName,String StandardCode,String BatchNumber,Guid[] WarehouseZones,int index,int size,Object[] searchConditions)
			{
			    //Log.Warning(string.Format("开始调用服务方法:StorageQuery....."));
				try
				{ 
					return pharmacyServcie.StorageQuery(out message,ProductGeneralName,StandardCode,BatchNumber,WarehouseZones,index,size,searchConditions);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:StorageQuery."));
				}
			}
		 
		      
			public DrugMaintainRecord[] GetDrugMaintainRecordByCondition(out String message,DateTime StartDate,DateTime EndDate,Nullable<Int32> CompleteState,Nullable<Int32> DrugMaintainType)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugMaintainRecordByCondition....."));
				try
				{ 
					return pharmacyServcie.GetDrugMaintainRecordByCondition(out message,StartDate,EndDate,CompleteState,DrugMaintainType);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugMaintainRecordByCondition."));
				}
			}
		 
		      
			public bool SaveDrugMaintainRecordByBillDocumentNo(out String message,String BillDocumentNo,bool IsCompleteState)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDrugMaintainRecordByBillDocumentNo....."));
				try
				{ 
					return pharmacyServcie.SaveDrugMaintainRecordByBillDocumentNo(out message,BillDocumentNo,IsCompleteState);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDrugMaintainRecordByBillDocumentNo."));
				}
			}
		 
		      
			public DrugMaintainRecordDetail[] GetDrugMaintainRecordDetailByCondition(out String message,String BillDocumentNo,Nullable<DateTime> CheckDate)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugMaintainRecordDetailByCondition....."));
				try
				{ 
					return pharmacyServcie.GetDrugMaintainRecordDetailByCondition(out message,BillDocumentNo,CheckDate);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugMaintainRecordDetailByCondition."));
				}
			}
		 
		      
			public DrugMaintainSet GetDrugMaintainSetByDrugMaintainTypeValue(out String message,int DrugMaintainTypeValue)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugMaintainSetByDrugMaintainTypeValue....."));
				try
				{ 
					return pharmacyServcie.GetDrugMaintainSetByDrugMaintainTypeValue(out message,DrugMaintainTypeValue);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugMaintainSetByDrugMaintainTypeValue."));
				}
			}
		 
		      
			public bool DeleteBusinessScope(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteBusinessScope....."));
				try
				{ 
					return pharmacyServcie.DeleteBusinessScope(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteBusinessScope."));
				}
			}
		 
		      
			public bool SaveBusinessScope(out String msg,BusinessScope value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveBusinessScope....."));
				try
				{ 
					return pharmacyServcie.SaveBusinessScope(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveBusinessScope."));
				}
			}
		 
		      
			public BusinessScope[] AllBusinessScopes(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllBusinessScopes....."));
				try
				{ 
					return pharmacyServcie.AllBusinessScopes(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllBusinessScopes."));
				}
			}
		 
		      
			public BusinessScope[] QueryBusinessScopes(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryBusinessScopes....."));
				try
				{ 
					return pharmacyServcie.QueryBusinessScopes(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryBusinessScopes."));
				}
			}
		 
		      
			public BusinessScope[] QueryPagedBusinessScopes(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedBusinessScopes....."));
				try
				{ 
					return pharmacyServcie.QueryPagedBusinessScopes(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedBusinessScopes."));
				}
			}
		 
		      
			public BusinessScope[] SearchBusinessScopesByQueryModel(out String message,QueryBusinessScopeModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchBusinessScopesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchBusinessScopesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchBusinessScopesByQueryModel."));
				}
			}
		 
		      
			public BusinessScope[] SearchPagedBusinessScopesByQueryModel(out PagerInfo pager,QueryBusinessScopeModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedBusinessScopesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedBusinessScopesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedBusinessScopesByQueryModel."));
				}
			}
		 
		      
			public BusinessScopeCategory GetBusinessScopeCategory(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetBusinessScopeCategory....."));
				try
				{ 
					return pharmacyServcie.GetBusinessScopeCategory(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetBusinessScopeCategory."));
				}
			}
		 
		      
			public bool AddBusinessScopeCategory(out String msg,BusinessScopeCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddBusinessScopeCategory....."));
				try
				{ 
					return pharmacyServcie.AddBusinessScopeCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddBusinessScopeCategory."));
				}
			}
		 
		      
			public bool DeleteBusinessScopeCategory(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteBusinessScopeCategory....."));
				try
				{ 
					return pharmacyServcie.DeleteBusinessScopeCategory(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteBusinessScopeCategory."));
				}
			}
		 
		      
			public bool SaveBusinessScopeCategory(out String msg,BusinessScopeCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveBusinessScopeCategory....."));
				try
				{ 
					return pharmacyServcie.SaveBusinessScopeCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveBusinessScopeCategory."));
				}
			}
		 
		      
			public BusinessScopeCategory[] AllBusinessScopeCategorys(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllBusinessScopeCategorys....."));
				try
				{ 
					return pharmacyServcie.AllBusinessScopeCategorys(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllBusinessScopeCategorys."));
				}
			}
		 
		      
			public BusinessScopeCategory[] QueryBusinessScopeCategorys(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryBusinessScopeCategorys....."));
				try
				{ 
					return pharmacyServcie.QueryBusinessScopeCategorys(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryBusinessScopeCategorys."));
				}
			}
		 
		      
			public BusinessScopeCategory[] QueryPagedBusinessScopeCategorys(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedBusinessScopeCategorys....."));
				try
				{ 
					return pharmacyServcie.QueryPagedBusinessScopeCategorys(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedBusinessScopeCategorys."));
				}
			}
		 
		      
			public BusinessScopeCategory[] SearchBusinessScopeCategorysByQueryModel(out String message,QueryBusinessScopeCategoryModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchBusinessScopeCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchBusinessScopeCategorysByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchBusinessScopeCategorysByQueryModel."));
				}
			}
		 
		      
			public BusinessScopeCategory[] SearchPagedBusinessScopeCategorysByQueryModel(out PagerInfo pager,QueryBusinessScopeCategoryModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedBusinessScopeCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedBusinessScopeCategorysByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedBusinessScopeCategorysByQueryModel."));
				}
			}
		 
		      
			public BusinessType GetBusinessType(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetBusinessType....."));
				try
				{ 
					return pharmacyServcie.GetBusinessType(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetBusinessType."));
				}
			}
		 
		      
			public bool AddBusinessType(out String msg,BusinessType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddBusinessType....."));
				try
				{ 
					return pharmacyServcie.AddBusinessType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddBusinessType."));
				}
			}
		 
		      
			public bool DeleteBusinessType(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteBusinessType....."));
				try
				{ 
					return pharmacyServcie.DeleteBusinessType(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteBusinessType."));
				}
			}
		 
		      
			public bool SaveBusinessType(out String msg,BusinessType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveBusinessType....."));
				try
				{ 
					return pharmacyServcie.SaveBusinessType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveBusinessType."));
				}
			}
		 
		      
			public BusinessType[] AllBusinessTypes(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllBusinessTypes....."));
				try
				{ 
					return pharmacyServcie.AllBusinessTypes(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllBusinessTypes."));
				}
			}
		 
		      
			public BusinessType[] QueryBusinessTypes(out String msg,String decription,String code,String name,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryBusinessTypes....."));
				try
				{ 
					return pharmacyServcie.QueryBusinessTypes(out msg,decription,code,name,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryBusinessTypes."));
				}
			}
		 
		      
			public BusinessType[] QueryPagedBusinessTypes(out PagerInfo pager,String decription,String code,String name,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedBusinessTypes....."));
				try
				{ 
					return pharmacyServcie.QueryPagedBusinessTypes(out pager,decription,code,name,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedBusinessTypes."));
				}
			}
		 
		      
			public BusinessType[] SearchBusinessTypesByQueryModel(out String message,QueryBusinessTypeModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchBusinessTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchBusinessTypesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchBusinessTypesByQueryModel."));
				}
			}
		 
		      
			public BusinessType[] SearchPagedBusinessTypesByQueryModel(out PagerInfo pager,QueryBusinessTypeModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedBusinessTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedBusinessTypesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedBusinessTypesByQueryModel."));
				}
			}
		 
		      
			public BusinessTypeManageCategoryDetail GetBusinessTypeManageCategoryDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetBusinessTypeManageCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.GetBusinessTypeManageCategoryDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetBusinessTypeManageCategoryDetail."));
				}
			}
		 
		      
			public bool AddBusinessTypeManageCategoryDetail(out String msg,BusinessTypeManageCategoryDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddBusinessTypeManageCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.AddBusinessTypeManageCategoryDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddBusinessTypeManageCategoryDetail."));
				}
			}
		 
		      
			public bool DeleteBusinessTypeManageCategoryDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteBusinessTypeManageCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.DeleteBusinessTypeManageCategoryDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteBusinessTypeManageCategoryDetail."));
				}
			}
		 
		      
			public bool SaveBusinessTypeManageCategoryDetail(out String msg,BusinessTypeManageCategoryDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveBusinessTypeManageCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.SaveBusinessTypeManageCategoryDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveBusinessTypeManageCategoryDetail."));
				}
			}
		 
		      
			public BusinessTypeManageCategoryDetail[] AllBusinessTypeManageCategoryDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllBusinessTypeManageCategoryDetails....."));
				try
				{ 
					return pharmacyServcie.AllBusinessTypeManageCategoryDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllBusinessTypeManageCategoryDetails."));
				}
			}
		 
		      
			public BusinessTypeManageCategoryDetail[] QueryBusinessTypeManageCategoryDetails(out String msg)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryBusinessTypeManageCategoryDetails....."));
				try
				{ 
					return pharmacyServcie.QueryBusinessTypeManageCategoryDetails(out msg);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryBusinessTypeManageCategoryDetails."));
				}
			}
		 
		      
			public BusinessTypeManageCategoryDetail[] QueryPagedBusinessTypeManageCategoryDetails(out PagerInfo pager,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedBusinessTypeManageCategoryDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedBusinessTypeManageCategoryDetails(out pager,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedBusinessTypeManageCategoryDetails."));
				}
			}
		 
		      
			public String CreatePurchaseOrderReturn(out String message,PurchaseOrderReturn order,PurchaseOrderReturnDetail[] orderDetails)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreatePurchaseOrderReturn....."));
				try
				{ 
					return pharmacyServcie.CreatePurchaseOrderReturn(out message,order,orderDetails);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreatePurchaseOrderReturn."));
				}
			}
		 
		      
			public PurchaseCommonEntity[] GetPurchaseOrderReturns(out String message,String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseOrderReturns....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseOrderReturns(out message,documentNumber,startTime,endTime,orderStatusValue,purchaseUnits,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseOrderReturns."));
				}
			}
		 
		      
			public PurchaseOrderReturnDetailEntity[] GetPurchaseOrderReturnDetails(out String message,Guid orderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseOrderReturnDetails....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseOrderReturnDetails(out message,orderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseOrderReturnDetails."));
				}
			}
		 
		      
			public PurchaseCommonEntity[] GetPurchaseCashOrdersByPurchaseOrderId(out String message,Guid purchaseOrderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseCashOrdersByPurchaseOrderId....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseCashOrdersByPurchaseOrderId(out message,purchaseOrderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseCashOrdersByPurchaseOrderId."));
				}
			}
		 
		      
			public String CreatePurchaseCashOrderByEnity(out String message,PurchaseCommonEntity order)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreatePurchaseCashOrderByEnity....."));
				try
				{ 
					return pharmacyServcie.CreatePurchaseCashOrderByEnity(out message,order);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreatePurchaseCashOrderByEnity."));
				}
			}
		 
		      
			public String CreatePurchaseCashOrder(out String message,PurchaseCashOrder order)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CreatePurchaseCashOrder....."));
				try
				{ 
					return pharmacyServcie.CreatePurchaseCashOrder(out message,order);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CreatePurchaseCashOrder."));
				}
			}
		 
		      
			public PurchaseCommonEntity[] GetPurchaseCashOrders(out String message,String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseCashOrders....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseCashOrders(out message,documentNumber,startTime,endTime,orderStatusValue,purchaseUnits,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseCashOrders."));
				}
			}
		 
		      
			public PurchaseOrderDetail[] GetPurchaseOrderDetailByOrderId(out String message,Guid purchaseOrderId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseOrderDetailByOrderId....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseOrderDetailByOrderId(out message,purchaseOrderId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseOrderDetailByOrderId."));
				}
			}
		 
		      
			public String[] GetBusinessScopeCodesByPurchaseUnitGuid(out String message,Guid purchaseUnitGuid)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetBusinessScopeCodesByPurchaseUnitGuid....."));
				try
				{ 
					return pharmacyServcie.GetBusinessScopeCodesByPurchaseUnitGuid(out message,purchaseUnitGuid);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetBusinessScopeCodesByPurchaseUnitGuid."));
				}
			}
		 
		      
			public String[] GetBusinessScopeCodesByPurchaseUnit(out String message,PurchaseUnit purchaseUnit)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetBusinessScopeCodesByPurchaseUnit....."));
				try
				{ 
					return pharmacyServcie.GetBusinessScopeCodesByPurchaseUnit(out message,purchaseUnit);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetBusinessScopeCodesByPurchaseUnit."));
				}
			}
		 
		      
			public String[] GetManageCategoryDetailByPurchaseUnitGuid(out String message,Guid purchaseUnitGuid)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetManageCategoryDetailByPurchaseUnitGuid....."));
				try
				{ 
					return pharmacyServcie.GetManageCategoryDetailByPurchaseUnitGuid(out message,purchaseUnitGuid);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetManageCategoryDetailByPurchaseUnitGuid."));
				}
			}
		 
		      
			public String[] GetManageCategoryDetailByPurchaseUnit(out String message,PurchaseUnit purchaseUnit)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetManageCategoryDetailByPurchaseUnit....."));
				try
				{ 
					return pharmacyServcie.GetManageCategoryDetailByPurchaseUnit(out message,purchaseUnit);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetManageCategoryDetailByPurchaseUnit."));
				}
			}
		 
		      
			public PurchaseUnit[] GetPurchaseUnitsForSelector(out String message,String name,String code,String py)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseUnitsForSelector....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseUnitsForSelector(out message,name,code,py);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseUnitsForSelector."));
				}
			}
		 
		      
			public bool IsExistPurchaseUnitByName(out String message,String name)
			{
			    //Log.Warning(string.Format("开始调用服务方法:IsExistPurchaseUnitByName....."));
				try
				{ 
					return pharmacyServcie.IsExistPurchaseUnitByName(out message,name);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:IsExistPurchaseUnitByName."));
				}
			}
		 
		      
			public PurchaseUnit GetPurchaseUnitByName(out String message,String name)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseUnitByName....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseUnitByName(out message,name);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseUnitByName."));
				}
			}
		 
		      
			public bool UpdatePurchaseUnitByName(out String message,String name,PurchaseUnit item)
			{
			    //Log.Warning(string.Format("开始调用服务方法:UpdatePurchaseUnitByName....."));
				try
				{ 
					return pharmacyServcie.UpdatePurchaseUnitByName(out message,name,item);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:UpdatePurchaseUnitByName."));
				}
			}
		 
		      
			public PurchaseUnit GetPurchaseUnitByFlowID(out String message,Guid flowId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseUnitByFlowID....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseUnitByFlowID(out message,flowId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseUnitByFlowID."));
				}
			}
		 
		      
			public String AddPurchaseUnitApproveFlow(PurchaseUnit su,Guid approvalFlowTypeID,Guid userID,String changeNote)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseUnitApproveFlow....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseUnitApproveFlow(su,approvalFlowTypeID,userID,changeNote);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseUnitApproveFlow."));
				}
			}
		 
		      
			public String ModifyPurchaseUnitApproveFlow(PurchaseUnit su,Guid approvalFlowTypeID,Guid userID,String changeNote)
			{
			    //Log.Warning(string.Format("开始调用服务方法:ModifyPurchaseUnitApproveFlow....."));
				try
				{ 
					return pharmacyServcie.ModifyPurchaseUnitApproveFlow(su,approvalFlowTypeID,userID,changeNote);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:ModifyPurchaseUnitApproveFlow."));
				}
			}
		 
		      
			public PurchaseUnit[] GetLockPurchaseUnit(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetLockPurchaseUnit....."));
				try
				{ 
					return pharmacyServcie.GetLockPurchaseUnit(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetLockPurchaseUnit."));
				}
			}
		 
		      
			public int GetLockPurchaseUnitCount(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetLockPurchaseUnitCount....."));
				try
				{ 
					return pharmacyServcie.GetLockPurchaseUnitCount(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetLockPurchaseUnitCount."));
				}
			}
		 
		      
			public PurchaseUnit[] GetPagedLockPurchaseUnit(out PagerInfo pager,out String message,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPagedLockPurchaseUnit....."));
				try
				{ 
					return pharmacyServcie.GetPagedLockPurchaseUnit(out pager,out message,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPagedLockPurchaseUnit."));
				}
			}
		 
		      
			public RetailOrder[] GetRetailOrderPagedByCode(out PagerInfo pager,out String message,String orderCode,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetRetailOrderPagedByCode....."));
				try
				{ 
					return pharmacyServcie.GetRetailOrderPagedByCode(out pager,out message,orderCode,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetRetailOrderPagedByCode."));
				}
			}
		 
		      
			public String AddRetailOrderAndDetails(RetailOrder ro)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddRetailOrderAndDetails....."));
				try
				{ 
					return pharmacyServcie.AddRetailOrderAndDetails(ro);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddRetailOrderAndDetails."));
				}
			}
		 
		      
			public String DeleteRetailOrderAndDetails(Guid retailOrderID)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteRetailOrderAndDetails....."));
				try
				{ 
					return pharmacyServcie.DeleteRetailOrderAndDetails(retailOrderID);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteRetailOrderAndDetails."));
				}
			}
		 
		      
			public String SaveRetailOrderAndDetails(RetailOrder ro)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveRetailOrderAndDetails....."));
				try
				{ 
					return pharmacyServcie.SaveRetailOrderAndDetails(ro);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveRetailOrderAndDetails."));
				}
			}
		 
		      
			public RoleWithUser[] GetRoleWithUserInfo(out String message,Guid UserID,Guid RoleId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetRoleWithUserInfo....."));
				try
				{ 
					return pharmacyServcie.GetRoleWithUserInfo(out message,UserID,RoleId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetRoleWithUserInfo."));
				}
			}
		 
		      
			public SalesOrder[] GetOrderStatusList(out String message,Int32[] orderStatusList)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetOrderStatusList....."));
				try
				{ 
					return pharmacyServcie.GetOrderStatusList(out message,orderStatusList);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetOrderStatusList."));
				}
			}
		 
		      
			public String AddSalesOrderAndDetails(SalesOrder so)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSalesOrderAndDetails....."));
				try
				{ 
					return pharmacyServcie.AddSalesOrderAndDetails(so);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSalesOrderAndDetails."));
				}
			}
		 
		      
			public String ModifySalesOrderAndDetails(SalesOrder so)
			{
			    //Log.Warning(string.Format("开始调用服务方法:ModifySalesOrderAndDetails....."));
				try
				{ 
					return pharmacyServcie.ModifySalesOrderAndDetails(so);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:ModifySalesOrderAndDetails."));
				}
			}
		 
		      
			public String DeleteSalesOrderAndDetails(Guid salesOrderID)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSalesOrderAndDetails....."));
				try
				{ 
					return pharmacyServcie.DeleteSalesOrderAndDetails(salesOrderID);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSalesOrderAndDetails."));
				}
			}
		 
		      
			public SalesOrder[] GetSalesOrderByStatus(out String message,int statusValue)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderByStatus....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderByStatus(out message,statusValue);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderByStatus."));
				}
			}
		 
		      
			public SalesOrder[] GetSalesOrderByOrderCode(out String message,String code)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderByOrderCode....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderByOrderCode(out message,code);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderByOrderCode."));
				}
			}
		 
		      
			public SalesOrderStatisticOutput[] AddupSalesOrder(out String message,SalesOrderStatisticInput input)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddupSalesOrder....."));
				try
				{ 
					return pharmacyServcie.AddupSalesOrder(out message,input);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddupSalesOrder."));
				}
			}
		 
		      
			public Business.Models.SaleOrderModel[] GetSalesOrderBalanceCodePaged(SalesCodeSearchInput searchInput,out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderBalanceCodePaged....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderBalanceCodePaged(searchInput,out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderBalanceCodePaged."));
				}
			}
		 
		      
			public SalesOrder[] GetSalesOrderCodePaged(out PagerInfo pager,out String message,SalesCodeSearchInput searchInput,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderCodePaged....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderCodePaged(out pager,out message,searchInput,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderCodePaged."));
				}
			}


            public Business.Models.SaleOrderModel[] GetSalesOrderCancelCodePaged(out String message, SalesCodeSearchInput searchInput)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderCancelCodePaged....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderCancelCodePaged(out message,searchInput);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderCancelCodePaged."));
				}
			}
		 
		      
			public User[] GetSalesOrderOperatorUser(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderOperatorUser....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderOperatorUser(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderOperatorUser."));
				}
			}
		 
		      
			public User[] GetSalesOrderCancelUser(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderCancelUser....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderCancelUser(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderCancelUser."));
				}
			}
		 
		      
			public User[] GetSalesOrderBalanceUser(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderBalanceUser....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderBalanceUser(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderBalanceUser."));
				}
			}
		 
		      
			public SalesOrderRecordOutput[] GetSalesOrderRecordPaged(out PagerInfo pager,out String message,SalesOrderRecordInput searchInput,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderRecordPaged....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderRecordPaged(out pager,out message,searchInput,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderRecordPaged."));
				}
			}
		 
		      
			public String CancelSalesOrder(SalesOrder so)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CancelSalesOrder....."));
				try
				{ 
					return pharmacyServcie.CancelSalesOrder(so);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CancelSalesOrder."));
				}
			}
		 
		      
			public SalesOrderReturn[] GetAllNoOverOrderReturn(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetAllNoOverOrderReturn....."));
				try
				{ 
					return pharmacyServcie.GetAllNoOverOrderReturn(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetAllNoOverOrderReturn."));
				}
			}
		 
		      
			public SalesOrderReturn[] GetSalesOrderReturnByStatus(out String message,Int32[] listOrderReturnStatus)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderReturnByStatus....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderReturnByStatus(out message,listOrderReturnStatus);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnByStatus."));
				}
			}
		 
		      
			public SalesOrderReturn GetLastOrderReturnByReturnOrder(out String message,Guid outInventoryID)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetLastOrderReturnByReturnOrder....."));
				try
				{ 
					return pharmacyServcie.GetLastOrderReturnByReturnOrder(out message,outInventoryID);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetLastOrderReturnByReturnOrder."));
				}
			}
		 
		      
			public String AddSalesOrderReturnAndDetail(SalesOrderReturn sor)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSalesOrderReturnAndDetail....."));
				try
				{ 
					return pharmacyServcie.AddSalesOrderReturnAndDetail(sor);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSalesOrderReturnAndDetail."));
				}
			}
		 
		      
			public String CancelSalesOrderReturn(SalesOrderReturn sor)
			{
			    //Log.Warning(string.Format("开始调用服务方法:CancelSalesOrderReturn....."));
				try
				{ 
					return pharmacyServcie.CancelSalesOrderReturn(sor);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:CancelSalesOrderReturn."));
				}
			}
		 
		      
			public String AcceptSalesOrderReturn(SalesOrderReturn sor)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AcceptSalesOrderReturn....."));
				try
				{ 
					return pharmacyServcie.AcceptSalesOrderReturn(sor);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AcceptSalesOrderReturn."));
				}
			}
		 
		      
			public String SaveReturnOrderInventory(SalesOrderReturn sor)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveReturnOrderInventory....."));
				try
				{ 
					return pharmacyServcie.SaveReturnOrderInventory(sor);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveReturnOrderInventory."));
				}
			}
		 
		      
			public SalesOrderReturn[] GetReturnOrderCodePaged(out PagerInfo pager,out String message,SalesCodeSearchInput searchInput,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetReturnOrderCodePaged....."));
				try
				{ 
					return pharmacyServcie.GetReturnOrderCodePaged(out pager,out message,searchInput,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetReturnOrderCodePaged."));
				}
			}


            public Business.Models.SalesOrderReturnModel[] GetReturnOrderCheckCodePaged(SalesCodeSearchInput searchInput, out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetReturnOrderCheckCodePaged....."));
				try
				{ 
					return pharmacyServcie.GetReturnOrderCheckCodePaged(searchInput,out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetReturnOrderCheckCodePaged."));
				}
			}
		 
		      
			public SalesOrderReturn[] GetReturnOrderInventoryCodePaged(out PagerInfo pager,out String message,SalesCodeSearchInput searchInput,int pageindex,int pageSize)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetReturnOrderInventoryCodePaged....."));
				try
				{ 
					return pharmacyServcie.GetReturnOrderInventoryCodePaged(out pager,out message,searchInput,pageindex,pageSize);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetReturnOrderInventoryCodePaged."));
				}
			}


            public Business.Models.SalesOrderReturnModel[] GetReturnOrderCancelCodePaged(SalesCodeSearchInput searchInput, out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetReturnOrderCancelCodePaged....."));
				try
				{ 
					return pharmacyServcie.GetReturnOrderCancelCodePaged(searchInput,out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetReturnOrderCancelCodePaged."));
				}
			}
		 
		      
			public DoubtDrug[] QueryPagedDoubtDrugs(out PagerInfo pager,String jsondruginventoryrecord,String decription,bool handled,bool queryhandled,String handledecription,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDoubtDrugs....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDoubtDrugs(out pager,jsondruginventoryrecord,decription,handled,queryhandled,handledecription,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDoubtDrugs."));
				}
			}
		 
		      
			public DoubtDrug[] SearchDoubtDrugsByQueryModel(out String message,QueryDoubtDrugModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDoubtDrugsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDoubtDrugsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDoubtDrugsByQueryModel."));
				}
			}
		 
		      
			public DoubtDrug[] SearchPagedDoubtDrugsByQueryModel(out PagerInfo pager,QueryDoubtDrugModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDoubtDrugsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDoubtDrugsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDoubtDrugsByQueryModel."));
				}
			}
		 
		      
			public DrugApprovalNumber GetDrugApprovalNumber(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugApprovalNumber....."));
				try
				{ 
					return pharmacyServcie.GetDrugApprovalNumber(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugApprovalNumber."));
				}
			}
		 
		      
			public bool AddDrugApprovalNumber(out String msg,DrugApprovalNumber value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDrugApprovalNumber....."));
				try
				{ 
					return pharmacyServcie.AddDrugApprovalNumber(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDrugApprovalNumber."));
				}
			}
		 
		      
			public bool DeleteDrugApprovalNumber(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDrugApprovalNumber....."));
				try
				{ 
					return pharmacyServcie.DeleteDrugApprovalNumber(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDrugApprovalNumber."));
				}
			}
		 
		      
			public bool SaveDrugApprovalNumber(out String msg,DrugApprovalNumber value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDrugApprovalNumber....."));
				try
				{ 
					return pharmacyServcie.SaveDrugApprovalNumber(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDrugApprovalNumber."));
				}
			}
		 
		      
			public DrugApprovalNumber[] AllDrugApprovalNumbers(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDrugApprovalNumbers....."));
				try
				{ 
					return pharmacyServcie.AllDrugApprovalNumbers(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDrugApprovalNumbers."));
				}
			}
		 
		      
			public DrugApprovalNumber[] QueryDrugApprovalNumbers(out String msg,String name,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDrugApprovalNumbers....."));
				try
				{ 
					return pharmacyServcie.QueryDrugApprovalNumbers(out msg,name,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDrugApprovalNumbers."));
				}
			}
		 
		      
			public DrugApprovalNumber[] QueryPagedDrugApprovalNumbers(out PagerInfo pager,String name,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDrugApprovalNumbers....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDrugApprovalNumbers(out pager,name,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDrugApprovalNumbers."));
				}
			}
		 
		      
			public DrugApprovalNumber[] SearchDrugApprovalNumbersByQueryModel(out String message,QueryDrugApprovalNumberModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDrugApprovalNumbersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDrugApprovalNumbersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDrugApprovalNumbersByQueryModel."));
				}
			}
		 
		      
			public DrugApprovalNumber[] SearchPagedDrugApprovalNumbersByQueryModel(out PagerInfo pager,QueryDrugApprovalNumberModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDrugApprovalNumbersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDrugApprovalNumbersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDrugApprovalNumbersByQueryModel."));
				}
			}
		 
		      
			public DrugCategory GetDrugCategory(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugCategory....."));
				try
				{ 
					return pharmacyServcie.GetDrugCategory(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugCategory."));
				}
			}
		 
		      
			public bool AddDrugCategory(out String msg,DrugCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDrugCategory....."));
				try
				{ 
					return pharmacyServcie.AddDrugCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDrugCategory."));
				}
			}
		 
		      
			public bool DeleteDrugCategory(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDrugCategory....."));
				try
				{ 
					return pharmacyServcie.DeleteDrugCategory(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDrugCategory."));
				}
			}
		 
		      
			public bool SaveDrugCategory(out String msg,DrugCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDrugCategory....."));
				try
				{ 
					return pharmacyServcie.SaveDrugCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDrugCategory."));
				}
			}
		 
		      
			public DrugCategory[] AllDrugCategorys(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDrugCategorys....."));
				try
				{ 
					return pharmacyServcie.AllDrugCategorys(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDrugCategorys."));
				}
			}
		 
		      
			public DrugCategory[] QueryDrugCategorys(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDrugCategorys....."));
				try
				{ 
					return pharmacyServcie.QueryDrugCategorys(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDrugCategorys."));
				}
			}
		 
		      
			public DrugCategory[] QueryPagedDrugCategorys(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDrugCategorys....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDrugCategorys(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDrugCategorys."));
				}
			}
		 
		      
			public DrugCategory[] SearchDrugCategorysByQueryModel(out String message,QueryDrugCategoryModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDrugCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDrugCategorysByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDrugCategorysByQueryModel."));
				}
			}
		 
		      
			public DrugCategory[] SearchPagedDrugCategorysByQueryModel(out PagerInfo pager,QueryDrugCategoryModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDrugCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDrugCategorysByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDrugCategorysByQueryModel."));
				}
			}
		 
		      
			public DrugClinicalCategory GetDrugClinicalCategory(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugClinicalCategory....."));
				try
				{ 
					return pharmacyServcie.GetDrugClinicalCategory(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugClinicalCategory."));
				}
			}
		 
		      
			public bool AddDrugClinicalCategory(out String msg,DrugClinicalCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDrugClinicalCategory....."));
				try
				{ 
					return pharmacyServcie.AddDrugClinicalCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDrugClinicalCategory."));
				}
			}
		 
		      
			public bool DeleteDrugClinicalCategory(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDrugClinicalCategory....."));
				try
				{ 
					return pharmacyServcie.DeleteDrugClinicalCategory(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDrugClinicalCategory."));
				}
			}
		 
		      
			public bool SaveDrugClinicalCategory(out String msg,DrugClinicalCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDrugClinicalCategory....."));
				try
				{ 
					return pharmacyServcie.SaveDrugClinicalCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDrugClinicalCategory."));
				}
			}
		 
		      
			public DrugClinicalCategory[] AllDrugClinicalCategorys(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDrugClinicalCategorys....."));
				try
				{ 
					return pharmacyServcie.AllDrugClinicalCategorys(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDrugClinicalCategorys."));
				}
			}
		 
		      
			public DrugClinicalCategory[] QueryDrugClinicalCategorys(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDrugClinicalCategorys....."));
				try
				{ 
					return pharmacyServcie.QueryDrugClinicalCategorys(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDrugClinicalCategorys."));
				}
			}
		 
		      
			public DrugClinicalCategory[] QueryPagedDrugClinicalCategorys(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDrugClinicalCategorys....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDrugClinicalCategorys(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDrugClinicalCategorys."));
				}
			}
		 
		      
			public DrugClinicalCategory[] SearchDrugClinicalCategorysByQueryModel(out String message,QueryDrugClinicalCategoryModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDrugClinicalCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDrugClinicalCategorysByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDrugClinicalCategorysByQueryModel."));
				}
			}
		 
		      
			public DrugClinicalCategory[] SearchPagedDrugClinicalCategorysByQueryModel(out PagerInfo pager,QueryDrugClinicalCategoryModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDrugClinicalCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDrugClinicalCategorysByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDrugClinicalCategorysByQueryModel."));
				}
			}
		 
		      
			public DictionaryDosage GetDictionaryDosage(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDictionaryDosage....."));
				try
				{ 
					return pharmacyServcie.GetDictionaryDosage(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDictionaryDosage."));
				}
			}
		 
		      
			public bool AddDictionaryDosage(out String msg,DictionaryDosage value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDictionaryDosage....."));
				try
				{ 
					return pharmacyServcie.AddDictionaryDosage(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDictionaryDosage."));
				}
			}
		 
		      
			public User[] GetAllUsers(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetAllUsers....."));
				try
				{ 
					return pharmacyServcie.GetAllUsers(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetAllUsers."));
				}
			}
		 
		      
			public User[] GetUserInfo(out String message,String Account)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetUserInfo....."));
				try
				{ 
					return pharmacyServcie.GetUserInfo(out message,Account);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetUserInfo."));
				}
			}
		 
		      
			public User UserLogon(out String message,String account,String pwd)
			{
			    //Log.Warning(string.Format("开始调用服务方法:UserLogon....."));
				try
				{ 
					return pharmacyServcie.UserLogon(out message,account,pwd);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:UserLogon."));
				}
			}
		 
		      
			public String UserLogout(out String message,Guid userId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:UserLogout....."));
				try
				{ 
					return pharmacyServcie.UserLogout(out message,userId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:UserLogout."));
				}
			}
		 
		      
			public Employee GetEmployeeByUserId(out String message,Guid userId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetEmployeeByUserId....."));
				try
				{ 
					return pharmacyServcie.GetEmployeeByUserId(out message,userId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetEmployeeByUserId."));
				}
			}
		 
		      
			public String LogUserLog(UserLog log)
			{
			    //Log.Warning(string.Format("开始调用服务方法:LogUserLog....."));
				try
				{ 
					return pharmacyServcie.LogUserLog(log);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:LogUserLog."));
				}
			}
		 
		      
			public ApprovalFlow GetApprovalFlow(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApprovalFlow....."));
				try
				{ 
					return pharmacyServcie.GetApprovalFlow(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApprovalFlow."));
				}
			}
		 
		      
			public bool AddApprovalFlow(out String msg,ApprovalFlow value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddApprovalFlow....."));
				try
				{ 
					return pharmacyServcie.AddApprovalFlow(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddApprovalFlow."));
				}
			}
		 
		      
			public bool DeleteApprovalFlow(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteApprovalFlow....."));
				try
				{ 
					return pharmacyServcie.DeleteApprovalFlow(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteApprovalFlow."));
				}
			}
		 
		      
			public bool SaveApprovalFlow(out String msg,ApprovalFlow value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveApprovalFlow....."));
				try
				{ 
					return pharmacyServcie.SaveApprovalFlow(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveApprovalFlow."));
				}
			}
		 
		      
			public ApprovalFlow[] AllApprovalFlows(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllApprovalFlows....."));
				try
				{ 
					return pharmacyServcie.AllApprovalFlows(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllApprovalFlows."));
				}
			}
		 
		      
			public ApprovalFlow[] QueryApprovalFlows(out String msg,int statusfrom,int statusto,String changenote,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryApprovalFlows....."));
				try
				{ 
					return pharmacyServcie.QueryApprovalFlows(out msg,statusfrom,statusto,changenote,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryApprovalFlows."));
				}
			}
		 
		      
			public ApprovalFlow[] QueryPagedApprovalFlows(out PagerInfo pager,int statusfrom,int statusto,String changenote,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedApprovalFlows....."));
				try
				{ 
					return pharmacyServcie.QueryPagedApprovalFlows(out pager,statusfrom,statusto,changenote,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedApprovalFlows."));
				}
			}
		 
		      
			public ApprovalFlow[] SearchApprovalFlowsByQueryModel(out String message,QueryApprovalFlowModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchApprovalFlowsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchApprovalFlowsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchApprovalFlowsByQueryModel."));
				}
			}
		 
		      
			public ApprovalFlow[] SearchPagedApprovalFlowsByQueryModel(out PagerInfo pager,QueryApprovalFlowModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedApprovalFlowsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedApprovalFlowsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedApprovalFlowsByQueryModel."));
				}
			}
		 
		      
			public ApprovalFlowNode GetApprovalFlowNode(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApprovalFlowNode....."));
				try
				{ 
					return pharmacyServcie.GetApprovalFlowNode(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApprovalFlowNode."));
				}
			}
		 
		      
			public bool AddApprovalFlowNode(out String msg,ApprovalFlowNode value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddApprovalFlowNode....."));
				try
				{ 
					return pharmacyServcie.AddApprovalFlowNode(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddApprovalFlowNode."));
				}
			}
		 
		      
			public bool DeleteApprovalFlowNode(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteApprovalFlowNode....."));
				try
				{ 
					return pharmacyServcie.DeleteApprovalFlowNode(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteApprovalFlowNode."));
				}
			}
		 
		      
			public bool SaveApprovalFlowNode(out String msg,ApprovalFlowNode value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveApprovalFlowNode....."));
				try
				{ 
					return pharmacyServcie.SaveApprovalFlowNode(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveApprovalFlowNode."));
				}
			}
		 
		      
			public ApprovalFlowNode[] AllApprovalFlowNodes(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllApprovalFlowNodes....."));
				try
				{ 
					return pharmacyServcie.AllApprovalFlowNodes(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllApprovalFlowNodes."));
				}
			}
		 
		      
			public ApprovalFlowNode[] QueryApprovalFlowNodes(out String msg,int orderfrom,int orderto,String name,String decription,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryApprovalFlowNodes....."));
				try
				{ 
					return pharmacyServcie.QueryApprovalFlowNodes(out msg,orderfrom,orderto,name,decription,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryApprovalFlowNodes."));
				}
			}
		 
		      
			public ApprovalFlowNode[] QueryPagedApprovalFlowNodes(out PagerInfo pager,int orderfrom,int orderto,String name,String decription,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedApprovalFlowNodes....."));
				try
				{ 
					return pharmacyServcie.QueryPagedApprovalFlowNodes(out pager,orderfrom,orderto,name,decription,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedApprovalFlowNodes."));
				}
			}
		 
		      
			public ApprovalFlowNode[] SearchApprovalFlowNodesByQueryModel(out String message,QueryApprovalFlowNodeModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchApprovalFlowNodesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchApprovalFlowNodesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchApprovalFlowNodesByQueryModel."));
				}
			}
		 
		      
			public ApprovalFlowNode[] SearchPagedApprovalFlowNodesByQueryModel(out PagerInfo pager,QueryApprovalFlowNodeModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedApprovalFlowNodesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedApprovalFlowNodesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedApprovalFlowNodesByQueryModel."));
				}
			}
		 
		      
			public ApprovalFlowType GetApprovalFlowType(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApprovalFlowType....."));
				try
				{ 
					return pharmacyServcie.GetApprovalFlowType(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApprovalFlowType."));
				}
			}
		 
		      
			public bool AddApprovalFlowType(out String msg,ApprovalFlowType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddApprovalFlowType....."));
				try
				{ 
					return pharmacyServcie.AddApprovalFlowType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddApprovalFlowType."));
				}
			}
		 
		      
			public bool DeleteApprovalFlowType(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteApprovalFlowType....."));
				try
				{ 
					return pharmacyServcie.DeleteApprovalFlowType(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteApprovalFlowType."));
				}
			}
		 
		      
			public bool SaveApprovalFlowType(out String msg,ApprovalFlowType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveApprovalFlowType....."));
				try
				{ 
					return pharmacyServcie.SaveApprovalFlowType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveApprovalFlowType."));
				}
			}
		 
		      
			public ApprovalFlowType[] AllApprovalFlowTypes(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllApprovalFlowTypes....."));
				try
				{ 
					return pharmacyServcie.AllApprovalFlowTypes(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllApprovalFlowTypes."));
				}
			}
		 
		      
			public ApprovalFlowType[] QueryApprovalFlowTypes(out String msg,String name,String decription,int approvaltypevaluefrom,int approvaltypevalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryApprovalFlowTypes....."));
				try
				{ 
					return pharmacyServcie.QueryApprovalFlowTypes(out msg,name,decription,approvaltypevaluefrom,approvaltypevalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryApprovalFlowTypes."));
				}
			}
		 
		      
			public ApprovalFlowType[] QueryPagedApprovalFlowTypes(out PagerInfo pager,String name,String decription,int approvaltypevaluefrom,int approvaltypevalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedApprovalFlowTypes....."));
				try
				{ 
					return pharmacyServcie.QueryPagedApprovalFlowTypes(out pager,name,decription,approvaltypevaluefrom,approvaltypevalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedApprovalFlowTypes."));
				}
			}
		 
		      
			public ApprovalFlowType[] SearchApprovalFlowTypesByQueryModel(out String message,QueryApprovalFlowTypeModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchApprovalFlowTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchApprovalFlowTypesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchApprovalFlowTypesByQueryModel."));
				}
			}
		 
		      
			public ApprovalFlowType[] SearchPagedApprovalFlowTypesByQueryModel(out PagerInfo pager,QueryApprovalFlowTypeModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedApprovalFlowTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedApprovalFlowTypesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedApprovalFlowTypesByQueryModel."));
				}
			}
		 
		      
			public ApprovalFlowRecord GetApprovalFlowRecord(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetApprovalFlowRecord....."));
				try
				{ 
					return pharmacyServcie.GetApprovalFlowRecord(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetApprovalFlowRecord."));
				}
			}
		 
		      
			public bool AddApprovalFlowRecord(out String msg,ApprovalFlowRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddApprovalFlowRecord....."));
				try
				{ 
					return pharmacyServcie.AddApprovalFlowRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddApprovalFlowRecord."));
				}
			}
		 
		      
			public bool DeleteApprovalFlowRecord(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteApprovalFlowRecord....."));
				try
				{ 
					return pharmacyServcie.DeleteApprovalFlowRecord(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteApprovalFlowRecord."));
				}
			}
		 
		      
			public bool SaveApprovalFlowRecord(out String msg,ApprovalFlowRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveApprovalFlowRecord....."));
				try
				{ 
					return pharmacyServcie.SaveApprovalFlowRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveApprovalFlowRecord."));
				}
			}
		 
		      
			public ApprovalFlowRecord[] AllApprovalFlowRecords(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllApprovalFlowRecords....."));
				try
				{ 
					return pharmacyServcie.AllApprovalFlowRecords(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllApprovalFlowRecords."));
				}
			}
		 
		      
			public ApprovalFlowRecord[] QueryApprovalFlowRecords(out String msg,DateTime approvetimefrom,DateTime approvetimeto,String comment,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryApprovalFlowRecords....."));
				try
				{ 
					return pharmacyServcie.QueryApprovalFlowRecords(out msg,approvetimefrom,approvetimeto,comment,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryApprovalFlowRecords."));
				}
			}
		 
		      
			public ApprovalFlowRecord[] QueryPagedApprovalFlowRecords(out PagerInfo pager,DateTime approvetimefrom,DateTime approvetimeto,String comment,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedApprovalFlowRecords....."));
				try
				{ 
					return pharmacyServcie.QueryPagedApprovalFlowRecords(out pager,approvetimefrom,approvetimeto,comment,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedApprovalFlowRecords."));
				}
			}
		 
		      
			public ApprovalFlowRecord[] SearchApprovalFlowRecordsByQueryModel(out String message,QueryApprovalFlowRecordModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchApprovalFlowRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchApprovalFlowRecordsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchApprovalFlowRecordsByQueryModel."));
				}
			}
		 
		      
			public ApprovalFlowRecord[] SearchPagedApprovalFlowRecordsByQueryModel(out PagerInfo pager,QueryApprovalFlowRecordModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedApprovalFlowRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedApprovalFlowRecordsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedApprovalFlowRecordsByQueryModel."));
				}
			}
		 
		      
			public BillDocumentCode GetBillDocumentCode(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetBillDocumentCode....."));
				try
				{ 
					return pharmacyServcie.GetBillDocumentCode(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetBillDocumentCode."));
				}
			}
		 
		      
			public bool AddBillDocumentCode(out String msg,BillDocumentCode value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddBillDocumentCode....."));
				try
				{ 
					return pharmacyServcie.AddBillDocumentCode(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddBillDocumentCode."));
				}
			}
		 
		      
			public bool DeleteBillDocumentCode(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteBillDocumentCode....."));
				try
				{ 
					return pharmacyServcie.DeleteBillDocumentCode(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteBillDocumentCode."));
				}
			}
		 
		      
			public bool SaveBillDocumentCode(out String msg,BillDocumentCode value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveBillDocumentCode....."));
				try
				{ 
					return pharmacyServcie.SaveBillDocumentCode(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveBillDocumentCode."));
				}
			}
		 
		      
			public BillDocumentCode[] AllBillDocumentCodes(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllBillDocumentCodes....."));
				try
				{ 
					return pharmacyServcie.AllBillDocumentCodes(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllBillDocumentCodes."));
				}
			}
		 
		      
			public BillDocumentCode[] QueryBillDocumentCodes(out String msg,bool locked,bool querylocked,bool used,bool queryused,bool canceled,bool querycanceled,String code,int billdocumenttypevaluefrom,int billdocumenttypevalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryBillDocumentCodes....."));
				try
				{ 
					return pharmacyServcie.QueryBillDocumentCodes(out msg,locked,querylocked,used,queryused,canceled,querycanceled,code,billdocumenttypevaluefrom,billdocumenttypevalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryBillDocumentCodes."));
				}
			}
		 
		      
			public BillDocumentCode[] QueryPagedBillDocumentCodes(out PagerInfo pager,bool locked,bool querylocked,bool used,bool queryused,bool canceled,bool querycanceled,String code,int billdocumenttypevaluefrom,int billdocumenttypevalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedBillDocumentCodes....."));
				try
				{ 
					return pharmacyServcie.QueryPagedBillDocumentCodes(out pager,locked,querylocked,used,queryused,canceled,querycanceled,code,billdocumenttypevaluefrom,billdocumenttypevalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedBillDocumentCodes."));
				}
			}
		 
		      
			public BillDocumentCode[] SearchBillDocumentCodesByQueryModel(out String message,QueryBillDocumentCodeModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchBillDocumentCodesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchBillDocumentCodesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchBillDocumentCodesByQueryModel."));
				}
			}
		 
		      
			public BillDocumentCode[] SearchPagedBillDocumentCodesByQueryModel(out PagerInfo pager,QueryBillDocumentCodeModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedBillDocumentCodesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedBillDocumentCodesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedBillDocumentCodesByQueryModel."));
				}
			}
		 
		      
			public BusinessScope GetBusinessScope(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetBusinessScope....."));
				try
				{ 
					return pharmacyServcie.GetBusinessScope(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetBusinessScope."));
				}
			}
		 
		      
			public bool AddBusinessScope(out String msg,BusinessScope value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddBusinessScope....."));
				try
				{ 
					return pharmacyServcie.AddBusinessScope(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddBusinessScope."));
				}
			}
		 
		      
			public bool AddDictionaryPiecemealUnit(out String msg,DictionaryPiecemealUnit value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDictionaryPiecemealUnit....."));
				try
				{ 
					return pharmacyServcie.AddDictionaryPiecemealUnit(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDictionaryPiecemealUnit."));
				}
			}
		 
		      
			public bool DeleteDictionaryPiecemealUnit(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDictionaryPiecemealUnit....."));
				try
				{ 
					return pharmacyServcie.DeleteDictionaryPiecemealUnit(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDictionaryPiecemealUnit."));
				}
			}
		 
		      
			public bool SaveDictionaryPiecemealUnit(out String msg,DictionaryPiecemealUnit value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDictionaryPiecemealUnit....."));
				try
				{ 
					return pharmacyServcie.SaveDictionaryPiecemealUnit(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDictionaryPiecemealUnit."));
				}
			}
		 
		      
			public DictionaryPiecemealUnit[] AllDictionaryPiecemealUnits(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDictionaryPiecemealUnits....."));
				try
				{ 
					return pharmacyServcie.AllDictionaryPiecemealUnits(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDictionaryPiecemealUnits."));
				}
			}
		 
		      
			public DictionaryPiecemealUnit[] QueryDictionaryPiecemealUnits(out String msg,String name,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDictionaryPiecemealUnits....."));
				try
				{ 
					return pharmacyServcie.QueryDictionaryPiecemealUnits(out msg,name,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDictionaryPiecemealUnits."));
				}
			}
		 
		      
			public DictionaryPiecemealUnit[] QueryPagedDictionaryPiecemealUnits(out PagerInfo pager,String name,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDictionaryPiecemealUnits....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDictionaryPiecemealUnits(out pager,name,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDictionaryPiecemealUnits."));
				}
			}
		 
		      
			public DictionaryPiecemealUnit[] SearchDictionaryPiecemealUnitsByQueryModel(out String message,QueryDictionaryPiecemealUnitModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDictionaryPiecemealUnitsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDictionaryPiecemealUnitsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDictionaryPiecemealUnitsByQueryModel."));
				}
			}
		 
		      
			public DictionaryPiecemealUnit[] SearchPagedDictionaryPiecemealUnitsByQueryModel(out PagerInfo pager,QueryDictionaryPiecemealUnitModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDictionaryPiecemealUnitsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDictionaryPiecemealUnitsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDictionaryPiecemealUnitsByQueryModel."));
				}
			}
		 
		      
			public DictionarySpecification GetDictionarySpecification(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDictionarySpecification....."));
				try
				{ 
					return pharmacyServcie.GetDictionarySpecification(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDictionarySpecification."));
				}
			}
		 
		      
			public bool AddDictionarySpecification(out String msg,DictionarySpecification value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDictionarySpecification....."));
				try
				{ 
					return pharmacyServcie.AddDictionarySpecification(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDictionarySpecification."));
				}
			}
		 
		      
			public bool DeleteDictionarySpecification(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDictionarySpecification....."));
				try
				{ 
					return pharmacyServcie.DeleteDictionarySpecification(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDictionarySpecification."));
				}
			}
		 
		      
			public bool SaveDictionarySpecification(out String msg,DictionarySpecification value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDictionarySpecification....."));
				try
				{ 
					return pharmacyServcie.SaveDictionarySpecification(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDictionarySpecification."));
				}
			}
		 
		      
			public DictionarySpecification[] AllDictionarySpecifications(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDictionarySpecifications....."));
				try
				{ 
					return pharmacyServcie.AllDictionarySpecifications(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDictionarySpecifications."));
				}
			}
		 
		      
			public DictionarySpecification[] QueryDictionarySpecifications(out String msg,String name,String code)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDictionarySpecifications....."));
				try
				{ 
					return pharmacyServcie.QueryDictionarySpecifications(out msg,name,code);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDictionarySpecifications."));
				}
			}
		 
		      
			public DictionarySpecification[] QueryPagedDictionarySpecifications(out PagerInfo pager,String name,String code,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDictionarySpecifications....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDictionarySpecifications(out pager,name,code,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDictionarySpecifications."));
				}
			}
		 
		      
			public DictionarySpecification[] SearchDictionarySpecificationsByQueryModel(out String message,QueryDictionarySpecificationModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDictionarySpecificationsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDictionarySpecificationsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDictionarySpecificationsByQueryModel."));
				}
			}
		 
		      
			public DictionarySpecification[] SearchPagedDictionarySpecificationsByQueryModel(out PagerInfo pager,QueryDictionarySpecificationModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDictionarySpecificationsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDictionarySpecificationsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDictionarySpecificationsByQueryModel."));
				}
			}
		 
		      
			public DictionaryStorageType GetDictionaryStorageType(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDictionaryStorageType....."));
				try
				{ 
					return pharmacyServcie.GetDictionaryStorageType(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDictionaryStorageType."));
				}
			}
		 
		      
			public bool AddDictionaryStorageType(out String msg,DictionaryStorageType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDictionaryStorageType....."));
				try
				{ 
					return pharmacyServcie.AddDictionaryStorageType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDictionaryStorageType."));
				}
			}
		 
		      
			public bool DeleteDictionaryStorageType(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDictionaryStorageType....."));
				try
				{ 
					return pharmacyServcie.DeleteDictionaryStorageType(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDictionaryStorageType."));
				}
			}
		 
		      
			public bool SaveDictionaryStorageType(out String msg,DictionaryStorageType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDictionaryStorageType....."));
				try
				{ 
					return pharmacyServcie.SaveDictionaryStorageType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDictionaryStorageType."));
				}
			}
		 
		      
			public DictionaryStorageType[] AllDictionaryStorageTypes(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDictionaryStorageTypes....."));
				try
				{ 
					return pharmacyServcie.AllDictionaryStorageTypes(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDictionaryStorageTypes."));
				}
			}
		 
		      
			public DictionaryStorageType[] QueryDictionaryStorageTypes(out String msg,String name,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDictionaryStorageTypes....."));
				try
				{ 
					return pharmacyServcie.QueryDictionaryStorageTypes(out msg,name,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDictionaryStorageTypes."));
				}
			}
		 
		      
			public DictionaryStorageType[] QueryPagedDictionaryStorageTypes(out PagerInfo pager,String name,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDictionaryStorageTypes....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDictionaryStorageTypes(out pager,name,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDictionaryStorageTypes."));
				}
			}
		 
		      
			public DictionaryStorageType[] SearchDictionaryStorageTypesByQueryModel(out String message,QueryDictionaryStorageTypeModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDictionaryStorageTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDictionaryStorageTypesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDictionaryStorageTypesByQueryModel."));
				}
			}
		 
		      
			public DictionaryStorageType[] SearchPagedDictionaryStorageTypesByQueryModel(out PagerInfo pager,QueryDictionaryStorageTypeModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDictionaryStorageTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDictionaryStorageTypesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDictionaryStorageTypesByQueryModel."));
				}
			}
		 
		      
			public DictionaryUserDefinedType GetDictionaryUserDefinedType(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDictionaryUserDefinedType....."));
				try
				{ 
					return pharmacyServcie.GetDictionaryUserDefinedType(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDictionaryUserDefinedType."));
				}
			}
		 
		      
			public bool AddDictionaryUserDefinedType(out String msg,DictionaryUserDefinedType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDictionaryUserDefinedType....."));
				try
				{ 
					return pharmacyServcie.AddDictionaryUserDefinedType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDictionaryUserDefinedType."));
				}
			}
		 
		      
			public bool DeleteDictionaryUserDefinedType(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDictionaryUserDefinedType....."));
				try
				{ 
					return pharmacyServcie.DeleteDictionaryUserDefinedType(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDictionaryUserDefinedType."));
				}
			}
		 
		      
			public bool SaveDictionaryUserDefinedType(out String msg,DictionaryUserDefinedType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDictionaryUserDefinedType....."));
				try
				{ 
					return pharmacyServcie.SaveDictionaryUserDefinedType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDictionaryUserDefinedType."));
				}
			}
		 
		      
			public DictionaryUserDefinedType[] AllDictionaryUserDefinedTypes(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDictionaryUserDefinedTypes....."));
				try
				{ 
					return pharmacyServcie.AllDictionaryUserDefinedTypes(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDictionaryUserDefinedTypes."));
				}
			}
		 
		      
			public DictionaryUserDefinedType[] QueryDictionaryUserDefinedTypes(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDictionaryUserDefinedTypes....."));
				try
				{ 
					return pharmacyServcie.QueryDictionaryUserDefinedTypes(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDictionaryUserDefinedTypes."));
				}
			}
		 
		      
			public BusinessTypeManageCategoryDetail[] SearchBusinessTypeManageCategoryDetailsByQueryModel(out String message,QueryBusinessTypeManageCategoryDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchBusinessTypeManageCategoryDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchBusinessTypeManageCategoryDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchBusinessTypeManageCategoryDetailsByQueryModel."));
				}
			}
		 
		      
			public BusinessTypeManageCategoryDetail[] SearchPagedBusinessTypeManageCategoryDetailsByQueryModel(out PagerInfo pager,QueryBusinessTypeManageCategoryDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedBusinessTypeManageCategoryDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedBusinessTypeManageCategoryDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedBusinessTypeManageCategoryDetailsByQueryModel."));
				}
			}
		 
		      
			public GoodsAdditionalProperty GetGoodsAdditionalProperty(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetGoodsAdditionalProperty....."));
				try
				{ 
					return pharmacyServcie.GetGoodsAdditionalProperty(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetGoodsAdditionalProperty."));
				}
			}
		 
		      
			public bool AddGoodsAdditionalProperty(out String msg,GoodsAdditionalProperty value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddGoodsAdditionalProperty....."));
				try
				{ 
					return pharmacyServcie.AddGoodsAdditionalProperty(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddGoodsAdditionalProperty."));
				}
			}
		 
		      
			public bool DeleteGoodsAdditionalProperty(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteGoodsAdditionalProperty....."));
				try
				{ 
					return pharmacyServcie.DeleteGoodsAdditionalProperty(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteGoodsAdditionalProperty."));
				}
			}
		 
		      
			public bool SaveGoodsAdditionalProperty(out String msg,GoodsAdditionalProperty value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveGoodsAdditionalProperty....."));
				try
				{ 
					return pharmacyServcie.SaveGoodsAdditionalProperty(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveGoodsAdditionalProperty."));
				}
			}
		 
		      
			public GoodsAdditionalProperty[] AllGoodsAdditionalPropertys(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllGoodsAdditionalPropertys....."));
				try
				{ 
					return pharmacyServcie.AllGoodsAdditionalPropertys(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllGoodsAdditionalPropertys."));
				}
			}
		 
		      
			public GoodsAdditionalProperty[] QueryGoodsAdditionalPropertys(out String msg,String carefunction,String putonrecord,DateTime putonrecorddatefrom,DateTime putonrecorddateto,String notsuitablepeople,String suitablepeople,String landmarkingredient,DateTime licensepermissiondatefrom,DateTime licensepermissiondateto,String usageanddosage,String mainingredient,String productaddress,String productaddressenglish,String productcountry,String productcountryenglish,String healthpermit,String regcode,String regproxycompany,String factorynameenglish,String factoryaddress,String factoryaddressenglish)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryGoodsAdditionalPropertys....."));
				try
				{ 
					return pharmacyServcie.QueryGoodsAdditionalPropertys(out msg,carefunction,putonrecord,putonrecorddatefrom,putonrecorddateto,notsuitablepeople,suitablepeople,landmarkingredient,licensepermissiondatefrom,licensepermissiondateto,usageanddosage,mainingredient,productaddress,productaddressenglish,productcountry,productcountryenglish,healthpermit,regcode,regproxycompany,factorynameenglish,factoryaddress,factoryaddressenglish);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryGoodsAdditionalPropertys."));
				}
			}
		 
		      
			public GoodsAdditionalProperty[] QueryPagedGoodsAdditionalPropertys(out PagerInfo pager,String carefunction,String putonrecord,DateTime putonrecorddatefrom,DateTime putonrecorddateto,String notsuitablepeople,String suitablepeople,String landmarkingredient,DateTime licensepermissiondatefrom,DateTime licensepermissiondateto,String usageanddosage,String mainingredient,String productaddress,String productaddressenglish,String productcountry,String productcountryenglish,String healthpermit,String regcode,String regproxycompany,String factorynameenglish,String factoryaddress,String factoryaddressenglish,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedGoodsAdditionalPropertys....."));
				try
				{ 
					return pharmacyServcie.QueryPagedGoodsAdditionalPropertys(out pager,carefunction,putonrecord,putonrecorddatefrom,putonrecorddateto,notsuitablepeople,suitablepeople,landmarkingredient,licensepermissiondatefrom,licensepermissiondateto,usageanddosage,mainingredient,productaddress,productaddressenglish,productcountry,productcountryenglish,healthpermit,regcode,regproxycompany,factorynameenglish,factoryaddress,factoryaddressenglish,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedGoodsAdditionalPropertys."));
				}
			}
		 
		      
			public GoodsAdditionalProperty[] SearchGoodsAdditionalPropertysByQueryModel(out String message,QueryGoodsAdditionalPropertyModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchGoodsAdditionalPropertysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchGoodsAdditionalPropertysByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchGoodsAdditionalPropertysByQueryModel."));
				}
			}
		 
		      
			public GoodsAdditionalProperty[] SearchPagedGoodsAdditionalPropertysByQueryModel(out PagerInfo pager,QueryGoodsAdditionalPropertyModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedGoodsAdditionalPropertysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedGoodsAdditionalPropertysByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedGoodsAdditionalPropertysByQueryModel."));
				}
			}
		 
		      
			public PurchaseCashOrder GetPurchaseCashOrder(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseCashOrder....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseCashOrder(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseCashOrder."));
				}
			}
		 
		      
			public bool AddPurchaseCashOrder(out String msg,PurchaseCashOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseCashOrder....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseCashOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseCashOrder."));
				}
			}
		 
		      
			public bool DeletePurchaseCashOrder(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseCashOrder....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseCashOrder(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseCashOrder."));
				}
			}
		 
		      
			public bool SavePurchaseCashOrder(out String msg,PurchaseCashOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseCashOrder....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseCashOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseCashOrder."));
				}
			}
		 
		      
			public PurchaseCashOrder[] AllPurchaseCashOrders(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseCashOrders....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseCashOrders(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseCashOrders."));
				}
			}
		 
		      
			public PurchaseCashOrder[] QueryPurchaseCashOrders(out String msg,String documentnumber,DateTime operatetimefrom,DateTime operatetimeto,int orderstatusvaluefrom,int orderstatusvalueto,String approvaldecription,DateTime paymenttimefrom,DateTime paymenttimeto,decimal paymentedamountfrom,decimal paymentedamountto,decimal paymentingamountfrom,decimal paymentingamountto,decimal paymentamountfrom,decimal paymentamountto,int dealermethodvaluefrom,int dealermethodvalueto,String decription,String relatedorderdocumentnumber,int relatedordertypevaluefrom,int relatedordertypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseCashOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseCashOrders(out msg,documentnumber,operatetimefrom,operatetimeto,orderstatusvaluefrom,orderstatusvalueto,approvaldecription,paymenttimefrom,paymenttimeto,paymentedamountfrom,paymentedamountto,paymentingamountfrom,paymentingamountto,paymentamountfrom,paymentamountto,dealermethodvaluefrom,dealermethodvalueto,decription,relatedorderdocumentnumber,relatedordertypevaluefrom,relatedordertypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseCashOrders."));
				}
			}
		 
		      
			public PurchaseCashOrder[] QueryPagedPurchaseCashOrders(out PagerInfo pager,String documentnumber,DateTime operatetimefrom,DateTime operatetimeto,int orderstatusvaluefrom,int orderstatusvalueto,String approvaldecription,DateTime paymenttimefrom,DateTime paymenttimeto,decimal paymentedamountfrom,decimal paymentedamountto,decimal paymentingamountfrom,decimal paymentingamountto,decimal paymentamountfrom,decimal paymentamountto,int dealermethodvaluefrom,int dealermethodvalueto,String decription,String relatedorderdocumentnumber,int relatedordertypevaluefrom,int relatedordertypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseCashOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseCashOrders(out pager,documentnumber,operatetimefrom,operatetimeto,orderstatusvaluefrom,orderstatusvalueto,approvaldecription,paymenttimefrom,paymenttimeto,paymentedamountfrom,paymentedamountto,paymentingamountfrom,paymentingamountto,paymentamountfrom,paymentamountto,dealermethodvaluefrom,dealermethodvalueto,decription,relatedorderdocumentnumber,relatedordertypevaluefrom,relatedordertypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseCashOrders."));
				}
			}
		 
		      
			public PurchaseCashOrder[] SearchPurchaseCashOrdersByQueryModel(out String message,QueryPurchaseCashOrderModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseCashOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseCashOrdersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseCashOrdersByQueryModel."));
				}
			}
		 
		      
			public PurchaseCashOrder[] SearchPagedPurchaseCashOrdersByQueryModel(out PagerInfo pager,QueryPurchaseCashOrderModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseCashOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseCashOrdersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseCashOrdersByQueryModel."));
				}
			}
		 
		      
			public Delivery GetDelivery(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDelivery....."));
				try
				{ 
					return pharmacyServcie.GetDelivery(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDelivery."));
				}
			}
		 
		      
			public bool AddDelivery(out String msg,Delivery value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDelivery....."));
				try
				{ 
					return pharmacyServcie.AddDelivery(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDelivery."));
				}
			}
		 
		      
			public bool DeleteDelivery(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDelivery....."));
				try
				{ 
					return pharmacyServcie.DeleteDelivery(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDelivery."));
				}
			}
		 
		      
			public bool SaveDelivery(out String msg,Delivery value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDelivery....."));
				try
				{ 
					return pharmacyServcie.SaveDelivery(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDelivery."));
				}
			}
		 
		      
			public Delivery[] AllDeliverys(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDeliverys....."));
				try
				{ 
					return pharmacyServcie.AllDeliverys(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDeliverys."));
				}
			}
		 
		      
			public Delivery[] QueryDeliverys(out String msg,DateTime deliverytimefrom,DateTime deliverytimeto,String shippingaddress,String deliveryaddress,String manifestnumber,int drugscountfrom,int drugscountto,int deliverymethodvaluefrom,int deliverymethodvalueto,int transportmethodvaluefrom,int transportmethodvalueto,String principal,String principalphone,String transportcompany,String vehicleinfo,int deliverystatusvaluefrom,int deliverystatusvalueto,String memo,bool isover,bool queryisover,DateTime reservationtimefrom,DateTime reservationtimeto,String reservationno,DateTime acceptedtimefrom,DateTime acceptedtimeto,String acceptedno,DateTime canceledtimefrom,DateTime canceledtimeto,String canceledno,DateTime outedtimefrom,DateTime outedtimeto,String outedno,DateTime signedtimefrom,DateTime signedtimeto,String signedno,DateTime returntimefrom,DateTime returntimeto,String returnno,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDeliverys....."));
				try
				{ 
					return pharmacyServcie.QueryDeliverys(out msg,deliverytimefrom,deliverytimeto,shippingaddress,deliveryaddress,manifestnumber,drugscountfrom,drugscountto,deliverymethodvaluefrom,deliverymethodvalueto,transportmethodvaluefrom,transportmethodvalueto,principal,principalphone,transportcompany,vehicleinfo,deliverystatusvaluefrom,deliverystatusvalueto,memo,isover,queryisover,reservationtimefrom,reservationtimeto,reservationno,acceptedtimefrom,acceptedtimeto,acceptedno,canceledtimefrom,canceledtimeto,canceledno,outedtimefrom,outedtimeto,outedno,signedtimefrom,signedtimeto,signedno,returntimefrom,returntimeto,returnno,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDeliverys."));
				}
			}
		 
		      
			public Delivery[] QueryPagedDeliverys(out PagerInfo pager,DateTime deliverytimefrom,DateTime deliverytimeto,String shippingaddress,String deliveryaddress,String manifestnumber,int drugscountfrom,int drugscountto,int deliverymethodvaluefrom,int deliverymethodvalueto,int transportmethodvaluefrom,int transportmethodvalueto,String principal,String principalphone,String transportcompany,String vehicleinfo,int deliverystatusvaluefrom,int deliverystatusvalueto,String memo,bool isover,bool queryisover,DateTime reservationtimefrom,DateTime reservationtimeto,String reservationno,DateTime acceptedtimefrom,DateTime acceptedtimeto,String acceptedno,DateTime canceledtimefrom,DateTime canceledtimeto,String canceledno,DateTime outedtimefrom,DateTime outedtimeto,String outedno,DateTime signedtimefrom,DateTime signedtimeto,String signedno,DateTime returntimefrom,DateTime returntimeto,String returnno,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDeliverys....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDeliverys(out pager,deliverytimefrom,deliverytimeto,shippingaddress,deliveryaddress,manifestnumber,drugscountfrom,drugscountto,deliverymethodvaluefrom,deliverymethodvalueto,transportmethodvaluefrom,transportmethodvalueto,principal,principalphone,transportcompany,vehicleinfo,deliverystatusvaluefrom,deliverystatusvalueto,memo,isover,queryisover,reservationtimefrom,reservationtimeto,reservationno,acceptedtimefrom,acceptedtimeto,acceptedno,canceledtimefrom,canceledtimeto,canceledno,outedtimefrom,outedtimeto,outedno,signedtimefrom,signedtimeto,signedno,returntimefrom,returntimeto,returnno,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDeliverys."));
				}
			}
		 
		      
			public Delivery[] SearchDeliverysByQueryModel(out String message,QueryDeliveryModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDeliverysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDeliverysByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDeliverysByQueryModel."));
				}
			}
		 
		      
			public Delivery[] SearchPagedDeliverysByQueryModel(out PagerInfo pager,QueryDeliveryModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDeliverysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDeliverysByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDeliverysByQueryModel."));
				}
			}
		 
		      
			public Department GetDepartment(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDepartment....."));
				try
				{ 
					return pharmacyServcie.GetDepartment(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDepartment."));
				}
			}
		 
		      
			public bool AddDepartment(out String msg,Department value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDepartment....."));
				try
				{ 
					return pharmacyServcie.AddDepartment(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDepartment."));
				}
			}
		 
		      
			public bool DeleteDepartment(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDepartment....."));
				try
				{ 
					return pharmacyServcie.DeleteDepartment(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDepartment."));
				}
			}
		 
		      
			public bool SaveDepartment(out String msg,Department value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDepartment....."));
				try
				{ 
					return pharmacyServcie.SaveDepartment(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDepartment."));
				}
			}
		 
		      
			public Department[] AllDepartments(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDepartments....."));
				try
				{ 
					return pharmacyServcie.AllDepartments(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDepartments."));
				}
			}
		 
		      
			public Department[] QueryDepartments(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDepartments....."));
				try
				{ 
					return pharmacyServcie.QueryDepartments(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDepartments."));
				}
			}
		 
		      
			public Department[] QueryPagedDepartments(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDepartments....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDepartments(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDepartments."));
				}
			}
		 
		      
			public Department[] SearchDepartmentsByQueryModel(out String message,QueryDepartmentModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDepartmentsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDepartmentsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDepartmentsByQueryModel."));
				}
			}
		 
		      
			public Department[] SearchPagedDepartmentsByQueryModel(out PagerInfo pager,QueryDepartmentModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDepartmentsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDepartmentsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDepartmentsByQueryModel."));
				}
			}
		 
		      
			public District GetDistrict(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDistrict....."));
				try
				{ 
					return pharmacyServcie.GetDistrict(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDistrict."));
				}
			}
		 
		      
			public bool AddDistrict(out String msg,District value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDistrict....."));
				try
				{ 
					return pharmacyServcie.AddDistrict(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDistrict."));
				}
			}
		 
		      
			public bool DeleteDistrict(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDistrict....."));
				try
				{ 
					return pharmacyServcie.DeleteDistrict(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDistrict."));
				}
			}
		 
		      
			public bool SaveDistrict(out String msg,District value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDistrict....."));
				try
				{ 
					return pharmacyServcie.SaveDistrict(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDistrict."));
				}
			}
		 
		      
			public District[] AllDistricts(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDistricts....."));
				try
				{ 
					return pharmacyServcie.AllDistricts(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDistricts."));
				}
			}
		 
		      
			public District[] QueryDistricts(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDistricts....."));
				try
				{ 
					return pharmacyServcie.QueryDistricts(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDistricts."));
				}
			}
		 
		      
			public District[] QueryPagedDistricts(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDistricts....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDistricts(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDistricts."));
				}
			}
		 
		      
			public District[] SearchDistrictsByQueryModel(out String message,QueryDistrictModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDistrictsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDistrictsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDistrictsByQueryModel."));
				}
			}
		 
		      
			public District[] SearchPagedDistrictsByQueryModel(out PagerInfo pager,QueryDistrictModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDistrictsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDistrictsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDistrictsByQueryModel."));
				}
			}
		 
		      
			public DoubtDrug GetDoubtDrug(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDoubtDrug....."));
				try
				{ 
					return pharmacyServcie.GetDoubtDrug(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDoubtDrug."));
				}
			}
		 
		      
			public bool AddDoubtDrug(out String msg,DoubtDrug value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDoubtDrug....."));
				try
				{ 
					return pharmacyServcie.AddDoubtDrug(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDoubtDrug."));
				}
			}
		 
		      
			public bool DeleteDoubtDrug(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDoubtDrug....."));
				try
				{ 
					return pharmacyServcie.DeleteDoubtDrug(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDoubtDrug."));
				}
			}
		 
		      
			public bool SaveDoubtDrug(out String msg,DoubtDrug value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDoubtDrug....."));
				try
				{ 
					return pharmacyServcie.SaveDoubtDrug(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDoubtDrug."));
				}
			}
		 
		      
			public DoubtDrug[] AllDoubtDrugs(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDoubtDrugs....."));
				try
				{ 
					return pharmacyServcie.AllDoubtDrugs(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDoubtDrugs."));
				}
			}
		 
		      
			public DoubtDrug[] QueryDoubtDrugs(out String msg,String jsondruginventoryrecord,String decription,bool handled,bool queryhandled,String handledecription,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDoubtDrugs....."));
				try
				{ 
					return pharmacyServcie.QueryDoubtDrugs(out msg,jsondruginventoryrecord,decription,handled,queryhandled,handledecription,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDoubtDrugs."));
				}
			}
		 
		      
			public Manufacturer[] QueryManufacturers(out String msg,String name,String shortpinyin,String decription,String code,bool enabled,bool queryenabled,String address,String tel,String contact)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryManufacturers....."));
				try
				{ 
					return pharmacyServcie.QueryManufacturers(out msg,name,shortpinyin,decription,code,enabled,queryenabled,address,tel,contact);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryManufacturers."));
				}
			}
		 
		      
			public Manufacturer[] QueryPagedManufacturers(out PagerInfo pager,String name,String shortpinyin,String decription,String code,bool enabled,bool queryenabled,String address,String tel,String contact,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedManufacturers....."));
				try
				{ 
					return pharmacyServcie.QueryPagedManufacturers(out pager,name,shortpinyin,decription,code,enabled,queryenabled,address,tel,contact,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedManufacturers."));
				}
			}
		 
		      
			public Manufacturer[] SearchManufacturersByQueryModel(out String message,QueryManufacturerModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchManufacturersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchManufacturersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchManufacturersByQueryModel."));
				}
			}
		 
		      
			public Manufacturer[] SearchPagedManufacturersByQueryModel(out PagerInfo pager,QueryManufacturerModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedManufacturersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedManufacturersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedManufacturersByQueryModel."));
				}
			}
		 
		      
			public PackagingMaterial GetPackagingMaterial(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPackagingMaterial....."));
				try
				{ 
					return pharmacyServcie.GetPackagingMaterial(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPackagingMaterial."));
				}
			}
		 
		      
			public bool AddPackagingMaterial(out String msg,PackagingMaterial value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPackagingMaterial....."));
				try
				{ 
					return pharmacyServcie.AddPackagingMaterial(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPackagingMaterial."));
				}
			}
		 
		      
			public bool DeletePackagingMaterial(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePackagingMaterial....."));
				try
				{ 
					return pharmacyServcie.DeletePackagingMaterial(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePackagingMaterial."));
				}
			}
		 
		      
			public bool SavePackagingMaterial(out String msg,PackagingMaterial value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePackagingMaterial....."));
				try
				{ 
					return pharmacyServcie.SavePackagingMaterial(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePackagingMaterial."));
				}
			}
		 
		      
			public PackagingMaterial[] AllPackagingMaterials(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPackagingMaterials....."));
				try
				{ 
					return pharmacyServcie.AllPackagingMaterials(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPackagingMaterials."));
				}
			}
		 
		      
			public PackagingMaterial[] QueryPackagingMaterials(out String msg,String name,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPackagingMaterials....."));
				try
				{ 
					return pharmacyServcie.QueryPackagingMaterials(out msg,name,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPackagingMaterials."));
				}
			}
		 
		      
			public PackagingMaterial[] QueryPagedPackagingMaterials(out PagerInfo pager,String name,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPackagingMaterials....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPackagingMaterials(out pager,name,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPackagingMaterials."));
				}
			}
		 
		      
			public PackagingMaterial[] SearchPackagingMaterialsByQueryModel(out String message,QueryPackagingMaterialModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPackagingMaterialsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPackagingMaterialsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPackagingMaterialsByQueryModel."));
				}
			}
		 
		      
			public PackagingMaterial[] SearchPagedPackagingMaterialsByQueryModel(out PagerInfo pager,QueryPackagingMaterialModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPackagingMaterialsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPackagingMaterialsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPackagingMaterialsByQueryModel."));
				}
			}
		 
		      
			public PackagingUnit GetPackagingUnit(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPackagingUnit....."));
				try
				{ 
					return pharmacyServcie.GetPackagingUnit(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPackagingUnit."));
				}
			}
		 
		      
			public bool AddPackagingUnit(out String msg,PackagingUnit value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPackagingUnit....."));
				try
				{ 
					return pharmacyServcie.AddPackagingUnit(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPackagingUnit."));
				}
			}
		 
		      
			public bool DeletePackagingUnit(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePackagingUnit....."));
				try
				{ 
					return pharmacyServcie.DeletePackagingUnit(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePackagingUnit."));
				}
			}
		 
		      
			public bool SavePackagingUnit(out String msg,PackagingUnit value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePackagingUnit....."));
				try
				{ 
					return pharmacyServcie.SavePackagingUnit(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePackagingUnit."));
				}
			}
		 
		      
			public PackagingUnit[] AllPackagingUnits(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPackagingUnits....."));
				try
				{ 
					return pharmacyServcie.AllPackagingUnits(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPackagingUnits."));
				}
			}
		 
		      
			public PackagingUnit[] QueryPackagingUnits(out String msg,String name,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPackagingUnits....."));
				try
				{ 
					return pharmacyServcie.QueryPackagingUnits(out msg,name,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPackagingUnits."));
				}
			}
		 
		      
			public PackagingUnit[] QueryPagedPackagingUnits(out PagerInfo pager,String name,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPackagingUnits....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPackagingUnits(out pager,name,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPackagingUnits."));
				}
			}
		 
		      
			public PackagingUnit[] SearchPackagingUnitsByQueryModel(out String message,QueryPackagingUnitModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPackagingUnitsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPackagingUnitsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPackagingUnitsByQueryModel."));
				}
			}
		 
		      
			public PackagingUnit[] SearchPagedPackagingUnitsByQueryModel(out PagerInfo pager,QueryPackagingUnitModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPackagingUnitsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPackagingUnitsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPackagingUnitsByQueryModel."));
				}
			}
		 
		      
			public PaymentMethod GetPaymentMethod(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPaymentMethod....."));
				try
				{ 
					return pharmacyServcie.GetPaymentMethod(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPaymentMethod."));
				}
			}
		 
		      
			public bool AddPaymentMethod(out String msg,PaymentMethod value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPaymentMethod....."));
				try
				{ 
					return pharmacyServcie.AddPaymentMethod(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPaymentMethod."));
				}
			}
		 
		      
			public bool DeletePaymentMethod(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePaymentMethod....."));
				try
				{ 
					return pharmacyServcie.DeletePaymentMethod(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePaymentMethod."));
				}
			}
		 
		      
			public bool SavePaymentMethod(out String msg,PaymentMethod value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePaymentMethod....."));
				try
				{ 
					return pharmacyServcie.SavePaymentMethod(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePaymentMethod."));
				}
			}
		 
		      
			public PaymentMethod[] AllPaymentMethods(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPaymentMethods....."));
				try
				{ 
					return pharmacyServcie.AllPaymentMethods(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPaymentMethods."));
				}
			}
		 
		      
			public PaymentMethod[] QueryPaymentMethods(out String msg,String name,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPaymentMethods....."));
				try
				{ 
					return pharmacyServcie.QueryPaymentMethods(out msg,name,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPaymentMethods."));
				}
			}
		 
		      
			public PaymentMethod[] QueryPagedPaymentMethods(out PagerInfo pager,String name,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPaymentMethods....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPaymentMethods(out pager,name,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPaymentMethods."));
				}
			}
		 
		      
			public PaymentMethod[] SearchPaymentMethodsByQueryModel(out String message,QueryPaymentMethodModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPaymentMethodsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPaymentMethodsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPaymentMethodsByQueryModel."));
				}
			}
		 
		      
			public PaymentMethod[] SearchPagedPaymentMethodsByQueryModel(out PagerInfo pager,QueryPaymentMethodModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPaymentMethodsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPaymentMethodsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPaymentMethodsByQueryModel."));
				}
			}
		 
		      
			public GSPLicense GetGSPLicense(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetGSPLicense....."));
				try
				{ 
					return pharmacyServcie.GetGSPLicense(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetGSPLicense."));
				}
			}
		 
		      
			public bool DeleteDictionaryDosage(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDictionaryDosage....."));
				try
				{ 
					return pharmacyServcie.DeleteDictionaryDosage(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDictionaryDosage."));
				}
			}
		 
		      
			public bool SaveDictionaryDosage(out String msg,DictionaryDosage value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDictionaryDosage....."));
				try
				{ 
					return pharmacyServcie.SaveDictionaryDosage(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDictionaryDosage."));
				}
			}
		 
		      
			public DictionaryDosage[] AllDictionaryDosages(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDictionaryDosages....."));
				try
				{ 
					return pharmacyServcie.AllDictionaryDosages(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDictionaryDosages."));
				}
			}
		 
		      
			public DictionaryDosage[] QueryDictionaryDosages(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDictionaryDosages....."));
				try
				{ 
					return pharmacyServcie.QueryDictionaryDosages(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDictionaryDosages."));
				}
			}
		 
		      
			public DictionaryDosage[] QueryPagedDictionaryDosages(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDictionaryDosages....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDictionaryDosages(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDictionaryDosages."));
				}
			}
		 
		      
			public DictionaryDosage[] SearchDictionaryDosagesByQueryModel(out String message,QueryDictionaryDosageModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDictionaryDosagesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDictionaryDosagesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDictionaryDosagesByQueryModel."));
				}
			}
		 
		      
			public DictionaryDosage[] SearchPagedDictionaryDosagesByQueryModel(out PagerInfo pager,QueryDictionaryDosageModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDictionaryDosagesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDictionaryDosagesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDictionaryDosagesByQueryModel."));
				}
			}
		 
		      
			public DrugInfo GetDrugInfo(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugInfo....."));
				try
				{ 
					return pharmacyServcie.GetDrugInfo(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugInfo."));
				}
			}
		 
		      
			public bool AddDrugInfo(out String msg,DrugInfo value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDrugInfo....."));
				try
				{ 
					return pharmacyServcie.AddDrugInfo(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDrugInfo."));
				}
			}
		 
		      
			public bool DeleteDrugInfo(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDrugInfo....."));
				try
				{ 
					return pharmacyServcie.DeleteDrugInfo(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDrugInfo."));
				}
			}
		 
		      
			public bool SaveDrugInfo(out String msg,DrugInfo value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDrugInfo....."));
				try
				{ 
					return pharmacyServcie.SaveDrugInfo(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDrugInfo."));
				}
			}
		 
		      
			public DrugInfo[] AllDrugInfos(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDrugInfos....."));
				try
				{ 
					return pharmacyServcie.AllDrugInfos(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDrugInfos."));
				}
			}
		 
		      
			public DrugInfo[] QueryDrugInfos(out String msg,String permitlicensecode,DateTime permitdatefrom,DateTime permitdateto,DateTime permitoutdatefrom,DateTime permitoutdateto,String code,String description,String barcode,String standardcode,String productname,String productenglishname,String productgeneralname,String productothername,String factoryname,String factorynameabbreviation,String piecemealspecification,int piecemealnumberfrom,int piecemealnumberto,decimal pricefrom,decimal priceto,decimal nationalsalepricefrom,decimal nationalsalepriceto,decimal purchasepricefrom,decimal purchasepriceto,decimal salepricefrom,decimal salepriceto,decimal wholesalepricefrom,decimal wholesalepriceto,decimal retailpricefrom,decimal retailpriceto,decimal tagpricefrom,decimal tagpriceto,decimal lowsalepricefrom,decimal lowsalepriceto,decimal limitedlowpricefrom,decimal limitedlowpriceto,decimal limiteduppricefrom,decimal limiteduppriceto,bool ismedicalinsurance,bool queryismedicalinsurance,bool isprescription,bool queryisprescription,bool isimport,bool queryisimport,bool ismainmaintenance,bool queryismainmaintenance,bool isspecialdrugcategory,bool queryisspecialdrugcategory,String specialdrugcategorycode,int validperiodfrom,int validperiodto,String licensepermissionnumber,String performancestandards,String package,int packageamountfrom,int packageamountto,bool isapproval,bool queryisapproval,DateTime approvaldatefrom,DateTime approvaldateto,int maxinventorycountfrom,int maxinventorycountto,int mininventorycountfrom,int mininventorycountto,String origin,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool valid,bool queryvalid,String validremark,bool islock,bool queryislock,String lockremark,bool enabled,bool queryenabled,String businessscopecode,String purchasemanagecategorydetailcode,String drugcategorycode,String medicalcategorydetailcode,String drugclinicalcategorycode,String dictionaryuserdefinedtypecode,String drugstoragetypecode,String dictionarymeasurementunitcode,String dictionarydosagecode,String dictionaryspecificationcode,String dictionarypiecemealunitcode,int goodstypevaluefrom,int goodstypevalueto,int approvalstatusvaluefrom,int approvalstatusvalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDrugInfos....."));
				try
				{ 
					return pharmacyServcie.QueryDrugInfos(out msg,permitlicensecode,permitdatefrom,permitdateto,permitoutdatefrom,permitoutdateto,code,description,barcode,standardcode,productname,productenglishname,productgeneralname,productothername,factoryname,factorynameabbreviation,piecemealspecification,piecemealnumberfrom,piecemealnumberto,pricefrom,priceto,nationalsalepricefrom,nationalsalepriceto,purchasepricefrom,purchasepriceto,salepricefrom,salepriceto,wholesalepricefrom,wholesalepriceto,retailpricefrom,retailpriceto,tagpricefrom,tagpriceto,lowsalepricefrom,lowsalepriceto,limitedlowpricefrom,limitedlowpriceto,limiteduppricefrom,limiteduppriceto,ismedicalinsurance,queryismedicalinsurance,isprescription,queryisprescription,isimport,queryisimport,ismainmaintenance,queryismainmaintenance,isspecialdrugcategory,queryisspecialdrugcategory,specialdrugcategorycode,validperiodfrom,validperiodto,licensepermissionnumber,performancestandards,package,packageamountfrom,packageamountto,isapproval,queryisapproval,approvaldatefrom,approvaldateto,maxinventorycountfrom,maxinventorycountto,mininventorycountfrom,mininventorycountto,origin,createtimefrom,createtimeto,updatetimefrom,updatetimeto,valid,queryvalid,validremark,islock,queryislock,lockremark,enabled,queryenabled,businessscopecode,purchasemanagecategorydetailcode,drugcategorycode,medicalcategorydetailcode,drugclinicalcategorycode,dictionaryuserdefinedtypecode,drugstoragetypecode,dictionarymeasurementunitcode,dictionarydosagecode,dictionaryspecificationcode,dictionarypiecemealunitcode,goodstypevaluefrom,goodstypevalueto,approvalstatusvaluefrom,approvalstatusvalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDrugInfos."));
				}
			}
		 
		      
			public DrugInfo[] QueryPagedDrugInfos(out PagerInfo pager,String permitlicensecode,DateTime permitdatefrom,DateTime permitdateto,DateTime permitoutdatefrom,DateTime permitoutdateto,String code,String description,String barcode,String standardcode,String productname,String productenglishname,String productgeneralname,String productothername,String factoryname,String factorynameabbreviation,String piecemealspecification,int piecemealnumberfrom,int piecemealnumberto,decimal pricefrom,decimal priceto,decimal nationalsalepricefrom,decimal nationalsalepriceto,decimal purchasepricefrom,decimal purchasepriceto,decimal salepricefrom,decimal salepriceto,decimal wholesalepricefrom,decimal wholesalepriceto,decimal retailpricefrom,decimal retailpriceto,decimal tagpricefrom,decimal tagpriceto,decimal lowsalepricefrom,decimal lowsalepriceto,decimal limitedlowpricefrom,decimal limitedlowpriceto,decimal limiteduppricefrom,decimal limiteduppriceto,bool ismedicalinsurance,bool queryismedicalinsurance,bool isprescription,bool queryisprescription,bool isimport,bool queryisimport,bool ismainmaintenance,bool queryismainmaintenance,bool isspecialdrugcategory,bool queryisspecialdrugcategory,String specialdrugcategorycode,int validperiodfrom,int validperiodto,String licensepermissionnumber,String performancestandards,String package,int packageamountfrom,int packageamountto,bool isapproval,bool queryisapproval,DateTime approvaldatefrom,DateTime approvaldateto,int maxinventorycountfrom,int maxinventorycountto,int mininventorycountfrom,int mininventorycountto,String origin,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool valid,bool queryvalid,String validremark,bool islock,bool queryislock,String lockremark,bool enabled,bool queryenabled,String businessscopecode,String purchasemanagecategorydetailcode,String drugcategorycode,String medicalcategorydetailcode,String drugclinicalcategorycode,String dictionaryuserdefinedtypecode,String drugstoragetypecode,String dictionarymeasurementunitcode,String dictionarydosagecode,String dictionaryspecificationcode,String dictionarypiecemealunitcode,int goodstypevaluefrom,int goodstypevalueto,int approvalstatusvaluefrom,int approvalstatusvalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDrugInfos....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDrugInfos(out pager,permitlicensecode,permitdatefrom,permitdateto,permitoutdatefrom,permitoutdateto,code,description,barcode,standardcode,productname,productenglishname,productgeneralname,productothername,factoryname,factorynameabbreviation,piecemealspecification,piecemealnumberfrom,piecemealnumberto,pricefrom,priceto,nationalsalepricefrom,nationalsalepriceto,purchasepricefrom,purchasepriceto,salepricefrom,salepriceto,wholesalepricefrom,wholesalepriceto,retailpricefrom,retailpriceto,tagpricefrom,tagpriceto,lowsalepricefrom,lowsalepriceto,limitedlowpricefrom,limitedlowpriceto,limiteduppricefrom,limiteduppriceto,ismedicalinsurance,queryismedicalinsurance,isprescription,queryisprescription,isimport,queryisimport,ismainmaintenance,queryismainmaintenance,isspecialdrugcategory,queryisspecialdrugcategory,specialdrugcategorycode,validperiodfrom,validperiodto,licensepermissionnumber,performancestandards,package,packageamountfrom,packageamountto,isapproval,queryisapproval,approvaldatefrom,approvaldateto,maxinventorycountfrom,maxinventorycountto,mininventorycountfrom,mininventorycountto,origin,createtimefrom,createtimeto,updatetimefrom,updatetimeto,valid,queryvalid,validremark,islock,queryislock,lockremark,enabled,queryenabled,businessscopecode,purchasemanagecategorydetailcode,drugcategorycode,medicalcategorydetailcode,drugclinicalcategorycode,dictionaryuserdefinedtypecode,drugstoragetypecode,dictionarymeasurementunitcode,dictionarydosagecode,dictionaryspecificationcode,dictionarypiecemealunitcode,goodstypevaluefrom,goodstypevalueto,approvalstatusvaluefrom,approvalstatusvalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDrugInfos."));
				}
			}
		 
		      
			public DrugInfo[] SearchDrugInfosByQueryModel(out String message,QueryDrugInfoModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDrugInfosByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDrugInfosByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDrugInfosByQueryModel."));
				}
			}
		 
		      
			public DrugInfo[] SearchPagedDrugInfosByQueryModel(out PagerInfo pager,QueryDrugInfoModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDrugInfosByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDrugInfosByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDrugInfosByQueryModel."));
				}
			}
		 
		      
			public DrugInventoryRecord GetDrugInventoryRecord(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugInventoryRecord....."));
				try
				{ 
					return pharmacyServcie.GetDrugInventoryRecord(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugInventoryRecord."));
				}
			}
		 
		      
			public bool AddDrugInventoryRecord(out String msg,DrugInventoryRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDrugInventoryRecord....."));
				try
				{ 
					return pharmacyServcie.AddDrugInventoryRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDrugInventoryRecord."));
				}
			}
		 
		      
			public bool DeleteDrugInventoryRecord(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDrugInventoryRecord....."));
				try
				{ 
					return pharmacyServcie.DeleteDrugInventoryRecord(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDrugInventoryRecord."));
				}
			}
		 
		      
			public bool SaveDrugInventoryRecord(out String msg,DrugInventoryRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDrugInventoryRecord....."));
				try
				{ 
					return pharmacyServcie.SaveDrugInventoryRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDrugInventoryRecord."));
				}
			}
		 
		      
			public DrugInventoryRecord[] AllDrugInventoryRecords(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDrugInventoryRecords....."));
				try
				{ 
					return pharmacyServcie.AllDrugInventoryRecords(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDrugInventoryRecords."));
				}
			}
		 
		      
			public DrugInventoryRecord[] QueryDrugInventoryRecords(out String msg,decimal purchasepriccefrom,decimal purchasepricceto,String batchnumber,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,bool isoutvaliddate,bool queryisoutvaliddate,int ininventorycountfrom,int ininventorycountto,int salescountfrom,int salescountto,int onsalesordercountfrom,int onsalesordercountto,int currentinventorycountfrom,int currentinventorycountto,int retailcountfrom,int retailcountto,int dismantingamountfrom,int dismantingamountto,int retaildismantingamountfrom,int retaildismantingamountto,int onretailcountfrom,int onretailcountto,String decription,int cansalenumfrom,int cansalenumto,bool valid,bool queryvalid,int durginventorytypevaluefrom,int durginventorytypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDrugInventoryRecords....."));
				try
				{ 
					return pharmacyServcie.QueryDrugInventoryRecords(out msg,purchasepriccefrom,purchasepricceto,batchnumber,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,isoutvaliddate,queryisoutvaliddate,ininventorycountfrom,ininventorycountto,salescountfrom,salescountto,onsalesordercountfrom,onsalesordercountto,currentinventorycountfrom,currentinventorycountto,retailcountfrom,retailcountto,dismantingamountfrom,dismantingamountto,retaildismantingamountfrom,retaildismantingamountto,onretailcountfrom,onretailcountto,decription,cansalenumfrom,cansalenumto,valid,queryvalid,durginventorytypevaluefrom,durginventorytypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDrugInventoryRecords."));
				}
			}
		 
		      
			public DrugInventoryRecord[] QueryPagedDrugInventoryRecords(out PagerInfo pager,decimal purchasepriccefrom,decimal purchasepricceto,String batchnumber,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,bool isoutvaliddate,bool queryisoutvaliddate,int ininventorycountfrom,int ininventorycountto,int salescountfrom,int salescountto,int onsalesordercountfrom,int onsalesordercountto,int currentinventorycountfrom,int currentinventorycountto,int retailcountfrom,int retailcountto,int dismantingamountfrom,int dismantingamountto,int retaildismantingamountfrom,int retaildismantingamountto,int onretailcountfrom,int onretailcountto,String decription,int cansalenumfrom,int cansalenumto,bool valid,bool queryvalid,int durginventorytypevaluefrom,int durginventorytypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDrugInventoryRecords....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDrugInventoryRecords(out pager,purchasepriccefrom,purchasepricceto,batchnumber,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,isoutvaliddate,queryisoutvaliddate,ininventorycountfrom,ininventorycountto,salescountfrom,salescountto,onsalesordercountfrom,onsalesordercountto,currentinventorycountfrom,currentinventorycountto,retailcountfrom,retailcountto,dismantingamountfrom,dismantingamountto,retaildismantingamountfrom,retaildismantingamountto,onretailcountfrom,onretailcountto,decription,cansalenumfrom,cansalenumto,valid,queryvalid,durginventorytypevaluefrom,durginventorytypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDrugInventoryRecords."));
				}
			}
		 
		      
			public DrugInventoryRecord[] SearchDrugInventoryRecordsByQueryModel(out String message,QueryDrugInventoryRecordModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDrugInventoryRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDrugInventoryRecordsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDrugInventoryRecordsByQueryModel."));
				}
			}
		 
		      
			public DrugInventoryRecord[] SearchPagedDrugInventoryRecordsByQueryModel(out PagerInfo pager,QueryDrugInventoryRecordModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDrugInventoryRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDrugInventoryRecordsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDrugInventoryRecordsByQueryModel."));
				}
			}
		 
		      
			public DrugMaintainRecord GetDrugMaintainRecord(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugMaintainRecord....."));
				try
				{ 
					return pharmacyServcie.GetDrugMaintainRecord(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugMaintainRecord."));
				}
			}
		 
		      
			public bool AddDrugMaintainRecord(out String msg,DrugMaintainRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDrugMaintainRecord....."));
				try
				{ 
					return pharmacyServcie.AddDrugMaintainRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDrugMaintainRecord."));
				}
			}
		 
		      
			public bool DeleteDrugMaintainRecord(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDrugMaintainRecord....."));
				try
				{ 
					return pharmacyServcie.DeleteDrugMaintainRecord(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDrugMaintainRecord."));
				}
			}
		 
		      
			public bool SaveDrugMaintainRecord(out String msg,DrugMaintainRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDrugMaintainRecord....."));
				try
				{ 
					return pharmacyServcie.SaveDrugMaintainRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDrugMaintainRecord."));
				}
			}
		 
		      
			public DrugMaintainRecord[] AllDrugMaintainRecords(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDrugMaintainRecords....."));
				try
				{ 
					return pharmacyServcie.AllDrugMaintainRecords(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDrugMaintainRecords."));
				}
			}
		 
		      
			public DrugMaintainRecord[] QueryDrugMaintainRecords(out String msg,String billdocumentno,DateTime expirationdatefrom,DateTime expirationdateto,int drugmaintaintypevaluefrom,int drugmaintaintypevalueto,int completestatefrom,int completestateto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDrugMaintainRecords....."));
				try
				{ 
					return pharmacyServcie.QueryDrugMaintainRecords(out msg,billdocumentno,expirationdatefrom,expirationdateto,drugmaintaintypevaluefrom,drugmaintaintypevalueto,completestatefrom,completestateto,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDrugMaintainRecords."));
				}
			}
		 
		      
			public DrugMaintainRecord[] QueryPagedDrugMaintainRecords(out PagerInfo pager,String billdocumentno,DateTime expirationdatefrom,DateTime expirationdateto,int drugmaintaintypevaluefrom,int drugmaintaintypevalueto,int completestatefrom,int completestateto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDrugMaintainRecords....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDrugMaintainRecords(out pager,billdocumentno,expirationdatefrom,expirationdateto,drugmaintaintypevaluefrom,drugmaintaintypevalueto,completestatefrom,completestateto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDrugMaintainRecords."));
				}
			}
		 
		      
			public DrugMaintainRecord[] SearchDrugMaintainRecordsByQueryModel(out String message,QueryDrugMaintainRecordModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDrugMaintainRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDrugMaintainRecordsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDrugMaintainRecordsByQueryModel."));
				}
			}
		 
		      
			public DrugMaintainRecord[] SearchPagedDrugMaintainRecordsByQueryModel(out PagerInfo pager,QueryDrugMaintainRecordModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDrugMaintainRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDrugMaintainRecordsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDrugMaintainRecordsByQueryModel."));
				}
			}
		 
		      
			public DrugMaintainRecordDetail GetDrugMaintainRecordDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugMaintainRecordDetail....."));
				try
				{ 
					return pharmacyServcie.GetDrugMaintainRecordDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugMaintainRecordDetail."));
				}
			}
		 
		      
			public bool AddDrugMaintainRecordDetail(out String msg,DrugMaintainRecordDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDrugMaintainRecordDetail....."));
				try
				{ 
					return pharmacyServcie.AddDrugMaintainRecordDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDrugMaintainRecordDetail."));
				}
			}
		 
		      
			public bool DeleteDrugMaintainRecordDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDrugMaintainRecordDetail....."));
				try
				{ 
					return pharmacyServcie.DeleteDrugMaintainRecordDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDrugMaintainRecordDetail."));
				}
			}
		 
		      
			public bool SaveDrugMaintainRecordDetail(out String msg,DrugMaintainRecordDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDrugMaintainRecordDetail....."));
				try
				{ 
					return pharmacyServcie.SaveDrugMaintainRecordDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDrugMaintainRecordDetail."));
				}
			}
		 
		      
			public DrugMaintainRecordDetail[] AllDrugMaintainRecordDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDrugMaintainRecordDetails....."));
				try
				{ 
					return pharmacyServcie.AllDrugMaintainRecordDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDrugMaintainRecordDetails."));
				}
			}
		 
		      
			public DrugMaintainRecordDetail[] QueryDrugMaintainRecordDetails(out String msg,String billdocumentno,String productname,String dictionarydosagecode,String dictionaryspecificationcode,int currentinventorycountfrom,int currentinventorycountto,int maintaincountfrom,int maintaincountto,decimal pricefrom,decimal priceto,String origin,String licensepermissionnumber,String batchnumber,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,String manufacturer,String checkqualifiednumber,String checkresult)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDrugMaintainRecordDetails....."));
				try
				{ 
					return pharmacyServcie.QueryDrugMaintainRecordDetails(out msg,billdocumentno,productname,dictionarydosagecode,dictionaryspecificationcode,currentinventorycountfrom,currentinventorycountto,maintaincountfrom,maintaincountto,pricefrom,priceto,origin,licensepermissionnumber,batchnumber,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,manufacturer,checkqualifiednumber,checkresult);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDrugMaintainRecordDetails."));
				}
			}
		 
		      
			public DrugMaintainRecordDetail[] QueryPagedDrugMaintainRecordDetails(out PagerInfo pager,String billdocumentno,String productname,String dictionarydosagecode,String dictionaryspecificationcode,int currentinventorycountfrom,int currentinventorycountto,int maintaincountfrom,int maintaincountto,decimal pricefrom,decimal priceto,String origin,String licensepermissionnumber,String batchnumber,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,String manufacturer,String checkqualifiednumber,String checkresult,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDrugMaintainRecordDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDrugMaintainRecordDetails(out pager,billdocumentno,productname,dictionarydosagecode,dictionaryspecificationcode,currentinventorycountfrom,currentinventorycountto,maintaincountfrom,maintaincountto,pricefrom,priceto,origin,licensepermissionnumber,batchnumber,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,manufacturer,checkqualifiednumber,checkresult,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDrugMaintainRecordDetails."));
				}
			}
		 
		      
			public DrugMaintainRecordDetail[] SearchDrugMaintainRecordDetailsByQueryModel(out String message,QueryDrugMaintainRecordDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDrugMaintainRecordDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDrugMaintainRecordDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDrugMaintainRecordDetailsByQueryModel."));
				}
			}
		 
		      
			public DrugMaintainRecordDetail[] SearchPagedDrugMaintainRecordDetailsByQueryModel(out PagerInfo pager,QueryDrugMaintainRecordDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDrugMaintainRecordDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDrugMaintainRecordDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDrugMaintainRecordDetailsByQueryModel."));
				}
			}
		 
		      
			public DictionaryMeasurementUnit GetDictionaryMeasurementUnit(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDictionaryMeasurementUnit....."));
				try
				{ 
					return pharmacyServcie.GetDictionaryMeasurementUnit(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDictionaryMeasurementUnit."));
				}
			}
		 
		      
			public bool AddDictionaryMeasurementUnit(out String msg,DictionaryMeasurementUnit value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDictionaryMeasurementUnit....."));
				try
				{ 
					return pharmacyServcie.AddDictionaryMeasurementUnit(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDictionaryMeasurementUnit."));
				}
			}
		 
		      
			public bool DeleteDictionaryMeasurementUnit(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDictionaryMeasurementUnit....."));
				try
				{ 
					return pharmacyServcie.DeleteDictionaryMeasurementUnit(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDictionaryMeasurementUnit."));
				}
			}
		 
		      
			public bool SaveDictionaryMeasurementUnit(out String msg,DictionaryMeasurementUnit value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDictionaryMeasurementUnit....."));
				try
				{ 
					return pharmacyServcie.SaveDictionaryMeasurementUnit(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDictionaryMeasurementUnit."));
				}
			}
		 
		      
			public DictionaryMeasurementUnit[] AllDictionaryMeasurementUnits(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDictionaryMeasurementUnits....."));
				try
				{ 
					return pharmacyServcie.AllDictionaryMeasurementUnits(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDictionaryMeasurementUnits."));
				}
			}
		 
		      
			public DictionaryMeasurementUnit[] QueryDictionaryMeasurementUnits(out String msg,String name,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDictionaryMeasurementUnits....."));
				try
				{ 
					return pharmacyServcie.QueryDictionaryMeasurementUnits(out msg,name,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDictionaryMeasurementUnits."));
				}
			}
		 
		      
			public DictionaryMeasurementUnit[] QueryPagedDictionaryMeasurementUnits(out PagerInfo pager,String name,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDictionaryMeasurementUnits....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDictionaryMeasurementUnits(out pager,name,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDictionaryMeasurementUnits."));
				}
			}
		 
		      
			public DictionaryMeasurementUnit[] SearchDictionaryMeasurementUnitsByQueryModel(out String message,QueryDictionaryMeasurementUnitModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDictionaryMeasurementUnitsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDictionaryMeasurementUnitsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDictionaryMeasurementUnitsByQueryModel."));
				}
			}
		 
		      
			public DictionaryMeasurementUnit[] SearchPagedDictionaryMeasurementUnitsByQueryModel(out PagerInfo pager,QueryDictionaryMeasurementUnitModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDictionaryMeasurementUnitsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDictionaryMeasurementUnitsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDictionaryMeasurementUnitsByQueryModel."));
				}
			}
		 
		      
			public DictionaryPiecemealUnit GetDictionaryPiecemealUnit(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDictionaryPiecemealUnit....."));
				try
				{ 
					return pharmacyServcie.GetDictionaryPiecemealUnit(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDictionaryPiecemealUnit."));
				}
			}
		 
		      
			public InstrumentsProductionLicense GetInstrumentsProductionLicense(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetInstrumentsProductionLicense....."));
				try
				{ 
					return pharmacyServcie.GetInstrumentsProductionLicense(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetInstrumentsProductionLicense."));
				}
			}
		 
		      
			public bool AddInstrumentsProductionLicense(out String msg,InstrumentsProductionLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddInstrumentsProductionLicense....."));
				try
				{ 
					return pharmacyServcie.AddInstrumentsProductionLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddInstrumentsProductionLicense."));
				}
			}
		 
		      
			public bool DeleteInstrumentsProductionLicense(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteInstrumentsProductionLicense....."));
				try
				{ 
					return pharmacyServcie.DeleteInstrumentsProductionLicense(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteInstrumentsProductionLicense."));
				}
			}
		 
		      
			public bool SaveInstrumentsProductionLicense(out String msg,InstrumentsProductionLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveInstrumentsProductionLicense....."));
				try
				{ 
					return pharmacyServcie.SaveInstrumentsProductionLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveInstrumentsProductionLicense."));
				}
			}
		 
		      
			public InstrumentsProductionLicense[] AllInstrumentsProductionLicenses(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllInstrumentsProductionLicenses....."));
				try
				{ 
					return pharmacyServcie.AllInstrumentsProductionLicenses(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllInstrumentsProductionLicenses."));
				}
			}
		 
		      
			public InstrumentsProductionLicense[] QueryInstrumentsProductionLicenses(out String msg,String legalperson,String header,String productaddress,String productscope,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryInstrumentsProductionLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryInstrumentsProductionLicenses(out msg,legalperson,header,productaddress,productscope,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryInstrumentsProductionLicenses."));
				}
			}
		 
		      
			public InstrumentsProductionLicense[] QueryPagedInstrumentsProductionLicenses(out PagerInfo pager,String legalperson,String header,String productaddress,String productscope,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedInstrumentsProductionLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryPagedInstrumentsProductionLicenses(out pager,legalperson,header,productaddress,productscope,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedInstrumentsProductionLicenses."));
				}
			}
		 
		      
			public InstrumentsProductionLicense[] SearchInstrumentsProductionLicensesByQueryModel(out String message,QueryInstrumentsProductionLicenseModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchInstrumentsProductionLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchInstrumentsProductionLicensesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchInstrumentsProductionLicensesByQueryModel."));
				}
			}
		 
		      
			public InstrumentsProductionLicense[] SearchPagedInstrumentsProductionLicensesByQueryModel(out PagerInfo pager,QueryInstrumentsProductionLicenseModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedInstrumentsProductionLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedInstrumentsProductionLicensesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedInstrumentsProductionLicensesByQueryModel."));
				}
			}
		 
		      
			public MedicalCategory GetMedicalCategory(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetMedicalCategory....."));
				try
				{ 
					return pharmacyServcie.GetMedicalCategory(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetMedicalCategory."));
				}
			}
		 
		      
			public bool AddMedicalCategory(out String msg,MedicalCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddMedicalCategory....."));
				try
				{ 
					return pharmacyServcie.AddMedicalCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddMedicalCategory."));
				}
			}
		 
		      
			public bool DeleteMedicalCategory(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteMedicalCategory....."));
				try
				{ 
					return pharmacyServcie.DeleteMedicalCategory(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteMedicalCategory."));
				}
			}
		 
		      
			public bool SaveMedicalCategory(out String msg,MedicalCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveMedicalCategory....."));
				try
				{ 
					return pharmacyServcie.SaveMedicalCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveMedicalCategory."));
				}
			}
		 
		      
			public MedicalCategory[] AllMedicalCategorys(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllMedicalCategorys....."));
				try
				{ 
					return pharmacyServcie.AllMedicalCategorys(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllMedicalCategorys."));
				}
			}
		 
		      
			public MedicalCategory[] QueryMedicalCategorys(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryMedicalCategorys....."));
				try
				{ 
					return pharmacyServcie.QueryMedicalCategorys(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryMedicalCategorys."));
				}
			}
		 
		      
			public MedicalCategory[] QueryPagedMedicalCategorys(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedMedicalCategorys....."));
				try
				{ 
					return pharmacyServcie.QueryPagedMedicalCategorys(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedMedicalCategorys."));
				}
			}
		 
		      
			public MedicalCategory[] SearchMedicalCategorysByQueryModel(out String message,QueryMedicalCategoryModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchMedicalCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchMedicalCategorysByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchMedicalCategorysByQueryModel."));
				}
			}
		 
		      
			public MedicalCategory[] SearchPagedMedicalCategorysByQueryModel(out PagerInfo pager,QueryMedicalCategoryModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedMedicalCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedMedicalCategorysByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedMedicalCategorysByQueryModel."));
				}
			}
		 
		      
			public MedicalCategoryDetail GetMedicalCategoryDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetMedicalCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.GetMedicalCategoryDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetMedicalCategoryDetail."));
				}
			}
		 
		      
			public bool AddMedicalCategoryDetail(out String msg,MedicalCategoryDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddMedicalCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.AddMedicalCategoryDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddMedicalCategoryDetail."));
				}
			}
		 
		      
			public bool DeleteMedicalCategoryDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteMedicalCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.DeleteMedicalCategoryDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteMedicalCategoryDetail."));
				}
			}
		 
		      
			public bool SaveMedicalCategoryDetail(out String msg,MedicalCategoryDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveMedicalCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.SaveMedicalCategoryDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveMedicalCategoryDetail."));
				}
			}
		 
		      
			public MedicalCategoryDetail[] AllMedicalCategoryDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllMedicalCategoryDetails....."));
				try
				{ 
					return pharmacyServcie.AllMedicalCategoryDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllMedicalCategoryDetails."));
				}
			}
		 
		      
			public MedicalCategoryDetail[] QueryMedicalCategoryDetails(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryMedicalCategoryDetails....."));
				try
				{ 
					return pharmacyServcie.QueryMedicalCategoryDetails(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryMedicalCategoryDetails."));
				}
			}
		 
		      
			public MedicalCategoryDetail[] QueryPagedMedicalCategoryDetails(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedMedicalCategoryDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedMedicalCategoryDetails(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedMedicalCategoryDetails."));
				}
			}
		 
		      
			public MedicalCategoryDetail[] SearchMedicalCategoryDetailsByQueryModel(out String message,QueryMedicalCategoryDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchMedicalCategoryDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchMedicalCategoryDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchMedicalCategoryDetailsByQueryModel."));
				}
			}
		 
		      
			public MedicalCategoryDetail[] SearchPagedMedicalCategoryDetailsByQueryModel(out PagerInfo pager,QueryMedicalCategoryDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedMedicalCategoryDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedMedicalCategoryDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedMedicalCategoryDetailsByQueryModel."));
				}
			}
		 
		      
			public Module GetModule(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetModule....."));
				try
				{ 
					return pharmacyServcie.GetModule(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetModule."));
				}
			}
		 
		      
			public bool AddModule(out String msg,Module value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddModule....."));
				try
				{ 
					return pharmacyServcie.AddModule(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddModule."));
				}
			}
		 
		      
			public bool DeleteModule(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteModule....."));
				try
				{ 
					return pharmacyServcie.DeleteModule(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteModule."));
				}
			}
		 
		      
			public bool SaveModule(out String msg,Module value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveModule....."));
				try
				{ 
					return pharmacyServcie.SaveModule(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveModule."));
				}
			}
		 
		      
			public Module[] AllModules(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllModules....."));
				try
				{ 
					return pharmacyServcie.AllModules(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllModules."));
				}
			}
		 
		      
			public DictionaryUserDefinedType[] QueryPagedDictionaryUserDefinedTypes(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDictionaryUserDefinedTypes....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDictionaryUserDefinedTypes(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDictionaryUserDefinedTypes."));
				}
			}
		 
		      
			public DictionaryUserDefinedType[] SearchDictionaryUserDefinedTypesByQueryModel(out String message,QueryDictionaryUserDefinedTypeModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDictionaryUserDefinedTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDictionaryUserDefinedTypesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDictionaryUserDefinedTypesByQueryModel."));
				}
			}
		 
		      
			public DictionaryUserDefinedType[] SearchPagedDictionaryUserDefinedTypesByQueryModel(out PagerInfo pager,QueryDictionaryUserDefinedTypeModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDictionaryUserDefinedTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDictionaryUserDefinedTypesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDictionaryUserDefinedTypesByQueryModel."));
				}
			}
		 
		      
			public AuthorizationDoc GetAuthorizationDoc(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetAuthorizationDoc....."));
				try
				{ 
					return pharmacyServcie.GetAuthorizationDoc(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetAuthorizationDoc."));
				}
			}
		 
		      
			public bool AddAuthorizationDoc(out String msg,AuthorizationDoc value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddAuthorizationDoc....."));
				try
				{ 
					return pharmacyServcie.AddAuthorizationDoc(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddAuthorizationDoc."));
				}
			}
		 
		      
			public bool DeleteAuthorizationDoc(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteAuthorizationDoc....."));
				try
				{ 
					return pharmacyServcie.DeleteAuthorizationDoc(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteAuthorizationDoc."));
				}
			}
		 
		      
			public bool SaveAuthorizationDoc(out String msg,AuthorizationDoc value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveAuthorizationDoc....."));
				try
				{ 
					return pharmacyServcie.SaveAuthorizationDoc(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveAuthorizationDoc."));
				}
			}
		 
		      
			public AuthorizationDoc[] AllAuthorizationDocs(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllAuthorizationDocs....."));
				try
				{ 
					return pharmacyServcie.AllAuthorizationDocs(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllAuthorizationDocs."));
				}
			}
		 
		      
			public AuthorizationDoc[] QueryAuthorizationDocs(out String msg,String docfile,String description,DateTime outdatefrom,DateTime outdateto,bool valid,bool queryvalid,bool isoutdate,bool queryisoutdate,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryAuthorizationDocs....."));
				try
				{ 
					return pharmacyServcie.QueryAuthorizationDocs(out msg,docfile,description,outdatefrom,outdateto,valid,queryvalid,isoutdate,queryisoutdate,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryAuthorizationDocs."));
				}
			}
		 
		      
			public AuthorizationDoc[] QueryPagedAuthorizationDocs(out PagerInfo pager,String docfile,String description,DateTime outdatefrom,DateTime outdateto,bool valid,bool queryvalid,bool isoutdate,bool queryisoutdate,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedAuthorizationDocs....."));
				try
				{ 
					return pharmacyServcie.QueryPagedAuthorizationDocs(out pager,docfile,description,outdatefrom,outdateto,valid,queryvalid,isoutdate,queryisoutdate,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedAuthorizationDocs."));
				}
			}
		 
		      
			public AuthorizationDoc[] SearchAuthorizationDocsByQueryModel(out String message,QueryAuthorizationDocModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchAuthorizationDocsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchAuthorizationDocsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchAuthorizationDocsByQueryModel."));
				}
			}
		 
		      
			public AuthorizationDoc[] SearchPagedAuthorizationDocsByQueryModel(out PagerInfo pager,QueryAuthorizationDocModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedAuthorizationDocsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedAuthorizationDocsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedAuthorizationDocsByQueryModel."));
				}
			}
		 
		      
			public DrugMaintainSet GetDrugMaintainSet(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetDrugMaintainSet....."));
				try
				{ 
					return pharmacyServcie.GetDrugMaintainSet(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetDrugMaintainSet."));
				}
			}
		 
		      
			public bool AddDrugMaintainSet(out String msg,DrugMaintainSet value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddDrugMaintainSet....."));
				try
				{ 
					return pharmacyServcie.AddDrugMaintainSet(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddDrugMaintainSet."));
				}
			}
		 
		      
			public bool DeleteDrugMaintainSet(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteDrugMaintainSet....."));
				try
				{ 
					return pharmacyServcie.DeleteDrugMaintainSet(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteDrugMaintainSet."));
				}
			}
		 
		      
			public bool SaveDrugMaintainSet(out String msg,DrugMaintainSet value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveDrugMaintainSet....."));
				try
				{ 
					return pharmacyServcie.SaveDrugMaintainSet(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveDrugMaintainSet."));
				}
			}
		 
		      
			public DrugMaintainSet[] AllDrugMaintainSets(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllDrugMaintainSets....."));
				try
				{ 
					return pharmacyServcie.AllDrugMaintainSets(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllDrugMaintainSets."));
				}
			}
		 
		      
			public DrugMaintainSet[] QueryDrugMaintainSets(out String msg,int drugmaintaintypevaluefrom,int drugmaintaintypevalueto,String name,int dayfrom,int dayto,DateTime startdatefrom,DateTime startdateto,int remindbeforedayfrom,int remindbeforedayto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryDrugMaintainSets....."));
				try
				{ 
					return pharmacyServcie.QueryDrugMaintainSets(out msg,drugmaintaintypevaluefrom,drugmaintaintypevalueto,name,dayfrom,dayto,startdatefrom,startdateto,remindbeforedayfrom,remindbeforedayto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryDrugMaintainSets."));
				}
			}
		 
		      
			public DrugMaintainSet[] QueryPagedDrugMaintainSets(out PagerInfo pager,int drugmaintaintypevaluefrom,int drugmaintaintypevalueto,String name,int dayfrom,int dayto,DateTime startdatefrom,DateTime startdateto,int remindbeforedayfrom,int remindbeforedayto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedDrugMaintainSets....."));
				try
				{ 
					return pharmacyServcie.QueryPagedDrugMaintainSets(out pager,drugmaintaintypevaluefrom,drugmaintaintypevalueto,name,dayfrom,dayto,startdatefrom,startdateto,remindbeforedayfrom,remindbeforedayto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedDrugMaintainSets."));
				}
			}
		 
		      
			public DrugMaintainSet[] SearchDrugMaintainSetsByQueryModel(out String message,QueryDrugMaintainSetModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchDrugMaintainSetsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchDrugMaintainSetsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchDrugMaintainSetsByQueryModel."));
				}
			}
		 
		      
			public DrugMaintainSet[] SearchPagedDrugMaintainSetsByQueryModel(out PagerInfo pager,QueryDrugMaintainSetModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedDrugMaintainSetsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedDrugMaintainSetsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedDrugMaintainSetsByQueryModel."));
				}
			}
		 
		      
			public Employee GetEmployee(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetEmployee....."));
				try
				{ 
					return pharmacyServcie.GetEmployee(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetEmployee."));
				}
			}
		 
		      
			public bool AddEmployee(out String msg,Employee value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddEmployee....."));
				try
				{ 
					return pharmacyServcie.AddEmployee(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddEmployee."));
				}
			}
		 
		      
			public bool DeleteEmployee(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteEmployee....."));
				try
				{ 
					return pharmacyServcie.DeleteEmployee(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteEmployee."));
				}
			}
		 
		      
			public bool SaveEmployee(out String msg,Employee value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveEmployee....."));
				try
				{ 
					return pharmacyServcie.SaveEmployee(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveEmployee."));
				}
			}
		 
		      
			public Employee[] AllEmployees(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllEmployees....."));
				try
				{ 
					return pharmacyServcie.AllEmployees(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllEmployees."));
				}
			}
		 
		      
			public Employee[] QueryEmployees(out String msg,DateTime outdatefrom,DateTime outdateto,String number,String name,String pinyin,String gender,String identityno,String phone,String email,String address,String rank,String education,String duty,String specility,int employstatusvaluefrom,int employstatusvalueto,bool enabled,bool queryenabled,int pharmaciststitletypevaluefrom,int pharmaciststitletypevalueto,String cardno,int pharmacistsqualificationvaluefrom,int pharmacistsqualificationvalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryEmployees....."));
				try
				{ 
					return pharmacyServcie.QueryEmployees(out msg,outdatefrom,outdateto,number,name,pinyin,gender,identityno,phone,email,address,rank,education,duty,specility,employstatusvaluefrom,employstatusvalueto,enabled,queryenabled,pharmaciststitletypevaluefrom,pharmaciststitletypevalueto,cardno,pharmacistsqualificationvaluefrom,pharmacistsqualificationvalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryEmployees."));
				}
			}
		 
		      
			public Employee[] QueryPagedEmployees(out PagerInfo pager,DateTime outdatefrom,DateTime outdateto,String number,String name,String pinyin,String gender,String identityno,String phone,String email,String address,String rank,String education,String duty,String specility,int employstatusvaluefrom,int employstatusvalueto,bool enabled,bool queryenabled,int pharmaciststitletypevaluefrom,int pharmaciststitletypevalueto,String cardno,int pharmacistsqualificationvaluefrom,int pharmacistsqualificationvalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedEmployees....."));
				try
				{ 
					return pharmacyServcie.QueryPagedEmployees(out pager,outdatefrom,outdateto,number,name,pinyin,gender,identityno,phone,email,address,rank,education,duty,specility,employstatusvaluefrom,employstatusvalueto,enabled,queryenabled,pharmaciststitletypevaluefrom,pharmaciststitletypevalueto,cardno,pharmacistsqualificationvaluefrom,pharmacistsqualificationvalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedEmployees."));
				}
			}
		 
		      
			public Employee[] SearchEmployeesByQueryModel(out String message,QueryEmployeeModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchEmployeesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchEmployeesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchEmployeesByQueryModel."));
				}
			}
		 
		      
			public Employee[] SearchPagedEmployeesByQueryModel(out PagerInfo pager,QueryEmployeeModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedEmployeesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedEmployeesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedEmployeesByQueryModel."));
				}
			}
		 
		      
			public GMSPLicenseBusinessScope GetGMSPLicenseBusinessScope(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetGMSPLicenseBusinessScope....."));
				try
				{ 
					return pharmacyServcie.GetGMSPLicenseBusinessScope(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetGMSPLicenseBusinessScope."));
				}
			}
		 
		      
			public bool AddGMSPLicenseBusinessScope(out String msg,GMSPLicenseBusinessScope value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddGMSPLicenseBusinessScope....."));
				try
				{ 
					return pharmacyServcie.AddGMSPLicenseBusinessScope(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddGMSPLicenseBusinessScope."));
				}
			}
		 
		      
			public bool DeleteGMSPLicenseBusinessScope(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteGMSPLicenseBusinessScope....."));
				try
				{ 
					return pharmacyServcie.DeleteGMSPLicenseBusinessScope(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteGMSPLicenseBusinessScope."));
				}
			}
		 
		      
			public bool SaveGMSPLicenseBusinessScope(out String msg,GMSPLicenseBusinessScope value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveGMSPLicenseBusinessScope....."));
				try
				{ 
					return pharmacyServcie.SaveGMSPLicenseBusinessScope(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveGMSPLicenseBusinessScope."));
				}
			}
		 
		      
			public GMSPLicenseBusinessScope[] AllGMSPLicenseBusinessScopes(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllGMSPLicenseBusinessScopes....."));
				try
				{ 
					return pharmacyServcie.AllGMSPLicenseBusinessScopes(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllGMSPLicenseBusinessScopes."));
				}
			}
		 
		      
			public GMSPLicenseBusinessScope[] QueryGMSPLicenseBusinessScopes(out String msg)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryGMSPLicenseBusinessScopes....."));
				try
				{ 
					return pharmacyServcie.QueryGMSPLicenseBusinessScopes(out msg);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryGMSPLicenseBusinessScopes."));
				}
			}
		 
		      
			public GMSPLicenseBusinessScope[] QueryPagedGMSPLicenseBusinessScopes(out PagerInfo pager,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedGMSPLicenseBusinessScopes....."));
				try
				{ 
					return pharmacyServcie.QueryPagedGMSPLicenseBusinessScopes(out pager,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedGMSPLicenseBusinessScopes."));
				}
			}
		 
		      
			public GMSPLicenseBusinessScope[] SearchGMSPLicenseBusinessScopesByQueryModel(out String message,QueryGMSPLicenseBusinessScopeModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchGMSPLicenseBusinessScopesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchGMSPLicenseBusinessScopesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchGMSPLicenseBusinessScopesByQueryModel."));
				}
			}
		 
		      
			public GMSPLicenseBusinessScope[] SearchPagedGMSPLicenseBusinessScopesByQueryModel(out PagerInfo pager,QueryGMSPLicenseBusinessScopeModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedGMSPLicenseBusinessScopesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedGMSPLicenseBusinessScopesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedGMSPLicenseBusinessScopesByQueryModel."));
				}
			}
		 
		      
			public InventoryRecord GetInventoryRecord(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetInventoryRecord....."));
				try
				{ 
					return pharmacyServcie.GetInventoryRecord(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetInventoryRecord."));
				}
			}
		 
		      
			public bool AddInventoryRecord(out String msg,InventoryRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddInventoryRecord....."));
				try
				{ 
					return pharmacyServcie.AddInventoryRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddInventoryRecord."));
				}
			}
		 
		      
			public bool DeleteInventoryRecord(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteInventoryRecord....."));
				try
				{ 
					return pharmacyServcie.DeleteInventoryRecord(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteInventoryRecord."));
				}
			}
		 
		      
			public bool SaveInventoryRecord(out String msg,InventoryRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveInventoryRecord....."));
				try
				{ 
					return pharmacyServcie.SaveInventoryRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveInventoryRecord."));
				}
			}
		 
		      
			public InventoryRecord[] AllInventoryRecords(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllInventoryRecords....."));
				try
				{ 
					return pharmacyServcie.AllInventoryRecords(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllInventoryRecords."));
				}
			}
		 
		      
			public InventoryRecord[] QueryInventoryRecords(out String msg,int maxinventorycountfrom,int maxinventorycountto,int mininventorycountfrom,int mininventorycountto,int currentinventorycountfrom,int currentinventorycountto,int salescountfrom,int salescountto,int onsalesordercountfrom,int onsalesordercountto,int retailcountfrom,int retailcountto,int onretailcountfrom,int onretailcountto,int dismantingamountfrom,int dismantingamountto,int retaildismantingamountfrom,int retaildismantingamountto,String druginfocode)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryInventoryRecords....."));
				try
				{ 
					return pharmacyServcie.QueryInventoryRecords(out msg,maxinventorycountfrom,maxinventorycountto,mininventorycountfrom,mininventorycountto,currentinventorycountfrom,currentinventorycountto,salescountfrom,salescountto,onsalesordercountfrom,onsalesordercountto,retailcountfrom,retailcountto,onretailcountfrom,onretailcountto,dismantingamountfrom,dismantingamountto,retaildismantingamountfrom,retaildismantingamountto,druginfocode);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryInventoryRecords."));
				}
			}
		 
		      
			public InventoryRecord[] QueryPagedInventoryRecords(out PagerInfo pager,int maxinventorycountfrom,int maxinventorycountto,int mininventorycountfrom,int mininventorycountto,int currentinventorycountfrom,int currentinventorycountto,int salescountfrom,int salescountto,int onsalesordercountfrom,int onsalesordercountto,int retailcountfrom,int retailcountto,int onretailcountfrom,int onretailcountto,int dismantingamountfrom,int dismantingamountto,int retaildismantingamountfrom,int retaildismantingamountto,String druginfocode,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedInventoryRecords....."));
				try
				{ 
					return pharmacyServcie.QueryPagedInventoryRecords(out pager,maxinventorycountfrom,maxinventorycountto,mininventorycountfrom,mininventorycountto,currentinventorycountfrom,currentinventorycountto,salescountfrom,salescountto,onsalesordercountfrom,onsalesordercountto,retailcountfrom,retailcountto,onretailcountfrom,onretailcountto,dismantingamountfrom,dismantingamountto,retaildismantingamountfrom,retaildismantingamountto,druginfocode,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedInventoryRecords."));
				}
			}
		 
		      
			public InventoryRecord[] SearchInventoryRecordsByQueryModel(out String message,QueryInventoryRecordModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchInventoryRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchInventoryRecordsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchInventoryRecordsByQueryModel."));
				}
			}
		 
		      
			public InventoryRecord[] SearchPagedInventoryRecordsByQueryModel(out PagerInfo pager,QueryInventoryRecordModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedInventoryRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedInventoryRecordsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedInventoryRecordsByQueryModel."));
				}
			}
		 
		      
			public Manufacturer GetManufacturer(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetManufacturer....."));
				try
				{ 
					return pharmacyServcie.GetManufacturer(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetManufacturer."));
				}
			}
		 
		      
			public bool AddManufacturer(out String msg,Manufacturer value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddManufacturer....."));
				try
				{ 
					return pharmacyServcie.AddManufacturer(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddManufacturer."));
				}
			}
		 
		      
			public bool DeleteManufacturer(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteManufacturer....."));
				try
				{ 
					return pharmacyServcie.DeleteManufacturer(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteManufacturer."));
				}
			}
		 
		      
			public bool SaveManufacturer(out String msg,Manufacturer value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveManufacturer....."));
				try
				{ 
					return pharmacyServcie.SaveManufacturer(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveManufacturer."));
				}
			}
		 
		      
			public Manufacturer[] AllManufacturers(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllManufacturers....."));
				try
				{ 
					return pharmacyServcie.AllManufacturers(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllManufacturers."));
				}
			}
		 
		      
			public PurchaseCheckingOrderDetail[] AllPurchaseCheckingOrderDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseCheckingOrderDetails....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseCheckingOrderDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseCheckingOrderDetails."));
				}
			}
		 
		      
			public PurchaseCheckingOrderDetail[] QueryPurchaseCheckingOrderDetails(out String msg,decimal purchasepricefrom,decimal purchasepriceto,int arrivalamountfrom,int arrivalamountto,DateTime arrivaldatetimefrom,DateTime arrivaldatetimeto,int qualifiedamountfrom,int qualifiedamountto,int checkresultfrom,int checkresultto,String decription,String batchnumber,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseCheckingOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseCheckingOrderDetails(out msg,purchasepricefrom,purchasepriceto,arrivalamountfrom,arrivalamountto,arrivaldatetimefrom,arrivaldatetimeto,qualifiedamountfrom,qualifiedamountto,checkresultfrom,checkresultto,decription,batchnumber,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseCheckingOrderDetails."));
				}
			}
		 
		      
			public PurchaseCheckingOrderDetail[] QueryPagedPurchaseCheckingOrderDetails(out PagerInfo pager,decimal purchasepricefrom,decimal purchasepriceto,int arrivalamountfrom,int arrivalamountto,DateTime arrivaldatetimefrom,DateTime arrivaldatetimeto,int qualifiedamountfrom,int qualifiedamountto,int checkresultfrom,int checkresultto,String decription,String batchnumber,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseCheckingOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseCheckingOrderDetails(out pager,purchasepricefrom,purchasepriceto,arrivalamountfrom,arrivalamountto,arrivaldatetimefrom,arrivaldatetimeto,qualifiedamountfrom,qualifiedamountto,checkresultfrom,checkresultto,decription,batchnumber,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseCheckingOrderDetails."));
				}
			}
		 
		      
			public PurchaseCheckingOrderDetail[] SearchPurchaseCheckingOrderDetailsByQueryModel(out String message,QueryPurchaseCheckingOrderDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseCheckingOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseCheckingOrderDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseCheckingOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseCheckingOrderDetail[] SearchPagedPurchaseCheckingOrderDetailsByQueryModel(out PagerInfo pager,QueryPurchaseCheckingOrderDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseCheckingOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseCheckingOrderDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseCheckingOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseInInventeryOrder GetPurchaseInInventeryOrder(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseInInventeryOrder....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseInInventeryOrder(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseInInventeryOrder."));
				}
			}
		 
		      
			public bool AddPurchaseInInventeryOrder(out String msg,PurchaseInInventeryOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseInInventeryOrder....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseInInventeryOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseInInventeryOrder."));
				}
			}
		 
		      
			public bool DeletePurchaseInInventeryOrder(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseInInventeryOrder....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseInInventeryOrder(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseInInventeryOrder."));
				}
			}
		 
		      
			public bool SavePurchaseInInventeryOrder(out String msg,PurchaseInInventeryOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseInInventeryOrder....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseInInventeryOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseInInventeryOrder."));
				}
			}
		 
		      
			public PurchaseInInventeryOrder[] AllPurchaseInInventeryOrders(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseInInventeryOrders....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseInInventeryOrders(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseInInventeryOrders."));
				}
			}
		 
		      
			public PurchaseInInventeryOrder[] QueryPurchaseInInventeryOrders(out String msg,String documentnumber,DateTime operatetimefrom,DateTime operatetimeto,int orderstatusvaluefrom,int orderstatusvalueto,String decription,String relatedorderdocumentnumber,int relatedordertypevaluefrom,int relatedordertypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseInInventeryOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseInInventeryOrders(out msg,documentnumber,operatetimefrom,operatetimeto,orderstatusvaluefrom,orderstatusvalueto,decription,relatedorderdocumentnumber,relatedordertypevaluefrom,relatedordertypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseInInventeryOrders."));
				}
			}
		 
		      
			public PurchaseInInventeryOrder[] QueryPagedPurchaseInInventeryOrders(out PagerInfo pager,String documentnumber,DateTime operatetimefrom,DateTime operatetimeto,int orderstatusvaluefrom,int orderstatusvalueto,String decription,String relatedorderdocumentnumber,int relatedordertypevaluefrom,int relatedordertypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseInInventeryOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseInInventeryOrders(out pager,documentnumber,operatetimefrom,operatetimeto,orderstatusvaluefrom,orderstatusvalueto,decription,relatedorderdocumentnumber,relatedordertypevaluefrom,relatedordertypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseInInventeryOrders."));
				}
			}
		 
		      
			public PurchaseInInventeryOrder[] SearchPurchaseInInventeryOrdersByQueryModel(out String message,QueryPurchaseInInventeryOrderModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseInInventeryOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseInInventeryOrdersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseInInventeryOrdersByQueryModel."));
				}
			}
		 
		      
			public PurchaseInInventeryOrder[] SearchPagedPurchaseInInventeryOrdersByQueryModel(out PagerInfo pager,QueryPurchaseInInventeryOrderModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseInInventeryOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseInInventeryOrdersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseInInventeryOrdersByQueryModel."));
				}
			}
		 
		      
			public PurchaseInInventeryOrderDetail GetPurchaseInInventeryOrderDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseInInventeryOrderDetail....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseInInventeryOrderDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseInInventeryOrderDetail."));
				}
			}
		 
		      
			public bool AddPurchaseInInventeryOrderDetail(out String msg,PurchaseInInventeryOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseInInventeryOrderDetail....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseInInventeryOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseInInventeryOrderDetail."));
				}
			}
		 
		      
			public bool DeletePurchaseInInventeryOrderDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseInInventeryOrderDetail....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseInInventeryOrderDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseInInventeryOrderDetail."));
				}
			}
		 
		      
			public bool SavePurchaseInInventeryOrderDetail(out String msg,PurchaseInInventeryOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseInInventeryOrderDetail....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseInInventeryOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseInInventeryOrderDetail."));
				}
			}
		 
		      
			public PurchaseInInventeryOrderDetail[] AllPurchaseInInventeryOrderDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseInInventeryOrderDetails....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseInInventeryOrderDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseInInventeryOrderDetails."));
				}
			}
		 
		      
			public PurchaseInInventeryOrderDetail[] QueryPurchaseInInventeryOrderDetails(out String msg,decimal purchasepricefrom,decimal purchasepriceto,String batchnumber,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,int arrivalamountfrom,int arrivalamountto,DateTime arrivaldatetimefrom,DateTime arrivaldatetimeto,String decription)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseInInventeryOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseInInventeryOrderDetails(out msg,purchasepricefrom,purchasepriceto,batchnumber,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,arrivalamountfrom,arrivalamountto,arrivaldatetimefrom,arrivaldatetimeto,decription);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseInInventeryOrderDetails."));
				}
			}
		 
		      
			public PurchaseInInventeryOrderDetail[] QueryPagedPurchaseInInventeryOrderDetails(out PagerInfo pager,decimal purchasepricefrom,decimal purchasepriceto,String batchnumber,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,int arrivalamountfrom,int arrivalamountto,DateTime arrivaldatetimefrom,DateTime arrivaldatetimeto,String decription,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseInInventeryOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseInInventeryOrderDetails(out pager,purchasepricefrom,purchasepriceto,batchnumber,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,arrivalamountfrom,arrivalamountto,arrivaldatetimefrom,arrivaldatetimeto,decription,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseInInventeryOrderDetails."));
				}
			}
		 
		      
			public PurchaseInInventeryOrderDetail[] SearchPurchaseInInventeryOrderDetailsByQueryModel(out String message,QueryPurchaseInInventeryOrderDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseInInventeryOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseInInventeryOrderDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseInInventeryOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseInInventeryOrderDetail[] SearchPagedPurchaseInInventeryOrderDetailsByQueryModel(out PagerInfo pager,QueryPurchaseInInventeryOrderDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseInInventeryOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseInInventeryOrderDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseInInventeryOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseManageCategory GetPurchaseManageCategory(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseManageCategory....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseManageCategory(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseManageCategory."));
				}
			}
		 
		      
			public bool AddPurchaseManageCategory(out String msg,PurchaseManageCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseManageCategory....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseManageCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseManageCategory."));
				}
			}
		 
		      
			public bool DeletePurchaseManageCategory(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseManageCategory....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseManageCategory(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseManageCategory."));
				}
			}
		 
		      
			public bool SavePurchaseManageCategory(out String msg,PurchaseManageCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseManageCategory....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseManageCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseManageCategory."));
				}
			}
		 
		      
			public PurchaseManageCategory[] AllPurchaseManageCategorys(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseManageCategorys....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseManageCategorys(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseManageCategorys."));
				}
			}
		 
		      
			public PurchaseManageCategory[] QueryPurchaseManageCategorys(out String msg,String name,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseManageCategorys....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseManageCategorys(out msg,name,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseManageCategorys."));
				}
			}
		 
		      
			public PurchaseManageCategory[] QueryPagedPurchaseManageCategorys(out PagerInfo pager,String name,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseManageCategorys....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseManageCategorys(out pager,name,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseManageCategorys."));
				}
			}
		 
		      
			public PurchaseManageCategory[] SearchPurchaseManageCategorysByQueryModel(out String message,QueryPurchaseManageCategoryModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseManageCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseManageCategorysByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseManageCategorysByQueryModel."));
				}
			}
		 
		      
			public PurchaseManageCategory[] SearchPagedPurchaseManageCategorysByQueryModel(out PagerInfo pager,QueryPurchaseManageCategoryModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseManageCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseManageCategorysByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseManageCategorysByQueryModel."));
				}
			}
		 
		      
			public bool AddGSPLicense(out String msg,GSPLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddGSPLicense....."));
				try
				{ 
					return pharmacyServcie.AddGSPLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddGSPLicense."));
				}
			}
		 
		      
			public bool DeleteGSPLicense(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteGSPLicense....."));
				try
				{ 
					return pharmacyServcie.DeleteGSPLicense(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteGSPLicense."));
				}
			}
		 
		      
			public bool SaveGSPLicense(out String msg,GSPLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveGSPLicense....."));
				try
				{ 
					return pharmacyServcie.SaveGSPLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveGSPLicense."));
				}
			}
		 
		      
			public GSPLicense[] AllGSPLicenses(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllGSPLicenses....."));
				try
				{ 
					return pharmacyServcie.AllGSPLicenses(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllGSPLicenses."));
				}
			}
		 
		      
			public GSPLicense[] QueryGSPLicenses(out String msg,String legalperson,String header,String qualityheader,String warehouseaddress,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryGSPLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryGSPLicenses(out msg,legalperson,header,qualityheader,warehouseaddress,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryGSPLicenses."));
				}
			}
		 
		      
			public GSPLicense[] QueryPagedGSPLicenses(out PagerInfo pager,String legalperson,String header,String qualityheader,String warehouseaddress,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedGSPLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryPagedGSPLicenses(out pager,legalperson,header,qualityheader,warehouseaddress,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedGSPLicenses."));
				}
			}
		 
		      
			public GSPLicense[] SearchGSPLicensesByQueryModel(out String message,QueryGSPLicenseModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchGSPLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchGSPLicensesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchGSPLicensesByQueryModel."));
				}
			}
		 
		      
			public GSPLicense[] SearchPagedGSPLicensesByQueryModel(out PagerInfo pager,QueryGSPLicenseModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedGSPLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedGSPLicensesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedGSPLicensesByQueryModel."));
				}
			}
		 
		      
			public GMPLicense GetGMPLicense(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetGMPLicense....."));
				try
				{ 
					return pharmacyServcie.GetGMPLicense(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetGMPLicense."));
				}
			}
		 
		      
			public bool AddGMPLicense(out String msg,GMPLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddGMPLicense....."));
				try
				{ 
					return pharmacyServcie.AddGMPLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddGMPLicense."));
				}
			}
		 
		      
			public bool DeleteGMPLicense(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteGMPLicense....."));
				try
				{ 
					return pharmacyServcie.DeleteGMPLicense(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteGMPLicense."));
				}
			}
		 
		      
			public bool SaveGMPLicense(out String msg,GMPLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveGMPLicense....."));
				try
				{ 
					return pharmacyServcie.SaveGMPLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveGMPLicense."));
				}
			}
		 
		      
			public GMPLicense[] AllGMPLicenses(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllGMPLicenses....."));
				try
				{ 
					return pharmacyServcie.AllGMPLicenses(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllGMPLicenses."));
				}
			}
		 
		      
			public GMPLicense[] QueryGMPLicenses(out String msg,String certificationscope,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryGMPLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryGMPLicenses(out msg,certificationscope,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryGMPLicenses."));
				}
			}
		 
		      
			public GMPLicense[] QueryPagedGMPLicenses(out PagerInfo pager,String certificationscope,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedGMPLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryPagedGMPLicenses(out pager,certificationscope,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedGMPLicenses."));
				}
			}
		 
		      
			public GMPLicense[] SearchGMPLicensesByQueryModel(out String message,QueryGMPLicenseModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchGMPLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchGMPLicensesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchGMPLicensesByQueryModel."));
				}
			}
		 
		      
			public GMPLicense[] SearchPagedGMPLicensesByQueryModel(out PagerInfo pager,QueryGMPLicenseModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedGMPLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedGMPLicensesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedGMPLicensesByQueryModel."));
				}
			}
		 
		      
			public BusinessLicense GetBusinessLicense(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.GetBusinessLicense(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetBusinessLicense."));
				}
			}
		 
		      
			public bool AddBusinessLicense(out String msg,BusinessLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.AddBusinessLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddBusinessLicense."));
				}
			}
		 
		      
			public bool DeleteBusinessLicense(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.DeleteBusinessLicense(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteBusinessLicense."));
				}
			}
		 
		      
			public bool SaveBusinessLicense(out String msg,BusinessLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.SaveBusinessLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveBusinessLicense."));
				}
			}
		 
		      
			public BusinessLicense[] AllBusinessLicenses(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllBusinessLicenses....."));
				try
				{ 
					return pharmacyServcie.AllBusinessLicenses(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllBusinessLicenses."));
				}
			}
		 
		      
			public BusinessLicense[] QueryBusinessLicenses(out String msg,int registeredcapitalfrom,int registeredcapitalto,int paidincapitalfrom,int paidincapitalto,String corporatenature,String businessscope,DateTime establishmentdatefrom,DateTime establishmentdateto,String inspectiondate,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryBusinessLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryBusinessLicenses(out msg,registeredcapitalfrom,registeredcapitalto,paidincapitalfrom,paidincapitalto,corporatenature,businessscope,establishmentdatefrom,establishmentdateto,inspectiondate,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryBusinessLicenses."));
				}
			}
		 
		      
			public BusinessLicense[] QueryPagedBusinessLicenses(out PagerInfo pager,int registeredcapitalfrom,int registeredcapitalto,int paidincapitalfrom,int paidincapitalto,String corporatenature,String businessscope,DateTime establishmentdatefrom,DateTime establishmentdateto,String inspectiondate,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedBusinessLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryPagedBusinessLicenses(out pager,registeredcapitalfrom,registeredcapitalto,paidincapitalfrom,paidincapitalto,corporatenature,businessscope,establishmentdatefrom,establishmentdateto,inspectiondate,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedBusinessLicenses."));
				}
			}
		 
		      
			public BusinessLicense[] SearchBusinessLicensesByQueryModel(out String message,QueryBusinessLicenseModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchBusinessLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchBusinessLicensesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchBusinessLicensesByQueryModel."));
				}
			}
		 
		      
			public BusinessLicense[] SearchPagedBusinessLicensesByQueryModel(out PagerInfo pager,QueryBusinessLicenseModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedBusinessLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedBusinessLicensesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedBusinessLicensesByQueryModel."));
				}
			}
		 
		      
			public MedicineProductionLicense GetMedicineProductionLicense(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetMedicineProductionLicense....."));
				try
				{ 
					return pharmacyServcie.GetMedicineProductionLicense(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetMedicineProductionLicense."));
				}
			}
		 
		      
			public bool AddMedicineProductionLicense(out String msg,MedicineProductionLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddMedicineProductionLicense....."));
				try
				{ 
					return pharmacyServcie.AddMedicineProductionLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddMedicineProductionLicense."));
				}
			}
		 
		      
			public bool DeleteMedicineProductionLicense(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteMedicineProductionLicense....."));
				try
				{ 
					return pharmacyServcie.DeleteMedicineProductionLicense(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteMedicineProductionLicense."));
				}
			}
		 
		      
			public bool SaveMedicineProductionLicense(out String msg,MedicineProductionLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveMedicineProductionLicense....."));
				try
				{ 
					return pharmacyServcie.SaveMedicineProductionLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveMedicineProductionLicense."));
				}
			}
		 
		      
			public MedicineProductionLicense[] AllMedicineProductionLicenses(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllMedicineProductionLicenses....."));
				try
				{ 
					return pharmacyServcie.AllMedicineProductionLicenses(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllMedicineProductionLicenses."));
				}
			}
		 
		      
			public MedicineProductionLicense[] QueryMedicineProductionLicenses(out String msg,String legalperson,String header,String productaddress,String corporatenature,String categorycode,String productscope,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryMedicineProductionLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryMedicineProductionLicenses(out msg,legalperson,header,productaddress,corporatenature,categorycode,productscope,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryMedicineProductionLicenses."));
				}
			}
		 
		      
			public MedicineProductionLicense[] QueryPagedMedicineProductionLicenses(out PagerInfo pager,String legalperson,String header,String productaddress,String corporatenature,String categorycode,String productscope,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedMedicineProductionLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryPagedMedicineProductionLicenses(out pager,legalperson,header,productaddress,corporatenature,categorycode,productscope,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedMedicineProductionLicenses."));
				}
			}
		 
		      
			public MedicineProductionLicense[] SearchMedicineProductionLicensesByQueryModel(out String message,QueryMedicineProductionLicenseModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchMedicineProductionLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchMedicineProductionLicensesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchMedicineProductionLicensesByQueryModel."));
				}
			}
		 
		      
			public MedicineProductionLicense[] SearchPagedMedicineProductionLicensesByQueryModel(out PagerInfo pager,QueryMedicineProductionLicenseModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedMedicineProductionLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedMedicineProductionLicensesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedMedicineProductionLicensesByQueryModel."));
				}
			}
		 
		      
			public MedicineBusinessLicense GetMedicineBusinessLicense(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetMedicineBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.GetMedicineBusinessLicense(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetMedicineBusinessLicense."));
				}
			}
		 
		      
			public bool AddMedicineBusinessLicense(out String msg,MedicineBusinessLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddMedicineBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.AddMedicineBusinessLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddMedicineBusinessLicense."));
				}
			}
		 
		      
			public bool DeleteMedicineBusinessLicense(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteMedicineBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.DeleteMedicineBusinessLicense(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteMedicineBusinessLicense."));
				}
			}
		 
		      
			public bool SaveMedicineBusinessLicense(out String msg,MedicineBusinessLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveMedicineBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.SaveMedicineBusinessLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveMedicineBusinessLicense."));
				}
			}
		 
		      
			public MedicineBusinessLicense[] AllMedicineBusinessLicenses(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllMedicineBusinessLicenses....."));
				try
				{ 
					return pharmacyServcie.AllMedicineBusinessLicenses(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllMedicineBusinessLicenses."));
				}
			}
		 
		      
			public MedicineBusinessLicense[] QueryMedicineBusinessLicenses(out String msg,String legalperson,String header,String qualityheader,String warehouseaddress,String businessscope,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryMedicineBusinessLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryMedicineBusinessLicenses(out msg,legalperson,header,qualityheader,warehouseaddress,businessscope,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryMedicineBusinessLicenses."));
				}
			}
		 
		      
			public MedicineBusinessLicense[] QueryPagedMedicineBusinessLicenses(out PagerInfo pager,String legalperson,String header,String qualityheader,String warehouseaddress,String businessscope,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedMedicineBusinessLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryPagedMedicineBusinessLicenses(out pager,legalperson,header,qualityheader,warehouseaddress,businessscope,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedMedicineBusinessLicenses."));
				}
			}
		 
		      
			public MedicineBusinessLicense[] SearchMedicineBusinessLicensesByQueryModel(out String message,QueryMedicineBusinessLicenseModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchMedicineBusinessLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchMedicineBusinessLicensesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchMedicineBusinessLicensesByQueryModel."));
				}
			}
		 
		      
			public MedicineBusinessLicense[] SearchPagedMedicineBusinessLicensesByQueryModel(out PagerInfo pager,QueryMedicineBusinessLicenseModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedMedicineBusinessLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedMedicineBusinessLicensesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedMedicineBusinessLicensesByQueryModel."));
				}
			}
		 
		      
			public InstrumentsBusinessLicense GetInstrumentsBusinessLicense(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetInstrumentsBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.GetInstrumentsBusinessLicense(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetInstrumentsBusinessLicense."));
				}
			}
		 
		      
			public bool AddInstrumentsBusinessLicense(out String msg,InstrumentsBusinessLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddInstrumentsBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.AddInstrumentsBusinessLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddInstrumentsBusinessLicense."));
				}
			}
		 
		      
			public bool DeleteInstrumentsBusinessLicense(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteInstrumentsBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.DeleteInstrumentsBusinessLicense(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteInstrumentsBusinessLicense."));
				}
			}
		 
		      
			public bool SaveInstrumentsBusinessLicense(out String msg,InstrumentsBusinessLicense value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveInstrumentsBusinessLicense....."));
				try
				{ 
					return pharmacyServcie.SaveInstrumentsBusinessLicense(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveInstrumentsBusinessLicense."));
				}
			}
		 
		      
			public InstrumentsBusinessLicense[] AllInstrumentsBusinessLicenses(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllInstrumentsBusinessLicenses....."));
				try
				{ 
					return pharmacyServcie.AllInstrumentsBusinessLicenses(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllInstrumentsBusinessLicenses."));
				}
			}
		 
		      
			public InstrumentsBusinessLicense[] QueryInstrumentsBusinessLicenses(out String msg,String legalperson,String header,String qualityheader,String warehouseaddress,String businessscope,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryInstrumentsBusinessLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryInstrumentsBusinessLicenses(out msg,legalperson,header,qualityheader,warehouseaddress,businessscope,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryInstrumentsBusinessLicenses."));
				}
			}
		 
		      
			public InstrumentsBusinessLicense[] QueryPagedInstrumentsBusinessLicenses(out PagerInfo pager,String legalperson,String header,String qualityheader,String warehouseaddress,String businessscope,String name,String decription,String code,bool enabled,bool queryenabled,String unitname,String regaddress,String licensecode,DateTime startdatefrom,DateTime startdateto,DateTime outdatefrom,DateTime outdateto,DateTime issuancedatefrom,DateTime issuancedateto,String issuanceorg,bool valid,bool queryvalid,int licensetypevaluefrom,int licensetypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedInstrumentsBusinessLicenses....."));
				try
				{ 
					return pharmacyServcie.QueryPagedInstrumentsBusinessLicenses(out pager,legalperson,header,qualityheader,warehouseaddress,businessscope,name,decription,code,enabled,queryenabled,unitname,regaddress,licensecode,startdatefrom,startdateto,outdatefrom,outdateto,issuancedatefrom,issuancedateto,issuanceorg,valid,queryvalid,licensetypevaluefrom,licensetypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedInstrumentsBusinessLicenses."));
				}
			}
		 
		      
			public InstrumentsBusinessLicense[] SearchInstrumentsBusinessLicensesByQueryModel(out String message,QueryInstrumentsBusinessLicenseModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchInstrumentsBusinessLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchInstrumentsBusinessLicensesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchInstrumentsBusinessLicensesByQueryModel."));
				}
			}
		 
		      
			public InstrumentsBusinessLicense[] SearchPagedInstrumentsBusinessLicensesByQueryModel(out PagerInfo pager,QueryInstrumentsBusinessLicenseModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedInstrumentsBusinessLicensesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedInstrumentsBusinessLicensesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedInstrumentsBusinessLicensesByQueryModel."));
				}
			}
		 
		      
			public PurchaseReceivingOrder[] SearchPagedPurchaseReceivingOrdersByQueryModel(out PagerInfo pager,QueryPurchaseReceivingOrderModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseReceivingOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseReceivingOrdersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseReceivingOrdersByQueryModel."));
				}
			}
		 
		      
			public PurchaseReceivingOrderDetail GetPurchaseReceivingOrderDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseReceivingOrderDetail....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseReceivingOrderDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseReceivingOrderDetail."));
				}
			}
		 
		      
			public bool AddPurchaseReceivingOrderDetail(out String msg,PurchaseReceivingOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseReceivingOrderDetail....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseReceivingOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseReceivingOrderDetail."));
				}
			}
		 
		      
			public bool DeletePurchaseReceivingOrderDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseReceivingOrderDetail....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseReceivingOrderDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseReceivingOrderDetail."));
				}
			}
		 
		      
			public bool SavePurchaseReceivingOrderDetail(out String msg,PurchaseReceivingOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseReceivingOrderDetail....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseReceivingOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseReceivingOrderDetail."));
				}
			}
		 
		      
			public PurchaseReceivingOrderDetail[] AllPurchaseReceivingOrderDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseReceivingOrderDetails....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseReceivingOrderDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseReceivingOrderDetails."));
				}
			}
		 
		      
			public PurchaseReceivingOrderDetail[] QueryPurchaseReceivingOrderDetails(out String msg,int amountfrom,int amountto,decimal purchasepricefrom,decimal purchasepriceto,int actualamountfrom,int actualamountto,int receiveamountfrom,int receiveamountto,int rejectamountfrom,int rejectamountto,String rejectreason,String rejecttrace,bool iscompanypurchase,bool queryiscompanypurchase,String transportmethod,bool istransportmethod,bool queryistransportmethod,String transporttemperature,String temperaturestatus,bool istransporttemperature,bool queryistransporttemperature,int checkresultfrom,int checkresultto,String decription)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseReceivingOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseReceivingOrderDetails(out msg,amountfrom,amountto,purchasepricefrom,purchasepriceto,actualamountfrom,actualamountto,receiveamountfrom,receiveamountto,rejectamountfrom,rejectamountto,rejectreason,rejecttrace,iscompanypurchase,queryiscompanypurchase,transportmethod,istransportmethod,queryistransportmethod,transporttemperature,temperaturestatus,istransporttemperature,queryistransporttemperature,checkresultfrom,checkresultto,decription);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseReceivingOrderDetails."));
				}
			}
		 
		      
			public PurchaseReceivingOrderDetail[] QueryPagedPurchaseReceivingOrderDetails(out PagerInfo pager,int amountfrom,int amountto,decimal purchasepricefrom,decimal purchasepriceto,int actualamountfrom,int actualamountto,int receiveamountfrom,int receiveamountto,int rejectamountfrom,int rejectamountto,String rejectreason,String rejecttrace,bool iscompanypurchase,bool queryiscompanypurchase,String transportmethod,bool istransportmethod,bool queryistransportmethod,String transporttemperature,String temperaturestatus,bool istransporttemperature,bool queryistransporttemperature,int checkresultfrom,int checkresultto,String decription,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseReceivingOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseReceivingOrderDetails(out pager,amountfrom,amountto,purchasepricefrom,purchasepriceto,actualamountfrom,actualamountto,receiveamountfrom,receiveamountto,rejectamountfrom,rejectamountto,rejectreason,rejecttrace,iscompanypurchase,queryiscompanypurchase,transportmethod,istransportmethod,queryistransportmethod,transporttemperature,temperaturestatus,istransporttemperature,queryistransporttemperature,checkresultfrom,checkresultto,decription,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseReceivingOrderDetails."));
				}
			}
		 
		      
			public PurchaseReceivingOrderDetail[] SearchPurchaseReceivingOrderDetailsByQueryModel(out String message,QueryPurchaseReceivingOrderDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseReceivingOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseReceivingOrderDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseReceivingOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseReceivingOrderDetail[] SearchPagedPurchaseReceivingOrderDetailsByQueryModel(out PagerInfo pager,QueryPurchaseReceivingOrderDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseReceivingOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseReceivingOrderDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseReceivingOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseUnit GetPurchaseUnit(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseUnit....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseUnit(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseUnit."));
				}
			}
		 
		      
			public bool AddPurchaseUnit(out String msg,PurchaseUnit value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseUnit....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseUnit(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseUnit."));
				}
			}
		 
		      
			public bool DeletePurchaseUnit(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseUnit....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseUnit(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseUnit."));
				}
			}
		 
		      
			public bool SavePurchaseUnit(out String msg,PurchaseUnit value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseUnit....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseUnit(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseUnit."));
				}
			}
		 
		      
			public PurchaseUnit[] AllPurchaseUnits(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseUnits....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseUnits(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseUnits."));
				}
			}
		 
		      
			public PurchaseUnit[] QueryPurchaseUnits(out String msg,bool valid,bool queryvalid,String validremark,bool islock,bool queryislock,String lockremark,String receiveaddress,String name,String code,String pinyincode,String contactname,String contacttel,String description,String legalperson,String header,String businessscope,String salesamount,String fax,String email,String webaddress,bool isoutdate,bool queryisoutdate,DateTime outdatefrom,DateTime outdateto,bool isgsplicenseoutdate,bool queryisgsplicenseoutdate,DateTime gsplicenseoutdatefrom,DateTime gsplicenseoutdateto,bool isgmplicenseoutdate,bool queryisgmplicenseoutdate,DateTime gmplicenseoutdatefrom,DateTime gmplicenseoutdateto,bool isbusinesslicenseoutdate,bool queryisbusinesslicenseoutdate,DateTime businesslicenseeoutdatefrom,DateTime businesslicenseeoutdateto,bool ismedicineproductionlicenseoutdate,bool queryismedicineproductionlicenseoutdate,DateTime medicineproductionlicenseoutdatefrom,DateTime medicineproductionlicenseoutdateto,bool ismedicinebusinesslicenseoutdate,bool queryismedicinebusinesslicenseoutdate,DateTime medicinebusinesslicenseoutdatefrom,DateTime medicinebusinesslicenseoutdateto,bool isinstrumentsproductionlicenseoutdate,bool queryisinstrumentsproductionlicenseoutdate,DateTime instrumentsproductionlicenseoutdatefrom,DateTime instrumentsproductionlicenseoutdateto,bool isinstrumentsbusinesslicenseoutdate,bool queryisinstrumentsbusinesslicenseoutdate,DateTime instrumentsbusinesslicenseoutdatefrom,DateTime instrumentsbusinesslicenseoutdateto,String taxregistrationcode,DateTime lastannualdtefrom,DateTime lastannualdteto,bool isapproval,bool queryisapproval,int approvalstatusvaluefrom,int approvalstatusvalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseUnits....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseUnits(out msg,valid,queryvalid,validremark,islock,queryislock,lockremark,receiveaddress,name,code,pinyincode,contactname,contacttel,description,legalperson,header,businessscope,salesamount,fax,email,webaddress,isoutdate,queryisoutdate,outdatefrom,outdateto,isgsplicenseoutdate,queryisgsplicenseoutdate,gsplicenseoutdatefrom,gsplicenseoutdateto,isgmplicenseoutdate,queryisgmplicenseoutdate,gmplicenseoutdatefrom,gmplicenseoutdateto,isbusinesslicenseoutdate,queryisbusinesslicenseoutdate,businesslicenseeoutdatefrom,businesslicenseeoutdateto,ismedicineproductionlicenseoutdate,queryismedicineproductionlicenseoutdate,medicineproductionlicenseoutdatefrom,medicineproductionlicenseoutdateto,ismedicinebusinesslicenseoutdate,queryismedicinebusinesslicenseoutdate,medicinebusinesslicenseoutdatefrom,medicinebusinesslicenseoutdateto,isinstrumentsproductionlicenseoutdate,queryisinstrumentsproductionlicenseoutdate,instrumentsproductionlicenseoutdatefrom,instrumentsproductionlicenseoutdateto,isinstrumentsbusinesslicenseoutdate,queryisinstrumentsbusinesslicenseoutdate,instrumentsbusinesslicenseoutdatefrom,instrumentsbusinesslicenseoutdateto,taxregistrationcode,lastannualdtefrom,lastannualdteto,isapproval,queryisapproval,approvalstatusvaluefrom,approvalstatusvalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseUnits."));
				}
			}
		 
		      
			public PurchaseUnit[] QueryPagedPurchaseUnits(out PagerInfo pager,bool valid,bool queryvalid,String validremark,bool islock,bool queryislock,String lockremark,String receiveaddress,String name,String code,String pinyincode,String contactname,String contacttel,String description,String legalperson,String header,String businessscope,String salesamount,String fax,String email,String webaddress,bool isoutdate,bool queryisoutdate,DateTime outdatefrom,DateTime outdateto,bool isgsplicenseoutdate,bool queryisgsplicenseoutdate,DateTime gsplicenseoutdatefrom,DateTime gsplicenseoutdateto,bool isgmplicenseoutdate,bool queryisgmplicenseoutdate,DateTime gmplicenseoutdatefrom,DateTime gmplicenseoutdateto,bool isbusinesslicenseoutdate,bool queryisbusinesslicenseoutdate,DateTime businesslicenseeoutdatefrom,DateTime businesslicenseeoutdateto,bool ismedicineproductionlicenseoutdate,bool queryismedicineproductionlicenseoutdate,DateTime medicineproductionlicenseoutdatefrom,DateTime medicineproductionlicenseoutdateto,bool ismedicinebusinesslicenseoutdate,bool queryismedicinebusinesslicenseoutdate,DateTime medicinebusinesslicenseoutdatefrom,DateTime medicinebusinesslicenseoutdateto,bool isinstrumentsproductionlicenseoutdate,bool queryisinstrumentsproductionlicenseoutdate,DateTime instrumentsproductionlicenseoutdatefrom,DateTime instrumentsproductionlicenseoutdateto,bool isinstrumentsbusinesslicenseoutdate,bool queryisinstrumentsbusinesslicenseoutdate,DateTime instrumentsbusinesslicenseoutdatefrom,DateTime instrumentsbusinesslicenseoutdateto,String taxregistrationcode,DateTime lastannualdtefrom,DateTime lastannualdteto,bool isapproval,bool queryisapproval,int approvalstatusvaluefrom,int approvalstatusvalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseUnits....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseUnits(out pager,valid,queryvalid,validremark,islock,queryislock,lockremark,receiveaddress,name,code,pinyincode,contactname,contacttel,description,legalperson,header,businessscope,salesamount,fax,email,webaddress,isoutdate,queryisoutdate,outdatefrom,outdateto,isgsplicenseoutdate,queryisgsplicenseoutdate,gsplicenseoutdatefrom,gsplicenseoutdateto,isgmplicenseoutdate,queryisgmplicenseoutdate,gmplicenseoutdatefrom,gmplicenseoutdateto,isbusinesslicenseoutdate,queryisbusinesslicenseoutdate,businesslicenseeoutdatefrom,businesslicenseeoutdateto,ismedicineproductionlicenseoutdate,queryismedicineproductionlicenseoutdate,medicineproductionlicenseoutdatefrom,medicineproductionlicenseoutdateto,ismedicinebusinesslicenseoutdate,queryismedicinebusinesslicenseoutdate,medicinebusinesslicenseoutdatefrom,medicinebusinesslicenseoutdateto,isinstrumentsproductionlicenseoutdate,queryisinstrumentsproductionlicenseoutdate,instrumentsproductionlicenseoutdatefrom,instrumentsproductionlicenseoutdateto,isinstrumentsbusinesslicenseoutdate,queryisinstrumentsbusinesslicenseoutdate,instrumentsbusinesslicenseoutdatefrom,instrumentsbusinesslicenseoutdateto,taxregistrationcode,lastannualdtefrom,lastannualdteto,isapproval,queryisapproval,approvalstatusvaluefrom,approvalstatusvalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseUnits."));
				}
			}
		 
		      
			public PurchaseUnit[] SearchPurchaseUnitsByQueryModel(out String message,QueryPurchaseUnitModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseUnitsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseUnitsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseUnitsByQueryModel."));
				}
			}
		 
		      
			public PurchaseUnit[] SearchPagedPurchaseUnitsByQueryModel(out PagerInfo pager,QueryPurchaseUnitModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseUnitsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseUnitsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseUnitsByQueryModel."));
				}
			}
		 
		      
			public PurchaseUnitBuyer GetPurchaseUnitBuyer(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseUnitBuyer....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseUnitBuyer(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseUnitBuyer."));
				}
			}
		 
		      
			public bool AddPurchaseUnitBuyer(out String msg,PurchaseUnitBuyer value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseUnitBuyer....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseUnitBuyer(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseUnitBuyer."));
				}
			}
		 
		      
			public bool DeletePurchaseUnitBuyer(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseUnitBuyer....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseUnitBuyer(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseUnitBuyer."));
				}
			}
		 
		      
			public bool SavePurchaseUnitBuyer(out String msg,PurchaseUnitBuyer value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseUnitBuyer....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseUnitBuyer(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseUnitBuyer."));
				}
			}
		 
		      
			public PurchaseUnitBuyer[] AllPurchaseUnitBuyers(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseUnitBuyers....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseUnitBuyers(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseUnitBuyers."));
				}
			}
		 
		      
			public PurchaseUnitBuyer[] QueryPurchaseUnitBuyers(out String msg,DateTime outdatefrom,DateTime outdateto,int purchaselimittypevaluefrom,int purchaselimittypevalueto,String name,String idnumber,String tel,String address,DateTime birthdayfrom,DateTime birthdayto,String gender,String createuser,String updateuser,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool valid,bool queryvalid,bool enabled,bool queryenabled,bool ischecked,bool queryischecked,String idchecktype)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseUnitBuyers....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseUnitBuyers(out msg,outdatefrom,outdateto,purchaselimittypevaluefrom,purchaselimittypevalueto,name,idnumber,tel,address,birthdayfrom,birthdayto,gender,createuser,updateuser,createtimefrom,createtimeto,updatetimefrom,updatetimeto,valid,queryvalid,enabled,queryenabled,ischecked,queryischecked,idchecktype);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseUnitBuyers."));
				}
			}
		 
		      
			public PurchaseUnitBuyer[] QueryPagedPurchaseUnitBuyers(out PagerInfo pager,DateTime outdatefrom,DateTime outdateto,int purchaselimittypevaluefrom,int purchaselimittypevalueto,String name,String idnumber,String tel,String address,DateTime birthdayfrom,DateTime birthdayto,String gender,String createuser,String updateuser,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool valid,bool queryvalid,bool enabled,bool queryenabled,bool ischecked,bool queryischecked,String idchecktype,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseUnitBuyers....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseUnitBuyers(out pager,outdatefrom,outdateto,purchaselimittypevaluefrom,purchaselimittypevalueto,name,idnumber,tel,address,birthdayfrom,birthdayto,gender,createuser,updateuser,createtimefrom,createtimeto,updatetimefrom,updatetimeto,valid,queryvalid,enabled,queryenabled,ischecked,queryischecked,idchecktype,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseUnitBuyers."));
				}
			}
		 
		      
			public PurchaseUnitBuyer[] SearchPurchaseUnitBuyersByQueryModel(out String message,QueryPurchaseUnitBuyerModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseUnitBuyersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseUnitBuyersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseUnitBuyersByQueryModel."));
				}
			}
		 
		      
			public PurchaseUnitBuyer[] SearchPagedPurchaseUnitBuyersByQueryModel(out PagerInfo pager,QueryPurchaseUnitBuyerModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseUnitBuyersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseUnitBuyersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseUnitBuyersByQueryModel."));
				}
			}
		 
		      
			public PurchaseUnitDeliverer GetPurchaseUnitDeliverer(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseUnitDeliverer....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseUnitDeliverer(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseUnitDeliverer."));
				}
			}
		 
		      
			public bool AddPurchaseUnitDeliverer(out String msg,PurchaseUnitDeliverer value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseUnitDeliverer....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseUnitDeliverer(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseUnitDeliverer."));
				}
			}
		 
		      
			public bool DeletePurchaseUnitDeliverer(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseUnitDeliverer....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseUnitDeliverer(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseUnitDeliverer."));
				}
			}
		 
		      
			public bool SavePurchaseUnitDeliverer(out String msg,PurchaseUnitDeliverer value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseUnitDeliverer....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseUnitDeliverer(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseUnitDeliverer."));
				}
			}
		 
		      
			public Module[] QueryModules(out String msg,String name,String description,String authkey,int indexfrom,int indexto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryModules....."));
				try
				{ 
					return pharmacyServcie.QueryModules(out msg,name,description,authkey,indexfrom,indexto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryModules."));
				}
			}
		 
		      
			public Module[] QueryPagedModules(out PagerInfo pager,String name,String description,String authkey,int indexfrom,int indexto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedModules....."));
				try
				{ 
					return pharmacyServcie.QueryPagedModules(out pager,name,description,authkey,indexfrom,indexto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedModules."));
				}
			}
		 
		      
			public Module[] SearchModulesByQueryModel(out String message,QueryModuleModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchModulesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchModulesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchModulesByQueryModel."));
				}
			}
		 
		      
			public Module[] SearchPagedModulesByQueryModel(out PagerInfo pager,QueryModuleModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedModulesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedModulesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedModulesByQueryModel."));
				}
			}
		 
		      
			public ModuleCatetory GetModuleCatetory(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetModuleCatetory....."));
				try
				{ 
					return pharmacyServcie.GetModuleCatetory(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetModuleCatetory."));
				}
			}
		 
		      
			public bool AddModuleCatetory(out String msg,ModuleCatetory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddModuleCatetory....."));
				try
				{ 
					return pharmacyServcie.AddModuleCatetory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddModuleCatetory."));
				}
			}
		 
		      
			public bool DeleteModuleCatetory(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteModuleCatetory....."));
				try
				{ 
					return pharmacyServcie.DeleteModuleCatetory(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteModuleCatetory."));
				}
			}
		 
		      
			public bool SaveModuleCatetory(out String msg,ModuleCatetory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveModuleCatetory....."));
				try
				{ 
					return pharmacyServcie.SaveModuleCatetory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveModuleCatetory."));
				}
			}
		 
		      
			public ModuleCatetory[] AllModuleCatetorys(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllModuleCatetorys....."));
				try
				{ 
					return pharmacyServcie.AllModuleCatetorys(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllModuleCatetorys."));
				}
			}
		 
		      
			public ModuleCatetory[] QueryModuleCatetorys(out String msg,String name,String description,int indexfrom,int indexto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryModuleCatetorys....."));
				try
				{ 
					return pharmacyServcie.QueryModuleCatetorys(out msg,name,description,indexfrom,indexto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryModuleCatetorys."));
				}
			}
		 
		      
			public ModuleCatetory[] QueryPagedModuleCatetorys(out PagerInfo pager,String name,String description,int indexfrom,int indexto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedModuleCatetorys....."));
				try
				{ 
					return pharmacyServcie.QueryPagedModuleCatetorys(out pager,name,description,indexfrom,indexto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedModuleCatetorys."));
				}
			}
		 
		      
			public ModuleCatetory[] SearchModuleCatetorysByQueryModel(out String message,QueryModuleCatetoryModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchModuleCatetorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchModuleCatetorysByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchModuleCatetorysByQueryModel."));
				}
			}
		 
		      
			public ModuleCatetory[] SearchPagedModuleCatetorysByQueryModel(out PagerInfo pager,QueryModuleCatetoryModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedModuleCatetorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedModuleCatetorysByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedModuleCatetorysByQueryModel."));
				}
			}
		 
		      
			public ModuleWithRole GetModuleWithRole(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetModuleWithRole....."));
				try
				{ 
					return pharmacyServcie.GetModuleWithRole(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetModuleWithRole."));
				}
			}
		 
		      
			public bool AddModuleWithRole(out String msg,ModuleWithRole value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddModuleWithRole....."));
				try
				{ 
					return pharmacyServcie.AddModuleWithRole(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddModuleWithRole."));
				}
			}
		 
		      
			public bool DeleteModuleWithRole(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteModuleWithRole....."));
				try
				{ 
					return pharmacyServcie.DeleteModuleWithRole(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteModuleWithRole."));
				}
			}
		 
		      
			public bool SaveModuleWithRole(out String msg,ModuleWithRole value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveModuleWithRole....."));
				try
				{ 
					return pharmacyServcie.SaveModuleWithRole(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveModuleWithRole."));
				}
			}
		 
		      
			public ModuleWithRole[] AllModuleWithRoles(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllModuleWithRoles....."));
				try
				{ 
					return pharmacyServcie.AllModuleWithRoles(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllModuleWithRoles."));
				}
			}
		 
		      
			public ModuleWithRole[] QueryModuleWithRoles(out String msg,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryModuleWithRoles....."));
				try
				{ 
					return pharmacyServcie.QueryModuleWithRoles(out msg,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryModuleWithRoles."));
				}
			}
		 
		      
			public ModuleWithRole[] QueryPagedModuleWithRoles(out PagerInfo pager,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedModuleWithRoles....."));
				try
				{ 
					return pharmacyServcie.QueryPagedModuleWithRoles(out pager,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedModuleWithRoles."));
				}
			}
		 
		      
			public ModuleWithRole[] SearchModuleWithRolesByQueryModel(out String message,QueryModuleWithRoleModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchModuleWithRolesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchModuleWithRolesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchModuleWithRolesByQueryModel."));
				}
			}
		 
		      
			public ModuleWithRole[] SearchPagedModuleWithRolesByQueryModel(out PagerInfo pager,QueryModuleWithRoleModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedModuleWithRolesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedModuleWithRolesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedModuleWithRolesByQueryModel."));
				}
			}
		 
		      
			public PharmacyFile GetPharmacyFile(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPharmacyFile....."));
				try
				{ 
					return pharmacyServcie.GetPharmacyFile(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPharmacyFile."));
				}
			}
		 
		      
			public bool AddPharmacyFile(out String msg,PharmacyFile value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPharmacyFile....."));
				try
				{ 
					return pharmacyServcie.AddPharmacyFile(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPharmacyFile."));
				}
			}
		 
		      
			public bool DeletePharmacyFile(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePharmacyFile....."));
				try
				{ 
					return pharmacyServcie.DeletePharmacyFile(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePharmacyFile."));
				}
			}
		 
		      
			public bool SavePharmacyFile(out String msg,PharmacyFile value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePharmacyFile....."));
				try
				{ 
					return pharmacyServcie.SavePharmacyFile(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePharmacyFile."));
				}
			}
		 
		      
			public PharmacyFile[] AllPharmacyFiles(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPharmacyFiles....."));
				try
				{ 
					return pharmacyServcie.AllPharmacyFiles(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPharmacyFiles."));
				}
			}
		 
		      
			public PharmacyFile[] QueryPharmacyFiles(out String msg,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String filename,String extension)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPharmacyFiles....."));
				try
				{ 
					return pharmacyServcie.QueryPharmacyFiles(out msg,createtimefrom,createtimeto,updatetimefrom,updatetimeto,filename,extension);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPharmacyFiles."));
				}
			}
		 
		      
			public PharmacyFile[] QueryPagedPharmacyFiles(out PagerInfo pager,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String filename,String extension,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPharmacyFiles....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPharmacyFiles(out pager,createtimefrom,createtimeto,updatetimefrom,updatetimeto,filename,extension,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPharmacyFiles."));
				}
			}
		 
		      
			public PharmacyFile[] SearchPharmacyFilesByQueryModel(out String message,QueryPharmacyFileModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPharmacyFilesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPharmacyFilesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPharmacyFilesByQueryModel."));
				}
			}
		 
		      
			public PharmacyFile[] SearchPagedPharmacyFilesByQueryModel(out PagerInfo pager,QueryPharmacyFileModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPharmacyFilesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPharmacyFilesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPharmacyFilesByQueryModel."));
				}
			}
		 
		      
			public PurchaseAgreement GetPurchaseAgreement(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseAgreement....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseAgreement(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseAgreement."));
				}
			}
		 
		      
			public bool AddPurchaseAgreement(out String msg,PurchaseAgreement value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseAgreement....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseAgreement(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseAgreement."));
				}
			}
		 
		      
			public bool DeletePurchaseAgreement(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseAgreement....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseAgreement(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseAgreement."));
				}
			}
		 
		      
			public bool SavePurchaseAgreement(out String msg,PurchaseAgreement value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseAgreement....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseAgreement(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseAgreement."));
				}
			}
		 
		      
			public PurchaseAgreement[] AllPurchaseAgreements(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseAgreements....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseAgreements(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseAgreements."));
				}
			}
		 
		      
			public PurchaseAgreement[] QueryPurchaseAgreements(out String msg)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseAgreements....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseAgreements(out msg);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseAgreements."));
				}
			}
		 
		      
			public PurchaseAgreement[] QueryPagedPurchaseAgreements(out PagerInfo pager,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseAgreements....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseAgreements(out pager,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseAgreements."));
				}
			}
		 
		      
			public PurchaseAgreement[] SearchPurchaseAgreementsByQueryModel(out String message,QueryPurchaseAgreementModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseAgreementsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseAgreementsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseAgreementsByQueryModel."));
				}
			}
		 
		      
			public PurchaseAgreement[] SearchPagedPurchaseAgreementsByQueryModel(out PagerInfo pager,QueryPurchaseAgreementModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseAgreementsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseAgreementsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseAgreementsByQueryModel."));
				}
			}
		 
		      
			public PurchaseCheckingOrder GetPurchaseCheckingOrder(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseCheckingOrder....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseCheckingOrder(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseCheckingOrder."));
				}
			}
		 
		      
			public bool AddPurchaseCheckingOrder(out String msg,PurchaseCheckingOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseCheckingOrder....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseCheckingOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseCheckingOrder."));
				}
			}
		 
		      
			public bool DeletePurchaseCheckingOrder(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseCheckingOrder....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseCheckingOrder(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseCheckingOrder."));
				}
			}
		 
		      
			public bool SavePurchaseCheckingOrder(out String msg,PurchaseCheckingOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseCheckingOrder....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseCheckingOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseCheckingOrder."));
				}
			}
		 
		      
			public PurchaseCheckingOrder[] AllPurchaseCheckingOrders(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseCheckingOrders....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseCheckingOrders(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseCheckingOrders."));
				}
			}
		 
		      
			public PurchaseCheckingOrder[] QueryPurchaseCheckingOrders(out String msg,String documentnumber,DateTime operatetimefrom,DateTime operatetimeto,int orderstatusvaluefrom,int orderstatusvalueto,String decription,String relatedorderdocumentnumber,int relatedordertypevaluefrom,int relatedordertypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseCheckingOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseCheckingOrders(out msg,documentnumber,operatetimefrom,operatetimeto,orderstatusvaluefrom,orderstatusvalueto,decription,relatedorderdocumentnumber,relatedordertypevaluefrom,relatedordertypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseCheckingOrders."));
				}
			}
		 
		      
			public PurchaseCheckingOrder[] QueryPagedPurchaseCheckingOrders(out PagerInfo pager,String documentnumber,DateTime operatetimefrom,DateTime operatetimeto,int orderstatusvaluefrom,int orderstatusvalueto,String decription,String relatedorderdocumentnumber,int relatedordertypevaluefrom,int relatedordertypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseCheckingOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseCheckingOrders(out pager,documentnumber,operatetimefrom,operatetimeto,orderstatusvaluefrom,orderstatusvalueto,decription,relatedorderdocumentnumber,relatedordertypevaluefrom,relatedordertypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseCheckingOrders."));
				}
			}
		 
		      
			public PurchaseCheckingOrder[] SearchPurchaseCheckingOrdersByQueryModel(out String message,QueryPurchaseCheckingOrderModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseCheckingOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseCheckingOrdersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseCheckingOrdersByQueryModel."));
				}
			}
		 
		      
			public PurchaseCheckingOrder[] SearchPagedPurchaseCheckingOrdersByQueryModel(out PagerInfo pager,QueryPurchaseCheckingOrderModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseCheckingOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseCheckingOrdersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseCheckingOrdersByQueryModel."));
				}
			}
		 
		      
			public PurchaseCheckingOrderDetail GetPurchaseCheckingOrderDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseCheckingOrderDetail....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseCheckingOrderDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseCheckingOrderDetail."));
				}
			}
		 
		      
			public bool AddPurchaseCheckingOrderDetail(out String msg,PurchaseCheckingOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseCheckingOrderDetail....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseCheckingOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseCheckingOrderDetail."));
				}
			}
		 
		      
			public bool DeletePurchaseCheckingOrderDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseCheckingOrderDetail....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseCheckingOrderDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseCheckingOrderDetail."));
				}
			}
		 
		      
			public bool SavePurchaseCheckingOrderDetail(out String msg,PurchaseCheckingOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseCheckingOrderDetail....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseCheckingOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseCheckingOrderDetail."));
				}
			}
		 
		      
			public bool SaveRetailOrder(out String msg,RetailOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveRetailOrder....."));
				try
				{ 
					return pharmacyServcie.SaveRetailOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveRetailOrder."));
				}
			}
		 
		      
			public RetailOrder[] AllRetailOrders(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllRetailOrders....."));
				try
				{ 
					return pharmacyServcie.AllRetailOrders(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllRetailOrders."));
				}
			}
		 
		      
			public RetailOrder[] QueryRetailOrders(out String msg,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String code,String description,decimal totalmoneyfrom,decimal totalmoneyto,decimal reducemoneyfrom,decimal reducemoneyto,decimal receivablemoneyfrom,decimal receivablemoneyto,decimal gotmoneyfrom,decimal gotmoneyto,decimal changemoneyfrom,decimal changemoneyto,decimal realpaymoneyfrom,decimal realpaymoneyto,int retailcustomertypevaluefrom,int retailcustomertypevalueto,int retailpaymentmethodvaluefrom,int retailpaymentmethodvalueto,decimal totalrefundfrom,decimal totalrefundto,decimal returnreducemoneyfrom,decimal returnreducemoneyto,decimal returnreceivablemoneyfrom,decimal returnreceivablemoneyto,decimal returnrealreceivemoneyfrom,decimal returnrealreceivemoneyto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryRetailOrders....."));
				try
				{ 
					return pharmacyServcie.QueryRetailOrders(out msg,createtimefrom,createtimeto,updatetimefrom,updatetimeto,code,description,totalmoneyfrom,totalmoneyto,reducemoneyfrom,reducemoneyto,receivablemoneyfrom,receivablemoneyto,gotmoneyfrom,gotmoneyto,changemoneyfrom,changemoneyto,realpaymoneyfrom,realpaymoneyto,retailcustomertypevaluefrom,retailcustomertypevalueto,retailpaymentmethodvaluefrom,retailpaymentmethodvalueto,totalrefundfrom,totalrefundto,returnreducemoneyfrom,returnreducemoneyto,returnreceivablemoneyfrom,returnreceivablemoneyto,returnrealreceivemoneyfrom,returnrealreceivemoneyto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryRetailOrders."));
				}
			}
		 
		      
			public RetailOrder[] QueryPagedRetailOrders(out PagerInfo pager,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String code,String description,decimal totalmoneyfrom,decimal totalmoneyto,decimal reducemoneyfrom,decimal reducemoneyto,decimal receivablemoneyfrom,decimal receivablemoneyto,decimal gotmoneyfrom,decimal gotmoneyto,decimal changemoneyfrom,decimal changemoneyto,decimal realpaymoneyfrom,decimal realpaymoneyto,int retailcustomertypevaluefrom,int retailcustomertypevalueto,int retailpaymentmethodvaluefrom,int retailpaymentmethodvalueto,decimal totalrefundfrom,decimal totalrefundto,decimal returnreducemoneyfrom,decimal returnreducemoneyto,decimal returnreceivablemoneyfrom,decimal returnreceivablemoneyto,decimal returnrealreceivemoneyfrom,decimal returnrealreceivemoneyto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedRetailOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPagedRetailOrders(out pager,createtimefrom,createtimeto,updatetimefrom,updatetimeto,code,description,totalmoneyfrom,totalmoneyto,reducemoneyfrom,reducemoneyto,receivablemoneyfrom,receivablemoneyto,gotmoneyfrom,gotmoneyto,changemoneyfrom,changemoneyto,realpaymoneyfrom,realpaymoneyto,retailcustomertypevaluefrom,retailcustomertypevalueto,retailpaymentmethodvaluefrom,retailpaymentmethodvalueto,totalrefundfrom,totalrefundto,returnreducemoneyfrom,returnreducemoneyto,returnreceivablemoneyfrom,returnreceivablemoneyto,returnrealreceivemoneyfrom,returnrealreceivemoneyto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedRetailOrders."));
				}
			}
		 
		      
			public RetailOrder[] SearchRetailOrdersByQueryModel(out String message,QueryRetailOrderModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchRetailOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchRetailOrdersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchRetailOrdersByQueryModel."));
				}
			}
		 
		      
			public RetailOrder[] SearchPagedRetailOrdersByQueryModel(out PagerInfo pager,QueryRetailOrderModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedRetailOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedRetailOrdersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedRetailOrdersByQueryModel."));
				}
			}
		 
		      
			public RetailOrderDetail GetRetailOrderDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetRetailOrderDetail....."));
				try
				{ 
					return pharmacyServcie.GetRetailOrderDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetRetailOrderDetail."));
				}
			}
		 
		      
			public bool AddRetailOrderDetail(out String msg,RetailOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddRetailOrderDetail....."));
				try
				{ 
					return pharmacyServcie.AddRetailOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddRetailOrderDetail."));
				}
			}
		 
		      
			public bool DeleteRetailOrderDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteRetailOrderDetail....."));
				try
				{ 
					return pharmacyServcie.DeleteRetailOrderDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteRetailOrderDetail."));
				}
			}
		 
		      
			public bool SaveRetailOrderDetail(out String msg,RetailOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveRetailOrderDetail....."));
				try
				{ 
					return pharmacyServcie.SaveRetailOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveRetailOrderDetail."));
				}
			}
		 
		      
			public RetailOrderDetail[] AllRetailOrderDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllRetailOrderDetails....."));
				try
				{ 
					return pharmacyServcie.AllRetailOrderDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllRetailOrderDetails."));
				}
			}
		 
		      
			public RetailOrderDetail[] QueryRetailOrderDetails(out String msg,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int indexfrom,int indexto,String productname,String productcode,String batchnumber,int amountfrom,int amountto,int returnamountfrom,int returnamountto,bool isdismanting,bool queryisdismanting,int dismantingamountfrom,int dismantingamountto,decimal unitpricefrom,decimal unitpriceto,decimal dismantingunitpricefrom,decimal dismantingunitpriceto,decimal actualunitpricefrom,decimal actualunitpriceto,decimal actualdismantingunitpricefrom,decimal actualdismantingunitpriceto,String measurementunit,String specificationcode,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,String factoryname,String description,bool isdiscount,bool queryisdiscount,int discountfrom,int discountto,int discountpricefrom,int discountpriceto,decimal totalmoneyfrom,decimal totalmoneyto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryRetailOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QueryRetailOrderDetails(out msg,createtimefrom,createtimeto,updatetimefrom,updatetimeto,indexfrom,indexto,productname,productcode,batchnumber,amountfrom,amountto,returnamountfrom,returnamountto,isdismanting,queryisdismanting,dismantingamountfrom,dismantingamountto,unitpricefrom,unitpriceto,dismantingunitpricefrom,dismantingunitpriceto,actualunitpricefrom,actualunitpriceto,actualdismantingunitpricefrom,actualdismantingunitpriceto,measurementunit,specificationcode,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,factoryname,description,isdiscount,queryisdiscount,discountfrom,discountto,discountpricefrom,discountpriceto,totalmoneyfrom,totalmoneyto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryRetailOrderDetails."));
				}
			}
		 
		      
			public RetailOrderDetail[] QueryPagedRetailOrderDetails(out PagerInfo pager,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int indexfrom,int indexto,String productname,String productcode,String batchnumber,int amountfrom,int amountto,int returnamountfrom,int returnamountto,bool isdismanting,bool queryisdismanting,int dismantingamountfrom,int dismantingamountto,decimal unitpricefrom,decimal unitpriceto,decimal dismantingunitpricefrom,decimal dismantingunitpriceto,decimal actualunitpricefrom,decimal actualunitpriceto,decimal actualdismantingunitpricefrom,decimal actualdismantingunitpriceto,String measurementunit,String specificationcode,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,String factoryname,String description,bool isdiscount,bool queryisdiscount,int discountfrom,int discountto,int discountpricefrom,int discountpriceto,decimal totalmoneyfrom,decimal totalmoneyto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedRetailOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedRetailOrderDetails(out pager,createtimefrom,createtimeto,updatetimefrom,updatetimeto,indexfrom,indexto,productname,productcode,batchnumber,amountfrom,amountto,returnamountfrom,returnamountto,isdismanting,queryisdismanting,dismantingamountfrom,dismantingamountto,unitpricefrom,unitpriceto,dismantingunitpricefrom,dismantingunitpriceto,actualunitpricefrom,actualunitpriceto,actualdismantingunitpricefrom,actualdismantingunitpriceto,measurementunit,specificationcode,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,factoryname,description,isdiscount,queryisdiscount,discountfrom,discountto,discountpricefrom,discountpriceto,totalmoneyfrom,totalmoneyto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedRetailOrderDetails."));
				}
			}
		 
		      
			public RetailOrderDetail[] SearchRetailOrderDetailsByQueryModel(out String message,QueryRetailOrderDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchRetailOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchRetailOrderDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchRetailOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public RetailOrderDetail[] SearchPagedRetailOrderDetailsByQueryModel(out PagerInfo pager,QueryRetailOrderDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedRetailOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedRetailOrderDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedRetailOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public Role GetRole(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetRole....."));
				try
				{ 
					return pharmacyServcie.GetRole(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetRole."));
				}
			}
		 
		      
			public bool AddRole(out String msg,Role value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddRole....."));
				try
				{ 
					return pharmacyServcie.AddRole(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddRole."));
				}
			}
		 
		      
			public bool DeleteRole(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteRole....."));
				try
				{ 
					return pharmacyServcie.DeleteRole(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteRole."));
				}
			}
		 
		      
			public bool SaveRole(out String msg,Role value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveRole....."));
				try
				{ 
					return pharmacyServcie.SaveRole(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveRole."));
				}
			}
		 
		      
			public Role[] AllRoles(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllRoles....."));
				try
				{ 
					return pharmacyServcie.AllRoles(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllRoles."));
				}
			}
		 
		      
			public Role[] QueryRoles(out String msg,String name,String code,String description,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryRoles....."));
				try
				{ 
					return pharmacyServcie.QueryRoles(out msg,name,code,description,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryRoles."));
				}
			}
		 
		      
			public Role[] QueryPagedRoles(out PagerInfo pager,String name,String code,String description,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedRoles....."));
				try
				{ 
					return pharmacyServcie.QueryPagedRoles(out pager,name,code,description,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedRoles."));
				}
			}
		 
		      
			public Role[] SearchRolesByQueryModel(out String message,QueryRoleModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchRolesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchRolesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchRolesByQueryModel."));
				}
			}
		 
		      
			public Role[] SearchPagedRolesByQueryModel(out PagerInfo pager,QueryRoleModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedRolesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedRolesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedRolesByQueryModel."));
				}
			}
		 
		      
			public RoleWithUser GetRoleWithUser(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetRoleWithUser....."));
				try
				{ 
					return pharmacyServcie.GetRoleWithUser(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetRoleWithUser."));
				}
			}
		 
		      
			public bool AddRoleWithUser(out String msg,RoleWithUser value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddRoleWithUser....."));
				try
				{ 
					return pharmacyServcie.AddRoleWithUser(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddRoleWithUser."));
				}
			}
		 
		      
			public bool DeleteRoleWithUser(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteRoleWithUser....."));
				try
				{ 
					return pharmacyServcie.DeleteRoleWithUser(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteRoleWithUser."));
				}
			}
		 
		      
			public bool SaveRoleWithUser(out String msg,RoleWithUser value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveRoleWithUser....."));
				try
				{ 
					return pharmacyServcie.SaveRoleWithUser(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveRoleWithUser."));
				}
			}
		 
		      
			public RoleWithUser[] AllRoleWithUsers(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllRoleWithUsers....."));
				try
				{ 
					return pharmacyServcie.AllRoleWithUsers(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllRoleWithUsers."));
				}
			}
		 
		      
			public RoleWithUser[] QueryRoleWithUsers(out String msg,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryRoleWithUsers....."));
				try
				{ 
					return pharmacyServcie.QueryRoleWithUsers(out msg,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryRoleWithUsers."));
				}
			}
		 
		      
			public RoleWithUser[] QueryPagedRoleWithUsers(out PagerInfo pager,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedRoleWithUsers....."));
				try
				{ 
					return pharmacyServcie.QueryPagedRoleWithUsers(out pager,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedRoleWithUsers."));
				}
			}
		 
		      
			public RoleWithUser[] SearchRoleWithUsersByQueryModel(out String message,QueryRoleWithUserModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchRoleWithUsersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchRoleWithUsersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchRoleWithUsersByQueryModel."));
				}
			}
		 
		      
			public PurchaseManageCategoryDetail GetPurchaseManageCategoryDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseManageCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseManageCategoryDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseManageCategoryDetail."));
				}
			}
		 
		      
			public bool AddPurchaseManageCategoryDetail(out String msg,PurchaseManageCategoryDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseManageCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseManageCategoryDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseManageCategoryDetail."));
				}
			}
		 
		      
			public bool DeletePurchaseManageCategoryDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseManageCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseManageCategoryDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseManageCategoryDetail."));
				}
			}
		 
		      
			public bool SavePurchaseManageCategoryDetail(out String msg,PurchaseManageCategoryDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseManageCategoryDetail....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseManageCategoryDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseManageCategoryDetail."));
				}
			}
		 
		      
			public PurchaseManageCategoryDetail[] AllPurchaseManageCategoryDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseManageCategoryDetails....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseManageCategoryDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseManageCategoryDetails."));
				}
			}
		 
		      
			public PurchaseManageCategoryDetail[] QueryPurchaseManageCategoryDetails(out String msg,String name,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseManageCategoryDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseManageCategoryDetails(out msg,name,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseManageCategoryDetails."));
				}
			}
		 
		      
			public PurchaseManageCategoryDetail[] QueryPagedPurchaseManageCategoryDetails(out PagerInfo pager,String name,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseManageCategoryDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseManageCategoryDetails(out pager,name,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseManageCategoryDetails."));
				}
			}
		 
		      
			public PurchaseManageCategoryDetail[] SearchPurchaseManageCategoryDetailsByQueryModel(out String message,QueryPurchaseManageCategoryDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseManageCategoryDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseManageCategoryDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseManageCategoryDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseManageCategoryDetail[] SearchPagedPurchaseManageCategoryDetailsByQueryModel(out PagerInfo pager,QueryPurchaseManageCategoryDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseManageCategoryDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseManageCategoryDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseManageCategoryDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseOrder GetPurchaseOrder(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseOrder....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseOrder(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseOrder."));
				}
			}
		 
		      
			public bool AddPurchaseOrder(out String msg,PurchaseOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseOrder....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseOrder."));
				}
			}
		 
		      
			public bool DeletePurchaseOrder(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseOrder....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseOrder(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseOrder."));
				}
			}
		 
		      
			public bool SavePurchaseOrder(out String msg,PurchaseOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseOrder....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseOrder."));
				}
			}
		 
		      
			public PurchaseOrder[] AllPurchaseOrders(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseOrders....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseOrders(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseOrders."));
				}
			}
		 
		      
			public PurchaseOrder[] QueryPurchaseOrders(out String msg,String documentnumber,decimal totalmoneyfrom,decimal totalmoneyto,decimal paymentforgoodsmoneyfrom,decimal paymentforgoodsmoneyto,decimal amountoftaxmoneyfrom,decimal amountoftaxmoneyto,int invaliddaysfrom,int invaliddaysto,DateTime purchaseddatefrom,DateTime purchaseddateto,DateTime createtimefrom,DateTime createtimeto,String decription,String approvaldecription,String amountapprovaldecription,int orderstatusvaluefrom,int orderstatusvalueto,DateTime updatetimefrom,DateTime updatetimeto,bool directmarketing,bool querydirectmarketing,String shippingmethod)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseOrders(out msg,documentnumber,totalmoneyfrom,totalmoneyto,paymentforgoodsmoneyfrom,paymentforgoodsmoneyto,amountoftaxmoneyfrom,amountoftaxmoneyto,invaliddaysfrom,invaliddaysto,purchaseddatefrom,purchaseddateto,createtimefrom,createtimeto,decription,approvaldecription,amountapprovaldecription,orderstatusvaluefrom,orderstatusvalueto,updatetimefrom,updatetimeto,directmarketing,querydirectmarketing,shippingmethod);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseOrders."));
				}
			}
		 
		      
			public PurchaseOrder[] QueryPagedPurchaseOrders(out PagerInfo pager,String documentnumber,decimal totalmoneyfrom,decimal totalmoneyto,decimal paymentforgoodsmoneyfrom,decimal paymentforgoodsmoneyto,decimal amountoftaxmoneyfrom,decimal amountoftaxmoneyto,int invaliddaysfrom,int invaliddaysto,DateTime purchaseddatefrom,DateTime purchaseddateto,DateTime createtimefrom,DateTime createtimeto,String decription,String approvaldecription,String amountapprovaldecription,int orderstatusvaluefrom,int orderstatusvalueto,DateTime updatetimefrom,DateTime updatetimeto,bool directmarketing,bool querydirectmarketing,String shippingmethod,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseOrders(out pager,documentnumber,totalmoneyfrom,totalmoneyto,paymentforgoodsmoneyfrom,paymentforgoodsmoneyto,amountoftaxmoneyfrom,amountoftaxmoneyto,invaliddaysfrom,invaliddaysto,purchaseddatefrom,purchaseddateto,createtimefrom,createtimeto,decription,approvaldecription,amountapprovaldecription,orderstatusvaluefrom,orderstatusvalueto,updatetimefrom,updatetimeto,directmarketing,querydirectmarketing,shippingmethod,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseOrders."));
				}
			}
		 
		      
			public PurchaseOrder[] SearchPurchaseOrdersByQueryModel(out String message,QueryPurchaseOrderModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseOrdersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseOrdersByQueryModel."));
				}
			}
		 
		      
			public PurchaseOrder[] SearchPagedPurchaseOrdersByQueryModel(out PagerInfo pager,QueryPurchaseOrderModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseOrdersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseOrdersByQueryModel."));
				}
			}
		 
		      
			public PurchaseOrderDetail GetPurchaseOrderDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseOrderDetail....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseOrderDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseOrderDetail."));
				}
			}
		 
		      
			public bool AddPurchaseOrderDetail(out String msg,PurchaseOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseOrderDetail....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseOrderDetail."));
				}
			}
		 
		      
			public bool DeletePurchaseOrderDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseOrderDetail....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseOrderDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseOrderDetail."));
				}
			}
		 
		      
			public bool SavePurchaseOrderDetail(out String msg,PurchaseOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseOrderDetail....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseOrderDetail."));
				}
			}
		 
		      
			public PurchaseOrderDetail[] AllPurchaseOrderDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseOrderDetails....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseOrderDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseOrderDetails."));
				}
			}
		 
		      
			public PurchaseOrderDetail[] QueryPurchaseOrderDetails(out String msg,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int amountfrom,int amountto,decimal purchasepricefrom,decimal purchasepriceto,decimal amountoftaxfrom,decimal amountoftaxto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseOrderDetails(out msg,createtimefrom,createtimeto,updatetimefrom,updatetimeto,amountfrom,amountto,purchasepricefrom,purchasepriceto,amountoftaxfrom,amountoftaxto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseOrderDetails."));
				}
			}
		 
		      
			public PurchaseOrderDetail[] QueryPagedPurchaseOrderDetails(out PagerInfo pager,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int amountfrom,int amountto,decimal purchasepricefrom,decimal purchasepriceto,decimal amountoftaxfrom,decimal amountoftaxto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseOrderDetails(out pager,createtimefrom,createtimeto,updatetimefrom,updatetimeto,amountfrom,amountto,purchasepricefrom,purchasepriceto,amountoftaxfrom,amountoftaxto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseOrderDetails."));
				}
			}
		 
		      
			public PurchaseOrderDetail[] SearchPurchaseOrderDetailsByQueryModel(out String message,QueryPurchaseOrderDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseOrderDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseOrderDetail[] SearchPagedPurchaseOrderDetailsByQueryModel(out PagerInfo pager,QueryPurchaseOrderDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseOrderDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseOrderReturn GetPurchaseOrderReturn(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseOrderReturn....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseOrderReturn(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseOrderReturn."));
				}
			}
		 
		      
			public bool AddPurchaseOrderReturn(out String msg,PurchaseOrderReturn value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseOrderReturn....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseOrderReturn(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseOrderReturn."));
				}
			}
		 
		      
			public bool DeletePurchaseOrderReturn(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseOrderReturn....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseOrderReturn(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseOrderReturn."));
				}
			}
		 
		      
			public bool SavePurchaseOrderReturn(out String msg,PurchaseOrderReturn value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseOrderReturn....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseOrderReturn(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseOrderReturn."));
				}
			}
		 
		      
			public PurchaseOrderReturn[] AllPurchaseOrderReturns(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseOrderReturns....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseOrderReturns(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseOrderReturns."));
				}
			}
		 
		      
			public PurchaseOrderReturn[] QueryPurchaseOrderReturns(out String msg,String documentnumber,String checkersuggest,String qualitysuggest,String generalmanagersuggest,String financedepartmentsuggest,int orderstatusvaluefrom,int orderstatusvalueto,String decription,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String relatedorderdocumentnumber,int relatedordertypevaluefrom,int relatedordertypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseOrderReturns....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseOrderReturns(out msg,documentnumber,checkersuggest,qualitysuggest,generalmanagersuggest,financedepartmentsuggest,orderstatusvaluefrom,orderstatusvalueto,decription,createtimefrom,createtimeto,updatetimefrom,updatetimeto,relatedorderdocumentnumber,relatedordertypevaluefrom,relatedordertypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseOrderReturns."));
				}
			}
		 
		      
			public PurchaseOrderReturn[] QueryPagedPurchaseOrderReturns(out PagerInfo pager,String documentnumber,String checkersuggest,String qualitysuggest,String generalmanagersuggest,String financedepartmentsuggest,int orderstatusvaluefrom,int orderstatusvalueto,String decription,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String relatedorderdocumentnumber,int relatedordertypevaluefrom,int relatedordertypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseOrderReturns....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseOrderReturns(out pager,documentnumber,checkersuggest,qualitysuggest,generalmanagersuggest,financedepartmentsuggest,orderstatusvaluefrom,orderstatusvalueto,decription,createtimefrom,createtimeto,updatetimefrom,updatetimeto,relatedorderdocumentnumber,relatedordertypevaluefrom,relatedordertypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseOrderReturns."));
				}
			}
		 
		      
			public PurchaseOrderReturn[] SearchPurchaseOrderReturnsByQueryModel(out String message,QueryPurchaseOrderReturnModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseOrderReturnsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseOrderReturnsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseOrderReturnsByQueryModel."));
				}
			}
		 
		      
			public PurchaseOrderReturn[] SearchPagedPurchaseOrderReturnsByQueryModel(out PagerInfo pager,QueryPurchaseOrderReturnModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseOrderReturnsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseOrderReturnsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseOrderReturnsByQueryModel."));
				}
			}
		 
		      
			public PurchaseOrderReturnDetail GetPurchaseOrderReturnDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseOrderReturnDetail....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseOrderReturnDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseOrderReturnDetail."));
				}
			}
		 
		      
			public bool AddPurchaseOrderReturnDetail(out String msg,PurchaseOrderReturnDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseOrderReturnDetail....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseOrderReturnDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseOrderReturnDetail."));
				}
			}
		 
		      
			public bool DeletePurchaseOrderReturnDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseOrderReturnDetail....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseOrderReturnDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseOrderReturnDetail."));
				}
			}
		 
		      
			public bool SavePurchaseOrderReturnDetail(out String msg,PurchaseOrderReturnDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseOrderReturnDetail....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseOrderReturnDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseOrderReturnDetail."));
				}
			}
		 
		      
			public PurchaseOrderReturnDetail[] AllPurchaseOrderReturnDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseOrderReturnDetails....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseOrderReturnDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseOrderReturnDetails."));
				}
			}
		 
		      
			public PurchaseOrderReturnDetail[] QueryPurchaseOrderReturnDetails(out String msg,String batchnumber,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,int returnamountfrom,int returnamountto,decimal purchasepricefrom,decimal purchasepriceto,String returnreason,bool isreissue,bool queryisreissue,int reissueamountfrom,int reissueamountto,int purchasereturnsourcevaluefrom,int purchasereturnsourcevalueto,int returnhandledmethodvaluefrom,int returnhandledmethodvalueto,String decription)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseOrderReturnDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseOrderReturnDetails(out msg,batchnumber,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,returnamountfrom,returnamountto,purchasepricefrom,purchasepriceto,returnreason,isreissue,queryisreissue,reissueamountfrom,reissueamountto,purchasereturnsourcevaluefrom,purchasereturnsourcevalueto,returnhandledmethodvaluefrom,returnhandledmethodvalueto,decription);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseOrderReturnDetails."));
				}
			}
		 
		      
			public PurchaseOrderReturnDetail[] QueryPagedPurchaseOrderReturnDetails(out PagerInfo pager,String batchnumber,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,int returnamountfrom,int returnamountto,decimal purchasepricefrom,decimal purchasepriceto,String returnreason,bool isreissue,bool queryisreissue,int reissueamountfrom,int reissueamountto,int purchasereturnsourcevaluefrom,int purchasereturnsourcevalueto,int returnhandledmethodvaluefrom,int returnhandledmethodvalueto,String decription,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseOrderReturnDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseOrderReturnDetails(out pager,batchnumber,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,returnamountfrom,returnamountto,purchasepricefrom,purchasepriceto,returnreason,isreissue,queryisreissue,reissueamountfrom,reissueamountto,purchasereturnsourcevaluefrom,purchasereturnsourcevalueto,returnhandledmethodvaluefrom,returnhandledmethodvalueto,decription,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseOrderReturnDetails."));
				}
			}
		 
		      
			public PurchaseOrderReturnDetail[] SearchPurchaseOrderReturnDetailsByQueryModel(out String message,QueryPurchaseOrderReturnDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseOrderReturnDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseOrderReturnDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseOrderReturnDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseOrderReturnDetail[] SearchPagedPurchaseOrderReturnDetailsByQueryModel(out PagerInfo pager,QueryPurchaseOrderReturnDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseOrderReturnDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseOrderReturnDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseOrderReturnDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchaseReceivingOrder GetPurchaseReceivingOrder(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseReceivingOrder....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseReceivingOrder(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseReceivingOrder."));
				}
			}
		 
		      
			public bool AddPurchaseReceivingOrder(out String msg,PurchaseReceivingOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseReceivingOrder....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseReceivingOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseReceivingOrder."));
				}
			}
		 
		      
			public bool DeletePurchaseReceivingOrder(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseReceivingOrder....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseReceivingOrder(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseReceivingOrder."));
				}
			}
		 
		      
			public bool SavePurchaseReceivingOrder(out String msg,PurchaseReceivingOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseReceivingOrder....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseReceivingOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseReceivingOrder."));
				}
			}
		 
		      
			public PurchaseReceivingOrder[] AllPurchaseReceivingOrders(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseReceivingOrders....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseReceivingOrders(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseReceivingOrders."));
				}
			}
		 
		      
			public PurchaseReceivingOrder[] QueryPurchaseReceivingOrders(out String msg,String documentnumber,DateTime operatetimefrom,DateTime operatetimeto,DateTime shippingtimefrom,DateTime shippingtimeto,String shippingadress,String shippingunit,String transportunit,int orderstatusvaluefrom,int orderstatusvalueto,String decription,String relatedorderdocumentnumber,int relatedordertypevaluefrom,int relatedordertypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseReceivingOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseReceivingOrders(out msg,documentnumber,operatetimefrom,operatetimeto,shippingtimefrom,shippingtimeto,shippingadress,shippingunit,transportunit,orderstatusvaluefrom,orderstatusvalueto,decription,relatedorderdocumentnumber,relatedordertypevaluefrom,relatedordertypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseReceivingOrders."));
				}
			}
		 
		      
			public PurchaseReceivingOrder[] QueryPagedPurchaseReceivingOrders(out PagerInfo pager,String documentnumber,DateTime operatetimefrom,DateTime operatetimeto,DateTime shippingtimefrom,DateTime shippingtimeto,String shippingadress,String shippingunit,String transportunit,int orderstatusvaluefrom,int orderstatusvalueto,String decription,String relatedorderdocumentnumber,int relatedordertypevaluefrom,int relatedordertypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseReceivingOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseReceivingOrders(out pager,documentnumber,operatetimefrom,operatetimeto,shippingtimefrom,shippingtimeto,shippingadress,shippingunit,transportunit,orderstatusvaluefrom,orderstatusvalueto,decription,relatedorderdocumentnumber,relatedordertypevaluefrom,relatedordertypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseReceivingOrders."));
				}
			}
		 
		      
			public PurchaseReceivingOrder[] SearchPurchaseReceivingOrdersByQueryModel(out String message,QueryPurchaseReceivingOrderModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseReceivingOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseReceivingOrdersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseReceivingOrdersByQueryModel."));
				}
			}
		 
		      
			public SalesOrderReturnDetail[] SearchSalesOrderReturnDetailsByQueryModel(out String message,QuerySalesOrderReturnDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchSalesOrderReturnDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchSalesOrderReturnDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchSalesOrderReturnDetailsByQueryModel."));
				}
			}
		 
		      
			public SalesOrderReturnDetail[] SearchPagedSalesOrderReturnDetailsByQueryModel(out PagerInfo pager,QuerySalesOrderReturnDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedSalesOrderReturnDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedSalesOrderReturnDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedSalesOrderReturnDetailsByQueryModel."));
				}
			}
		 
		      
			public OutInventory GetOutInventory(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetOutInventory....."));
				try
				{ 
					return pharmacyServcie.GetOutInventory(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetOutInventory."));
				}
			}
		 
		      
			public bool AddOutInventory(out String msg,OutInventory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddOutInventory....."));
				try
				{ 
					return pharmacyServcie.AddOutInventory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddOutInventory."));
				}
			}
		 
		      
			public bool DeleteOutInventory(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteOutInventory....."));
				try
				{ 
					return pharmacyServcie.DeleteOutInventory(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteOutInventory."));
				}
			}
		 
		      
			public bool SaveOutInventory(out String msg,OutInventory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveOutInventory....."));
				try
				{ 
					return pharmacyServcie.SaveOutInventory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveOutInventory."));
				}
			}
		 
		      
			public OutInventory[] AllOutInventorys(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllOutInventorys....."));
				try
				{ 
					return pharmacyServcie.AllOutInventorys(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllOutInventorys."));
				}
			}
		 
		      
			public OutInventory[] QueryOutInventorys(out String msg,String outinventorynumber,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,DateTime outinventorydatefrom,DateTime outinventorydateto,String description,String orderoutinventorychecknumber,decimal totalmoneyfrom,decimal totalmoneyto,decimal totaltaxfrom,decimal totaltaxto,int outinventorytypevaluefrom,int outinventorytypevalueto,int outinventorystatusvaluefrom,int outinventorystatusvalueto,String ordercode)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryOutInventorys....."));
				try
				{ 
					return pharmacyServcie.QueryOutInventorys(out msg,outinventorynumber,createtimefrom,createtimeto,updatetimefrom,updatetimeto,outinventorydatefrom,outinventorydateto,description,orderoutinventorychecknumber,totalmoneyfrom,totalmoneyto,totaltaxfrom,totaltaxto,outinventorytypevaluefrom,outinventorytypevalueto,outinventorystatusvaluefrom,outinventorystatusvalueto,ordercode);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryOutInventorys."));
				}
			}
		 
		      
			public OutInventory[] QueryPagedOutInventorys(out PagerInfo pager,String outinventorynumber,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,DateTime outinventorydatefrom,DateTime outinventorydateto,String description,String orderoutinventorychecknumber,decimal totalmoneyfrom,decimal totalmoneyto,decimal totaltaxfrom,decimal totaltaxto,int outinventorytypevaluefrom,int outinventorytypevalueto,int outinventorystatusvaluefrom,int outinventorystatusvalueto,String ordercode,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedOutInventorys....."));
				try
				{ 
					return pharmacyServcie.QueryPagedOutInventorys(out pager,outinventorynumber,createtimefrom,createtimeto,updatetimefrom,updatetimeto,outinventorydatefrom,outinventorydateto,description,orderoutinventorychecknumber,totalmoneyfrom,totalmoneyto,totaltaxfrom,totaltaxto,outinventorytypevaluefrom,outinventorytypevalueto,outinventorystatusvaluefrom,outinventorystatusvalueto,ordercode,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedOutInventorys."));
				}
			}
		 
		      
			public OutInventory[] SearchOutInventorysByQueryModel(out String message,QueryOutInventoryModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchOutInventorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchOutInventorysByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchOutInventorysByQueryModel."));
				}
			}
		 
		      
			public OutInventory[] SearchPagedOutInventorysByQueryModel(out PagerInfo pager,QueryOutInventoryModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedOutInventorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedOutInventorysByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedOutInventorysByQueryModel."));
				}
			}
		 
		      
			public SetSpeicalDrugRecord GetSetSpeicalDrugRecord(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSetSpeicalDrugRecord....."));
				try
				{ 
					return pharmacyServcie.GetSetSpeicalDrugRecord(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSetSpeicalDrugRecord."));
				}
			}
		 
		      
			public bool AddSetSpeicalDrugRecord(out String msg,SetSpeicalDrugRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSetSpeicalDrugRecord....."));
				try
				{ 
					return pharmacyServcie.AddSetSpeicalDrugRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSetSpeicalDrugRecord."));
				}
			}
		 
		      
			public bool DeleteSetSpeicalDrugRecord(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSetSpeicalDrugRecord....."));
				try
				{ 
					return pharmacyServcie.DeleteSetSpeicalDrugRecord(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSetSpeicalDrugRecord."));
				}
			}
		 
		      
			public bool SaveSetSpeicalDrugRecord(out String msg,SetSpeicalDrugRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveSetSpeicalDrugRecord....."));
				try
				{ 
					return pharmacyServcie.SaveSetSpeicalDrugRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveSetSpeicalDrugRecord."));
				}
			}
		 
		      
			public SetSpeicalDrugRecord[] AllSetSpeicalDrugRecords(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllSetSpeicalDrugRecords....."));
				try
				{ 
					return pharmacyServcie.AllSetSpeicalDrugRecords(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllSetSpeicalDrugRecords."));
				}
			}
		 
		      
			public SetSpeicalDrugRecord[] QuerySetSpeicalDrugRecords(out String msg,int maintainduetimefrom,int maintainduetimeto,String reason,String maintainemphasis,String memo)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QuerySetSpeicalDrugRecords....."));
				try
				{ 
					return pharmacyServcie.QuerySetSpeicalDrugRecords(out msg,maintainduetimefrom,maintainduetimeto,reason,maintainemphasis,memo);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QuerySetSpeicalDrugRecords."));
				}
			}
		 
		      
			public SetSpeicalDrugRecord[] QueryPagedSetSpeicalDrugRecords(out PagerInfo pager,int maintainduetimefrom,int maintainduetimeto,String reason,String maintainemphasis,String memo,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedSetSpeicalDrugRecords....."));
				try
				{ 
					return pharmacyServcie.QueryPagedSetSpeicalDrugRecords(out pager,maintainduetimefrom,maintainduetimeto,reason,maintainemphasis,memo,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedSetSpeicalDrugRecords."));
				}
			}
		 
		      
			public SetSpeicalDrugRecord[] SearchSetSpeicalDrugRecordsByQueryModel(out String message,QuerySetSpeicalDrugRecordModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchSetSpeicalDrugRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchSetSpeicalDrugRecordsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchSetSpeicalDrugRecordsByQueryModel."));
				}
			}
		 
		      
			public SetSpeicalDrugRecord[] SearchPagedSetSpeicalDrugRecordsByQueryModel(out PagerInfo pager,QuerySetSpeicalDrugRecordModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedSetSpeicalDrugRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedSetSpeicalDrugRecordsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedSetSpeicalDrugRecordsByQueryModel."));
				}
			}
		 
		      
			public SpecialDrugCategory GetSpecialDrugCategory(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSpecialDrugCategory....."));
				try
				{ 
					return pharmacyServcie.GetSpecialDrugCategory(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSpecialDrugCategory."));
				}
			}
		 
		      
			public bool AddSpecialDrugCategory(out String msg,SpecialDrugCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSpecialDrugCategory....."));
				try
				{ 
					return pharmacyServcie.AddSpecialDrugCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSpecialDrugCategory."));
				}
			}
		 
		      
			public bool DeleteSpecialDrugCategory(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSpecialDrugCategory....."));
				try
				{ 
					return pharmacyServcie.DeleteSpecialDrugCategory(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSpecialDrugCategory."));
				}
			}
		 
		      
			public bool SaveSpecialDrugCategory(out String msg,SpecialDrugCategory value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveSpecialDrugCategory....."));
				try
				{ 
					return pharmacyServcie.SaveSpecialDrugCategory(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveSpecialDrugCategory."));
				}
			}
		 
		      
			public SpecialDrugCategory[] AllSpecialDrugCategorys(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllSpecialDrugCategorys....."));
				try
				{ 
					return pharmacyServcie.AllSpecialDrugCategorys(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllSpecialDrugCategorys."));
				}
			}
		 
		      
			public SpecialDrugCategory[] QuerySpecialDrugCategorys(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QuerySpecialDrugCategorys....."));
				try
				{ 
					return pharmacyServcie.QuerySpecialDrugCategorys(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QuerySpecialDrugCategorys."));
				}
			}
		 
		      
			public SpecialDrugCategory[] QueryPagedSpecialDrugCategorys(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedSpecialDrugCategorys....."));
				try
				{ 
					return pharmacyServcie.QueryPagedSpecialDrugCategorys(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedSpecialDrugCategorys."));
				}
			}
		 
		      
			public SpecialDrugCategory[] SearchSpecialDrugCategorysByQueryModel(out String message,QuerySpecialDrugCategoryModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchSpecialDrugCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchSpecialDrugCategorysByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchSpecialDrugCategorysByQueryModel."));
				}
			}
		 
		      
			public SpecialDrugCategory[] SearchPagedSpecialDrugCategorysByQueryModel(out PagerInfo pager,QuerySpecialDrugCategoryModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedSpecialDrugCategorysByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedSpecialDrugCategorysByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedSpecialDrugCategorysByQueryModel."));
				}
			}
		 
		      
			public Store GetStore(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetStore....."));
				try
				{ 
					return pharmacyServcie.GetStore(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetStore."));
				}
			}
		 
		      
			public bool AddStore(out String msg,Store value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddStore....."));
				try
				{ 
					return pharmacyServcie.AddStore(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddStore."));
				}
			}
		 
		      
			public bool DeleteStore(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteStore....."));
				try
				{ 
					return pharmacyServcie.DeleteStore(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteStore."));
				}
			}
		 
		      
			public PurchaseUnitDeliverer[] AllPurchaseUnitDeliverers(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseUnitDeliverers....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseUnitDeliverers(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseUnitDeliverers."));
				}
			}

        //WFZ
            public SupplyPerson[] AllSupplyPersons(out String message)
            {
                //Log.Warning(string.Format("开始调用服务方法:AllPurchaseUnitDeliverers....."));
                try
                {
                    return pharmacyServcie.AllSupplyPersons(out message);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:AllPurchaseUnitDeliverers."));
                }
            }
        //end
		 
		      
			public PurchaseUnitDeliverer[] QueryPurchaseUnitDeliverers(out String msg,String name,String idfile,String idnumber,String tel,String address,DateTime birthdayfrom,DateTime birthdayto,String gender,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool valid,bool queryvalid,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseUnitDeliverers....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseUnitDeliverers(out msg,name,idfile,idnumber,tel,address,birthdayfrom,birthdayto,gender,createtimefrom,createtimeto,updatetimefrom,updatetimeto,valid,queryvalid,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseUnitDeliverers."));
				}
			}
		 
		      
			public PurchaseUnitDeliverer[] QueryPagedPurchaseUnitDeliverers(out PagerInfo pager,String name,String idfile,String idnumber,String tel,String address,DateTime birthdayfrom,DateTime birthdayto,String gender,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool valid,bool queryvalid,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseUnitDeliverers....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseUnitDeliverers(out pager,name,idfile,idnumber,tel,address,birthdayfrom,birthdayto,gender,createtimefrom,createtimeto,updatetimefrom,updatetimeto,valid,queryvalid,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseUnitDeliverers."));
				}
			}
		 
		      
			public PurchaseUnitDeliverer[] SearchPurchaseUnitDeliverersByQueryModel(out String message,QueryPurchaseUnitDelivererModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseUnitDeliverersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseUnitDeliverersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseUnitDeliverersByQueryModel."));
				}
			}

            //WFZ
            public SupplyPerson[] SearchSupplyPersonsByQueryModel(out String message, QuerySupplyPersonModel qModel)
            {
                //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseUnitDeliverersByQueryModel....."));
                try
                {
                    return pharmacyServcie.SearchSupplyPersonsByQueryModel(out message, qModel);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseUnitDeliverersByQueryModel."));
                }
            }
            //end
		 
		      
			public PurchaseUnitDeliverer[] SearchPagedPurchaseUnitDeliverersByQueryModel(out PagerInfo pager,QueryPurchaseUnitDelivererModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseUnitDeliverersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseUnitDeliverersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseUnitDeliverersByQueryModel."));
				}
			}
		 
		      
			public PurchaseUnitType GetPurchaseUnitType(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchaseUnitType....."));
				try
				{ 
					return pharmacyServcie.GetPurchaseUnitType(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchaseUnitType."));
				}
			}
		 
		      
			public bool AddPurchaseUnitType(out String msg,PurchaseUnitType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchaseUnitType....."));
				try
				{ 
					return pharmacyServcie.AddPurchaseUnitType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchaseUnitType."));
				}
			}
		 
		      
			public bool DeletePurchaseUnitType(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchaseUnitType....."));
				try
				{ 
					return pharmacyServcie.DeletePurchaseUnitType(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchaseUnitType."));
				}
			}
		 
		      
			public bool SavePurchaseUnitType(out String msg,PurchaseUnitType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchaseUnitType....."));
				try
				{ 
					return pharmacyServcie.SavePurchaseUnitType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchaseUnitType."));
				}
			}
		 
		      
			public PurchaseUnitType[] AllPurchaseUnitTypes(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchaseUnitTypes....."));
				try
				{ 
					return pharmacyServcie.AllPurchaseUnitTypes(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchaseUnitTypes."));
				}
			}
		 
		      
			public PurchaseUnitType[] QueryPurchaseUnitTypes(out String msg,String name,String decription,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchaseUnitTypes....."));
				try
				{ 
					return pharmacyServcie.QueryPurchaseUnitTypes(out msg,name,decription,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchaseUnitTypes."));
				}
			}
		 
		      
			public PurchaseUnitType[] QueryPagedPurchaseUnitTypes(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchaseUnitTypes....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchaseUnitTypes(out pager,name,decription,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchaseUnitTypes."));
				}
			}
		 
		      
			public PurchaseUnitType[] SearchPurchaseUnitTypesByQueryModel(out String message,QueryPurchaseUnitTypeModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchaseUnitTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchaseUnitTypesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchaseUnitTypesByQueryModel."));
				}
			}
		 
		      
			public PurchaseUnitType[] SearchPagedPurchaseUnitTypesByQueryModel(out PagerInfo pager,QueryPurchaseUnitTypeModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchaseUnitTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchaseUnitTypesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchaseUnitTypesByQueryModel."));
				}
			}
		 
		      
			public PurchasingPlan GetPurchasingPlan(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchasingPlan....."));
				try
				{ 
					return pharmacyServcie.GetPurchasingPlan(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchasingPlan."));
				}
			}
		 
		      
			public bool AddPurchasingPlan(out String msg,PurchasingPlan value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchasingPlan....."));
				try
				{ 
					return pharmacyServcie.AddPurchasingPlan(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchasingPlan."));
				}
			}
		 
		      
			public bool DeletePurchasingPlan(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchasingPlan....."));
				try
				{ 
					return pharmacyServcie.DeletePurchasingPlan(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchasingPlan."));
				}
			}
		 
		      
			public bool SavePurchasingPlan(out String msg,PurchasingPlan value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchasingPlan....."));
				try
				{ 
					return pharmacyServcie.SavePurchasingPlan(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchasingPlan."));
				}
			}
		 
		      
			public PurchasingPlan[] AllPurchasingPlans(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchasingPlans....."));
				try
				{ 
					return pharmacyServcie.AllPurchasingPlans(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchasingPlans."));
				}
			}
		 
		      
			public PurchasingPlan[] QueryPurchasingPlans(out String msg)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchasingPlans....."));
				try
				{ 
					return pharmacyServcie.QueryPurchasingPlans(out msg);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchasingPlans."));
				}
			}
		 
		      
			public PurchasingPlan[] QueryPagedPurchasingPlans(out PagerInfo pager,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchasingPlans....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchasingPlans(out pager,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchasingPlans."));
				}
			}
		 
		      
			public PurchasingPlan[] SearchPurchasingPlansByQueryModel(out String message,QueryPurchasingPlanModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchasingPlansByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchasingPlansByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchasingPlansByQueryModel."));
				}
			}
		 
		      
			public PurchasingPlan[] SearchPagedPurchasingPlansByQueryModel(out PagerInfo pager,QueryPurchasingPlanModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchasingPlansByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchasingPlansByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchasingPlansByQueryModel."));
				}
			}
		 
		      
			public PurchasingPlanDetail GetPurchasingPlanDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetPurchasingPlanDetail....."));
				try
				{ 
					return pharmacyServcie.GetPurchasingPlanDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetPurchasingPlanDetail."));
				}
			}
		 
		      
			public bool AddPurchasingPlanDetail(out String msg,PurchasingPlanDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddPurchasingPlanDetail....."));
				try
				{ 
					return pharmacyServcie.AddPurchasingPlanDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddPurchasingPlanDetail."));
				}
			}
		 
		      
			public bool DeletePurchasingPlanDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeletePurchasingPlanDetail....."));
				try
				{ 
					return pharmacyServcie.DeletePurchasingPlanDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeletePurchasingPlanDetail."));
				}
			}
		 
		      
			public bool SavePurchasingPlanDetail(out String msg,PurchasingPlanDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SavePurchasingPlanDetail....."));
				try
				{ 
					return pharmacyServcie.SavePurchasingPlanDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SavePurchasingPlanDetail."));
				}
			}
		 
		      
			public PurchasingPlanDetail[] AllPurchasingPlanDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllPurchasingPlanDetails....."));
				try
				{ 
					return pharmacyServcie.AllPurchasingPlanDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllPurchasingPlanDetails."));
				}
			}
		 
		      
			public PurchasingPlanDetail[] QueryPurchasingPlanDetails(out String msg)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPurchasingPlanDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPurchasingPlanDetails(out msg);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPurchasingPlanDetails."));
				}
			}
		 
		      
			public PurchasingPlanDetail[] QueryPagedPurchasingPlanDetails(out PagerInfo pager,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedPurchasingPlanDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedPurchasingPlanDetails(out pager,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedPurchasingPlanDetails."));
				}
			}
		 
		      
			public PurchasingPlanDetail[] SearchPurchasingPlanDetailsByQueryModel(out String message,QueryPurchasingPlanDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPurchasingPlanDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPurchasingPlanDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPurchasingPlanDetailsByQueryModel."));
				}
			}
		 
		      
			public PurchasingPlanDetail[] SearchPagedPurchasingPlanDetailsByQueryModel(out PagerInfo pager,QueryPurchasingPlanDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedPurchasingPlanDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedPurchasingPlanDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedPurchasingPlanDetailsByQueryModel."));
				}
			}
		 
		      
			public Rareword GetRareword(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetRareword....."));
				try
				{ 
					return pharmacyServcie.GetRareword(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetRareword."));
				}
			}
		 
		      
			public bool AddRareword(out String msg,Rareword value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddRareword....."));
				try
				{ 
					return pharmacyServcie.AddRareword(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddRareword."));
				}
			}
		 
		      
			public bool DeleteRareword(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteRareword....."));
				try
				{ 
					return pharmacyServcie.DeleteRareword(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteRareword."));
				}
			}
		 
		      
			public bool SaveRareword(out String msg,Rareword value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveRareword....."));
				try
				{ 
					return pharmacyServcie.SaveRareword(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveRareword."));
				}
			}
		 
		      
			public Rareword[] AllRarewords(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllRarewords....."));
				try
				{ 
					return pharmacyServcie.AllRarewords(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllRarewords."));
				}
			}
		 
		      
			public Rareword[] QueryRarewords(out String msg,String pinyin,String word,String parts,String code)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryRarewords....."));
				try
				{ 
					return pharmacyServcie.QueryRarewords(out msg,pinyin,word,parts,code);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryRarewords."));
				}
			}
		 
		      
			public Rareword[] QueryPagedRarewords(out PagerInfo pager,String pinyin,String word,String parts,String code,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedRarewords....."));
				try
				{ 
					return pharmacyServcie.QueryPagedRarewords(out pager,pinyin,word,parts,code,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedRarewords."));
				}
			}
		 
		      
			public Rareword[] SearchRarewordsByQueryModel(out String message,QueryRarewordModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchRarewordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchRarewordsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchRarewordsByQueryModel."));
				}
			}
		 
		      
			public Rareword[] SearchPagedRarewordsByQueryModel(out PagerInfo pager,QueryRarewordModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedRarewordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedRarewordsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedRarewordsByQueryModel."));
				}
			}
		 
		      
			public RetailMember GetRetailMember(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetRetailMember....."));
				try
				{ 
					return pharmacyServcie.GetRetailMember(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetRetailMember."));
				}
			}
		 
		      
			public bool AddRetailMember(out String msg,RetailMember value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddRetailMember....."));
				try
				{ 
					return pharmacyServcie.AddRetailMember(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddRetailMember."));
				}
			}
		 
		      
			public bool DeleteRetailMember(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteRetailMember....."));
				try
				{ 
					return pharmacyServcie.DeleteRetailMember(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteRetailMember."));
				}
			}
		 
		      
			public bool SaveRetailMember(out String msg,RetailMember value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveRetailMember....."));
				try
				{ 
					return pharmacyServcie.SaveRetailMember(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveRetailMember."));
				}
			}
		 
		      
			public RetailMember[] AllRetailMembers(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllRetailMembers....."));
				try
				{ 
					return pharmacyServcie.AllRetailMembers(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllRetailMembers."));
				}
			}
		 
		      
			public RetailMember[] QueryRetailMembers(out String msg,String name,String code,bool enabled,bool queryenabled,int retailcustomertypevaluefrom,int retailcustomertypevalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryRetailMembers....."));
				try
				{ 
					return pharmacyServcie.QueryRetailMembers(out msg,name,code,enabled,queryenabled,retailcustomertypevaluefrom,retailcustomertypevalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryRetailMembers."));
				}
			}
		 
		      
			public RetailMember[] QueryPagedRetailMembers(out PagerInfo pager,String name,String code,bool enabled,bool queryenabled,int retailcustomertypevaluefrom,int retailcustomertypevalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedRetailMembers....."));
				try
				{ 
					return pharmacyServcie.QueryPagedRetailMembers(out pager,name,code,enabled,queryenabled,retailcustomertypevaluefrom,retailcustomertypevalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedRetailMembers."));
				}
			}
		 
		      
			public RetailMember[] SearchRetailMembersByQueryModel(out String message,QueryRetailMemberModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchRetailMembersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchRetailMembersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchRetailMembersByQueryModel."));
				}
			}
		 
		      
			public RetailMember[] SearchPagedRetailMembersByQueryModel(out PagerInfo pager,QueryRetailMemberModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedRetailMembersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedRetailMembersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedRetailMembersByQueryModel."));
				}
			}
		 
		      
			public RetailOrder GetRetailOrder(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetRetailOrder....."));
				try
				{ 
					return pharmacyServcie.GetRetailOrder(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetRetailOrder."));
				}
			}
		 
		      
			public bool AddRetailOrder(out String msg,RetailOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddRetailOrder....."));
				try
				{ 
					return pharmacyServcie.AddRetailOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddRetailOrder."));
				}
			}
		 
		      
			public bool DeleteRetailOrder(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteRetailOrder....."));
				try
				{ 
					return pharmacyServcie.DeleteRetailOrder(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteRetailOrder."));
				}
			}
		 
		      
			public bool DeleteUser(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteUser....."));
				try
				{ 
					return pharmacyServcie.DeleteUser(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteUser."));
				}
			}
		 
		      
			public bool SaveUser(out String msg,User value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveUser....."));
				try
				{ 
					return pharmacyServcie.SaveUser(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveUser."));
				}
			}
		 
		      
			public User[] AllUsers(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllUsers....."));
				try
				{ 
					return pharmacyServcie.AllUsers(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllUsers."));
				}
			}
		 
		      
			public User[] QueryUsers(out String msg,String account,String pwd,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryUsers....."));
				try
				{ 
					return pharmacyServcie.QueryUsers(out msg,account,pwd,createtimefrom,createtimeto,updatetimefrom,updatetimeto,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryUsers."));
				}
			}
		 
		      
			public User[] QueryPagedUsers(out PagerInfo pager,String account,String pwd,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedUsers....."));
				try
				{ 
					return pharmacyServcie.QueryPagedUsers(out pager,account,pwd,createtimefrom,createtimeto,updatetimefrom,updatetimeto,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedUsers."));
				}
			}
		 
		      
			public User[] SearchUsersByQueryModel(out String message,QueryUserModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchUsersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchUsersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchUsersByQueryModel."));
				}
			}
		 
		      
			public User[] SearchPagedUsersByQueryModel(out PagerInfo pager,QueryUserModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedUsersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedUsersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedUsersByQueryModel."));
				}
			}
		 
		      
			public UserLog GetUserLog(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetUserLog....."));
				try
				{ 
					return pharmacyServcie.GetUserLog(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetUserLog."));
				}
			}
		 
		      
			public bool AddUserLog(out String msg,UserLog value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddUserLog....."));
				try
				{ 
					return pharmacyServcie.AddUserLog(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddUserLog."));
				}
			}
		 
		      
			public bool DeleteUserLog(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteUserLog....."));
				try
				{ 
					return pharmacyServcie.DeleteUserLog(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteUserLog."));
				}
			}
		 
		      
			public bool SaveUserLog(out String msg,UserLog value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveUserLog....."));
				try
				{ 
					return pharmacyServcie.SaveUserLog(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveUserLog."));
				}
			}
		 
		      
			public UserLog[] AllUserLogs(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllUserLogs....."));
				try
				{ 
					return pharmacyServcie.AllUserLogs(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllUserLogs."));
				}
			}
		 
		      
			public UserLog[] QueryUserLogs(out String msg,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String content)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryUserLogs....."));
				try
				{ 
					return pharmacyServcie.QueryUserLogs(out msg,createtimefrom,createtimeto,updatetimefrom,updatetimeto,content);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryUserLogs."));
				}
			}
		 
		      
			public UserLog[] QueryPagedUserLogs(out PagerInfo pager,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String content,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedUserLogs....."));
				try
				{ 
					return pharmacyServcie.QueryPagedUserLogs(out pager,createtimefrom,createtimeto,updatetimefrom,updatetimeto,content,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedUserLogs."));
				}
			}
		 
		      
			public UserLog[] SearchUserLogsByQueryModel(out String message,QueryUserLogModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchUserLogsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchUserLogsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchUserLogsByQueryModel."));
				}
			}
		 
		      
			public UserLog[] SearchPagedUserLogsByQueryModel(out PagerInfo pager,QueryUserLogModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedUserLogsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedUserLogsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedUserLogsByQueryModel."));
				}
			}
		 
		      
			public Vehicle GetVehicle(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetVehicle....."));
				try
				{ 
					return pharmacyServcie.GetVehicle(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetVehicle."));
				}
			}
		 
		      
			public bool AddVehicle(out String msg,Vehicle value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddVehicle....."));
				try
				{ 
					return pharmacyServcie.AddVehicle(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddVehicle."));
				}
			}
		 
		      
			public bool DeleteVehicle(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteVehicle....."));
				try
				{ 
					return pharmacyServcie.DeleteVehicle(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteVehicle."));
				}
			}
		 
		      
			public bool SaveVehicle(out String msg,Vehicle value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveVehicle....."));
				try
				{ 
					return pharmacyServcie.SaveVehicle(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveVehicle."));
				}
			}
		 
		      
			public Vehicle[] AllVehicles(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllVehicles....."));
				try
				{ 
					return pharmacyServcie.AllVehicles(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllVehicles."));
				}
			}
		 
		      
			public Vehicle[] QueryVehicles(out String msg,String type,int vehiclecategoryvaluefrom,int vehiclecategoryvalueto,String cubage,String licenseplate,String rule,String other,String driver,bool status,bool querystatus,bool isoutcheck,bool queryisoutcheck)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryVehicles....."));
				try
				{ 
					return pharmacyServcie.QueryVehicles(out msg,type,vehiclecategoryvaluefrom,vehiclecategoryvalueto,cubage,licenseplate,rule,other,driver,status,querystatus,isoutcheck,queryisoutcheck);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryVehicles."));
				}
			}
		 
		      
			public Vehicle[] QueryPagedVehicles(out PagerInfo pager,String type,int vehiclecategoryvaluefrom,int vehiclecategoryvalueto,String cubage,String licenseplate,String rule,String other,String driver,bool status,bool querystatus,bool isoutcheck,bool queryisoutcheck,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedVehicles....."));
				try
				{ 
					return pharmacyServcie.QueryPagedVehicles(out pager,type,vehiclecategoryvaluefrom,vehiclecategoryvalueto,cubage,licenseplate,rule,other,driver,status,querystatus,isoutcheck,queryisoutcheck,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedVehicles."));
				}
			}
		 
		      
			public Vehicle[] SearchVehiclesByQueryModel(out String message,QueryVehicleModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchVehiclesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchVehiclesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchVehiclesByQueryModel."));
				}
			}
		 
		      
			public Vehicle[] SearchPagedVehiclesByQueryModel(out PagerInfo pager,QueryVehicleModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedVehiclesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedVehiclesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedVehiclesByQueryModel."));
				}
			}
		 
		      
			public Warehouse GetWarehouse(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetWarehouse....."));
				try
				{ 
					return pharmacyServcie.GetWarehouse(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetWarehouse."));
				}
			}
		 
		      
			public bool AddWarehouse(out String msg,Warehouse value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddWarehouse....."));
				try
				{ 
					return pharmacyServcie.AddWarehouse(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddWarehouse."));
				}
			}
		 
		      
			public bool DeleteWarehouse(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteWarehouse....."));
				try
				{ 
					return pharmacyServcie.DeleteWarehouse(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteWarehouse."));
				}
			}
		 
		      
			public bool SaveWarehouse(out String msg,Warehouse value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveWarehouse....."));
				try
				{ 
					return pharmacyServcie.SaveWarehouse(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveWarehouse."));
				}
			}
		 
		      
			public Warehouse[] AllWarehouses(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllWarehouses....."));
				try
				{ 
					return pharmacyServcie.AllWarehouses(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllWarehouses."));
				}
			}
		 
		      
			public Warehouse[] QueryWarehouses(out String msg,String name,String code,String mnemoniccode,String address,String managementcompany,String phone,String rentcompany,String rentyear,String area,String shadearea,String normalarea,String coldarea,String ypfzarea,String yhyssarea,String phcarea,String tyzqarea,String dwarea,String decription,bool enabled,bool queryenabled,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryWarehouses....."));
				try
				{ 
					return pharmacyServcie.QueryWarehouses(out msg,name,code,mnemoniccode,address,managementcompany,phone,rentcompany,rentyear,area,shadearea,normalarea,coldarea,ypfzarea,yhyssarea,phcarea,tyzqarea,dwarea,decription,enabled,queryenabled,createtimefrom,createtimeto,updatetimefrom,updatetimeto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryWarehouses."));
				}
			}
		 
		      
			public Warehouse[] QueryPagedWarehouses(out PagerInfo pager,String name,String code,String mnemoniccode,String address,String managementcompany,String phone,String rentcompany,String rentyear,String area,String shadearea,String normalarea,String coldarea,String ypfzarea,String yhyssarea,String phcarea,String tyzqarea,String dwarea,String decription,bool enabled,bool queryenabled,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedWarehouses....."));
				try
				{ 
					return pharmacyServcie.QueryPagedWarehouses(out pager,name,code,mnemoniccode,address,managementcompany,phone,rentcompany,rentyear,area,shadearea,normalarea,coldarea,ypfzarea,yhyssarea,phcarea,tyzqarea,dwarea,decription,enabled,queryenabled,createtimefrom,createtimeto,updatetimefrom,updatetimeto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedWarehouses."));
				}
			}
		 
		      
			public RoleWithUser[] SearchPagedRoleWithUsersByQueryModel(out PagerInfo pager,QueryRoleWithUserModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedRoleWithUsersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedRoleWithUsersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedRoleWithUsersByQueryModel."));
				}
			}
		 
		      
			public SalesOrder GetSalesOrder(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrder....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrder(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrder."));
				}
			}
		 
		      
			public bool AddSalesOrder(out String msg,SalesOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSalesOrder....."));
				try
				{ 
					return pharmacyServcie.AddSalesOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSalesOrder."));
				}
			}
		 
		      
			public bool DeleteSalesOrder(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSalesOrder....."));
				try
				{ 
					return pharmacyServcie.DeleteSalesOrder(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSalesOrder."));
				}
			}
		 
		      
			public bool SaveSalesOrder(out String msg,SalesOrder value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveSalesOrder....."));
				try
				{ 
					return pharmacyServcie.SaveSalesOrder(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveSalesOrder."));
				}
			}
		 
		      
			public SalesOrder[] AllSalesOrders(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllSalesOrders....."));
				try
				{ 
					return pharmacyServcie.AllSalesOrders(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllSalesOrders."));
				}
			}
		 
		      
			public SalesOrder[] QuerySalesOrders(out String msg,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String salername,DateTime saledatefrom,DateTime saledateto,String description,decimal totalmoneyfrom,decimal totalmoneyto,String ordercode,bool alldelivered,bool queryalldelivered,int salesdrugtypevaluefrom,int salesdrugtypevalueto,int pickupgoodtypevaluefrom,int pickupgoodtypevalueto,String pickupman,String purchaseunitman,int orderstatusvaluefrom,int orderstatusvalueto,String cancelreason,String ordercancelcode,String orderbalancecode,String balancereason,String orderoutinventorycode,String orderoutinventorycheckcode,String orderreturncode,String orderreturnreason,String orderreturncancelcode,String orderreturncancelreason,String orderreturncheckcode,String orderreturnininventorycode,String orderdirectreturncode)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QuerySalesOrders....."));
				try
				{ 
					return pharmacyServcie.QuerySalesOrders(out msg,createtimefrom,createtimeto,updatetimefrom,updatetimeto,salername,saledatefrom,saledateto,description,totalmoneyfrom,totalmoneyto,ordercode,alldelivered,queryalldelivered,salesdrugtypevaluefrom,salesdrugtypevalueto,pickupgoodtypevaluefrom,pickupgoodtypevalueto,pickupman,purchaseunitman,orderstatusvaluefrom,orderstatusvalueto,cancelreason,ordercancelcode,orderbalancecode,balancereason,orderoutinventorycode,orderoutinventorycheckcode,orderreturncode,orderreturnreason,orderreturncancelcode,orderreturncancelreason,orderreturncheckcode,orderreturnininventorycode,orderdirectreturncode);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QuerySalesOrders."));
				}
			}
		 
		      
			public SalesOrder[] QueryPagedSalesOrders(out PagerInfo pager,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String salername,DateTime saledatefrom,DateTime saledateto,String description,decimal totalmoneyfrom,decimal totalmoneyto,String ordercode,bool alldelivered,bool queryalldelivered,int salesdrugtypevaluefrom,int salesdrugtypevalueto,int pickupgoodtypevaluefrom,int pickupgoodtypevalueto,String pickupman,String purchaseunitman,int orderstatusvaluefrom,int orderstatusvalueto,String cancelreason,String ordercancelcode,String orderbalancecode,String balancereason,String orderoutinventorycode,String orderoutinventorycheckcode,String orderreturncode,String orderreturnreason,String orderreturncancelcode,String orderreturncancelreason,String orderreturncheckcode,String orderreturnininventorycode,String orderdirectreturncode,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedSalesOrders....."));
				try
				{ 
					return pharmacyServcie.QueryPagedSalesOrders(out pager,createtimefrom,createtimeto,updatetimefrom,updatetimeto,salername,saledatefrom,saledateto,description,totalmoneyfrom,totalmoneyto,ordercode,alldelivered,queryalldelivered,salesdrugtypevaluefrom,salesdrugtypevalueto,pickupgoodtypevaluefrom,pickupgoodtypevalueto,pickupman,purchaseunitman,orderstatusvaluefrom,orderstatusvalueto,cancelreason,ordercancelcode,orderbalancecode,balancereason,orderoutinventorycode,orderoutinventorycheckcode,orderreturncode,orderreturnreason,orderreturncancelcode,orderreturncancelreason,orderreturncheckcode,orderreturnininventorycode,orderdirectreturncode,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedSalesOrders."));
				}
			}
		 
		      
			public SalesOrder[] SearchSalesOrdersByQueryModel(out String message,QuerySalesOrderModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchSalesOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchSalesOrdersByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchSalesOrdersByQueryModel."));
				}
			}
		 
		      
			public SalesOrder[] SearchPagedSalesOrdersByQueryModel(out PagerInfo pager,QuerySalesOrderModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedSalesOrdersByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedSalesOrdersByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedSalesOrdersByQueryModel."));
				}
			}
		 
		      
			public SalesOrderDeliverDetail GetSalesOrderDeliverDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderDeliverDetail....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderDeliverDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderDeliverDetail."));
				}
			}
		 
		      
			public bool AddSalesOrderDeliverDetail(out String msg,SalesOrderDeliverDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSalesOrderDeliverDetail....."));
				try
				{ 
					return pharmacyServcie.AddSalesOrderDeliverDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSalesOrderDeliverDetail."));
				}
			}
		 
		      
			public bool DeleteSalesOrderDeliverDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSalesOrderDeliverDetail....."));
				try
				{ 
					return pharmacyServcie.DeleteSalesOrderDeliverDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSalesOrderDeliverDetail."));
				}
			}
		 
		      
			public bool SaveSalesOrderDeliverDetail(out String msg,SalesOrderDeliverDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveSalesOrderDeliverDetail....."));
				try
				{ 
					return pharmacyServcie.SaveSalesOrderDeliverDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveSalesOrderDeliverDetail."));
				}
			}
		 
		      
			public SalesOrderDeliverDetail[] AllSalesOrderDeliverDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllSalesOrderDeliverDetails....."));
				try
				{ 
					return pharmacyServcie.AllSalesOrderDeliverDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllSalesOrderDeliverDetails."));
				}
			}
		 
		      
			public SalesOrderDeliverDetail[] QuerySalesOrderDeliverDetails(out String msg)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QuerySalesOrderDeliverDetails....."));
				try
				{ 
					return pharmacyServcie.QuerySalesOrderDeliverDetails(out msg);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QuerySalesOrderDeliverDetails."));
				}
			}
		 
		      
			public SalesOrderDeliverDetail[] QueryPagedSalesOrderDeliverDetails(out PagerInfo pager,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedSalesOrderDeliverDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedSalesOrderDeliverDetails(out pager,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedSalesOrderDeliverDetails."));
				}
			}
		 
		      
			public SalesOrderDeliverDetail[] SearchSalesOrderDeliverDetailsByQueryModel(out String message,QuerySalesOrderDeliverDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchSalesOrderDeliverDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchSalesOrderDeliverDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchSalesOrderDeliverDetailsByQueryModel."));
				}
			}
		 
		      
			public SalesOrderDeliverDetail[] SearchPagedSalesOrderDeliverDetailsByQueryModel(out PagerInfo pager,QuerySalesOrderDeliverDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedSalesOrderDeliverDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedSalesOrderDeliverDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedSalesOrderDeliverDetailsByQueryModel."));
				}
			}
		 
		      
			public SalesOrderDeliverRecord GetSalesOrderDeliverRecord(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderDeliverRecord....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderDeliverRecord(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderDeliverRecord."));
				}
			}
		 
		      
			public bool AddSalesOrderDeliverRecord(out String msg,SalesOrderDeliverRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSalesOrderDeliverRecord....."));
				try
				{ 
					return pharmacyServcie.AddSalesOrderDeliverRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSalesOrderDeliverRecord."));
				}
			}
		 
		      
			public bool DeleteSalesOrderDeliverRecord(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSalesOrderDeliverRecord....."));
				try
				{ 
					return pharmacyServcie.DeleteSalesOrderDeliverRecord(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSalesOrderDeliverRecord."));
				}
			}
		 
		      
			public bool SaveSalesOrderDeliverRecord(out String msg,SalesOrderDeliverRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveSalesOrderDeliverRecord....."));
				try
				{ 
					return pharmacyServcie.SaveSalesOrderDeliverRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveSalesOrderDeliverRecord."));
				}
			}
		 
		      
			public SalesOrderDeliverRecord[] AllSalesOrderDeliverRecords(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllSalesOrderDeliverRecords....."));
				try
				{ 
					return pharmacyServcie.AllSalesOrderDeliverRecords(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllSalesOrderDeliverRecords."));
				}
			}
		 
		      
			public SalesOrderDeliverRecord[] QuerySalesOrderDeliverRecords(out String msg,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool haddelivered,bool queryhaddelivered)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QuerySalesOrderDeliverRecords....."));
				try
				{ 
					return pharmacyServcie.QuerySalesOrderDeliverRecords(out msg,createtimefrom,createtimeto,updatetimefrom,updatetimeto,haddelivered,queryhaddelivered);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QuerySalesOrderDeliverRecords."));
				}
			}
		 
		      
			public SalesOrderDeliverRecord[] QueryPagedSalesOrderDeliverRecords(out PagerInfo pager,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool haddelivered,bool queryhaddelivered,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedSalesOrderDeliverRecords....."));
				try
				{ 
					return pharmacyServcie.QueryPagedSalesOrderDeliverRecords(out pager,createtimefrom,createtimeto,updatetimefrom,updatetimeto,haddelivered,queryhaddelivered,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedSalesOrderDeliverRecords."));
				}
			}
		 
		      
			public SalesOrderDeliverRecord[] SearchSalesOrderDeliverRecordsByQueryModel(out String message,QuerySalesOrderDeliverRecordModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchSalesOrderDeliverRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchSalesOrderDeliverRecordsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchSalesOrderDeliverRecordsByQueryModel."));
				}
			}
		 
		      
			public SalesOrderDeliverRecord[] SearchPagedSalesOrderDeliverRecordsByQueryModel(out PagerInfo pager,QuerySalesOrderDeliverRecordModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedSalesOrderDeliverRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedSalesOrderDeliverRecordsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedSalesOrderDeliverRecordsByQueryModel."));
				}
			}
		 
		      
			public SalesOrderDetail GetSalesOrderDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderDetail....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderDetail."));
				}
			}
		 
		      
			public bool AddSalesOrderDetail(out String msg,SalesOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSalesOrderDetail....."));
				try
				{ 
					return pharmacyServcie.AddSalesOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSalesOrderDetail."));
				}
			}
		 
		      
			public bool DeleteSalesOrderDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSalesOrderDetail....."));
				try
				{ 
					return pharmacyServcie.DeleteSalesOrderDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSalesOrderDetail."));
				}
			}
		 
		      
			public bool SaveSalesOrderDetail(out String msg,SalesOrderDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveSalesOrderDetail....."));
				try
				{ 
					return pharmacyServcie.SaveSalesOrderDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveSalesOrderDetail."));
				}
			}
		 
		      
			public SalesOrderDetail[] AllSalesOrderDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllSalesOrderDetails....."));
				try
				{ 
					return pharmacyServcie.AllSalesOrderDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllSalesOrderDetails."));
				}
			}
		 
		      
			public SalesOrderDetail[] QuerySalesOrderDetails(out String msg,int indexfrom,int indexto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String productname,String productcode,String batchnumber,int amountfrom,int amountto,decimal unitpricefrom,decimal unitpriceto,decimal actualunitpricefrom,decimal actualunitpriceto,decimal pricefrom,decimal priceto,String measurementunit,String specificationcode,String dictionarydosagecode,String origin,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,String factoryname,String description,int returnamountfrom,int returnamountto,int changeamountfrom,int changeamountto,int outamountfrom,int outamountto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QuerySalesOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QuerySalesOrderDetails(out msg,indexfrom,indexto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,productname,productcode,batchnumber,amountfrom,amountto,unitpricefrom,unitpriceto,actualunitpricefrom,actualunitpriceto,pricefrom,priceto,measurementunit,specificationcode,dictionarydosagecode,origin,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,factoryname,description,returnamountfrom,returnamountto,changeamountfrom,changeamountto,outamountfrom,outamountto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QuerySalesOrderDetails."));
				}
			}
		 
		      
			public SalesOrderDetail[] QueryPagedSalesOrderDetails(out PagerInfo pager,int indexfrom,int indexto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String productname,String productcode,String batchnumber,int amountfrom,int amountto,decimal unitpricefrom,decimal unitpriceto,decimal actualunitpricefrom,decimal actualunitpriceto,decimal pricefrom,decimal priceto,String measurementunit,String specificationcode,String dictionarydosagecode,String origin,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,String factoryname,String description,int returnamountfrom,int returnamountto,int changeamountfrom,int changeamountto,int outamountfrom,int outamountto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedSalesOrderDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedSalesOrderDetails(out pager,indexfrom,indexto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,productname,productcode,batchnumber,amountfrom,amountto,unitpricefrom,unitpriceto,actualunitpricefrom,actualunitpriceto,pricefrom,priceto,measurementunit,specificationcode,dictionarydosagecode,origin,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,factoryname,description,returnamountfrom,returnamountto,changeamountfrom,changeamountto,outamountfrom,outamountto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedSalesOrderDetails."));
				}
			}
		 
		      
			public SalesOrderDetail[] SearchSalesOrderDetailsByQueryModel(out String message,QuerySalesOrderDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchSalesOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchSalesOrderDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchSalesOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public SalesOrderDetail[] SearchPagedSalesOrderDetailsByQueryModel(out PagerInfo pager,QuerySalesOrderDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedSalesOrderDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedSalesOrderDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedSalesOrderDetailsByQueryModel."));
				}
			}
		 
		      
			public SalesOrderReturn GetSalesOrderReturn(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderReturn....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderReturn(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturn."));
				}
			}
		 
		      
			public bool AddSalesOrderReturn(out String msg,SalesOrderReturn value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSalesOrderReturn....."));
				try
				{ 
					return pharmacyServcie.AddSalesOrderReturn(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSalesOrderReturn."));
				}
			}
		 
		      
			public bool DeleteSalesOrderReturn(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSalesOrderReturn....."));
				try
				{ 
					return pharmacyServcie.DeleteSalesOrderReturn(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSalesOrderReturn."));
				}
			}
		 
		      
			public bool SaveSalesOrderReturn(out String msg,SalesOrderReturn value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveSalesOrderReturn....."));
				try
				{ 
					return pharmacyServcie.SaveSalesOrderReturn(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveSalesOrderReturn."));
				}
			}
		 
		      
			public SalesOrderReturn[] AllSalesOrderReturns(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllSalesOrderReturns....."));
				try
				{ 
					return pharmacyServcie.AllSalesOrderReturns(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllSalesOrderReturns."));
				}
			}
		 
		      
			public SalesOrderReturn[] QuerySalesOrderReturns(out String msg,String orderreturncode,String orderreturnreason,DateTime orderreturntimefrom,DateTime orderreturntimeto,bool isreissue,bool queryisreissue,String sellermemo,DateTime sellerupdatetimefrom,DateTime sellerupdatetimeto,String tradememo,DateTime tradeupdatetimefrom,DateTime tradeupdatetimeto,String qualitymemo,DateTime qualityupdatetimefrom,DateTime qualityupdatetimeto,int orderreturnstatusvaluefrom,int orderreturnstatusvalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String orderreturnininventorycode,String orderreturncancelcode,String orderreturncancelreason,String orderreturncheckcode)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QuerySalesOrderReturns....."));
				try
				{ 
					return pharmacyServcie.QuerySalesOrderReturns(out msg,orderreturncode,orderreturnreason,orderreturntimefrom,orderreturntimeto,isreissue,queryisreissue,sellermemo,sellerupdatetimefrom,sellerupdatetimeto,tradememo,tradeupdatetimefrom,tradeupdatetimeto,qualitymemo,qualityupdatetimefrom,qualityupdatetimeto,orderreturnstatusvaluefrom,orderreturnstatusvalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,orderreturnininventorycode,orderreturncancelcode,orderreturncancelreason,orderreturncheckcode);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QuerySalesOrderReturns."));
				}
			}
		 
		      
			public SalesOrderReturn[] QueryPagedSalesOrderReturns(out PagerInfo pager,String orderreturncode,String orderreturnreason,DateTime orderreturntimefrom,DateTime orderreturntimeto,bool isreissue,bool queryisreissue,String sellermemo,DateTime sellerupdatetimefrom,DateTime sellerupdatetimeto,String tradememo,DateTime tradeupdatetimefrom,DateTime tradeupdatetimeto,String qualitymemo,DateTime qualityupdatetimefrom,DateTime qualityupdatetimeto,int orderreturnstatusvaluefrom,int orderreturnstatusvalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String orderreturnininventorycode,String orderreturncancelcode,String orderreturncancelreason,String orderreturncheckcode,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedSalesOrderReturns....."));
				try
				{ 
					return pharmacyServcie.QueryPagedSalesOrderReturns(out pager,orderreturncode,orderreturnreason,orderreturntimefrom,orderreturntimeto,isreissue,queryisreissue,sellermemo,sellerupdatetimefrom,sellerupdatetimeto,tradememo,tradeupdatetimefrom,tradeupdatetimeto,qualitymemo,qualityupdatetimefrom,qualityupdatetimeto,orderreturnstatusvaluefrom,orderreturnstatusvalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,orderreturnininventorycode,orderreturncancelcode,orderreturncancelreason,orderreturncheckcode,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedSalesOrderReturns."));
				}
			}
		 
		      
			public SalesOrderReturn[] SearchSalesOrderReturnsByQueryModel(out String message,QuerySalesOrderReturnModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchSalesOrderReturnsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchSalesOrderReturnsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchSalesOrderReturnsByQueryModel."));
				}
			}
		 
		      
			public SalesOrderReturn[] SearchPagedSalesOrderReturnsByQueryModel(out PagerInfo pager,QuerySalesOrderReturnModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedSalesOrderReturnsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedSalesOrderReturnsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedSalesOrderReturnsByQueryModel."));
				}
			}
		 
		      
			public SalesOrderReturnDetail GetSalesOrderReturnDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSalesOrderReturnDetail....."));
				try
				{ 
					return pharmacyServcie.GetSalesOrderReturnDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnDetail."));
				}
			}
		 
		      
			public bool AddSalesOrderReturnDetail(out String msg,SalesOrderReturnDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSalesOrderReturnDetail....."));
				try
				{ 
					return pharmacyServcie.AddSalesOrderReturnDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSalesOrderReturnDetail."));
				}
			}
		 
		      
			public bool DeleteSalesOrderReturnDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSalesOrderReturnDetail....."));
				try
				{ 
					return pharmacyServcie.DeleteSalesOrderReturnDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSalesOrderReturnDetail."));
				}
			}
		 
		      
			public bool SaveSalesOrderReturnDetail(out String msg,SalesOrderReturnDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveSalesOrderReturnDetail....."));
				try
				{ 
					return pharmacyServcie.SaveSalesOrderReturnDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveSalesOrderReturnDetail."));
				}
			}
		 
		      
			public SalesOrderReturnDetail[] AllSalesOrderReturnDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllSalesOrderReturnDetails....."));
				try
				{ 
					return pharmacyServcie.AllSalesOrderReturnDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllSalesOrderReturnDetails."));
				}
			}
		 
		      
			public SalesOrderReturnDetail[] QuerySalesOrderReturnDetails(out String msg,int indexfrom,int indexto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String productname,String productcode,String batchnumber,int orderamountfrom,int orderamountto,decimal unitpricefrom,decimal unitpriceto,decimal actualunitpricefrom,decimal actualunitpriceto,decimal pricefrom,decimal priceto,String measurementunit,String specificationcode,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,String factoryname,String description,int returnamountfrom,int returnamountto,int returnreasonvaluefrom,int returnreasonvalueto,String returnreasonmemo,int caninamountfrom,int caninamountto,int cannotinamountfrom,int cannotinamountto,int returnhandledmethodvaluefrom,int returnhandledmethodvalueto,String returnhandledmethodmemo,bool isreissue,bool queryisreissue,int reissueamountfrom,int reissueamountto,String dictionarydosagecode,String origin)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QuerySalesOrderReturnDetails....."));
				try
				{ 
					return pharmacyServcie.QuerySalesOrderReturnDetails(out msg,indexfrom,indexto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,productname,productcode,batchnumber,orderamountfrom,orderamountto,unitpricefrom,unitpriceto,actualunitpricefrom,actualunitpriceto,pricefrom,priceto,measurementunit,specificationcode,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,factoryname,description,returnamountfrom,returnamountto,returnreasonvaluefrom,returnreasonvalueto,returnreasonmemo,caninamountfrom,caninamountto,cannotinamountfrom,cannotinamountto,returnhandledmethodvaluefrom,returnhandledmethodvalueto,returnhandledmethodmemo,isreissue,queryisreissue,reissueamountfrom,reissueamountto,dictionarydosagecode,origin);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QuerySalesOrderReturnDetails."));
				}
			}
		 
		      
			public SalesOrderReturnDetail[] QueryPagedSalesOrderReturnDetails(out PagerInfo pager,int indexfrom,int indexto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String productname,String productcode,String batchnumber,int orderamountfrom,int orderamountto,decimal unitpricefrom,decimal unitpriceto,decimal actualunitpricefrom,decimal actualunitpriceto,decimal pricefrom,decimal priceto,String measurementunit,String specificationcode,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,String factoryname,String description,int returnamountfrom,int returnamountto,int returnreasonvaluefrom,int returnreasonvalueto,String returnreasonmemo,int caninamountfrom,int caninamountto,int cannotinamountfrom,int cannotinamountto,int returnhandledmethodvaluefrom,int returnhandledmethodvalueto,String returnhandledmethodmemo,bool isreissue,bool queryisreissue,int reissueamountfrom,int reissueamountto,String dictionarydosagecode,String origin,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedSalesOrderReturnDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedSalesOrderReturnDetails(out pager,indexfrom,indexto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,productname,productcode,batchnumber,orderamountfrom,orderamountto,unitpricefrom,unitpriceto,actualunitpricefrom,actualunitpriceto,pricefrom,priceto,measurementunit,specificationcode,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,factoryname,description,returnamountfrom,returnamountto,returnreasonvaluefrom,returnreasonvalueto,returnreasonmemo,caninamountfrom,caninamountto,cannotinamountfrom,cannotinamountto,returnhandledmethodvaluefrom,returnhandledmethodvalueto,returnhandledmethodmemo,isreissue,queryisreissue,reissueamountfrom,reissueamountto,dictionarydosagecode,origin,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedSalesOrderReturnDetails."));
				}
			}
		 
		      
			public Warehouse[] SearchWarehousesByQueryModel(out String message,QueryWarehouseModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchWarehousesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchWarehousesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchWarehousesByQueryModel."));
				}
			}
		 
		      
			public Warehouse[] SearchPagedWarehousesByQueryModel(out PagerInfo pager,QueryWarehouseModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedWarehousesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedWarehousesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedWarehousesByQueryModel."));
				}
			}
		 
		      
			public WarehouseZone GetWarehouseZone(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetWarehouseZone....."));
				try
				{ 
					return pharmacyServcie.GetWarehouseZone(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetWarehouseZone."));
				}
			}
		 
		      
			public bool AddWarehouseZone(out String msg,WarehouseZone value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddWarehouseZone....."));
				try
				{ 
					return pharmacyServcie.AddWarehouseZone(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddWarehouseZone."));
				}
			}
		 
		      
			public bool DeleteWarehouseZone(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteWarehouseZone....."));
				try
				{ 
					return pharmacyServcie.DeleteWarehouseZone(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteWarehouseZone."));
				}
			}
		 
		      
			public bool SaveWarehouseZone(out String msg,WarehouseZone value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveWarehouseZone....."));
				try
				{ 
					return pharmacyServcie.SaveWarehouseZone(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveWarehouseZone."));
				}
			}
		 
		      
			public WarehouseZone[] AllWarehouseZones(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllWarehouseZones....."));
				try
				{ 
					return pharmacyServcie.AllWarehouseZones(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllWarehouseZones."));
				}
			}
		 
		      
			public WarehouseZone[] QueryWarehouseZones(out String msg,String name,String decription,String code,String mnemoniccode,String area,bool enabled,bool queryenabled,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int warehousezonetypevaluefrom,int warehousezonetypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryWarehouseZones....."));
				try
				{ 
					return pharmacyServcie.QueryWarehouseZones(out msg,name,decription,code,mnemoniccode,area,enabled,queryenabled,createtimefrom,createtimeto,updatetimefrom,updatetimeto,warehousezonetypevaluefrom,warehousezonetypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryWarehouseZones."));
				}
			}
		 
		      
			public WarehouseZone[] QueryPagedWarehouseZones(out PagerInfo pager,String name,String decription,String code,String mnemoniccode,String area,bool enabled,bool queryenabled,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,int warehousezonetypevaluefrom,int warehousezonetypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedWarehouseZones....."));
				try
				{ 
					return pharmacyServcie.QueryPagedWarehouseZones(out pager,name,decription,code,mnemoniccode,area,enabled,queryenabled,createtimefrom,createtimeto,updatetimefrom,updatetimeto,warehousezonetypevaluefrom,warehousezonetypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedWarehouseZones."));
				}
			}
		 
		      
			public WarehouseZone[] SearchWarehouseZonesByQueryModel(out String message,QueryWarehouseZoneModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchWarehouseZonesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchWarehouseZonesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchWarehouseZonesByQueryModel."));
				}
			}
		 
		      
			public WarehouseZone[] SearchPagedWarehouseZonesByQueryModel(out PagerInfo pager,QueryWarehouseZoneModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedWarehouseZonesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedWarehouseZonesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedWarehouseZonesByQueryModel."));
				}
			}
		 
		      
			public WaringSet GetWaringSet(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetWaringSet....."));
				try
				{ 
					return pharmacyServcie.GetWaringSet(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetWaringSet."));
				}
			}
		 
		      
			public bool AddWaringSet(out String msg,WaringSet value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddWaringSet....."));
				try
				{ 
					return pharmacyServcie.AddWaringSet(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddWaringSet."));
				}
			}
		 
		      
			public bool DeleteWaringSet(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteWaringSet....."));
				try
				{ 
					return pharmacyServcie.DeleteWaringSet(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteWaringSet."));
				}
			}
		 
		      
			public bool SaveWaringSet(out String msg,WaringSet value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveWaringSet....."));
				try
				{ 
					return pharmacyServcie.SaveWaringSet(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveWaringSet."));
				}
			}
		 
		      
			public WaringSet[] AllWaringSets(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllWaringSets....."));
				try
				{ 
					return pharmacyServcie.AllWaringSets(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllWaringSets."));
				}
			}
		 
		      
			public WaringSet[] QueryWaringSets(out String msg,String code,String name,String setvalue)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryWaringSets....."));
				try
				{ 
					return pharmacyServcie.QueryWaringSets(out msg,code,name,setvalue);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryWaringSets."));
				}
			}
		 
		      
			public WaringSet[] QueryPagedWaringSets(out PagerInfo pager,String code,String name,String setvalue,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedWaringSets....."));
				try
				{ 
					return pharmacyServcie.QueryPagedWaringSets(out pager,code,name,setvalue,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedWaringSets."));
				}
			}
		 
		      
			public WaringSet[] SearchWaringSetsByQueryModel(out String message,QueryWaringSetModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchWaringSetsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchWaringSetsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchWaringSetsByQueryModel."));
				}
			}
		 
		      
			public WaringSet[] SearchPagedWaringSetsByQueryModel(out PagerInfo pager,QueryWaringSetModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedWaringSetsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedWaringSetsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedWaringSetsByQueryModel."));
				}
			}
		 
		      
			public OutInventoryDetail GetOutInventoryDetail(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetOutInventoryDetail....."));
				try
				{ 
					return pharmacyServcie.GetOutInventoryDetail(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetOutInventoryDetail."));
				}
			}
		 
		      
			public bool AddOutInventoryDetail(out String msg,OutInventoryDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddOutInventoryDetail....."));
				try
				{ 
					return pharmacyServcie.AddOutInventoryDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddOutInventoryDetail."));
				}
			}
		 
		      
			public bool DeleteOutInventoryDetail(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteOutInventoryDetail....."));
				try
				{ 
					return pharmacyServcie.DeleteOutInventoryDetail(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteOutInventoryDetail."));
				}
			}
		 
		      
			public bool SaveOutInventoryDetail(out String msg,OutInventoryDetail value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveOutInventoryDetail....."));
				try
				{ 
					return pharmacyServcie.SaveOutInventoryDetail(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveOutInventoryDetail."));
				}
			}
		 
		      
			public OutInventoryDetail[] AllOutInventoryDetails(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllOutInventoryDetails....."));
				try
				{ 
					return pharmacyServcie.AllOutInventoryDetails(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllOutInventoryDetails."));
				}
			}
		 
		      
			public OutInventoryDetail[] QueryOutInventoryDetails(out String msg,int indexfrom,int indexto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String productname,String productcode,String dictionarydosagecode,String origin,String batchnumber,int amountfrom,int amountto,decimal unitpricefrom,decimal unitpriceto,decimal actualunitpricefrom,decimal actualunitpriceto,decimal pricefrom,decimal priceto,String measurementunit,String specificationcode,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,String factoryname,String description,int outamountfrom,int outamountto,String warehousecode,String warehousename,String warehousezonecode,String warehousezonename,int cansalenumfrom,int cansalenumto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryOutInventoryDetails....."));
				try
				{ 
					return pharmacyServcie.QueryOutInventoryDetails(out msg,indexfrom,indexto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,productname,productcode,dictionarydosagecode,origin,batchnumber,amountfrom,amountto,unitpricefrom,unitpriceto,actualunitpricefrom,actualunitpriceto,pricefrom,priceto,measurementunit,specificationcode,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,factoryname,description,outamountfrom,outamountto,warehousecode,warehousename,warehousezonecode,warehousezonename,cansalenumfrom,cansalenumto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryOutInventoryDetails."));
				}
			}
		 
		      
			public OutInventoryDetail[] QueryPagedOutInventoryDetails(out PagerInfo pager,int indexfrom,int indexto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String productname,String productcode,String dictionarydosagecode,String origin,String batchnumber,int amountfrom,int amountto,decimal unitpricefrom,decimal unitpriceto,decimal actualunitpricefrom,decimal actualunitpriceto,decimal pricefrom,decimal priceto,String measurementunit,String specificationcode,DateTime pruductdatefrom,DateTime pruductdateto,DateTime outvaliddatefrom,DateTime outvaliddateto,String factoryname,String description,int outamountfrom,int outamountto,String warehousecode,String warehousename,String warehousezonecode,String warehousezonename,int cansalenumfrom,int cansalenumto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedOutInventoryDetails....."));
				try
				{ 
					return pharmacyServcie.QueryPagedOutInventoryDetails(out pager,indexfrom,indexto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,productname,productcode,dictionarydosagecode,origin,batchnumber,amountfrom,amountto,unitpricefrom,unitpriceto,actualunitpricefrom,actualunitpriceto,pricefrom,priceto,measurementunit,specificationcode,pruductdatefrom,pruductdateto,outvaliddatefrom,outvaliddateto,factoryname,description,outamountfrom,outamountto,warehousecode,warehousename,warehousezonecode,warehousezonename,cansalenumfrom,cansalenumto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedOutInventoryDetails."));
				}
			}
		 
		      
			public OutInventoryDetail[] SearchOutInventoryDetailsByQueryModel(out String message,QueryOutInventoryDetailModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchOutInventoryDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchOutInventoryDetailsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchOutInventoryDetailsByQueryModel."));
				}
			}
		 
		      
			public OutInventoryDetail[] SearchPagedOutInventoryDetailsByQueryModel(out PagerInfo pager,QueryOutInventoryDetailModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedOutInventoryDetailsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedOutInventoryDetailsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedOutInventoryDetailsByQueryModel."));
				}
			}
		 
		      
			public void ReportHeart()
			{
			    //Log.Warning(string.Format("开始调用服务方法:ReportHeart....."));
				try
				{ 
					pharmacyServcie.ReportHeart();
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:ReportHeart."));
				}
			}
		 
		      
			public bool ValidateClientAuth(Store clientStore)
			{
			    //Log.Warning(string.Format("开始调用服务方法:ValidateClientAuth....."));
				try
				{ 
					return pharmacyServcie.ValidateClientAuth(clientStore);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:ValidateClientAuth."));
				}
			}
		 
		      
			public bool KeepConnection(String sessionId)
			{
			    //Log.Warning(string.Format("开始调用服务方法:KeepConnection....."));
				try
				{ 
					return pharmacyServcie.KeepConnection(sessionId);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:KeepConnection."));
				}
			}
		 
		      
			public bool SaveStore(out String msg,Store value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveStore....."));
				try
				{ 
					return pharmacyServcie.SaveStore(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveStore."));
				}
			}
		 
		      
			public Store[] AllStores(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllStores....."));
				try
				{ 
					return pharmacyServcie.AllStores(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllStores."));
				}
			}
		 
		      
			public Store[] QueryStores(out String msg,String name,String decription,String code,bool enabled,bool queryenabled,String address,String tel,String head,int storetypevaluefrom,int storetypevalueto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryStores....."));
				try
				{ 
					return pharmacyServcie.QueryStores(out msg,name,decription,code,enabled,queryenabled,address,tel,head,storetypevaluefrom,storetypevalueto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryStores."));
				}
			}
		 
		      
			public Store[] QueryPagedStores(out PagerInfo pager,String name,String decription,String code,bool enabled,bool queryenabled,String address,String tel,String head,int storetypevaluefrom,int storetypevalueto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedStores....."));
				try
				{ 
					return pharmacyServcie.QueryPagedStores(out pager,name,decription,code,enabled,queryenabled,address,tel,head,storetypevaluefrom,storetypevalueto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedStores."));
				}
			}
		 
		      
			public Store[] SearchStoresByQueryModel(out String message,QueryStoreModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchStoresByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchStoresByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchStoresByQueryModel."));
				}
			}
		 
		      
			public Store[] SearchPagedStoresByQueryModel(out PagerInfo pager,QueryStoreModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedStoresByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedStoresByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedStoresByQueryModel."));
				}
			}
		 
		      
			public SupplyUnit GetSupplyUnit(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSupplyUnit....."));
				try
				{ 
					return pharmacyServcie.GetSupplyUnit(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSupplyUnit."));
				}
			}
		 
		      
			public bool AddSupplyUnit(out String msg,SupplyUnit value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSupplyUnit....."));
				try
				{ 
					return pharmacyServcie.AddSupplyUnit(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSupplyUnit."));
				}
			}
		 
		      
			public bool DeleteSupplyUnit(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSupplyUnit....."));
				try
				{ 
					return pharmacyServcie.DeleteSupplyUnit(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSupplyUnit."));
				}
			}
		 
		      
			public bool SaveSupplyUnit(out String msg,SupplyUnit value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveSupplyUnit....."));
				try
				{ 
					return pharmacyServcie.SaveSupplyUnit(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveSupplyUnit."));
				}
			}
		 
		      
			public SupplyUnit[] AllSupplyUnits(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllSupplyUnits....."));
				try
				{ 
					return pharmacyServcie.AllSupplyUnits(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllSupplyUnits."));
				}
			}
		 
		      
			public SupplyUnit[] QuerySupplyUnits(out String msg,bool isqualityagreementout,bool queryisqualityagreementout,DateTime qualityagreementoutdatefrom,DateTime qualityagreementoutdateto,bool isattorneyaattorneyout,bool queryisattorneyaattorneyout,DateTime attorneyaattorneyoutdatefrom,DateTime attorneyaattorneyoutdateto,String supplyproductclass,String qualitycharger,String bankaccountname,String bank,String bankaccount,bool valid,bool queryvalid,String validremark,bool islock,bool queryislock,String lockremark,String name,String code,String pinyincode,String contactname,String contacttel,String description,String legalperson,String header,String businessscope,String salesamount,String fax,String email,String webaddress,bool isoutdate,bool queryisoutdate,DateTime outdatefrom,DateTime outdateto,bool isgsplicenseoutdate,bool queryisgsplicenseoutdate,DateTime gsplicenseoutdatefrom,DateTime gsplicenseoutdateto,bool isgmplicenseoutdate,bool queryisgmplicenseoutdate,DateTime gmplicenseoutdatefrom,DateTime gmplicenseoutdateto,bool isbusinesslicenseoutdate,bool queryisbusinesslicenseoutdate,DateTime businesslicenseeoutdatefrom,DateTime businesslicenseeoutdateto,bool ismedicineproductionlicenseoutdate,bool queryismedicineproductionlicenseoutdate,DateTime medicineproductionlicenseoutdatefrom,DateTime medicineproductionlicenseoutdateto,bool ismedicinebusinesslicenseoutdate,bool queryismedicinebusinesslicenseoutdate,DateTime medicinebusinesslicenseoutdatefrom,DateTime medicinebusinesslicenseoutdateto,bool isinstrumentsproductionlicenseoutdate,bool queryisinstrumentsproductionlicenseoutdate,DateTime instrumentsproductionlicenseoutdatefrom,DateTime instrumentsproductionlicenseoutdateto,bool isinstrumentsbusinesslicenseoutdate,bool queryisinstrumentsbusinesslicenseoutdate,DateTime instrumentsbusinesslicenseoutdatefrom,DateTime instrumentsbusinesslicenseoutdateto,String taxregistrationcode,DateTime lastannualdtefrom,DateTime lastannualdteto,bool isapproval,bool queryisapproval,int approvalstatusvaluefrom,int approvalstatusvalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QuerySupplyUnits....."));
				try
				{ 
					return pharmacyServcie.QuerySupplyUnits(out msg,isqualityagreementout,queryisqualityagreementout,qualityagreementoutdatefrom,qualityagreementoutdateto,isattorneyaattorneyout,queryisattorneyaattorneyout,attorneyaattorneyoutdatefrom,attorneyaattorneyoutdateto,supplyproductclass,qualitycharger,bankaccountname,bank,bankaccount,valid,queryvalid,validremark,islock,queryislock,lockremark,name,code,pinyincode,contactname,contacttel,description,legalperson,header,businessscope,salesamount,fax,email,webaddress,isoutdate,queryisoutdate,outdatefrom,outdateto,isgsplicenseoutdate,queryisgsplicenseoutdate,gsplicenseoutdatefrom,gsplicenseoutdateto,isgmplicenseoutdate,queryisgmplicenseoutdate,gmplicenseoutdatefrom,gmplicenseoutdateto,isbusinesslicenseoutdate,queryisbusinesslicenseoutdate,businesslicenseeoutdatefrom,businesslicenseeoutdateto,ismedicineproductionlicenseoutdate,queryismedicineproductionlicenseoutdate,medicineproductionlicenseoutdatefrom,medicineproductionlicenseoutdateto,ismedicinebusinesslicenseoutdate,queryismedicinebusinesslicenseoutdate,medicinebusinesslicenseoutdatefrom,medicinebusinesslicenseoutdateto,isinstrumentsproductionlicenseoutdate,queryisinstrumentsproductionlicenseoutdate,instrumentsproductionlicenseoutdatefrom,instrumentsproductionlicenseoutdateto,isinstrumentsbusinesslicenseoutdate,queryisinstrumentsbusinesslicenseoutdate,instrumentsbusinesslicenseoutdatefrom,instrumentsbusinesslicenseoutdateto,taxregistrationcode,lastannualdtefrom,lastannualdteto,isapproval,queryisapproval,approvalstatusvaluefrom,approvalstatusvalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QuerySupplyUnits."));
				}
			}
		 
		      
			public SupplyUnit[] QueryPagedSupplyUnits(out PagerInfo pager,bool isqualityagreementout,bool queryisqualityagreementout,DateTime qualityagreementoutdatefrom,DateTime qualityagreementoutdateto,bool isattorneyaattorneyout,bool queryisattorneyaattorneyout,DateTime attorneyaattorneyoutdatefrom,DateTime attorneyaattorneyoutdateto,String supplyproductclass,String qualitycharger,String bankaccountname,String bank,String bankaccount,bool valid,bool queryvalid,String validremark,bool islock,bool queryislock,String lockremark,String name,String code,String pinyincode,String contactname,String contacttel,String description,String legalperson,String header,String businessscope,String salesamount,String fax,String email,String webaddress,bool isoutdate,bool queryisoutdate,DateTime outdatefrom,DateTime outdateto,bool isgsplicenseoutdate,bool queryisgsplicenseoutdate,DateTime gsplicenseoutdatefrom,DateTime gsplicenseoutdateto,bool isgmplicenseoutdate,bool queryisgmplicenseoutdate,DateTime gmplicenseoutdatefrom,DateTime gmplicenseoutdateto,bool isbusinesslicenseoutdate,bool queryisbusinesslicenseoutdate,DateTime businesslicenseeoutdatefrom,DateTime businesslicenseeoutdateto,bool ismedicineproductionlicenseoutdate,bool queryismedicineproductionlicenseoutdate,DateTime medicineproductionlicenseoutdatefrom,DateTime medicineproductionlicenseoutdateto,bool ismedicinebusinesslicenseoutdate,bool queryismedicinebusinesslicenseoutdate,DateTime medicinebusinesslicenseoutdatefrom,DateTime medicinebusinesslicenseoutdateto,bool isinstrumentsproductionlicenseoutdate,bool queryisinstrumentsproductionlicenseoutdate,DateTime instrumentsproductionlicenseoutdatefrom,DateTime instrumentsproductionlicenseoutdateto,bool isinstrumentsbusinesslicenseoutdate,bool queryisinstrumentsbusinesslicenseoutdate,DateTime instrumentsbusinesslicenseoutdatefrom,DateTime instrumentsbusinesslicenseoutdateto,String taxregistrationcode,DateTime lastannualdtefrom,DateTime lastannualdteto,bool isapproval,bool queryisapproval,int approvalstatusvaluefrom,int approvalstatusvalueto,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedSupplyUnits....."));
				try
				{ 
					return pharmacyServcie.QueryPagedSupplyUnits(out pager,isqualityagreementout,queryisqualityagreementout,qualityagreementoutdatefrom,qualityagreementoutdateto,isattorneyaattorneyout,queryisattorneyaattorneyout,attorneyaattorneyoutdatefrom,attorneyaattorneyoutdateto,supplyproductclass,qualitycharger,bankaccountname,bank,bankaccount,valid,queryvalid,validremark,islock,queryislock,lockremark,name,code,pinyincode,contactname,contacttel,description,legalperson,header,businessscope,salesamount,fax,email,webaddress,isoutdate,queryisoutdate,outdatefrom,outdateto,isgsplicenseoutdate,queryisgsplicenseoutdate,gsplicenseoutdatefrom,gsplicenseoutdateto,isgmplicenseoutdate,queryisgmplicenseoutdate,gmplicenseoutdatefrom,gmplicenseoutdateto,isbusinesslicenseoutdate,queryisbusinesslicenseoutdate,businesslicenseeoutdatefrom,businesslicenseeoutdateto,ismedicineproductionlicenseoutdate,queryismedicineproductionlicenseoutdate,medicineproductionlicenseoutdatefrom,medicineproductionlicenseoutdateto,ismedicinebusinesslicenseoutdate,queryismedicinebusinesslicenseoutdate,medicinebusinesslicenseoutdatefrom,medicinebusinesslicenseoutdateto,isinstrumentsproductionlicenseoutdate,queryisinstrumentsproductionlicenseoutdate,instrumentsproductionlicenseoutdatefrom,instrumentsproductionlicenseoutdateto,isinstrumentsbusinesslicenseoutdate,queryisinstrumentsbusinesslicenseoutdate,instrumentsbusinesslicenseoutdatefrom,instrumentsbusinesslicenseoutdateto,taxregistrationcode,lastannualdtefrom,lastannualdteto,isapproval,queryisapproval,approvalstatusvaluefrom,approvalstatusvalueto,createtimefrom,createtimeto,updatetimefrom,updatetimeto,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedSupplyUnits."));
				}
			}
		 
		      
			public SupplyUnit[] SearchSupplyUnitsByQueryModel(out String message,QuerySupplyUnitModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchSupplyUnitsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchSupplyUnitsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchSupplyUnitsByQueryModel."));
				}
			}
		 
		      
			public SupplyUnit[] SearchPagedSupplyUnitsByQueryModel(out PagerInfo pager,QuerySupplyUnitModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedSupplyUnitsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedSupplyUnitsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedSupplyUnitsByQueryModel."));
				}
			}
		 
		      
			public SupplyUnitSalesman GetSupplyUnitSalesman(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetSupplyUnitSalesman....."));
				try
				{ 
					return pharmacyServcie.GetSupplyUnitSalesman(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetSupplyUnitSalesman."));
				}
			}
		 
		      
			public bool AddSupplyUnitSalesman(out String msg,SupplyUnitSalesman value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddSupplyUnitSalesman....."));
				try
				{ 
					return pharmacyServcie.AddSupplyUnitSalesman(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddSupplyUnitSalesman."));
				}
			}
		 
		      
			public bool DeleteSupplyUnitSalesman(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteSupplyUnitSalesman....."));
				try
				{ 
					return pharmacyServcie.DeleteSupplyUnitSalesman(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteSupplyUnitSalesman."));
				}
			}
		 
		      
			public bool SaveSupplyUnitSalesman(out String msg,SupplyUnitSalesman value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveSupplyUnitSalesman....."));
				try
				{ 
					return pharmacyServcie.SaveSupplyUnitSalesman(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveSupplyUnitSalesman."));
				}
			}
		 
		      
			public SupplyUnitSalesman[] AllSupplyUnitSalesmans(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllSupplyUnitSalesmans....."));
				try
				{ 
					return pharmacyServcie.AllSupplyUnitSalesmans(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllSupplyUnitSalesmans."));
				}
			}
		 
		      
			public SupplyUnitSalesman[] QuerySupplyUnitSalesmans(out String msg,DateTime outdatefrom,DateTime outdateto,String name,String idnumber,String tel,String address,DateTime birthdayfrom,DateTime birthdayto,String gender,bool enabled,bool queryenabled,bool valid,bool queryvalid,bool isoutdate,bool queryisoutdate,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String businessscopes,bool ischecked,bool queryischecked,String idchecktype)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QuerySupplyUnitSalesmans....."));
				try
				{ 
					return pharmacyServcie.QuerySupplyUnitSalesmans(out msg,outdatefrom,outdateto,name,idnumber,tel,address,birthdayfrom,birthdayto,gender,enabled,queryenabled,valid,queryvalid,isoutdate,queryisoutdate,createtimefrom,createtimeto,updatetimefrom,updatetimeto,businessscopes,ischecked,queryischecked,idchecktype);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QuerySupplyUnitSalesmans."));
				}
			}
		 
		      
			public SupplyUnitSalesman[] QueryPagedSupplyUnitSalesmans(out PagerInfo pager,DateTime outdatefrom,DateTime outdateto,String name,String idnumber,String tel,String address,DateTime birthdayfrom,DateTime birthdayto,String gender,bool enabled,bool queryenabled,bool valid,bool queryvalid,bool isoutdate,bool queryisoutdate,DateTime createtimefrom,DateTime createtimeto,DateTime updatetimefrom,DateTime updatetimeto,String businessscopes,bool ischecked,bool queryischecked,String idchecktype,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedSupplyUnitSalesmans....."));
				try
				{ 
					return pharmacyServcie.QueryPagedSupplyUnitSalesmans(out pager,outdatefrom,outdateto,name,idnumber,tel,address,birthdayfrom,birthdayto,gender,enabled,queryenabled,valid,queryvalid,isoutdate,queryisoutdate,createtimefrom,createtimeto,updatetimefrom,updatetimeto,businessscopes,ischecked,queryischecked,idchecktype,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedSupplyUnitSalesmans."));
				}
			}
		 
		      
			public SupplyUnitSalesman[] SearchSupplyUnitSalesmansByQueryModel(out String message,QuerySupplyUnitSalesmanModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchSupplyUnitSalesmansByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchSupplyUnitSalesmansByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchSupplyUnitSalesmansByQueryModel."));
				}
			}
		 
		      
			public SupplyUnitSalesman[] SearchPagedSupplyUnitSalesmansByQueryModel(out PagerInfo pager,QuerySupplyUnitSalesmanModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedSupplyUnitSalesmansByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedSupplyUnitSalesmansByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedSupplyUnitSalesmansByQueryModel."));
				}
			}
		 
		      
			public TaxRate GetTaxRate(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetTaxRate....."));
				try
				{ 
					return pharmacyServcie.GetTaxRate(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetTaxRate."));
				}
			}
		 
		      
			public bool AddTaxRate(out String msg,TaxRate value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddTaxRate....."));
				try
				{ 
					return pharmacyServcie.AddTaxRate(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddTaxRate."));
				}
			}
		 
		      
			public bool DeleteTaxRate(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteTaxRate....."));
				try
				{ 
					return pharmacyServcie.DeleteTaxRate(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteTaxRate."));
				}
			}
		 
		      
			public bool SaveTaxRate(out String msg,TaxRate value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveTaxRate....."));
				try
				{ 
					return pharmacyServcie.SaveTaxRate(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveTaxRate."));
				}
			}
		 
		      
			public TaxRate[] AllTaxRates(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllTaxRates....."));
				try
				{ 
					return pharmacyServcie.AllTaxRates(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllTaxRates."));
				}
			}
		 
		      
			public TaxRate[] QueryTaxRates(out String msg,String name,String code,bool enabled,bool queryenabled)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryTaxRates....."));
				try
				{ 
					return pharmacyServcie.QueryTaxRates(out msg,name,code,enabled,queryenabled);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryTaxRates."));
				}
			}
		 
		      
			public TaxRate[] QueryPagedTaxRates(out PagerInfo pager,String name,String code,bool enabled,bool queryenabled,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedTaxRates....."));
				try
				{ 
					return pharmacyServcie.QueryPagedTaxRates(out pager,name,code,enabled,queryenabled,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedTaxRates."));
				}
			}
		 
		      
			public TaxRate[] SearchTaxRatesByQueryModel(out String message,QueryTaxRateModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchTaxRatesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchTaxRatesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchTaxRatesByQueryModel."));
				}
			}
		 
		      
			public TaxRate[] SearchPagedTaxRatesByQueryModel(out PagerInfo pager,QueryTaxRateModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedTaxRatesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedTaxRatesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedTaxRatesByQueryModel."));
				}
			}
		 
		      
			public UnitType GetUnitType(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetUnitType....."));
				try
				{ 
					return pharmacyServcie.GetUnitType(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetUnitType."));
				}
			}
		 
		      
			public bool AddUnitType(out String msg,UnitType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddUnitType....."));
				try
				{ 
					return pharmacyServcie.AddUnitType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddUnitType."));
				}
			}
		 
		      
			public bool DeleteUnitType(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteUnitType....."));
				try
				{ 
					return pharmacyServcie.DeleteUnitType(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteUnitType."));
				}
			}
		 
		      
			public bool SaveUnitType(out String msg,UnitType value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveUnitType....."));
				try
				{ 
					return pharmacyServcie.SaveUnitType(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveUnitType."));
				}
			}
		 
		      
			public UnitType[] AllUnitTypes(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllUnitTypes....."));
				try
				{ 
					return pharmacyServcie.AllUnitTypes(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllUnitTypes."));
				}
			}
		 
		      
			public UnitType[] QueryUnitTypes(out String msg,String name,bool enabled,bool queryenabled,String decription,String code)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryUnitTypes....."));
				try
				{ 
					return pharmacyServcie.QueryUnitTypes(out msg,name,enabled,queryenabled,decription,code);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryUnitTypes."));
				}
			}
		 
		      
			public UnitType[] QueryPagedUnitTypes(out PagerInfo pager,String name,bool enabled,bool queryenabled,String decription,String code,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedUnitTypes....."));
				try
				{ 
					return pharmacyServcie.QueryPagedUnitTypes(out pager,name,enabled,queryenabled,decription,code,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedUnitTypes."));
				}
			}
		 
		      
			public UnitType[] SearchUnitTypesByQueryModel(out String message,QueryUnitTypeModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchUnitTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchUnitTypesByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchUnitTypesByQueryModel."));
				}
			}
		 
		      
			public UnitType[] SearchPagedUnitTypesByQueryModel(out PagerInfo pager,QueryUnitTypeModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedUnitTypesByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedUnitTypesByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedUnitTypesByQueryModel."));
				}
			}
		 
		      
			public UploadRecord GetUploadRecord(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetUploadRecord....."));
				try
				{ 
					return pharmacyServcie.GetUploadRecord(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetUploadRecord."));
				}
			}
		 
		      
			public bool AddUploadRecord(out String msg,UploadRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddUploadRecord....."));
				try
				{ 
					return pharmacyServcie.AddUploadRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddUploadRecord."));
				}
			}
		 
		      
			public bool DeleteUploadRecord(out String msg,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:DeleteUploadRecord....."));
				try
				{ 
					return pharmacyServcie.DeleteUploadRecord(out msg,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:DeleteUploadRecord."));
				}
			}
		 
		      
			public bool SaveUploadRecord(out String msg,UploadRecord value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SaveUploadRecord....."));
				try
				{ 
					return pharmacyServcie.SaveUploadRecord(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SaveUploadRecord."));
				}
			}
		 
		      
			public UploadRecord[] AllUploadRecords(out String message)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AllUploadRecords....."));
				try
				{ 
					return pharmacyServcie.AllUploadRecords(out message);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AllUploadRecords."));
				}
			}
		 
		      
			public UploadRecord[] QueryUploadRecords(out String msg,String tablename,int indexfrom,int indexto)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryUploadRecords....."));
				try
				{ 
					return pharmacyServcie.QueryUploadRecords(out msg,tablename,indexfrom,indexto);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryUploadRecords."));
				}
			}
		 
		      
			public UploadRecord[] QueryPagedUploadRecords(out PagerInfo pager,String tablename,int indexfrom,int indexto,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:QueryPagedUploadRecords....."));
				try
				{ 
					return pharmacyServcie.QueryPagedUploadRecords(out pager,tablename,indexfrom,indexto,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:QueryPagedUploadRecords."));
				}
			}
		 
		      
			public UploadRecord[] SearchUploadRecordsByQueryModel(out String message,QueryUploadRecordModel qModel)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchUploadRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchUploadRecordsByQueryModel(out message,qModel);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchUploadRecordsByQueryModel."));
				}
			}
		 
		      
			public UploadRecord[] SearchPagedUploadRecordsByQueryModel(out PagerInfo pager,QueryUploadRecordModel qModel,int index,int size)
			{
			    //Log.Warning(string.Format("开始调用服务方法:SearchPagedUploadRecordsByQueryModel....."));
				try
				{ 
					return pharmacyServcie.SearchPagedUploadRecordsByQueryModel(out pager,qModel,index,size);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:SearchPagedUploadRecordsByQueryModel."));
				}
			}
		 
		      
			public User GetUser(out String message,Guid id)
			{
			    //Log.Warning(string.Format("开始调用服务方法:GetUser....."));
				try
				{ 
					return pharmacyServcie.GetUser(out message,id);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:GetUser."));
				}
			}
		 
		      
			public bool AddUser(out String msg,User value)
			{
			    //Log.Warning(string.Format("开始调用服务方法:AddUser....."));
				try
				{ 
					return pharmacyServcie.AddUser(out msg,value);
				} 
				catch(Exception ex)
				{ 
					 HandleException(ex);
					 throw ex;
				}
				finally
				{
					 //Log.Warning(string.Format("结束调用服务方法:AddUser."));
				}
			}

        //wfz
            public bool AddSupplyPerson(out String msg, SupplyPerson value)
            {
                //Log.Warning(string.Format("开始调用服务方法:AddSupplyPerson....."));
                try
                {
                    return pharmacyServcie.AddSupplyPerson(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:AddSupplyPerson."));
                }
            }


            public bool DeleteSupplyPerson(out String msg, Guid id)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteSupplyPerson....."));
                try
                {
                    return pharmacyServcie.DeleteSupplyPerson(out msg, id);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteSupplyPerson."));
                }
            }


            public bool SaveSupplyPerson(out String msg, SupplyPerson value)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveSupplyPerson....."));
                try
                {
                    return pharmacyServcie.SaveSupplyPerson(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveSupplyPerson."));
                }
            }
        //end
        #region 不合格药品信息处理
            ////药品不合格处理
            public bool AddDrugsUnqualification(out String msg, drugsUnqualication value)
            {
                //Log.Warning(string.Format("开始调用服务方法:drugsUnqualication....."));
                try
                {
                    return pharmacyServcie.AddDrugsUnqualification(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:AddDrugMaintainSet."));
                }
            }

            public bool SaveDrugsUnqualification(out String msg, drugsUnqualication value)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveDrugsUnqualification....."));
                try
                {
                    return pharmacyServcie.SaveDrugsUnqualification(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveDrugsUnqualification."));
                }
            }

            public bool DeleteDrugsUnqualification(out String msg, System.Guid ItemID)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualification....."));
                try
                {
                    return pharmacyServcie.DeleteDrugsUnqualification(out msg, ItemID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualification."));
                }
            }

            public BugsBox.Pharmacy.Models.drugsUnqualificationQuery[] GetDrugsUnqualification(out String msg, System.Guid value)
            {
                //Log.Warning(string.Format("开始调用服务方法:drugsUnqualication....."));
                try
                {
                    return pharmacyServcie.GetDrugsUnqualification(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:GetDrugMaintainSet."));
                }
            }
            public BugsBox.Pharmacy.Models.drugsUnqualication GetDrugsUnqualificationByID(out String msg, System.Guid value)
            {
                //Log.Warning(string.Format("开始调用服务方法:drugsUnqualication....."));
                try
                {
                    return pharmacyServcie.GetDrugsUnqualificationByID(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:GetDrugsUnqualificationByID."));
                }
            }
            public BugsBox.Pharmacy.Models.drugsUnqualication[] GetDrugsUnqualificationByCondition(out String msg, drugsUnqualificationCondition Condition)
            {
                //Log.Warning(string.Format("开始调用服务方法:drugsUnqualication....."));
                try
                {
                    return pharmacyServcie.GetDrugsUnqualificationByCondition(out msg, Condition);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:GetDrugsUnqualificationByCondition."));
                }
            }

            public bool addDrugsUnqualityApproval(drugsUnqualication value, Guid approvalFlowTypeID, Guid userID, string changeNote, out string message)
            {
                try
                {
                    return pharmacyServcie.addDrugsUnqualityApproval(value, approvalFlowTypeID, userID, changeNote, out message);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:GetDrugsUnqualificationByCondition."));
                }
            }
        
            public bool EditDrugUnqualification(Models.drugsUnqualication du, int flag,out string message)
            {
                try
                {
                    return pharmacyServcie.EditDrugUnqualification(du, flag, out message);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:GetDrugsUnqualificationByCondition."));
                }
            }

            public drugsUnqualificationQuery getDrugsUnqualificationQueryByFlowID(Guid FlowID, out string message)
            {
                try
                {
                    return pharmacyServcie.getDrugsUnqualificationQueryByFlowID(FlowID, out message);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:getDrugsUnqualificationQueryByFlowID."));
                }
            }
        #endregion
            #region 获取salesman实体方法
            public System.Collections.Generic.List<Models.SupplyUnitSalesman> GetSalesManBySupplyUnitID(Guid SupplyUnitID, out string message)
            {
                try
                {
                    return pharmacyServcie.GetSalesManBySupplyUnitID(SupplyUnitID, out message);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:getDrugsUnqualificationQueryByFlowID."));
                }
            }
            #endregion


        //组织机构证书
            public OrganizationCodeLicense GetOrganizationCodeLicense(out String message, Guid id)
            {
                //Log.Warning(string.Format("开始调用服务方法:GetOrganizationCodeLicense....."));
                try
                {
                    return pharmacyServcie.GetOrganizationCodeLicense(out message, id);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:GetOrganizationCodeLicense."));
                }
            }


            public bool AddOrganizationCodeLicense(out String msg, OrganizationCodeLicense value)
            {
                //Log.Warning(string.Format("开始调用服务方法:AddOrganizationCodeLicense....."));
                try
                {
                    return pharmacyServcie.AddOrganizationCodeLicense(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:AddOrganizationCodeLicense."));
                }
            }


            public bool DeleteOrganizationCodeLicense(out String msg, Guid id)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteOrganizationCodeLicense....."));
                try
                {
                    return pharmacyServcie.DeleteOrganizationCodeLicense(out msg, id);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteOrganizationCodeLicense."));
                }
            }


            public bool SaveOrganizationCodeLicense(out String msg, OrganizationCodeLicense value)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveOrganizationCodeLicense....."));
                try
                {
                    return pharmacyServcie.SaveOrganizationCodeLicense(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveOrganizationCodeLicense."));
                }
            }


            public OrganizationCodeLicense[] AllOrganizationCodeLicenses(out String message)
            {
                //Log.Warning(string.Format("开始调用服务方法:AllOrganizationCodeLicenses....."));
                try
                {
                    return pharmacyServcie.AllOrganizationCodeLicenses(out message);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:AllOrganizationCodeLicenses."));
                }
            }

            //卫生许可证
            public HealthLicense GetHealthLicense(out String message, Guid id)
            {
                //Log.Warning(string.Format("开始调用服务方法:GetHealthLicense....."));
                try
                {
                    return pharmacyServcie.GetHealthLicense(out message, id);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:GetHealthLicense."));
                }
            }


            public bool AddHealthLicense(out String msg, HealthLicense value)
            {
                //Log.Warning(string.Format("开始调用服务方法:AddHealthLicense....."));
                try
                {
                    return pharmacyServcie.AddHealthLicense(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:AddHealthLicense."));
                }
            }


            public bool DeleteHealthLicense(out String msg, Guid id)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteHealthLicense....."));
                try
                {
                    return pharmacyServcie.DeleteHealthLicense(out msg, id);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteHealthLicense."));
                }
            }


            public bool SaveHealthLicense(out String msg, HealthLicense value)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveHealthLicense....."));
                try
                {
                    return pharmacyServcie.SaveHealthLicense(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveHealthLicense."));
                }
            }


            public HealthLicense[] AllHealthLicenses(out String message)
            {
                //Log.Warning(string.Format("开始调用服务方法:AllHealthLicenses....."));
                try
                {
                    return pharmacyServcie.AllHealthLicenses(out message);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:AllHealthLicenses."));
                }
            }

            //食品流通许可证
            public FoodCirculateLicense GetFoodCirculateLicense(out String message, Guid id)
            {
                //Log.Warning(string.Format("开始调用服务方法:GetFoodCirculateLicense....."));
                try
                {
                    return pharmacyServcie.GetFoodCirculateLicense(out message, id);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:GetFoodCirculateLicense."));
                }
            }


            public bool AddFoodCirculateLicense(out String msg, FoodCirculateLicense value)
            {
                //Log.Warning(string.Format("开始调用服务方法:AddFoodCirculateLicense....."));
                try
                {
                    return pharmacyServcie.AddFoodCirculateLicense(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:AddFoodCirculateLicense."));
                }
            }


            public bool DeleteFoodCirculateLicense(out String msg, Guid id)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteFoodCirculateLicense....."));
                try
                {
                    return pharmacyServcie.DeleteFoodCirculateLicense(out msg, id);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteFoodCirculateLicense."));
                }
            }


            public bool SaveFoodCirculateLicense(out String msg, FoodCirculateLicense value)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveFoodCirculateLicense....."));
                try
                {
                    return pharmacyServcie.SaveFoodCirculateLicense(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveFoodCirculateLicense."));
                }
            }


            public FoodCirculateLicense[] AllFoodCirculateLicenses(out String message)
            {
                //Log.Warning(string.Format("开始调用服务方法:AllFoodCirculateLicenses....."));
                try
                {
                    return pharmacyServcie.AllFoodCirculateLicenses(out message);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:AllFoodCirculateLicenses."));
                }
            }

            //税务登记证
            public TaxRegisterLicense GetTaxRegisterLicense(out String message, Guid id)
            {
                //Log.Warning(string.Format("开始调用服务方法:GetTaxRegisterLicense....."));
                try
                {
                    return pharmacyServcie.GetTaxRegisterLicense(out message, id);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:GetTaxRegisterLicense."));
                }
            }


            public bool AddTaxRegisterLicense(out String msg, TaxRegisterLicense value)
            {
                //Log.Warning(string.Format("开始调用服务方法:AddTaxRegisterLicense....."));
                try
                {
                    return pharmacyServcie.AddTaxRegisterLicense(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:AddTaxRegisterLicense."));
                }
            }


            public bool DeleteTaxRegisterLicense(out String msg, Guid id)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteTaxRegisterLicense....."));
                try
                {
                    return pharmacyServcie.DeleteTaxRegisterLicense(out msg, id);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteTaxRegisterLicense."));
                }
            }


            public bool SaveTaxRegisterLicense(out String msg, TaxRegisterLicense value)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveTaxRegisterLicense....."));
                try
                {
                    return pharmacyServcie.SaveTaxRegisterLicense(out msg, value);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveTaxRegisterLicense."));
                }
            }


            public TaxRegisterLicense[] AllTaxRegisterLicenses(out String message)
            {
                //Log.Warning(string.Format("开始调用服务方法:AllTaxRegisterLicenses....."));
                try
                {
                    return pharmacyServcie.AllTaxRegisterLicenses(out message);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:AllTaxRegisterLicenses."));
                }
            }

        #region 不合格药品销毁实体方法 2014-2-11
            public bool AddDrugsUnqualificationDestroy(DrugsUnqualificationDestroy value ,out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
                try
                {
                    return pharmacyServcie.AddDrugsUnqualificationDestroy(value, out msg );
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
                }
            }

            public bool SaveDrugsUnqualificationDestroy(DrugsUnqualificationDestroy value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.SaveDrugsUnqualificationDestroy(value,out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveDrugsUnqualificationDestroy."));
                }
            }

            public bool DeleteDrugsUnqualificationDestroy(System.Guid ItemID, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.DeleteDrugsUnqualificationDestroy(ItemID , out msg );
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }

            public DrugsUnqualificationDestroy[] getDrugsUnqualificationDestroysByCondition(DateTime dtFrom, DateTime dtTo, string keyword, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:getDrugsUnqualificationDestroysByCondition....."));
                try
                {
                    return pharmacyServcie.getDrugsUnqualificationDestroysByCondition(dtFrom,dtTo,keyword, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:getDrugsUnqualificationDestroysByCondition."));
                }
            }
        #endregion


            #region 待处理药品存储实体方法 2014-3-10
            public bool AddDrugsUndeterminate(DrugsUndeterminate value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
                try
                {
                    return pharmacyServcie.AddDrugsUndeterminate(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
                }
            }

            public bool SaveDrugsUndeterminate(DrugsUndeterminate value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.SaveDrugsUndeterminate(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveDrugsUnqualificationDestroy."));
                }
            }

            public bool DeleteDrugsUndeterminate(System.Guid ItemID, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.DeleteDrugsUndeterminate(ItemID, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }

            public Models.DrugsUndeterminate[] GetDrugsUndeterminate(int state, string source, string keyword, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.GetDrugsUndeterminate(state,source,keyword, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }

            public bool SaveToNextProc(DrugsUndeterminate value, Guid userID, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveToNextProc....."));
                try
                {
                    return pharmacyServcie.SaveToNextProc(value, userID, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }
            #endregion

            #region 拒收单存储实体方法 2014-3-10
            public bool AddDocumentRefuse(DocumentRefuse value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
                try
                {
                    return pharmacyServcie.AddDocumentRefuse(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
                }
            }

            public bool SaveDocumentRefuse(DocumentRefuse value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.SaveDocumentRefuse(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveDrugsUnqualificationDestroy."));
                }
            }

            public bool DeleteDocumentRefuse(System.Guid ItemID, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.DeleteDocumentRefuse(ItemID, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }

            public bool RefuseNextProc(Models.DocumentRefuse value, System.Guid UserID, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.RefuseNextProc(value, UserID,out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }

            public Models.DocumentRefuse[] QueryRefuseDocument(string source, int proc, string keyword, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.QueryRefuseDocument(source,proc,keyword, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }    

            #endregion

            #region 体检档案存储实体方法 2014-3-12
            public bool AddHealthCheckDocument(HealthCheckDocument value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
                try
                {
                    return pharmacyServcie.AddHealthCheckDocument(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
                }
            }

            public bool SaveHealthCheckDocument(HealthCheckDocument value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.SaveHealthCheckDocument(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveDrugsUnqualificationDestroy."));
                }
            }

            public bool DeleteHealthCheckDocument(System.Guid ItemID, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.DeleteHealthCheckDocument(ItemID, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }

            public Models.HealthCheckDocument[] AllHealthCheckDocuments( out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.AllHealthCheckDocuments( out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }

            public Models.HealthCheckDetail[] AllHealthCheckDetails(out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.AllHealthCheckDetails(out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }

            public Models.EduDocument[] AllEduDocuments(out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.AllEduDocuments(out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }

            public Models.EduDetails[] AllEduDetailss(out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.AllEduDetailss(out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }
            #endregion

            #region 体检档案存储实体方法 2014-3-12
            public bool AddHealthCheckDetail(HealthCheckDetail value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
                try
                {
                    return pharmacyServcie.AddHealthCheckDetail(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
                }
            }

            public bool SaveHealthCheckDetail(HealthCheckDetail value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.SaveHealthCheckDetail(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveDrugsUnqualificationDestroy."));
                }
            }

            public bool DeleteHealthCheckDetail(System.Guid ItemID, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.DeleteHealthCheckDetail(ItemID, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }
           
            #endregion

            #region 体检档案存储实体方法 2014-3-12
            public bool AddEduDocument(EduDocument value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
                try
                {
                    return pharmacyServcie.AddEduDocument(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
                }
            }

            public bool SaveEduDocument(EduDocument value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.SaveEduDocument(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveDrugsUnqualificationDestroy."));
                }
            }

            public bool DeleteEduDocument(System.Guid ItemID, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.DeleteEduDocument(ItemID, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }
            #endregion

            #region 体检档案存储实体方法 2014-3-12
            public bool AddEduDetails(EduDetails value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
                try
                {
                    return pharmacyServcie.AddEduDetails(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
                }
            }

            public bool SaveEduDetails(EduDetails value, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:SaveDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.SaveEduDetails(value, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SaveDrugsUnqualificationDestroy."));
                }
            }

            public bool DeleteEduDetails(System.Guid ItemID, out string msg)
            {
                //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
                try
                {
                    return pharmacyServcie.DeleteEduDetails(ItemID, out msg);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
                }
            }
           
            #endregion
        #region 健康、培训关键字查询
         public HealthCheckDocument[] SearchPagedHealthCheckDocumentByAllStrings(out PagerInfo pager, out String message, String keys, int index, int size)
            {
                //Log.Warning(string.Format("开始调用服务方法:SearchPagedHealthCheckDocumentByAllStrings....."));
                try
                {
                    return pharmacyServcie.SearchPagedHealthCheckDocumentByAllStrings(out pager, out message, keys, index, size);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SearchPagedHealthCheckDocumentByAllStrings."));
                }
            }

         public HealthCheckDetail[] SearchPagedHealthCheckDetailByAllStrings(out PagerInfo pager, out String message, String keys, int index, int size)
            {
                //Log.Warning(string.Format("开始调用服务方法:SearchPagedHealthCheckDetailByAllStrings....."));
                try
                {
                    return pharmacyServcie.SearchPagedHealthCheckDetailByAllStrings(out pager, out message, keys, index, size);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SearchPagedHealthCheckDetailByAllStrings."));
                }
            }

         public EduDocument[] SearchPagedEduDocumentByAllStrings(out PagerInfo pager, out String message, String keys, int index, int size)
            {
                //Log.Warning(string.Format("开始调用服务方法:SearchPagedEduDocumentByAllStrings....."));
                try
                {
                    return pharmacyServcie.SearchPagedEduDocumentByAllStrings(out pager, out message, keys, index, size);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SearchPagedEduDocumentByAllStrings."));
                }
            }

            public EduDetails[] SearchPagedEduDetailsByAllStrings(out PagerInfo pager, out String message, String keys, int index, int size)
            {
                //Log.Warning(string.Format("开始调用服务方法:SearchPagedEduDetailsByAllStrings....."));
                try
                {
                    return pharmacyServcie.SearchPagedEduDetailsByAllStrings(out pager, out message, keys, index, size);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    throw ex;
                }
                finally
                {
                    //Log.Warning(string.Format("结束调用服务方法:SearchPagedEduDetailsByAllStrings."));
                }
            }
        #endregion

        //dictricts
        public Provinces[] AllProvinces(out String message)
        {
            //Log.Warning(string.Format("开始调用服务方法:AllProvinces....."));
            try
            {
                return pharmacyServcie.AllProvinces(out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:AllProvinces."));
            }
        }
        public Cities[] AllCities(out String message)
        {
            //Log.Warning(string.Format("开始调用服务方法:AllCities....."));
            try
            {
                return pharmacyServcie.AllCities(out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:AllCities."));
            }
        }
        public Zones[] AllZones(out String message)
        {
            //Log.Warning(string.Format("开始调用服务方法:AllZones....."));
            try
            {
                return pharmacyServcie.AllZones(out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:AllZones."));
            }
        }

        #region 报损存储实体方法 2014-3-12
        public DrugsBreakage[] GetDrugsBreakagesPassed(DrugsBreakage db, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.GetDrugsBreakagesPassed(db, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }
        public bool AddDrugsBreakageByFlowID(Models.DrugsBreakage value, Guid flowTypeID, string changeNote, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.AddDrugsBreakageByFlowID(value, flowTypeID, changeNote, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }

        public DrugsBreakage GetDrugsBreakageByFlowID(Guid flowID, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.GetDrugsBreakageByFlowID(flowID, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }

        public DrugsBreakage GetDrugsBreakage(Guid id, out string msg)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.GetDrugsBreakage(id, out msg);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }

        public bool AddDrugsBreakage(DrugsBreakage value, out string msg)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.AddDrugsBreakage(value, out msg);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }

        public bool SaveDrugsBreakage(DrugsBreakage value, out string msg)
        {
            //Log.Warning(string.Format("开始调用服务方法:SaveDrugsUnqualificationDestroy....."));
            try
            {
                return pharmacyServcie.SaveDrugsBreakage(value, out msg);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:SaveDrugsUnqualificationDestroy."));
            }
        }

        public bool DeleteDrugsBreakage(System.Guid ItemID, out string msg)
        {
            //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
            try
            {
                return pharmacyServcie.DeleteDrugsBreakage(ItemID, out msg);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
            }
        }

        #endregion

        #region 移库存储实体方法 2014-3-12
        public DrugsInventoryMove GetDrugsInventoryMove(Guid id, out string msg)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.GetDrugsInventoryMove(id, out msg);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }

        public bool AddDrugsInventoryMove(DrugsInventoryMove value, out string msg)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.AddDrugsInventoryMove(value, out msg);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }

        public bool SaveDrugsInventoryMove(DrugsInventoryMove value, out string msg)
        {
            //Log.Warning(string.Format("开始调用服务方法:SaveDrugsUnqualificationDestroy....."));
            try
            {
                return pharmacyServcie.SaveDrugsInventoryMove(value, out msg);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:SaveDrugsUnqualificationDestroy."));
            }
        }

        public bool DeleteDrugsInventoryMove(System.Guid ItemID, out string msg)
        {
            //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
            try
            {
                return pharmacyServcie.DeleteDrugsInventoryMove(ItemID, out msg);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
            }
        }

        public bool AddDrugsInventoryMoveByFlowID(Models.DrugsInventoryMove value, System.Guid flowTypeID, string changeNote, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
            try
            {
                return pharmacyServcie.AddDrugsInventoryMoveByFlowID(value, flowTypeID, changeNote, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
            }
        }

        public Models.DrugsInventoryMove GetDrugsInventoryMoveByFlowID(System.Guid flowID, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:DeleteDrugsUnqualificationDestroy....."));
            try
            {
                return pharmacyServcie.GetDrugsInventoryMoveByFlowID(flowID, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:DeleteDrugsUnqualificationDestroy."));
            }
        }
        #endregion


        #region
        public LnstitutionLegalPersonLicense[] GetLnstitutionLegalPersonLicense(LnstitutionLegalPersonLicense value, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.GetLnstitutionLegalPersonLicense(value, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }

        public MmedicalInstitutionPermit[] GetMmedicalInstitutionPermit(MmedicalInstitutionPermit value, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.GetMmedicalInstitutionPermit(value, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }

        public bool OpLnstitutionLegalPersonLicense(LnstitutionLegalPersonLicense value, int op, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.OpLnstitutionLegalPersonLicense(value, op , out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }
        public bool OpMmedicalInstitutionPermit(MmedicalInstitutionPermit value, int op, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.OpMmedicalInstitutionPermit(value, op, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }
        #endregion

        #region 根据定单列表选退货定单
        public Business.Models.ReturnPurchaseOrderList[] GetInventeryOrderListByReturn(string keyword, string supplyUnitName, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.GetInventeryOrderListByReturn(keyword,supplyUnitName, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }

        public Business.Models.PurchaseOrderReturnDetailEntity[] getPurchaseInventoryDetatilEntity(System.Guid id, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.getPurchaseInventoryDetatilEntity(id, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:drugsUnqualicationDestroy."));
            }
        }
        #endregion

        #region 根据购货商id获取销售单列表
        public SalesOrder[] GetSaleOrderByPurchaseUnitID(Guid id, out string message)
        {
            //Log.Warning(string.Format("开始调用服务方法:drugsUnqualicationDestroy....."));
            try
            {
                return pharmacyServcie.GetSaleOrderByPurchaseUnitID(id, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSaleOrderByPurchaseUnitID."));
            }
        }    
        #endregion

        #region 养护细节、待处理药品列表存储过程
        public bool SaveDrugMaintainDetailAndUndeterminate(Models.DrugMaintainRecordDetail[] dmrds, out string message)
        {
            try
            {
                return pharmacyServcie.SaveDrugMaintainDetailAndUndeterminate(dmrds, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSaleOrderByPurchaseUnitID."));
            }
        }
        #endregion

        #region 获取销售单退货单统计
        public System.Collections.Generic.Dictionary<int, decimal> GetSalesReturnSummary(Models.SalesOrder[] so, out string message)
        {
            try
            {
                return pharmacyServcie.GetSalesReturnSummary(so,out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSalesReturnSummary."));
            }
        }
        public SalesOrderReturn[] GetSalesOrderReturnByCreateTime(DateTime dtFrom, DateTime dtTo, out string message)
        {
            try
            {
                return pharmacyServcie.GetSalesOrderReturnByCreateTime(dtFrom,dtTo, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnByCreateTime."));
            }
        }
        #endregion

        #region 销毁报告写入操作
        public bool CreateDestroyByDrugsBreakage(Models.DrugsBreakage[] dbs, Models.DrugsUnqualificationDestroy d, out string message)
        {
            try
            {
                return pharmacyServcie.CreateDestroyByDrugsBreakage(dbs,d, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnByCreateTime."));
            }
        }
        #endregion

        #region 采购冲差价处理
        public bool SubmitRefunds(PurchasingPlan[] pps, int flag, out string message)
        {
            try
            {
                return pharmacyServcie.SubmitRefunds(pps, flag, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnByCreateTime."));
            }
        }

        public System.Collections.Generic.IEnumerable<PurchasingPlan> GetPurchaseRefunds(object[] objs, out string message)
        {
            try
            {
                return pharmacyServcie.GetPurchaseRefunds(objs, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnByCreateTime."));
            }
        }
        #endregion

        #region 采退配送
        public bool SaveDeliveryByPurchaseReturn(Models.PurchaseOrderReturn por, System.Guid createUid, out string message)
        {
            try
            {
                return pharmacyServcie.SaveDeliveryByPurchaseReturn(por,createUid, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnByCreateTime."));
            }
        }
        #endregion


        #region 药品流向
        public System.Collections.Generic.List<Business.Models.DrugPath> GetDrugPath(System.Guid id, int pathType, out string message)
        {
            try
            {
                return pharmacyServcie.GetDrugPath(id, pathType, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnByCreateTime."));
            }
        }
        #endregion

        #region 销售开票时获取供货商
        public System.Collections.Generic.List<HistoryPurchase> GetPurchaseHistoryByInInventoryPurchaseID(System.Guid id, int type,out string message)
        {
            try
            {
                return pharmacyServcie.GetPurchaseHistoryByInInventoryPurchaseID(id, type,out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnByCreateTime."));
            }
        }
        #endregion

        /// <summary>
        /// 库存损益
        /// </summary>
        /// <param name="kw"></param>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<Models.DrugInventoryRecord> GetDrugInventoryRecordPL(string kw, int type, out string message)
        {
            try
            {
                return pharmacyServcie.GetDrugInventoryRecordPL(kw, type, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnByCreateTime."));
            }
        }

        /// <summary>
        /// 客户端查询近效期药品
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="keyword"></param>
        /// <param name="MaintainType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<BugsBox.Pharmacy.Business.Models.DrugInventoryNearExpiration> GetDrugInventoryRecordNearExpirationDate(int Month, string keyword, int MaintainType, out string message)
        {
            try
            {
                return pharmacyServcie.GetDrugInventoryRecordNearExpirationDate(Month, keyword, MaintainType, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnByCreateTime."));
            }
        }

        public void WriteLog(System.Guid Uid, string Content)
        {
            try
            {
                pharmacyServcie.WriteLog(Uid, Content);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetSalesOrderReturnByCreateTime."));
            }
        }

        #region 查询移库记录
        public System.Collections.Generic.IEnumerable<Business.Models.DrugsInventoryMoveRecordModel> GetMoveRecords(Models.DrugsInventoryMove dm, out string message)
        {
            try
            {
                return pharmacyServcie.GetMoveRecords(dm, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetMoveRecords."));
            }
        }
        #endregion

        public System.Collections.Generic.IEnumerable<Business.Models.PurchaseTaxReturn> GetPurchaseTaxReturn(System.Guid SuId, System.DateTime dtF, System.DateTime dtT, out string message)
        {
            try
            {
                return pharmacyServcie.GetPurchaseTaxReturn(SuId,dtF,dtT, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetPurchaseTaxReturn."));
            }
        }

        public bool SavePurchaseOrdersByPurchaseTaxReturn(Business.Models.PurchaseTaxReturn[] list, out string message)
        {
            try
            {
                return pharmacyServcie.SavePurchaseOrdersByPurchaseTaxReturn(list, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetMoveRecords."));
            }
        }

        public System.Collections.Generic.IEnumerable<Business.Models.SalesTaxRate> GetSalesTaxRate(System.Guid Pid, System.Guid Uid, out string message)
        {
            try
            {
                return pharmacyServcie.GetSalesTaxRate(Pid,Uid, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetMoveRecords."));
            }
        }

        public System.Collections.Generic.IEnumerable<Business.Models.SalerTaxManage> GetSalerTaxManage(System.DateTime dtF, System.DateTime DtT, System.Guid purchaseUnitId, string SalerName, out string message)
        {
            try
            {
                return pharmacyServcie.GetSalerTaxManage(dtF, DtT, purchaseUnitId, SalerName, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetMoveRecords."));
            }
        }

        public bool SaveSaleOrderTaxRate(System.Collections.Generic.List<Business.Models.SalerTaxManage> ListST, int locker, out string message)
        {
            try
            {
                return pharmacyServcie.SaveSaleOrderTaxRate(ListST,locker, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                //Log.Warning(string.Format("结束调用服务方法:GetMoveRecords."));
            }
        }

        public System.Collections.Generic.IEnumerable<Business.Models.AllTax> GetAllTax(System.DateTime dtF, System.DateTime dtT, System.Guid salerID, out string message)
        {
            try
            {
                return pharmacyServcie.GetAllTax(dtF, dtT, salerID, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {
                
            }
        }
        public bool AddVehicleToApprovalByFlowID(Models.Vehicle value, System.Guid flowTypeID, string ChangeNote, out string message)
        {
            try
            {
                return pharmacyServcie.AddVehicleToApprovalByFlowID(value, flowTypeID, ChangeNote,out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {

            }
        }

        public Vehicle GetVehicleByFlowID(System.Guid flowId, out string message)
        {
            try
            {
                return pharmacyServcie.GetVehicleByFlowID(flowId,out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {

            }
        }

        public System.Collections.Generic.IEnumerable<Business.Models.PurchaseOrderReturnModel> GetPReturnOrderByQureyModel(Business.Models.PurchaseOrderReturnQueryModel q, out string message)
        {
            try
            {
                return pharmacyServcie.GetPReturnOrderByQureyModel(q,out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {

            }
        }

        public IEnumerable<Business.Models.SaleOrderModel> GetSaleRefundHistory(SalesCodeSearchInput searchInput, out string message)
        {
            try
            {
                return pharmacyServcie.GetSaleRefundHistory(searchInput, out message);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw ex;
            }
            finally
            {

            }
        }
    }


}
