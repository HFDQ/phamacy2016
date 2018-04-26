using System;
using System.Collections.Generic;
using System.Data.Entity; 
using System.Data.Objects;
using System.Linq;
using BugsBox.Application.Core.CF; 
using BugsBox.CMS.Infra;
using BugsBox.Common;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Application.Core
{
    public class RepositoryWindsorConfigurator : WindsorConfigurator
    { 

        public override void Configure()
        {
            try
            {
                try
                {
                  
                    //注入IService IQueryableUnitOfWork
                    WindsorRegistrar.Register(typeof(Db), typeof(Db));
                    base.Configure();
                    //var swcType = typeof(RepositoryWindsorConfigurator);
                    //var assembly = swcType.Assembly;
                    //var alltypes = assembly.GetTypes();
                    //var repositoryTypes = alltypes
                    //    .Where(t => t.IsInterface)
                    //    .ToList();
                    //foreach (var repositoryType in repositoryTypes)
                    //{
                    //    var implementationType =
                    //        alltypes.FirstOrDefault(t => t.GetInterface(repositoryType.Name) != null);
                    //    WindsorRegistrar.Register(repositoryType, implementationType);
                    //}
                    WindsorRegistrar.Register(typeof(RepositoryProvider), typeof(RepositoryProvider));
                    //WindsorRegistrar.RegisterAllFromAssemblies(assembly.FullName);
                }
                catch (Exception ex)
                {
                    ex = new BusinessException("注入仓储对象失败!", ex);
                    LoggerHelper.Instance.Error(ex);
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw new AppException("注入配置失败!", ex);
            }
        } 
  
    }
}