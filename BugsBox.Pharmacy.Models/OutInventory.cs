using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 出库记录
    /// 一次发货记录只能一次出库
    /// 针对销售的发出库记录在产生销售发货记录时产生因此出库记录要有是否已经出库标识
    /// 出库记录标识为出库时要处理药物库存记录当前库存数量和销售数量
    /// </summary>
    [Description("销售出库单")]
    [DataContract(IsReference = true)]
    public class OutInventory : Entity, IStore
    {
        #region Entiy Property

        /// <summary>
        /// 出库单号
        /// </summary>
        [Required]
        
        [MinLength(1)]
        [DataMember]
        public string OutInventoryNumber { get; set; }

        /// <summary>
        /// 创建用户编号
        /// 此表为销售人员编号
        /// </summary>
        [DataMember]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 保管员
        /// </summary>
        [Required]
        [DataMember]
        public Guid storekeeperId { get; set; }

        /// <summary>
        /// 复核员
        /// </summary>
        [Required]
        [DataMember]
        public Guid ReviewerId { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        [Required]
        [DataMember]
        public DateTime OutInventoryDate { get; set; }

        /// <summary>
        /// 描述即备注
        /// </summary>
        
        [DataMember]
        public string Description { get; set; }

        #region 销售出库

        /// <summary>
        /// 销售出库用户ID
        /// </summary>
        [DataMember]
        public Guid OrderOutInventoryUserID { get; set; }

        /// <summary>
        ///  销售出库时间
        /// </summary>
        [DataMember]
        public DateTime? OrderOutInventoryTime { get; set; }
        #endregion

        #region 销售出库审核

        /// <summary>
        /// 销售出库审核单号
        /// </summary>
        [DataMember]
        public string OrderOutInventoryCheckNumber { get; set; }

        /// <summary>
        /// 销售出库审核用户ID
        /// </summary>
        [DataMember]
        public Guid OrderOutInventoryCheckUserID { get; set; }

        /// <summary>
        ///  销售出库审核时间
        /// </summary>
        [DataMember]
        public DateTime? OrderOutInventoryCheckTime { get; set; }
        #endregion

        /// <summary>
        /// 销售总额（金额合计）
        /// </summary>
        [DataMember(Order = 8)]
        public decimal TotalMoney { get; set; }

        /// <summary>
        /// 税额总额（金额合计）
        /// </summary>
        [DataMember]
        public decimal TotalTax { get; set; }

        /// <summary>
        /// 出库类型
        /// </summary>
        [DataMember]
        public int OutInventoryTypeValue { get; set; }

        /// <summary>
        /// 出库类型
        /// </summary>
        public OutInventoryType OutInventoryType
        {
            get { return (OutInventoryType)OutInventoryTypeValue; }
            set { OutInventoryTypeValue = (int)value; }
        }

        /// <summary>
        /// 出库状态
        /// </summary>
        [DataMember]
        public int OutInventoryStatusValue { get; set; }

        /// <summary>
        /// 出库状态
        /// </summary>
        public OutInventoryStatus OutInventoryStatus
        {
            get { return (OutInventoryStatus)OutInventoryStatusValue; }
            set { OutInventoryStatusValue = (int)value; }
        }

        #endregion


        #region Navigation Property

        /// <summary>
        /// 销售ID
        /// </summary>
        [Required]
        [DataMember]
        public Guid SalesOrderID { get; set; }
        /// <summary>
        /// 销售单号
        /// </summary>
        
        [DataMember]
        public string OrderCode { get; set; }

        /// <summary>
        /// 销退ID
        /// </summary>
        [Required]
        [DataMember]
        public Guid SalesOrderReturnID { get; set; }

        /// <summary>
        /// 发货记录
        /// </summary>
        [DataMember(Order = 15)]
        public virtual ICollection<OutInventoryDetail> SalesOutInventoryDetails { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        [NotMapped]
        [DataMember]
        public string keepper { get; set; }

        #endregion


        #region 特殊药品复核员，第一复核员与普通药品复核员合并
        /// <summary>
        /// 特药第二复核员，拣货后，从配置文件中自动写入该表，复核界面打开需判断是否是该复核员进行复核。
        /// </summary>
        [DataMember]
        public Guid SpecialDrugSecondChecker { get; set; }

        /// <summary>
        /// 复核时间
        /// </summary>
        [DataMember]
        public DateTime SecondCheckDateTime { get; set; }

        /// <summary>
        /// 复核意见
        /// </summary>
        [DataMember]
        public string SecondeCheckMemo { get; set; }
        #endregion
    }
}
