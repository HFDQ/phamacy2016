using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class WareHouseZonePositionModel
    {
        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称")]
        public string WareHouseName { get; set; }

        [DataMember]
        public Guid WareHouseId { get; set; }

        /// <summary>
        /// 库区名称
        /// </summary>
        [DataMember]
        [DisplayName("(库区)货架名称")]
        public string WareHouseZoneName { get; set; }

        /// <summary>
        /// 库区标签ID
        /// </summary>
        [DataMember]
        [DisplayName("(库区)货架标签ID")]
        public int WareHouseZonePIndex { get; set; }

        [DataMember]
        public Guid WareHouseZoneId { get; set; }

        /// <summary>
        /// 货位ID
        /// </summary>
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// 顺序号
        /// </summary>
        [DataMember]
        [DisplayName("货位标签ID")]
        public int PIndex { get; set; }

        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        [DisplayName("货位名称")]
        public string Name { get; set; }

        /// <summary>
        /// 容量
        /// </summary>
        [DataMember]
        [DisplayName("容量")]
        public decimal Capacity { get; set; }


        /// <summary>
        /// 行列
        /// </summary>
        [DataMember]
        [DisplayName("行列")]
        public string RowCol { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [DataMember]
        [DisplayName("说明")]
        public string Memo { get; set; }

        [DataMember]
        [DisplayName("条码信息")]
        public string BarCode 
        { 
            get{
                string zId=this.WareHouseZonePIndex.ToString().PadLeft(3,'0');
                string pid=this.PIndex.ToString().PadLeft(3,'0');
                return "9999"+zId + pid;
            }
        }

    }

    public class WarehouseZonePositionOutInventoryModel
    {
        /// <summary>
        /// 顺序号
        /// </summary>
        [DataMember]
        [DisplayName("标签序号")]
        public int PIndex { get; set; }

        /// <summary>
        /// 库区标签ID
        /// </summary>
        [DataMember]
        [DisplayName("(库区)货架标签ID")]
        public int WareHouseZonePIndex { get; set; }

        /// <summary>
        /// 标签上显示的出库数量
        /// </summary>
        [DataMember]
        public decimal OutAmount { get; set; }

        /// <summary>
        /// 销售订单号
        /// </summary>
        [DataMember]
        public string OrderNumber { get; set; }
    }
    public class WareHouseZonePositionQueryModel
    {
        /// <summary>
        /// 货位ID
        /// </summary>
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [DataMember]
        public Guid WareHouseId { get;set;}

        /// <summary>
        /// 仓库货架ID
        /// </summary>
        [DataMember]
        public Guid WareHouseZoneId { get; set; }

        /// <summary>
        /// 货位查询的关键字
        /// </summary>
        [DataMember]
        public string Keyword { get; set; }

        /// <summary>
        /// 按仓库查询货位的关键字
        /// </summary>
        [DataMember]
        public string whKeyword { get; set; }

        /// <summary>
        /// 按仓库货架查询货位的关键字
        /// </summary>
        [DataMember]
        public string whzKeyword { get; set; }
    }
}
