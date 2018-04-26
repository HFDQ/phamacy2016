using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    [Description("体检档案")]
    [DataContract(IsReference = true)]
    public class HealthCheckDocument : Entity
    {


        /// <summary>
        /// 档案编号
        /// </summary>
        [DataMember(Name = "档案编号", Order = 0)]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 档案名称
        /// </summary>
        [DataMember(Name = "档案名称", Order =1)]
        public string DocumentName { get; set; }

        /// <summary>
        /// 体检时间
        /// </summary>
        [DataMember(Name = "体检时间", Order = 2)]
        public DateTime CheckTime { get; set; }

        /// <summary>
        /// 体检内容
        /// </summary>
        [DataMember(Name = "体检内容", Order = 3)]
        public string CheckContext { get; set; }

        /// <summary>
        /// 体检机构
        /// </summary>
        [DataMember(Name = "体检机构", Order = 4)]
        public string CheckOrganize { get; set; }

        /// <summary>
        /// 地点
        /// </summary>
        [DataMember(Name = "地点", Order = 5)]
        public string CheckAdress { get; set; }

        /// <summary>
        /// 内科医生
        /// </summary>
        [DataMember(Name = "内科主检医生", Order = 6)]
        public string MedicineDoctor { get; set; }

        /// <summary>
        /// 皮肤科医生
        /// </summary>
        [DataMember(Name = "皮肤科主检医生", Order = 7)]
        public string SkinDoctor { get; set; }

        /// <summary>
        /// 胸透医生
        /// </summary>
        [DataMember(Name = "胸透主检医生", Order = 8)]
        public string XCheckDoctor { get; set; }

        /// <summary>
        /// 化验
        /// </summary>
        [DataMember(Name = "化验主检医生", Order = 9)]
        public string HepatitisDoctor { get; set; }

        /// <summary>
        /// 视力
        /// </summary>
        [DataMember(Name = "视力主检医生", Order = 10)]
        public string OptometryDoctor { get; set; }

        /// <summary>
        /// 责任医师
        /// </summary>
        [DataMember(Name = "责任医师", Order = 11)]
        public string ChargeDoctor { get; set; }

        /// <summary>
        /// 发证机构
        /// </summary>
        [DataMember(Name = "发证机构", Order = 12)]
        public string IssuanceOrg { get; set; }

        /// <summary>
        /// 体检人员
        /// </summary>
        [DataMember(Name = "体检人员", Order = 13)]
        public string CheckEployees { get; set; }

        /// <summary>
        /// 参加人数
        /// </summary>
        [DataMember(Name = "参加人数", Order = 14)]
        public decimal CheckEployeesSum { get; set; }

        /// <summary>
        /// 合格通过
        /// </summary>
        [DataMember(Name = "合格通过人数", Order = 15)]
        public decimal CheckPassNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(Name = "备注", Order = 16)]
        public string Memo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember(Name = "创建时间", Order = 17)]
        public DateTime createTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember(Name = "更新时间", Order = 18)]
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

        [DataMember(Order = 25)]
        public virtual ICollection<HealthCheckDetail> HealthCheckDetails { get; set; }

        #endregion


    }
}
