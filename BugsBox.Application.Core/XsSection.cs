using System.Configuration;
using System;
using System.Collections.Generic;

namespace BugsBox.Application.Core
{
    public class XsSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public IncludeElementCollection Includes
        {
            get { return (IncludeElementCollection)base[""]; }
        }

        public static XsSection GetSection()
        {
            return (XsSection)ConfigurationManager.GetSection("xs");
        }
    }

    public class IncludeElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new StringElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as StringElement).Assembly;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        public StringElement this[int index]
        {
            get
            {
                return (StringElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        protected override string ElementName
        {
            get
            {
                return "include";
            }
        }
    }
    public class StringElement : ConfigurationElement
    {
        protected static readonly ConfigurationProperty s_propAssembly;
        private static ConfigurationPropertyCollection s_properties;
        static StringElement()
        {
            s_propAssembly = new ConfigurationProperty("assembly", typeof(string));
            ConfigurationPropertyCollection propertys = new ConfigurationPropertyCollection();
            propertys.Add(s_propAssembly);
            s_properties = propertys;
        }
        #region ConfigurationElement 成员
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return s_properties;
            }
        }
        #endregion
        public string Assembly
        {
            get
            {
                return base[s_propAssembly].ToString();
            }
            set
            {
                base[s_propAssembly] = value;
            }
        }
    }
}
