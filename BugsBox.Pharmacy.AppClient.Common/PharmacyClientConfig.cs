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
        public Store Store = new Store { Id = new Guid("5125E3A9-A37A-47C8-812D-444477F05E6E"), Address = "蒙城县淝河路84号", Code = "MD", Decription = "默认MD", Enabled = true, Head = "贺文军", Name = "安徽庄子药业有限责任公司",Tel = "0558-7668708 0558-7668712" };
        public bool AutoLoadData = false;
        public readonly string SystemName = "药品经营企业计算机系统";
        public string LastAccount = "";
        public string LastPwd = "";
        public bool Pswcheck = false;
    }
}
