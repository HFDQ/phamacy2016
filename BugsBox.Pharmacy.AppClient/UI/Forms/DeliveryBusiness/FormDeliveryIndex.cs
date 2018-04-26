using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DeliveryBusiness
{

    public partial class FormDeliveryIndex :BaseFunctionForm
    {
        private List<Delivery> _DeliveryList = new List<Delivery>();
        private PagerInfo pageInfo = new PagerInfo();
        private IList<User> userList = new List<User>();
        private List<SalesOrder> _salesOrderList = new List<SalesOrder>();
        private List<PurchaseUnit> ListPurchaseUnit = new List<PurchaseUnit>();
        private string msg = string.Empty;
        ContextMenuStrip cms = new ContextMenuStrip();
        IList<User> ListUser = null;
        List<status2String> ListStatus = new List<status2String>();
        Guid ReceivingCmpID = Guid.Empty;

        public FormDeliveryIndex()
        {
            InitializeComponent();

            this.dgvMain.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.ListPurchaseUnit = this.PharmacyDatabaseService.AllPurchaseUnits(out msg).ToList();
            ListUser = this.PharmacyDatabaseService.AllUsers(out msg).ToList();

            #region 配送状态转换字符
            foreach (var i in typeof(DeliveryStatus).GetFields())
            {
                var attr = i.GetCustomAttributes(false);
                if (attr.Length > 0 && attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute != null)
                {
                    var v = typeof(DeliveryStatus).InvokeMember(i.Name, System.Reflection.BindingFlags.GetField, null, null, null);
                    var n = (attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute).Name;
                    status2String li = new status2String();
                    li.nam = n;
                    li.num = (Int32)v;
                    ListStatus.Add(li);
                }
            }
            #endregion

            this.RightMenu();            
        }

        //右键菜单
        private void RightMenu()
        {
            Font font = new System.Drawing.Font("楷体", 8, FontStyle.Bold);
            cms.Items.Add("表格操作", null, null);
            cms.Items[cms.Items.Count - 1].Font = font;
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("复制单元格", null, delegate(object sender, EventArgs e)
            {
                Clipboard.SetData(DataFormats.Text, this.dgvMain.CurrentCell.Value.ToString());
            });
            cms.Items.Add("-");
            cms.Items.Add("自动调整列宽", null, AutoColums);
            cms.Items.Add("自动调整行高", null, AutoRows);
            cms.Items.Add("-");
            cms.Items.Add("内容操作", null, null);
            cms.Items[cms.Items.Count - 1].Font = font;
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("查看销售单据", null, delegate(object sender, EventArgs e) { this.querySaleOrder(); });
            cms.Items.Add("查看配送记录", null, delegate(object sender, EventArgs e) { this.queryDeliveryOrder(); });
            cms.Items.Add("只查选中收货单位", null, delegate(object sender, EventArgs e) { this.queryByRecevingCmpID(); });
            cms.Items.Add("-");
            cms.Items.Add("导出操作", null, null);
            cms.Items[cms.Items.Count - 1].Font = font;
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("导出查询结果", null, this.toolStripButton1_Click);
        }
        //调整列宽
        private void AutoColums(object sender, EventArgs e)
        {
            this.dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        //调整行高
        private void AutoRows(object sender, EventArgs e)
        {
            this.dgvMain.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }
        //销售单
        private void querySaleOrder()
        {
            if (this.dgvMain.SelectedRows.Count<=0) return;
            Business.Models.DeliveryModel dm = this.dgvMain.SelectedRows[0].DataBoundItem as Business.Models.DeliveryModel;
            Models.SalesOrder c = this.PharmacyDatabaseService.GetSalesOrder(out msg, dm.SalesOrderID);
            Forms.SalesBusiness.FormSalesOrderEdit frm = new SalesBusiness.FormSalesOrderEdit(c, false);
            frm.ShowDialog();
        }
        //查看配送记录
        private void queryDeliveryOrder()
        {
            if (this.dgvMain.SelectedRows.Count <= 0) return;
            Business.Models.DeliveryModel dm = this.dgvMain.SelectedRows[0].DataBoundItem as Business.Models.DeliveryModel;
            Delivery d = this.PharmacyDatabaseService.GetDelivery(out msg, dm.ID);
            FormDeliveryEdit editForm = new FormDeliveryEdit(d, d.DeliveryStatusValue, false);
            editForm.ShowDialog(this);
        }

        //查询指定收货单位配送信息
        private void queryByRecevingCmpID()
        {
            try
            {
                int pageIndex = this.pcMain.PageIndex = 1;
                int pageSize = this.pcMain.PageSize;
                var c = this.dgvMain.CurrentRow.DataBoundItem as Business.Models.DeliveryModel;
                if (c == null) return;
                this.ReceivingCmpID = c.ReceivingCompasnyID;
                GetListDelivery(pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }
        //隐藏列
        private void HideColumns()
        {
            this.dgvMain.Columns["ID"].Visible = false;
            this.dgvMain.Columns["SalesOrderID"].Visible = false;
            this.dgvMain.Columns["DrugsPrice"].Visible = false;
            this.dgvMain.Columns["ReceivingCompasnyID"].Visible = false;
        }
        
        private void FormDeliveryIndex_Load(object sender, EventArgs e)
        {
            try
            {
                //配送方式
                var dm = Utility.CreateComboboxList<DeliveryMethod>(true);
                dm.Insert(0,new Pharmacy.UI.Common.ListItem(null,"全部"));
                this.cmbDeliveryMethod.DataSource = dm;
                this.cmbDeliveryMethod.DisplayMember = "Name";
                this.cmbDeliveryMethod.ValueMember = "ID";
                this.cmbDeliveryMethod.SelectedIndex = 0;

                //配送状态
                //var ds=Utility.CreateComboboxList<DeliveryStatus>(true);
                this.ListStatus.Insert(0, new status2String() { nam="全部",num=-1});
                this.cmbDeliveryStatus.DataSource = this.ListStatus;
                this.cmbDeliveryStatus.DisplayMember = "nam";
                this.cmbDeliveryStatus.ValueMember = "num";
                this.cmbDeliveryStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void tsbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = this.pcMain.PageIndex = 1;
                int pageSize = this.pcMain.PageSize;
                this.ReceivingCmpID = Guid.Empty;
                GetListDelivery(pageIndex, pageSize);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void GetListDelivery(int pageIndex, int pageSize)
        {
            try
            {
                _DeliveryList = null;
                DeliveryIndexInput qsom = InitDeliveryIndexInput();
                string msg = string.Empty;
                var c = PharmacyDatabaseService.GetDeliveryPaged(out pageInfo, out msg, qsom, pageIndex, pageSize);
                var result = from ds in ListStatus join i in c on ds.num equals i.DeliveryStatusValue
                             join u in ListUser on i.AcceptedOperatorId equals u.Id into Left1
                             from u in Left1.DefaultIfEmpty()
                             join u1 in ListUser on i.outedOperatorId equals u1.Id into Left2
                             from u1 in Left2.DefaultIfEmpty()
                             join u2 in ListUser on i.SignedOperatorId equals u2.Id into Left3
                             from u2 in Left3.DefaultIfEmpty()
                             select new Business.Models.DeliveryModel
                             {
                                    AcceptedOperator=u==null?"未受理":u.Employee.Name,
                                    AcceptedTime=u==null?i.CreateTime:i.AcceptedTime,
                                    DeliveryAddress=i.DeliveryAddress,
                                    DeliveryMethod =u==null?"未受理": (i.DeliveryMethodValue == 0 ? "客户自理" : i.DeliveryMethodValue == 1 ? "自有车辆运输" : "委托运输"),
                                    DeliveryStatus=ds.nam,
                                    DrugsCount=i.DrugsCount,
                                    ID=i.Id,
                                    outedOperator=u1==null?"未出库":u1.Employee.Name,
                                    outedTime=u1==null?i.CreateTime:i.outedTime,
                                    Principal=u==null?string.Empty:i.Principal,
                                    PrincipalPhone=u==null?string.Empty:i.PrincipalPhone,
                                    ReceivingCompasnyID=i.ReceivingCompasnyID,
                                    ReceivingCompasnyName=i.ReceivingCompasnyName,
                                    SalesOrderID=i.OrderID,
                                    SalesOrderNumber=i.SalesOrder,
                                    ShippingAddress=i.ShippingAddress,
                                    SignedOperator=u2==null?"未签收":u2.Employee.Name,
                                    SignedTime=u2==null?i.CreateTime:i.SignedTime,
                                    TransportCompany=u==null?string.Empty:i.TransportCompany,
                                    TransportMethod =u==null?"未受理":( i.TransportMethodValue == 0 ? "客户自理" : i.TransportMethodValue == 1 ? "自有车辆运输" : "委托运输"),
                                    VehicleInfo=u==null?string.Empty:i.VehicleInfo,
                                    Memo=i.Memo
                             };
                this.dgvMain.DataSource = result.ToList();
                pcMain.RecordCount = pageInfo.RecordCount;

                this.HideColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        //设置查询条件
        private DeliveryIndexInput InitDeliveryIndexInput()
        {
            DeliveryIndexInput dii = new DeliveryIndexInput();

            dii.OrderNumber = this.txtSalesOrder.Text.Trim();

            dii.DeliveryFromDate = dtFrom.Value.Date;
            dii.DeliveryToDate = dtTo.Value.AddDays(1).Date;

            if (this.cmbDeliveryMethod.SelectedValue != null)
                dii.DeliveryMethodValue = cmbDeliveryMethod.SelectedIndex-1;
            else
                dii.DeliveryMethodValue = -1;

            if (this.cmbDeliveryStatus.SelectedValue != null)
                dii.DeliveryStatusValue = Convert.ToInt16(cmbDeliveryStatus.SelectedValue);
            else
                dii.DeliveryStatusValue = -1;

            dii.ReceivingCompasnyName = this.textBox1.Text.Trim();
            dii.ReceivingCompasnyID = this.ReceivingCmpID;
            return dii;
        }
        
        private void dgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void dgvMain_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgvMain_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            this.dgvMain.Rows[e.RowIndex].Selected = true;
            this.dgvMain.CurrentCell = this.dgvMain.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cms.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void pcMain_DataPaging()
        {
            int pageIndex = this.pcMain.PageIndex;
            int pageSize = this.pcMain.PageSize;
            GetListDelivery(pageIndex, pageSize);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dgvMain, "配送信息查询结果");
        }

        private void txtSalesOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tsbtnSearch_Click(sender, e);
        }
    }
    public class status2String
    {
        public int num { get; set; }
        public string nam { get; set; }
    }
}
