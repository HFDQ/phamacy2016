using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DataDictionary
{
    /// <summary>
    /// 与药物相关数据字典管理首页(将从菜单直接点开显示到frmMain的Tab选项卡区域)
    /// 界面上以Tab选项卡方式加载药物相关数据字典管理的界面
    /// 药物数据库管理数据界面列表
    /// 1.
    /// </summary>
    public partial class FormDrugDictionaryIndex : BaseFunctionForm
    {
        public FormDrugDictionaryIndex()
        {
            InitializeComponent();
        }

        private void dockPanel_ActiveContentChanged(object sender, EventArgs e)
        {

        }
    }
}
