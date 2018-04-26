using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common.Helper
{
    public class UIForm
    {
        //动态加载菜单 构造Form 实例的属性类
        private string fromName;
        private string formPosition;
        private List<string> fromParams;

        /// <summary>
        ///Form 的名称
        /// </summary>
        public string FormName
        {
            get;
            set;
        }

        /// <summary>
        /// Form 显示的位置
        /// </summary>
        public string FormPosition
        {
            get;
            set;
        }


        /// <summary>
        /// Form 对应的参数
        /// </summary>
        public List<string> FormParams 
        {
            get;
            set;
        }
    }
}
