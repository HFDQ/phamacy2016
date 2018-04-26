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

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class FormGoodsAdditionalProperty : Form
    {
        public FormGoodsAdditionalProperty(FormRunMode runMode, DrugInfo drugInfo, GoodsAdditionalProperty goodsAdditional)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                this.RunMode = runMode;
                GoodsAdditional = goodsAdditional;
                if (GoodsAdditional == null)
                {
                    throw new ArgumentNullException("商品附加属性不可为空");
                }
                this.DrugInfo = drugInfo; 
                if (drugInfo == null)
                {
                    throw new ArgumentNullException("商品属性不可为空");
                } 
                this.ucGoodsAdditionalProperty1.DrugInfo = this.DrugInfo;
                this.ucGoodsAdditionalProperty1.GoodsAdditional = this.GoodsAdditional;
                this.FormClosing += new FormClosingEventHandler(FormGoodsAdditionalProperty_FormClosing);
            }  
        }

        void FormGoodsAdditionalProperty_FormClosing(object sender, FormClosingEventArgs e)
        {
            string b = UI.RequiredFieldsCheck<GoodsAdditionalProperty>.CheckRequiredFields(this.GoodsAdditional);
            if (!string.IsNullOrEmpty(b))
            {
                MessageBox.Show("您选择的商品类型为非国产药品和进口药品，字段：" + b + ",为必填项，请点击“编辑”按钮填写完整信息!");
                e.Cancel = true;
            }
        } 
      

        #region 属性与字段

        [Browsable(false)]
        public GoodsAdditionalProperty GoodsAdditional 
        {
            get
            {
                if (this.ucGoodsAdditionalProperty1 != null)
                {
                    return this.ucGoodsAdditionalProperty1.GoodsAdditional;
                }
                return null;
            }
            set
            {
                if (this.ucGoodsAdditionalProperty1 != null)
                {
                    this.ucGoodsAdditionalProperty1.GoodsAdditional = value;
                }
            }
        }

        private DrugInfo drugInfo;

        /// <summary>
        /// 当前药物信息
        /// </summary>
        [Browsable(false)]
        public DrugInfo DrugInfo
        {
            get 
            {
               
                return drugInfo; 
            }
            set
            {
                if (DesignMode) return;  
                drugInfo = value;
            }
        }

        private FormRunMode runMode;

        /// <summary>
        /// 窗口运行模式
        /// </summary>
        [Browsable(false)]
        public FormRunMode RunMode
        {
            get
            {
                return runMode;
            }
            set
            {
                runMode = value;
                if (runMode == FormRunMode.Add)
                {
                    this.Text = string.Format("{0}药物信息", "添加"); 
                }
                else if (runMode == FormRunMode.Edit)
                {
                    this.Text = string.Format("{0}药物信息", "编辑");
                }
                else if (runMode == FormRunMode.Browse)
                {
                    this.Text = string.Format("{0}药物信息", "查看");
                } 
            }
        }

        #endregion 

        private void FormGoodsAdditionalProperty_Load(object sender, EventArgs e)
        {
          
        }

        private void FormGoodsAdditionalProperty_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
