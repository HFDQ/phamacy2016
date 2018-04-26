using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 部门
    /// Version:2013.07.16.2143 已完成
    /// 由曹晓红完成
    /// </summary>
    [Description("部门")]
    [DataContract(IsReference = true)]
    public class Department:Entity,IDictionaryType,IStore
    {

        #region Entiy Property 

        [Required(ErrorMessage = "请输入[部门名称]")]
        [MinLength(2)]
        [DataMember(Order = 0)]
        public string Name { get; set; }

        [Required(ErrorMessage = "请输入[描述]")]
        [DataMember(Order = 1)]
        public string Decription { get; set; }

        [Required(ErrorMessage = "请输入[代码]")]
        [MinLength(1)]
        [DataMember(Order = 2)]
        public string Code { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [DataMember(Order = 3)]
        public bool Enabled { get; set; }

        [DataMember(Order = 4)]
        public Guid StoreId { get; set; }

        #endregion

        #region Navigation Property

        /// <summary>
        /// 父部门编号
        /// </summary>
        [DataMember(Order = 5)]
        public Guid DepartmentId{get;set;}

        [DataMember(Order = 6)]
        public virtual ICollection<Employee> Employees { get; set; } 

        #endregion

    }
}

