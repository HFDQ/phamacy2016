using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.Services
{
    public static class EntityOrderDictionary
    {
        private static readonly Dictionary<Type, object> entityOrderDictionary = new Dictionary<Type, object>();

        static EntityOrderDictionary()
        {
            //请在此添加相关实体的排序
            //Demo
            //AddOrder<UserLog>(new Action<Orderable<UserLog>>(o => o.Desc(t => t.CreateTime, t => t.Content)));
            AddOrder<UserLog>(new Action<Orderable<UserLog>>(o => o.Desc(t => t.CreateTime)));
            AddOrder<Module>(new Action<Orderable<Module>>(o => o.Desc(t => t.Name, t => t.Description)));
            AddOrder<BusinessScope>(new Action<Orderable<BusinessScope>>(o => o.Desc(t => t.Code)));
            AddOrder<BusinessScopeCategory>(new Action<Orderable<BusinessScopeCategory>>(o => o.Desc(t => t.Code)));
            AddOrder<BusinessType>(new Action<Orderable<BusinessType>>(o => o.Desc(t => t.Code)));
            AddOrder<District>(new Action<Orderable<District>>(o => o.Desc(t => t.Code)));
            AddOrder<Role>(new Action<Orderable<Role>>(o => o.Asc(t => t.Code)));
            AddOrder<User>(new Action<Orderable<User>>(o => o.Asc(t => t.Account)));
            AddOrder<Employee>(new Action<Orderable<Employee>>(o => o.Asc(t => t.Number)));
            AddOrder<SalesOrder>(new Action<Orderable<SalesOrder>>(o => o.Asc(r => r.CreateTime)));
        }

        public static void AddOrder<T>(object order)
            where T : Entity, new()
        {
            if (order == null)
            {
                order = new Action<Orderable<T>>(o => o.Desc(t => t.Id));
            }
            entityOrderDictionary.Add(typeof(T), order);
        }

        public static Action<Orderable<T>> GetOrder<T>()
            where T : Entity, IEntity, new()
        {
            if (!entityOrderDictionary.ContainsKey(typeof(T)))
            {
                AddOrder<T>(new Action<Orderable<T>>(o => o.Desc(t => t.Id)));
            }
            return entityOrderDictionary[typeof(T)] as Action<Orderable<T>>;
        }
    }
}
