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


namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugsUnqualification
{
    public partial class formDrugsUnqualificationSearch : BaseFunctionForm
    {
        DataTable dt = null;
        private bool flag;
        drugsUnqualication item = null;
        List<drugsUnqualication> list;
        double pageNum = 0.0;
        double pageSize=30.0;
        int recordCount = 0;
        drugsUnqualificationCondition dqc = new drugsUnqualificationCondition();
        FormUnqualificationApprovalDetail f;
        drugsUnqualificationQuery dq;
        List<drugsUnqualificationQuery> dqs;
        Dictionary<string,string> dic=new Dictionary<string,string>();
        public formDrugsUnqualificationSearch()
        {
            InitializeComponent();

            this.cmbUnqualificationType.SelectedIndex = 0;
            AutoCompleteStringCollection acNames = new AutoCompleteStringCollection();
            this.getStorageTable();

            var a = from d in dt.AsEnumerable() select d["drugName"];
            var q = a.Distinct();

            foreach (string s in q)
            {
                acNames.Add(s);
            }
            acNames.Insert(0, "全部");
            this.textBox1.AutoCompleteCustomSource = acNames;
            this.textBox1.DataSource = acNames;
            string msg = string.Empty;
            list = new List<drugsUnqualication>();
            cmbUnqualificationType.Items.Insert(0, "全部");
            DataTable adt=new DataTable();
            adt.Columns.Add("name");
            adt.Columns.Add("index");
            DataRow dr =adt.NewRow();
            //dr[0] = "全部";
            //dr[1] = 0;
            //adt.Rows.Add(dr);
            dr = adt.NewRow();
            dr[0]="待审";
            dr[1]=1;
            adt.Rows.Add(dr);
            dr = adt.NewRow();
            dr[0]="审核通过";
            dr[1]=2;
            adt.Rows.Add(dr);
            dr = adt.NewRow();
            dr[0]="审核未通过";
            dr[1]=4;
            adt.Rows.Add(dr);
            
            this.comboBox1.ComboBox.DataSource = adt;
            this.comboBox1.ComboBox.DisplayMember = "name";
            this.comboBox1.ComboBox.ValueMember = "index";
        }

        private DataTable getStorageTable()
        {           
            dt = new DataTable();
            dt.Columns.Add("drugName");
            dt.Columns.Add("batchNo");
            dt.Columns.Add("drugInventoryID");

            string outmsg = "";
            var drugsRecord = PharmacyDatabaseService.StorageQuery(out outmsg, "", "", "", new Guid[] { }, 0, 1000, new object[] { }).ToList();

            DataRow dr = null;
            foreach (InventeryModel ar in drugsRecord)
            {
                dr = dt.NewRow();
                dr["drugName"] = ar.ProductGeneralName;
                dr["batchNo"] = ar.BatchNumber;
                dr["drugInventoryID"] = ar.InventoryID;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataRow[] drs = null;
            drs= dt.Select("drugName='" + textBox1.Text+"'");
            var q= from d in drs.AsEnumerable() select d["batchNo"];
            this.cmbBatch.Text = string.Empty;
            this.cmbBatch.Items.Clear();
            this.cmbBatch.Items.Add("全部");
            foreach (string s in q)
            {
                this.cmbBatch.Items.Add(s);
            }
            if (this.cmbBatch.Items.Count > 0)
            {
                this.cmbBatch.SelectedIndex = 0;
            }
        }


        private void tsbtnCancel_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            dqc = new drugsUnqualificationCondition();
            dqc.batchNo = cmbBatch.Text.Trim() == "全部" || cmbBatch.Text.Trim() == string.Empty ? string.Empty : cmbBatch.Text.Trim();
            dqc.drugName = textBox1.Text.Trim()=="全部"||textBox1.Text.Trim()==string.Empty?string.Empty:textBox1.Text.Trim();
            dqc.unqualificationType = cmbUnqualificationType.SelectedIndex;
            dqc.dtFrom =checkBox1.Checked? this.dateTimePicker1.Value:DateTime.MinValue;
            dqc.dtTo = checkBox1.Checked ? this.dateTimePicker2.Value : DateTime.MaxValue;
            list = PharmacyDatabaseService.GetDrugsUnqualificationByCondition(out msg,dqc).ToList();
            var l = list.ToArray();
            var v = from i in l
                    select new drugsUnqualificationQuery
                    {
                        id = i.Id,
                        flowID = i.flowID,
                        drugName = i.drugName,
                        batchNo = i.batchNo,
                        createTime = i.createTime,
                        unqualificationType = (drugsUnqualificationType)i.unqualificationType,
                        quantity = i.quantity,
                        Description = "双击查看",
                        updateTime = i.updateTime,
                        IsApproval = i.ApprovalStatusValue == 2 ? "已审" : i.ApprovalStatusValue == 4 ? "审批未通过" : i.ApprovalStatusValue == 1 ? "待审" : "其他"
                    };
            recordCount = v.Count();
            dqs = v.ToList();
            loadData();
            
        }

        void dgvDrugDetailList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ) return;
            string msg = string.Empty;
            int rIdx = e.RowIndex;
            Guid itemId = new Guid(this.dgvDrugDetailList.Rows[rIdx].Cells["id"].Value.ToString());
            Guid approvalFlowId = new Guid(this.dgvDrugDetailList.Rows[rIdx].Cells["FlowId"].Value.ToString());
            item = PharmacyDatabaseService.GetDrugsUnqualificationByID(out msg, itemId);            
            f = new FormUnqualificationApprovalDetail();
            dq = PharmacyDatabaseService.getDrugsUnqualificationQueryByFlowID(approvalFlowId, out msg);
            UserControls.ucDrugsUnqualification ucf = new UserControls.ucDrugsUnqualification(dq);
            f.Height += ucf.Height;
            f.Controls.Add(ucf);
            ucf.Dock = DockStyle.Fill;
            f.ShowDialog();
            f = null;
            dq = null;
            ucf = null;
            flag = true;
        }
        
        
        private void formDrugsUnqualification_Load(object sender, EventArgs e)
        {
            //this.dgvDrugDetailList.AutoGenerateColumns = false;
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[0].Name,"ID");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[1].Name,"创建人");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[2].Name,"创建时间");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[3].Name,"更新时间");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[4].Name,"审核状态");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[5].Name,"ID");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[6].Name,"不合格描述");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[7].Name,"不合格类型");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[8].Name,"不合格数量");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[9].Name,"药品名称");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[10].Name,"批次号");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[11].Name,"当前库存");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[12].Name,"存放库区");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[13].Name, "存放仓库");
            //dic.Add(typeof(drugsUnqualificationQuery).GetProperties()[14].Name, "审核流程");
            //foreach (var i in dic)
            //{
            //    Console.WriteLine(i.Key+":"+i.Value);
            //}
            //foreach (var i in typeof(drugsUnqualificationQuery).GetProperties())
            //{
            //    if (i.Name == "Description")
            //    {
            //        DataGridViewButtonColumn dgbc = new DataGridViewButtonColumn();
            //        dgbc.HeaderText = dic[i.Name];
            //        this.dgvDrugDetailList.Columns.Add(dgbc);
            //    }
            //    else
            //    {
            //        DataGridViewColumn dgbc = new DataGridViewColumn();
            //        dgbc.HeaderText = dic[i.Name];
            //        this.dgvDrugDetailList.Columns.Add(dgbc);
            //    }
                
            //}
        }


        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.pageSize=Convert.ToInt16(this.toolStripTextBox1.Text);
            loadData();
        }


        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            //textBox1
        }

        private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (pageNum >= Math.Ceiling(Convert.ToDouble(recordCount) / pageSize)-1) return;
            pageNum++;
            loadData();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (pageNum <= 0) return;
            pageNum--;
            loadData();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            pageNum = Convert.ToDouble(toolStripButton5.Text) - 1;
            double p = Math.Ceiling(Convert.ToDouble(recordCount) / pageSize);
            if (pageNum < 0 || pageNum >= p)
            {
                return;
            }
            loadData();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)c).SelectedIndex = 0;                    
                }
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).Text = string.Empty;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePicker1.Enabled = this.dateTimePicker2.Enabled = this.checkBox1.Checked;
        }

        private void loadData()
        {
            if (dqs==null) return;
            var listq = dqs.Skip(Convert.ToInt16(pageSize * pageNum)).Take(Convert.ToInt16(pageSize));
            this.dgvDrugDetailList.DataSource = listq.ToList();

            this.dgvDrugDetailList.Columns[0].Visible = false;
            this.dgvDrugDetailList.Columns["id"].Visible = false;
            this.dgvDrugDetailList.Columns["FlowID"].Visible = false;
            this.dgvDrugDetailList.Columns["creater"].Visible = false;
            this.dgvDrugDetailList.Columns["warehouse"].Visible = false;
            this.dgvDrugDetailList.Columns["warehousezone"].Visible = false;
            this.dgvDrugDetailList.Columns["CurrentInventoryCount"].Visible = false;

            this.dgvDrugDetailList.Columns["createTime"].DefaultCellStyle.Format = "yy年MM月dd日 hh时mm分ss秒";
            this.dgvDrugDetailList.Columns["updateTime"].DefaultCellStyle.Format = "yy年MM月dd日 hh时mm分ss秒";
            DataGridViewColumn dc = dgvDrugDetailList.Columns["Description"];
            dc.HeaderText = "查看详细";
            
            this.toolStripLabel2.Text = "当前第" + (pageNum + 1).ToString() + "页，共计" + Math.Ceiling(recordCount / pageSize).ToString() + "页,共计" + recordCount.ToString() + "条数据";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list.Count<=0) return;
            var v = from i in list where i.ApprovalStatusValue==Convert.ToInt16(comboBox1.ComboBox.SelectedValue)
                    select new drugsUnqualificationQuery
                    {
                        id = i.Id,
                        flowID = i.flowID,
                        drugName = i.drugName,
                        batchNo = i.batchNo,
                        createTime = i.createTime,
                        unqualificationType = (drugsUnqualificationType)i.unqualificationType,
                        quantity = i.quantity,
                        Description = "双击查看",
                        updateTime = i.updateTime,
                        IsApproval = i.ApprovalStatusValue == 2 ? "已审" : i.ApprovalStatusValue == 4 ? "审批未通过" : i.ApprovalStatusValue == 1 ? "待审" : "其他"
                    };
            recordCount = v.Count();
            dqs = v.ToList();
            pageNum = 0;
            loadData();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
