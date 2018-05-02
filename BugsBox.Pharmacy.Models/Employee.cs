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
    /// 员工
    /// luozhy@20130722
    /// </summary>
    [Description("员工")]
    [DataContract(IsReference=true)]
    public class Employee : Entity, IStore, ILEntity,IEnable
    {
        /// <summary>
        /// 员工号
        /// </summary>
        [Required(ErrorMessage = "请输入[员工号]")]
        [DataMember(Order = 0)]
        public string Number { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "请输入[员工姓名]")]
        [DataMember(Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// 姓名拼音
        /// </summary>
        [DataMember(Order = 2)]
        public string Pinyin { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember(Order = 3)]
        public string Gender { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [DataMember(Order = 4)]
        public string IdentityNo { get; set; }
        
        /// <summary>
        /// 电话
        /// </summary>
        [DataMember(Order = 5)]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember(Order = 6)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "请输入[联系地址]")]
        [DataMember(Order = 7)]
        public string Address { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [DataMember(Order = 8)]
        public string Rank { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [DataMember(Order = 9)]
        public string Education { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        [DataMember(Order = 10)]
        public string Specility { get; set; }

        /// <summary>
        /// 岗位职责
        /// </summary>
        [DataMember(Order = 11)]
        public string Duty { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [DataMember(Order = 12)]
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// 开始工作日
        /// </summary>
        [DataMember(Order = 13)]
        public DateTime? WorkTime { get; set; }

        /// <summary>
        /// 合同过期日
        /// </summary>
        [Required]
        [DataMember(Order = 14)]
        public DateTime OutDate { get; set; }

        /// <summary>
        /// 在职状态
        /// </summary>
        [Required]
        [DataMember(Order = 15)]
        public int EmployStatusValue { get; set; }

        /// <summary>
        /// 在职状态
        /// </summary> 
        [NotMapped]
        public EmployStatus EmployStatus
        {
            get { return (EmployStatus)EmployStatusValue; }
            set { EmployStatusValue = (int)value; }
        }

        /// <summary>
        /// 药师职称
        /// </summary>
        [Required]
        [DataMember(Order = 16)]
        public int PharmacistsTitleTypeValue { get; set; }

        [NotMapped]
        /// <summary>
        /// 药师职称
        /// </summary> 
        public PharmacistsTitleType PharmacistsTitleType
        {
            get { return (PharmacistsTitleType)PharmacistsTitleTypeValue; }
            set { PharmacistsTitleTypeValue = (int)value; }
        }

        /// <summary>
        /// 证书编号
        /// </summary>
        [DataMember(Order = 17)]
        public string CardNo { get; set; }

        /// <summary>
        /// 证书日期
        /// </summary>
        [DataMember(Order = 18)]
        public DateTime CardDate { get; set; }

        /// <summary>
        /// c
        /// </summary>
        [Required]
        [DataMember(Order = 19)]
        public int PharmacistsQualificationValue { get; set; }

        /// <summary>
        /// 从业资格
        /// </summary> 
        [NotMapped]
        public PharmacistsQualification PharmacistsQualification
        {
            get { return (PharmacistsQualification)PharmacistsQualificationValue; }
            set { PharmacistsQualificationValue = (int)value; }
        }

        /// <summary>
        /// 启用
        /// </summary>
        [DataMember]
        public bool Enabled { get; set; }

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 33)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 20)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "请输入[创建时间]")]
        [DataMember(Order = 21)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 22)]
        public DateTime UpdateTime { get; set; }

        [DataMember(Order = 23)]
        public Guid StoreId { get; set; }

        [DataMember(Order = 24)]
        public Guid DepartmentId { get; set; }

        [DataMember(Order = 25)]
        public virtual Department Department { get; set; }

        [DataMember(Order = 26)]
        public virtual ICollection<User> Users { get; set; }

        [DataMember(Order = 30)]
        public bool Pro_work_exam { get; set; }

        [DataMember(Order = 31)]
        public DateTime Pro_work_exam_Date { get; set; }
    }
}

