using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Common.Config;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.Config
{
    public class PharmacyServiceConfig:BaseConfig
    {
        public static PharmacyServiceConfig Config {
            get { return ConfigHelper<PharmacyServiceConfig>.Instance; }
        }

        public override string Description
        {
            get { return "医药经营企业计算机系统-服务端配置"; }
        }

        public override string Name
        {
            get { return "医药经营企业计算机系统-服务端配置"; }
        }
        public readonly string SystemName = "医药经营企业计算机系统";
        public Store CurrentStore = new Store {Id=new Guid("5125E3A9-A37A-47C8-812D-444477F05E6E"),Address = "门店地址", Code = "MD", Decription = "默认MD",Enabled =true,Head = "负责人",Name = "某医药销售门店",StoreType = StoreType.Branch,Tel = "13584197721"};
    }
}
