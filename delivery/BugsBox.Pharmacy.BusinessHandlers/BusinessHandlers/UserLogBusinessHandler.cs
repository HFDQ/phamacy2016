using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    /// <summary>
    /// 用户日志的业务逻辑处理
    /// </summary>
    partial class UserLogBusinessHandler
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="log"></param>
        public void LogUserLog(UserLog log)
        {
            try
            {
                string message = ValidateAdd(log);
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Log.Warning("日志对象验证不通过:" + message);
                    return;
                }
                this.Add(log, out message);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        public void WriteLog(Guid Uid, string Content)
        {
            UserLog ul = new UserLog();
            string EmployeeName = BusinessHandlerFactory.UserBusinessHandler.GetEmployeeByUserId(Uid).Name;
            ul.Content = "操作员:" + EmployeeName + " 操作内容：" + Content;
            ul.CreateTime = DateTime.Now;
            ul.CreateUserId = Uid;
            ul.Deleted = false;
            ul.DeleteTime = null;
            ul.Id = Guid.NewGuid();
            ul.StoreId = BugsBox.Pharmacy.Config.PharmacyServiceConfig.Config.CurrentStore.Id;
            ul.UpdateTime = DateTime.Now;
            ul.UpdateUserId = Uid;
            this.Add(ul);
            this.Save();
        }

        public System.Collections.Generic.IEnumerable<Business.Models.UserLogModel> GetPagedUserLogs(Business.Models.QueryBusinessUserLogModel m,out PagerInfo pagerInfo,int PageIndex,int PageSize)
        {
            PagerInfo p = new PagerInfo
            {
                Index=PageIndex,
                 Size=PageSize
            };
            
            var origin = this.Queryable.Where(r => r.CreateTime >= m.DTF && r.CreateTime <= m.DTT);
            if (!string.IsNullOrEmpty(m.Keyword))
            {
                origin = origin.Where(r => r.Content.Contains(m.Keyword));
            }

            var c = from i in origin
                    join u in RepositoryProvider.Db.Users.Where(r => r.Deleted == false)
                    on i.CreateUserId equals u.Id
                    join e in RepositoryProvider.Db.Employees.Where(r => r.Deleted == false)
                    on u.EmployeeId equals e.Id
                    select new Business.Models.UserLogModel
                    {
                         CreateTime=i.CreateTime,
                          EmployeeName=e.Name,
                           Id=i.Id,
                            OperateContent=i.Content
                    };
            p.RecordCount = c.Count();
            pagerInfo = p;

            c=c.OrderBy(r => r.CreateTime).Skip((PageIndex - 1) * PageSize).Take(PageSize);
            return c;
        }

        public Business.Models.ServerInfo GetServerInfo()
        {
            Business.Models.ServerInfo si = new Business.Models.ServerInfo();
            si.ServerVersion = BugsBox.Common.AssemblyInfoHelper.AssemblyVersion.ToString();
            si.ServerTime = DateTime.Now;
            return si;
        }

        //读取服务端文件
        public System.Collections.Generic.IEnumerable<Business.Models.UpdateFiles> GetUpdateFiles(string FileName)
        {
            try
            {
                List<Business.Models.UpdateFiles> ListUpdateFiles = new List<Business.Models.UpdateFiles>();
                string[] Files;
                if (string.IsNullOrEmpty(FileName))
                {
                    Files = System.IO.Directory.GetFileSystemEntries(System.IO.Directory.GetCurrentDirectory() + "\\应用客户端");
                }
                else
                {
                    if (FileName.IndexOf("\\") > 0)
                    {
                        Files = new string[] { FileName };
                    }
                    else
                    {
                        Files = System.IO.Directory.GetFileSystemEntries(System.IO.Directory.GetCurrentDirectory() + "\\" + FileName);
                    }
                }

                byte[] bytes;
                foreach (var i in Files)
                {
                    Business.Models.UpdateFiles f = new Business.Models.UpdateFiles();
                    f.FileName = i.Substring(i.LastIndexOf('\\') + 1, i.Length - i.LastIndexOf('\\') - 1);
                    System.IO.FileInfo fi = new System.IO.FileInfo(i);
                    using (System.IO.FileStream fs = fi.OpenRead())
                    {
                        bytes = new byte[fi.Length];
                        fs.Read(bytes, 0, bytes.Length);
                        f.bytes = bytes;
                        ListUpdateFiles.Add(f);
                    }
                }
                return ListUpdateFiles;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }

        public bool SaveClientFile()
        {
            return true;
        }

        /// <summary>
        /// 获得供货企业和销售客户资质的近效期预警信息
        /// List<Int>第一条为供货单位数量，
        /// 第二条为客户记录数量
        /// </summary>
        /// <param name="WarningDate"></param>
        /// <returns></returns>
        public List<Business.Models.QualityFilesWarningModel> GetQualifyFilesCount(Business.Models.NearExpireDateQualifiedFiles WarningDate)
        {
            try
            {
                List<Business.Models.QualityFilesWarningModel> ListWarning = new List<Business.Models.QualityFilesWarningModel>();
                DateTime CheckDate = DateTime.Now.Date.AddMonths(WarningDate.WarningDate);
                DateTime Now = DateTime.Now.Date;
                var SupplyUnits = RepositoryProvider.Db.SupplyUnits.Where(r => r.Deleted == false && (r.OutDate < CheckDate && r.OutDate > Now)).ToList();
                if (SupplyUnits.Count() > 0)
                {
                    foreach (var i in SupplyUnits)
                        ListWarning.Add(new Business.Models.QualityFilesWarningModel
                        {
                            Id = i.Id,
                            Name = i.Name,
                            QualityFileWarningTypeValue = (int)Business.Models.QualityFileWarningType.供货单位,
                            WarningDate = CheckDate,
                            WarningDateSetUpMonth = WarningDate.WarningDate
                        });
                }

                CheckDate = DateTime.Now.Date.AddMonths(WarningDate.PurchaseWarningDate);

                var PurchaseUnits = RepositoryProvider.Db.PurchaseUnits.Where(r => r.Deleted == false && (r.OutDate <= CheckDate && r.OutDate >= Now)).ToList();
                if (PurchaseUnits.Count > 0)
                {
                    foreach (var i in PurchaseUnits)
                        ListWarning.Add(new Business.Models.QualityFilesWarningModel
                        {
                            Id = i.Id,
                            Name = i.Name,
                            QualityFileWarningTypeValue = (int)Business.Models.QualityFileWarningType.客户单位,
                            WarningDate = CheckDate,
                            WarningDateSetUpMonth = WarningDate.PurchaseWarningDate
                        });
                }

                CheckDate = DateTime.Now.Date.AddMonths(WarningDate.DrugInfoQualityWarningDate);
                var DrugInfos = RepositoryProvider.Db.DrugInfos.Where(r => r.Deleted == false && r.PermitOutDate <= CheckDate && r.PermitOutDate >= Now).ToList();
                if (DrugInfos.Count > 0)
                {
                    foreach (var i in DrugInfos)
                    {
                        ListWarning.Add(new Business.Models.QualityFilesWarningModel
                        {
                            Id = i.Id,
                            Name = i.ProductGeneralName,
                            QualityFileWarningTypeValue = (int)Business.Models.QualityFileWarningType.品种许可有效期,
                            WarningDate = CheckDate,
                            WarningDateSetUpMonth = WarningDate.DrugInfoQualityWarningDate
                        });
                    }
                }

                CheckDate = DateTime.Now.Date.AddMonths(WarningDate.DrugWarningDate);
                var de = from i in RepositoryProvider.Db.DrugInventoryRecords.Where(r => r.CanSaleNum > 0 && r.OutValidDate > Now && r.OutValidDate <= CheckDate)
                         join j in RepositoryProvider.Db.DrugInfos.Where(r => r.Deleted == false) on i.DrugInfoId equals j.Id
                         select new Business.Models.QualityFilesWarningModel
                         {
                             Id = i.Id,
                             Name = j.ProductGeneralName,
                             QualityFileWarningTypeValue = (int)Business.Models.QualityFileWarningType.库存品种近效期,
                             WarningDate = CheckDate,
                             WarningDateSetUpMonth = WarningDate.DrugWarningDate
                         };

                ListWarning.AddRange(de.ToList());
                return ListWarning;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }
    }
}
