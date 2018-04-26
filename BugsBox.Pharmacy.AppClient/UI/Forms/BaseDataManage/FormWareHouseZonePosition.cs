using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.UI;
using bpac;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormWareHouseZonePosition : BaseFunctionForm
    {
        string msg = string.Empty;

        BugsBox.Pharmacy.AppClient.UI.Ele_Lab EleModel = null;

        BugsBox.Pharmacy.UI.Common.BaseRightMenu RightMenu;

        public FormWareHouseZonePosition()
        {
            InitializeComponent();

            #region 右键打印单条货位条码
            RightMenu = new Pharmacy.UI.Common.BaseRightMenu(this.dataGridView1);
            RightMenu.InsertMenuItem("打印该货位的条码", delegate()
            {
                var re = MessageBox.Show("需要打印该行货位条码码？", "提示", MessageBoxButtons.OKCancel);
                if (re == System.Windows.Forms.DialogResult.Cancel) return;

                if (!System.IO.File.Exists("resources\\名称.lbx"))
                {
                    MessageBox.Show("条码打印模板文件不存在，请增加一个！");
                    return;
                }

                bpac.DocumentClass doc = new DocumentClass();

                doc.Open("resources\\名称.lbx");

                Business.Models.WareHouseZonePositionModel m = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.WareHouseZonePositionModel;
                doc.GetObject("Title").Text = m.WareHouseZoneName + "  " + m.Name;
                doc.SetBarcodeData(0, m.BarCode);
                doc.StartPrint("", PrintOptionConstants.bpoDefault);
                doc.PrintOut(1, PrintOptionConstants.bpoDefault);

                doc.EndPrint();
                doc.Close();
            });
            #endregion

            this.EleModel = SearialiserHelper<Ele_Lab>.DeSerializeFileToObj("EleSetup.bin");
            if (this.EleModel.IsEnabled)
            {
                if (elelab.unart_manage.com_manage.FirstOrDefault() == null)
                {
                    int[] ss = new int[] { int.Parse(this.EleModel.PortName.Substring(3)) };
                    elelab.unart_manage.init_com_sys(ss);
                }
            }
            this.button2.Visible = this.EleModel.IsEnabled;

            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            #region 插入仓库数据到combo和事件
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            var w = this.PharmacyDatabaseService.AllWarehouses(out msg).Where(r => r.Deleted == false).OrderBy(r => r.Name).ToList();
            w.Insert(0, new Models.Warehouse
            {
                Name = "全部",
                Id = Guid.Empty,
            });
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.DataSource = w;
            this.comboBox1.SelectedIndex = 0;

            var wz = this.PharmacyDatabaseService.AllWarehouseZones(out msg).Where(r => r.Deleted == false).OrderBy(r => r.Name).ToList();
            var wzt = new List<Models.WarehouseZone>();
            wzt.Add(
                new Models.WarehouseZone
                {
                    Name = "全部",
                    Id = Guid.Empty,
                });

            this.comboBox2.ValueMember = "Id";
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.DataSource = wzt;
            this.comboBox2.SelectedIndex = 0;

            this.comboBox1.SelectedIndexChanged += (sender, e) =>
            {
                var wzs = wz.Where(r => r.WarehouseId == (Guid)this.comboBox1.SelectedValue).OrderBy(r => r.Name).ToList();

                wzs.Insert(0, new Models.WarehouseZone
                {
                    Name = "全部",
                    Id = Guid.Empty,
                });
                this.comboBox2.ValueMember = "Id";
                this.comboBox2.DisplayMember = "Name";
                this.comboBox2.DataSource = wzs;
                this.comboBox2.SelectedIndex = 0;
            };
            #endregion


            //批量创建
            this.toolStripButton2.Click += (sender, e) =>
            {
                FormWareHouseZonePosition_Editor frm = new FormWareHouseZonePosition_Editor(w, wz);
                frm.Show(this);
            };

            #region 修改ACTION
            Action<object, EventArgs> EditPostionAction = (sender, e) =>
            {
                if (this.dataGridView1.CurrentRow == null) return;
                var c = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.WareHouseZonePositionModel;
                using (FormWareHouseZonePositionEdit frm = new FormWareHouseZonePositionEdit(w, wz, c))
                {
                    var re = frm.ShowDialog();
                    if (re == System.Windows.Forms.DialogResult.OK)
                    {
                        this.toolStripButton1_Click(null, null);
                    }
                }
            };
            #endregion

            //修改
            this.toolStripButton3.Click += (sender, e) => EditPostionAction(sender, e);
            //Datagridview双击修该货位
            this.dataGridView1.CellDoubleClick += (sender, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                EditPostionAction(null, null);
            };

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var c = this.PharmacyDatabaseService.GetWareHouseZonePositionById(new Business.Models.WareHouseZonePositionQueryModel
            {
                Keyword = this.textBox1.Text.Trim(),
                WareHouseId = (Guid)this.comboBox1.SelectedValue,
                WareHouseZoneId = (Guid)this.comboBox2.SelectedValue,
            },
            out msg);

            this.dataGridView1.DataSource = c.ToList();

            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["WareHouseId"].Visible = false;
            this.dataGridView1.Columns["WareHouseZoneId"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.toolStripButton1_Click(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow == null) return;
            if (MessageBox.Show("确定删除该记录？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;

            var c = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.WareHouseZonePositionModel;
            List<Guid> ListPWaitForDeleting = new List<Guid>();
            ListPWaitForDeleting.Add(c.Id);
            bool b = this.PharmacyDatabaseService.DeleteWareHouseZonePostion(ListPWaitForDeleting, out msg);
            if (b)
            {
                MessageBox.Show("成功删除货位记录一条");
                this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "成功删除货位记录一条，名称为：" + c.Name);
                this.toolStripButton1_Click(sender, e);
            }
            else
            {
                MessageBox.Show("删除失败！请联系管理员");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            List<string> ListPorts = System.IO.Ports.SerialPort.GetPortNames().OrderBy(r => r).ToList();
            if (ListPorts.Count <= 0)
            {
                MessageBox.Show("请检查串口USB连接，或者其驱动是否正常！");
                return;
            }
            using (FormWareHouseZonePosition_EleLabSetup frm = new FormWareHouseZonePosition_EleLabSetup(this.EleModel))
            {
                var re = frm.ShowDialog();
                if (re == System.Windows.Forms.DialogResult.OK)
                    this.EleModel = frm.EleModel;
            }
        }

        //点亮测试
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            byte Port = byte.Parse(this.EleModel.PortName.Substring(3));

            var c = this.dataGridView1.DataSource as List<Business.Models.WareHouseZonePositionModel>;

            List<string> LabelId = new List<string>();
            List<string> LabelAddress = new List<string>();
            List<string> labelNumber = new List<string>();
            foreach (var r in c)
            {
                LabelId.Add(r.WareHouseZonePIndex.ToString());
                LabelAddress.Add(r.PIndex.ToString());
                labelNumber.Add("8");
            }

            elelab.pick.make_data(null, this.EleModel.TestLed, 2, Port, LabelId.ToArray(), LabelAddress.ToArray(), labelNumber.ToArray());
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "货位查询列表");
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            var re = MessageBox.Show("需要打印列表中的货位条码码？", "提示", MessageBoxButtons.OKCancel);
            if (re == System.Windows.Forms.DialogResult.Cancel) return;

            if (!System.IO.File.Exists("resources\\名称.lbx"))
            {
                MessageBox.Show("条码打印模板文件不存在，请增加一个！");
                return;
            }

            bpac.DocumentClass doc = new DocumentClass();

            doc.Open("resources\\名称.lbx");
            
            foreach (DataGridViewRow i in this.dataGridView1.Rows)
            {
                Business.Models.WareHouseZonePositionModel m = i.DataBoundItem as Business.Models.WareHouseZonePositionModel;
                doc.GetObject("Title").Text = m.WareHouseZoneName + "  " + m.Name;
                
                doc.SetBarcodeData(0, m.BarCode);
                doc.StartPrint("", PrintOptionConstants.bpoHalfCut);
                doc.PrintOut(1,  PrintOptionConstants.bpoHalfCut|PrintOptionConstants.bpoChainPrint);
            }
            
            doc.EndPrint();
            doc.Close();
        }


    }
}
