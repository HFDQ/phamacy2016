using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.Objects;
using BugsBox.Application.Core.CF; 
using BugsBox.CMS.Infra;

namespace BugsBox.Application.Core
{
    public abstract class WindsorConfigurator
    {
        public static WindsorConfigurator Configurator = default(WindsorConfigurator); 

        public virtual void Configure()
        {
            try
            {
                //WindsorRegistrar.RegisterGeneric(typeof(IRepository<>), typeof(CFRepository<>));
            }
            catch (Exception ex)
            {
                throw new AppException("注入配置失败!", ex);
            }
        }  

        #region DbContext

        static WindsorConfigurator()
        {
          
        }

        #endregion DbContext
    }
}