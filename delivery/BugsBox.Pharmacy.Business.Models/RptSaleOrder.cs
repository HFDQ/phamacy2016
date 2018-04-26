using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class RptSaleOrder
    {
        /// <summary>
        /// 购货单位
        /// </summary>
        [DataMember]
        public string PurchaseUnit { get; set; }

        /// <summary>
        /// 开票时间
        /// </summary>
        [DataMember]
        public DateTime? SalesDate { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [DataMember]
        public string SaleOrderNumber { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        [DataMember]
        public string CheckMethod { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public string productName { get; set; }


        /// <summary>
        /// 商品规格
        /// </summary>
        [DataMember]
        public string DictionarySpecificationCode { get; set; }

        /// <summary>
        /// 剂型
        /// </summary>
        [DataMember]
        public string DictionaryDosageCode { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public string DictionaryMeasurementUnitCode { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public int Number { get; set; }

        /// <summary>
        /// 销售价
        /// </summary>
        [DataMember]
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public decimal SumMoney { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        [DataMember]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        [DataMember]
        public DateTime ValidPeriod { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [DataMember]
        public string WareHouse { get; set; }

        /// <summary>
        /// 质量状况
        /// </summary>
        [DataMember]
        public string QualityStatus { get; set; }

        /// <summary>
        /// 开票员
        /// </summary>
        [DataMember]
        public string Drawer { get; set; }

        /// <summary>
        /// 收款员
        /// </summary>
        [DataMember]
        public string Beneficiary { get; set; }

        /// <summary>
        /// 业务员
        /// </summary>
        [DataMember]
        public string Salesman { get; set; }

        /// <summary>
        /// 药品生产商
        /// </summary>
        [DataMember]
        public string FactoryName { get; set; }

        /// <summary>
        /// 发货人
        /// </summary>
        [DataMember]
        public string Consignor { get; set; }

        /// <summary>
        /// 复核人
        /// </summary>
        [DataMember]
        public string ReChecker { get; set; }


    }
}
