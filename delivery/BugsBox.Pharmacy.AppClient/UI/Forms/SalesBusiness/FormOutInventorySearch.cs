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
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormOutInventorySearch : BaseFunctionForm
    {
        public OutInventoryStatus Status { get; set; }
        private PagerInfo pager = new PagerInfo();

        string FirstChecker = string.Empty;
        string SecondChecker = string.Empty;
        string InventoryKeeper = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outInventoryStatus"></param>
        public FormOutInventorySearch(object outInventoryStatus)
        {
            InitializeComponent();
            this.dgvOutInventory.AutoGenerateColumns = false;
            this.Status = EnumHelper<OutInventoryStatus>.Parse(outInventoryStatus.ToString());
            this.Text = this.Status == OutInventoryStatus.Outing ? "出库记录查询" : "出库审核记录查询";
        }

        /// <summary>
        /// 初始化画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOutInventoryIndex_Load(object sender, EventArgs e)
        {
            string message = string.Empty;
            try
            {
                IEnumerable<User> users = PharmacyDatabaseService.GetAllUsers(out message);
                var list = users.Select(p => new ListItem { ID = p.Id.ToString(), Name = p.Account }).ToList();
                list.Insert(0, new ListItem { ID = Guid.Empty.ToString(), Name = "-请选择-" });
                
            }
            catch (Exception)
            {
                MessageBox.Show("画面初始化失败");
            }

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            string xmlFile = AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml";
            doc.Load(xmlFile);
            System.Xml.XmlNodeList NodeList = doc.SelectNodes("/SalePriceType/SaleOutInventoryChecker");
            FirstChecker = NodeList[0].Attributes[0].Value.ToString();
            SecondChecker = NodeList[0].Attributes[1].Value.ToString();
            InventoryKeeper = NodeList[0].Attributes[2].Value.ToString();

            dgvOutInventory.DataSource = null;
            this.pagerControl.RecordCount = 0;
        }

        /// <summary>
        /// 检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                
                BindGrid();
                this.pagerControl.RecordCount = pager.RecordCount;
                pagerControl.PageIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("检索出库单失败!" + ex.Message);
            }
        }
        /// <summary>
        /// 翻页
        /// </summary>
        private void pagerControl_DataPaging()
        {
            BindGrid();

        }

        /// <summary>
        /// 格式化表格数据
        /// </summary>
        private void FormatRows() 
        {
            foreach (DataGridViewRow row in this.dgvOutInventory.Rows)
            {
                var entity = row.DataBoundItem as OutInventory;
                if (entity != null)
                {
                    try
                    {
                        string message;
                        row.Cells["序号"].Value = row.Index + 1;
                        row.Cells["出库类型"].Value = Utility.getEnumTypeDisplayName<OutInventoryType>(entity.OutInventoryType);
                        row.Cells["出库状态"].Value = Utility.getEnumTypeDisplayName<OutInventoryStatus>(entity.OutInventoryStatus);
                        row.Cells["保管员"].Value = InventoryKeeper;
                        if (this.checkBox1.Checked)
                        {
                            row.Cells["复核员"].Value = FirstChecker;
                            row.Cells["第二复核员"].Value = SecondChecker;
                        }
                        else
                        {
                            row.Cells["复核员"].Value = FirstChecker;
                        }
                        
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
        /// 查看详细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOutInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var entity = dgvOutInventory.Rows[e.RowIndex].DataBoundItem as OutInventory;

            if (dgvOutInventory.Columns[e.ColumnIndex].Name == "查看详细")
            {
                FormOutInventory form = new FormOutInventory(entity.SalesOrderID, entity.Id, true);
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
            input.isImport = this.checkBox1.Checked ? 1 : 0;

            OutInventory[] list = new OutInventory[0];
            if (this.Status == OutInventoryStatus.Outing)
            {
                list = PharmacyDatabaseService.GetSubmitedOutInventoryByCondition(out pager, out message, input, this.pagerControl.PageIndex, this.pagerControl.PageSize);
            }
            else if (this.Status == OutInventoryStatus.Outed)
            {
                list = PharmacyDatabaseService.GetAcceptedOutInventoryByCondition(out pager, out message, input, this.pagerControl.PageIndex, this.pagerControl.PageSize);
            }
            dgvOutInventory.DataSource = list;
            FormatRows();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dgvOutInventory, "销售出库拣货复核查询结果");
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tsbtnSearch_Click(sender, e);
        }
    }
}
