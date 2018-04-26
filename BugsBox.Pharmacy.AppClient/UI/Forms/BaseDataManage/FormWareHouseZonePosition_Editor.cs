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
    public partial class FormWareHouseZonePosition_Editor : BaseFunctionForm
    {
        string msg = string.Empty;


        public FormWareHouseZonePosition_Editor(List<Models.Warehouse> w, List<Models.WarehouseZone> wz)
        {
            InitializeComponent();

            PositionRowCol prc = new PositionRowCol
            {
                NamePrefix = "货位"
            };
            this.textBox1.DataBindings.Add("Text", prc, "Row");
            this.textBox2.DataBindings.Add("Text", prc, "Col");
            this.textBox3.DataBindings.Add("Text", prc, "NamePrefix");
            this.textBox4.DataBindings.Add("Text", prc, "Capacity");

            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.DataSource = w;
            this.comboBox1.SelectedIndex = 0;

            this.comboBox1.SelectedIndexChanged += (sender, e) =>
            {
                this.comboBox2.ValueMember = "Id";
                this.comboBox2.DisplayMember = "Name";
                this.comboBox2.DataSource = wz.Where(r => r.WarehouseId == (Guid)this.comboBox1.SelectedValue).OrderBy(r => r.Name).ToList();
            };
            #region 按钮事件
            this.button2.Click += (sender, e) =>
            {
                this.Dispose();
            };

            #region 提交事件
            this.button1.Click += (sender, e) =>
            {
                #region 提交前检查
                this.button1.Enabled = !this.button1.Enabled;
                this.Validate();

                if ((Guid)this.comboBox1.SelectedValue == Guid.Empty)
                {
                    MessageBox.Show("请选择仓库！");
                    this.button1.Enabled = !this.button1.Enabled;
                    return;
                }
                if ( this.comboBox2.SelectedValue==null|| (Guid)this.comboBox2.SelectedValue == Guid.Empty)
                {
                    MessageBox.Show("请选择货架！");
                    this.button1.Enabled = !this.button1.Enabled;
                    return;
                }

                if (prc.Row <= 0)
                {
                    MessageBox.Show("请设定货架层数！");
                    this.button1.Enabled = !this.button1.Enabled;
                    return;
                }
                if (prc.Col <= 0)
                {
                    MessageBox.Show("请设定货架列数！");
                    this.button1.Enabled = !this.button1.Enabled;
                    return;
                }
                #endregion

                if (MessageBox.Show("确定要批量新增库位吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.button1.Enabled = !this.button1.Enabled;
                    return;
                }

                List<Models.WareHouseZonePosition> ListPositions = new List<Models.WareHouseZonePosition>();
                Models.WareHouseZonePosition p = null;
                int count = 0;
                for (int i = 0; i < prc.Row; i++)
                {
                    for (int j = 0; j < prc.Col; j++)
                    {
                        count++;
                        p = new Models.WareHouseZonePosition
                        {
                            Id = Guid.NewGuid(),
                            Capacity = prc.Capacity,
                            CreateUserId = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id,
                            Deleted = false,
                            Memo = ((Models.WarehouseZone)this.comboBox2.SelectedItem).Name,
                            Name = prc.NamePrefix + (i + 1).ToString() + "层" + (j + 1).ToString() + "列",
                            PIndex = count,
                            RowCol = "第" + (i + 1) + "层，第" + (j + 1).ToString() + "列",
                            UpdateUserId = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id,
                            WareHouseZoneId = (Guid)this.comboBox2.SelectedValue
                        };
                        ListPositions.Add(p);
                    }
                }

                bool b = this.PharmacyDatabaseService.AddWareHouseZonePositions(ListPositions.ToArray(), out msg);

                if (b)
                {
                    MessageBox.Show("批量操作成功！");
                    this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "批量新增库位，所属货架：" + ((Models.WarehouseZone)this.comboBox2.SelectedItem).Name);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("批量操作失败，请联系管理员！");
                    this.button1.Enabled = !this.button1.Enabled;
                }
            };
            #endregion
            #endregion
        }
    }

    public class PositionRowCol
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public string NamePrefix { get; set; }

        public decimal Capacity { get; set; }
    }
}
