﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstruments.Infrastructure.Repository.Mapping
{
    public abstract class NopEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        protected NopEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

            this.HasKey(o => o.ID);
        }
    }
}
