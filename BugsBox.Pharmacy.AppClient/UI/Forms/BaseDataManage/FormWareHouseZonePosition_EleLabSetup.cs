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
    public partial class FormWareHouseZonePosition_EleLabSetup : Form
    {
        public Ele_Lab EleModel = null;
        public FormWareHouseZonePosition_EleLabSetup(Ele_Lab eleModel)
        {
            InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            if (eleModel == null)
            {
                eleModel = new Ele_Lab
                {
                    IsEnabled = false,
                    PortName = string.Empty,
                    IsNormal = false,
                    PickGoodsLed = 1,
                    PurchaseInInventoryLed = 2,
                    TestLed = 3
                };
            }

            List<string> ListPorts = System.IO.Ports.SerialPort.GetPortNames().OrderBy(r => r).ToList();
            this.comboBox1.DataSource = ListPorts;

            if (ListPorts.Count <= 0)
            {
                MessageBox.Show("请检查串口USB连接，或者其驱动是否正常！");
                this.Close();
                return;
            }
            if (eleModel.IsNormal)
            {
                this.comboBox1.SelectedItem = eleModel.PortName;
                this.checkBox1.Checked = eleModel.IsEnabled;
            }
            else
            {
                this.comboBox1.SelectedIndex = 0;
            }

            var c1=BugsBox.Pharmacy.AppClient.UI.EnumToListHelper.ConverEnumToList(typeof(LedColorEnum)).OrderBy(r=>r.Id).ToList();
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.ValueMember = "Id";
            this.comboBox2.DataSource = c1;
            this.comboBox2.SelectedValue = eleModel.PickGoodsLed;

            var c2 = BugsBox.Pharmacy.AppClient.UI.EnumToListHelper.ConverEnumToList(typeof(LedColorEnum)).OrderBy(r => r.Id).ToList();
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.ValueMember = "Id";
            this.comboBox3.DataSource = c2;
            this.comboBox3.SelectedValue = eleModel.PurchaseInInventoryLed;

            var c3 = BugsBox.Pharmacy.AppClient.UI.EnumToListHelper.ConverEnumToList(typeof(LedColorEnum)).OrderBy(r => r.Id).ToList();
            this.comboBox4.DisplayMember = "Name";
            this.comboBox4.ValueMember = "Id";
            this.comboBox4.DataSource = c3;
            this.comboBox4.SelectedValue = eleModel.TestLed;

            #region 事件
            this.button1.Click += (sender, e) =>
            {
                this.Validate();

                if (ListPorts.Count <= 0)
                {
                    MessageBox.Show("请检查COM串口连接，或者其驱动是否正常！");
                    return;
                }

                eleModel.PortName = this.comboBox1.SelectedValue.ToString();
                eleModel.IsEnabled = this.checkBox1.Checked;
                eleModel.IsNormal = true;

                eleModel.PickGoodsLed = byte.Parse(this.comboBox2.SelectedValue.ToString());
                eleModel.PurchaseInInventoryLed = byte.Parse(this.comboBox3.SelectedValue.ToString());
                eleModel.TestLed = byte.Parse(this.comboBox4.SelectedValue.ToString());

                var b = BugsBox.Pharmacy.AppClient.UI.SearialiserHelper<BugsBox.Pharmacy.AppClient.UI.Ele_Lab>.SerializeObjToFile(eleModel, "EleSetup.bin");
                if (b)
                {
                    MessageBox.Show("保存成功！");
                    this.EleModel = eleModel;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            };

            this.button2.Click += (sender, e) =>
            {
                this.Dispose();
            };
            #endregion
        }
    }
    public enum LedColorEnum
    {
        红=1,
        绿=2,
        兰=3,
        红闪=4,
        绿闪=5,
        兰闪=6,
    }
}
