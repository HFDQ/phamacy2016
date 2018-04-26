using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Common;

namespace BugsBox.Pharmacy.Repository
{
    /// <summary>
    /// 系统数据库上文工厂
    /// </summary>
    public class DbContextFactory : IDbContextFactory
    {
        private ILogger Log = LoggerHelper.Instance;
        private readonly DbContext c;

        public DbContextFactory()
        {
            c = new Db();
        }

        public object GetContext()
        {
            return new Db();
        }
    }
}
