using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace BugsBox.Pharmacy.AppClient.UI.Forms
{
    /// <summary>
    /// 描述：對Excel文件的創建表、讀取、寫入數據操作.
    /// 程序員：谢堂文(Darren Xie)
    /// 創建日期：
    /// 版本：1.0
    /// </summary>
    public static class MyExcelUtls
    {
        #region 取文件的擴展名
        /// <summary>
        /// 取文件的擴展名
        /// </summary>
        /// <param name="FileName">文件名稱</param>
        /// <returns>string</returns>
        public static string GetExtFileTypeName(string FileName)
        {
            string sFile = FileName;// myFile.PostedFile.FileName;
            sFile = sFile.Substring(sFile.LastIndexOf("\\") + 1);
            sFile = sFile.Substring(sFile.LastIndexOf(".")).ToLower();
            return sFile;
        }
        #endregion

        #region 檢查一個文件是不是2007版本的Excel文件
        /// <summary>
        /// 檢查一個文件是不是2007版本的Excel文件
        /// </summary>
        /// <param name="FileName">文件名稱</param>
        /// <returns>bool</returns>
        public static bool IsExcel2007(string FileName)
        {
            bool r;
            switch (GetExtFileTypeName(FileName))
            {
                case ".xls":
                    r = false;
                    break;
                case ".xlsx":
                    r = true;
                    break;
                default:
                    throw new Exception("你要檢查" + FileName + "是2007版本的Excel文件還是之前版本的Excel文件，但是這個文件不是一個有效的Excel文件。");

            }
            return r;
        }

        #endregion

        #region Excel的連接串
        //Excel的連接串
        //2007和之前的版本是有區別的，但是新的可以讀取舊的

        /// <summary>
        /// Excel文件在服務器上的OLE連接字符串
        /// </summary>
        /// <param name="excelFile">Excel文件在服務器上的路徑</param>
        /// <param name="no_HDR">第一行不是標題：true;第一行是標題：false;</param>
        /// <returns>String</returns>
        public static String GetExcelConnectionString(string excelFile, bool no_HDR)
        {

            try
            {
                if (no_HDR)
                {
                    if (IsExcel2007(excelFile))
                    {
                        return "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + excelFile + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'"; //接可以操作.xls与.xlsx文件
                    }
                    else
                    {
                        return "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + excelFile + ";Extended Properties='Excel 8.0; HDR=NO; IMEX=1'"; //接只能操作Excel2007之前(.xls)文件

                    }
                }
                else
                {
                    return GetExcelConnectionString(excelFile);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// Excel文件在服務器上的OLE連接字符串
        /// </summary>
        /// <param name="excelFile">Excel文件在服務器上的路徑</param>
        /// <returns>String</returns>
        public static String GetExcelConnectionString(string excelFile)
        {
            try
            {
                if (IsExcel2007(excelFile))
                {
                    return "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + excelFile + ";Extended Properties='Excel 12.0;  IMEX=1'"; //此连接可以操作.xls与.xlsx文件
                }
                else
                {
                    return "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + excelFile + ";Extended Properties='Excel 8.0;  IMEX=1'"; //此连接只能操作Excel2007之前(.xls)文件

                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// Excel文件在服務器上的OLE連接字符串
        /// </summary>
        /// <param name="excelFile">Excel文件在服務器上的路徑</param>
        /// <returns>String</returns>
        public static String GetExcelConnectionStringByWrite(string excelFile)
        {
            try
            {
                if (IsExcel2007(excelFile))
                {
                    return "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + excelFile + ";Extended Properties='Excel 12.0;'"; //此连接可以操作.xlslsx文件
                }
                else
                {
                    return "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + excelFile + ";Extended Properties='Excel 8.0;'"; //此连接只能操作l2007之前(.xls)文件

                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        #endregion

        #region 讀取Excel中的所有表名
        //讀取Excel中的所有表名
        //读取Excel文件时，可能一个文件中会有多个Sheet，因此获取Sheet的名称是非常有用的

        /// <summary>
        /// 根据Excel物理路径获取Excel文件中所有表名,列名是TABLE_NAME
        /// </summary>
        /// <param name="excelFile">Excel物理路径</param>
        /// <returns>DataTable</returns>
        public static System.Data.DataTable GetExcelSheetNames2DataTable(string excelFile)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;

            try
            {
                string strConn = GetExcelConnectionString(excelFile);
                objConn = new OleDbConnection(strConn);
                objConn.Open();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }
                return dt;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        /// <summary>
        /// 根据Excel物理路径获取Excel文件中所有表名
        /// </summary>
        /// <param name="excelFile">Excel物理路径</param>
        /// <returns>String[]</returns>
        public static String[] GetExcelSheetNames(string excelFile)
        {
            System.Data.DataTable dt = null;

            try
            {

                dt = GetExcelSheetNames2DataTable(excelFile);
                if (dt == null)
                {
                    return null;
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                return excelSheets;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
        /// <summary>
        /// 根据Excel物理路径获取Excel文件中所有表名
        /// </summary>
        /// <param name="excelFile">Excel物理路径</param>
        /// <returns>String[]</returns>
        public static List<string> GetExcelSheetNames2List(string excelFile)
        {
            List<string> l = new List<string>();
            try
            {
                if (File.Exists(excelFile))//如果文件不存在，就不用檢查了，一定是0個表的
                {
                    string[] t = GetExcelSheetNames(excelFile);
                    foreach (string s in t)
                    {
                        string ss = s;
                        if (ss.LastIndexOf('$') > 0)
                        {
                            ss = ss.Substring(0, ss.Length - 1);
                        }
                        l.Add(ss);
                    }
                }
                return l;
            }
            catch (Exception ee)
            {
                throw ee;
            }

        }
        #endregion

        #region Sheet2DataTable
        /// <summary>
        /// 獲取Excel文件中指定SheetName的內容到DataTable
        /// </summary>
        /// <param name="FileFullPath">Excel物理路径</param>
        /// <param name="SheetName">SheetName</param>
        /// <param name="no_HDR">第一行不是標題：true;第一行是標題：false;</param>
        /// <returns>DataTable</returns>
        public static DataTable GetExcelToDataTableBySheet(string FileFullPath, string SheetName, bool no_HDR)
        {
            try
            {
                return GetExcelToDataSet(FileFullPath, no_HDR, SheetName).Tables[SheetName];
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 獲取Excel文件中指定SheetName的內容到DataTable
        /// </summary>
        /// <param name="FileFullPath">Excel物理路径</param>
        /// <param name="SheetName">SheetName</param>
        /// <returns>DataTable</returns>
        public static DataTable GetExcelToDataTableBySheet(string FileFullPath, string SheetName)
        {
            try
            {
                return GetExcelToDataTableBySheet(FileFullPath, SheetName, false);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        #endregion

        #region Excel2DataSet
        /// <summary>
        /// 獲取Excel文件中所有Sheet的內容到DataSet，以Sheet名做DataTable名
        /// </summary>
        /// <param name="FileFullPath">Excel物理路径</param>
        /// <param name="no_HDR">第一行不是標題：true;第一行是標題：false;</param>
        /// <returns>DataSet</returns>
        public static DataSet GetExcelToDataSet(string FileFullPath, bool no_HDR)
        {
            try
            {
                string strConn = GetExcelConnectionString(FileFullPath, no_HDR);
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                DataSet ds = new DataSet();
                foreach (string colName in GetExcelSheetNames(FileFullPath))
                {
                    OleDbDataAdapter odda = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", colName), conn);                    //("select *  [Sheet1$]", conn);
                    odda.Fill(ds, colName);
                }
                conn.Close();
                return ds;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 獲取Excel文件中指定Sheet的內容到DataSet，以Sheet名做DataTable名
        /// </summary>
        /// <param name="FileFullPath">Excel物理路径</param>
        /// <param name="no_HDR">第一行不是標題：true;第一行是標題：false;</param>
        /// <param name="SheetName">第一行不是標題：true;第一行是標題：false;</param>
        /// <returns>DataSet</returns>
        public static DataSet GetExcelToDataSet(string FileFullPath, bool no_HDR, string SheetName)
        {
            try
            {
                string strConn = GetExcelConnectionString(FileFullPath, no_HDR);
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                DataSet ds = new DataSet();
                OleDbDataAdapter odda = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", SheetName), conn);                    //("select * fromeet1$]", conn);
                odda.Fill(ds, SheetName);
                conn.Close();
                return ds;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        #endregion

        #region 刪除過時文件
        //刪除過時文件
        public static bool DeleteOldFile(string servepath)
        {
            try
            {
                FileInfo F = new FileInfo(servepath);
                F.Delete();
                return true;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message + "刪除" + servepath + "出錯.");
            }
        }
        #endregion

        #region 在Excel文件中創建表,Excel物理路径如果文件不是一個已存在的文件，會自動創建文件
        /// <summary>
        /// 在一個Excel文件中創建Sheet
        /// </summary>
        /// <param name="servepath">Excel物理路径,如果文件不是一個已存在的文件，會自動創建文件</param>
        /// <param name="sheetName">Sheet Name</param>
        /// <param name="cols">表頭列表</param>
        /// <returns>bool</returns>
        public static bool CreateSheet(string servepath, string sheetName, string[] cols)
        {
            try
            {
                if (sheetName.Trim() == "")
                {
                    throw new Exception("需要提供表名。");
                }

                if (cols.Equals(null))
                {
                    throw new Exception("創建表需要提供字段列表。");
                }

                using (OleDbConnection conn = new OleDbConnection(GetExcelConnectionStringByWrite(servepath)))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    if (sheetName.LastIndexOf('$') > 0)
                    {
                        sheetName = sheetName.Substring(sheetName.Length - 1);
                    }
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 3600;
                    StringBuilder sql = new StringBuilder();
                    sql.Append("CREATE TABLE [" + sheetName + "](");
                    foreach (string s in cols)
                    {
                        sql.Append("[" + s + "] text,");
                    }
                    sql = sql.Remove(sql.Length - 1, 1);
                    sql.Append(")");
                    cmd.CommandText = sql.ToString();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        #endregion

        #region DataTable2Sheet,把一個DataTable寫入Excel中的表,Excel物理路径,如果文件不是一個已存在的文件，會自動創建文件
        /// <summary>
        /// 把一個DataTable寫入到一個或多個Sheet中
        /// </summary>
        /// <param name="servepath">Excel物理路径,如果文件不是一個已存在的文件，會自動創建文件</param>
        /// <param name="dt">DataTable</param>
        /// <returns>bool</returns>
        public static bool DataTable2Sheet(string servepath, DataTable dt)
        {
            try
            {
                return DataTable2Sheet(servepath, dt, dt.TableName);
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        /// <summary>
        /// 把一個DataTable寫入到一個或多個Sheet中
        /// </summary>
        /// <param name="servepath">Excel物理路径,如果文件不是一個已存在的文件，會自動創建文件</param>
        /// <param name="dt">DataTable</param>
        /// <param name="maxrow">一個Sheet的行數</param>
        /// <returns>bool</returns>
        public static bool DataTable2Sheet(string servepath, DataTable dt, int maxrow)
        {
            try
            {
                return DataTable2Sheet(servepath, dt, dt.TableName, maxrow);
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        /// <summary>
        /// 把一個DataTable寫入到一個或多個Sheet中
        /// </summary>
        /// <param name="servepath">Excel物理路径,如果文件不是一個已存在的文件，會自動創建文件</param>
        /// <param name="dt">DataTable</param>
        /// <param name="sheetName">Sheet Name</param>
        /// <returns>bool</returns>
        public static bool DataTable2Sheet(string servepath, DataTable dt, string sheetName)
        {
            try
            {
                return DataTable2Sheet(servepath, dt, dt.TableName, 0);
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        /// <summary>
        /// 把一個DataTable寫入到一個或多個Sheet中
        /// </summary>
        /// <param name="servepath">Excel物理路径,如果文件不是一個已存在的文件，會自動創建文件</param>
        /// <param name="dt">DataTable</param>
        /// <param name="sheetName">Sheet Name</param>
        /// <param name="maxrow">一個Sheet的行數</param>
        /// <returns>bool</returns>
        public static bool DataTable2Sheet(string servepath, DataTable dt, string sheetName, int maxrow)
        {
            try
            {
                if (sheetName.Trim() == "")
                {
                    throw new Exception("需要提供表名。");
                }
                StringBuilder strSQL = new StringBuilder();
                //看看目標表是否已存在
                List<string> tables = GetExcelSheetNames2List(servepath);
                if (tables.Contains(sheetName))
                {
                    //存在,直接寫入
                    using (OleDbConnection conn = new OleDbConnection(GetExcelConnectionStringByWrite(servepath)))
                    {
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = conn;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            StringBuilder strfield = new StringBuilder();
                            StringBuilder strvalue = new StringBuilder();
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                strfield.Append("[" + dt.Columns[j].ColumnName + "]");
                                strvalue.Append("'" + dt.Rows[i][j].ToString() + "'");
                                if (j != dt.Columns.Count - 1)
                                {
                                    strfield.Append(",");
                                    strvalue.Append(",");
                                }
                            }
                            if (maxrow == 0)//不需要限制一個表的行數
                            {
                                cmd.CommandText = strSQL.Append(" insert into [" + sheetName + "]( ")
                                .Append(strfield.ToString()).Append(") values (").Append(strvalue).Append(")").ToString();
                            }
                            else
                            {
                                //加1才可才防止i=0的情況只寫入一行
                                string sheetNameT = sheetName + ((i + 1) / maxrow + (Math.IEEERemainder(i + 1, maxrow) == 0 ? 0 : 1)).ToString();
                                if (!tables.Contains(sheetNameT))
                                {
                                    tables = GetExcelSheetNames2List(servepath);
                                    string[] cols = new string[dt.Columns.Count];
                                    for (int ii = 0; ii < dt.Columns.Count; ii++)
                                    {
                                        cols[ii] = dt.Columns[ii].ColumnName;
                                    }
                                    if (!(CreateSheet(servepath, sheetNameT, cols)))
                                    {
                                        throw new Exception("在" + servepath + "上創建表" + sheetName + "失敗.");
                                    }
                                    else
                                    {
                                        tables = GetExcelSheetNames2List(servepath);
                                    }
                                }
                                cmd.CommandText = strSQL.Append(" insert into [" + sheetNameT + "]( ")
                                .Append(strfield.ToString()).Append(") values (").Append(strvalue).Append(")").ToString();

                            }
                            cmd.ExecuteNonQuery();
                            strSQL.Remove(0, strSQL.Length);
                        }
                        conn.Close();
                    }
                }
                else
                {
                    //不存在,需要先創建
                    using (OleDbConnection conn = new OleDbConnection(GetExcelConnectionStringByWrite(servepath)))
                    {
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = conn;
                        //創建表
                        string[] cols = new string[dt.Columns.Count];
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            cols[i] = dt.Columns[i].ColumnName;
                        }

                        //產生寫數據的語句
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            StringBuilder strfield = new StringBuilder();
                            StringBuilder strvalue = new StringBuilder();
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                strfield.Append("[" + dt.Columns[j].ColumnName + "]");
                                strvalue.Append("'" + dt.Rows[i][j] + "'");
                                if (j != dt.Columns.Count - 1)
                                {
                                    strfield.Append(",");
                                    strvalue.Append(",");
                                }
                            }
                            if (maxrow == 0)//不需要限制一個表的行數
                            {
                                if (!tables.Contains(sheetName))
                                {
                                    if (!(CreateSheet(servepath, sheetName, cols)))
                                    {
                                        throw new Exception("在" + servepath + "上創建表" + sheetName + "失敗.");
                                    }
                                    else
                                    {
                                        tables = GetExcelSheetNames2List(servepath);
                                    }
                                }
                                cmd.CommandText = strSQL.Append(" insert into [" + sheetName + "]( ")
                                .Append(strfield.ToString()).Append(") values (").Append(strvalue).Append(")").ToString();
                            }
                            else
                            {
                                //加1才可才防止i=0的情況只寫入一行
                                string sheetNameT = sheetName + ((i + 1) / maxrow + (Math.IEEERemainder(i + 1, maxrow) == 0 ? 0 : 1)).ToString();

                                if (!tables.Contains(sheetNameT))
                                {
                                    for (int ii = 0; ii < dt.Columns.Count; ii++)
                                    {
                                        cols[ii] = dt.Columns[ii].ColumnName;
                                    }
                                    if (!(CreateSheet(servepath, sheetNameT, cols)))
                                    {
                                        throw new Exception("在" + servepath + "上創建表" + sheetName + "失敗.");
                                    }
                                    else
                                    {
                                        tables = GetExcelSheetNames2List(servepath);
                                    }
                                }
                                cmd.CommandText = strSQL.Append(" insert into [" + sheetNameT + "]( ")
                                .Append(strfield.ToString()).Append(") values (").Append(strvalue).Append(")").ToString();

                                //
                            }
                            cmd.ExecuteNonQuery();
                            strSQL.Remove(0, strSQL.Length);
                        }
                        conn.Close();
                    }
                }
                return true;
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        #endregion
        public static bool DataGridview2Sheet(System.Windows.Forms.DataGridView dataGridView1, string tableName)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook wb = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet c = wb.CreateSheet(tableName);

            List<DataGridViewColumn> ListColumns = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn i in dataGridView1.Columns)
            {
                if (i.Visible == true)
                    ListColumns.Add(i);
            }
            ListColumns = ListColumns.OrderBy(r => r.DisplayIndex).ToList();

            if (dataGridView1.Rows.Count <= 0) return false;

            foreach (DataGridViewColumn dc in ListColumns)
            {
                if (dc.Visible == false) continue;
                if (dc.ValueType == typeof(int) || dc.ValueType == typeof(decimal) || dc.ValueType == typeof(double))
                    c.SetColumnWidth(dc.Index, 10 * 256);
                else
                {
                    c.SetColumnWidth(dc.Index, 20 * 256);
                }
            }


            #region 表头
            NPOI.SS.UserModel.IRow RowHeader = c.CreateRow(0);
            var FirstCell = RowHeader.CreateCell(0);
            FirstCell.SetCellValue(BugsBox.Pharmacy.AppClient.Common.AppClientContext.Config.Store.Name + tableName);
            NPOI.SS.UserModel.ICellStyle cellstyleHeader = wb.CreateCellStyle();
            cellstyleHeader.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellstyleHeader.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellstyleHeader.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            cellstyleHeader.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;

            NPOI.SS.UserModel.IFont CellFontHeader = wb.CreateFont();
            CellFontHeader.FontName = "微软雅黑";
            CellFontHeader.FontHeightInPoints = 16;
            cellstyleHeader.SetFont(CellFontHeader);
            cellstyleHeader.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            FirstCell.CellStyle = cellstyleHeader;

            c.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, ListColumns.Count - 1));
            #endregion

            #region 标题行 居中并且有框线
            NPOI.SS.UserModel.ICellStyle CellStyleTitles = wb.CreateCellStyle();
            CellStyleTitles.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            CellStyleTitles.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            CellStyleTitles.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            CellStyleTitles.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            CellStyleTitles.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            NPOI.SS.UserModel.IRow RowTitle = c.CreateRow(1);
            int cindex = 0;
            foreach (DataGridViewColumn hc in ListColumns)
            {
                if (!hc.Visible) continue;
                NPOI.SS.UserModel.ICell cell = RowTitle.CreateCell(cindex);
                cindex++;
                cell.CellStyle = CellStyleTitles;
                if (!string.IsNullOrEmpty(hc.HeaderText))
                    cell.SetCellValue(hc.HeaderText);
            }
            #endregion

            #region 列表 有框线,默认左对齐
            NPOI.SS.UserModel.ICellStyle CellStyleLeftAlignmentCell = wb.CreateCellStyle();
            CellStyleLeftAlignmentCell.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            CellStyleLeftAlignmentCell.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            CellStyleLeftAlignmentCell.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            CellStyleLeftAlignmentCell.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;



            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                NPOI.SS.UserModel.IRow row = c.CreateRow(i.Index + 2);
                cindex = 0;
                foreach (var u in ListColumns)
                {
                    var col = dataGridView1.Rows[i.Index].Cells[u.Index];
                    if (!col.Visible) continue;
                    NPOI.SS.UserModel.ICell xcell = row.CreateCell(cindex);
                    cindex++;

                    //设置居中对齐，如果是string则左对齐
                    if (col.ValueType == typeof(string) || col.ValueType == typeof(Guid))
                    {
                        xcell.CellStyle = CellStyleLeftAlignmentCell;//默认左对齐的风格
                    }
                    else
                    {
                        xcell.CellStyle = CellStyleTitles;//默认居中对齐的风格，与标题栏一致
                    }

                    if (col.Value == null) continue;
                    if (col.ValueType == typeof(string))
                    {
                        xcell.SetCellValue(col.Value.ToString());
                    }
                    else if (col.ValueType == typeof(decimal?) || col.ValueType == typeof(int?) || col.ValueType == typeof(double?) || col.ValueType == typeof(decimal) || col.ValueType == typeof(int) || col.ValueType == typeof(double))
                    {
                        xcell.SetCellValue(double.Parse(col.Value.ToString()));
                    }
                    else
                    {
                        xcell.SetCellValue(col.Value.ToString());
                    }
                }
            }
            #endregion

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel电子表格|*.xls";
                sfd.FileName = tableName + DateTime.Now.Ticks.ToString();
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.FileStream fs = System.IO.File.OpenWrite(sfd.FileName))
                        {
                            wb.Write(fs);
                            MessageBox.Show("导出成功！");
                        }
                    }
                    catch (System.IO.IOException ex)
                    {
                        MessageBox.Show("导出失败！\n" + ex.Message);
                        return false;
                    }
                }
            }
            return true;
        }

    }
}