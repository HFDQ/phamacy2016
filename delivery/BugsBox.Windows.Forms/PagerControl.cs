using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PagerControl
{
    /// <summary>
    /// 分页控件
    /// RecordCount: 记录总数
    /// PageSize: 每页显示，默认值为20
    /// PageCount: 显示总页数
    /// PageIndex: 当前显示页数
    /// 加载此控件时，需先设置RecordCount
    /// 在此控件的DataPaging 事件函数中 实现绑定刷新DataView功能
    /// </summary>
    public partial class PagerControl : UserControl
    {
        public delegate void Paging();

        public PagerControl()
        {
            InitializeComponent();

        }

        #region Public Constant Variables

        public const int DEFAULT_PAGEINDEX = 1;
        public const int DEFAULT_PAGESIZE = 20; //默认每页显示记录数为20

        #endregion

        #region private variables
        private int recordCount = 0;
        private int pageCount = 0;
        private int pageSize = DEFAULT_PAGESIZE;
        private int pageIndex = DEFAULT_PAGEINDEX;

        #endregion

        #region Public Events

        //自定义控件event
        public event Paging DataPaging = null;

        #endregion

        #region Properties
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value;
                GetPageCount();
            }
        }
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
            set
            {
                pageIndex = value;
                RefreshControlInfo();
            }
        }
        /// <summary>
        /// 记录总条数
        /// </summary>
        public int RecordCount
        {
            get
            {
                return recordCount;
            }

            set
            {
                recordCount = value;

                GetPageCount();
                RefreshControlInfo();
                //BindData();
            }
        }
        /// <summary>
        /// 计算获得总页数
        /// </summary>
        private void GetPageCount()
        {
            if (this.RecordCount > 0)
            {
                pageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.RecordCount) / Convert.ToDouble(this.PageSize)));
            }
            else
            {
                pageCount = 0;
            }
        }

        /// <summary>
        /// 刷新显示分页控件的信息
        /// </summary>
        private void RefreshControlInfo()
        {
            this.lblRecordCount.Text = "记录总数：" + this.RecordCount.ToString();

            this.txtPageNo.Text = this.PageIndex.ToString();
            this.txtPageSize.Text = this.PageSize.ToString();
            this.lblPageCount.Text = "页 共" + this.pageCount.ToString() + "页";
        }

        #endregion

        

        #region 数据绑定方法
        /// <summary>
        /// 触发事件以便主界面获取，以便更新dataview数据
        /// 同时刷新显示分页控件的信息
        /// 控制button是否enable
        /// </summary>

        private void BindData()
        {

            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            if (DataPaging != null)
            {
                DataPaging();
            }

            RefreshControlInfo();

            if (this.PageIndex == 1)
            {
                this.btnPre.Enabled = false;
                this.btnFirst.Enabled = false;
            }
            else
            {
                btnPre.Enabled = true;
                btnFirst.Enabled = true;
            }

            if (this.PageIndex == this.pageCount)
            {
                this.btnLast.Enabled = false;
                this.btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }

            if (this.recordCount == 0)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                btnFirst.Enabled = false;
                btnPre.Enabled = false;
            }



        }
        
        #endregion                         

        #region component event
        //第一页
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (pageIndex > 1)
            {
                pageIndex = 1;
                BindData();

            }

        }

        //上一页
        private void btnPre_Click(object sender, EventArgs e)
        {
            if (pageIndex > 1)
            {
                pageIndex--;
                BindData();

            }
        }

        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageIndex < pageCount)
            {
                pageIndex++;
                BindData();
            }

        }
        //最后一页
        private void btnLast_Click(object sender, EventArgs e)
        {
            if (pageIndex < pageCount)
            {
                pageIndex = pageCount;
                BindData();
            }

        }

        //更改每页显示记录数，enter键确认修改
        private void txtPageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                string strFormat = @"^[1-9][0-9]*$";//正则表达式 ，正整数
                Regex reg = new Regex(strFormat);

                if (!reg.IsMatch(this.txtPageSize.Text.Trim()))
                {
                    PageSize = DEFAULT_PAGESIZE;
                    BindData();
                }

                else
                {
                    PageSize = Int32.Parse(txtPageSize.Text.Trim()); //重新计算pagecount 
                    BindData();
                }

            }

        }

        private void PagerControl_Load(object sender, EventArgs e)
        {
            this.txtPageNo.Text = pageIndex.ToString();
            this.txtPageSize.Text = pageSize.ToString();
        }


        #endregion


        
    }

}
