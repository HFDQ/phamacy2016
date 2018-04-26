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
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.UI.Common.Helper;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugBusiness
{
    public partial class FormDoubtDrugEdit : BaseFunctionForm
    {
        /// <summary>
        /// 运行模式
        /// </summary>
        public FormRunMode Mode { get; private set; }

        private bool DataToServerReady { get; set; }


        /// <summary>
        ///  如果是编辑和浏览模式必须设置
        ///  不为null的doubtDrug
        /// </summary>
        /// <param name="mode">运行模式</param>
        /// <param name="doubtDrug"></param>
        public FormDoubtDrugEdit(FormRunMode mode, DoubtDrug doubtDrug)
        {
            InitializeComponent();
            if (DesignMode) return;
            Mode = mode;
            if (Mode == FormRunMode.Browse
                || Mode == FormRunMode.Edit)
            {
                throw new ArgumentNullException("浏览模式与编辑模式药物疑问对象不可为null");
            }
            SetControlsStatus();
            CurrentDoubtDrug = doubtDrug;
            switch (mode)
            {
                case FormRunMode.Edit:
                    this.Text = "疑问药品编辑";
                    break;
                case FormRunMode.Browse:
                    this.Text = "疑问药品浏览";
                    break;
                case FormRunMode.Add:
                    this.Text = "疑问药品添加";
                    break;
            }
        }

        /// <summary>
        /// 默认为添加模式
        /// </summary>
        public FormDoubtDrugEdit()
            : this(FormRunMode.Add,new DoubtDrug())
        {
            
        }


        /// <summary>
        /// 当前药物库存
        /// </summary>
        private DrugInventoryRecord currentDrugInventoryRecord;

        private DoubtDrug currentDoubtDrug;

        public DoubtDrug CurrentDoubtDrug
        {
            get { return currentDoubtDrug; }
            set
            {
                currentDoubtDrug = value;
                if (currentDoubtDrug != null)
                {
                    if (!DesignMode)
                    {
                        if (Mode == FormRunMode.Add)
                        {
                            currentDoubtDrug.CreateTime = DateTime.Now;
                            currentDoubtDrug.CreateUserId = AppClientContext.CurrentUser.Id;
                            currentDoubtDrug.Decription = "请您输入疑问描述...";
                            currentDoubtDrug.Deleted = false;
                            currentDoubtDrug.Id = Guid.NewGuid();
                            currentDoubtDrug.UpdateTime = currentDoubtDrug.CreateTime;
                            currentDoubtDrug.UpdateUserId = currentDoubtDrug.CreateUserId;
                            currentDoubtDrug.HandleDecription = "还未处理";
                            //currentDoubtDrug.Handled = false;//To Do
                        }
                        BindDoubtDrug();
                        CurrentDrugInventoryRecord = currentDoubtDrug.DrugInventoryRecord;
                    }
                }
            }
        }

        /// <summary>
        /// 当前药物库存
        /// </summary>
        public DrugInventoryRecord CurrentDrugInventoryRecord
        {
            get { return currentDrugInventoryRecord; }
            set
            {
                currentDrugInventoryRecord = value;
                if (currentDrugInventoryRecord != null)
                {
                    if (!DesignMode)
                    {
                        BindDrugInfo();
                        BindDrugInventoryRecord();
                    }
                }
            }
        }

        #region 从服务端获取数据

        #endregion 从服务端获取数据

        #region 数据到服务端

        #endregion 数据到服务端

        #region 控件到数据

        /// <summary>
        /// 收集疑问信息
        /// </summary>
        private void CollectDrugInfos()
        {
            DataToServerReady = false;
            try
            {
                if (CurrentDrugInventoryRecord == null)
                {
                    //MessageBox.Show("请选择药物库存!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show(this.Text+"请选择药物库存!","错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                string description = this.textBoxDoubtDrugDecription.Text.Trim();
                CurrentDoubtDrug.Decription = description;
                if (DataToServerReady == !string.IsNullOrWhiteSpace(description))
                {
                    this.textBoxDoubtDrugDecription.Focus();
                    //MessageBox.Show("请您输入[疑问信息]!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show( this.Text+"请您输入[疑问信息]!","错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                currentDoubtDrug.DrugInventoryRecordId = CurrentDrugInventoryRecord.Id;
                currentDoubtDrug.JsonDrugInventoryRecord = CurrentDrugInventoryRecord.ToJson();
                DataToServerReady = true;
                
            }
            catch (Exception ex)
            {
                DataToServerReady = false;
                ex = new Exception("收集疑问信息失败" + ex.Message, ex);
                Log.Error(ex);
            }
        }

        #endregion 控件到数据

        #region 数据到控件

        #endregion 设置控件状态

        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlsStatus()
        {
            if (DesignMode) return;
            try
            {
                this.ucGoodsInfo1.RunMode = FormRunMode.Browse;
                switch (Mode)
                {
                    case FormRunMode.Add: 
                        textBoxDoubtDrugDecription.Enabled = true;
                        buttonCancel.Enabled = true;
                        buttonCancel.Enabled = true;
                        buttonSelectDrugInventoryRecord.Enabled = true;
                        break; 
                    case FormRunMode.Edit:
                        textBoxDoubtDrugDecription.Enabled = true;
                        buttonCancel.Enabled = true;
                        buttonCancel.Enabled = true;
                        buttonSelectDrugInventoryRecord.Enabled = false;
                        break; 
                    case FormRunMode.Browse:
                        textBoxDoubtDrugDecription.Enabled = false;
                        buttonCancel.Enabled = false;
                        buttonCancel.Enabled = false;
                        buttonSelectDrugInventoryRecord.Enabled = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                ex = new Exception("设置控件状态失败" + ex.Message, ex);
                Log.Error(ex);
            }
        }

        #region 设置控件状态

        /// <summary>
        /// 绑定疑问信息
        /// </summary>
        private void BindDoubtDrug()
        {
            try
            {
                textBoxDoubtDrugDecription.Text = CurrentDoubtDrug.Decription;
                string message;
                textBoxDoubtEmployee.Text = PharmacyDatabaseService.GetUser(out message, CurrentDoubtDrug.CreateUserId).Employee.Name;
            }
            catch (Exception ex)
            {
                ex = new Exception("绑定疑问信息失败");
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 绑定药物库存关联的药物失败
        /// </summary>
        private void BindDrugInfo()
        {
            try
            {
                if (currentDrugInventoryRecord != null && currentDrugInventoryRecord.DrugInfo != null)
                    ucGoodsInfo1.DrugInfo = currentDrugInventoryRecord.DrugInfo;
            }
            catch (Exception ex)
            {
                ex = new Exception("绑定药物库存关联的药物失败");
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 绑定库存信息
        /// </summary>
        private void BindDrugInventoryRecord()
        {
            try
            {
                if (currentDrugInventoryRecord== null) return;
                labelDurgInventoryType.Text = string.Format("{0}",
                    EnumHelper<DurgInventoryType>.GetDisplayValue((DurgInventoryType)currentDrugInventoryRecord.DurgInventoryTypeValue));
                label1BatchNumber.Text = string.Format("{0}", currentDrugInventoryRecord.BatchNumber);
                label1PruductDate.Text = string.Format("{0}", currentDrugInventoryRecord.PruductDate);
                labelOutValidDate.Text = string.Format("{0}", currentDrugInventoryRecord.OutValidDate);
                labelInInventoryCount.Text = string.Format("{0}", currentDrugInventoryRecord.InInventoryCount);
                labelCurrentInventoryCount.Text = string.Format("{0}", currentDrugInventoryRecord.CurrentInventoryCount);
                labelSalesCount.Text = string.Format("{0}", currentDrugInventoryRecord.SalesCount);
                labelRetailCount.Text = string.Format("{0}", currentDrugInventoryRecord.RetailCount);
                labelDismantingAmount.Text = string.Format("{0}", currentDrugInventoryRecord.DismantingAmount);
                labelRetailDismantingAmount.Text = string.Format("{0}", currentDrugInventoryRecord.RetailDismantingAmount);
                labelCanSaleNum.Text = string.Format("{0}", currentDrugInventoryRecord.CanSaleNum);
            }
            catch (Exception ex)
            {
                ex = new Exception("绑定药物库存信息失败");
                Log.Error(ex);
            }
        }

        #endregion

        #region 事件处理

        private void buttonSelectDrugInventoryRecord_Click(object sender, EventArgs e)
        { 
            if (Mode != FormRunMode.Add) return;
            try
            {
                var form = new FormAllDrugInventoryRecordSelector();
                form.ShowInTaskbar = false;
                form.SelectMode = SelectMode.Single;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK
                    && form.SelectedDrugInventoryRecords != null
                    && form.SelectedDrugInventoryRecords.Count == 1)
                {
                    CurrentDrugInventoryRecord = form.SelectedDrugInventoryRecords.FirstOrDefault();
                } 
            }
            catch (Exception ex)
            {

                Log.Error(ex);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                 
                CollectDrugInfos();
                if (!DataToServerReady)
                {
                    //MessageBox.Show("您的输入信息有错误!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show(this.Text+"您的输入信息有错误!","错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                string message = string.Empty;
                bool result = false;
                switch (Mode)
                {
                    case FormRunMode.Add:
                        result=PharmacyDatabaseService.AddDoubtDrug(out message, CurrentDoubtDrug);
                        //添加处理
                        //List<DrugInventoryRecord> DrugInventoryRecords = new List<DrugInventoryRecord>();
                        //DrugInventoryRecord DrugInventoryRecord = DrugInventoryRecords.Where(d => d.Id == currentDoubtDrug.DrugInventoryRecordId).First();
                        break;
                    case FormRunMode.Edit:
                        result=PharmacyDatabaseService.SaveDoubtDrug(out message, CurrentDoubtDrug); 
                        //编辑处理
                        break;
                }
                if (result && string.IsNullOrWhiteSpace(message))
                {
                    //MessageBox.Show("保存疑问成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(this.Text+"保存疑问成功","错误" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("保存疑问失败" + message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show(this.Text+"保存疑问失败" + message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
              
            }
            catch (Exception ex)
            {
               ex = new Exception("保存疑问失败"+ex.Message,ex);
               Log.Error(ex);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        #endregion 事件处理
    }
}
