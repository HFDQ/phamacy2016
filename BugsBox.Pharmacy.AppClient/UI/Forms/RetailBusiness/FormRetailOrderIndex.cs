using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.RetailBusiness
{
    using RetailPaymentMethod = BugsBox.Pharmacy.Models.RetailPaymentMethod;
    using RetailCustomerType = BugsBox.Pharmacy.Models.RetailCustomerType;
    using BugsBox.Pharmacy.Service.Models;
    using BugsBox.Application.Core;

    public partial class FormRetailOrderIndex : BaseFunctionForm
    {
        private List<RetailOrder> _retailOrderList = new List<RetailOrder>();
        private PagerInfo pageInfo = new PagerInfo();
        private IList<User> userList = new List<User>();
        private List<Store> storeList = new List<Store>();
        public FormRetailOrderIndex()
        {
            try
            {
                InitializeComponent();
                DefineGridColumn();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRetailOrderIndex_Load(object sender, EventArgs e)
        {
            try
            {
                //客户类型初始化
                this.cmbRetailCustomerType.DataSource = Utility.CreateComboboxList<RetailCustomerType>();
                this.cmbRetailCustomerType.DisplayMember = "Name";
                this.cmbRetailCustomerType.ValueMember = "ID";

                //付款方式初始化
                this.cmbRetailPaymentMethod.DataSource = Utility.CreateComboboxList<RetailPaymentMethod>();
                this.cmbRetailPaymentMethod.DisplayMember = "Name";
                this.cmbRetailPaymentMethod.ValueMember = "ID";
                string msg = string.Empty;
                storeList = PharmacyDatabaseService.AllStores(out msg).ToList() ;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 定义GRIDView 的显示列
        /// </summary>
        private void DefineGridColumn()
        {
            dgvMain.AutoGenerateColumns = false;

            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
            btnView.HeaderText = "";
            btnView.Text = "查看明细";
            btnView.Name = "View";
            btnView.Width = 70;
            btnView.UseColumnTextForButtonValue = true;
            this.dgvMain.Columns.Add(btnView);

        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_retailOrderList != null && _retailOrderList.Count > 0)
                {
                    RetailOrder ro = _retailOrderList[e.RowIndex];
                    if (dgvMain.Columns[e.ColumnIndex].Name == "View")
                    {
                        FormRetailOrderEdit form = new FormRetailOrderEdit(ro);
                        form.ShowDialog();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void pcMain_DataPaging()
        {
            try
            {
                int pageIndex = this.pcMain.PageIndex;
                int pageSize = this.pcMain.PageSize;
                GetListRetailsOrder(pageIndex, pageSize);
                dgvMain.DataSource = _retailOrderList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }

        }


        private void GetListRetailsOrder(int pageIndex, int pageSize)
        {
            try
            {
                _retailOrderList = null;

                QueryRetailOrderModel qsom = InitQueryRetailOrderModel();
                _retailOrderList = PharmacyDatabaseService.SearchPagedRetailOrdersByQueryModel(out pageInfo, qsom, pageIndex, pageSize).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void cmbSeller_DropDown(object sender, EventArgs e)
        {
            try
            {
                FormOperatorSelector form = new FormOperatorSelector();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.cmbSeller.DataSource = form.Result;
                    this.cmbSeller.DisplayMember = "Name";
                    this.cmbSeller.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private QueryRetailOrderModel InitQueryRetailOrderModel()
        {
            QueryRetailOrderModel qrom = new QueryRetailOrderModel();


            if (this.cmbRetailCustomerType.SelectedValue != null)
                qrom.RetailCustomerTypeValueFrom = qrom.RetailCustomerTypeValueTo = Convert.ToInt16(cmbRetailCustomerType.SelectedValue);
            else
            {
                qrom.RetailCustomerTypeValueFrom = -1;
                qrom.RetailCustomerTypeValueTo = -2;
            }

            if (this.cmbRetailPaymentMethod.SelectedValue != null)
                qrom.RetailPaymentMethodValueFrom = qrom.RetailPaymentMethodValueTo = Convert.ToInt16(cmbRetailCustomerType.SelectedValue);
            else
            {
                qrom.RetailPaymentMethodValueFrom = -1;
                qrom.RetailPaymentMethodValueTo = -2;
            }

            qrom.TotalMoneyFrom = -1;
            qrom.TotalMoneyTo = -2;

            qrom.ChangeMoneyFrom = -1;
            qrom.ChangeMoneyTo = -2;
            qrom.GotMoneyFrom = -1;
            qrom.GotMoneyTo = -2;

            qrom.ReduceMoneyFrom = -1;
            qrom.ReduceMoneyTo = -2;


            qrom.ReceivableMoneyFrom = -1;
            qrom.ReceivableMoneyTo = -2;

            qrom.RealPayMoneyFrom = -1;
            qrom.RealPayMoneyTo = -2;

            qrom.UpdateTimeFrom = DateTime.Now.AddDays(1);
            qrom.UpdateTimeTo = DateTime.Now;

            qrom.TotalRefundFrom = -1;
            qrom.TotalRefundTo = -2;

            qrom.ReturnReduceMoneyFrom = -1;
            qrom.ReturnReduceMoneyTo = -2;

            qrom.ReturnRealReceiveMoneyFrom = -1;
            qrom.ReturnRealReceiveMoneyTo = -2;

            qrom.RetailCustomerTypeValueFrom = -1;
            qrom.RetailCustomerTypeValueTo = -2;

            qrom.Code = txtOrders.Text;

            qrom.CreateTimeFrom = DtFT.StartTime;
            qrom.CreateTimeTo = DtFT.EndTime;

            if (cmbSeller.SelectedValue != null)
                qrom.CreateUserId = (Guid)cmbSeller.SelectedValue;


            return qrom;
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FormRetailOrderEdit form = new FormRetailOrderEdit();
                (Parent.FindForm() as frmMain).ShowForm(form);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var cellValue = dgvMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                string cellFormatValue = string.Empty;
                if (dgvMain.Columns[e.ColumnIndex].Name == "客户类型")
                {
                    if (cellValue != null)
                    {
                        cellFormatValue = Utility.getEnumTypeDisplayName<BugsBox.Pharmacy.Models.RetailCustomerType>((BugsBox.Pharmacy.Models.RetailCustomerType)_retailOrderList[e.RowIndex].RetailCustomerTypeValue);
                        e.Value = cellFormatValue;
                    }
                }
                else if (dgvMain.Columns[e.ColumnIndex].Name == "付款方式")
                {
                    if (cellValue != null)
                    {
                        cellFormatValue = Utility.getEnumTypeDisplayName<BugsBox.Pharmacy.Models.RetailPaymentMethod>((BugsBox.Pharmacy.Models.RetailPaymentMethod)_retailOrderList[e.RowIndex].RetailPaymentMethodValue);
                        e.Value = cellFormatValue;
                    }

                }
                else if (dgvMain.Columns[e.ColumnIndex].Name == "门店编号")
                {
                    if (cellValue != null && (Guid)cellValue != Guid.Empty)
                    {
                        cellFormatValue = storeList.Where(w => w.Id == (Guid)cellValue).Select(s => s.Name).FirstOrDefault();
                        e.Value = cellFormatValue;
                    }

                }
                else
                    return;
            }


        }

        private void tsbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = this.pcMain.PageIndex = 1;
                int pageSize = this.pcMain.PageSize;
                GetListRetailsOrder(pageIndex, pageSize);
                dgvMain.DataSource = _retailOrderList;
                pcMain.RecordCount = pageInfo.RecordCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }


    }
}
