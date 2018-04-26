using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 配送信息
    /// </summary>
    [Description("配送信息")]
    [DataContract(IsReference = true)]
    public class Delivery:Entity, ILEntity,IStore
    {
        #region 配送基本信息
        /// <summary>
        /// 发货时间
        /// </summary>
        [DataMember]
        public DateTime DeliveryTime { get; set; }
        /// <summary>
        /// 发货地址
        /// </summary>
        [DataMember]
        public string ShippingAddress { get; set; }
        /// <summary>
        /// 收货公司
        /// </summary>
        [DataMember]
        public Guid ReceivingCompasnyID { get; set; }
        /// <summary>
        /// 收货公司名称
        /// </summary>
        [NotMapped]
        [DataMember]
        public string ReceivingCompasnyName { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        [DataMember]
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// 货单号
        /// </summary>
        [DataMember]
        public string ManifestNumber { get; set; }
        /// <summary>
        /// 药品件数
        /// </summary>
        [DataMember]
        [Required]
        public decimal DrugsCount { get; set; }
        /// <summary>
        /// 配送方式值
        /// </summary>
        [DataMember]
        public int DeliveryMethodValue { get; set; }
        /// <summary>
        /// 配送方式
        /// </summary>
        public DeliveryMethod DeliveryMethod
        {
            get { return (DeliveryMethod)this.DeliveryMethodValue; }
            set { this.DeliveryMethodValue = (int)value; }
        }
        /// <summary>
        /// 运输方式值
        /// </summary>
        [DataMember]
        public int TransportMethodValue { get; set; }
        /// <summary>
        /// 运输方式
        /// </summary>
        public TransportMethod TransportMethod
        {
            get { return (TransportMethod)this.TransportMethodValue; }
            set { this.TransportMethodValue = (int)value; }
        }
        /// <summary>
        /// 委托人
        /// </summary>
        [DataMember]
        public string Principal { get; set; }
        /// <summary>
        /// 委托人电话
        /// </summary>
        [DataMember]
        public string PrincipalPhone { get; set; }
        /// <summary>
        /// 运输公司
        /// </summary>
        [DataMember]
        public string TransportCompany { get; set; }
        /// <summary>
        /// 车辆信息
        /// </summary>
        [DataMember]
        public string VehicleInfo { get; set; }
        /// <summary>
        /// 车辆信息(自有车辆的情况下使用)
        /// </summary>
        [DataMember]
        public Guid VehicleID { get; set; }

        /// <summary>
        /// 配送状态值
        /// </summary>
        [DataMember]
        [Required]
        public int DeliveryStatusValue { get; set; }
        /// <summary>
        /// 配送状态
        /// </summary>
        public DeliveryStatus DeliveryStatus 
        {
            get { return (DeliveryStatus)this.DeliveryStatusValue; } 
            set { this.DeliveryStatusValue = (int)value; } 
        }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Memo { get; set; }

        /// <summary>
        /// 配送结束状态
        /// </summary>
        [DataMember]
        public bool IsOver { get; set; }


#endregion

        #region 配送预约
        /// <summary>
        /// 配送预约操作时间
        /// </summary>
        [DataMember]
        public DateTime ReservationTime { get; set; }
        /// <summary>
        /// 配送预约操作者
        /// </summary>
        [DataMember]
        public Guid ReservationOperatorId { get; set; }
        /// <summary>
        /// 配送预约操作编号
        /// </summary>
        [DataMember]
        public string ReservationNo { get; set; }

        #endregion

        #region 配送受理
        /// <summary>
        /// 配送受理操作时间
        /// </summary>
        [DataMember]
        public DateTime AcceptedTime { get; set; }
        /// <summary>
        /// 配送受理操作者
        /// </summary>
        [DataMember]
        public Guid AcceptedOperatorId { get; set; }
        /// <summary>
        /// 配送受理操作编号
        /// </summary>
        [DataMember]
        public string AcceptedNo { get; set; }

        #endregion

        #region 配送取消
        /// <summary>
        /// 配送取消操作时间
        /// </summary>
        [DataMember]
        public DateTime CanceledTime { get; set; }
        /// <summary>
        /// 配送取消操作者
        /// </summary>
        [DataMember]
        public Guid CanceledOperatorId { get; set; }
        /// <summary>
        /// 配送取消操作编号
        /// </summary>
        [DataMember]
        public string CanceledNo { get; set; }

        #endregion

        #region 配送出库
        /// <summary>
        /// 配送出库操作时间
        /// </summary>
        [DataMember]
        public DateTime outedTime { get; set; }
        /// <summary>
        /// 配送出库操作者
        /// </summary>
        [DataMember]
        public Guid outedOperatorId { get; set; }
        /// <summary>
        /// 配送出库操作编号
        /// </summary>
        [DataMember]
        public string outedNo { get; set; }

        #endregion

        #region 配送签收
        /// <summary>
        /// 配送签收操作时间
        /// </summary>
        [DataMember]
        public DateTime SignedTime { get; set; }
        /// <summary>
        /// 配送签收操作者
        /// </summary>
        [DataMember]
        public Guid SignedOperatorId { get; set; }
        /// <summary>
        /// 配送签收操作编号
        /// </summary>
        [DataMember]
        public string SignedNo { get; set; }

        #endregion

        #region 销退申请
        /// <summary>
        /// 销退申请操作时间
        /// </summary>
        [DataMember]
        public DateTime ReturnTime { get; set; }
        /// <summary>
        /// 销退申请操作者
        /// </summary>
        [DataMember]
        public Guid ReturnOperatorId { get; set; }
        /// <summary>
        /// 销退申请收操作编号
        /// </summary>
        [DataMember]
        public string ReturnNo { get; set; }

        #endregion

        #region ILEntity
        [DataMember]
        public DateTime CreateTime{ get; set; }
        [DataMember]
        public Guid CreateUserId { get; set; }
        [DataMember]
        public DateTime UpdateTime { get; set; }
        [DataMember]
        public Guid UpdateUserId { get; set; }
        #endregion

        #region Navigation Property

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        [DataMember]
        public Guid OrderID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [NotMapped]
        [DataMember]
        public string SalesOrder { get; set; }

        /// <summary>
        /// 出库ID
        /// </summary>
        [DataMember]
        public Guid OutInventoryID { get; set; }

        /// <summary>
        /// 自有车辆管理ID
        /// </summary>
        [DataMember]
        public Guid OwnVehicleID { get; set; }

        #endregion
    }
}
