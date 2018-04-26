using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using System.Xml;
using System.Data.SqlClient;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Storage
{
    public partial class FormStorageChecking : BaseFunctionForm
    {
        private string addr = string.Empty;
        private string dbname = string.Empty;
        private string user = string.Empty;
        private string pw = string.Empty;
        System.Data.SqlClient.SqlConnection oleConnection = null;
        string sql = null;
        DataSet dsw = new DataSet();
        DataTable dtn;
        string DocNum = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();

        private string strValue;
        public string StrValue
        {
            set
            {
                strValue = value;
            }
        }

        List<Business.Models.InventeryModel> storage = null;
        BindingList<Business.Models.InventeryModel> bList = new BindingList<Business.Models.InventeryModel>();
        string msg = string.Empty;
        ToolTip tt = new ToolTip();
        ContextMenuStrip cms = new ContextMenuStrip();
        public FormStorageChecking()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            XmlDocument doc = new XmlDocument();
            string xmlFile = AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml";
            doc.Load(xmlFile);
            XmlNodeList nodeList = doc.SelectNodes("/SalePriceType/photo");
            addr = nodeList[0].Attributes["Address"].Value.ToString();
            dbname = nodeList[0].Attributes["database"].Value.ToString();
            user = nodeList[0].Attributes["user"].Value.ToString();
            pw = nodeList[0].Attributes["pw"].Value.ToString();

            BindComboBoxWarehouseZones();
            this.dataGridView1.DataSource = new BindingCollection<InventeryModel>(bList);

            sql = "Data Source=" + addr + ";Initial Catalog=" + dbname + ";User ID=" + user + ";Password=" + pw + ";Min Pool Size=1";
            strValue = string.Empty;

            tt.SetToolTip(this.dataGridView1, "批次详细");
            tt.UseFading = true;
            tt.InitialDelay = 2000;
            tt.UseAnimation = true;

            tt.AutoPopDelay = 10000;
            tt.BackColor = Color.Blue;
            tt.IsBalloon = true;

            //移库至
            ToolStripMenuItem tsi = new ToolStripMenuItem("移至－>");
            WarehouseZone[] warehousezoneArr = this.comboBox1.DataSource as WarehouseZone[];

            foreach (var i in warehousezoneArr)
            {
                tsi.DropDownItems.Add(i.Name, null, DrugInventoryMoveClick);
                tsi.DropDownItems[tsi.DropDownItems.Count - 1].Tag = i;
            }



            cms.Items.Add("流向查看");
            cms.Items.Add("-");
            //cms.Items.Add("查看购销流向", null, this.button3_Click);
            cms.Items.Add("查看品种来源", null, DrugSouce_Click);
            cms.Items.Add("查看品种批次来源", null, DrugBatchSource_Click);
            cms.Items.Add("-");
            cms.Items.Add("移库操作");
            cms.Items.Add("-");
            cms.Items.Add(tsi);
            cms.Items.Add("查看移库记录", null, delegate (object sender, EventArgs e)
                {
                    Form_DrugInventoryMove frm = new Form_DrugInventoryMove();
                    frm.ShowDialog();
                });
        }

        /// <summary>
        /// 移库右键菜单
        /// </summary>
        /// <param name="sender">sender内含tag属性为warehousezone对象</param>
        /// <param name="e"></param>
        private void DrugInventoryMoveClick(object sender, EventArgs e)
        {
            WarehouseZone wz = ((ToolStripDropDownItem)sender).Tag as WarehouseZone;
            if (wz.Name == this.comboBox1.SelectedText) return;

            ApprovalFlowType aft = this.PharmacyDatabaseService.GetApprovalFlowTypeByBusiness(out msg, ApprovalType.drugsInventoryMove).FirstOrDefault();
            if (aft == null)
            {
                MessageBox.Show("请先通知管理员设定移库审批，并设定其审批节点！"); return;
            }

            if (MessageBox.Show("确定需要申请该药品移库至:" + wz.Name + "吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            Guid InventoryID = storage[this.dataGridView1.SelectedCells[0].RowIndex].InventoryID;
            DrugInventoryRecord dir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, InventoryID);
            if (dir == null)
            {
                MessageBox.Show("读取库存表失败！");
                return;
            }

            DrugsInventoryMove dim = new DrugsInventoryMove();
            dim.Id = Guid.NewGuid();
            dim.ApprovalStatusValue = 1;
            dim.batchNo = dir.BatchNumber;
            dim.createTime = DateTime.Now;
            dim.createUID = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id;
            dim.Deleted = false;
            dim.Description = "移库至" + wz.Name;
            dim.drugName = dir.DrugInfo.ProductGeneralName;
            dim.flowID = Guid.NewGuid();
            dim.inventoryRecordID = dir.Id;
            dim.OriginWareHouseID = dir.WarehouseZoneId;
            dim.quantity = dir.CanSaleNum;
            dim.updateTime = DateTime.Now;
            dim.WareHouseID = wz.Id;
            bool b = this.PharmacyDatabaseService.AddDrugsInventoryMoveByFlowID(dim, aft.Id, "新增移库审批", out msg);
            if (b)
            {
                this.PharmacyDatabaseService.WriteLog(dim.createUID, "成功提交移库申请信息：" + dim.drugName + "被成功申请移至" + dim.OriginWareHouseID);
                if (MessageBox.Show("成功申请移库信息" + wz.Name + "，请至右键菜单－>移库记录查询界面查询！需要打开移库记录查询窗口吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
                Form_DrugInventoryMove frm = new Form_DrugInventoryMove();
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.toolStripButton1.Enabled = true;
            if (dataGridView1.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("请确定是否需要保存当前数据，点击确定后未保存数据将丢失！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                    Search();
                else
                    return;
            }
            else
                Search();

        }

        private void Search()
        {
            try
            {
                Guid[] warehouseZonesIds = new Guid[] { };
                if (this.comboBox1.SelectedIndex != -1)
                {
                    warehouseZonesIds = new Guid[] { Guid.Parse(comboBox1.SelectedValue.ToString()) };
                    if (this.comboBox1.Text.Contains("中药"))
                    {
                        dataGridView1.Columns["OutValidDate"].Visible = false;
                        dataGridView1.Columns["Decription"].Visible = true;
                    }
                    else
                    {
                        dataGridView1.Columns["OutValidDate"].Visible = true;
                        dataGridView1.Columns["Decription"].Visible = false;
                    }
                }
                string msg = String.Empty;

                bool combine = BatchCombineCheck.Checked;

                storage = PharmacyDatabaseService.StorageQuery(out msg, this.textBox1.Text.Trim(), this.textBox2.Text.Trim(), this.textBox3.Text.Trim(), warehouseZonesIds, 1, 100000, new object[] { combine }).ToList();
                if (storage == null)
                {
                    MessageBox.Show("查询结果为空！");
                    return;
                }

                this.dataGridView1.DataSource = new BindingCollection<InventeryModel>(storage);
                this.label8.Text = "当前盘存品种共计：" + dataGridView1.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误,请联系管理员" + ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void BindComboBoxWarehouseZones()
        {
            string msg = string.Empty;
            WarehouseZone[] listWarehouseZone = PharmacyDatabaseService.AllWarehouseZones(out msg);
            this.comboBox1.DataSource = listWarehouseZone;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.SelectedIndex = -1;
        }
        private void pagerControl1_DataPaging()
        {
            Search();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        private void BatchCombineCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("盘存数据为空！无导出数据！");
                return;
            }
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, this.comboBox1.Text + "库存");
            //Search();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            if (e.ColumnIndex == this.dataGridView1.ColumnCount - 1)
            {
                return;
            }
            if (e.ColumnIndex == this.dataGridView1.ColumnCount - 2)
            {
                return;
            }

            if (e.RowIndex < 0) return;
            Guid gid = storage[e.RowIndex].InventoryID;
            Guid druginfoid = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, gid).DrugInfoId;
            Storage.Form_DrugPath frm = new Storage.Form_DrugPath(druginfoid, 3);
            frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_InventoryPL frm = new Form_InventoryPL();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Search();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (this.dataGridView1.CurrentCell.OwningColumn.Name != this.colPLNum.Name) return;

            decimal cansale = storage[e.RowIndex].CanSaleNum;
            if (storage[e.RowIndex].DismantingAmount < -cansale)
            {
                MessageBox.Show("损溢数量有误，最低不能超过负的可销数量！");
                storage[e.RowIndex].DismantingAmount = 0;
                return;
            }
        }
        /// <summary>
        /// 查看品种来源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrugBatchSource_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                Guid InvID = storage[this.dataGridView1.SelectedCells[0].RowIndex].InventoryID;
                DrugInventoryRecord diir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, InvID);
                Guid pinId = diir.PurchaseInInventeryOrderDetailId;

                if (pinId != Guid.Empty)
                {
                    Common.Form_HistoryPurchase frm = new Common.Form_HistoryPurchase(pinId);
                    frm.ShowDialog();
                    this.dataGridView1.Focus();
                }
            }
        }

        private void DrugSouce_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                Guid InvID = storage[this.dataGridView1.SelectedCells[0].RowIndex].InventoryID;
                DrugInventoryRecord diir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, InvID);
                Guid pinId = diir.DrugInfoId;

                if (pinId != Guid.Empty)
                {
                    Common.Form_HistoryPurchase frm = new Common.Form_HistoryPurchase(pinId, 1);
                    frm.ShowDialog();
                    this.dataGridView1.Focus();
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            this.dataGridView1.ClearSelection();
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cms.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int count = 0;
            Guid[] warehouseZonesIds = new Guid[] { };
            if (this.comboBox1.SelectedIndex != -1)
            {
                warehouseZonesIds = new Guid[] { Guid.Parse(comboBox1.SelectedValue.ToString()) };
            }
            string msg = String.Empty;

            bool combine = BatchCombineCheck.Checked;
            this.dataGridView1.EndEdit();
            try
            {
                List<object> list = new List<object>();

                System.Data.SqlClient.SqlConnection oleConnection = new System.Data.SqlClient.SqlConnection(sql);
                oleConnection.Open();
                DataSet dsSql = new DataSet();
                System.Data.SqlClient.SqlDataAdapter oa = new System.Data.SqlClient.SqlDataAdapter("select * from StorageChecking", oleConnection);

                oa.Fill(dsSql);
                System.Data.SqlClient.SqlCommandBuilder scb = new System.Data.SqlClient.SqlCommandBuilder(oa);

                dtn = dsSql.Tables[0];
                DateTime date = DateTime.Now;
                int j = dtn.Rows.Count;
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("尚未查询当前库存情况，记录为空！");
                    return;
                }
                var dtnGroup = from i in dtn.AsEnumerable()
                               group i by new { t1 = i.Field<string>("DocumentNum") } into g
                               select new
                               {
                                   DocNo = g.FirstOrDefault().Field<string>("DocumentNum").ToString()
                               };
                if (dtnGroup != null)
                {
                    foreach (var item in dtnGroup.ToList())
                    {
                        if (item.DocNo.Contains(DocNum))
                        {
                            if (MessageBox.Show("本月已做过盘存操作,如果你需要重新盘存，本月原盘存记录将被清除!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {

                                oleConnection = new System.Data.SqlClient.SqlConnection(sql);
                                oleConnection.Open();
                                System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
                                sqlCommand.Connection = oleConnection;
                                sqlCommand.CommandText = "delete from StorageChecking where DocumentNum LIKE  '%" + DocNum + "%'";
                                sqlCommand.ExecuteNonQuery();
                                MessageBox.Show("本月旧盘存记录清除完成！");
                                return;
                            }
                            else
                            {
                                dataGridView1.DataSource = null;
                                return;
                            }
                        }

                    }
                }


                foreach (DataGridViewRow r in this.dataGridView1.Rows)
                {
                    if (Convert.ToDecimal(r.Cells["colRealAmount"].Value) == 0)
                    {
                        count++;
                        r.Cells["colRealAmount"].Style.BackColor = Color.Red;
                    }
                    string pName = r.Cells[0].Value.ToString();
                    string gg = r.Cells[1].Value.ToString();
                    string unit = r.Cells[2].Value.ToString();
                    string pNumber = r.Cells[3].Value.ToString();
                    string pFactory = r.Cells[4].Value == null ? "无" : r.Cells[4].Value.ToString();
                    string origin = r.Cells[5].Value == null ? "无" : r.Cells[5].Value.ToString();
                    string batchNumber = r.Cells[6].Value == null ? "无" : r.Cells[6].Value.ToString();
                    DateTime pDate = Convert.ToDateTime(r.Cells[7].Value);
                    DateTime validDate = Convert.ToDateTime(r.Cells[8].Value);
                    decimal purchasePrice = Convert.ToDecimal(r.Cells[9].Value);
                    decimal canUsed = Convert.ToDecimal(r.Cells[10].Value);
                    decimal currentIn = Convert.ToDecimal(r.Cells[11].Value);
                    decimal money = Convert.ToDecimal(r.Cells[12].Value);
                    decimal realAmount = r.Cells[13].Value == null ? 0m : Convert.ToDecimal(r.Cells[13].Value);
                    decimal dismaindAmount = canUsed - realAmount;
                    DateTime dtime = DateTime.Now;
                    string documentNum = "PCD" + DocNum;
                    string opuser = AppClientContext.CurrentUser.Employee.Name;
                    string wh = r.Cells["Column3"].Value.ToString();

                    DataRow dr = dtn.NewRow();
                    dr.BeginEdit();
                    dr[0] = j++;
                    dr[1] = pName.ToString();
                    dr[2] = gg;
                    dr[3] = unit;
                    dr[4] = pNumber;
                    dr[5] = pFactory;
                    dr[6] = origin;
                    dr[7] = batchNumber;
                    dr[8] = pDate;
                    dr[9] = validDate;
                    dr[10] = purchasePrice;
                    dr[11] = canUsed;
                    dr[12] = money;
                    dr[13] = currentIn;
                    dr[14] = realAmount;
                    dr[15] = canUsed - realAmount;
                    dr[16] = dtime;
                    dr[17] = documentNum;
                    dr[18] = opuser;
                    dr[19] = wh;
                    dr.EndEdit();
                    dtn.Rows.Add(dr);
                }
                DataTable dty = new DataTable();
                if (count > 0)
                {
                    if (MessageBox.Show("有实盘数据为0，是否继续保存？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        oa.Update(dtn);
                        dsSql.AcceptChanges();
                        count = 0;
                        MessageBox.Show("保存成功，损溢数量将自动计算。\n\r请注意：若有药品损溢情况，请申报损溢并审批！");
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    oa.Update(dtn);
                    dsSql.AcceptChanges();
                    count = 0;
                    MessageBox.Show("保存成功，损溢数量将自动计算。\n\r请注意：若有药品损溢情况，请申报损溢并审批！");
                }

                oleConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("请确定是否需要保存当前数据，点击确定后未保存数据将丢失！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                    return;
            }
            this.dataGridView1.DataSource = null;
            FormHisInventeryChecking frm = new FormHisInventeryChecking();
            frm.Owner = this;
            frm.ShowDialog();

            if (strValue == string.Empty) return;
            System.Data.SqlClient.SqlConnection oleConnection = new System.Data.SqlClient.SqlConnection(sql);
            oleConnection.Open();
            DataSet dsSql = new DataSet();
            System.Data.SqlClient.SqlDataAdapter oa = new System.Data.SqlClient.SqlDataAdapter("select * from StorageChecking where DocumentNum LIKE  '%" + strValue + "%'", oleConnection);

            oa.Fill(dsSql);
            System.Data.SqlClient.SqlCommandBuilder scb = new System.Data.SqlClient.SqlCommandBuilder(oa);

            dtn = dsSql.Tables[0];
            dataGridView1.DataSource = dtn;
            if (strValue.Contains(DocNum))
            {
                toolStripButton1.Enabled = true;
                foreach (DataGridViewRow r in this.dataGridView1.Rows)
                {
                    if (Convert.ToDecimal(r.Cells["colRealAmount"].Value) == 0)
                    {
                        count++;
                        r.Cells["colRealAmount"].Style.BackColor = Color.Red;
                    }
                }
            }
            else
            {
                toolStripButton1.Enabled = false;
            }
            this.label8.Text = "当前盘存品种共计：" + dataGridView1.Rows.Count.ToString() + "；当前盘存尚有" + count.ToString() + "条未处理！";
        }

    }
}
