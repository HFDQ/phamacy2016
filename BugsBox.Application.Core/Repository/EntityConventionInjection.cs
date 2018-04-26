using System;
using Omu.ValueInjecter;

namespace BugsBox.Application.Core
{
    /// <summary>
    /// 对象属性注入
    /// </summary>
    public class EntityConventionInjectionForSave : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            if (c.SourceProp.Name == "Id" || c.TargetProp.Name == "Id") return false;
            if (c.SourceProp.Name != c.TargetProp.Name) return false;
            var s = c.SourceProp.Type;
            var t = c.TargetProp.Type;
            if (s != t) return false;
            if (s.IsEnum || t.IsEnum) return false;
            if (s.IsGenericType)
            {
                return s.IsValueType;
            }

            if (s.IsClass && s != typeof(string)) return false;
            if (s.BaseType == typeof(IEntity))
                return false;
            return true;
        }
    }

    public class EntityIdConventionInjection : ConventionInjection
    {
        private static Type IdType = typeof(int);

        protected override bool Match(ConventionInfo c)
        {
            if (c.SourceProp.Name != c.TargetProp.Name) return false;
            var s = c.SourceProp.Type;
            var t = c.TargetProp.Type;
            if (s != t) return false;
            return s == IdType && t == IdType;
        }
    }

    public class ObjectConventionInjection : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            if (c.SourceProp.Name != c.TargetProp.Name) return false;
            var s = c.SourceProp.Type;
            var t = c.TargetProp.Type;
            if (s != t) return false;
            if (s.IsClass && s != typeof(string)) return false;
            return true;
        }
    }
}