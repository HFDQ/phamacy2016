using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Data.OleDb;
using System.Collections;
using System.Configuration;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;
using CustomValidatorsLibrary;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.Common;
namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormEmployeeImport : BaseFunctionForm
    {
        public FormEmployeeImport()
        {
            InitializeComponent();
        }
        private List<Department> _ListDepartment = new List<Department>();
        private Dictionary<string, Guid> dicDepartment = new Dictionary<string, Guid>();
        private Dictionary<string, string> dicColumn = new Dictionary<string, string>();

        /// <summary>
        /// 浏览选择要导入的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                dialog.Filter = "Assemblies (*.xls)|*.xls;*.xlsx";
                DialogResult dr = dialog.ShowDialog();
                if (dr.ToString().ToUpper() == "OK") // if xml file selected, save file path to listbox.
                {
                    string fileName = dialog.FileName;
                    txtFilePath.Text = fileName;
                }
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///  导入并绑定到Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelColumnMapping();
                string fileName = txtFilePath.Text;
                if (!File.Exists(fileName))
                {
                    MessageBox.Show(string.Format("{0} not found!", fileName));
                    return;
                }

                if (Getexcelds(fileName, "Sheet1") != null)
                {
                    dataGridView1.DataSource = Getexcelds(fileName, "Sheet1"); //绑定到界面
                    dataGridView1.DataMember = "tablename";
                    progressBar1.Value = 100;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                Log.Error(ex);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="sheetname"></param>
        /// <returns></returns>
        private DataSet Getexcelds(string Path, String sheetname)//导入到dataset
        {
            bool IS_EXCEL_2007 = false;
            progressBar1.Value = 0;
            string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Path + "';Extended Properties='Excel 8.0;HDR=YES;IMEX=1'");//第一行作为列
            if (System.IO.Path.GetExtension(Path).ToUpper() == ".XLSX")
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
                IS_EXCEL_2007 = true;
            }

            OleDbConnection conn = new OleDbConnection(strConn);

            progressBar1.Value += 20;
            conn.Open();
            try
            {

                string strExcel = "select * from [" + sheetname + "]";
                if (sheetname.IndexOf('$') < 0)//if it have not $
                {
                    strExcel = "select * from[" + sheetname + "$]";
                }

                OleDbDataAdapter da = new OleDbDataAdapter(strExcel, strConn);

                DataSet ds = new DataSet();
                progressBar1.Value += 20;
                da.Fill(ds, "tablename");
                conn.Close();
                progressBar1.Value += 30;
                return ds;

            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message, "错误提示！"); return null;
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //判断是否被选中
                    Employee employee = new Employee();
                    var properties = employee.GetType().GetProperties();
                    employee.CreateTime = DateTime.Now;
                    employee.CreateUserId = AppClientContext.CurrentUser.Id;
                    employee.UpdateUserId = AppClientContext.CurrentUser.Id;
                    employee.UpdateTime = DateTime.Now;
                    foreach (var item in properties)
                    {
                        if (dicColumn.ContainsKey(item.Name))
                        {
                            string type = item.PropertyType.Name;
                            if (item.Name == "BirthDay" || item.Name == "WorkTime" || item.Name == "CardDate")
                            {
                                if (dataGridView1.Rows[i].Cells[dicColumn[item.Name]].Value != null)
                                {
                                    DateTime dt = new DateTime();
                                    bool isSuccess = DateTime.TryParse(dataGridView1.Rows[i].Cells[dicColumn[item.Name]].Value.ToString(), out dt);
                                    if (isSuccess)
                                        item.SetValue(employee, dt, null);
                                    else
                                    {
                                        MessageBox.Show(dicColumn[item.Name] + "时间格式转换失败！！！", "Error");
                                        return;
                                    }
                                }
                            }
                            else if (item.Name == "DepartmentId")
                            {
                                if (dataGridView1.Rows[i].Cells[dicColumn[item.Name]].Value != null)
                                {
                                    item.SetValue(employee, dicDepartment[dataGridView1.Rows[i].Cells[dicColumn[item.Name]].Value.ToString()], null);
                                }
                                else
                                {
                                    MessageBox.Show(dicColumn[item.Name] + "不能为空！！！", "Error");
                                    return;
                                }

                            }
                            else
                            {
                                if (item.Name == "Address" || item.Name == "EmployStatusValue" || item.Name == "PharmacistsTitleTypeValue" || item.Name == "PharmacistsTitleTypeValue")
                                {
                                    if (dataGridView1.Rows[i].Cells[dicColumn[item.Name]].Value == null)
                                    {
                                        MessageBox.Show(dicColumn[item.Name] + "不能为空！！！", "Error");
                                        return;                                     
                                    }
                                }
                                switch (type)
                                {
                                    case "String":
                                        if (dataGridView1.Rows[i].Cells[dicColumn[item.Name]].Value != null)
                                            item.SetValue(employee, dataGridView1.Rows[i].Cells[dicColumn[item.Name]].Value.ToString(), null);
                                        break;
                                    case "Int32":
                                        if (dataGridView1.Rows[i].Cells[dicColumn[item.Name]].Value != null)
                                            item.SetValue(employee, Convert.ToInt32(dataGridView1.Rows[i].Cells[dicColumn[item.Name]].Value.ToString()), null);
                                        break;

                                }
                            }
                        }
                    }
                    string msg = string.Empty;
                    PharmacyDatabaseService.AddEmployee(out msg, employee);
                    if (msg.Length > 0)
                    {
                        MessageBox.Show("员工录入保存失败！！！", "Error");
                        Log.Error(msg);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                Log.Error(ex);
            }
        }


        private void GetDepartment()
        {
            string msg = string.Empty;
            _ListDepartment = PharmacyDatabaseService.AllDepartments(out msg).ToList();
            foreach (Department bt in _ListDepartment)
            {
                dicDepartment.Add(bt.Code, bt.Id);
            }

        }

        private void FormEmployeeImport_Load(object sender, EventArgs e)
        {
            GetDepartment();
        }

        private void ExcelColumnMapping()
        {
            dicColumn.Clear();
            dicColumn.Add("Number", "员工号");
            dicColumn.Add("Address", "联系地址");
            dicColumn.Add("Name", "姓名");
            dicColumn.Add("Gender", "性别");
            dicColumn.Add("IdentityNo", "身份证");
            dicColumn.Add("Phone", "电话");
            dicColumn.Add("Email", "邮箱");
            dicColumn.Add("Rank", "级别");
            dicColumn.Add("Education", "学历");
            dicColumn.Add("Duty", "职责");
            dicColumn.Add("BirthDay", "生日");
            dicColumn.Add("WorkTime", "开始工作日");
            dicColumn.Add("Specility", "特点专长");
            dicColumn.Add("PharmacistsTitleTypeValue", "药师职称");
            dicColumn.Add("CardNo", "证书编号");
            dicColumn.Add("CardDate", "证书日期");
            dicColumn.Add("DepartmentId", "部门代码");
        }


    }
}
