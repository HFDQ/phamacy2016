using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Models
{
    [Description("数据上传记录")]
    [DataContract(IsReference = true)]
    public class UploadRecord : Entity
    {
        [DataMember]
        public string TableName { get; set; }
        [DataMember]
        public int Index { get; set; }
    }
}
