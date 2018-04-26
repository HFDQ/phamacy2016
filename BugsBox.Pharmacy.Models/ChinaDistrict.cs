using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BugsBox.Pharmacy.Models.Config;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 证照
    /// </summary>
    [Description("行政区域划分")]
    [DataContract(IsReference = true)]
    public class ChinaDistrict: Entity
    {

        [DataMember(Name = "名称", Order = 1)]
        public string Name { get; set; }
    }

    [Description("省份")]
    public class Provinces : ChinaDistrict
    {
        public Provinces()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
              .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
        }
        [DataMember(Order = 10)]
        public virtual ICollection<Cities> Cities { get; set; }
    }

    [Description("城市")]
    public class Cities : ChinaDistrict
    {
        public Cities()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
              .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
        }
        [DataMember(Order = 20)]
        public int ProvincesId { get; set; }

        [DataMember(Order = 21)]
        public virtual Provinces Provinces { get; set; }
        
        [DataMember(Order = 22)]
        public virtual ICollection<Zones> Zones { get; set; }
    }

    [Description("区")]
    public class Zones : ChinaDistrict
    {
        public Zones()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
              .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
        }
        [DataMember(Order = 30)]
        public string PostCode { get; set; }

        [DataMember(Order = 31)]
        public string AreaCode { get; set; }
        
        [DataMember(Order = 32)]
        public int CitiesId { get; set; }

        [DataMember(Order = 21)]
        public virtual Cities Cities { get; set; }
    }
}
