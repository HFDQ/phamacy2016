using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Common;
using BugsBox.Pharmacy.AppClient;
using BugsBox.Pharmacy.AppClient.PS;
using CustomValidatorsLibrary;

namespace BugsBox.Pharmacy.UI.Common
{
    /// <summary>
    /// 功能UserControl基类
    /// </summary>
    public partial class BaseFunctionUserControl : UserControl, IPharmacyUserControlView
    {
        [Browsable(false)]
        public IPharmacyDatabaseService PharmacyDatabaseService { get; private set; }
        private List<BaseValidator> _allValidator = new List<BaseValidator>();

        public BaseFunctionUserControl()
        {
            if (!DesignMode)
            { 
                PharmacyDatabaseService = ServicesProvider.Instance.PharmacyDatabaseService;
            }
        }

        /// <summary>
        /// 记录日志对象
        /// </summary>
        protected ILogger Log = LoggerHelper.Instance;

        public virtual void Init()
        {
        }

        public virtual bool BeforeSwitchOut()
        {
            return true;
        }

        public virtual bool BeforeExit()
        {
            return true;
        }

        public void AddRequiredValidate(Label label, Control control)
        {
            label.Text = label.Text.Replace(":", "").Replace("：", "");
            Label asterisk = new Label();
            asterisk.Size = new Size(10, 13);
            asterisk.Location = new Point(label.Location.X + label.Width, label.Location.Y);
            asterisk.Text = "*";
            asterisk.ForeColor = Color.Red;
            label.Parent.Controls.Add(asterisk);
            Label colon = new Label();
            colon.Size = new Size(10, 13);
            colon.Location = new Point(label.Location.X + label.Width + 10, label.Location.Y);
            colon.Text = "：";
            label.Parent.Controls.Add(colon);
            RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
            requiredFieldValidator.ErrorMessage = String.Format("请输入{0}", label.Text);
            requiredFieldValidator.ControlToValidate = control;
            _allValidator.Add(requiredFieldValidator);
        }

        public bool ValidateControls(out string msg)
        {
            msg = String.Empty;
            foreach (BaseValidator v in _allValidator)
            {
                v.Validate();
                if (!v.IsValid)
                {
                    msg = v.ErrorMessage;
                    if (v.ControlToValidate != null)
                    {
                        try
                        {
                            if (!v.ControlToValidate.Focused)
                            {
                                v.ControlToValidate.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                           
                        }
                    }
                    return false;
                }
            }
            return true;
        }
    }
}
