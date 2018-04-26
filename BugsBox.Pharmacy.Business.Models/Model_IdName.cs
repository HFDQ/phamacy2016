using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class Model_IdName
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        [DisplayName("名称")]
        public string Name { get; set; }

        [DataMember]
        public string PinYin { get; set; }

        [DataMember]
        public bool IsValid { get; set; }

        [DataMember]
        [DisplayName("是否有效")]
        public string IsValidStr { get => this.IsValid ? "是" : "否"; }
    }
}
