using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// 用户操作日志MODEL
    /// </summary>
    public class UserLogModel
    {
        public Guid Id { get; set; }

        [System.ComponentModel.DisplayName("操作时间")]
        public DateTime CreateTime { get; set; }

        [System.ComponentModel.DisplayName("操作人")]
        public string EmployeeName { get; set; }

        [System.ComponentModel.DisplayName("日志内容")]
        public string OperateContent { get; set; }
    }

    /// <summary>
    /// 查询条件实体
    /// </summary>
    public class QueryBusinessUserLogModel
    {
        /// <summary>
        /// 查询关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 查询时间 起
        /// </summary>
        public DateTime DTF { get; set; }

        /// <summary>
        /// 查询时间止
        /// </summary>
        public DateTime DTT { get; set; }

        
    }
}
