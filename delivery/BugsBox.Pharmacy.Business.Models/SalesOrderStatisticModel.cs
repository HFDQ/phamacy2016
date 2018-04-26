using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// 销售订单统计检索条件
    /// </summary>
    [DataContract]
    public class SalesOrderStatisticInput
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        [DataMember]
        public DateTime FromDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        [DataMember]
        public DateTime ToDate { get; set; }
        /// <summary>
        /// 时间单位(StatisticTimeUnit)
        /// </summary>
        [DataMember]
        public int TimeUnit { get; set; }
        /// <summary>
        /// 统计对象(StatisticObject枚举)
        /// </summary>
        [DataMember]
        public int StatisticObject { get; set; }
    }

    /// <summary>
    /// 销售订单统计结果
    /// </summary>
    [DataContract]
    public class SalesOrderStatisticOutput
    {
        /// <summary>
        /// 统计对象名称
        /// </summary>
        [DataMember]
        public string StatisticObject { get; set; }

        [DataMember]
        public string DrugName { get; set; }
        [DataMember]
        public decimal SaleNum { get; set; }
        [DataMember]
        public decimal ReturnSaleNum { get; set; }
        [DataMember]
        public decimal SaleNumSum { get; set; }
        [DataMember]
        public string Dosage { get; set; }
        [DataMember]
        public string Specific { get; set; }
        [DataMember]
        public string FactoryName { get; set; }
        [DataMember]
        public string Origin { get; set; }
        [DataMember]
        public string PermitNumber { get; set; }
        [DataMember]
        public string BusinessType { get; set; }

        [DataMember]
        public string PurchaseUnitName { get; set; }

        [DataMember]
        public string SalerName { get; set; }

        [DataMember]
        public string WareHouseZone { get; set; }


        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public decimal CostSum { get; set; }
        /// <summary>
        /// 实际金额=销售金额-销退金额
        /// </summary>
        [DataMember]
        public decimal RealMoney
        {
            get { return decimal.Round((Sum - ReturnSum), 2); }
            set{}
        }
        [DataMember]
        public decimal GrossProfit
        {
            get { return decimal.Round((Sum - CostSum) / 1.17m, 2); }
            set { }
        }
        [DataMember]
        public decimal GrossProfitRate
        {
            get {
                if (Sum <= 0) 
                    return 0m;
                else
                    return decimal.Round((Sum - CostSum) / Sum, 2); }
            set { }
        }

        [DataMember]
        public decimal ReturnSum { get; set; }
        [DataMember]
        public decimal ReturnCostSum { get; set; }

        [DataMember]
        public decimal zySaleSum { get; set; }
        [DataMember]
        public decimal xySaleSum { get; set; }
    }

    [DataContract]
    public class ResultItem
    {
        
        
        
        
    }
}