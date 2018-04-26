using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using System.Threading;
using System.Data.OleDb;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DataImport
{
   // public partial class FormDrugInfo : Form
    public partial class FormDrugInfo : BaseFunctionForm
    {
        private int progressValue = 0;
        private Thread th1, th2;
        private DataTable dtDrug, dtState; 
        private int completeIndex = 0;//执行到的行数
        public FormDrugInfo()
        {
            InitializeComponent();
        }


        private void FormDrugInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            progressBar1.Value = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //文件路径
                textBox1.Text = openFileDialog1.FileName;
                ////获取Excel第一个sheet的数据，放到dtDrug
                //string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                //               "Extended Properties=Excel 12.0 XML;" +
                //               "data source=" + textBox1.Text;
                //获取Excel第一个sheet的数据，放到dtDrug
                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                               "Extended Properties=Excel 8.0;" +
                               "data source=" + textBox1.Text;
                OleDbConnection OleConn = new OleDbConnection(strConn);
                string sheetName = GetFirstSheetNameFromExcelFileName(textBox1.Text, 0);
                String sql = "SELECT * FROM  [" + sheetName + "$] ";
                OleConn.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, OleConn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                string result ="";
                if (!CheckColumn(ds.Tables[0], out result))
                {
                    MessageBox.Show(result, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dtDrug = ds.Tables[0];

                dtState = new DataTable(); ;
                dtState.Columns.Add(new DataColumn("Index", typeof(string)));
                dtState.Columns.Add(new DataColumn("状态", typeof(string)));
                dtState.Columns.Add(new DataColumn("导入信息", typeof(string))); 


                progressBar1.Maximum = ds.Tables[0].Rows.Count;
                BuShowData.Enabled = true;
            }
        }
         
        /// <summary>
        /// 显示导入药物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuShowData_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtDrug;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[8].Value = "准备好";
            }

            BuImport.Enabled = true;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuImport_Click(object sender, EventArgs e)
        {
            BuLoad.Enabled = false;
            BuShowData.Enabled = false;
            BuImport.Enabled = false;


            th1 = new Thread(new ThreadStart(Import));
            th1.Start();
            th2 = new Thread(new ThreadStart(ChangeProgress));
            th2.Start();

        }

        /// <summary>
        /// 窗体退出时结束所有进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDrugInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (th1 != null && th1.ThreadState != ThreadState.Aborted)
            {
                th1.Abort();
            }
            if (th2 != null && th2.ThreadState != ThreadState.Aborted)
            {
                th2.Abort();
            }
        }
 

        ///导入数据库
        private void Import()
        {
            string result;

            int i = 0;
            foreach (DataRow reader in dtDrug.Rows)
            {
                try
                {
                    if (reader["药品本位码"].ToString().Trim().Length != 14)
                    {
                        dtState.Rows.Add(i, "导入失败", "失败原因：'药品本位码'必须为14位");
                        continue;
                    }
   
                    DrugInfo info = new DrugInfo();
                    info.Id = Guid.NewGuid();
                    info.Code = reader["编码"].ToString();
                    info.Description = reader["描述"].ToString();
                    info.BarCode = reader["条形码"].ToString();
                    info.StandardCode = reader["药品本位码"].ToString();
                    info.ProductName = reader["药品名称"].ToString();
                    info.ProductGeneralName = reader["药品通用名"].ToString();
                    info.ProductOtherName = reader["药品其他名称"].ToString();
                    info.FactoryName = reader["厂家全称"].ToString();
                    info.FactoryNameAbbreviation = reader["厂家简称"].ToString();
                    info.PiecemealSpecification = reader["拆零规格"].ToString();
                    info.PiecemealNumber = Convert.ToInt32(ConvertToDecimal(reader["拆零数量"]));
                    info.Price = ConvertToDecimal(reader["价格"]);
                    info.NationalSalePrice = ConvertToDecimal(reader["国家零售价"]);
                    info.PurchasePrice = ConvertToDecimal(reader["采购价"]);
                    info.SalePrice = ConvertToDecimal(reader["销售价"]);
                    info.WholeSalePrice = ConvertToDecimal(reader["批发价"]);
                    info.RetailPrice = ConvertToDecimal(reader["零售价"]);
                    info.TagPrice = ConvertToDecimal(reader["挂价"]);
                    info.LowSalePrice = ConvertToDecimal(reader["最低售价"]);
                    info.LimitedLowPrice = ConvertToDecimal(reader["最低限价"]);
                    info.LimitedUpPrice = ConvertToDecimal(reader["最高限价"]);

                    info.IsMedicalInsurance = Convert.ToBoolean(reader["是否医保"]);
                    info.IsPrescription = Convert.ToBoolean(reader["是否处方药"]);
                    info.IsImport = Convert.ToBoolean(reader["是否进口药"]);
                    info.IsMainMaintenance = Convert.ToBoolean(reader["是否重点养护"]);
                    info.IsSpecialDrugCategory = Convert.ToBoolean(reader["是否特殊管理药品"]);

                    info.SpecialDrugCategoryCode = reader["特殊管理药品类型"].ToString();
                    info.ValidPeriod = Convert.ToInt32(ConvertToDecimal(reader["有效期"]));
                    info.LicensePermissionNumber = reader["批准文号"].ToString();
                    info.PerformanceStandards = reader["执行标准"].ToString();
                    info.Package = reader["包装"].ToString();
                    info.IsApproval = true;
                    info.ApprovalDate = Convert.ToDateTime(reader["审批日期"]);

                    info.CreateTime = DateTime.Now;
                    info.CreateUserId = Guid.Empty;

                    info.BusinessScopeCode = reader["经营范围"].ToString();
                    info.PurchaseManageCategoryDetailCode = reader["药品管理分类详细"].ToString();
                    info.DrugCategoryCode = reader["药品分类"].ToString();
                    info.MedicalCategoryDetailCode = reader["医疗详细分类"].ToString();
                    info.DrugClinicalCategoryCode = reader["临床分类"].ToString();
                    info.DictionaryUserDefinedTypeCode = reader["自定义类型"].ToString();
                    info.DrugStorageTypeCode = reader["存储方式"].ToString();
                    info.DictionaryMeasurementUnitCode = reader["药品单位"].ToString();
                    info.DictionaryDosageCode = reader["剂型"].ToString();
                    info.DictionarySpecificationCode = reader["规格"].ToString();
                    info.DictionaryPiecemealUnitCode = reader["拆零单位"].ToString();

                    try
                    {
                        if (!PharmacyDatabaseService.IsExistDrugInfo(out result, info))
                        {
                            dtState.Rows.Add(i, "导入失败", "失败原因：" + result);
                        }
                        else
                        {
                            PharmacyDatabaseService.AddDrugInfo(out result, info);
                            dtState.Rows.Add(i, "导入成功", result);
                        }
                    }
                    catch(Exception e)
                    {
                        dtState.Rows.Add(i, "导入失败", "失败原因：" + e.Message);
                    }
                    
                }
                catch (Exception ex)
                {
                    dtState.Rows.Add(i, "导入失败", "失败原因：" + ex.Message);
                }
                finally
                {
                    progressValue++;
                    i++;
                }
            } 
        }


        #region  显示进度条
        public delegate void delChangeInfo();

        public void ChangeProgress()
        {
            while (true)
            {
                delChangeInfo ad = new delChangeInfo(ChangeProgressValue);
                this.BeginInvoke(ad);
                Thread.Sleep(100);
            }
        }

        private void ChangeProgressValue()
        {
            progressBar1.Value = progressValue;
             
            for (int j = completeIndex; j < dtState.Rows.Count; j++)
            {
                DataRow row = dtState.Rows[j];

                int index = Convert.ToInt32(row["index"]);
                dataGridView1.Rows[index].Cells[8].Value = row["状态"];
                dataGridView1.Rows[index].Cells[9].Value = row["导入信息"];
                
                completeIndex = index;

                if (index+1 < dtDrug.Rows.Count)
                {
                    dataGridView1.Rows[index + 1].Cells[8].Value = "正在导入"; 
                }
            }


            if (progressBar1.Maximum > 0 && progressBar1.Maximum <= progressBar1.Value && dtState.Rows.Count == dtDrug.Rows.Count)
            {
                th1.Abort();
                th2.Abort();
                //重置
                BuLoad.Enabled = true;

                progressValue = 0;
                completeIndex = 0;
                dtState = null;
            }
        }
        #endregion


        /// <summary>
        /// 检查Excel所需列是否都有
        /// </summary>
        /// <param name="dtDrug"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool CheckColumn(DataTable dtDrug, out string result)
        {
            if (!CheckOneColumn(dtDrug, "药品本位码", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dtDrug, "药品名称", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dtDrug, "药品通用名", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dtDrug, "厂家全称", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dtDrug, "厂家简称", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dtDrug, "批准文号", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dtDrug, "经营范围", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dtDrug, "药品分类", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dtDrug, "存储方式", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dtDrug, "药品单位", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dtDrug, "剂型", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dtDrug, "规格", out result))
            {
                return false;
            }

            result = "";
            return true;
        }


        #region 基础方法
        /// <summary>
        /// object装换成decimal，异常返回0
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private decimal ConvertToDecimal(object field)
        {
            decimal result = 0;

            if (field == null || field.ToString().Trim().Length == 0)
            {
                return result;
            }

            try
            {
                result = Convert.ToDecimal(field);
            }
            catch
            { }

            return result;
        }

        /// <summary>
        /// 获取Excel中第一个Sheet名称
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="numberSheetID"></param>
        /// <returns></returns>
        /// <example>
        /// string sheetName = GetFirstSheetNameFromExcelFileName(strFileUpLoadPath, 0);
        ///</example>
        public static string GetFirstSheetNameFromExcelFileName(string filepath, int numberSheetID)
        {
            if (!System.IO.File.Exists(filepath))
            {
                return "This file doesn't exist!";
            }
            if (numberSheetID <= 1) { numberSheetID = 1; }
            try
            {
                string strFirstSheetName = null;

                Microsoft.Office.Interop.Excel.Application obj = (Microsoft.Office.Interop.Excel.Application)
                    Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application", string.Empty);
                Microsoft.Office.Interop.Excel.Workbook objWB = obj.Workbooks.Open(filepath, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                strFirstSheetName = ((Microsoft.Office.Interop.Excel.Worksheet)objWB.Worksheets[1]).Name;

                objWB.Close(Type.Missing, Type.Missing, Type.Missing);
                objWB = null;
                obj.Quit();
                obj = null;
                return strFirstSheetName;
            }
            catch (Exception Err)
            {
                return Err.Message;
            }
        }
         
        private bool CheckOneColumn(DataTable dtDrug, string ColumnName, out string result)
        {
            if (dtDrug.Columns[ColumnName] == null)
            {
                result = "缺少'" + ColumnName + "'列";
                return false;
            }
            else
            {
                result = "";
                return true;
            }
        }
        #endregion


    }
}
