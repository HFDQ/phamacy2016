using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;

namespace System
{
    /// <summary>
    /// 待实现异常
    /// </summary>
    public class TodoException:AppException
    {
        public override string Level
        {
            get
            {
                return "待实现";
            }
        }

        public override string Message
        {
            get { return "暂未实现"; }
        }
    }
}
