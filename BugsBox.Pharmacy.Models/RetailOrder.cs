using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BugsBox.Pharmacy.Models.Config;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 零售单
    /// 1.应收款=金额总计-调减金额
    /// 2.实付(实收款)=收钱-找零
    /// 3.实付(实收款)可能小于应收款,因为小数点问题
    /// 4.金额总计=(零售单明细金额+零售单明细金额1+...)
    /// </summary>
    [DataContract(IsReference = true)]
    public class RetailOrder : Entity, ILEntity,IStore
    {
        #region Entiy Property

        #region ILEntity


        /// <summary>
        /// 营业员编号
        /// </summary>
        [DataMember]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 订单时间
        /// </summary>
        [Required(ErrorMessage = "请输入[订单时间]")]
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime UpdateTime { get; set; }


        #endregion ILEntity

        #region 零售信息 

        /// <summary>
        /// 单号
        /// </summary>
        [Required(ErrorMessage = "请输入[单号]")]
        [DisplayName("单号")]
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// 备注
        /// </summary> 
        [DisplayName("备注")]
        [DataMember]
        public string Description { get; set; }

        #endregion 零售信息

        #region 数量与金钱

        /// <summary>
        /// 金额总计
        /// </summary>
        [DataMember]
        public decimal TotalMoney { get; set; }

        /// <summary>
        /// 调减金额
        /// </summary>
        [DataMember]
        public decimal ReduceMoney { get; set; }

        /// <summary>
        /// 应收款=金额总计-调减金额
        /// </summary>
        [DataMember]
        public decimal ReceivableMoney { get; set; }

        #region 付款与结算情况

        /// <summary>
        /// 收钱
        /// </summary>
        [DataMember]
        public decimal GotMoney { get; set; }

        /// <summary>
        /// 找零
        /// </summary>
        [DataMember]
        public decimal ChangeMoney { get; set; }

        /// <summary>
        /// 实付(实收款)=收钱-找零
        /// </summary>
        [DataMember]
        public decimal RealPayMoney { get; set; }

        
        /// <summary>
        /// 付款方式值
        /// </summary>
        [DataMember]
        public int RetailCustomerTypeValue { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public RetailCustomerType RetailCustomerType
        {
            get { return (RetailCustomerType)RetailCustomerTypeValue; }
            set { RetailCustomerTypeValue = (int)value; }
        }

        /// <summary>
        /// 付款方式值
        /// </summary>
        [DataMember]
        public int RetailPaymentMethodValue { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public RetailPaymentMethod RetailPaymentMethod
        {
            get { return (RetailPaymentMethod)RetailPaymentMethodValue; }
            set { RetailPaymentMethodValue = (int)value; }
        }

        #endregion 付款与结算情况


        /// <summary>
        /// 退货金额总计
        /// </summary>
        [DataMember]
        public decimal TotalRefund { get; set; }

        /// <summary>
        /// 退货调减金额
        /// </summary>
        [DataMember]
        public decimal ReturnReduceMoney { get; set; }

        /// <summary>
        /// 退货应收款=退货金额总计-退货调减金额
        /// </summary>
        [DataMember]
        public decimal ReturnReceivableMoney { get; set; }


        /// <summary>
        /// 退货实收款
        /// </summary>
        [DataMember]
        public decimal ReturnRealReceiveMoney { get; set; }



        #endregion




        #endregion

        #region Navigation Property 

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 订单明细
        /// </summary>
        [DataMember]
        public virtual ICollection<RetailOrderDetail> RetailOrderDetails { get; set; }

        #endregion
    }
}
