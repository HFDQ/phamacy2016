using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.PS;
using CustomValidatorsLibrary;
using System.Reflection;
using BugsBox.Windows.Forms;
using BugsBox.Pharmacy.UI.Common.UserControls;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Windows.Forms.Input;
using BugsBox.Application.Core;
using BugsBox.Common.Security;
using BugsBox.Pharmacy.AppClient.UI;

namespace BugsBox.Pharmacy.UI.Common
{
    public partial class CRUDControl : BaseFunctionUserControl
    {
        private bool _isGeneated = false;
        private OperateType _TYPE = OperateType.Browse;
        private PagerInfo _pageInfo = new PagerInfo();
        private Dictionary<string, string> _headTexts = new Dictionary<string, string>();
        private TabPage _tabPageEdit = null;
        private TabPage _tabPageSearch = null;
        private const string _SEARCHPREFIX = "Search_";
        private List<BaseValidator> _allValidator = new List<BaseValidator>();
        private const string _COMMONPREFIX = "Common";
        private Dictionary<string, List<ListItem>> _InitFieldValues = new Dictionary<string, List<ListItem>>();
        private Button btnEdu = new Button();
        private Button btnPhyExam = new Button();

        private Guid _currentUser = Guid.Empty;
        private User listUser = null;
        private Role listR = null;
        private RoleWithUser listRU = null;
        string msg = string.Empty;

        public enum OperateType
        {
            Add,
            Edit,
            Browse,
            Search,
            Delete
        }
        public CRUDControl()
        {
            InitializeComponent();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
        }

        private void Initial()
        {
            _currentUser = AppClientContext.CurrentUser.Id;
            listUser = PharmacyDatabaseService.GetUser(out msg, _currentUser);
            listR = PharmacyDatabaseService.AllRoles(out msg).Where(p => p.Name == "SystemRole" || p.Name=="信息管理员").FirstOrDefault();
            listRU = PharmacyDatabaseService.GetRoleWithUserInfo(out msg, listUser.Id, listR.Id).FirstOrDefault();

            _tabPageEdit = tabPageEdit;
            _tabPageSearch = tabPageSearch;
            DisplayTabPage(false);
            if (EnabledActions.Count > 0)
            {
                if (!EnabledActions.Contains("Search"))
                {
                    btnCancel.Visible = false;
                    btnRefresh.Visible = false;
                    btnSearch.Visible = false;
                }


                if (!EnabledActions.Contains("Add"))
                {
                    btnAdd.Visible = false;
                }

                if (!EnabledActions.Contains("Edit"))
                {
                    btnModify.Visible = false;
                }

                if (!EnabledActions.Contains("Edit") && !EnabledActions.Contains("Add"))
                {
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                }
            }

            //用户修改自己密码
            if (listRU == null)
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnRefresh.Visible = false;
                btnSearch.Visible = false;
            }

            HeaderTexts = _headTexts;
            this.btnAdd.Click += new System.EventHandler(this.OnButtonAddClick);
            this.btnClose.Click += new System.EventHandler(this.OnButtonCloseClick);
        }

        private void Refresh(bool rebind = false)
        {
            if (rebind)
            {
                BindDataSourceType(GridDataSourceType);
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                InitFieldValues();
            }
            ValueControlsMap(null, true);
        }

        public void Operate(OperateType type = OperateType.Browse)
        {
            string msg = string.Empty;
            bool ignore = false;
            try
            {
                switch (type)
                {
                    case OperateType.Browse:
                        break;
                    case OperateType.Search:
                        Dictionary<string, object> bindSearchValues = ValueControlsMap(null, false, true);
                        Entity[] entities = SearchEnties(out msg, bindSearchValues, out _pageInfo);
                        this.pagerControl1.RecordCount = _pageInfo.RecordCount;
                        this.pagerControl1.PageIndex = _pageInfo.Index;
                        if (entities == null)
                        {
                            MessageBox.Show("查询失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(msg))
                            {
                                BindDataSourceType(GridDataSourceType, entities);
                            }
                        }
                        break;
                    case OperateType.Delete:
                        ignore = DeleteEntity(out msg);
                        break;
                    case OperateType.Edit:
                    case OperateType.Add:
                        Dictionary<string, object> bindValues = ValueControlsMap();
                        if (type == OperateType.Add)
                        {
                            bindValues.Add("CreateUserId", AppClientContext.CurrentUser.Id);
                            bindValues.Add("CreateTime", DateTime.Now);
                        }
                        else
                        {
                            bindValues.Add("UpdateUserId", AppClientContext.CurrentUser.Id);
                            bindValues.Add("UpdateTime", DateTime.Now);
                        }
                        AddEditEntity(bindValues, out msg);
                        break;
                }
                HandelMessage(msg, ignore);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetEditMode(bool isEdit)
        {
            tabPageEdit.Show();
            btnAdd.Enabled = !isEdit;
            btnDelete.Enabled = !isEdit;
            btnModify.Enabled = !isEdit;
            btnSearch.Enabled = !isEdit;
            btnSave.Enabled = isEdit;
            btnCancel.Enabled = isEdit;
            DisplayTabPage(isEdit);
            if (isEdit)
            {
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void ShowData(bool bindData)
        {
            if (!_isGeneated)
            {
                _tabPageEdit.Controls.Clear();
                Generate_Controls();
                //_isGeneated = true;
            }

            if (bindData && dataGridView1.CurrentRow != null)
            {
                ValueControlsMap(dataGridView1.CurrentRow);
            }
        }

        private void AddRequiredValidate(RichTextBox label, Control control, string headerText, List<string> requiredFields = null)
        {
            if (requiredFields == null || requiredFields.Contains(control.Name))
            {
                label.Text = label.Text.Replace(":", "") + "*:";
                label.Select(label.Text.Length - 2, 1);
                label.SelectionColor = Color.Red;
                RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
                requiredFieldValidator.ErrorMessage = String.Format("请输入{0}", headerText);
                requiredFieldValidator.ControlToValidate = control;
                _allValidator.Add(requiredFieldValidator);
            }
        }
        //新增操作
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _TYPE = OperateType.Add;
            Refresh();
            ShowData(false);
            SetEditMode(true);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            _TYPE = OperateType.Edit;
            if (dataGridView1.CurrentRow != null)
            {
                EditId = (Guid)dataGridView1.CurrentRow.Cells["Id"].Value;
                SetEditMode(true);
                ShowData(true);
            }
            else
                MessageBox.Show("没有选择要修改的记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _TYPE = OperateType.Search;
            SetEditMode(false);
            Operate(_TYPE);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg = String.Empty;
            //foreach (BaseValidator c in _allValidator)
            //{
            //    Console.WriteLine(c.ControlToValidate.Name);
            //}

            if (ValidateControls(out msg))
            {
                Operate(_TYPE);
            }
            else
            {
                MessageBox.Show(msg);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Refresh();
            SetEditMode(false);
        }

        //设置中文字段名
        private void SetHeadColumnNames()
        {
            if (HeaderTexts != null)
            {
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (HeaderTexts.ContainsKey(Utility.GetFieldName(GridDataSourceType) + "_" + col.Name))
                    {
                        col.HeaderText = HeaderTexts[Utility.GetFieldName(GridDataSourceType) + "_" + col.Name];
                    }
                    else if (HeaderTexts.ContainsKey(_COMMONPREFIX + "_" + col.Name))
                    {
                        col.HeaderText = HeaderTexts[_COMMONPREFIX + "_" + col.Name];
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _TYPE = OperateType.Delete;
            string msg = String.Empty;
            if (dataGridView1.CurrentRow != null)
            {
                EditId = (Guid)dataGridView1.CurrentRow.Cells["Id"].Value;
                //User users = this.PharmacyDatabaseService.GetUser(out msg, EditId);
                //RoleWithUser userRole= this.PharmacyDatabaseService.GetRoleWithUser(out msg, users.Id);
                //Role role = this.PharmacyDatabaseService.GetRole(out msg, userRole.RoleId);
                ////MessageBox.Show(role.Name.ToString());
                //if (role.Name == "SystemRole".Trim() )
                //{
                //    MessageBox.Show("该员工是系统管理员，删除请慎重！");
                //    return;
                //}
                //else
                    //Operate(_TYPE);
                Operate(_TYPE);
               
            }
            else
                MessageBox.Show("没有选择要删除的记录!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool ValidateControls(out string msg)
        {
            msg = String.Empty;
            foreach (BaseValidator v in _allValidator)
            { 
                Console.WriteLine(v.ControlToValidate.Name+"::"+v.IsValid);
                v.Validate();
               
                if (!v.IsValid)
                {
                    msg = v.ErrorMessage;
                    return false;
                }
            }
            return true;
        }

        private void HiddenFields(string fieldName)
        {
            if (fieldName.Split('_').Length == 2)
            {
                if (fieldName.Split('_')[0] == Utility.GetFieldName(GridDataSourceType))
                {
                    if (this.dataGridView1.Columns[fieldName.Split('_')[0]] != null)
                        this.dataGridView1.Columns[fieldName.Split('_')[0]].Visible = false;
                }
            }
            else
            {
                if (this.dataGridView1.Columns[fieldName] != null)
                    this.dataGridView1.Columns[fieldName].Visible = false;
            }
        }

        public Object getSerachFieldValue(Dictionary<string, object> searchConditions, string searchField)
        {
            if (searchConditions.ContainsKey(_SEARCHPREFIX + searchField))
                return searchConditions[_SEARCHPREFIX + searchField];
            else
                return "";
        }

        //定义字段中文显示
        private void FormatFieldCN()
        {
            Type type = typeof(ResourceStrings);
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo f in fields)
            {
                if (f.Name.Contains(_COMMONPREFIX) || f.Name.Contains(Utility.GetFieldName(GridDataSourceType)))
                {
                    if (!HeaderTexts.ContainsKey(f.Name))
                        HeaderTexts.Add(f.Name, f.GetValue(f.Name).ToString());
                }
            }
        }

        //格式化显示
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                FormatDisplay(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //绑定数据到实体
        private void BindDataToEntity(Object e, Dictionary<string, object> bindValues)
        {
            if (e is Entity)
            {
                ((Entity)e).Id = Guid.NewGuid();
            }
            var properties = e.GetType().GetProperties();
            foreach (var item in properties)
            {
                if (bindValues.ContainsKey(item.Name))
                {
                    if (item.Name == "Enabled")
                    {
                        if (bindValues[item.Name].ToString() == "True")
                        {
                            item.SetValue(e, true, null);
                        }
                        else if (bindValues[item.Name].ToString() == "False")
                        {
                            item.SetValue(e, false, null);
                        }
                    }
                    else
                    {
                        if (Utility.IsGUID(bindValues[item.Name].ToString()))
                        {
                            item.SetValue(e, new Guid(bindValues[item.Name].ToString()), null);
                        }
                        else if (bindValues[item.Name] is DateTime)
                        {
                            if (item.PropertyType == bindValues[item.Name].GetType())
                            {
                                item.SetValue(e, bindValues[item.Name], null);
                            }
                            else
                            {
                                item.SetValue(e, bindValues[item.Name] ?? null, null);
                            }
                        }
                        else
                            if (item.Name == "PurchaseTaxReturn" || item.Name == "SalesManageFee")
                            {

                                item.SetValue(e, bindValues[item.Name] == String.Empty ? 0m : Convert.ToDecimal(bindValues[item.Name]), null);
                            }
                            else
                            {
                                item.SetValue(e, Convert.ChangeType(bindValues[item.Name], item.PropertyType), null);
                            }
                    }
                }
            }
        }

        //隐藏或显示TabPage控件
        private void DisplayTabPage(bool displayEditPage)
        {
            tabControl1.TabPages.Clear();
            if (displayEditPage)
            {
                tabControl1.TabPages.Insert(0, _tabPageEdit);
            }
            else
            {
                tabControl1.TabPages.Insert(0, _tabPageSearch);
            }
        }

        /// <summary>
        /// 翻页显示
        /// </summary>
        private void pagerControl1_DataPaging()
        {
            //int pageSize = this.pagerControl1.PageSize;
            //int pageIndex = this.pagerControl1.PageIndex;

            this.Operate(OperateType.Search);
            
            switch (GridDataSourceType)
            {
                case DataSoruceType.DictionaryDosage:
                    ////DictionaryDosage[] dosage = this.PharmacyDatabaseService.QueryPagedDictionaryDosages(out _pageInfo, string.Empty, false, false, pageIndex, pageSize);
                    //DictionaryDosage[] dosage = this.PharmacyDatabaseService.QueryPagedDictionaryDosages(out _pageInfo
                    //    ,string.Empty
                    //    ,string.Empty
                    //    ,false
                    //    ,false 
                    //    , pageIndex, pageSize);//修复因DrugType表去除的错误
                    //this.dataGridView1.DataSource = dosage;
                    break;


            }
            //DictionaryDosage[] dosage = this.PharmacyDatabaseService.QueryPagedDictionaryDosages(out _pageInfo, string.Empty, false, false, pageIndex, pageSize);
            //this.dataGridView1.DataSource = dosage;
            //}
            //try
            //{
            //    BindDataSourceType(GridDataSourceType);
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(ex);
            //    MessageBox.Show("用户管理窗口查询翻页失败！", "系统错误");
            //}
        }

        //动态产生用户操作界面
        public void Generate_Controls(bool isSearch = false)
        {
            // top of textboxes
            int current_top = 10;
            int current_left = 80;

            int currentsearch_top = 20;
            int currentsearch_left = 10;

            // index used to match between each textbox and the properate column in grid
            int my_index = 14;

            int mysearch_index = 4;

            // iterate the grid and create textbox for each column
            int y = 0;
            _allValidator.Clear();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (FilterGenerateControl(col))
                    continue;

                // generate textboxes only for visible columns

                if (isSearch || col.Visible == true)
                {
                    my_index++;
                    // increase the top each time for space between textboxes
                    current_top += 30;

                    //// create a second column of textboxes (not all of them in 1 long column)
                    if (my_index % 14 == 0)
                    {
                        current_top = 40; current_left += 350;
                    }
                    Control c;
                    switch (col.ValueType.ToString())
                    {
                        case "System.String":
                            c = new CoolTextBox();
                            if (col.Name == "Pwd")
                            {
                                var cc = c as CoolTextBox;
                                cc.IsPwd = true;
                            }
                            if (_InitFieldValues.ContainsKey("Rareword"))
                            {
                                foreach (ListItem r in _InitFieldValues["Rareword"])
                                {
                                    ((CoolTextBox)c).Items.Add(new AutoCompleteEntry(r.Name, r.ID));
                                }
                            }
                            break;
                        case "System.Boolean":
                            c = new CheckBox();
                            if (col.Name == "Enabled")
                            {
                                ((CheckBox)c).Checked = true;
                            }
                            //WFZ
                            if (col.Name == "Year_exam")
                            {
                                ((CheckBox)c).Checked = true;
                            }
                            if (col.Name == "Pro_work_exam")
                            {
                                ((CheckBox)c).Checked = true;
                            }
                            break;
                        case "System.DateTime":
                        case "System.Nullable`1[System.DateTime]":
                            c = new DateTimePicker();
                            break;
                        case "System.Guid":
                            c = new ComboBox();
                            break;
                        default:
                            c = new CoolTextBox();
                            if (_InitFieldValues.ContainsKey("Rareword"))
                            {
                                foreach (ListItem r in _InitFieldValues["Rareword"])
                                {
                                    ((CoolTextBox)c).Items.Add(new AutoCompleteEntry(r.Name, r.ID));
                                }
                            }
                            //if (col.Name == "SalesManageFee" || col.Name == "PurchaseTaxReturn")
                            //{
                            //    (CoolTextBox)c.item = "0";
                            //}
                            break;
                    }

                    switch (col.Name)
                    {
                        case "Description":
                        case "Decription":
                            c = new RichTextBox();
                            ((RichTextBox)c).Height = 80;
                            c.Top = current_top;
                            current_top += 80;
                            break;
                        default:
                            c.Top = current_top;
                            break;

                    }
                    if (_InitFieldValues.ContainsKey(col.Name))
                    {
                        c = new ComboBox();
                        c.Top = current_top;
                    }
                    RichTextBox l = new RichTextBox();
                    l.ReadOnly = true;
                    l.Multiline = false;
                    l.Height = 12;

                    l.ScrollBars = RichTextBoxScrollBars.None;
                    l.BorderStyle = BorderStyle.None;
                    l.Text = col.HeaderCell.Value.ToString() + ":";
                    l.Top = current_top;
                    l.Left = current_left;

                    if (GridDataSourceType == DataSoruceType.SupplyUnit)
                    {
                        l.Width = 150;
                        c.Width = 130;
                    }
                    else
                    {
                        l.Width = 100;
                        c.Width = 180;
                    }

                    c.Left = current_left + l.Width;

                    c.Name = col.Name;


                    if (isSearch)
                    {
                        l.BackColor = Color.AliceBlue;
                        if (SearchFields.Contains(col.Name))
                        {
                            mysearch_index++;
                            if (mysearch_index % 4 == 0) { currentsearch_top += 30; currentsearch_left = 10; }
                            l.Top = currentsearch_top;
                            l.Left = currentsearch_left;
                            l.Width = 60;
                            switch (col.Name)
                            {
                                case "Enabled":
                                    c = new ComboBox();
                                    break;

                            }
                            c.Name = _SEARCHPREFIX + col.Name;
                            c.Left = currentsearch_left + l.Width;
                            c.Top = currentsearch_top;
                            if (GridDataSourceType == DataSoruceType.UserLog)
                            {
                                c.Width = 280;
                            }
                            else
                            {
                                c.Width = 180;
                            }

                            InitControlOptions(c, true);
                            if (!(c is CheckBox))
                            {
                                this.bugsBoxFocusColorProvider1.SetFocusBackColor(c, System.Drawing.Color.MediumBlue);
                                this.bugsBoxFocusColorProvider1.SetFocusForeColor(c, System.Drawing.Color.White);
                            }
                            searchGroupBox.Controls.Add(l);
                            searchGroupBox.Controls.Add(c);
                            currentsearch_left += l.Width + c.Width + 10;
                        }
                    }
                    else
                    {
                        c.TabIndex = 0;
                        l.TabIndex = 1;
                        l.BackColor = Color.White;
                        //处理验证
                        HandelValidation(l, c, col.HeaderCell.Value.ToString());
                        InitControlOptions(c);
                        if (!(c is CheckBox))
                        {
                            this.bugsBoxFocusColorProvider1.SetFocusBackColor(c, System.Drawing.Color.MediumBlue);
                            this.bugsBoxFocusColorProvider1.SetFocusForeColor(c, System.Drawing.Color.White);
                        }
                        tabPageEdit.Controls.Add(l);
                        tabPageEdit.Controls.Add(c);
                        y++;

                    }
                }
            }

            //修改自己密码

            if (GridDataSourceType == DataSoruceType.User && listRU == null)
            {
                foreach (Control c in _tabPageEdit.Controls)
                    if (!(c is CoolTextBox || c is RichTextBox))
                        c.Enabled = false;
            }

            //add按钮
            if (GridDataSourceType == DataSoruceType.User)
            {

                //    //btnEdu.Text = "参加培训情况";
                //    //btnPhyExam.Text = "参加体检情况";
                //    btnPhyExam.Width = 120;
                //    btnEdu.Width = 120;
                //    System.Drawing.Point p = new Point(250, 70 * 13 / 2);//
                //    btnEdu.Location = p;
                //    System.Drawing.Point p2 = new Point(450, 70 * 13 / 2);//
                //    btnPhyExam.Location = p2;
                //    tabPageEdit.Controls.Add(btnEdu);
                //    tabPageEdit.Controls.Add(btnPhyExam);

                //    btnEdu.Click += new System.EventHandler(btnEdu_click);//
                //    //btnPhyExam.Click += new System.EventHandler(btnPhyExam_click);//
            }

            if (isSearch)
            {
                if (GridDataSourceType == DataSoruceType.UserLog)
                {
                    FromToDateTime f = new FromToDateTime();
                    f.Left = 10;
                    f.Top = 15;
                    searchGroupBox.Controls.Add(f);
                    currentsearch_top += 20;
                }
                searchGroupBox.Height = currentsearch_top + 40;
            }
        }

        //根据DataGridViewRow设置控件值 或者 获取控件值 或者清空控件值
        public Dictionary<string, object> ValueControlsMap(DataGridViewRow dr = null, bool refresh = false, bool fromSearch = false)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            try
            {

                //获取查询模块控件值
                Control parentControl;
                if (fromSearch)
                {
                    parentControl = searchGroupBox;
                }
                else
                {
                    parentControl = tabPageEdit;
                }
                foreach (Control c in parentControl.Controls)
                {
                    if (!string.IsNullOrEmpty(c.Name))
                    {

                        if (refresh == true)
                        {
                            //清空控件值
                            switch (c.GetType().Name)
                            {
                                case "CoolTextBox":
                                    ((CoolTextBox)c).Text = "";
                                    break;
                                //case "CheckBox":
                                //    //((CheckBox)c).Checked = false;
                                //    break;
                                case "DateTimePicker":
                                    ((DateTimePicker)c).Format = DateTimePickerFormat.Custom;
                                    ((DateTimePicker)c).CustomFormat = "";
                                    break;
                                case "ComboBox":
                                    if (((ComboBox)c).Items.Count > 0)
                                        ((ComboBox)c).SelectedIndex = 0;
                                    break;
                                case "RichTextBox":
                                    ((RichTextBox)c).Text = "";
                                    break;
                            }
                        }
                        else if (dr == null)
                        {
                            //获取控件值
                            string name = fromSearch ? c.Name.Replace(_SEARCHPREFIX, "") : c.Name;
                            switch (c.GetType().Name)
                            {
                                case "CoolTextBox": 
                                    values.Add(name, ((CoolTextBox)c).Text); 
                                    break;
                                case "CheckBox":
                                    values.Add(name, ((CheckBox)c).Checked);
                                    break;
                                case "DateTimePicker":
                                    values.Add(name, ((DateTimePicker)c).Value);
                                    break;
                                case "ComboBox":
                                    if (((ComboBox)c).SelectedItem != null)
                                        values.Add(name, ((ListItem)((((ComboBox)c)).SelectedItem)).ID);
                                    break;
                                case "RichTextBox":
                                    values.Add(name, ((RichTextBox)c).Text);
                                    break;
                                case "FromToDateTime":
                                    values.Add(ResourceStrings.Common_StartTime, ((FromToDateTime)c).StartTime);
                                    values.Add(ResourceStrings.Common_EndTime, ((FromToDateTime)c).EndTime);
                                    break;
                            }
                        }
                        else if (dr.Cells[c.Name].Value != null)
                        {
                            //设置控件值
                            switch (c.GetType().Name)
                            {
                                case "CoolTextBox":
                                    //对密码解密
                                    var pwd = (CoolTextBox)c;
                                    if (pwd.IsPwd)
                                    {
                                        ((CoolTextBox)c).Text = EncodeHelper.Base64Decode((dr.DataBoundItem as User).Pwd);
                                    }
                                    else
                                    {
                                        ((CoolTextBox)c).Text = dr.Cells[c.Name].Value.ToString();
                                    }
                                    break;
                                case "CheckBox":
                                    ((CheckBox)c).Checked = (Boolean)dr.Cells[c.Name].Value;
                                    break;
                                case "DateTimePicker":
                                    ((DateTimePicker)c).Value = (DateTime)dr.Cells[c.Name].Value;
                                    break;
                                case "ComboBox":
                                     //((ComboBox)c).ValueMember = dr.Cells[c.Name].Value.ToString();
                                    ComboBox cb=(ComboBox)c;
                                    ListItem listItem=new ListItem();
                                    foreach( ListItem li in cb.Items ){
                                        if (li.Name == dr.Cells[c.Name].Value.ToString() || li.ID == dr.Cells[c.Name].Value.ToString())
                                        {
                                            listItem=li;
                                        }
                                    }                                    
                                    cb.SelectedItem=listItem;

                                    break;
                                case "RichTextBox":
                                    ((RichTextBox)c).Text = dr.Cells[c.Name].Value.ToString();
                                    break;
                            }
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("系统发生问题，请联系管理员");
            }
            return values;
        }

        //处理提示弹出信息
        public void HandelMessage(string msg, bool ignore = false)
        {
            if (!ignore)
            {
                if (string.IsNullOrEmpty(msg))
                {
                    if (_TYPE != OperateType.Search)
                    {
                        if (_TYPE == OperateType.Edit)
                        {
                            MessageBox.Show("数据修改成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (_TYPE == OperateType.Add)
                        {
                            MessageBox.Show("数据保存成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (_TYPE == OperateType.Delete)
                        {
                            MessageBox.Show("数据删除成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        Refresh(true);
                        SetEditMode(false);
                        //if (this.ParentForm != null)
                        //    this.ParentForm.Close();
                    }
                }
                else
                {
                    MessageBox.Show(msg);
                }
            }
        }

        private void HiddenOperations()
        {
            switch (GridDataSourceType)
            {
                  case DataSoruceType.UserLog:
            //    case DataSoruceType.DictionaryDosage:
            //    case DataSoruceType.DictionaryMeasurementUnit:
            //    case DataSoruceType.DictionaryPiecemealUnit:
            //    case DataSoruceType.DictionarySpecification:
            //    case DataSoruceType.DictionaryStorageType:
            //    case DataSoruceType.DrugCategory:
            //    case DataSoruceType.DrugType:
                    btnAdd.Visible = false;
                    btnModify.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
            //        toolStripSeparator1.Visible = false;
            //        toolStripSeparator2.Visible = false;
            //        toolStripSeparator3.Visible = false;
                    break;
            }
        }

        [Browsable(true), Description("选择按钮单击事件。"), Category("操作")]
        public event EventHandler ButtonAddClick; protected virtual void OnButtonAddClick(object sender, EventArgs e) { if (ButtonAddClick != null) ButtonAddClick(this, e); }

        [Browsable(true), Description("关闭单击事件。"), Category("操作")]
        public event EventHandler ButtonCloseClick; protected virtual void OnButtonCloseClick(object sender, EventArgs e) { if (ButtonCloseClick != null) ButtonCloseClick(this, e); }

        protected Dictionary<string, string> HeaderTexts
        {
            get;
            set;
        }

        private DataSoruceType _dataSourceType = DataSoruceType.Store;
        [Browsable(true), Description("DataGridView 数据源类型"), Category("自定义")]
        public DataSoruceType GridDataSourceType
        {

            get
            {
                return _dataSourceType;
            }
            set
            {
                Initial();
                _dataSourceType = value;
                label3.Text = EnumHelper<DataSoruceType>.GetDisplayValue(value);
                BindDataSourceType(value);
                //产生搜索操作界面
                Generate_Controls(true);
                HiddenOperations();
                if (EnabledActions.Count > 0)
                {
                    if (!EnabledActions.Contains("Search") && EnabledActions.Contains("Add"))
                    {
                        btnAdd_Click(null, null);
                        DisplayTabPage(true);
                    }
                }
            }
        }

        [Browsable(true), Description("定义搜索的字段"), Category("自定义")]
        public List<string> SearchFields
        {
            get;
            set;
        }

        [Browsable(true), Description("定义可操作的行为(Add,Edit,Search)"), Category("自定义")]
        public List<string> EnabledActions
        {
            get;
            set;
        }

        public Guid EditId
        {
            get;
            set;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindDataSourceType(GridDataSourceType);
            ValueControlsMap(null, true, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnEdu_click(object sender, System.EventArgs e)
        {
            //Button btnEdu = (Button)sender;//
            MessageBox.Show("增加培训信息");
        }
        //private void btnPhyExam_click(object sender, System.EventArgs e)
        //{
        //    Button btnPhyExam = (Button)sender;//
        //    MessageBox.Show("增加体检信息");
        //}

        public void setpagecontrol()
        {
            pagerControl1.Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "基础信息查询");
        }
    }
}
