using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.IServices
{
    /// <summary>
    /// 通知的客户端回调
    /// 由服务端调用
    /// </summary>
    [ServiceContract(Namespace = "http://www.bugsbox.bugsbox/PharmacyNotification")]
    public interface IPharmacyNotificationCallback
    {
        #region 三大对象审批通知
        [OperationContract(IsOneWay = true)]
        void test(string a);
        #endregion 三大对象审批通知

        #region 药物库存通知
        #endregion 药物库存通知

        #region 销售相关通知
        [OperationContract(IsOneWay = true)]
        void NeedApprovalForSales(Business.Models.NotifyData[] NotifyData);
        #endregion 销售相关通知

        #region 采购相关通知
        #endregion 采购相关通知

        #region 药品养护相关通知
        #endregion 药品养护相关通知

        #region 用户上线通知

        /// <summary>
        /// 有用户上线了
        /// </summary>
        /// <param name="user"></param>
        [OperationContract(IsOneWay=true)]
        void UserOnLine(User user);

        [OperationContract(IsOneWay = true)]
        void SayHello(string hello);

        [OperationContract(IsOneWay = true)]
        void RoleAuthorityChanged();

        #endregion 

        #region 锁定通知
        [OperationContract(IsOneWay = true)]
        void DrugLock(int number);
        [OperationContract(IsOneWay = true)]
        void SupplyUnitLock(int number);
        [OperationContract(IsOneWay = true)]
        void PurchaseUnitLock(int number);

        #endregion

        #region 审批通知
        [OperationContract(IsOneWay = true)]
        void NeedApproval(Business.Models.WarningData[] approvals);
        #endregion

        /// <summary>
        /// 养护通知
        /// </summary>
        /// <param name="day"></param>
        [OperationContract(IsOneWay = true)]
        void NeedDrugMaintain(int day);
        /// <summary>
        /// 疑问药品通知
        /// </summary>
        /// <param name="number"></param>
        [OperationContract(IsOneWay = true)]
        void NeedHandledDoubtDrug(int number);

        /// <summary>
        /// 销售通知
        /// </summary>
        /// <param name="approvals"></param>
        [OperationContract(IsOneWay = true)]
        void NeedHandleSale(Business.Models.WarningData[] approvals);


        /// <summary>
        /// 采购相关通知
        /// </summary>
        /// <param name="approvals"></param>
        [OperationContract(IsOneWay = true)]
        void NeedHandlePurchase(Business.Models.WarningData[] approvals);

        /// <summary>
        /// 缺货通知
        /// </summary>
        /// <param name="approvals"></param>
        [OperationContract(IsOneWay = true)]
        void DrugOutofStock(int number);
    }
}
