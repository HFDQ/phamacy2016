using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.UI.Report;

using BugsBox.Pharmacy.AppClient.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugMaintain
{
    public partial class DrugMaintainRecordDetails : BaseFunctionForm
    {
        private string _documentNumber = string.Empty;
        private string msg = string.Empty;
        private List<DrugMaintainRecordDetail> _detail = null;
        private List<User> allUser = new List<User>();
        BaseForm.BasicInfoRightMenu cms = null;
        UI.Forms.BaseForm.BasicInfoRightMenu Bcms = null;
        /// <summary>
        /// 养护类型
        /// </summary>
        public int maintainTypeValue { get; set; }

        public string documentNumber
        {
            get { return _documentNumber; }
            set { _documentNumber = value; }
        }
        public bool isComplete { get; set; }

        public DrugMaintainRecordDetails()
        {
            InitializeComponent();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            allUser = this.PharmacyDatabaseService.AllUsers(out msg).ToList();

            this.dataGridView1.CellMouseClick += (sender, e) =>
            {
                cms.DrugId = Guid.Empty;
                cms.DrugInventoryId = Guid.Empty;

                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                var c = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as DrugMaintainRecordDetail;
                if (cms != null)
                {
                    cms.DrugInventoryId = c.DrugInventoryRecordId;
                }
            };

            cms = new BaseForm.BasicInfoRightMenu(this.dataGridView1);
            cms.InsertDrugBasicInfo();
        }

        public delegate void BindDataHandler();
        private void DrugMaintainRecordDetails_Load(object sender, EventArgs e)
        {
            txtBillDocumentNo.Text = _documentNumber;
            dataGridView1.AutoGenerateColumns = false;

            toolStripButton1.Enabled = !isComplete;
            this.dataGridView1.ReadOnly = isComplete;
            this.toolStripComboBox1.SelectedIndex = 1;
            this.BindData();

            if (this.maintainTypeValue == (int)DrugMaintainType.Inst)
            {
                this.Column1.HeaderText = "器械名称";
                this.Column14.HeaderText = "器械型号";
                this.Column20.HeaderText = "单位";
                this.Column3.HeaderText = "注册证或备案凭证编号";
                this.Text = "医疗器械养护记录明细";
            }

            this.dataGridView1.CellFormatting+=dataGridView1_CellFormatting;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
            if (MessageBox.Show("提示：提交前请认真检查，一旦提交后，疑问药品将进入质量复查流程，不可以修改，养护数量，需要保存养护记录吗？", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK) return;

            List<DrugMaintainRecordDetail> list = new List<DrugMaintainRecordDetail>();
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[Column18.Name].Value) && dr.ReadOnly == false)
                {
                    DrugMaintainRecordDetail dmrd = (DrugMaintainRecordDetail)dr.DataBoundItem;
                    dmrd.UserId = AppClientContext.CurrentUser.Id;
                    if (dmrd.MaintainCount < 0)
                    {
                        MessageBox.Show("养护数量小于0，请检查！");
                        return;
                    }
                    try
                    {
                        if (Convert.ToDecimal(dmrd.CheckqualifiedNumber) > dmrd.MaintainCount)
                        {
                            MessageBox.Show(dmrd.ProductName + "验收合格数量不能大于养护数量，请检查！");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("验收合格数量请填写数字！");
                        return;
                    }
                    list.Add(dmrd);
                }
            }

            if (list.Count <= 0)
            {
                MessageBox.Show("没有设置养护细节，您没有填写任何一行品种的养护数量等信息，请检查！");
                return;
            }
            if (this.PharmacyDatabaseService.SaveDrugMaintainDetailAndUndeterminate(list.ToArray(), out msg))
            {
                MessageBox.Show("养护细节保存成功！");
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存药品养护状态成功");

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(msg);
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "保存药品养护状态失败！");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void BindData()
        {
            string msg;
            _detail = PharmacyDatabaseService.GetDrugMaintainRecordDetailByCondition(out msg,
                  _documentNumber, null).ToList();

            this._detail.ForEach(r =>
            {
                r.CheckResult = string.IsNullOrEmpty(r.CheckResult) ? "外观检验" : r.CheckResult;
                r.MaintainResult = string.IsNullOrEmpty(r.MaintainResult) ? "正常" : r.MaintainResult;
            });

            dataGridView1.DataSource = new BindingCollection<DrugMaintainRecordDetail>(_detail);

            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                if (dr.Cells[this.Column7.Name].Value != null)
                {
                    dr.Cells[Column18.Name].Value = true;
                    dr.Cells[Column19.Name].Value = Convert.ToDecimal(dr.Cells[this.Column9.Name].Value) - Convert.ToDecimal(dr.Cells[this.Column10.Name].Value);
                    dr.ReadOnly = true;
                }
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name.Contains(this.Column11.Name))
            {
                Guid g = Guid.Parse(e.Value.ToString());
                if (g != Guid.Empty)
                {
                    User usr = allUser.Where(r => r.Id == g).FirstOrDefault();

                    if (usr != null)
                    {
                        e.Value = usr.Employee.Name;
                    }
                }
                else
                {
                    e.Value = string.Empty;
                }
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            DrugMaintainRecordDetail md = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as DrugMaintainRecordDetail;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name.Contains(this.Column10.Name))
            {
                decimal d = 0m;
                if (!decimal.TryParse(md.CheckqualifiedNumber, out d))
                {
                    MessageBox.Show("您填写了非数字信息，请修改!");
                    md.CheckqualifiedNumber = md.MaintainCount.ToString();
                    return;
                }
                if (d > md.MaintainCount)
                {
                    MessageBox.Show("您填写的养护合格数量超过了养护数量，请修改!");
                    md.CheckqualifiedNumber = md.MaintainCount.ToString();
                    return;
                }

                this.dataGridView1.Rows[e.RowIndex].Cells[this.Column19.Name].Value = md.MaintainCount - Convert.ToDecimal(md.CheckqualifiedNumber);
                this.dataGridView1.Rows[e.RowIndex].Cells[this.Column18.Name].Value = true;
            }

            if (this.dataGridView1.Columns[e.ColumnIndex].Name == this.Column9.Name)
            {
                if (md.MaintainCount > md.CurrentInventoryCount || md.MaintainCount < 0)
                {
                    MessageBox.Show("养护数量超过库存数量，请修改！");
                    md.MaintainCount = 0;
                    md.CheckqualifiedNumber = "0";
                    this.dataGridView1.Rows[e.RowIndex].Cells[this.Column18.Name].Value = false;
                    return;
                }
                md.CheckqualifiedNumber = md.MaintainCount.ToString();
                if (md.MaintainCount > 0m)
                    this.dataGridView1.Rows[e.RowIndex].Cells[this.Column18.Name].Value = true;
                else
                    this.dataGridView1.Rows[e.RowIndex].Cells[this.Column18.Name].Value = false;
            }

            if (this.dataGridView1.Columns[e.ColumnIndex].Name == this.Column18.Name)
            {
                if (!Convert.ToBoolean(this.dataGridView1.Rows[e.RowIndex].Cells[this.Column18.Name].Value))
                {
                    md.MaintainCount = 0m;
                    md.CheckqualifiedNumber = "0";
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("您输入的数据格式不正确，请修改！");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            decimal per = Convert.ToDecimal(this.toolStripComboBox1.SelectedItem) / 100;
            foreach (var c in _detail)
            {
                if (c.CheckDate != null) continue;
                c.MaintainCount = Convert.ToDecimal(c.CurrentInventoryCount * per);
                c.CheckqualifiedNumber = c.MaintainCount.ToString();
                c.CheckResult = "养护完成";
                c.UserId = AppClientContext.CurrentUser.Id;
                c.CheckDate = DateTime.Now;
            }
            foreach (DataGridViewRow r in this.dataGridView1.Rows)
            {
                r.Cells[1].Value = true;

            }
            this.dataGridView1.Refresh();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "药品养护单");
        }

    }
}
