using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseForm
{
    public partial class CRUDForm : BaseFunctionForm
    {
        public CRUDForm()
        {

            InitializeComponent();
            Initial();
        }

        public CRUDForm(params object[] args)
        {
            InitializeComponent();
            if (args != null && args.Length > 0)
            {
                Initial(args);
            }
            
        }

        private void Initial(object[] args=null)
        {
            if (!DesignMode)
            {
                try
                {
                    if (args != null && args.Length > 0)
                    {
                        string msg = string.Empty;
                        this.Text = EnumHelper<DataSoruceType>.GetDisplayValue(EnumHelper<DataSoruceType>.Parse(args[0].ToString()));
                        List<string> searchFields = new List<string>();
                        List<string> operationActions = new List<string>();
                        if (args.Length > 1)
                        {
                            List<string> searchConditions = args[1].ToString().Split('|').ToList();
                            if (searchConditions.Count > 0)
                            {
                                foreach (var s in searchConditions)
                                {
                                    searchFields.Add(s.ToString());
                                }
                            }
                            else
                            {
                                searchFields.Add("Name");
                            }
                           
                        }
                        else
                        {
                            searchFields.Add("Name");
                        }
                        if (args.Length > 2)
                        {
                            operationActions = args[2].ToString().Split('|').ToList();
                            foreach(var o in operationActions)
                            {
                                if (!(o == "Add" || o == "Edit" || o == "Search"))
                                {
                                    operationActions.Clear();
                                    break;
                                }
                            }
                        }
                        crudControl1.setpagecontrol();
                        crudControl1.EnabledActions = operationActions;
                        crudControl1.SearchFields = searchFields;
                        crudControl1.GridDataSourceType = EnumHelper<DataSoruceType>.Parse(args[0].ToString());
                        crudControl1.ButtonAddClick += OnButtonAddClick;
                        crudControl1.ButtonCloseClick += OnButtonCloseClick;
                    }
                    else
                    {
                        MessageBox.Show("请联系管理员,配置正确的菜单项");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        protected void OnButtonAddClick(object sender, EventArgs e)
        {

        }

        protected void OnButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
