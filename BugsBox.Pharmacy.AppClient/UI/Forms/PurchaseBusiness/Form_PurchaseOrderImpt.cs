using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class Form_PurchaseOrderImpt : BaseFunctionForm
    {
        string msg = string.Empty;

        List<Business.Models.PurchaseOrderImpt> ListDetails = new List<Business.Models.PurchaseOrderImpt>();

        List<Business.Models.PurchaseOrderImpt> ListDetailsWaitingImpt = new List<Business.Models.PurchaseOrderImpt>();

        public event PurchaseOrderImptEventHandler OnPurchaseOrderImpt;

        public Form_PurchaseOrderImpt()
        {
            InitializeComponent();

            #region 绑定类型
            var ordertypes = EnumToListHelper.ConverEnumToList(typeof(PurchaseDrugTypes)).Where(r => r.Name != "食品").ToList();

            this.toolStripComboBox1.ComboBox.DisplayMember = "Name";
            this.toolStripComboBox1.ComboBox.ValueMember = "Id";
            this.toolStripComboBox1.ComboBox.DataSource = ordertypes;
            #endregion

            #region DataGridView初始化
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView2, e);
            #endregion

            #region 右键菜单
            BugsBox.Pharmacy.UI.Common.BaseRightMenu brm = new BugsBox.Pharmacy.UI.Common.BaseRightMenu(this.dataGridView1);
            #endregion

            #region 清理表格数据
            Action ClearData = () =>
                {
                    this.ListDetails.Clear();
                    this.dataGridView1.DataSource = null;
                    this.ListDetailsWaitingImpt.Clear();
                    this.dataGridView2.DataSource = null;
                };
            #endregion

            #region 打开EXCEL文件
            this.toolStripButton1.Click += (s, e) =>
                {
                    OpenFileDialog ofd = new OpenFileDialog
                    {
                        Filter = "XLS文件|*.xls|XLSX文件|*.xlsx",
                    };

                    var re = ofd.ShowDialog();
                    if (re != System.Windows.Forms.DialogResult.OK) return;

                    FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook(fs);
                    int sheetCount = book.NumberOfSheets;

                    NPOI.SS.UserModel.ISheet sheet = book.GetSheetAt(0);
                    #region 简单验证一下excel表格
                    if (sheet == null)
                    {
                        MessageBox.Show("模板文件出错，请检查！"); return;
                    }

                    NPOI.SS.UserModel.IRow row = sheet.GetRow(0);
                    if (row == null)
                    {
                        MessageBox.Show("模板文件出错，请检查！"); return;
                    }

                    int firstCellNum = row.FirstCellNum;
                    int lastCellNum = row.LastCellNum;
                    if (firstCellNum == lastCellNum)
                    {
                        MessageBox.Show("模板文件出错，请检查！"); return;
                    }
                    #endregion

                    ClearData();
                    for (int i = 1; i < sheet.LastRowNum + 1; i++)
                    {
                        var sheetrow = sheet.GetRow(i);
                        Business.Models.PurchaseOrderImpt m = new Business.Models.PurchaseOrderImpt();
                        m.ProductGeneralName = sheet.GetRow(i).Cells[0].StringCellValue;
                        m.DosageName = sheet.GetRow(i).Cells[1].StringCellValue;
                        m.SpecificName = sheet.GetRow(i).Cells[2].StringCellValue;
                        m.MeasurementName = sheet.GetRow(i).Cells[3].StringCellValue;
                        m.FactoryName = sheet.GetRow(i).Cells[4].StringCellValue;
                        m.Origin = sheet.GetRow(i).Cells[5].StringCellValue;
                        m.Amount = decimal.Parse(sheet.GetRow(i).Cells[6].NumericCellValue.ToString());
                        m.UnitPrice = decimal.Parse(sheet.GetRow(i).Cells[7].NumericCellValue.ToString());
                        m.TaxRate = decimal.Parse(sheet.GetRow(i).Cells[8].NumericCellValue.ToString());

                        this.ListDetails.Add(m);
                    }
                    this.dataGridView1.DataSource = this.ListDetails;
                    this.dataGridView1.Columns["DruginfoId"].Visible = false;
                };

            #endregion

            #region 生成模板文件
            this.toolStripButton4.Click += (s, e) =>
            {
                DownlodExcel();
                MessageBox.Show("导出成功！");
            };
            #endregion

            #region 服务器端验证
            this.toolStripButton2.Click += (s, e) =>
            {
                if (this.dataGridView1.Rows.Count <= 0) return;

                var result = this.PharmacyDatabaseService.CheckForPurchaseOrderDetails(this.ListDetails, out msg).ToList();

                if (result.Any(r => r.DrugInfoId == Guid.Empty))
                {
                    MessageBox.Show("有一个或多个记录没有验证成功，请检查品名，剂型，规格等基本信息！您可以修改后再尝试验证！");
                }

                this.ListDetails = result.Where(r => r.DrugInfoId == Guid.Empty).ToList();
                this.dataGridView1.DataSource = ListDetails;

                this.ListDetailsWaitingImpt = result.Where(r => r.DrugInfoId != Guid.Empty).ToList();
                this.dataGridView2.DataSource = this.ListDetailsWaitingImpt;
                this.dataGridView2.Columns["DrugInfoId"].Visible = false;
                this.dataGridView2.Refresh();
            };
            #endregion

            #region 导入按钮click
            this.toolStripButton3.Click += (s, e) =>
                {
                    if (this.ListDetailsWaitingImpt.Count <= 0) return;

                    if (this.OnPurchaseOrderImpt != null)
                    {
                        PurchaseOrderImptEventArgs args = new PurchaseOrderImptEventArgs
                        {
                            ImptList = this.ListDetailsWaitingImpt
                        };
                        this.OnPurchaseOrderImpt(args);
                    }
                };
            #endregion
        }


        public void DownlodExcel()
        {
            SaveFileDialog sflg = new SaveFileDialog();
            sflg.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            sflg.FileName = "采购单细节导入模板表.xls";
            if (sflg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;

            NPOI.SS.UserModel.IWorkbook book = null;
            if (sflg.FilterIndex == 1)
            {
                book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            }

            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("采购细节表");

            // 添加表头
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);

            NPOI.SS.UserModel.ICell cell = row.CreateCell(0);
            cell.SetCellType(NPOI.SS.UserModel.CellType.String);
            cell.SetCellValue("品名");

            #region 医疗器械(这里不用)
            //if ((int)this.toolStripComboBox1.ComboBox.SelectedValue == (int)PurchaseDrugTypes.医疗器械)
            //{
            //    cell = row.CreateCell(1);
            //    cell.SetCellType(NPOI.SS.UserModel.CellType.STRING);
            //    cell.SetCellValue("型号");

            //    cell = row.CreateCell(2);
            //    cell.SetCellType(NPOI.SS.UserModel.CellType.STRING);
            //    cell.SetCellValue("规格");

            //    cell = row.CreateCell(3);
            //    cell.SetCellType(NPOI.SS.UserModel.CellType.STRING);
            //    cell.SetCellValue("单位");

            //    cell = row.CreateCell(4);
            //    cell.SetCellType(NPOI.SS.UserModel.CellType.STRING);
            //    cell.SetCellValue("生产厂家");

            //    cell = row.CreateCell(5);
            //    cell.SetCellType(NPOI.SS.UserModel.CellType.NUMERIC);
            //    cell.SetCellValue("数量");

            //    cell = row.CreateCell(6);
            //    cell.SetCellType(NPOI.SS.UserModel.CellType.NUMERIC);
            //    cell.SetCellValue("单价");

            //    cell = row.CreateCell(7);
            //    cell.SetCellType(NPOI.SS.UserModel.CellType.NUMERIC);
            //    cell.SetCellValue("税率(%)");
            //}
            //else 
            #endregion
            {
                cell = row.CreateCell(1);
                cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue("剂型");

                cell = row.CreateCell(2);
                cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue("规格");

                cell = row.CreateCell(3);
                cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue("单位");

                cell = row.CreateCell(4);
                cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue("生产厂家");

                cell = row.CreateCell(5);
                cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                cell.SetCellValue("产地");

                cell = row.CreateCell(6);
                cell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                cell.SetCellValue("数量");

                cell = row.CreateCell(7);
                cell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                cell.SetCellValue("单价");

                cell = row.CreateCell(8);
                cell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                cell.SetCellValue("税率(%)");
            }

            // 写入 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            book = null;

            using (FileStream fs = new FileStream(sflg.FileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Flush();
            }

            ms.Close();
            ms.Dispose();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }

    public delegate void PurchaseOrderImptEventHandler(PurchaseOrderImptEventArgs e);

    public class PurchaseOrderImptEventArgs : EventArgs
    {
        public List<Business.Models.PurchaseOrderImpt> ImptList { get; set; }
    }
}
