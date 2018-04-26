using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class FormGSPLicense : BaseFunctionForm
    {
        bool _type =true;  
        /// <summary>
        /// 证书编号
        /// </summary>
        /// <param name="guid"></param>
        public FormGSPLicense(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                throw new ArgumentException("参数证书编号不可为默认");
            } 
            gMSPLicenseId = guid; 
            InitializeComponent();
        }
        
        //Edit by Wfz
        public FormGSPLicense(Guid guid,string legalPerson,string qualityCharger,string name,string address, string wareHouseAddress)
        {
            //if (guid == Guid.Empty)
            //{
            //    throw new ArgumentException("参数证书编号不可为默认");
            //}
            gMSPLicenseId = guid;
            InitializeComponent();
            LegalPerson = legalPerson;
            QualityCharger = qualityCharger;
            Name = name;
            this.Address = address;
            this.wareHouseAddress = wareHouseAddress;
        }

        public FormGSPLicense(Guid guid, string legalPerson, string qualityCharger, string name, string address, string wareHouseAddress, bool type)
        {
            //if (guid == Guid.Empty)
            //{
            //    throw new ArgumentException("参数证书编号不可为默认");
            //}
            gMSPLicenseId = guid;
            InitializeComponent();
            LegalPerson = legalPerson;
            QualityCharger = qualityCharger;
            Name = name;
            this.Address = address;
            this.wareHouseAddress = wareHouseAddress;
            _type = type;
            this.Text = "生产企业品种范围";
        }


        #region 变量定义 
    
        public string Name { get; private set; }
        public string LegalPerson { get; private set; }
        public string QualityCharger { get; private set; }//edit by wfz
        public string Address{ get; private set; }
        public string wareHouseAddress{ get; private set; }

        private Guid gMSPLicenseId;


        /// <summary>
        /// GSP证书对象
        /// </summary>
        public GSPLicense GSPLicense { get; private set; }

        private List<GMSPLicenseBusinessScope> GMSPLicenseBusinessScopes { get; set; }
        private GMSPLicenseBusinessScope gms { get; set;}

        /// <summary>
        /// 编辑状态
        /// </summary>
        public bool EditMode { get; private set; }

        /// <summary>
        /// 待选经营方式
        /// </summary>
        protected List<BusinessType> BusinessTypes { get; set; }


        /// <summary>
        /// 待选经营范围
        /// </summary>
        protected List<BusinessScope> BusinessScopes { get; set; }

        #endregion

        #region 事件处理

        private void FormGSPLicenseEdit_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode)
                    return;
                LoadGSPLicense(true);
                InitRequiredControl();
                LoadBusinessScopes();
                LoadBusinessTypes();
                LoadGMSPLicenseBusinessScopes();
                BindBusinessScopes();
                BindBusinessTypes();
                SetGMSPLicense();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("窗体加载失败" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"窗体加载失败" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        public void InitRequiredControl()
        {
            if (!DesignMode)
            {
                AddRequiredValidate(label1, textBoxName);
                AddRequiredValidate(label7, textBoxLicenseCode);
                AddRequiredValidate(label2, textBoxUnitName);
                AddRequiredValidate(label3, textBoxRegAddress);
                AddRequiredValidate(label9, textBoxIssuanceOrg);
                AddRequiredValidate(label10, dateTimePickerIssuanceDate);
                AddRequiredValidate(label11, dateTimePickerOutDate);
                AddRequiredValidate(label8, comboBoxBusinessTypeId);
                AddRequiredValidate(label4, textBoxHeader);
                AddRequiredValidate(label13, textBoxLegalPerson);
                AddRequiredValidate(label5, textBoxQualityHeader);
                AddRequiredValidate(label6, textBoxWarehouseAddress);
                //AddRequiredValidate(label14, checkedListBoxGMSPLicenseBusinessScopes);
            }
        }

        private void dateTimePickerIssuanceDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.dateTimePickerIssuanceDate.Value.Date >= this.dateTimePickerOutDate.Value.Date)
            {
                this.textBoxStatus.Text = "证书日期无效";
                return;
            }
            else
            {
                this.textBoxStatus.Text = "证书日期有效";
            }
            if (DateTime.Now.Date >= this.dateTimePickerOutDate.Value.Date)
            {
                this.textBoxStatus.Text = "证书已经过期";
            }
            else
            {
                this.textBoxStatus.Text = "证书有效";
            }
        }

        private void dateTimePickerOutDate_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerIssuanceDate_ValueChanged(sender, e);
        }

        private void checkedListBoxGMSPLicenseBusinessScopes_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = String.Empty;
                if (!ValidateControls(out msg))
                {
                    MessageBox.Show(msg);
                    return;
                }
                if (GetGMSPLicense())
                {
                    //string msg;
                    bool result = false;
                    if (EditMode)
                    {
                        result = PharmacyDatabaseService.AddGSPLicense(out msg, this.GSPLicense);
                    }
                    else
                    {
                        result = PharmacyDatabaseService.AddGSPLicense(out msg, this.GSPLicense);
                    }
                    if (result && string.IsNullOrWhiteSpace(msg))
                    {
                        //MessageBox.Show("证书保证成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text+"证书保证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("证书保存失败" + msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text+"证书保存失败" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("证书保存失败" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"证书保存失败" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #endregion 事件处理

        #region 控件到数据

        /// <summary>
        /// 设置证书信息到控件
        /// </summary>
        private bool GetGMSPLicense()
        {
            try
            {
                if (GSPLicense != null)
                {
                    GSPLicense.Id = Guid.NewGuid();
                    GSPLicense.Name = textBoxName.Text;
                    GSPLicense.LicenseCode = textBoxLicenseCode.Text;
                    GSPLicense.UnitName = textBoxUnitName.Text;
                    GSPLicense.RegAddress = textBoxRegAddress.Text;
                    GSPLicense.IssuanceOrg = textBoxIssuanceOrg.Text;
                    GSPLicense.IssuanceDate = dateTimePickerIssuanceDate.Value.Date;
                    GSPLicense.OutDate = dateTimePickerOutDate.Value.Date;
                    
                    GSPLicense.BusinessTypeId = (Guid)comboBoxBusinessTypeId.SelectedValue;
                    if (GSPLicense.BusinessTypeId == Guid.Empty || GSPLicense.BusinessTypeId == null)
                    {
                        MessageBox.Show("请选择经营方式！");
                        comboBoxBusinessTypeId.Focus();
                        return false;
                    }

                    GSPLicense.Header = textBoxHeader.Text; 
                    GSPLicense.WarehouseAddress = textBoxWarehouseAddress.Text;
                    GSPLicense.LegalPerson = textBoxLegalPerson.Text;
                    GSPLicense.QualityHeader = textBoxQualityHeader.Text; 
                    //WFZ
                    GSPLicense.ChangeRecord = textBoxChangeRecord.Text;
                    return GetGMSPLicenseBusinessScopes();
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //MessageBox.Show("从控件获取证书信息失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"从控件获取证书信息失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        private bool GetGMSPLicenseBusinessScopes()
        {
            try
            {
                string msg = string.Empty;
                GMSPLicenseBusinessScopes = PharmacyDatabaseService.AllGMSPLicenseBusinessScopes(out msg).Where(d=>d.GSPLicenseId==GSPLicense.Id && d.Deleted==false).ToList();
                if (GMSPLicenseBusinessScopes.Count != 0)
                {
                    foreach (var gms in GMSPLicenseBusinessScopes)
                        PharmacyDatabaseService.DeleteGMSPLicenseBusinessScope(out msg, gms.Id);
                }
                if (GMSPLicenseBusinessScopes.Count == 0)
                {
                    GMSPLicenseBusinessScopes = new List<GMSPLicenseBusinessScope>();
                }
                GMSPLicenseBusinessScopes.Clear();
                var items = checkedListBoxGMSPLicenseBusinessScopes.Items;
                for (int i = 0; i < items.Count; i++)
                {
                    var businessScope = items[i] as BusinessScope;
                    if (businessScope == null)
                        continue;
                    if (!checkedListBoxGMSPLicenseBusinessScopes.GetItemChecked(i))
                    {
                        continue;
                    }
                    GMSPLicenseBusinessScopes.Add(new GMSPLicenseBusinessScope
                    {
                        Id = Guid.NewGuid()
                        ,
                        BusinessScopeId = businessScope.Id
                        ,
                        GSPLicenseId = GSPLicense.Id 
                        ,
                        Deleted=false
                    });
                }
                GSPLicense.GMSPLicenseBusinessScopes = GMSPLicenseBusinessScopes.ToArray();
                //foreach (GMSPLicenseBusinessScope gsm in GMSPLicenseBusinessScopes)
                //    return PharmacyDatabaseService.AddGMSPLicenseBusinessScope(out msg,gsm);
                return true;

            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //MessageBox.Show("从控件收集选择的经营范围失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"从控件收集选择的经营范围失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        #endregion 控件到数据

        #region 数据到控件

        /// <summary>
        /// 绑定到经营方式到控件
        /// </summary>
        private void BindBusinessTypes()
        {
            try
            {
                if (BusinessTypes == null)
                {
                    LoadBusinessTypes();
                }
                if (BusinessTypes != null)
                {
                    this.comboBoxBusinessTypeId.DisplayMember = "Name";
                    this.comboBoxBusinessTypeId.ValueMember = "Id";
                    var tempTypes = BusinessTypes.ToList();
                    tempTypes.Insert(0, new BusinessType { Id = Guid.Empty, Name = "请选择..." });
                    this.comboBoxBusinessTypeId.DataSource = tempTypes;
                    if (comboBoxBusinessTypeId.Items.Count > 0)
                    {
                        comboBoxBusinessTypeId.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //MessageBox.Show("绑定到经营方式到控件", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"绑定到经营方式到控件","错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// 绑定到经营范围到控件
        /// </summary>
        private void BindBusinessScopes()
        {
            try
            {
                if (BusinessScopes == null)
                {
                    LoadBusinessScopes();
                }
                if (BusinessScopes != null)
                {
                    this.checkedListBoxGMSPLicenseBusinessScopes.Items.Clear();
                    this.checkedListBoxGMSPLicenseBusinessScopes.DisplayMember = "Name";
                    this.checkedListBoxGMSPLicenseBusinessScopes.ValueMember = "Id";
                    this.checkedListBoxGMSPLicenseBusinessScopes
                        .Items.AddRange(BusinessScopes.Cast<object>().ToArray());

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //MessageBox.Show("绑定到经营方式到控件", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"绑定到经营方式到控件","错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// 设置当前证书已经关联的经营范围
        /// </summary>
        private void SetGMSPLicenseBusinessScopes()
        {
            try
            {
                if (GMSPLicenseBusinessScopes.Count<=0)
                {
                    LoadGMSPLicenseBusinessScopes();
                }
                if (GMSPLicenseBusinessScopes.Count !=0)
                {
                    GMSPLicenseBusinessScopes.ForEach(gsmpScope =>
                    {
                        var items = checkedListBoxGMSPLicenseBusinessScopes.Items;
                        for (int i = 0; i < items.Count; i++)
                        {
                            var businessScope = items[i] as BusinessScope;
                            if (businessScope != null)
                            {
                                if (businessScope.Id == gsmpScope.BusinessScopeId)
                                {
                                    checkedListBoxGMSPLicenseBusinessScopes.SetItemChecked(i, true);
                                }
                            }
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //MessageBox.Show("设置当前证书已经关联的经营范围", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"设置当前证书已经关联的经营范围","错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// 设置证书信息到控件
        /// </summary>
        private void SetGMSPLicense()
        {
            try
            {
                if (GSPLicense != null)
                {
                    textBoxName.Text =_type? GSPLicense.Name:"无";
                    textBoxLicenseCode.Text =_type? GSPLicense.LicenseCode:"无";
                    textBoxUnitName.Text = GSPLicense.UnitName;
                    textBoxRegAddress.Text = GSPLicense.RegAddress;
                    textBoxIssuanceOrg.Text = _type?GSPLicense.IssuanceOrg:"无";
                    
                    dateTimePickerIssuanceDate.Value = _type ? GSPLicense.IssuanceDate : DateTime.Now.AddYears(-10);
                    dateTimePickerOutDate.Value = _type ? GSPLicense.OutDate : DateTime.Now.AddYears(10);
                    if (comboBoxBusinessTypeId.Items.Count > 0)
                    {
                        if (EditMode)
                        {
                            comboBoxBusinessTypeId.SelectedValue = GSPLicense.BusinessTypeId;
                        }
                    }
                    textBoxHeader.Text = GSPLicense.Header; 
                    textBoxWarehouseAddress.Text = GSPLicense.WarehouseAddress;
                    textBoxLegalPerson.Text = GSPLicense.LegalPerson;
                    textBoxQualityHeader.Text = GSPLicense.QualityHeader;
                    textBoxChangeRecord.Text = GSPLicense.ChangeRecord;
                    SetGMSPLicenseBusinessScopes();
                }


            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //MessageBox.Show("设置证书信息到控件失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+"设置证书信息到控件失败","错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #endregion 数据到控件

        #region 从服务器获取数据

        /// <summary>
        /// 从服务器获取该Guid证书
        /// </summary>
        /// <returns></returns>
        private bool LoadGSPLicense(bool showMessage = false)
        {
            try
            {
                string message;
                GSPLicense = PharmacyDatabaseService.GetGSPLicense(out message, gMSPLicenseId);
                if (GSPLicense != null)
                { 
                    EditMode = true;
                    //this.buttonSave.Enabled = false;
                }
                else
                {
                    EditMode = false;
                    GSPLicense = new GSPLicense();
                    GSPLicense.Id =gMSPLicenseId;
                    GSPLicense.StoreId = AppClientContext.Config.Store.Id; 
                    GSPLicense.IssuanceDate = DateTime.Now;
                    GSPLicense.OutDate = DateTime.Now.AddYears(1);//edit by wfz
                    GSPLicense.LegalPerson = LegalPerson;
                    GSPLicense.QualityHeader = QualityCharger;
                    GSPLicense.UnitName = Name;
                    GSPLicense.Enabled = true;
                    GSPLicense.RegAddress = Address;
                    GSPLicense.WarehouseAddress = wareHouseAddress;
                    GSPLicense.Header = LegalPerson;
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                if (showMessage)
                    //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show( this.Text+ex.Message,"错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

        }

        /// <summary>
        /// 从服务器获取证书的经营范围
        /// </summary>
        /// <param name="showMessage"></param>
        /// <returns></returns>
        public bool LoadGMSPLicenseBusinessScopes(bool showMessage = false)
        {
            try
            {
                if (EditMode)
                {
                    //从服务器获取最新的证书的经营范围们
                    GMSPLicenseBusinessScopes = this.GSPLicense.GMSPLicenseBusinessScopes.ToList();
                }
                else
                {
                    GMSPLicenseBusinessScopes = new List<GMSPLicenseBusinessScope>();
                }
                return true;
            }
            catch (Exception ex)
            {
                GMSPLicenseBusinessScopes = null;
                if (showMessage)
                    //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
                return false;
            }
        }

        /// <summary>
        /// 从服务器获取所有经营范围
        /// </summary>
        /// <param name="showMessage"></param>
        /// <returns></returns>
        public bool LoadBusinessScopes(bool showMessage = false)
        {
            try
            {
                string message;
                BusinessScopes = PharmacyDatabaseService.AllBusinessScopes(out message).Where(d=>d.Deleted==false)
                    .ToList();
                if (BusinessScopes != null && string.IsNullOrWhiteSpace(message))
                {
                    foreach (BusinessScope businessScope in BusinessScopes)
                    {
                        if (businessScope.BusinessScopeCategory != null)
                        {
                            businessScope.Name = string.Format("{0}>{1}"
                                , businessScope.BusinessScopeCategory.Name
                                , businessScope.Name
                                );
                        }
                    }
                    return true;
                }
                else
                {
                    throw new Exception(message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                if (showMessage)
                    //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        /// 从服务器获取所有经营范围
        /// </summary>
        /// <param name="showMessage"></param>
        /// <returns></returns>
        public bool LoadBusinessTypes(bool showMessage = false)
        {
            try
            {
                string message;
                BusinessTypes = PharmacyDatabaseService.AllBusinessTypes(out message)
                    .ToList();
                if (BusinessScopes != null && string.IsNullOrWhiteSpace(message))
                {
                    return true;
                }
                else
                {
                    throw new Exception(message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                if (showMessage)
                    //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }


        #endregion 从服务器获取数据

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i=0;i<checkedListBoxGMSPLicenseBusinessScopes.Items.Count;i++)
            {
                this.checkedListBoxGMSPLicenseBusinessScopes.SetItemChecked(i,true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxGMSPLicenseBusinessScopes.Items.Count; i++)
            {
                this.checkedListBoxGMSPLicenseBusinessScopes.SetItemChecked(i, false);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.gMSPLicenseId == Guid.Empty || this.gMSPLicenseId == null) return;
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1101, this.gMSPLicenseId);
            if (!this.button1.Visible)
            {
                SetControls.SetControlReadonly(frm,true);
            }
            frm.ShowDialog();
        }

        #region 数据到服务器

        #endregion 数据到服务器
    }
}
