using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DeliveryBusiness
{
    public partial class FormDeliverySearch : BaseFunctionForm
    {
        public DeliveryStatus Status { get; set; }
        private PagerInfo pager = new PagerInfo();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outInventoryStatus"></param>
        public FormDeliverySearch(object deliveryStatus)
        {
            InitializeComponent();
            this.dgvDelivery.AutoGenerateColumns = false;
            this.Status = EnumHelper<DeliveryStatus>.Parse(deliveryStatus.ToString());
            switch (this.Status)
            {
                case DeliveryStatus.Accepted: this.Text = "配送申请记录查询"; break;
                case DeliveryStatus.Canceled: this.Text = "配送取消记录查询"; break;
                case DeliveryStatus.Outed:    this.Text = "配送出库记录查询"; break;
                case DeliveryStatus.Signed:   this.Text = "配送签收记录查询"; break;
                case DeliveryStatus.Return:   this.Text = "配送销退记录查询"; break;
                default: this.Text = string.Empty; break;
            }
        }

        private void FormDeliverySearch_Load(object sender, EventArgs e)
        {
            string message = string.Empty;
            try
            {
                IEnumerable<User> users = PharmacyDatabaseService.GetAllUsers(out message);
                var list = users.Select(p => new ListItem { ID = p.Id.ToString(), Name = p.Account }).ToList();
                list.Insert(0, new ListItem { ID = Guid.Empty.ToString(), Name = "-请选择-" });
                this.cmbOperator.DataSource = list;
                this.cmbOperator.ValueMember = "ID";
                this.cmbOperator.DisplayMember = "Name";
            }
            catch (Exception)
            {
                MessageBox.Show("画面初始化失败");
            }

            this.dgvDelivery.DataSource = null;
            this.pagerControl.RecordCount = 0;
        }

        private void tsbtnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                BindGrid();
                this.pagerControl.RecordCount = pager.RecordCount;
                this.pagerControl.PageIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("检索配送记录失败!" + ex.Message);
            }
        }

        /// <summary>
        /// 格式化表格数据
        /// </summary>
        private void FormatRows()
        {
            foreach (DataGridViewRow row in this.dgvDelivery.Rows)
            {
                var entity = row.DataBoundItem as Delivery;
                if (entity != null)
                {
                    try
                    {
                        string message = string.Empty;
                        row.Cells["序号"].Value = row.Index + 1;
                        row.Cells["配送方式"].Value = Utility.getEnumTypeDisplayName<DeliveryMethod>(entity.DeliveryMethod);
                        row.Cells["运输方式"].Value = Utility.getEnumTypeDisplayName<TransportMethod>(entity.TransportMethod);
                        row.Cells["配送状态"].Value = Utility.getEnumTypeDisplayName<DeliveryStatus>(entity.DeliveryStatus);
                        row.Cells["预约者"].Value = GetUserName(out message, entity.ReservationOperatorId);
                        row.Cells["受理者"].Value = GetUserName(out message, entity.AcceptedOperatorId);
                        row.Cells["取消者"].Value = GetUserName(out message, entity.CanceledOperatorId);
                        row.Cells["出库者"].Value = GetUserName(out message, entity.outedOperatorId);
                        row.Cells["签收者"].Value = GetUserName(out message, entity.SignedOperatorId);
                        row.Cells["销退申请者"].Value = GetUserName(out message, entity.ReturnOperatorId);
                    }
                    catch (Exception ex)
                    {
                        Log.Warning(ex, string.Format("{0}行的数据格式化失败!!!", row.Index));
                    }
                }
            }
        }

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        private string GetUserName(out string msg, Guid userID)
        {
            var user = PharmacyDatabaseService.GetUser(out msg, userID);
            if (user != null)
            {
                return user.Account;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 打开详细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDelivery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var entity = dgvDelivery.Rows[e.RowIndex].DataBoundItem as Delivery;

            if (dgvDelivery.Columns[e.ColumnIndex].Name == "查看详细")
            {
                FormDeliveryEdit form = new FormDeliveryEdit(entity,(int)entity.DeliveryStatus, false);
                (Parent.FindForm() as frmMain).ShowForm(form);
            }
        }


        private void BindGrid() 
        {
            string message = string.Empty;
            SalesCodeSearchInput input = new SalesCodeSearchInput();
            input.Code = this.txtCode.Text;
            if (this.dtFrom.Checked)
            {
                input.FromDate = this.dtFrom.Value;
            }
            if (this.dtTo.Checked)
            {
                input.ToDate = this.dtTo.Value;
            }
            if (this.cmbOperator.SelectedValue != null)
            {
                input.OperatorID = Guid.Parse(this.cmbOperator.SelectedValue.ToString());
            }

            Delivery[] list = new Delivery[0];
            if (this.Status == DeliveryStatus.Accepted)
            {
                list = PharmacyDatabaseService.GetSubmitedDeliveryByCondition(out pager, out message, input, this.pagerControl.PageIndex, this.pagerControl.PageSize);
            }
            else if (this.Status == DeliveryStatus.Canceled)
            {
                list = PharmacyDatabaseService.GetCanceledDeliveryByCondition(out pager, out message, input, this.pagerControl.PageIndex, this.pagerControl.PageSize);
            }
            else if (this.Status == DeliveryStatus.Outed)
            {
                list = PharmacyDatabaseService.GetOutedDeliveryByCondition(out pager, out message, input, this.pagerControl.PageIndex, this.pagerControl.PageSize);
            }
            else if (this.Status == DeliveryStatus.Signed)
            {
                list = PharmacyDatabaseService.GetSignedDeliveryByCondition(out pager, out message, input, this.pagerControl.PageIndex, this.pagerControl.PageSize);
            }
            else if (this.Status == DeliveryStatus.Return)
            {
                list = PharmacyDatabaseService.GetReturnedDeliveryByCondition(out pager, out message, input, this.pagerControl.PageIndex, this.pagerControl.PageSize);
            }

            dgvDelivery.DataSource = list;
          
            FormatRows();
        }

        private void pagerControl_DataPaging()
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //string msg = string.Empty;
            //Guid[] warehouseZonesIds = new Guid[] { };

            //DataTable dt = new DataTable("销售配送");

            //dt.Columns.Add("配送日期");
            //dt.Columns.Add("规格");
            //dt.Columns.Add("剂型");
            //dt.Columns.Add("单位");
            //dt.Columns.Add("批准文号");
            //dt.Columns.Add("生产厂家");
            //dt.Columns.Add("生产批号");
            //dt.Columns.Add("生产日期");
            //dt.Columns.Add("有效期至");
            //dt.Columns.Add("采购价");
            //dt.Columns.Add("可用库存");
            //dt.Columns.Add("金额");
            //DataRow dr = null;
            //foreach (var c in storage)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = c.ProductGeneralName;
            //    dr[1] = c.DictionarySpecificationCode;
            //    dr[2] = c.DictionaryDosageCode;
            //    dr[3] = c.DictionaryMeasurementUnitCode;
            //    dr[4] = c.LicensePermissionNumber;
            //    dr[5] = c.FactoryName;
            //    dr[6] = c.BatchNumber;
            //    dr[7] = c.PruductDate;
            //    dr[8] = c.OutValidDate;
            //    dr[9] = c.PurchasePrice;
            //    dr[10] = c.CanSaleNum;
            //    dr[11] = c.PriceCount;
            //    dt.Rows.Add(dr);
            //}

            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "EXCEL电子表格文件|*.XLS";
            //sfd.ShowDialog();
            //if (sfd.FileName != string.Empty)
            //{
            //    if (MyExcelUtls.DataTable2Sheet(sfd.FileName, dt))
            //    {
            //        MessageBox.Show("导出成功！");
            //    }
            //    else
            //    {
            //        MessageBox.Show("导出失败！");
            //    }
            //}
            //dt.Dispose();
            //dt = null;
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tsbtnSearch_Click(sender, e);
        }

    }
}
