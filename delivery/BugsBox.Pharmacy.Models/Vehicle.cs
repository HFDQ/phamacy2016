using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 车辆
    /// Version:2013.07.16.2143
    /// 由张小艾完成
    /// </summary>
    [Description("车辆")]
    [DataContract(IsReference = true)]
    public class Vehicle : Entity,IStore
    {
        #region Entiy Property

        [DataMember]
        public Guid? createUID { get; set; }

        [DataMember]
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 车类型
        /// </summary>
        [Required]
        [DataMember(Order = 0)]
        public string Type { get; set; }

        /// <summary>
        /// 类别
        /// </summary>  
        [DataMember(Order = 0)]
        public int VehicleCategoryValue { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public VehicleCategory VehicleCategory
        {
            get { return (VehicleCategory)VehicleCategoryValue; }
            set { VehicleCategoryValue = (int)value; }
        }

        /// <summary>
        /// 容积
        /// </summary>
        [Required]
        [DataMember(Order = 1)]
        public string Cubage { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        [Required]
        [DataMember(Order = 2)]
        public string LicensePlate { get; set; }

        /// <summary>
        /// 规则
        /// </summary> 
        //[Required]
        //[MinLength(1)]
        [DataMember(Order = 3)]
        public string Rule { get; set; }

        /// <summary>
        /// 其他参数
        /// </summary>  
        [DataMember(Order = 4)]
        public string Other { get; set; }


        /// <summary>
        /// 驾驶员
        /// </summary> 
        //[Required]
        [DataMember(Order = 5)]
        public string Driver { get; set; }

        /// <summary>
        /// 状态(使用中 == 1, 未使用 == 0)
        /// </summary>
        [DataMember(Order = 6)]
        public bool Status { get; set; }


        /// <summary>
        /// 是否外审
        /// </summary>  
        [DataMember(Order = 7)]
        public bool IsOutCheck { get; set; }

        /// <summary>
        /// 是否通过审核
        /// </summary>
        [DataMember]
        public int? ApprovalStatusValue { get; set; }

        //public ApprovalStatus ApprovalStatus
        //{
        //    get { return (ApprovalStatus)ApprovalStatusValue; }
        //    set
        //    {
        //        ApprovalStatusValue = (int)value;
        //    }
        //}

        /// <summary>
        /// 审批流程
        /// </summary>  
        [DataMember(Order = 9)]
        public Guid? FlowID { get; set; }

        /// <summary>
        /// 委托人
        /// </summary>
        [DataMember(Order = 10)]
        public string DelegateMan { get; set; }

        /// <summary>
        /// 委托公司
        /// </summary>
        [DataMember(Order = 11)]
        public string DelegateCompany { get; set; }

        /// <summary>
        /// 委托电话
        /// </summary>
        [DataMember(Order = 12)]
        public string DelegateTel { get; set; }

        // <summary>
        /// 道路运输许可证号
        /// </summary>
        [DataMember(Order = 13)]
        public string LiscenceCode { get; set; }

        // <summary>
        /// 地址
        /// </summary>
        [DataMember(Order = 14)]
        public string DelegateAddr { get; set; }

        // <summary>
        /// 经营范围
        /// </summary>
        [DataMember(Order = 12)]
        public string DelegateScope { get; set; }

        // <summary>
        /// 证照颁发日期
        /// </summary>
        [DataMember(Order = 12)]
        public DateTime? StartDate { get; set; }

        // <summary>
        /// 证照截止日期
        /// </summary>
        [DataMember(Order = 12)]
        public DateTime? EndDate { get; set; }

        #endregion

        

        #region Navigation Property

        [DataMember(Order = 7)]
        public Guid StoreId { get; set; }
        #endregion

    }
}

