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
using BugsBox.Pharmacy.UI.Common.Printer;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.UI.Report;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugsUnqualification
{
    public partial class FormDrugsDestroyDetails : BaseFunctionForm
    {
        string msg = string.Empty;
        private int currentPage=0;
        private int pageSize = 30;
        private int pageNum = 0;
        private List<DrugsUnqualificationDestroy> result = null;
        List<User> Users = null;

        DateTimePicker dtF = new DateTimePicker();
        DateTimePicker dtT = new DateTimePicker();
        BaseRightMenu brm = null;

        public FormDrugsDestroyDetails()
        {
            InitializeComponent();

            dtF.Value = DateTime.Now.Date.AddDays(-3);
            dtF.Width = 120;
            ToolStripControlHost tsch = new ToolStripControlHost(dtF);
            this.toolStrip1.Items.Insert(2,tsch);
            this.toolStrip1.Items.Insert(3, new ToolStripLabel("至"));

            dtT.Value = DateTime.Now.Date;
            dtT.Width = 120;
            tsch = new ToolStripControlHost(dtT);
            this.toolStrip1.Items.Insert(4, tsch);

            this.brm = new BaseRightMenu(this.dataGridView1);
            this.brm.InsertMenuItem("查看报损审批信息", this.OpenBreakageApprovalForm);
            this.brm.InsertMenuItem("查看不合格审批信息", this.OpenUnqualicationApprovalForm);

            this.dataGridView1.RowPostPaint += (sender, e) =>
            {
                DataGridViewOperator.SetRowNumber((DataGridView)sender, e);
            };

            Users = this.PharmacyDatabaseService.AllUsers(out msg).ToList();
        }
        private void getDrugsDestroyData()
        {
            var rs = result.Skip(pageSize * currentPage).Take(pageSize);
            this.dataGridView1.DataSource = rs.ToList();

            foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
            {
                if (!dc.Name.StartsWith("Column"))
                {
                    dc.Visible = false;
                    continue;
                }
                if (dc.Name == "Column7")
                {
                    dc.DefaultCellStyle.Format = "yy年MM月dd日";
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            result = PharmacyDatabaseService.getDrugsUnqualificationDestroysByCondition(this.dtF.Value.Date, this.dtT.Value.Date.AddDays(1), queryText.Text, out msg).ToList();
            currentPage = 0;
            pageNum = Convert.ToInt16(Math.Ceiling((Convert.ToDouble(result.Count) / Convert.ToDouble(pageSize))));
            this.toolStripLabel2.Text = "共计" + pageNum.ToString() + "页";
            this.toolStripLabel6.Text = "1";
            this.toolStripTextBox2.Text = "1";
            this.getDrugsDestroyData();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.pageSize = Convert.ToInt32(toolStripTextBox1.Text);
            this.toolStripLabel6.Text = "1";
            currentPage = 0;
            pageNum = Convert.ToInt16(Math.Ceiling((Convert.ToDouble(result.Count) / Convert.ToDouble(pageSize))));
            this.toolStripLabel2.Text = "共计" + pageNum.ToString() + "页";
            this.toolStripTextBox2.Text = "1";
            this.getDrugsDestroyData();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.currentPage = this.currentPage > 0 ? this.currentPage-1 : this.currentPage;
            this.toolStripLabel6.Text = (currentPage + 1).ToString();
            this.getDrugsDestroyData();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.currentPage=this.currentPage==pageNum-1?this.currentPage:this.currentPage+1;
            this.toolStripLabel6.Text = (currentPage + 1).ToString();
            this.getDrugsDestroyData();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            int turnToPage=Convert.ToInt16(toolStripTextBox2.Text)-1;
            if(turnToPage<0||turnToPage>=pageNum||turnToPage==currentPage)return;
            this.currentPage = turnToPage;
            this.getDrugsDestroyData();
        }
        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            char[] cs = toolStripTextBox2.Text.ToCharArray();
            foreach (char c in cs)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("请输入数字！");
                    return;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.queryText.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.CurrentCell.OwningColumn.Name != "Column8") return;
            DrugsUnqualificationDestroy d = result[e.RowIndex];
            FormDrugUnqualificationDestroy f = new FormDrugUnqualificationDestroy(d);
            f.ShowDialog();            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (result == null) return;
            this.toolStripLabel7.Text = "正在导出";
            this.toolStripProgressBar1.Value = 0;
            this.toolStripProgressBar1.Maximum = result.Count;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "EXCEL电子表格|*.xls";
            sfd.FileName = "报损药品销毁信息" + DateTime.Now.ToString("yyyyMMddhhmmss");
            sfd.ShowDialog();
            
            if (sfd.FileName == string.Empty) return;
            if (this.outputToXLS(sfd.FileName))
            {
                MessageBox.Show("导出成功！");
            }
            else
            {
                MessageBox.Show("导出失败！");
            }
        }

        private bool outputToXLS(string filename)
        {
            try
            {
                DataTable dt = new DataTable("药品销毁表");
                dt.Columns.Add("序号", typeof(int));
                dt.Columns.Add("创建时间", typeof(DateTime));
                dt.Columns.Add("创建人");
                dt.Columns.Add("药品名称");
                dt.Columns.Add("批号");
                dt.Columns.Add("规格");
                dt.Columns.Add("剂型");
                dt.Columns.Add("生产厂家");

                dt.Columns.Add("数量");
                dt.Columns.Add("单价", typeof(decimal));
                dt.Columns.Add("生产日期", typeof(DateTime));
                dt.Columns.Add("有效期至", typeof(DateTime));                
                dt.Columns.Add("总价", typeof(decimal));
                dt.Columns.Add("库区");
                dt.Columns.Add("销毁方式");
                dt.Columns.Add("销毁原因");
                dt.Columns.Add("销毁地点");
                dt.Columns.Add("销毁时间", typeof(DateTime));
                dt.Columns.Add("运输车辆");
                dt.Columns.Add("执行人");
                dt.Columns.Add("运输人");
                dt.Columns.Add("销毁后现象");
                dt.Columns.Add("药监部门意见");
                int i = 1;
                
                foreach (var r in result)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = i;
                    dr[1] = r.createTime;
                    var p=Users.Where(u=>u.CreateUserId==u.CreateUserId).FirstOrDefault();                    
                    dr[2] = p==null?"用户被人为删除！":p.Employee.Name;

                    var b = this.PharmacyDatabaseService.GetDrugsBreakage(r.DrugsUnqualicationID,out msg);
                    if (b == null)
                    {
                        MessageBox.Show("报损记录被认为删除！");
                        return false;
                    }

                    dr[3] = b.drugName;
                    dr[4] = b.batchNo;
                    dr[5] = b.Specific;
                    dr[6] = b.DosageType;
                    
                    dr[7] = b.FactoryName;
                    dr[8] = b.quantity;
                    dr[9] = b.PurchasePrice;
                    dr[10] = b.produceDate;
                    dr[11] = b.ExpireDate;
                    
                    dr[12] = r.price;
                    dr[13] = r.wareHouseZone;
                    dr[14] = r.DestroyMethod;
                    dr[15] = r.DestroyReason;
                    dr[16] = r.DestroyPlace;
                    dr[17] = r.DestroyTime;
                    dr[18] = r.DestroyCargo;
                    dr[19] = r.DestroyMan;
                    dr[20] = r.Destroyer;
                    dr[21] = r.DestroyState;
                    dr[22] = r.SupervisorOpinion;
                    i++;
                    this.toolStripProgressBar1.Value++;
                    System.Threading.Thread.Sleep(100);
                    dt.Rows.Add(dr);
                }
                MyExcelUtls.DataTable2Sheet(filename, dt);
                this.toolStripLabel7.Text = "导出完成";
                this.toolStripProgressBar1.Value = 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 打开保存审批详情
        /// </summary>
        private void OpenBreakageApprovalForm()
        {
            var row = this.dataGridView1.CurrentRow.DataBoundItem as DrugsUnqualificationDestroy;
            Guid unqualicationId = row.DrugsUnqualicationID;
            var c=this.PharmacyDatabaseService.GetDrugsBreakage(unqualicationId,out msg);
            Guid approvalFlowId =c.flowID;
            using (FormUnqualificationApprovalDetail f = new FormUnqualificationApprovalDetail())
            {
                

                var af = this.PharmacyDatabaseService.GetApproveFlowsByFlowID(out msg, approvalFlowId);
                UserControls.UcDrugBreakage ucf = new UserControls.UcDrugBreakage(c, af);
                f.Height += ucf.Height;
                f.Controls.Add(ucf);
                ucf.Dock = DockStyle.Fill;
                f.Text = "品种报损单:" + c.drugName;
                f.ShowDialog();
            }            
        }

        private void OpenUnqualicationApprovalForm()
        {
            var row = this.dataGridView1.CurrentRow.DataBoundItem as DrugsUnqualificationDestroy;
            Guid unqualicationId = row.DrugsUnqualicationID;
            var c=this.PharmacyDatabaseService.GetDrugsBreakage(unqualicationId,out msg);
            Guid unqId =c.DrugUnqualityId;
            using (FormUnqualificationApprovalDetail f = new FormUnqualificationApprovalDetail())
            {
                var q=this.PharmacyDatabaseService.GetDrugsUnqualificationByID(out msg,unqId);
                Guid approvalFlowId = q.flowID;
                Business.Models.drugsUnqualificationQuery dq = PharmacyDatabaseService.getDrugsUnqualificationQueryByFlowID(approvalFlowId, out msg);
                UserControls.ucDrugsUnqualification ucf = new UserControls.ucDrugsUnqualification(dq);
                f.Height += ucf.Height;
                f.Controls.Add(ucf);
                ucf.Dock = DockStyle.Fill;
                f.ShowDialog();                
            }
        }
    }
}
