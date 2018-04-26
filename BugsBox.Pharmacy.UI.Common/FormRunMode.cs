using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common
{
    /// <summary>
    /// 窗体运行模式
    /// </summary>
    public enum FormRunMode
    {
        /// <summary>
        /// 添加
        /// </summary>
        Add=1,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit=2,
        /// <summary>
        /// 浏览Or查看
        /// </summary>
        Browse=4,
        /// <summary>
        /// 查询
        /// </summary>
        Search=8,
        /// <summary>
        /// 删除
        /// </summary>
        Delete=16,
        /// <summary>
        /// 审核
        /// </summary>
        Check=32,
    }
}
