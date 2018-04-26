using BugsBox.Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugMaintain
{
    public partial class DrugMaintainRecord :BaseFunctionForm
    {
        string msg = string.Empty;
        public DrugMaintainRecord()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
        }

        private void DrugMaintenanceRecord_Load(object sender, EventArgs e)
        {
            StartDate.Value = DateTime.Now.AddMonths(-1);
            EndDate.Value = DateTime.Now;
            this.cmbCompleteState.SelectedIndex = 0;
            this.cmdDrugMaintainType.SelectedIndex = 0;

            dataGridView1.AutoGenerateColumns = false;
        }

        //保存
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        //查询
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            LoadData();  
        }

        private void LoadData()
        {
            string msg;
            int? CompleteState = null, DrugMaintainTypeValue = null;
            //完成状态
            if (cmbCompleteState.SelectedIndex == 1)
            {
                CompleteState = 1;
            }
            else if (cmbCompleteState.SelectedIndex == 2)
            {
                CompleteState = 0;
            }
            //类型
            if (cmdDrugMaintainType.SelectedIndex ==1)
            {
                DrugMaintainTypeValue = (int)DrugMaintainType.Normal;
            }
            else if (cmdDrugMaintainType.SelectedIndex == 2)
            {
                DrugMaintainTypeValue = (int)DrugMaintainType.Special;
            }
            else if (cmdDrugMaintainType.SelectedIndex == 3)
            {
                DrugMaintainTypeValue = (int)DrugMaintainType.Inst;
            }
            else if (cmdDrugMaintainType.SelectedIndex == 4)
            {
                DrugMaintainTypeValue = (int)DrugMaintainType.Zyyp;
            }
            else if (cmdDrugMaintainType.SelectedIndex == 5)
            {
                DrugMaintainTypeValue = (int)DrugMaintainType.Zyc;
            }
            else if (cmdDrugMaintainType.SelectedIndex == 6)
            {
                DrugMaintainTypeValue = (int)DrugMaintainType.BJSP;
            }

            List<BugsBox.Pharmacy.Models.DrugMaintainRecord> item = PharmacyDatabaseService.GetDrugMaintainRecordByCondition(out msg, StartDate.Value, EndDate.Value, CompleteState, DrugMaintainTypeValue).ToList();
            if (item == null) return;
            var all = item.OrderBy(r => r.CreateTime).ToList();
            var c = from i in all
                    select new MaintainInfo
                    {
                        BillDocumentNo = i.BillDocumentNo,
                        CompleteState = Convert.ToBoolean(i.CompleteState) ? "已完成" : "未完成",
                        ExpirationDate = i.ExpirationDate.ToLongDateString(),
                        CreateTime = i.CreateTime,
                        DrugMaintainType = i.DrugMaintainTypeValue == 0 ? "普通药品" : i.DrugMaintainTypeValue == 1 ? "重点养护药品":i.DrugMaintainTypeValue==2?"医疗器械":i.DrugMaintainTypeValue==3 ? "中药饮片":i.DrugMaintainTypeValue==4?"中药材":"保健食品",
                         DrugMaintainTypeValue=i.DrugMaintainTypeValue
                    };
            dataGridView1.DataSource = c.ToList();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0||e.ColumnIndex<0) return;
            if (!this.dataGridView1.CurrentCell.OwningColumn.Name.Contains(Column6.Name)) return;
            var MaintainRecord=this.dataGridView1.CurrentRow.DataBoundItem as MaintainInfo;

            DrugMaintainRecordDetails frm = new DrugMaintainRecordDetails();
            frm.documentNumber = MaintainRecord.BillDocumentNo;
            frm.maintainTypeValue = MaintainRecord.DrugMaintainTypeValue;
            
            if (this.dataGridView1.Rows[e.RowIndex].Cells[Column4.Name].Value.ToString().Contains("已完成"))
            {
                frm.isComplete = true;
            }

            frm.ShowDialog();
            if (frm.DialogResult != DialogResult.OK) return;
            
            this.LoadData();
        }

        /// <summary>
        /// 养护信息类型，用于绑定列表
        /// </summary>
        class MaintainInfo
        {
            /// <summary>
            /// 单号
            /// </summary>
            public string BillDocumentNo { get;set; }

            /// <summary>
            /// 完成状态
            /// </summary>
            public string CompleteState { get; set; }

            /// <summary>
            /// 过期日
            /// </summary>
            public string ExpirationDate { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime CreateTime { get; set; }


            /// <summary>
            /// 显示养护类型
            /// </summary>
            public string DrugMaintainType { get; set; }

            /// <summary>
            /// 养护类型值
            /// </summary>
            public int DrugMaintainTypeValue { get; set; }
        }
    }

}
