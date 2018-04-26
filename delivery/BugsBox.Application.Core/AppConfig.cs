using System;
using BugsBox.Common.Config;

namespace BugsBox.Application.Core
{
    /// <summary>
    ///应用配置
    /// </summary>
    public class AppConfig : BaseConfig
    {
        public override string Description
        {
            get { return "应用配置"; }
        }

        public override string Name
        {
            get { return "应用配置"; }
        }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize = 12;

        public static AppConfig Config
        {
            get { return ConfigHelper<AppConfig>.Instance; }
        }

        /// <summary>
        /// 是否自动创建数据库
        /// 此功能慎用!!
        /// </summary>
        public bool AutoCreateAndInitDatabase = true;

        /// <summary>
        /// 初始化时间
        /// </summary>
        public DateTime InitDateTime;

        public const string SystemName = "东青药品仓库配送管理信息系统";
    }
}