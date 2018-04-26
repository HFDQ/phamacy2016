using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class SalesOrderOutInventoryModel
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        [DisplayName("出库单号")]
        public string OutInventoryOrderCode { get; set; }

        [DataMember]
        public Guid SalesOrderId { get; set; }

        [DataMember]
        [DisplayName("库管员")]
        public string InventoryKeeper { get; set; }

        [DataMember]
        [DisplayName("销售单号")]
        public string OrderCode { get; set; }

        [DataMember]
        public DateTime SalesOrderCreateTime { get; set; }

        [DataMember]
        [DisplayName("创建时间")]
        public string SalesOrderCreateTimeStr { get => this.SalesOrderCreateTime.ToLongDateString(); }

        [DataMember]
        [DisplayName("销售员")]
        public string SalerName { get; set; }

        [DataMember]
        public int OutInventoryTypeValue { get; set; }

        [DataMember]
        [DisplayName("出库类型")]
        public string OutInventoryTypeStr { get
            {
                if (this.OutInventoryTypeValue == (int)Pharmacy.Models.OutInventoryType.SalesNormal)
                {
                    return "销售出库";
                }
                return "其他";
            }
        }
    }

    /// <summary>
    /// 查询Model
    /// </summary>
    public class SalesOrderOutInventoryQueryModel : BaseQueryModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int OutInventoryStatusValue { get; set; }

        public Guid FirstCheckerUserId { get; set; }

        public Guid SecondCheckerUserInd { get; set; }
    }
}
