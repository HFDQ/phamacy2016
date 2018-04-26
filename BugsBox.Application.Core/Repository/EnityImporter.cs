using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BugsBox.Common;
using System.Data.Entity;

namespace BugsBox.Application.Core.Repository
{
    /// <summary>
    /// 实体导入
    /// </summary>
    public class EnityImporter<T>:IDisposable
         where T : class,IEntity, new()
    {
        public EnityImporter(IRepository<T> repository)
        {
            if (repository == null)
            {
                throw new NullReferenceException("repository 不可为空");
            }
            _Repository = repository; 
        }

        private const string Folder = "Data";

        protected static readonly DateTime Now = DateTime.Now;

        public IRepository<T> _Repository { get; private set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        protected virtual string FileName
        {
            get { return typeof (T).FullName + ".json"; }
        }

        protected virtual string BackupFileName
        {
            get
            {
                return typeof(T).FullName+"." + Now.ToString("yyyyMMddHHmmsss")+ ".json"; 
            }
        }

        protected virtual string BackupFileFullPath
        {
           
           get
           {
               string folder = Path.Combine(ApplicationContext.RootPath, Folder, "Backup");
               if (!Directory.Exists(folder))
               {
                   Directory.CreateDirectory(folder);
               }
               return Path.Combine(folder, BackupFileName);
           }
            
        }

        protected virtual string FileFullPath
        {
            get
            {
                string folder = Path.Combine(ApplicationContext.RootPath, Folder, "Import");
                  if (!Directory.Exists(folder))
                  {
                      Directory.CreateDirectory(folder);
                  }
                return Path.Combine(folder, FileName); 
            }
        }

        public bool FileExists
        {
            get { return File.Exists(FileFullPath); }
        }

        public bool Import()
        {
            if (!FileExists)
            {
                LoggerHelper.Instance.Warning(string.Format("导入的文件({0})不存在,无法导入!",FileFullPath) );
                return false;
            }
            LoggerHelper.Instance.Information(string.Format("开始导入的实体({0}-{1})...", FileFullPath, typeof(T).FullName));
            try
            {

                List<T> entities = JsonSerializeHelper.DeSerializeJson<List<T>>(FileFullPath);
                if (entities == null) return false;
                foreach (var entity in entities)
                {
                    if (entity.Id == default(Guid))
                    {
                        entity.Id = Guid.NewGuid();
                    }
                    _Repository.Add(entity);
                }
                _Repository.UnitOfWork.Commit();
                LoggerHelper.Instance.Information(string.Format("成功导入的实体({0}-{1}).", FileFullPath, typeof(T).FullName));
                Backup();
            }
            catch (Exception ex)
            {
                ex = new Exception(string.Format("导入的实体({0}-{1})失败.", FileFullPath, typeof (T).FullName));
                LoggerHelper.Instance.Error(ex);
            }
            return true;
        }

        public bool Backup()
        {
            LoggerHelper.Instance.Information(string.Format("开始备份({0}-{1})的原始数据...", FileFullPath, typeof(T).FullName));
            List<T> orginalentities = _Repository.Queryable.ToList();
            JsonSerializeHelper.SerializeJson(orginalentities,BackupFileFullPath);
            LoggerHelper.Instance.Information(string.Format("备份({0}-{1})的成功", FileFullPath, typeof(T).FullName));
            return true;
        }


        public void Dispose()
        {
            if (_Repository != null)
            {
                _Repository.Dispose();
                _Repository = null;
            }
        }
    }
}
