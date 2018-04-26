using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using System.Linq.Expressions;
using System.Data.Entity;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class GMSPLicenseBusinessScopeBusinessHandler
    {
        protected override IQueryable<GMSPLicenseBusinessScope> IncludeNavigationProperties(IQueryable<GMSPLicenseBusinessScope> queryable)
        {
            return base.IncludeNavigationProperties(queryable.Include(r=>r.BusinessScope));
        }

        /// <summary>
        /// 重写此方法
        /// 重点处理证书下的经营范围
        /// </summary>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        //public override bool Add(GMSPLicense value, out string msg)
        //{
        //    //GMSPLicense oldobject = this.Get(value.Id);
        //    //if (oldobject != null)
        //    //{
        //    //    oldobject.GMSPLicenseBusinessScopes.Clear();

        //    //    foreach (GMSPLicenseBusinessScope gmspbs in value.GMSPLicenseBusinessScopes)
        //    //    {
        //    //        oldobject.GMSPLicenseBusinessScopes.Add(gmspbs);
        //    //    }
        //    //}
        //    return base.Add(value, out msg);
        //}

        /// <summary>
        /// 重写此方法
        /// 重点处理证书下的经营范围,提交过的经营范围是客户端选择的
        /// </summary>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        //public override bool Save(GMSPLicense value, out string msg)
        //{
        //    Db db = this.UnitOfWork as Db;
        //    var gMSPLicenseBusinessScopes = db.GMSPLicenseBusinessScopes
        //        .Where(glc => glc.GMSPLicenseId == value.Id);
        //    gMSPLicenseBusinessScopes.ForEach(id =>
        //    {
        //        db.GMSPLicenseBusinessScopes.Remove(id);
        //    });
        //    var sopes = value.GMSPLicenseBusinessScopes.ToList();
        //    foreach (var gmspLicenseBusinessScope in sopes)
        //    {
        //        db.GMSPLicenseBusinessScopes.Add(gmspLicenseBusinessScope);
        //    }
        //    value.GMSPLicenseBusinessScopes = null;
        //    return base.Save(value, out msg);
        //}
    }
}
