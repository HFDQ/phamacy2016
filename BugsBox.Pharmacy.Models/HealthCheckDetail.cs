using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    [Description("体检档案细节")]
    [DataContract(IsReference = true)]
    public class HealthCheckDetail : Entity
    {
        #region Entiy Property

        /// <summary>
        /// 体检档案编号
        /// </summary>
        [DataMember(Name = "体检档案编号", Order = 0)]
        public Guid DocumentId { get; set; }

        /// <summary>
        /// 体检年度
        /// </summary>
        [DataMember(Name = "体检年度", Order = 1)]
        public string CheckYear { get; set; }

        /// <summary>
        /// 体检-内科
        /// </summary>
        [DataMember(Name = "内科检查结果", Order = 2)]
        public string Medicine { get; set; }

        /// <summary>
        /// 皮肤科
        /// </summary>
        [DataMember(Name = "皮肤科检查结果", Order = 3)]
        public string Skin { get; set; }

        /// <summary>
        /// 胸透
        /// </summary>
        [DataMember(Name = "胸透检查结果", Order = 4)]
        public string XCheck { get; set; }

        /// <summary>
        /// 化验
        /// </summary>
        [DataMember(Name = "化验检查结果", Order = 5)]
        public string Hepatitis { get; set; }

        /// <summary>
        /// 视力
        /// </summary>
        [DataMember(Name = "视力检查结果", Order = 6)]
        public string Optometry { get; set; }

        /// <summary>
        /// 检查结果
        /// </summary>
        [DataMember(Name = "检查结果", Order = 7)]
        public string CheckResult { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(Name = "备注", Order = 8)]
        public string Memo { get; set; }

        /// <summary>
        /// 是否通过
        /// </summary>
        [DataMember(Order = 9)]
        public bool IsCheckPass { get; set; }

        [DataMember(Order = 10)]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember(Name = "创建时间")]
        public DateTime createTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember(Name = "更新时间")]
        public System.DateTime updateTime { get; set; }

        #endregion

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

        [DataMember(Order = 20)]
        public Guid EmployeeId { get; set; }

        [DataMember(Order = 21)]
        public virtual Employee Employee { get; set; }

        [DataMember(Order = 22)]
        public virtual HealthCheckDocument HealthCheckDocument { get; set; }

        #endregion
    }
}
