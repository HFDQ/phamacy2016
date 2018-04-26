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

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    /// <summary>
    /// GSP/GMP证书编辑
    /// </summary>
    public partial class FormGMSPLicenseEdit : BaseFunctionForm
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="guid">证书编号</param>
        /// <param name="unitId">单位编号</param>
        /// <param name="isSupplyUnit">是否供应商</param>
        public FormGMSPLicenseEdit(Guid guid, Guid unitId, bool isSupplyUnit)
        {
            if (guid == Guid.Empty)
            {
                throw new ArgumentException("参数证书编号不可为默认");
            }
            if (unitId == Guid.Empty)
            {
                throw new ArgumentException("参数单位编号不可为默认");
            }
            gMSPLicenseId = guid;
            UnitId = unitId;
            IsSupplyUnit = isSupplyUnit;
            InitializeComponent();
        }

        #region 变量定义

        private Guid UnitId { get; set; }

        private bool IsSupplyUnit { get; set; }

        private Guid gMSPLicenseId;


        /// <summary>
        /// 证书对象
        /// </summary>
        public GMSPLicense GMSPLicense { get; private set; }

        private List<GMSPLicenseBusinessScope> GMSPLicenseBusinessScopes { get; set; }

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

        private void FormGMSPLicenseEdit_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode)
                    return;
                LoadGMSPLicense(true);
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
                MessageBox.Show(this.Text + "窗体加载失败" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (GetGMSPLicense())
                {
                    string msg;
                    bool result = false;
                    if (EditMode)
                    {
                        result = PharmacyDatabaseService.SaveGMSPLicense(out msg, this.GMSPLicense);
                    }
                    else
                    {
                        result = PharmacyDatabaseService.AddGMSPLicense(out msg, this.GMSPLicense);
                    }
                    if (result && string.IsNullOrWhiteSpace(msg))
                    {
                        //MessageBox.Show("证书保证成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text + "证书保证成功", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("证书保存失败" + msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(this.Text + "证书保存失败" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("证书保存失败" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text + "证书保存失败" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (GMSPLicense != null)
                {
                    GMSPLicense.Name = textBoxName.Text;
                    GMSPLicense.LicenseCode = textBoxLicenseCode.Text;
                    GMSPLicense.UnitName = textBoxUnitName.Text;
                    GMSPLicense.RegAddress = textBoxRegAddress.Text;
                    GMSPLicense.IssuanceOrg = textBoxIssuanceOrg.Text;
                    GMSPLicense.IssuanceDate = dateTimePickerIssuanceDate.Value.Date;
                    GMSPLicense.OutDate = dateTimePickerOutDate.Value.Date;
                    if (comboBoxBusinessTypeId.Items.Count > 0)
                    {
                        GMSPLicense.BusinessTypeId = (Guid)comboBoxBusinessTypeId.SelectedValue;
                    }
                    GMSPLicense.Header = textBoxHeader.Text;
                    GMSPLicense.CertificationScope = textBoxCertificationScope.Text;
                    GMSPLicense.WarehouseAddress = textBoxWarehouseAddress.Text;
                    GMSPLicense.LegalPerson = textBoxLegalPerson.Text;
                    GMSPLicense.QualityHeader = textBoxQualityHeader.Text;
                    return GetGMSPLicenseBusinessScopes();
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //MessageBox.Show("从控件获取证书信息失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show("this.Text+从控件获取证书信息失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        private bool GetGMSPLicenseBusinessScopes()
        {
            try
            {
                if (GMSPLicenseBusinessScopes == null)
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
                        GMSPLicenseId = GMSPLicense.Id
                    });
                }
                GMSPLicense.GMSPLicenseBusinessScopes = GMSPLicenseBusinessScopes.ToArray();
                return true;

            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //MessageBox.Show("从控件收集选择的经营范围失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text + "从控件收集选择的经营范围失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                MessageBox.Show(this.Text+"绑定到经营方式到控件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                MessageBox.Show(this.Text+"绑定到经营方式到控件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// 设置当前证书已经关联的经营范围
        /// </summary>
        private void SetGMSPLicenseBusinessScopes()
        {
            try
            {
                if (GMSPLicenseBusinessScopes == null)
                {
                    LoadGMSPLicenseBusinessScopes();
                }
                if (GMSPLicenseBusinessScopes != null)
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
                if (GMSPLicense != null)
                {
                    textBoxName.Text = GMSPLicense.Name;
                    textBoxLicenseCode.Text = GMSPLicense.LicenseCode;
                    textBoxUnitName.Text = GMSPLicense.UnitName;
                    textBoxRegAddress.Text = GMSPLicense.RegAddress;
                    textBoxIssuanceOrg.Text = GMSPLicense.IssuanceOrg;
                    dateTimePickerIssuanceDate.Value = GMSPLicense.IssuanceDate;
                    dateTimePickerOutDate.Value = GMSPLicense.OutDate;
                    if (comboBoxBusinessTypeId.Items.Count > 0)
                    {
                        if (EditMode)
                        {
                            comboBoxBusinessTypeId.SelectedValue = GMSPLicense.BusinessTypeId;
                        }
                    }
                    textBoxHeader.Text = GMSPLicense.Header;
                    textBoxCertificationScope.Text = GMSPLicense.CertificationScope;
                    textBoxWarehouseAddress.Text = GMSPLicense.WarehouseAddress;
                    textBoxLegalPerson.Text = GMSPLicense.LegalPerson;
                    textBoxQualityHeader.Text = GMSPLicense.QualityHeader;
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
        private bool LoadGMSPLicense(bool showMessage = false)
        {
            try
            {
                string message;
                GMSPLicense = PharmacyDatabaseService.GetGMSPLicense(out message, gMSPLicenseId);
                if (GMSPLicense != null)
                {
                    EditMode = true;
                }
                else
                {
                    EditMode = false;
                    GMSPLicense = new GMSPLicense();
                    GMSPLicense.Id = gMSPLicenseId;
                    GMSPLicense.StoreId = AppClientContext.Config.Store.Id;
                    if (IsSupplyUnit)
                    {
                        GMSPLicense.SupplyUnitId = UnitId;
                    }
                    else
                    {
                        GMSPLicense.PurchaseUnitId = UnitId;
                    }
                    GMSPLicense.IssuanceDate = DateTime.Now;
                    GMSPLicense.OutDate = DateTime.Now.AddYears(1);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                if (showMessage)
                    //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    GMSPLicenseBusinessScopes = this.GMSPLicense.GMSPLicenseBusinessScopes
                        .ToList();
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
                BusinessScopes = PharmacyDatabaseService.AllBusinessScopes(out message)
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

        #region 数据到服务器

        #endregion 数据到服务器
    }
}
