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
    public partial class FormSupplyUnit : BaseFunctionForm
    {
        private int progressValue = 0;
        private Thread th1, th2;
        private DataTable datatable, dtState;
        private int completeIndex = 0;//执行到的行数 
        /// <summary>
        /// datagridview中列的索引
        /// </summary>
        private enum DataGridColumn
        {
            /// <summary>
            /// 状态列
            /// </summary>
            StateIndex = 13,
            /// <summary>
            /// 导入信息列
            /// </summary>
            MessageIndex = 14
        }

        public FormSupplyUnit()
        {
            InitializeComponent();
        }


        private void FormSupplyUnit_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BuLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            progressBar1.Value = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //文件路径
                textBox1.Text = openFileDialog1.FileName;

                //获取Excel第一个sheet的数据，放到dt
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

                string result = "";
                if (!CheckColumn(ds.Tables[0], out result))
                {
                    MessageBox.Show(result, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                datatable = ds.Tables[0];

                dtState = new DataTable(); ;
                dtState.Columns.Add(new DataColumn("Index", typeof(string)));
                dtState.Columns.Add(new DataColumn("状态", typeof(string)));
                dtState.Columns.Add(new DataColumn("导入信息", typeof(string)));


                progressBar1.Maximum = ds.Tables[0].Rows.Count;
                BuShowData.Enabled = true;
            }
        }

        private void BuShowData_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = datatable;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[Convert.ToInt16(DataGridColumn.StateIndex)].Value = "准备好";
            }

            BuImport.Enabled = true;
        }

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


        ///导入数据库
        private void Import()
        {
            string result;

            int i = 0;
            foreach (DataRow reader in datatable.Rows)
            {
                try
                {

                    if (reader["传真"].ToString().Trim().Length == 0)
                    {
                        dtState.Rows.Add(i, "导入失败", "失败原因：'传真'不能为空");
                        continue;
                    }
                    if (reader["邮箱"].ToString().Trim().Length == 0)
                    {
                        dtState.Rows.Add(i, "导入失败", "失败原因：'邮箱'不能为空");
                        continue;
                    }
                    if (reader["网站"].ToString().Trim().Length == 0)
                    {
                        dtState.Rows.Add(i, "导入失败", "失败原因：'网站'不能为空");
                        continue;
                    }
                    Guid UnitTypeId;
                    UnitType item = PharmacyDatabaseService.QueryUnitTypes(out result, reader["企业类型"].ToString(), true, true, null, null).FirstOrDefault();
                    if (item != null)
                    {
                        UnitTypeId = item.Id;
                    }
                    else
                    {
                        dtState.Rows.Add(i, "导入失败", "失败原因：企业类型'" + reader["企业类型"].ToString() + "'不存在");
                        continue;
                    }

                    SupplyUnit info;

                    bool IsExist = PharmacyDatabaseService.IsExistSupplyUnitByName(out result, reader["单位名称"].ToString());
                    //更新
                    if (IsExist)
                    {
                        info = PharmacyDatabaseService.GetSupplyUnitByName(out result, reader["单位名称"].ToString());
                    }
                    else //新增
                    {
                        info = new SupplyUnit();
                        info.Id = Guid.NewGuid();
                        info.CreateTime = DateTime.Now;
                        info.CreateUserId = Guid.Empty;
                        info.Enabled = true;
                        info.Name = reader["单位名称"].ToString();
                    }

                    info.QualityAgreementOutdate = Convert.ToDateTime(reader["质量协议书有效期止"]);
                    info.AttorneyAattorneyOutdate = Convert.ToDateTime(reader["法人委托书有效期止"]);
                    info.SupplyProductClass = reader["拟供品种"].ToString();
                    info.QualityCharger = reader["质量负责人"].ToString();

                    info.BankAccountName = reader["开户户名"].ToString();
                    info.Bank = reader["银行"].ToString();
                    info.BankAccount = reader["银行帐号"].ToString();
                     
                    info.Code = reader["唯一编码"].ToString();
                    info.PinyinCode = reader["拼音码"].ToString();
                    info.ContactName = reader["联系人"].ToString();
                    info.ContactTel = reader["联系电话"].ToString();
                    info.Description = reader["说明"].ToString();
                    info.LegalPerson = reader["法人"].ToString();
                    info.BusinessScope = reader["生产经营范围"].ToString();
                    info.SalesAmount = reader["年销售额"].ToString();
                    info.Fax = reader["传真"].ToString();
                    info.Email = reader["邮箱"].ToString();
                    info.WebAddress = reader["网站"].ToString();
                    info.OutDate = Convert.ToDateTime(reader["过期日"]);
                    //info.GSPGMPLicCode = reader["GSMP证书号"].ToString();
                    //info.GSPGMPLicOutdate = Convert.ToDateTime(reader["GSP/GMP证书有效期止"]);
                    //info.BusinessLicCode = reader["营业执照编号"].ToString();
                    //info.BusinessLicOutdate = Convert.ToDateTime(reader["营业执照有效期止"]);
                    //info.PharmaceuticalTradingLicCode = reader["药品经营许可证号"].ToString();
                    //info.PharmaceuticalTradingLicOutdate = Convert.ToDateTime(reader["药品经营许可证有效期止"]);
                    info.TaxRegistrationCode = reader["税务登记号"].ToString();
                    info.LastAnnualDte = Convert.ToDateTime(reader["最新年检日期"]);
                    info.UnitTypeId = UnitTypeId;

                  
                     
                     
                    if (IsExist)
                    {
                        PharmacyDatabaseService.UpdateSupplyUnitByName(out result, reader["单位名称"].ToString(), info); 
                        dtState.Rows.Add(i, "更新成功", result);
                    }
                    else
                    {
                        PharmacyDatabaseService.AddSupplyUnit(out result, info);
                        dtState.Rows.Add(i, "导入成功", result);
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
                dataGridView1.Rows[index].Cells[Convert.ToInt16(DataGridColumn.StateIndex)].Value = row["状态"];
                dataGridView1.Rows[index].Cells[Convert.ToInt16(DataGridColumn.MessageIndex)].Value = row["导入信息"];

                completeIndex = index;

                if (index + 1 < datatable.Rows.Count)
                {
                    dataGridView1.Rows[index + 1].Cells[Convert.ToInt16(DataGridColumn.StateIndex)].Value = "正在导入";
                }
            }


            if (progressBar1.Maximum > 0 && progressBar1.Maximum <= progressBar1.Value && dtState.Rows.Count == datatable.Rows.Count)
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
        /// <param name="dt"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool CheckColumn(DataTable dt, out string result)
        {
            //if (!CheckOneColumn(dt, "质量协议书有效期止", out result))
            //{
            //    return false;
            //}
            //if (!CheckOneColumn(dt, "法人委托书有效期止", out result))
            //{
            //    return false;
            //}
            //if (!CheckOneColumn(dt, "拟供品种", out result))
            //{
            //    return false;
            //}
            //if (!CheckOneColumn(dt, "质量负责人", out result))
            //{
            //    return false;
            //}
            //if (!CheckOneColumn(dt, "开户户名", out result))
            //{
            //    return false;
            //}
            //if (!CheckOneColumn(dt, "银行", out result))
            //{
            //    return false;
            //}
            //if (!CheckOneColumn(dt, "银行帐号", out result))
            //{
            //    return false;
            //}

            if (!CheckOneColumn(dt, "传真", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dt, "邮箱", out result))
            {
                return false;
            }
            if (!CheckOneColumn(dt, "网站", out result))
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

        private bool CheckOneColumn(DataTable dt, string ColumnName, out string result)
        {
            if (dt.Columns[ColumnName] == null)
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

        private void FormSupplyUnit_FormClosing(object sender, FormClosingEventArgs e)
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

    }
}
