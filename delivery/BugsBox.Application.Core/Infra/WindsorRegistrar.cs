using System;
using Autofac;
using BugsBox.Application.Core;

namespace BugsBox.CMS.Infra
{
    /// <summary>
    /// 对象注入
    /// </summary>
    public class WindsorRegistrar
    {
        /// <summary>
        /// 以单例方式注入
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <param name="implementationType">实现接口的类型</param>
        public static void RegisterSingleton(Type interfaceType, Type implementationType)
        {
            IoC.Builder.RegisterType(implementationType).As(interfaceType).SingleInstance();
        }

        /// <summary>
        /// 以单例方式注入
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <param name="implementationType">实现接口的类型</param>
        public static void RegisterGenericSingleton(Type interfaceType, Type implementationType)
        {
            IoC.Builder.RegisterGeneric(implementationType).As(interfaceType).SingleInstance();
        }

        /// <summary>
        /// 一次调用一个对象
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <param name="implementationType">实现了接口的类型</param>
        public static void Register(Type interfaceType, Type implementationType)
        {
            IoC.Builder.RegisterType(implementationType).As(interfaceType)
               .InstancePerDependency()
               .PropertiesAutowired();
        }

        /// <summary>
        /// 一次调用一个对象
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <param name="implementationType">实现了接口的类型</param>
        public static void RegisterGeneric(Type interfaceType, Type implementationType)
        {
            IoC.Builder.RegisterGeneric(implementationType).As(interfaceType)
               .InstancePerDependency()
               .PropertiesAutowired();
        }

        /// <summary>
        /// 注入某程序集中所有接口与类
        /// </summary>
        /// <param name="a"></param>
        public static void RegisterAllFromAssemblies(string a)
        {

        }
    }
}