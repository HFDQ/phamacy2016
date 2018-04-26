using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common.Report
{
    /// <summary>
    /// 报表(导出,预览)模板
    /// </summary>
    public abstract class ReportTemplate
    {
        /// <summary>
        /// 模板标题
        /// </summary>
        string Title { get; set; }

        private string file;

        /// <summary>
        /// 文件
        /// </summary>
        public string File
        {
            get
            {
                return file;
            }
            set
            {
                file = value;
                Loaded = false;

            }
        }  

        /// <summary>
        /// 加载
        /// </summary>
        public bool Loaded { get; set; }


        /// <summary>
        /// 加载模板
        /// </summary>
        /// <returns></returns>
        public abstract bool Load();

        /// <summary>
        /// 模内容对象
        /// </summary>
        public abstract object Template { get; }


    }
}
