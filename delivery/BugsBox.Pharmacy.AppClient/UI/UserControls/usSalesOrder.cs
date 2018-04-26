using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.PS;
using CustomValidatorsLibrary;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;

namespace BugsBox.Pharmacy.AppClient.UI.UserControls
{
    public partial class usSalesOrder : BaseFunctionUserControl
    {
        private SalesOrder _salesOrder = new SalesOrder();
        private List<SalesOrderDetail> _salesOrderDetail = new List<SalesOrderDetail>();

        public SalesOrder SalesOrder
        {
            get { return _salesOrder; }
            set { _salesOrder = value; }
        }

        private string _titleName;
        public string TitleName
        {
            get { return _titleName; }
            set 
            { _titleName = value;
              this.lblTitle.Text = value;
            }
        }
        public usSalesOrder()
        {
            InitializeComponent();
            DefineGridColumn();
        }

        public usSalesOrder(SalesOrder order)
        {
            InitializeComponent();
            this.SalesOrder = _salesOrder;
            DefineGridColumn();
        }

        public usSalesOrder(SalesOrder order, bool isEdit)
        {
            InitializeComponent();
            this.SalesOrder = _salesOrder;
            DefineGridColumn();
            SetControlIsEdit(isEdit);
        }

        public usSalesOrder(SalesOrder order, bool isEdit,string titleName)
        {
            InitializeComponent();
            this.SalesOrder = _salesOrder;
            DefineGridColumn();
            SetControlIsEdit(isEdit);
            this._titleName = titleName;
            this.lblTitle.Text = _titleName;
        }

        /// <summary>
        /// 根据SalesOrder 对象初始化控件
        /// </summary>
        /// <param name="supplyUnit"></param>
        public void InitEditControl(SalesOrder salesOrder)
        {
            if (salesOrder != null)
            {
                
                this.dtSalesDate.Value = salesOrder.SaleDate;
                this.cmbSalesMan.SelectedText = salesOrder.SalerName;
                this.cmbSupply.SelectedValue = salesOrder.PurchaseUnitId;
                this.txtTotalMoney.Text = salesOrder.TotalMoney.ToString();
                this.lblCreateDate.Text = salesOrder.CreateTime.ToString();
                this.lblOrderCode.Text = salesOrder.OrderCode;
                this.lblOrderState.Text = Utility.getEnumTypeDisplayName<BugsBox.Pharmacy.Models.OrderStatus>((BugsBox.Pharmacy.Models.OrderStatus)(_salesOrder.OrderStatusValue)); 
                string msg = string.Empty;
                _salesOrderDetail.Clear();
                _salesOrderDetail = PharmacyDatabaseService.GetSalesOrder(out msg, _salesOrder.Id).SalesOrderDetails.ToList();
                this.dgvDrugDetailList.DataSource = _salesOrderDetail;
            }
        }

        //private  DataTable ToDataTable<T>(this IList<T> list) 
        //{ 
        //    Type elementType = typeof(T);
        //    var t = new DataTable(); 
        //    elementType.GetProperties().ToList().ForEach(propInfo => t.Columns.Add(propInfo.Name, Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType));
        //    foreach (T item in list)
        //    { 
        //        var row = t.NewRow(); 
        //        elementType.GetProperties().ToList().ForEach(propInfo => row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value);
        //        t.Rows.Add(row);
        //    } 
        //    return t; 
        //}
        /// <summary>
        /// 定义GRIDView 的显示列
        /// </summary>
        private void DefineGridColumn()
        {
            dgvDrugDetailList.AutoGenerateColumns = false;
            Dictionary<string, string> dicGridViewTilte = new Dictionary<string, string>();
            dicGridViewTilte.Add("Index", "行号");
            dicGridViewTilte.Add("productCode", "商品编号");
            dicGridViewTilte.Add("productName", "商品名称");
            dicGridViewTilte.Add("BatchNumber", "批号");
            dicGridViewTilte.Add("UnitPrice", "单价");
            dicGridViewTilte.Add("Amount", "数量");
            dicGridViewTilte.Add("Price", "金额");
            dicGridViewTilte.Add("Decription", "说明");
            dicGridViewTilte.Add("MeasurementUnit", "单位");
            dicGridViewTilte.Add("SpecificationCode", "规格");
            dicGridViewTilte.Add("FactoryName", "生产厂商");
            dicGridViewTilte.Add("PruductDate", "生产日期");
            dicGridViewTilte.Add("OutValidDate", "有效期至");
            //根据字典构造DataGridView 列
            foreach (KeyValuePair<string, string> kv in dicGridViewTilte)
            {
                DataGridViewTextBoxColumn dgvtb = new DataGridViewTextBoxColumn();
                dgvtb.DataPropertyName = kv.Key;
                dgvtb.HeaderText = kv.Value;
                this.dgvDrugDetailList.Columns.Add(dgvtb);
            }
        }



        /// <summary>
        /// 设置控件的可用属性
        /// </summary>
        /// <param name="isEdit"></param>
        public void SetControlIsEdit(bool isEdit)
        {
            foreach (Control ct in tableLayoutPanel1.Controls)
            {
                if (ct is TextBox)
                    ((TextBox)ct).ReadOnly = !isEdit;
                else if (ct is RichTextBox)
                    ((RichTextBox)ct).ReadOnly = !isEdit;
                else if (ct is ComboBox)
                {
                    ((ComboBox)ct).Enabled = isEdit;
                }
                else if (ct is DateTimePicker)
                    ((DateTimePicker)ct).Enabled = isEdit;
                else if (ct is CheckBox)
                    ((CheckBox)ct).Enabled = isEdit;
            }

            this.dgvDrugDetailList.ReadOnly = !isEdit;
        }

        private void usSalesOrder_Load(object sender, EventArgs e)
        {
            try
            {
                if (_salesOrder != null)
                {
                    InitEditControl(_salesOrder);
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
