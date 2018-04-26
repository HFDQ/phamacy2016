using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Models
{
    [Description("培训档案")]
    [DataContract(IsReference = true)]
    public class EduDocument : Entity
    {
        /// <summary>
        /// 档案编号
        /// </summary>
        [DataMember(Name = "档案编号", Order = 0)]
        public string eduDocumentNumber{get; set;}

        /// <summary>
        /// 档案名称
        /// </summary>
        [DataMember(Name = "档案名称", Order = 1)]
        public string eduDocumentName { get; set; }

        /// <summary>
        /// 培训时间
        /// </summary>
        [DataMember(Name = "培训时间起始", Order = 2)]
        public DateTime eduTimeStart { get; set; }

        /// <summary>
        /// 培训时间
        /// </summary>
        [DataMember(Name = "培训时间止", Order = 3)]
        public DateTime eduTimeEnd { get; set; }

        /// <summary>
        /// 培训内容
        /// </summary>
        [DataMember(Name = "培训内容", Order = 4)]
        public string eduContext { get; set; }

        /// <summary>
        /// 培训机构
        /// </summary>
        [DataMember(Name = "培训机构", Order = 5)]
        public string eduOrganize { get; set; }

        /// <summary>
        /// 培训教师
        /// </summary>
        [DataMember(Name = "培训教师", Order = 6)]
        public string eduTeacher { get; set; }

        /// <summary>
        /// 培训地点
        /// </summary>
        [DataMember(Name = "培训地点", Order = 7)]
        public string eduAdress { get; set; }

        /// <summary>
        /// 培训人员
        /// </summary>
        [DataMember(Name = "培训人员", Order = 8)]
        public string eduEployees { get; set; }

        /// <summary>
        /// 参加人数
        /// </summary>
        [DataMember(Name = "参加人数", Order = 9)]
        public decimal eduEployeesSum { get; set; }

        /// <summary>
        /// 培训合格通过人数
        /// </summary>
        [DataMember(Name = "培训合格通过人数", Order = 10)]
        public decimal eduEployeesPassNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(Name = "备注", Order = 13)]
        public string Memo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember(Name = "创建时间", Order = 11)]
        public DateTime createTime{ get; set;}

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember(Name = "更新时间", Order = 12)]
        public System.DateTime updateTime { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [DataMember(Name = "f1")]
        public System.DateTime f1 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [DataMember(Name = "f2")]
        public decimal f2 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [DataMember(Name = "f3")]
        public decimal f3 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [DataMember(Name = "f4")]
        public string f4 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [DataMember(Name = "f5")]
        public string f5 { get; set; }

        #region Navigation Property

        //[DataMember(Order = 8)]
        //public Guid EduDetailsId { get; set; }

        [DataMember(Order = 20)]
        public virtual ICollection<EduDetails> EduDetailss { get; set; }
        #endregion
    }
}
