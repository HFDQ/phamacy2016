using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormOrderReturnCenter : BaseFunctionForm
    {
        private int _returnStatus;
        private IList<User> userList = new List<User>();

        public FormOrderReturnCenter()
        {
            InitializeComponent();
            this.dgvOrderReturn.AutoGenerateColumns = false;
            this.Text = "销退中心";
        }

        /// <summary>
        /// 
        /// </summary>
        public FormOrderReturnCenter(object returnStatus)
        {
            InitializeComponent();
            if (returnStatus == null) return;

            OrderReturnStatus orderReturnStatus = EnumHelper<OrderReturnStatus>.Parse(returnStatus.ToString());
            this._returnStatus = (int)orderReturnStatus;
            this.dgvOrderReturn.AutoGenerateColumns = false;
            this.Text = UpdateFormTitle(orderReturnStatus);
        }

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOrderReturnCenter_Load(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                userList = PharmacyDatabaseService.AllUsers(out msg).ToList();
                btnRefresh_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Text+"窗体加载初始化数据失败！！！");
                
            }
        }

        /// <summary>
        /// 格式化显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrderReturn_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }

                var row = dgvOrderReturn.Rows[e.RowIndex];
                var entity = row.DataBoundItem as SalesOrderReturn;
                if (entity != null)
                {
                    row.Cells["序号"].Value = e.RowIndex + 1;
                    row.Cells["销退状态"].Value = Utility.getEnumTypeDisplayName<OrderReturnStatus>((OrderReturnStatus)entity.OrderReturnStatusValue);

                    Employee employee = userList.Where(w => w.Id == entity.SellerID).Select(s => s.Employee).FirstOrDefault();
                    if (employee != null)
                        row.Cells["销售员"].Value = employee.Name;

                    employee = userList.Where(w => w.Id == entity.TradeUserID).Select(s => s.Employee).FirstOrDefault();
                    if (employee != null)
                        row.Cells["营业部代表"].Value = employee.Name;

                    employee = userList.Where(w => w.Id == entity.QualityUserID).Select(s => s.Employee).FirstOrDefault();
                    if (employee != null)
                        row.Cells["质量管理部代表"].Value = employee.Name;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);

            }
        }

        /// <summary>
        /// 处理按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrderReturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var entity = dgvOrderReturn.Rows[e.RowIndex].DataBoundItem as SalesOrderReturn;

            if (dgvOrderReturn.Columns[e.ColumnIndex].Name == "处理")
            {
                string message = string.Empty;
                try
                {
                    var orderReturn = PharmacyDatabaseService.GetSalesOrderReturn(out message, entity.Id);
                    FormSalesOrderReturn form = new FormSalesOrderReturn(orderReturn);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        btnRefresh_Click(sender, e);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("打开销退处理画面失败" + message);
                }
            }
        }

        /// <summary>
        /// 刷新处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            try
            {                

                SalesOrderReturn[] list = PharmacyDatabaseService.GetSalesOrderReturnByStatus(out message, this.GetReturnStatus());
                dgvOrderReturn.DataSource = list;
            }
            catch (Exception)
            {
                MessageBox.Show("检索"+this.Text+"失败!" + message);
            }
        }

        private int[] GetReturnStatus()
        {
            List<int> StateValue=new List<int>();
            if (this.Authorize(ModuleKeys.SaleOrderReturnReceiving))
            {
                StateValue.Add( (int)OrderReturnStatus.Balanced);
            }
            if (this.Authorize(ModuleKeys.SaleOrderReturnChecking))
            {
                StateValue.Add((int)OrderReturnStatus.ReturnReceived);
            }
            if (this.Authorize(ModuleKeys.SaleOrderReturnInInventory))
            {
                StateValue.Add((int)OrderReturnStatus.ReturnChecked);
            }
            StateValue.Add(this._returnStatus);
            return StateValue.ToArray();
        }


        /// <summary>
        /// 更新Form Title
        /// </summary>
        /// <param name="status"></param>
        private string UpdateFormTitle(OrderReturnStatus status)
        {
            string formTitle = string.Empty;
            switch (status)
            {
                case OrderReturnStatus.None:
                    formTitle = "销退单新建";
                    break;
                case OrderReturnStatus.Waitting:
                    formTitle = "销退销售员审核";
                    break;
                case OrderReturnStatus.SellerApproved:
                    formTitle = "销退营业部审核";
                    break;
                case OrderReturnStatus.TradeApproved:
                    formTitle = "销退质管部审核通过";
                    break;
                case OrderReturnStatus.QualityApproved:
                    formTitle = "销退出入库处理";
                    break;
            }
            return formTitle;
        }

    }
}
