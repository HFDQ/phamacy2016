using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormSupplyUnitSalesmanEdit : BaseFunctionForm
    {
        public FormSupplyUnitSalesmanEdit(FormRunMode runMode, SupplyUnitSalesman entity)
        {
            InitializeComponent();
            if (runMode != FormRunMode.Add && entity == null)
            {
                throw new ArgumentNullException("该模式下实体对象不可以为空");
            }
            this.RunMode = runMode;
            this.Entity = entity;
        }

        public FormSupplyUnitSalesmanEdit()
            : this(FormRunMode.Add, null)
        {
        }

        public FormRunMode RunMode { get; private set; }
        public SupplyUnitSalesman Entity { get; private set; }
        private List<SupplyUnit> SupplyUnits { get; set; }
        private List<ListItem> Genders { get; set; }
        private List<District> Districts { get; set; }
        public GSPLicense GSPLicense { get; private set; }
        private List<GSPLicense> GSPLicenses = null;
        private List<GMSPLicenseBusinessScope> GMSPLicenseBusinessScopes = null;
        private void InitData()
        {
            try
            {
                string message;
                SupplyUnits = PharmacyDatabaseService.AllSupplyUnits(out message)
                    .ToList();
                switch (RunMode)
                {
                    case FormRunMode.Add:
                        Entity = new SupplyUnitSalesman();
                        Entity.Birthday = TypesDefaultValues.MinDateTime;
                        Entity.BusinessScopes = string.Empty;
                        Entity.CreateTime = DateTime.Now;
                        Entity.CreateUserId = AppClientContext.CurrentUser.Id;
                        Entity.Deleted = false;
                        Entity.Enabled = true;
                        Entity.Gender = "男";
                        Entity.IsOutDate = false;
                        Entity.OutDate = TypesDefaultValues.MaxDateTime;
                        Entity.UpdateTime = DateTime.Now;
                        Entity.UpdateUserId = AppClientContext.CurrentUser.Id;
                        //string message;
                        //GSPLicense = PharmacyDatabaseService.GetGSPLicense(out message, gMSPLicenseId);
                        //if (GMSPLicenseBusinessScopes == null)
                        //{
                        //    GMSPLicenseBusinessScopes = thisAllBusinessScopes(out message);
                        //}
                        break;
                    case FormRunMode.Edit:
                        break;
                    case FormRunMode.Browse:
                        break;
                    case FormRunMode.Search:
                        break;
                    case FormRunMode.Delete:
                        break;
                    default:
                        break;
                }

                //初始化字典数据
                SupplyUnits.Insert(0, new SupplyUnit { Id = Guid.Empty, Name = "请您选择..." });
                Districts = PharmacyDatabaseService.AllDistricts(out message).ToList();
                Districts.Insert(0, new District { Id = Guid.Empty, Name = "请您选择..." });
                Genders = new List<ListItem>();
                Genders.Add(new ListItem { ID = "-1", Name = "未知" });
                Genders.Add(new ListItem { ID = "1", Name = "男" });
                Genders.Add(new ListItem { ID = "0", Name = "女" });
            }
            catch (Exception ex)
            {
                ex = new Exception("初始化数据失败", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitControls()
        {
            try
            {
                if (SupplyUnits != null)
                    this.comboBoxSupplyUnitId.DataSource = SupplyUnits;
                if (this.comboBoxSupplyUnitId.Items.Count > 0)
                {
                    this.comboBoxSupplyUnitId.SelectedIndex = 0;
                }
                if (Districts != null)
                {
                    this.comboBoxAuthorizedDistrictId.DataSource = Districts;
                }
                if (this.comboBoxAuthorizedDistrictId.Items.Count > 0)
                {
                    this.comboBoxAuthorizedDistrictId.SelectedIndex = 0;
                }
                if (Genders != null)
                {
                    this.comboBoxGender.DataSource = Genders;
                }
                if (this.comboBoxGender.Items.Count > 0)
                {
                    this.comboBoxGender.SelectedIndex = 0;
                }

                dateTimePickerBirthday.MaxDate = TypesDefaultValues.MaxDateTime;
                dateTimePickerBirthday.MinDate = TypesDefaultValues.MinDateTime;
                dateTimePickerOutDate.MaxDate = TypesDefaultValues.MaxDateTime;
                dateTimePickerOutDate.MinDate = TypesDefaultValues.MinDateTime;
                this.comboBoxSupplyUnitId.Enabled = (RunMode == FormRunMode.Add);
                InitValidator();
                //文件处理
                this.buttonIDNumber.Tag = Entity.IDFile;
                //核实信息处理 
                this.textBoxIDCheckType.Text = string.IsNullOrWhiteSpace(Entity.IDCheckType)
                    ? "当面核实"
                    : Entity.IDCheckType;
                switch (RunMode)
                {
                    case FormRunMode.Add:
                    case FormRunMode.Edit:
                        checkBoxChecked.Checked = false;
                        checkBoxChecked.Enabled = false;
                        labelIDCheckUserName.Text = "...";
                        break;
                    case FormRunMode.Browse:
                    case FormRunMode.Search:
                    case FormRunMode.Delete:
                        this.checkBoxChecked.Checked = Entity.IsChecked;
                        this.checkBoxChecked.Enabled = false;
                        User checkUser = null;
                        string message = string.Empty;
                        checkUser = PharmacyDatabaseService.GetUser(out message, Entity.IDCheckUserId);
                        this.labelIDCheckUserName.Text = checkUser == null ? "无" : checkUser.Employee.Name;
                        break;
                    case FormRunMode.Check:
                        this.checkBoxChecked.Checked = false;
                        this.checkBoxChecked.Enabled =true;
                        this.labelIDCheckUserName.Text = AppClientContext.CurrentUser.Employee.Name;
                        break;
                    default:
                        break;
                }
                //核实信息处理

            }
            catch (Exception ex)
            {
                ex = new Exception("初始化控件失败", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitValidator()
        {
            this.AddRequiredValidate(this.labelName, this.textBoxName);
            this.AddRequiredValidate(this.labelIDNumber, this.textBoxIDNumber);
            //this.AddRequiredValidate(this.labelAddress, this.textBoxAddress);
            //this.AddRequiredValidate(this.labelTel, this.textBoxTel);
            this.AddRequiredValidate(this.labelSupplyUnitId, this.comboBoxSupplyUnitId);
            this.AddRequiredValidate(this.labelAuthorizedDistrictId, this.comboBoxAuthorizedDistrictId);
            this.AddRequiredValidate(this.labelIDCheckType, this.textBoxIDCheckType);
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitData();
            InitControls();
            BindEntityInfo();
        }

        private void BindEntityInfo()
        {
            try
            {
                if (Entity != null )
                {
                    textBoxName.Text = Entity.Name;
                    textBoxIDNumber.Text = Entity.IDNumber;
                    dateTimePickerBirthday.Value = Entity.Birthday;
                    //comboBoxGender.SelectedText = Entity.Gender;
                    //WFZ modified
                    comboBoxGender.Text = Entity.Gender;
                    //checkBoxChecked.Checked = Entity.IsChecked;

                    textBoxAddress.Text = Entity.Address;
                    textBoxTel.Text = Entity.Tel;
                    comboBoxSupplyUnitId.SelectedValue = Entity.SupplyUnitId;
                    dateTimePickerOutDate.Value = Entity.OutDate;
                    comboBoxAuthorizedDistrictId.SelectedValue = Entity.AuthorizedDistrictId;
                    ucBusinessScopeEditor.SelectedBusinessScopes = Entity.BusinessScopes;
                    checkBoxEnabled.Checked = Entity.Enabled;
                    buttonIDNumber.Tag = Entity.IDFile;
                    //核实信息处理 
                    this.textBoxIDCheckType.Text = string.IsNullOrWhiteSpace(Entity.IDCheckType)
                        ? "当面核实"
                        : Entity.IDCheckType;
                    switch (RunMode)
                    {
                        case FormRunMode.Add:  
                        case FormRunMode.Edit:
                            checkBoxChecked.Checked = false;
                            labelIDCheckUserName.Text = "...";
                            break;
                        case FormRunMode.Browse: 
                        case FormRunMode.Search: 
                        case FormRunMode.Delete: 
                            this.checkBoxChecked.Checked = Entity.IsChecked;
                            User checkUser = null;
                            string message = string.Empty;
                            checkUser = PharmacyDatabaseService.GetUser(out message, Entity.IDCheckUserId);
                            this.labelIDCheckUserName.Text = checkUser == null ? "无" : checkUser.Employee.Name;
                            break;  
                        case FormRunMode.Check:
                            this.checkBoxChecked.Checked = Entity.IsChecked;
                            this.labelIDCheckUserName.Text = AppClientContext.CurrentUser.Employee.Name;
                            break;
                        default:
                            break;
                    }
                    //核实信息处理
                }
            }
            catch (Exception ex)
            {
                ex = new Exception("绑定实体失败", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CollectEntityInfo()
        {
            try
            {
                Entity.Address = this.textBoxAddress.Text;
                Entity.AuthorizedDistrictId = Guid.Parse(this.comboBoxAuthorizedDistrictId.SelectedValue.ToString());
                Entity.Birthday = this.dateTimePickerBirthday.Value;
                Entity.BusinessScopes = this.ucBusinessScopeEditor.SelectedBusinessScopes;
                Entity.Enabled = this.checkBoxEnabled.Checked;
                Entity.Gender = this.comboBoxGender.Text;
                Entity.IDNumber = this.textBoxIDNumber.Text;
                Entity.Name = this.textBoxName.Text;
                Entity.OutDate = this.dateTimePickerOutDate.Value;
                Entity.SupplyUnitId = Guid.Parse(this.comboBoxSupplyUnitId.SelectedValue.ToString());
                Entity.Tel = this.textBoxTel.Text;
                //if (string.IsNullOrWhiteSpace(Entity.Tel) || Entity.Tel.Trim().Length < 8)
                //{
                //    MessageBox.Show("电话至少8位" + labelTel.Text, this.Text, MessageBoxButtons.OK,
                //        MessageBoxIcon.Stop);
                //    return false;
                //}
                if (Entity.AuthorizedDistrictId == Guid.Empty)
                {
                    MessageBox.Show("请检查您选择" + labelSupplyUnitId.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                if (Entity.SupplyUnitId == Guid.Empty)
                {
                    MessageBox.Show("请检查您选择" + labelAuthorizedDistrictId.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                //文件处理
                Entity.IDFile = Guid.Parse(this.buttonIDNumber.Tag.ToString());
                //核实信息处理
                Entity.IsChecked = this.checkBoxChecked.Checked;
                Entity.IDCheckType = this.textBoxIDCheckType.Text;
                //核实信息处理
                //WFZ modified
                if (this.dateTimePickerOutDate.Value.Date >= DateTime.Now.Date)
                    this.Entity.Valid = true;
                return true;

            }
            catch (Exception ex)
            {
                ex = new Exception("收集供货商业务人员信息出错", ex);
                this.Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            if (ValidateControls(out message))
            {

                if (CollectEntityInfo())
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("请检查您的输入:" + message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void buttonIDNumber_Click(object sender, EventArgs e)
        {
            Button btnFile = sender as Button;
            Guid fileId = Guid.Empty;
            if (btnFile.Tag != null)
            {
                fileId = (Guid)btnFile.Tag;
            }
            string msg;
            UserControlPharmacyFile form = new UserControlPharmacyFile(true);
            form.Title = btnFile.Parent.Text;
            form.OldPharmacyFile = PharmacyDatabaseService.GetPharmacyFile(out msg, fileId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                btnFile.Tag = form.PharmacyFile.Id;
            }
        }

        private void comboBoxSupplyUnitId_SelectedValueChanged(object sender, EventArgs e)
        {
            Guid supplyunitId = (System.Guid)(this.comboBoxSupplyUnitId.SelectedValue);
            //GSPLicense=
            if (supplyunitId != Guid.Empty)
            {
                //this.ucBusinessScopeEditor.
                //var d = from i in WarehouseZone where i.WarehouseId == (Guid)(comboBoxWarehouse.SelectedValue) select i;
                //this.comboBoxWarehouseZone.DataSource = d.ToArray();
                //this.comboBoxWarehouseZone.ValueMember = "id";
                //this.comboBoxWarehouseZone.DisplayMember = "name";
                //MessageBox.Show(supplyunitId.ToString());


                string msg = String.Empty;
                SupplyUnit supplyUnit=this.PharmacyDatabaseService.GetSupplyUnit(out msg,supplyunitId );
                GMSPLicenseBusinessScopes = this.PharmacyDatabaseService.AllGMSPLicenseBusinessScopes(out msg).ToList();
                var d = from i in GMSPLicenseBusinessScopes where i.GSPLicenseId == supplyUnit.GSPLicenseId select i;
                //MessageBox.Show(supplyUnit.GSPLicenseId.ToString());
                //var d= from i in GMSPLicenseBusinessScope where i.
            }
        }
    }
}
