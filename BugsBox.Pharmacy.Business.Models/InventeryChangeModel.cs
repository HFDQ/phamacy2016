using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    //库存查询
    [DataContract]
    public class InventeryChangeModel
    {

        //药品通用名
        [DataMember]
        public string ProductGeneralName { get; set; }

        //批号
        [DataMember]
        public string BatchNumber { get; set; }

        //药品单位
        [DataMember]
        public decimal ChangeAmount { get; set; }

        //厂家全称
        [DataMember]
        public decimal CanSaleNum { get; set; }


        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public string Operator { get; set; }

    }
}
