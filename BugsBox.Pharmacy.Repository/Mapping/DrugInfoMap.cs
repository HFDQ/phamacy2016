using BugsBox.Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Repository.Mapping
{
    public class DrugInfoMap : EntityTypeConfiguration<DrugInfo>
    {
        public DrugInfoMap()
        {
            this.HasKey(o => o.Id);
            this.HasOptional(s => s.GoodsAdditionalProperty).WithRequired(o => o.DrugInfo);
           

        }
    }
}
