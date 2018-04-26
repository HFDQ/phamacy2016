using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormFood : BaseFunctionForm
    {
        string msg = string.Empty;
        /// <summary>
        /// Druginfo器械实体
        /// </summary>
        public Models.DrugInfo entity { get; set; }
        public FormStatusEnum FSE = FormStatusEnum.New;

        public event InstrumentInfoSubMitEventHandler InstrumentInfoSubmit;

        List<Control> ListValidator = new List<Control>();
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
                BusinessScopeCode = "保健食品",
                Deleted = false,
                Description = "因业务需要，申请采购",
                Enabled = true,

                Id = Guid.NewGuid(),
                ValidPeriod = 24,
                PermitDate = DateTime.Now.Date,
                PermitOutDate = DateTime.Now.AddYears(50).Date,
                ValidRemark = "无",
                PurchaseManageCategoryDetailCode = "无",
                MedicalCategoryDetailCode = "无",
                DrugClinicalCategoryCode = "无",
                DictionaryUserDefinedTypeCode = "无",
                StandardCode = string.Empty,
                DrugCategoryCode = "无",
                SpecialDrugCategoryCode = "无",
                GoodsType = Models.GoodsType.Food,
                GoodsTypeValue = (int)Models.GoodsType.Food,
                PerformanceStandards = "无",
                PiecemealSpecification = "无",
                DictionaryPiecemealUnitCode = "无",
                Origin = "无",
                Function = "",
                CommendedUser = "无",
                Ingredient = "无"

            };

        };
        #endregion

        /// <summary>
        /// 初始化方法-需设定读写FSE、实体entity
        /// </summary>
        public FormFood()
        {
            InitializeComponent();

            this.Text = this.FSE == FormStatusEnum.New ? "新建保健食品信息" : this.FSE == FormStatusEnum.Edit ? "编辑保健食品信息" : "查看保健食品信息";

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
            {
                this.entity.WareHouses = warehouseList.FirstOrDefault().Id;
                this.comboBox3.SelectedIndex = 0;
            }

            if (warehouseList.Count <= 0)
            {
                MessageBox.Show("仓库信息没有设置，请通知管理设置仓库信息！");
                this.toolStripButton1.Enabled = false;
                this.toolStripButton3.Enabled = false;
                return;
            }

            var warehousezoneList = this.PharmacyDatabaseService.AllWarehouseZones(out msg).Where(r => !r.Deleted).OrderBy(r => r.Name).ToList();
            if (warehousezoneList.Count <= 0)
            {
                MessageBox.Show("仓库库位（货架）信息没有设置，请通知管理设置仓库信息！");
                this.toolStripButton1.Enabled = false;
                this.toolStripButton3.Enabled = false;
                return;
            }


            this.comboBox4.DisplayMember = "Name";
            this.comboBox4.ValueMember = "Id";

            var wz = warehousezoneList.Where(r => r.WarehouseId == (Guid)this.comboBox3.SelectedValue).ToList();
            this.comboBox4.DataSource = wz;
            if (wz.Count() > 0)
                this.comboBox4.SelectedIndex = 0;

            this.comboBox3.SelectedIndexChanged += (sender, e) =>
            {
                if (this.comboBox3.SelectedValue == null) return;
                wz = warehousezoneList.Where(r => r.WarehouseId == (Guid)this.comboBox3.SelectedValue).ToList();
                this.comboBox4.DataSource = wz;
                if (wz.Count() > 0)
                    this.comboBox4.SelectedIndex = 0;
            };

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
                    var ApprovalFlow = this.PharmacyDatabaseService.GetApproveFlowsByFlowID(out msg, entity.FlowID);

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

                if (!string.IsNullOrEmpty(this.entity.WareHouseZones))
                {
                    this.comboBox4.SelectedValue = Guid.Parse(entity.WareHouseZones);
                }

                #endregion
            };
            #endregion

            #region 提交事件
            this.toolStripButton1.Click += (sender, e) =>
            {
                if (MessageBox.Show("确定需要提交该保健食品信息吗？", "", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
                this.Validate();

                if (!this.ValidateRequiredTextBox()) return;  //验证文本框                

                this.entity.DrugStorageTypeCode = ((Models.DictionaryStorageType)this.comboBox1.SelectedItem).Name;

                if (warehousezoneList.Count <= 0)
                {
                    MessageBox.Show("您所选择的仓库没有设定库位（货架），请更换仓库。");
                    return;
                }
                this.entity.WareHouseZones = this.comboBox4.SelectedValue.ToString();

                this.entity.FlowID = Guid.NewGuid();

                this.toolStripButton3.Enabled = !this.toolStripButton3.Enabled;//开始提交

                var b = this.PharmacyDatabaseService.AddDrugInfoApproveFlow(this.entity, (Guid)this.comboBox2.SelectedValue, BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "新增保健食品：" + this.entity.ProductGeneralName);

                if (b == string.Empty)
                {
                    MessageBox.Show("新增保健食品：" + this.entity.ProductGeneralName + "成功！");
                    this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "新增保健食品：" + this.entity.ProductGeneralName);

                    this.drugInfoBindingSource.Clear();
                    this.entity = default(Models.DrugInfo);
                    this.entity = InitEntity();
                    this.entity.WareHouses = warehouseList.FirstOrDefault().Id;
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
                if (MessageBox.Show("确定需要保存该保健食品信息吗？", "", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
                this.Validate();

                if (!this.ValidateRequiredTextBox()) return;  //验证文本框

                this.entity.DrugStorageTypeCode = ((Models.DictionaryStorageType)this.comboBox1.SelectedItem).Name;

                this.entity.WareHouses = (Guid)this.comboBox3.SelectedValue;
                this.entity.WareHouseZones = this.comboBox4.SelectedValue.ToString();
                this.entity.PermitOutDate = DateTime.Now.AddYears(50).Date;

                this.entity.Valid = false;
                Guid typeid = (Guid)this.comboBox2.SelectedValue;
                if (entity.IsApproval || entity.ApprovalStatusValue == (int)Models.ApprovalStatus.Reject)
                {
                    entity.ApprovalStatus = Models.ApprovalStatus.Waitting;
                    entity.IsApproval = false;
                    entity.FlowID = Guid.NewGuid();

                    this.toolStripButton3.Enabled = !this.toolStripButton3.Enabled;//开始提交
                    msg = PharmacyDatabaseService.ModifyDrugInfoApproveFlow(entity, typeid, BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "审核后修改保健食品信息:" + entity.ProductGeneralName);
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

                    msg = PharmacyDatabaseService.ModifyDrugInfoApproveFlow(entity, typeid, BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "审核前修改保健食品信息" + entity.ProductGeneralName);
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
                if (c.Name == textBox9.Name || c.Name == richTextBox2.Text || c.Name == textBox5.Name) continue;
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(RichTextBox))
                {
                    this.ListValidator.Add(c);
                }
                if (c.GetType() == typeof(GroupBox))
                {
                    AddTextBoxToValidator(c);
                }
            }
        }

        private bool ValidateRequiredTextBox()
        {
            foreach (Control t in this.ListValidator.OrderBy(r => r.TabIndex).ToList())
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
                    this.tt.Show("请填写信息，如无法确定信息，则填\"无\"即可。", t, 5000);
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (Forms.BaseDataManage.Form_Photo frm = new Forms.BaseDataManage.Form_Photo(17, this.entity.Id))
            {
                if (this.FSE == FormStatusEnum.Edit)
                {
                    SetControls.SetControlReadonly(frm, false);
                    frm.ShowDialog();
                }
                else if (this.FSE == FormStatusEnum.New)
                {
                    MessageBox.Show("请在\"品种质量档案维护\"版块内进行上传图片");
                    return;
                }
                else
                {
                    SetControls.SetControlReadonly(frm, true);
                    frm.ShowDialog();
                }
            }
        }

    }

}
