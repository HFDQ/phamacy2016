﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormInstrumentsQuery :BaseFunctionForm
    {
        string msg = string.Empty;

        private PagerInfo pageInfo = new PagerInfo
        {
             Index=1,
              Size=50,
              RecordCount=0
        };

        #region 单元格风格
        DataGridViewCellStyle cellstyleY = new DataGridViewCellStyle
        {
            BackColor = Color.LightYellow
        };
        DataGridViewCellStyle cellstyleS = new DataGridViewCellStyle
        {
            BackColor = Color.LightSalmon
        };
        DataGridViewCellStyle cellstyleG = new DataGridViewCellStyle
        {
            BackColor = Color.LightGreen
        };

        DataGridViewCellStyle cellstyleR = new DataGridViewCellStyle
        {
            BackColor = Color.LightPink
        };
        #endregion


        public FormInstrumentsQuery()
        {
            InitializeComponent();

            #region 右键支持
            BaseForm.BasicInfoRightMenu cms = new BaseForm.BasicInfoRightMenu(this.dataGridView1);
            cms.InserMenu("查看医疗器械信息", delegate()
            {
                this.InstrumentDetailOpen(FormStatusEnum.Read);
            });
            cms.InserMenu("修改医疗器械信息", delegate()
            {
                this.InstrumentDetailOpen(FormStatusEnum.Edit);
            });
            cms.InserMenu("导出当前查询结果列表", delegate()
            {
                MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "医疗器械信息查询结果列表");
            });
            cms.InserMenu("导出当前器械审批表", delegate()
            {
                var u = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.InstrumentsModel;
                byte[] b = this.PharmacyDatabaseService.GetUpdateFiles("ApprovalFiles\\54C14EA2-7456-4A5B-BF39-C441F451C35B").FirstOrDefault().bytes;

                using (System.IO.FileStream fs = new System.IO.FileStream("File", System.IO.FileMode.OpenOrCreate))
                {
                    fs.Write(b, 0, b.Length);
                    fs.Close();
                    CreateWinWord cww = new CreateWinWord();
                    cww.Inst = u;
                    
                    if (cww.CreateWord(fs.Name, u.ProductGeneralName, 0))
                    {
                        MessageBox.Show(u.ProductGeneralName + "：审批信息表导出成功！");
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "导出首营医疗器械信息审批表成功！品种名称：" + u.ProductGeneralName);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "导出首营医疗器械信息审批表失败！品种名称：" + u.ProductGeneralName);
                    }
                    fs.Dispose();
                }
            });
            #endregion

            #region datagridview1事件
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowPostPaint += (sender, ex) => DataGridViewOperator.SetRowNumber((DataGridView)sender, ex);
            this.dataGridView1.CellMouseDoubleClick += (sender, e) =>
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
                if(e.Button==System.Windows.Forms.MouseButtons.Left)
                    this.InstrumentDetailOpen(FormStatusEnum.Read);
            };
            #endregion

            #region 文本框键盘事件
            this.textBox1.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
                {
                    this.InstrumentsQuery();
                }
            };
            #endregion

            #region 分页控件事件
            this.pagerControl1.DataPaging += pagerControl1_DataPaging;
            #endregion
        }

        void pagerControl1_DataPaging()
        {
            this.InstrumentsQuery();
        }

        /// <summary>
        /// 打开INSTRUMENT细节查看或者编辑
        /// </summary>
        /// <param name="fse"></param>
        private void InstrumentDetailOpen(FormStatusEnum fse)
        {
            if (this.dataGridView1.CurrentRow == null) return;
            var c=this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.InstrumentsModel;
            Models.DrugInfo entity = this.PharmacyDatabaseService.GetDrugInfo(out msg, c.Id);
            FormInstrument frm = new FormInstrument();
            frm.Text = entity.ProductGeneralName;
            frm.entity = entity;            
            frm.FSE = fse;
            if (fse == FormStatusEnum.Read)
                Common.SetControls.SetControlReadonly(frm, true);
            else
            {
                frm.InstrumentInfoSubmit += (sender, e) =>
                {
                    if (e)
                    {
                        this.InstrumentsQuery();
                    }
                };
            }
            frm.Show(this);
        }

        public void InstrumentsQuery()
        {
            var c = this.PharmacyDatabaseService.GetInstrumentsByCondition(this.textBox1.Text.Trim(), this.pagerControl1.PageIndex, this.pagerControl1.PageSize, out pageInfo, this.checkBox1.Checked);
            if (c == null) return;
            this.dataGridView1.DataSource = c.ToList();
            this.dataGridView1.Columns["Id"].Visible = false;

            foreach (DataGridViewRow r in this.dataGridView1.Rows)
            {                
                r.Cells["Valid"].Style =r.Cells["Valid"].Value.ToString().Contains("有效")? cellstyleY:cellstyleR;//是否有效列

                r.Cells["IsApproval"].Style = r.Cells["IsApproval"].Value.ToString().Contains("审批通过") ? cellstyleS : cellstyleR;//是否审批列

                r.Cells["Locked"].Style = r.Cells["Locked"].Value.ToString().Contains("未锁定") ? cellstyleG : cellstyleR;//是否认为锁定列
            }

            this.pagerControl1.PageIndex = this.pageInfo.Index;
            this.pagerControl1.RecordCount = this.pageInfo.RecordCount;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.InstrumentsQuery();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.InstrumentDetailOpen(FormStatusEnum.Edit);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1,"医疗器械信息查询结果列表");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.InstrumentDetailOpen(FormStatusEnum.Read);
        }
    }
}
