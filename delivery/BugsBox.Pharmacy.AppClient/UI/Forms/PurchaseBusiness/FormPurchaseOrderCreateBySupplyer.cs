using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Models;
using System.Xml;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormPurchaseOrderCreateBySupplyer : BaseFunctionForm
    {
        string msg = string.Empty;
        DataTable _dt = new DataTable();
        BindingList<DrugInfo> bList = new BindingList<DrugInfo>();
        public List<DrugInfo> list = new List<DrugInfo>();
        BindingList<DrugInfo> addBL = new BindingList<DrugInfo>();
        List<SupplyUnit> listSupplyer = new List<SupplyUnit>();
        public string Supplyer = string.Empty;
        public string SupplyerID = string.Empty;
        private int supplyDrugType = -1;

        public delegate void SubmitEventHandler(object sender, SubmitEventArgs e);
        public event SubmitEventHandler submitEvent;

        public Common.GoodsTypeClass GoodsType { get; set; }

        public class SubmitEventArgs : EventArgs
        {
            public readonly List<DrugInfo> listDrug;
            public PurchaseDrugTypes PDrugType { get; set; }
            public SubmitEventArgs(List<DrugInfo> listDrug)
            {
                this.listDrug = listDrug;
            }
        }

        protected virtual void onSubmit(SubmitEventArgs e)
        {
            if (submitEvent != null)
            {
                submitEvent(this, e);
            }
        }

        public FormPurchaseOrderCreateBySupplyer()
        {
            InitializeComponent();
            _dt.Columns.Add("id", typeof(System.Guid));
            _dt.Columns.Add("py", typeof(string));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.DataSource = addBL;
        }

        /// <summary>
        /// 初始化方法2
        /// </summary>
        /// <param name="SupplyID"></param>
        public FormPurchaseOrderCreateBySupplyer(Guid SupplyID)
            : this()
        {
            if (SupplyID != null && SupplyID != Guid.Empty)
            {
                this.SupplyerID = SupplyID.ToString();
            }
        }


        private void FormPurchaseOrderCreateBySupplyer_Load(object sender, EventArgs e)
        {
            var all = PharmacyDatabaseService.AllSupplyUnits(out msg);
            listSupplyer = all.Where(r => r.Valid).ToList();


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string msg = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml");
                XmlNode xmlNode = doc.SelectSingleNode("SalePriceType/SupplyDrugType");
                if (xmlNode == null)
                {
                    XmlNode SPTNode = doc.SelectSingleNode("SalePriceType");
                    XmlElement NewNode = doc.CreateElement("SupplyDrugType");
                    var result = MessageBox.Show("需要启用拟供药品过滤功能吗？如果启用，则需要在首营供货企业中填写拟供品种资料，并提交审核。（本功仅能针对生产企业，只提示一次，设置后无提示。）", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes;
                    NewNode.SetAttribute("Type", result ? "1" : "0");
                    NewNode.InnerText = "设为1时根据拟供品种过滤,同时决定是否需要增加采购收货扫描图片";
                    SPTNode.AppendChild(NewNode);
                    xmlNode = NewNode;
                    doc.Save(AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml");
                }

                supplyDrugType = Convert.ToInt16(xmlNode.Attributes["Type"].Value);
            }
            catch (Exception ex)
            { MessageBox.Show("配置文件读取错误，请联系管理员！"); }

            if (this.toolStripComboBox1.ComboBox.Items.Count == 0) return;
            SupplyUnit su = (SupplyUnit)this.toolStripComboBox1.ComboBox.SelectedItem;
            Guid uid = su.Id;
            var all = PharmacyDatabaseService.GetDrugInfoBySupplyUnit(out msg, uid);
            if (all == null)
            {
                MessageBox.Show("无该供货商可销售药品，请查询其经营资质是否过期或其经营范围是否正确。");
                this.dataGridView1.DataSource = null;
                return;
            }
            all = all.Where(r => r.Valid).ToArray();
            //控制医疗器械
            if (this.GoodsType == Common.GoodsTypeClass.医疗器械)
            {
                all = all.Where(r => r.BusinessScopeCode== "医疗器械"
                    || r.BusinessScopeCode.Contains("I类")
                    || r.BusinessScopeCode.Contains("II类")
                    || r.BusinessScopeCode.Contains("III类")
                    )
                    .ToArray();
            }
            else
            {
                all = all.Where(r => r.BusinessScopeCode != "医疗器械"
                    //&& r.BusinessScopeCode!="I类"
                    //&& r.BusinessScopeCode!="II类"
                    //&& r.BusinessScopeCode!="III类"
                    )
                    .ToArray();
            }

            if (all == null)
            {
                MessageBox.Show("无该供货商可销售药品，请查询其经营资质是否过期或其经营范围是否正确。");
                this.dataGridView1.DataSource = null;
                return;
            }
            all = all.Except(addBL, new compareD()).ToArray();
            bList.Clear();

            string unitTypeName = PharmacyDatabaseService.GetUnitType(out msg, su.UnitTypeId).Name;
            if (supplyDrugType == 1 && unitTypeName == "生产企业")
            {
                //拟供品种过滤
                string drugStr = su.SupplyProductClass;
                if (drugStr.IsNullOrTrimEmpty())
                {
                    MessageBox.Show("请检查该生产企业的拟供品种。");
                    return;
                }
                foreach (var c in all)
                {
                    if (drugStr.Contains(c.ProductGeneralName))
                    {
                        bList.Add(c);
                    }
                }
            }
            else
            {
                foreach (var c in all)
                {
                    bList.Add(c);
                }
            }
            this.dataGridView1.DataSource = bList;
            this.Supplyer = su.Name;
            this.Text = su.Name + " 入库品种选择";

            this.SupplyerID = su.Id.ToString();
        }


        //提交按钮
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            List<DrugInfo> l = new List<DrugInfo>();
            foreach (var c in addBL)
            {
                l.Add(c);
            }
            SubmitEventArgs args = new SubmitEventArgs(l);
            onSubmit(args);
            this.Dispose();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string t = toolStripTextBox1.Text;
            var c = bList.Where(r => r.FactoryName.Contains(t) || r.PurchaseManageCategoryDetailCode.Contains(t) || r.DictionaryMeasurementUnitCode.Contains(t) || (r.DictionaryDosageCode != null && r.DictionaryDosageCode.Contains(t))).ToList();
            if (c.ToList() != null)
                dataGridView1.DataSource = c;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            string t = toolStripTextBox2.Text;
            var c = bList.Where(r => r.Pinyin != null).Where(r => r.Pinyin.Contains(t) || r.Pinyin.Contains(t.ToUpper())).ToList();
            if (c.ToList() != null)
                dataGridView1.DataSource = c;
        }
        //List的Except比较器，需实现接口方法：Equals和GetHashCode
        class compareD : IEqualityComparer<DrugInfo>
        {
            public bool Equals(DrugInfo x, DrugInfo y)
            {
                if (y == null) return true;
                return x.Id == y.Id;
            }
            public int GetHashCode(DrugInfo obj)
            {
                unchecked
                {
                    if (obj == null)
                        return 0;
                    int hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Id.GetHashCode();
                    return hashCode;
                }
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void FormPurchaseOrderCreateBySupplyer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                this.toolStripButton2_Click(sender, e);
            }
        }

        private void FormPurchaseOrderCreateBySupplyer_Activated(object sender, EventArgs e)
        {
            this.toolStripTextBox3.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.dataGridView1.CurrentCell == null) return;
            if (this.dataGridView1.CurrentCell.RowIndex < 0 || this.dataGridView1.CurrentCell == null) return;
            if (e.KeyCode == Keys.Return)
            {
                Guid g = Guid.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                var c = bList.Where(r => r.Id == g).FirstOrDefault();
                addBL.Add(c);
                bList.Remove(c);
                this.toolStripTextBox1_TextChanged(sender, e);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            Guid g = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            var c = bList.Where(r => r.Id == g).FirstOrDefault();
            addBL.Add(c);
            bList.Remove(c);
            this.toolStripTextBox1_TextChanged(sender, e);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var c = addBL[e.RowIndex];
            addBL.Remove(c);
            bList.Add(c);
            this.toolStripTextBox1_TextChanged(sender, e);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (this.toolStripTextBox3.Text.Trim().Equals(string.Empty)) return;
            string str = this.toolStripTextBox3.Text.Trim().ToUpper();
            var q = listSupplyer.Where(r => r.PinyinCode.ToUpper().Contains(str)).ToList();
            if (q == null) return;
            if (q.Count <= 0) return;
            this.toolStripComboBox1.ComboBox.DataSource = q;
            this.toolStripComboBox1.ComboBox.ValueMember = "id";
            this.toolStripComboBox1.ComboBox.DisplayMember = "name";
            this.toolStripComboBox1.ComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.toolStripComboBox1.ComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.toolStripComboBox1.ComboBox.SelectedIndex = 0;
        }

        private void toolStripTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (toolStripComboBox1.ComboBox.Text.Trim() == string.Empty) return;
            if (e.KeyCode == Keys.Return)
            {
                this.toolStripButton1_Click(sender, e);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void 查看印模印章ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripComboBox1.ComboBox.SelectedValue == null) return;
            Guid sid = Guid.Parse(this.toolStripComboBox1.ComboBox.SelectedValue.ToString());
            BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1, sid);
            frm.ShowDialog();
        }

        private void 查看票据样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripComboBox1.ComboBox.SelectedValue == null) return;
            Guid sid = Guid.Parse(this.toolStripComboBox1.ComboBox.SelectedValue.ToString());
            BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(2, sid);
            frm.ShowDialog();
        }

        private void 查看供货商信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripComboBox1.ComboBox.SelectedValue == null) return;
            Guid sid = Guid.Parse(this.toolStripComboBox1.ComboBox.SelectedValue.ToString());

            SupplyUnit su = this.PharmacyDatabaseService.GetSupplyUnit(out msg, sid);
            UserControls.ucSupplyUnit us = new UserControls.ucSupplyUnit(su, false);
            Form f = new Form();
            f.Text = su.Name;
            f.AutoSize = true;
            f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Panel p = new Panel();
            p.AutoSize = true;
            p.Controls.Add(us);
            f.Controls.Add(p);
            f.ShowDialog();
        }

        private void 查看经营范围ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }


}
