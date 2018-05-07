using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 药品养护记录
    /// </summary>
    [Description("药品养护记录")]
    [DataContract]
    public class DrugMaintainRecord : Entity, ILEntity
    {
        //编号 截止日期  类型 （重点 普通）  完成状态  


        //单据  
        [DataMember]
        public string BillDocumentNo { get; set; }


        //截止日期  
        [DataMember]
        public DateTime ExpirationDate { get; set; }


        //类型
        [Required]
        [DataMember]
        public int DrugMaintainTypeValue { get; set; }



        //完成状态 
        [DataMember]
        public int CompleteState { get; set; }

        ///// <summary>
        ///// 本次养护日期
        ///// </summary> 
        //[DataMember(Order = 3)]
        //public DateTime MaintenanceTime { get; set; }

        ///// <summary>
        ///// 上次养护人Id
        ///// </summary> 
        //[DataMember(Order = 4)]
        //public Guid LastUserId { get; set; }

        ///// <summary>
        ///// 上次养护日期
        ///// </summary> 
        //[DataMember(Order = 5)]
        //public DateTime LastMaintenanceTime { get; set; }

        ///// <summary>
        ///// 备注
        ///// </summary> 
        //[Required]
        //[MaxLength(512)]
        //[DataMember(Order = 6)]
        //public string Memo { get; set; }

        #region ILEntity
        [Required]
        [DataMember]
        public DateTime CreateTime { get; set; }

        [Required]
        [DataMember]
        public Guid CreateUserId { get; set; }


        [NotMapped]
        [DataMember]
        public string CreateUser { get; set; }


        [DataMember]
        public DateTime UpdateTime { get; set; }

        [DataMember]
        public Guid UpdateUserId { get; set; }

        #endregion

    }
}
