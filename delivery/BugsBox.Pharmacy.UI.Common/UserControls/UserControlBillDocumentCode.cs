using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient;
 

namespace BugsBox.Pharmacy.UI.Common.UserControls
{
    /// <summary>
    /// 单据编号控件
    /// </summary> 
    public partial class UserControlBillDocumentCode : UserControl
    {
        protected const string PropertyCategory = "Pharmacy";

        public UserControlBillDocumentCode()
        {
            InitializeComponent();
        } 

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SizeChanged += UserControlBillDocumentCode_SizeChanged;
            if (DesignMode)
            {
                this.labelCode.ForeColor = Color.Red;
                GenarateCode();
            } 
        } 

        /// <summary>
        /// 120, 20
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UserControlBillDocumentCode_SizeChanged(object sender, EventArgs e)
        {
            if (this.Height < 20)
            {
                this.Height = 20;
            }
            if (this.Width < 130)
            {
                this.Width = 130;
            }
        } 

        #region 属性

        private bool viewMode = false;

        [Category(PropertyCategory)]
        [Description("显示模式")]
        public bool ViewMode
        {
            get { return viewMode; }
            set { viewMode = value; }
        }

        private BillDocumentType type;

        [Category(PropertyCategory)]
        [Description("单据类型")]
        public BillDocumentType Type
        {
            get { return type; }
            set
            { 
                type = value;
                if (DesignMode)
                {
                    GenarateCode();
                }
            }
        }

        private string code = string.Empty;

        [Browsable(false)]
        [Category(PropertyCategory)]
        [Description("单据编号")]
        public string Code
        {
            get { return code; } 
        } 

        [Browsable(false)]
        public BillDocumentCode BillDocumentCode { get; private set; }
        
        #endregion 

        #region 对外方法  

        /// <summary>
        /// 设置单据编号
        /// 只能在显示模式调用
        /// </summary>
        /// <param name="code"></param>
        public void SetCode(string code)
        {
            this.code = code;
            this.labelCode.Text = this.code;
        }

        /// <summary>
        /// 生成新的单据编号
        /// </summary>
        /// <returns></returns>
        public string GenarateCode()
        {
            if (viewMode)
            {
                return "显示模式不可生成新单据编号";
            }
            else
            {
                try
                {
                    if (DesignMode)
                    {
                        code = DateTime.Now.ToString("yyyyMMddHHmm")
                            + ((int)Type).ToString().PadLeft(4, '0')
                            + "1224";
                    }
                    else
                    {
                        string message;
                        var billCode = ServicesProvider.Instance.PharmacyDatabaseService
                            .GenerateBillDocumentCodeByTypeValue(out message, (int)type);
                        code = billCode.Code;
                        BillDocumentCode = billCode;
                    }
                    this.labelCode.Text = code;
                    return code;
                }
                catch (Exception ex)
                {
                    code = string.Empty;
                    this.labelCode.Text = ex.Message;
                    return code;
                }
            }
        }

        #endregion 
    }
}
