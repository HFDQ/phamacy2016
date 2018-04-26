using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.UI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class Form_OutInventoryCheck : BaseFunctionForm
    {
        string msg = string.Empty;
        DrugOutInventoryCheckQueryModel q = new DrugOutInventoryCheckQueryModel
        {
              DTF=DateTime.Now.Date,
              DTT=DateTime.Now.Date
        };
        
        public Form_OutInventoryCheck()
        {
            InitializeComponent();

            #region 表格初始化和右键
            this.dataGridView1.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ReadOnly = true;


            BaseRightMenu brm = new BaseRightMenu(this.dataGridView1);
            #endregion

            #region 控件事件
            this.toolStripButton1.Click += (s, e) => GetData();

            this.button1.Click += (s, e) => GetData();

            this.toolStripButton2.Click += (s, e) =>
            {
                MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "出库复核查询结果");
            };

            this.button2.Click += (s, e) =>
            {
                this.q = new DrugOutInventoryCheckQueryModel
                {
                    DTF = DateTime.Now.Date,
                    DTT = DateTime.Now.Date
                };
                this.drugOutInventoryCheckQueryModelBindingSource.Clear();
                this.drugOutInventoryCheckQueryModelBindingSource.Add(this.q);
            };
            #endregion

            #region 绑定
            this.drugOutInventoryCheckQueryModelBindingSource.Add(this.q); 
            #endregion
        }

        /// <summary>
        /// 获取查询结果数据列表
        /// </summary>
        private void GetData()
        {
            this.Validate();
            this.q.DTT = this.q.DTT.AddDays(1);
            var re = this.PharmacyDatabaseService.GetDrugOutInventoryChecksByQueryModel(q, out msg).ToList();

            this.dataGridView1.DataSource = re;

            this.q.DTT = this.q.DTT.AddDays(-1);

            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["DrugInfoId"].Visible = false;
            this.dataGridView1.Columns["IsSpecial"].Visible = false;
            this.dataGridView1.Columns["SaleDate"].Visible = false;
            this.dataGridView1.Columns["FirstCheckTime"].Visible = false;
            this.dataGridView1.Columns["SecondCheckTime"].Visible = false;
        }
    }
}
