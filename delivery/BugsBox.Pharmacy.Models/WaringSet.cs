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
    /// 报警设置
    /// luo@0806
    /// </summary>
    [Description("报警设置")]
    [DataContract(IsReference=true)]
    public class WaringSet : Entity,IStore
    {
        /// <summary>
        /// 代码
        /// </summary>
        [DataMember(Order = 1)]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember(Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [DataMember(Order = 3)]
        public string SetValue { get; set; }


        [DataMember(Order = 7)]
        public Guid StoreId { get; set; }
    }
}
