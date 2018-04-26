using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BugsBox.Pharmacy.AppClient.UI.Forms
{
    public delegate void FormStatusChangeHandler(object sender,FormStatusChangeEventArgs e);

    /// <summary>
    /// 本类用于控制窗口状态：提交和编辑，通过该类，设置、获取当前状态。
    /// 客户端调用时，实现FormStatusChanged事件，对窗体的某些按钮执行控制。
    /// </summary>
    public class FormStatus
    {
        FormStatusEnum _fs;
        public event FormStatusChangeHandler FormStatusChanged;

        public FormStatusEnum FStatus
        {
            get { return this._fs; }
            set
            {
                FormStatusChangeEventArgs e = new FormStatusChangeEventArgs(value);
                OnStatusChange(this, e);
                e.fs = value;
            }
        }

        public FormStatus(FormStatusEnum fs)
        {
            this._fs = fs;
        }

        protected virtual void OnStatusChange(object sender,FormStatusChangeEventArgs e)
        {
            if (FormStatusChanged != null)
            {
                FormStatusChanged(this, e);
            }
        }
    }

    /// <summary>
    /// 窗体状态改变的事件参数类
    /// </summary>
    public class FormStatusChangeEventArgs : EventArgs
    {
        public FormStatusEnum fs;
        public FormStatusChangeEventArgs(FormStatusEnum fs)
        {
            this.fs = fs;
        }
    }

    /// <summary>
    /// 窗体状态：新建状态和编辑状态
    /// </summary>
    public enum FormStatusEnum
    {
        New,
        Edit,
        Read
    }
}
