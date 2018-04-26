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
    public partial class FormWareHouseZonePositionEdit : BaseFunctionForm
    {
        string msg = string.Empty;
        public FormWareHouseZonePositionEdit()
        {
            InitializeComponent();
        }

        public FormWareHouseZonePositionEdit(List<Models.Warehouse> w, List<Models.WarehouseZone> wz, Business.Models.WareHouseZonePositionModel wzp):this()
        {
            #region 绑定货位
            var rc = wzp.RowCol.Split('，');
            int row = int.Parse(rc[0].Substring(1, rc[0].Length - 2));
            int col = int.Parse(rc[1].Substring(1, rc[1].Length - 2));
            PositionRowCol prc = new PositionRowCol
            {
                Capacity = wzp.Capacity,
                Row = row,
                Col = col,
                NamePrefix = wzp.Name
            };
            this.textBox1.DataBindings.Add("Text", prc, "Row");
            this.textBox2.DataBindings.Add("Text", prc, "Col");
            this.textBox3.DataBindings.Add("Text", prc, "NamePrefix");
            this.textBox4.DataBindings.Add("Text", prc, "Capacity");
            #endregion

            #region 绑定仓库，货架
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.DataSource = w;
            this.comboBox1.SelectedValue = wzp.WareHouseId;

            Action<object, EventArgs> Combo1SelectedIndexChanged = (sender, ex) =>
            {
                this.comboBox2.ValueMember = "Id";
                this.comboBox2.DisplayMember = "Name";
                var u=wz.Where(r => r.WarehouseId == (Guid)this.comboBox1.SelectedValue).ToList();
                this.comboBox2.DataSource = u;
                if (u.FirstOrDefault(r => r.Id == wzp.Id) == null)
                {
                    this.comboBox2.SelectedIndex = 0;
                }
                else
                {
                    this.comboBox2.SelectedValue = wzp.WareHouseZoneId;
                }

            };

            Combo1SelectedIndexChanged(null, null);

            this.comboBox1.SelectedIndexChanged += (sender, e) => Combo1SelectedIndexChanged(sender, e);
            #endregion
            
            #region 提交修改
            this.button1.Click += (sender, e) =>
            {
                if (string.IsNullOrEmpty(prc.NamePrefix))
                {
                    MessageBox.Show("货位名称不能为空"); return;
                }
                if (prc.Row<=0||prc.Col<=0)
                {
                    MessageBox.Show("货位行或列不得小于或等于0"); return;
                }
                var re=MessageBox.Show("确定需要更改该货位信息吗？","提示",MessageBoxButtons.OKCancel);
                if (re == System.Windows.Forms.DialogResult.Cancel) return;

                var c=this.PharmacyDatabaseService.GetWarehouseZonePositionById(wzp.Id ,out msg);

                if (c== null)
                {
                    MessageBox.Show("数据库发生错误，请联系管理员！"); return;
                }

                c.RowCol = "第" + prc.Row + "层，第" + prc.Col.ToString() + "列";
                c.Name = prc.NamePrefix;
                c.WareHouseZoneId = (Guid)this.comboBox2.SelectedValue;
                c.Capacity = prc.Capacity;

                var sub=new List<Models.WareHouseZonePosition>();
                sub.Add(c);
                var b = this.PharmacyDatabaseService.SaveWareHouseZonePosition(sub,out msg);

                if (b)
                {
                    MessageBox.Show("提交成功！");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("提交失败，请联系管理员！");
                }
            };
            #endregion

            #region 关闭窗口
            this.button2.Click += (sender, e) =>
            {
                this.Close();
            };
            #endregion
        }
    }
}
