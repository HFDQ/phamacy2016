using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Models
{
    [Description("培训档案细节")]
    [DataContract(IsReference = true)]
    public class EduDetails: Entity
    {



        /// <summary>
        /// 档案编号
        /// </summary>
        [DataMember(Name = "档案编号", Order=0)]
        public Guid DocumentId { get; set; }

        /// <summary>
        /// 培训合格
        /// </summary>
        [DataMember(Name = "培训合格", Order = 1)]
        public bool IsEduPass { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(Name = "备注", Order = 2)]
        public string Memo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember(Name = "创建时间", Order = 3)]
        public DateTime createTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember(Name = "更新时间", Order = 4)]
        public System.DateTime updateTime { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [DataMember(Name = "f1", Order=5)]
        public System.DateTime f1 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [DataMember(Name = "f2",Order=6)]
        public decimal f2 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [DataMember(Name = "f3", Order=7)]
        public decimal f3 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [DataMember(Name = "f4", Order=8)]
        public string f4 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [DataMember(Name = "f5", Order=9)]
        public string f5 { get; set; }


        #region Navigation Property

        [DataMember(Order = 10)]
        public Guid EmployeeId { get; set; }

        [DataMember(Order = 11)]
        public virtual Employee Employee { get; set; }

        [DataMember(Order = 12)]
        public virtual EduDocument EduDocument { get; set; }

        #endregion




    }
}
