using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DrugOutInventoryCheckModel
    {
        /// <summary>
        /// 出库细节ID
        /// </summary>
        [DataMember]
        public Guid Id { get; set; }


        /// <summary>
        /// 品种ID
        /// </summary>
        [DataMember]
        public Guid DrugInfoId { get; set; }


        [DisplayName("品名")]
        [DataMember]
        public string ProductGeneralName { get; set; }


        [DisplayName("剂型")]
        [DataMember]
        public string DosageName { get; set; }


        [DisplayName("规格")]
        [DataMember]
        public string SpecificName { get; set; }


        [DisplayName("计量单位")]
        [DataMember]
        public string MeasurementName { get; set; }


        [DisplayName("生产厂家")]
        [DataMember]
        public string FactoryName { get; set; }


        [DisplayName("产地")]
        [DataMember]
        public string Origin { get; set; }

        
        [DataMember]
        public bool IsSpecial { get; set; }

        [DisplayName("是否特殊管理药品")]
        [DataMember]
        public string IsSpecialStr { get => this.IsSpecial ? "是" : "否"; }


        [DisplayName("批号")]
        [DataMember]
        public string BatchName { get; set; }

        [DataMember]
        public decimal Amount { get; set; }


        [DisplayName("购货单位")]
        [DataMember]
        public string PurchaseUnitName { get; set; }


        [DisplayName("批准文号")]
        [DataMember]
        public string LiscencePermitNumber { get; set; }


        [DisplayName("销售单号")]
        [DataMember]
        public string SalesOrderCode { get; set; }
        
        [DataMember]
        public DateTime SaleDate { get; set; }

        [DisplayName("销售日期")]
        [DataMember]
        public string SaleDateStr { get => this.SaleDate.ToLongDateString(); }

        [DisplayName("第一复核员")]
        [DataMember]
        public string FirstCheckerName { get; set; }

        [DataMember]
        public DateTime FirstCheckTime { get; set; }

        [DataMember]
        [DisplayName("复核时间")]
        public string FirstCheckTimeStr { get => this.FirstCheckTime.ToString("yyyy/MM/dd hh:mm"); }

        [DisplayName("第二复核员")]
        [DataMember]
        public string SecondCheckerName { get; set; }

        [DataMember]
        public DateTime SecondCheckTime { get; set; }
        [DataMember]
        [DisplayName("复核时间")]
        public string SecondCheckTimeStr { get => this.FirstCheckTime.ToString("yyyy/MM/dd hh:mm"); }
    }

    public class DrugOutInventoryCheckQueryModel : BaseQueryModel
    {
        [DataMember]
        public DateTime DTF { get; set; }

        [DataMember]
        public DateTime DTT { get; set; }

        [DataMember]
        public string FactoryName { get; set; }


        [DataMember]
        public string BatchNumber { get; set; }
    }
}
