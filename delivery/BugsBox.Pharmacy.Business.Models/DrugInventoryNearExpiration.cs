using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DrugInventoryNearExpiration
    {
        public Guid id { get; set; }
        public string productGeneralName { get; set; }
        public string permitionCode { get; set; }
        public string specific{ get; set; }
        public string dosage { get; set; }
        public string batchNumber { get; set; }
        public DateTime invalidDate { get; set; }
        public string factoryName { get; set; }
        public string isMaitain { get; set; }
        public decimal canSaleNum { get; set; }
        public Guid DrugInfoId { get; set; }        
        public string shelf { get; set; }
        public string Origin { get; set; }

        /// <summary>
        /// 库龄
        /// </summary>
        public string Age
        {
            get 
            {
                if (ArrivalDate.Date == DateTime.Now.Date)
                {
                    return "前期库存导入，无法计算入库时间！";
                }
                return ((DateTime.Now.Year - this.ArrivalDate.Year) * 12 + (DateTime.Now.Month - this.ArrivalDate.Month)).ToString(); 
            }
        }

        /// <summary>
        /// 到货日期
        /// </summary>
        public DateTime ArrivalDate { get; set; }
    }
}
