using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Common.Config;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.Common
{
    public class PharmacyClientConfig:BaseConfig
    {
        public static PharmacyClientConfig Config
        {
            get { return ConfigHelper<PharmacyClientConfig>.Instance; }
        }

        public override string Description
        {
            get { return "医药进销存客户端配置"; }
        }

        public override string Name
        {
            get { return "医药进销存客户端配置"; }
        }

        public StoreType ClientType = StoreType.Branch;
        public Store Store = new Store { Id = new Guid("5125E3A9-A37A-47C8-812D-444477F05E6E"), Address = "门店地址", Code = "MD", Decription = "默认MD", Enabled = true, Head = "负责人", Name = "某医药销售门店",Tel = "13584197721" };
        public bool AutoLoadData = false;
        public readonly string SystemName = "医药进销存系统";
        public string LastAccount = "";
        public string LastPwd = "";
    }
}
