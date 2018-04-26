using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DeliveryTrasactionModel
    {
        /// <summary>
        /// 配送ID
        /// </summary>
        [DataMember]
        [System.ComponentModel.DisplayName("配送编号")]
        public Guid Id { get; set; }

        /// <summary>
        /// 销售单ID
        /// </summary>
        [DataMember]
        [System.ComponentModel.DisplayName("销售单编号")]
        public Guid SalesOrderId { get; set; }

        /// <summary>
        /// 销售单号
        /// </summary>
        [DataMember]
        [System.ComponentModel.DisplayName("定单号")]
        public string SalesOrderDocumentNumber { get; set; }

        /// <summary>
        /// 捡货复核ID
        /// </summary>
        [DataMember]
        [System.ComponentModel.DisplayName("捡货复核编号")]
        public Guid OutInvetoryId { get; set; }

        /// <summary>
        /// 捡货复核ID
        /// </summary>
        [DataMember]
        [System.ComponentModel.DisplayName("捡货复核单号")]
        public string OutInvetoryDocumentNumber { get; set; }

        /// <summary>
        /// 收货公司
        /// </summary>
        [DataMember]
        public Guid ReceivingCompasnyID { get; set; }

        /// <summary>
        /// 收货公司名称
        /// </summary>
        [DataMember]
        public string ReceivingCompasnyName { get; set; }

        /// <summary>
        /// 出库药品数量
        /// </summary>
        [DataMember]
        [System.ComponentModel.DisplayName("出库药品数量")]
        public Decimal OutInventoryNumber { get; set; }

        [DataMember]
        [System.ComponentModel.DisplayName("创建时间")]
        public DateTime OutInventoryDateTime { get; set; }

        /// <summary>
        /// 0表示销售，1、表示采购退货
        /// </summary>
        [DataMember]
        [System.ComponentModel.DisplayName("状态")]
        public int Status { get; set; }
    }
}
