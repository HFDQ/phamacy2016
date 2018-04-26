using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 库存记录某药品的库存量
    /// 不记录药物存放在何库区
    /// 在产生药物库存时处理
    /// 某药物第一次入库里新建此记录
    /// 后续某药物产生药物库存时要针对DrugInfoId或DrugInfoCode修改当前库存数据
    /// 可销售可零售数量=CurrentInventoryCount-OnSalesOrderCount-OnRetailCount
    /// </summary>
    [Description("库存")]
    [DataContract(IsReference = true)]
    public class InventoryRecord : Entity,IStore
    {
        #region Entiy Property  

        /// <summary>
        /// 最大库存报警
        /// </summary>
        [DataMember]
        public decimal MaxInventoryCount { get; set; }

        /// <summary>
        /// 最小库存报警
        /// </summary>
        [DataMember]
        public decimal MinInventoryCount { get; set; }

        /// <summary>
        /// 当前库存数量(在库)
        /// </summary>
        [DataMember]
        public decimal CurrentInventoryCount { get; set; }

        /// <summary>
        /// 已经销售且出库的数量
        /// </summary>
        [DataMember]
        public decimal SalesCount { get; set; } 

        /// <summary>
        /// 在销售单但未出库数量
        /// </summary>
         [DataMember]
        public decimal OnSalesOrderCount { get; set; }

        /// <summary>
        /// 已经零售且已经卖出的数量
        /// </summary>
         [DataMember]
        public decimal RetailCount { get; set; }

        /// <summary>
        /// 被零售客户端加入零售明细的数量
        /// </summary>
         [DataMember]
        public decimal OnRetailCount { get; set; }


         /// <summary>
         /// 待售拆零数量
         /// </summary>
         [DataMember]
         public decimal DismantingAmount { get; set; }

         /// <summary>
         /// 已售拆零数量
         /// </summary>
         [DataMember]
         public decimal RetailDismantingAmount { get; set; }

        #endregion

        #region Navigation Property 

        /// <summary>
        /// 药物编号
        /// </summary>
       [DataMember]
        public Guid DrugInfoId { get; set; }

        /// <summary>
        /// 药物编码
        /// </summary>
        [DataMember]
        public string DrugInfoCode { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        #endregion
    }
}

