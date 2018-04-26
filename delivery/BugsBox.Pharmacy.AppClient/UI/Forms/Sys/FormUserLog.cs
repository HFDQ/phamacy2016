using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models; 

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Sys
{
    public partial class FormUserLog : BaseFunctionForm
    {
        public FormUserLog()
        {
            InitializeComponent();
        }

        public class MyComparer : IComparer<UserLog>
        {
            public int Compare(UserLog x, UserLog y)
            {
                return (x.CreateTime.CompareTo(y.CreateTime));
            }
        } 

        #region Field

        /// <summary>
        /// 分页信息
        /// </summary>
        protected PagerInfo PagerInfo = null;

        /// <summary>
        /// 已经选择的记录
        /// </summary>
        protected UserLog SelectedEnitty = null;

        /// <summary>
        /// 加载的数据列表
        /// </summary>
        protected UserLog[] DataList = null;

        /// <summary>
        /// 主表数据
        /// </summary>
        protected Store[] pStores = null;

        /// <summary>
        /// 主表数据
        /// </summary>
        protected User[] pUsers = null;

        #endregion

        #region 数据获取

        /// <summary>
        /// 从服务器获取数据
        /// </summary>
        protected void LoadData()
        {
            try
            {
                DataList = PharmacyDatabaseService.QueryPagedUserLogs(out PagerInfo
                                                                      , this.dateTimePickerCreateTimeFrom.Value.Date
                                                                      , this.dateTimePickerCreateTimeTo.Value.Date
                                                                      , DateTime.Now
                                                                      , DateTime.Now.AddDays(-1)
                                                                      , this.textBoxContent.Text
                                                                      , this.pagerControl1.PageIndex
                                                                      , AppConfig.Config.PageSize);
                string msg = string.Empty;
                pStores = PharmacyDatabaseService.AllStores(out msg);
                pUsers = PharmacyDatabaseService.AllUsers(out msg);
                //DataList.ToList().Sort(new MyComparer());

            }
            catch (Exception ex)
            {
                DataList = null;
                ex = new Exception("获取日志列表失败", ex);
                Log.Error(ex);
                MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 与界面相关方法

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
           
            base.OnLoad(e);
            if (DesignMode) return;
            this.dateTimePickerCreateTimeFrom.Value = this.dateTimePickerCreateTimeFrom.Value.AddDays(-1);
            this.dataGridViewList.AutoGenerateColumns = false;
            this.pagerControl1.PageSize = AppConfig.Config.PageSize;
            buttonSearch_Click(null, null);
          
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindList()
        {
            if (DataList != null)
            {
                this.dataGridViewList.DataSource = DataList;
                this.dataGridViewList.Sort(this.dataGridViewList.Columns["colCreateTime"], ListSortDirection.Descending);
            }
        }

        /// <summary>
        /// 由于这个方法会在设置记录总条数自动调用。
        /// 这个方法又会在用户点击切换页调用。故  LoadData();//这是从服务加载分页数据记录必须在里面调用一次。
        /// 这就会导致用户点击查询按钮后 LoadData()调用两次。
        /// </summary>
        private void pagerControl1_DataPaging()
        {
            LoadData();//这是从服务加载分页数据记录
            BindList();//这是绑定记录到列表控件
            
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 查询按钮的点击处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadData();//这是从服务加载分页数据记录
            this.pagerControl1.PageIndex = 1;//这是设置为第一页
            this.pagerControl1.RecordCount = PagerInfo.RecordCount;//这是设置搜索的记录条数
        }

        /// <summary>
        /// 在行绘制之前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;//这是列头哦


            try
            {
                var currentRow = this.dataGridViewList.Rows[e.RowIndex];
                var entity = currentRow.DataBoundItem as UserLog;
                if (entity == null) return;//没有实体

                if (pStores != null)//门店名称
                {
                    var store = pStores.FirstOrDefault(s => s.Id == entity.StoreId);
                    if (store != null)
                    {
                        var cellStore = currentRow.Cells[colStore.Name] as DataGridViewTextBoxCell;//门店单元格
                        cellStore.Value = store.Name;
                    } 
                }
                if (pUsers != null)//创建者
                {
                    var user = pUsers.FirstOrDefault(u=>u.Id== entity.CreateUserId);
                    if (user != null)
                    {
                        var cellUser = currentRow.Cells[colCreateUser.Name] as DataGridViewTextBoxCell;//门店单元格
                        cellUser.Value = user.Account;
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        #endregion 事件处理


    }
}
