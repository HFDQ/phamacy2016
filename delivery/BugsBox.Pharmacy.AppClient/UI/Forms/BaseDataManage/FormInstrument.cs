using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormInstrument : BaseFunctionForm
    {
        string msg = string.Empty;
        /// <summary>
        /// Druginfo器械实体
        /// </summary>
        public Models.DrugInfo entity { get; set; }
        public FormStatusEnum FSE = FormStatusEnum.New;

        public event InstrumentInfoSubMitEventHandler InstrumentInfoSubmit;

        List<TextBox> ListValidator = new List<TextBox>();
        ToolTip tt = new ToolTip();

        #region 初始化实体参数方法
        private Func<Models.DrugInfo> InitEntity = () =>
        {
            return new Models.DrugInfo
            {
                MinInventoryCount = 1,
                MaxInventoryCount = 99999,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                CreateUserId = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id,
                UpdateUserId = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id,
                ApprovalDate = DateTime.Now.Date,
                ApprovalStatusValue = (int)Models.ApprovalStatus.Waitting,
                BigPackage = 0,
                BarCode = "无",
                BusinessScopeCode = "医疗器械",
                Deleted = false,
                Description = "同意采购",
                Enabled = true,
                
                Id = Guid.NewGuid(),
                IsImport = false,
                ValidPeriod = 36,
                PermitDate = DateTime.Now.Date,
                PermitOutDate = DateTime.Now.AddYears(50).Date,
                ValidRemark = "无",
                PurchaseManageCategoryDetailCode = "无",
                MedicalCategoryDetailCode = "无",
                DrugClinicalCategoryCode = "无",
                DictionaryUserDefinedTypeCode = "无",
                StandardCode = string.Empty,
                 InstEntProductLiscencePermitNumber="无"
            };

        };
        #endregion

        /// <summary>
        /// 初始化方法-需设定读写FSE、实体entity
        /// </summary>
        public FormInstrument()
        {
            InitializeComponent();

            this.Text = this.FSE == FormStatusEnum.New ? "新建医疗器械信息" : this.FSE == FormStatusEnum.Edit ? "编辑医疗器械信息" : "查看医疗器械信息";


            #region 验证文本框
            this.AddTextBoxToValidator(this);            
            #endregion

            #region 绑定实体

            int _count = 0;
            if (this.entity == null)
            {
                this.entity = InitEntity();
                _count = PharmacyDatabaseService.GetDrugInfoCount(string.Empty);
                this.entity.DocCode = "SPDA" + _count.ToString().PadLeft(6, '0');
                this.entity.Code = "SPBH" + _count.ToString().PadLeft(6, '0');
            }
            #endregion

            #region 生成注记码和产品编号
            this.textBox1.LostFocus += (sender, e) =>
            {
                entity.Pinyin = this.textBox1.Text.Trim() == string.Empty ? string.Empty : CreateChineseSpell.CreatePY(this.textBox1.Text.Trim());
                this.textBox2.Text = entity.Pinyin;
                this.entity.ProductName = this.textBox1.Text.Trim();
            };
            #endregion

            #region 绑定存储条件
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            var storageList = this.PharmacyDatabaseService.AllDictionaryStorageTypes(out msg).Where(r => !r.Deleted).OrderBy(r => r.Name).ToList();
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Name";
            this.comboBox1.DataSource = storageList;
            if (storageList.Count() > 0)
                this.comboBox1.SelectedIndex = 0;
            #endregion

            #region 绑定审批流程
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            var ApprovalProceedureList = this.PharmacyDatabaseService.GetApprovalFlowTypeByBusiness(out msg, Models.ApprovalType.DrugInfoApproval).OrderBy(r => r.Name).ToList();
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.ValueMember = "Id";
            this.comboBox2.DataSource = ApprovalProceedureList;
            if (ApprovalProceedureList.Count() > 0)
                comboBox2.SelectedIndex = 0;
            #endregion

            #region 绑定仓库和库位
            this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            var warehouseList = this.PharmacyDatabaseService.AllWarehouses(out msg).Where(r => !r.Deleted).OrderBy(r => r.Name).ToList();
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.ValueMember = "Id";
            this.comboBox3.DataSource = warehouseList;
            if (warehouseList.Count() > 0)
                this.comboBox3.SelectedIndex = 0;

            var warehousezoneList = this.PharmacyDatabaseService.AllWarehouseZones(out msg).Where(r => !r.Deleted).OrderBy(r => r.Name).ToList();
            this.comboBox4.DisplayMember = "Name";
            this.comboBox4.ValueMember = "Id";

            var wz = warehousezoneList.Where(r => r.WarehouseId == (Guid)this.comboBox3.SelectedValue).ToList();
            this.comboBox4.DataSource = wz;
            if (wz.Count() > 0)
                this.comboBox4.SelectedIndex = 0;

            this.comboBox3.SelectedIndexChanged += (sender, e) =>
            {
                wz = warehousezoneList.Where(r => r.WarehouseId == (Guid)this.comboBox3.SelectedValue).ToList();
                this.comboBox4.DataSource = wz;
                if (wz.Count() > 0)
                    this.comboBox4.SelectedIndex = 0;
            };

            #endregion

            #region 器械分类判定码
            FormInstrument_CategoryTable frm = null;

            Func<string, bool> CheckInstrumentTypeStr = (s) =>
            {
                if (s == string.Empty) return true;
                if (s.Length < 6 || s.Length > 7) return false;
                if (!s.Contains("-")) return false;
                if (s.Substring(s.Length - 3, 1) != "-") return false;
                if (s[0] != 'A' && s[0] != 'B') return false;
                if (s[1] != 'A' && s[1] != 'B') return false;
                if (int.Parse(s[s.Length - 1].ToString()) > 3 || int.Parse(s[s.Length - 1].ToString()) < 1) return false;
                if (int.Parse(s[s.Length - 2].ToString()) > 3 || int.Parse(s[s.Length - 2].ToString()) < 1) return false;
                return true;
            };

            this.linkLabel1.Click += (sender, e) =>
            {
                string str = this.entity.StandardCode.Trim();

                if (!CheckInstrumentTypeStr(str))
                {
                    if (MessageBox.Show("分类码错误！需要清空，并且重新设定吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
                    else
                        this.entity.StandardCode = string.Empty;
                }

                if (frm == null || frm.IsDisposed)
                {
                    frm = new FormInstrument_CategoryTable(str);
                    frm.SelectInstrument += (sender1, e1) =>
                    {
                        this.entity.StandardCode = e1.InstrumentTypeStr;
                        this.textBox11.Text = this.entity.StandardCode;
                    };
                }
                frm.Hide();
                frm.Show(this);
            };
            #endregion

            #region 管理分类combo
            this.comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox5.SelectedIndex = 0;
            #endregion

            #region 录入人
            this.label21.Text = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Employee.Name;
            #endregion

            #region Form_Load事件

            this.Load += (sender, e) =>
            {
                this.drugInfoBindingSource.Add(entity);

                #region 初始化工具条按钮显示
                if (FSE == FormStatusEnum.New)
                {
                    this.toolStripButton3.Visible = false;
                }
                if (FSE == FormStatusEnum.Edit)
                {
                    this.toolStripButton1.Visible = false;
                    this.toolStripButton3.Visible = true;
                }
                if (FSE == FormStatusEnum.Read)
                {
                    this.toolStripButton1.Visible = false;
                    this.toolStripButton3.Visible = false;
                }
                #endregion

                #region 审核Combo
                if (this.entity.FlowID != null && this.entity.FlowID != Guid.Empty)
                {
                    var ApprovalFlow=this.PharmacyDatabaseService.GetApproveFlowsByFlowID(out msg,entity.FlowID);

                    var AllApprovalTypes = this.PharmacyDatabaseService.AllApprovalFlowTypes(out msg).ToList();
                    if (entity.IsApproval)//如果审批结束
                    {
                        AllApprovalTypes = AllApprovalTypes.Where(r => r.ApprovalType == Models.ApprovalType.DrugInfoEditApproval).ToList();
                        this.comboBox2.DataSource = null;
                        this.comboBox2.DisplayMember = "Name";
                        this.comboBox2.ValueMember = "Id";                        
                        this.comboBox2.DataSource = AllApprovalTypes;
                        this.comboBox2.SelectedIndex = 0;
                    }
                    else//如果审批未结束
                    {
                        this.comboBox2.DataSource = null;
                        this.comboBox2.DisplayMember = "Name";
                        this.comboBox2.ValueMember = "Id";                        
                        this.comboBox2.DataSource = AllApprovalTypes;
                        this.comboBox2.Enabled = false;
                        this.comboBox2.SelectedValue = ApprovalFlow.ApprovalFlowTypeId;
                    }
                }
                #endregion

                #region 实体数据
                if (!string.IsNullOrEmpty(this.entity.DrugStorageTypeCode))
                {
                    this.comboBox1.SelectedValue = this.entity.DrugStorageTypeCode;
                }
                if (this.entity.WareHouses != null && this.entity.WareHouses != Guid.Empty)
                {
                    this.comboBox3.SelectedValue = entity.WareHouses;
                }
                if (!string.IsNullOrEmpty(this.entity.WareHouseZones))
                {
                    this.comboBox4.SelectedValue = Guid.Parse(entity.WareHouseZones);
                }

                if (!string.IsNullOrEmpty(this.entity.DrugCategoryCode))
                {
                    this.comboBox5.SelectedItem = entity.DrugCategoryCode;
                }

                #endregion
            };
            #endregion

            #region 提交事件
            this.toolStripButton1.Click += (sender, e) =>
            {
                if (MessageBox.Show("确定需要提交该医疗器械信息吗？", "", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
                this.Validate();

                if (!this.ValidateRequiredTextBox()) return;  //验证文本框                
                if (this.comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("请选择存储方式！"); return;
                }
                this.entity.DrugStorageTypeCode = ((Models.DictionaryStorageType)this.comboBox1.SelectedItem).Name;

                this.entity.WareHouses = (Guid)this.comboBox3.SelectedValue;
                if (warehousezoneList.Count <= 0)
                {
                    MessageBox.Show("您所选择的仓库没有设定库位（货架），请选择其他仓库！");
                    return;
                }
                this.entity.WareHouseZones = this.comboBox4.SelectedValue.ToString();

                this.entity.DrugCategoryCode = this.comboBox5.SelectedItem.ToString();

                this.entity.FlowID = Guid.NewGuid();

                this.toolStripButton3.Enabled = !this.toolStripButton3.Enabled;//开始提交

                var b = this.PharmacyDatabaseService.AddDrugInfoApproveFlow(this.entity, (Guid)this.comboBox2.SelectedValue, BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "新增医疗器械：" + this.entity.ProductGeneralName);

                if (b == string.Empty)
                {
                    MessageBox.Show("新增医疗器械：" + this.entity.ProductGeneralName + "成功！");
                    this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "新增医疗器械：" + this.entity.ProductGeneralName);

                    this.drugInfoBindingSource.Clear();
                    this.entity = default(Models.DrugInfo);
                    this.entity = InitEntity();
                    this.drugInfoBindingSource.Add(this.entity);
                    _count = PharmacyDatabaseService.GetDrugInfoCount(string.Empty);

                    this.entity.DocCode = "SPDA" + _count.ToString().PadLeft(6, '0');
                    this.textBox3.Text = this.entity.DocCode;
                    this.entity.Code = "SPBH" + _count.ToString().PadLeft(6, '0');
                    this.textBox18.Text = this.entity.Code;
                    this.toolStripButton3.Enabled = !this.toolStripButton3.Enabled;//结束提交
                }
                else
                {
                    MessageBox.Show("提交失败，请稍后重试！");
                    this.toolStripButton3.Enabled = !this.toolStripButton3.Enabled;//结束提交
                }
            };

            #endregion

            #region 保存编辑数据按钮
            this.toolStripButton3.Click += (sender, e) =>
            {
                if (this.FSE != FormStatusEnum.Edit) return;
                if (MessageBox.Show("确定需要保存该医疗器械信息吗？", "", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
                this.Validate();

                if (!this.ValidateRequiredTextBox()) return;  //验证文本框

                if (this.comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("请选择存储方式！"); return;
                }
                this.entity.DrugStorageTypeCode = ((Models.DictionaryStorageType)this.comboBox1.SelectedItem).Name;

                this.entity.WareHouses = (Guid)this.comboBox3.SelectedValue;
                this.entity.WareHouseZones = this.comboBox4.SelectedValue.ToString();
                this.entity.PermitOutDate =DateTime.Now.AddYears(50).Date;

                this.entity.DrugCategoryCode = this.comboBox5.SelectedItem.ToString();
                this.entity.Valid = false;
                Guid typeid = (Guid)this.comboBox2.SelectedValue;
                if (entity.IsApproval || entity.ApprovalStatusValue == (int)Models.ApprovalStatus.Reject)
                {
                    entity.ApprovalStatus = Models.ApprovalStatus.Waitting;
                    entity.IsApproval = false;
                    entity.FlowID = Guid.NewGuid();

                    this.toolStripButton3.Enabled = !this.toolStripButton3.Enabled;//开始提交
                    msg = PharmacyDatabaseService.ModifyDrugInfoApproveFlow(entity, typeid, BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "审核后修改医疗器械信息:" + entity.ProductGeneralName);
                    if (string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show("提交成功！");
                        if (this.InstrumentInfoSubmit != null)
                        {
                            this.InstrumentInfoSubmit(this, true);
                        } 
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("提交失败，请稍后再试！");
                        this.toolStripButton3.Enabled = !this.toolStripButton3.Enabled;
                        return;
                    }
                }
                else
                {
                    entity.ApprovalStatus = Models.ApprovalStatus.Waitting;
                    this.toolStripButton3.Enabled = !this.toolStripButton3.Enabled;//开始提交

                    msg = PharmacyDatabaseService.ModifyDrugInfoApproveFlow(entity, typeid, BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "审核前修改医疗器械信息" + entity.ProductGeneralName);
                    if (string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show("提交成功！");
                        if (this.InstrumentInfoSubmit != null)
                        {
                            this.InstrumentInfoSubmit(this, true);
                        }                         
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("提交失败，请稍后再试！");
                        this.toolStripButton3.Enabled = !this.toolStripButton3.Enabled;
                        return;
                    }
                }
            };
            #endregion
        }

        #region 验证文本框
        private void AddTextBoxToValidator(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    this.ListValidator.Add((TextBox)c);
                }
                if (c.GetType() == typeof(GroupBox))
                {
                    AddTextBoxToValidator(c);
                }
            }
        }

        private bool ValidateRequiredTextBox()
        {
            foreach (TextBox t in this.ListValidator.OrderBy(r=>r.TabIndex).ToList())
            {
                if (string.IsNullOrEmpty(t.Text.Trim()))
                {
                    tt.Dispose();
                    tt = new ToolTip
                    {
                        ToolTipTitle = "提示!",
                        AutoPopDelay = 5000,
                        InitialDelay = 1000,
                        ReshowDelay = 500,
                        ShowAlways = true,
                        ToolTipIcon = ToolTipIcon.Warning,
                        IsBalloon = true
                    };
                    tt.SetToolTip(t, "NoText!");
                    this.tt.Show("请填写信息", t,5000);
                    t.Focus();
                    return false;
                }
            }
            return true;
        }
        #endregion

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
    public delegate void InstrumentInfoSubMitEventHandler(object sender, bool IsSubmit);
}
