using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 销售发货记录的明细
    /// 用来记录某次发货发哪些对应的订单明细
    /// 产生销售发货记录的明细要处理出库单，处理药品库存数量，处理库存数量
    /// </summary>
    [DataContract(IsReference = true)]
    public class SalesOrderDeliverDetail:Entity,IStore
    {
        #region Entiy Property

        #endregion

        #region Navigation Property


        [DataMember(Order = 7)]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 如条发货记录编号
        /// </summary>
        public Guid SalesOrderDeliverRecordId { get; set; }

        /// <summary>
        /// 哪条发货记录
        /// </summary>
        [DataMember]
        public SalesOrderDeliverRecord SalesOrderDeliverRecord { get; set; }

        [DataMember]
        public Guid SalesOrderDetailId { get; set; }

        #endregion
    }
}
