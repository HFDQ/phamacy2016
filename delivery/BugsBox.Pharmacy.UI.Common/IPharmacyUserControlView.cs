using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common
{
    /// <summary>
    /// 系统用户控件视图接口
    /// </summary>
    public interface IPharmacyUserControlView
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Init();
        /// <summary>
        /// 显示
        /// </summary>
        void Show();

        /// <summary>
        /// 切换之前
        /// </summary>
        /// <returns></returns>
        bool BeforeSwitchOut();

        /// <summary>
        /// 关闭之前
        /// </summary>
        /// <returns></returns>
        bool BeforeExit();
    }
}
