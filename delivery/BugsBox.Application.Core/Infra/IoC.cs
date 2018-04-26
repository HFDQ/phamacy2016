using System;
using Autofac; 

namespace BugsBox.Application.Core
{
    /// <summary>
    /// 控制反转注入工具
    /// </summary>
    public static class IoC
    {
        private static readonly object LockObj = new object(); 
        public static readonly ContainerBuilder Builder = new ContainerBuilder();
        private static IContainer container = null; 

        public static IContainer Container
        {
            get { return container; } 
        }

        /// <summary>
        /// 获取某类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        /// <summary>
        /// 获取某类型对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Resolve(Type type)
        {
            return container.Resolve(type);
        }

        public static void Build()
        { 
            container = Builder.Build();
        }
    }
}