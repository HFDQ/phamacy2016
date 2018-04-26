using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormSalePriceControlRules : BaseFunctionForm
    {
        string msg = string.Empty;
        public FormSalePriceControlRules()
        {
            InitializeComponent();

            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            SalePriceControlRulesModel m = this.PharmacyDatabaseService.GetSalePriceControlRules(out msg);

            if (m.RuleType == 0)
            {
                m = new SalePriceControlRulesModel
                {
                     RuleType=0,
                     Description = "在销售开票界面中，控制销售价不得低于采购价。客户端销售开票时，药品选择界面中定义的价格无效，以采购价显示当前药品的销售价，销售价格不得低于采购价格，否则无法开票销售。请注意，销售价格不得低于本公司对该品种定义的最低销售价格。",
                     RuleName = Models.SalePriceControlEnum.不低于采购价.ToString(),
                      SalesOrderPrintRuleValue=m.SalesOrderPrintRuleValue
                };
                this.label2.Text = m.Description;
            }

            var c=EnumToListHelper.ConverEnumToList(typeof(Models.SalePriceControlEnum));
            
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DataSource = c.OrderBy(r=>r.Id).ToList();
            this.comboBox1.SelectedIndex = m.RuleType;
            this.label2.Text = m.Description;            
            if (m.RuleType == (int)Models.SalePriceControlEnum.不高于最高定价)
            {
                this.textBox1.Enabled = true;
                this.textBox1.Text = m.RuleRate.ToString();
            }

            var p = EnumToListHelper.ConverEnumToList(typeof(EnumSalesOrderPrintRule));
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.ValueMember = "Id";
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.DataSource = p;
            this.comboBox2.SelectedValue =(int) m.SalesOrderPrintRuleValue;

            #region 控价规则选择
            this.comboBox1.SelectedIndexChanged += (s, e) =>
                {
                    var idx = this.comboBox1.SelectedIndex;

                    if (idx == 0) this.label2.Text = "在销售开票界面中，控制销售价不得低于采购价。客户端销售开票时，药品选择界面中定义的价格无效，以采购价显示当前药品的销售价，销售价格不得低于采购价格，否则无法开票销售。请注意，销售价格不得低于本公司对该品种定义的最低销售价格。";
                    if (idx == 1) this.label2.Text = "在销售开票界面中，以药品选择界面中定义的销售价显示当前价格，可低于采购价销售。请注意，销售价格不得低于本公司对于该品种定义的最低销售价格。";
                    if (idx == 2)
                    {
                        this.label2.Text = "在销售开票界面，以采购价的N倍比例显示当前药品销售价格，可以在文本框中填写该比例。药品选择界面中定义的销售价格无效。本规则可低于采购价销售，但不能高于最高定价。请注意，销售价格不得低于本公司对于该品种定义的最低销售价格。";
                    }
                    this.textBox1.Enabled = idx == 2;
                }; 
            #endregion

            //保存
            #region 保存
            this.toolStripButton1.Click += (s, e) =>
                {
                    var re = MessageBox.Show("确定需要保存销售价格控制规则吗？", "提示", MessageBoxButtons.OKCancel);
                    if (re == System.Windows.Forms.DialogResult.Cancel) return;
                    m.RuleType = this.comboBox1.SelectedIndex;
                    m.RuleName = ((Models.SalePriceControlEnum)(this.comboBox1.SelectedIndex)).ToString();
                    m.Description = this.label2.Text;
                    m.SalesOrderPrintRuleValue = (EnumSalesOrderPrintRule)this.comboBox2.SelectedValue;

                    decimal rate = 1m;
                    if (m.RuleType == (int)Models.SalePriceControlEnum.不高于最高定价)
                    {
                        if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
                        {
                            MessageBox.Show("该规则需要您填写比例！");
                            this.textBox1.Focus();
                            return;
                        }

                        if (!decimal.TryParse(this.textBox1.Text.Trim(), out rate))
                        {
                            MessageBox.Show("请输入比例！"); return;
                        }
                        m.RuleRate = rate;
                    }


                    if (this.PharmacyDatabaseService.SaveSalePriceControlRules(m, out msg))
                    {
                        MessageBox.Show("销售价格控制规则保存成功！请注意设定品种价格或者最低价格等信息！");
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "保存销售价格控制规则成功！");
                    }
                    else
                    {
                        MessageBox.Show("信息保存失败，异常信息：\n" + msg);
                    }
                }; 
            #endregion
        }
    }
}
