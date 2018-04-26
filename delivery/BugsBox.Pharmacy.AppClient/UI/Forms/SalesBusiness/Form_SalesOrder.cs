using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    /// <summary>
    /// 根据销售单状态，需要修改各控件的显示和可操作状态。
    /// 新增，编辑，查看，冲差价编辑
    /// </summary>
    public partial class Form_SalesOrder : BaseFunctionForm
    {
        string msg = string.Empty;

        #region 初始化变量或类型
        FormOperation CurrentFormStatus = FormOperation.Add;
        PurchaseUnit CurrentPurchaseUnit = null;                           //当前选定的客户单位
        PurchaseUnitBuyer CurrentPurchaseUnitBuyer = null;        //当前客户单位的采购员
        SalesDrugType CurrentSalesDrugType = SalesDrugType.Drug;
        PickUpGoodType CurrentPickUpGoodType = PickUpGoodType.Delivered;

        SalesOrder CurrentSalesOrder = new SalesOrder
        {
            OrderStatus = OrderStatus.Waitting,
            CreateUserId = BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id,
            Id = Guid.NewGuid(),
            PickUpGoodType = PickUpGoodType.GetBySelf,
            SaleDate = DateTime.Now,
            StoreId = BugsBox.Pharmacy.AppClient.Common.AppClientContext.Config.Store.Id
        };

        List<SalesOrderDetailModel> CurrentSalesOrderDetailModels = new List<SalesOrderDetailModel>();
        #endregion

        UI.Forms.BaseForm.BasicInfoRightMenu BaseRightMenu = null;               //右键

        #region 销售人员名单
        List<User> SaleUsers = new List<User>();
        #endregion

        //新增构造函数
        public Form_SalesOrder()
        {
            InitializeComponent();

            this.invoicer.Text = Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Employee.Name;
            this.lblCreateDate.Text = DateTime.Now.Date.ToLongDateString();

            #region 列表处理
            this.dataGridView1.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
            this.dataGridView1.CellClick += dataGridView1_CellClick;
           
            this.dataGridView1.CellMouseDown += (s, e) =>       //选定列表中的药品id，给右键菜单使用
            {
                if (this.dataGridView1.Rows.Count <= 0) return;
                var c=this.dataGridView1.CurrentRow.DataBoundItem as SalesOrderDetailModel;
                this.BaseRightMenu.DrugId = c.DrugInfoId;
            };

            this.BaseRightMenu = new UI.Forms.BaseForm.BasicInfoRightMenu(this.dataGridView1);         //右键支持
            this.BaseRightMenu.InsertDrugBasicInfo();           //加入药品基本信息查询功能
            
            this.BaseRightMenu.InserMenu("删除该品种", () =>
            {
                if (this.dataGridView1.Rows.Count <= 0) return;
                var c = MessageBox.Show("确定需要删除该品种吗","提示",MessageBoxButtons.OKCancel);
                if (c == System.Windows.Forms.DialogResult.Cancel) return;
                this.DeleteDrug();
            });
            #endregion

            #region 选择客户单位
            this.textBox1.Focus();
            this.textBox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode != Keys.Return) return;
                using (Common.FormPurchaseSelector frm = new Common.FormPurchaseSelector(this.textBox1.Text.Trim()))
                {
                    var re=frm.ShowDialog();
                    if (re == System.Windows.Forms.DialogResult.OK)
                    {
                        this.CurrentPurchaseUnit = frm.Result;
                        this.txtPurchaseName.Text = this.CurrentPurchaseUnit.Name;

                        this.BaseRightMenu.InsertPurchaseUnitBasicInfo();           //加入右键查询该客户的基本信息查询界面

                        #region 当前客户单位的采购员
                        var c=this.PharmacyDatabaseService.GetPurchaseUnitBuyersByPurchaseUnitId(this.CurrentPurchaseUnit.Id,out msg).OrderBy(r=>r.Name).ToList();

                        c.Add(new PurchaseUnitBuyer{
                            Id=Guid.Empty,
                             Name="请选择"
                        });
                        this.cmbPurchaseUnitBuyer.DisplayMember = "Name";
                        this.cmbPurchaseUnitBuyer.ValueMember = "Id";
                        this.cmbPurchaseUnitBuyer.DataSource = c;
                        if (c.Count > 0)
                        {
                            this.cmbPurchaseUnitBuyer.SelectedIndex = 0;
                            this.CurrentPurchaseUnitBuyer = c.First();
                        }
                        #endregion
                    }
                }
            };
            #endregion

            #region 客户采购员选择
            this.cmbPurchaseUnitBuyer.SelectedIndexChanged += (s, e) =>
            {
                this.CurrentPurchaseUnitBuyer = this.cmbPurchaseUnitBuyer.SelectedItem as PurchaseUnitBuyer;
            };
            #endregion

            #region 提货方式
            var pickupGoodTypeList = EnumToListHelper.ConverEnumToList(typeof(PickUpGoodType));
            this.cmbPickUpGoods.DisplayMember = "Name";
            this.cmbPickUpGoods.ValueMember = "Id";
            this.cmbPickUpGoods.DataSource = pickupGoodTypeList;
            this.cmbPickUpGoods.SelectedValue = (int)this.CurrentPickUpGoodType;
            #endregion

            #region 品种类型选择下拉列表
            var drugTypeList = EnumToListHelper.ConverEnumToList(typeof(SalesDrugType));
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DataSource = drugTypeList;
            this.comboBox1.SelectedIndex = 0;
            this.comboBox1.SelectedIndexChanged += (s, e) =>
            {
                this.CurrentSalesDrugType = (SalesDrugType)this.comboBox1.SelectedIndex;
                this.toolStripStatusLabel2.Text = ((MyLibs.EnumTypeList)this.comboBox1.SelectedItem).Name;
            };

            #endregion

            #region 销售人员名单绑定列表
            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml");
            System.Xml.XmlNodeList xmlNode = xmlDocument.SelectNodes("/SalePriceType/priceType");
            
            xmlNode = xmlDocument.SelectNodes("/SalePriceType/salerRoleName");
            string  salerRoleName = xmlNode[0].Attributes[0].Value.ToString();
            var SalerNames=this.PharmacyDatabaseService.GetUserByPosition(salerRoleName,string.Empty,string.Empty).OrderBy(r=>r.Employee.Name).ToList();//根据角色获取用户
            var UE = (from i in SalerNames
                     select new SalerNames
                     {
                         Id=i.Id,
                         EName=i.Employee.Name
                     }).ToList();
            //插入一条“请选择”
            UE.Insert(0,new SalerNames
            {
                Id=Guid.Empty,
                EName="请选择销售员"
            });

            this.cmbSalesMan.ValueMember = "Id";
            this.cmbSalesMan.DisplayMember = "EName";
            this.cmbSalesMan.DataSource = UE;
            this.cmbSalesMan.SelectedIndex = 0;
            #endregion
        }
       
        //单击列表处理,删除按钮
        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex == this.Column1.Index)//如果点击了删除按钮
            {
                this.DeleteDrug();
            }
        }

        //删除药品销售记录行
        private void DeleteDrug()
        {
            var r = this.dataGridView1.CurrentRow.DataBoundItem as SalesOrderDetailModel;
            this.CurrentSalesOrderDetailModels.Remove(r);
            this.dataGridView1.DataSource = null;           //删除后重新绑定
            this.dataGridView1.DataSource = this.CurrentSalesOrderDetailModels;
        }

        //导出销售单
        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        //提交
        private void tsbtnSubmit_Click(object sender, EventArgs e)
        {

        }

        //增加销售药品信息
        private void btnDetailAdd_Click(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    ///  该类型用于绑定销售员
    /// </summary>
    public class SalerNames
    {
        /// <summary>
        /// id为销售员userid
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// employee的姓名
        /// </summary>
        public string EName { get; set; }
    }
}
