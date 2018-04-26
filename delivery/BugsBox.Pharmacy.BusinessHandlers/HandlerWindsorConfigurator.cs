using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.CMS.Infra;
using BugsBox.Common;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy
{
    public class HandlerWindsorConfigurator : RepositoryWindsorConfigurator
    { 
        public override void Configure()
        {
            try
            {
                base.Configure();
                var swcType = typeof(HandlerWindsorConfigurator);
                var assembly = swcType.Assembly;
                var alltypes = assembly.GetTypes();
                WindsorRegistrar.Register(typeof(BusinessHandlerFactory), typeof(BusinessHandlerFactory));
                var iService = typeof(IService<>);
                var serviceTypes = alltypes
                    .Where(t => t.IsClass && t.GetInterface(iService.FullName) != null && !t.IsAbstract)
                    .ToList();
                foreach (var type in serviceTypes)
                {
                    WindsorRegistrar.Register(type, type);
                }
                WindsorRegistrar.RegisterAllFromAssemblies(assembly.FullName);
            }
            catch (Exception ex)
            {
                ex = new BusinessException("注入服务对象失败!", ex);
                LoggerHelper.Instance.Error(ex);
                throw ex;
            }
        }
    }
}
