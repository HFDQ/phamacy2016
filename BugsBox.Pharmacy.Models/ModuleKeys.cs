using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 模块与功能键
    /// 将与客户共用参与权限检测
    /// </summary>
    public static class ModuleKeys
    {
        #region new

        #region 机构人员管理管理
        
        [CategoryWithIndex("机构人员管理管理", 0)]
        [DescriptionWithIndex(BMSZ, 0)]
        public const string BMSZ = "部门设置[窗体]";
        [CategoryWithIndex("机构人员管理管理", 0)]
        [DescriptionWithIndex(YGLR, 0)]
        public const string YGLR = "员工录入[窗体]";
        [CategoryWithIndex("机构人员管理管理", 0)]
        [DescriptionWithIndex(YGPLDR, 0)]
        public const string YGPLDR = "员工批量导入[窗体]";
        [CategoryWithIndex("机构人员管理管理", 0)]
        [DescriptionWithIndex(TJDAGL, 0)]
        public const string TJDAGL = "体检档案管理[窗体]";
        [CategoryWithIndex("机构人员管理管理", 0)]
        [DescriptionWithIndex(PXDAGL, 0)]
        public const string PXDAGL = "培训档案管理[窗体]";
        [CategoryWithIndex("机构人员管理管理", 0)]
        [DescriptionWithIndex(TJXXJL, 0)]
        public const string TJXXJL = "体检档案详细记录[窗体]";
        [CategoryWithIndex("机构人员管理管理", 0)]
        [DescriptionWithIndex(PXXXJL, 0)]
        public const string PXXXJL = "培训档案详细记录[窗体]";
        #endregion

        #region 锁定管理
        [CategoryWithIndex("锁定管理", 0)]
        [DescriptionWithIndex(YPPCSDGL, 0)]
        public const string YPPCSDGL = "药品批次锁定管理[窗体]";
        [CategoryWithIndex("锁定管理", 0)]
        [DescriptionWithIndex(YWYPTJ, 0)]
        public const string YWYPTJ = "疑问药品添加[窗体]";
        [CategoryWithIndex("锁定管理", 0)]
        [DescriptionWithIndex(YPSD, 0)]
        public const string YPSD = "药品锁定[窗体]";
        [CategoryWithIndex("锁定管理", 0)]
        [DescriptionWithIndex(GYSSD, 0)]
        public const string GYSSD = "供应商锁定[窗体]";
        [CategoryWithIndex("锁定管理", 0)]
        [DescriptionWithIndex(KHSD, 0)]
        public const string KHSD = "客户锁定[窗体]";
        #endregion

        #region 业务管理窗体

            #region 首营信息管理
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(SYGHSLR, 0)]
            public const string SYGHSLR = "首营供货商录入[窗体]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(SYYCNHGL, 0)]
            public const string SYYCNHGL = "首营药材供货人管理[窗体]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(GFYWY, 0)]
            public const string GFYWY = "供方业务员[窗体]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(GFYWY_EDIT, 0)]
            public const string GFYWY_EDIT = "供方业务员编辑[功能]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(GFYWY_Check, 0)]
            public const string GFYWY_Check = "供方业务员审核[功能]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(FORM_SupplyUnitImport, 2)]
            public const string FORM_SupplyUnitImport = "合格供应商导入[窗体]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(SYKHLR, 0)]
            public const string SYKHLR = "首营客户录入[窗体]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(KHYWY, 0)]
            public const string KHYWY = "客户采购员[窗体]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(KHYWY_EDIT, 0)]
            public const string KHYWY_EDIT = "客户采购员编辑[功能]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(KHYWY_Check, 0)]
            public const string KHYWY_Check = "客户采购员审核[功能]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(KHTHY, 0)]
            public const string KHTHY = "客户提货员[窗体]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(FORM_PurchaseUnitImport, 1)]
            public const string FORM_PurchaseUnitImport = "合格客户导入[窗体]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(SYYPLR, 0)]
            public const string SYYPLR = "首营药品录入[窗体]";
            [CategoryWithIndex("首营信息管理", 0)]
            [DescriptionWithIndex(FORM_DrugInfoImport, 0)]
            public const string FORM_DrugInfoImport = "合格药品导入[窗体]";

            #endregion

            #region 采购业务管理
            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(PTCG, 0)]
            public const string PTCG = "药品采购[窗体]";
            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(DSCGD, 0)]
            public const string DSCGD = "待审采购单[窗体]";
            #region 税票处理平台
            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(CGSPCL, 0)]
            public const string CGSPCL = "采购税票处理平台[窗体]";

            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(InvoinceColumn, 0)]
            public const string InvoinceColumn = "销售税票项[功能]";

            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(ReceiveMoneyColumn, 0)]
            public const string ReceiveMoneyColumn = "销售金额项[功能]";

            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(PIsPayed, 0)]
            public const string PIsPayed = "采购已打款项[功能]";

            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(PInvoiceArrived, 0)]
            public const string PInvoiceArrived = "采购发票已到项[功能]";

            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(SRefund, 0)]
            public const string SRefund = "销售冲差处理[功能]";

            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(SMoneyCollection, 0)]
            public const string SMoneyCollection = "销售已收款[功能]";

            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(SInvoiceCollection, 0)]
            public const string SInvoiceCollection = "销售已开票[功能]";

            #endregion

            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(CGTHD, 0)]
            public const string CGTHD = "采购退货单[窗体]";            
            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(CGQXD, 0)]
            public const string CGQXD = "采购取消单[窗体]";
            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(CGDD1, 0)]
            public const string CGDD1 = "采购记录[窗体]";

            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(CGYPXZ, 0)]
            public const string CGYPXZ = "采购药品选择[窗体]";
            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(EditPurchaseOrder, 0)]
            public const string EditPurchaseOrder = "采购单编辑[功能]";
            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(ApprovalPurchaseOrder, 0)]
            public const string ApprovalPurchaseOrder = "采购单审核[功能]";
            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(PurchaseReturn, 0)]
            public const string PurchaseReturn = "采购退货[功能]";
            [CategoryWithIndex("采购业务管理", 0)]
            [DescriptionWithIndex(CGCCJ, 0)]
            public const string CGCCJ = "采购冲差价[功能]";

            

            #endregion

            #region 销售业务管理
            [CategoryWithIndex("销售业务管理", 0)]
            [DescriptionWithIndex(AddSalesOrder, 0)]
            public const string AddSalesOrder = "新建销售单[窗体]";
            [CategoryWithIndex("销售业务管理", 0)]
            [DescriptionWithIndex(EditSalesOrder, 0)]
            public const string EditSalesOrder = "编辑订单[功能]";

            [CategoryWithIndex("销售业务管理", 0)]
            [DescriptionWithIndex(SXDDCX, 1)]
            public const string SXDDCX = "销售订单查询[窗体]";
            [CategoryWithIndex("销售业务管理", 0)]
            [DescriptionWithIndex(SXTJ, 1)]
            public const string SXTJ = "销售统计[窗体]";
            [CategoryWithIndex("销售业务管理", 0)]
            [DescriptionWithIndex(ApprovalSalesOrder, 1)]
            public const string ApprovalSalesOrder = "销售审核[窗体]";
            [CategoryWithIndex("销售业务管理", 0)]
            [DescriptionWithIndex(BalanceSalesOrder, 2)]
            public const string BalanceSalesOrder = "销售结算[窗体]";
            [CategoryWithIndex("销售业务管理", 0)]
            [DescriptionWithIndex(BalanceSalesOrderReturn, 1)]
            public const string BalanceSalesOrderReturn = "销售退货结算[窗体]";
            [CategoryWithIndex("销售业务管理", 0)]
            [DescriptionWithIndex(SubmitOrderReturn, 5)]
            public const string SubmitOrderReturn = "销退申请处理[窗体]";
            [CategoryWithIndex("销售业务管理", 0)]
            [DescriptionWithIndex(SaleOrderRefund, 5)]
            public const string SaleOrderRefund = "销售冲差价[窗体]";
            [CategoryWithIndex("销售业务管理", 0)]
            [DescriptionWithIndex(SaleOrderReturn, 11)]
            public const string SaleOrderReturn = "销售退货单[窗体]";
            [DescriptionWithIndex(DirectSaleOrder, 12)]
            public const string DirectSaleOrder = "直调销售申请[窗体]";
            #endregion

            [CategoryWithIndex("商品其他信息", 0)]
            [DescriptionWithIndex(DrugOtherInfor, 0)]
            public const string DrugOtherInfor = "商品其他信息设置及修改[窗体]";

            [CategoryWithIndex("商品其他信息", 0)]
            [DescriptionWithIndex(SalePriceControlRule, 0)]
            public const string SalePriceControlRule = "销售价格控制规则[功能]";


        #endregion

        #region 仓储管理

            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(BHGYPXJ, 0)]
            public const string BHGYPXJ = "不合格药品新建[窗体]";

            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(CGSHD, 0)]
            public const string CGSHD = "采购收货单[窗体]";

            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(ZDYSD, 0)]
            public const string ZDYSD = "直调验收处理[窗体]";

            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(CGYSD, 0)]
            public const string CGYSD = "验收记录[窗体]";
            //[CategoryWithIndex("仓储管理", 0)]
            //[DescriptionWithIndex(CGRKD, 0)]
            //public const string CGRKD = "库存记录[窗体]";


            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(PurchaseReceiving, 0)]
            public const string PurchaseReceiving = "采购收货[功能]";
            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(PurchaseChecking, 0)]
            public const string PurchaseChecking = "采购验收[功能]";
            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(PurchaseInInventory, 0)]
            public const string PurchaseInInventory = "采购入库[功能]";

            [CategoryWithIndex("养护管理", 0)]
            [DescriptionWithIndex(YHGL, 0)]
            public const string YHGL = "养护管理[窗体]";
            [CategoryWithIndex("养护管理", 0)]
            [DescriptionWithIndex(YHSZ, 0)]
            public const string YHSZ = "养护设置[窗体]";
            [CategoryWithIndex("养护管理", 0)]
            [DescriptionWithIndex(ZDYPSZ , 0)]
            public const string ZDYPSZ = "重点养护确认[窗体]";
            [CategoryWithIndex("养护管理", 0)]
            [DescriptionWithIndex(XYKC, 0)]
            public const string XYKC = "库存损溢处理[窗体]";
            [CategoryWithIndex("养护管理", 0)]
            [DescriptionWithIndex(KYKC, 0)]
            public const string KYKC = "可用库存[窗体]";
            

            #region 养护
            [CategoryWithIndex("养护管理", 0)]
            [DescriptionWithIndex(养护工作计划, 0)]
            public const string 养护工作计划 = "养护工作计划[窗体]";
            [CategoryWithIndex("养护管理", 0)]
            [DescriptionWithIndex(普通养护药品记录, 0)]
            public const string 普通养护药品记录 = "普通养护药品记录[窗体]";
            [CategoryWithIndex("养护管理", 0)]
            [DescriptionWithIndex(重点养护药品记录, 0)]
            public const string 重点养护药品记录 = "重点养护药品记录[窗体]";
            #endregion

            [CategoryWithIndex("配送管理", 0)]
            [DescriptionWithIndex(PSCX, 1)]
            public const string PSCX = "配送查询[窗体]";



            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(SubmitOutInventoryForOrder, 3)]
            public const string SubmitOutInventoryForOrder = "出库拣货[窗体]";
            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(SubmitOrderReturnOutInventory, 10)]
            public const string SubmitOrderReturnOutInventory = "销退出库申请[功能]";
            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(ApprovalOutInventoryForOrder, 4)]
            public const string ApprovalOutInventoryForOrder = "出库复核[窗体]";

            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(SpecialDrugApproval, 5)]
            public const string SpecialDrugApproval = "特殊管理药品二次复核[窗体]";
    
            [CategoryWithIndex("仓储管理", 0)]    
            [DescriptionWithIndex(InventoryRecordChecking, 20)]
            public const string InventoryRecordChecking = "库存盘点[窗体]";

            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(ElecticalMotioner, 21)]
            public const string ElecticalMotioner = "电子监管码管理[窗体]";

            [CategoryWithIndex("配送管理", 0)]
            [DescriptionWithIndex(PSSL, 0)]
            public const string PSSL = "配送受理[窗体]";
            [CategoryWithIndex("配送管理", 0)]
            [DescriptionWithIndex(EditDeliveryInfo, 0)]
            public const string EditDeliveryInfo = "编辑配送信息[功能]";
            [CategoryWithIndex("配送管理", 0)]
            [DescriptionWithIndex(SignedForDelivery, 2)]
            public const string SignedForDelivery = "配送签收[功能]";
            [CategoryWithIndex("配送管理", 0)]
            [DescriptionWithIndex(OutInventoryForDelivery, 1)]
            public const string OutInventoryForDelivery = "配送出库[窗体]";
            [CategoryWithIndex("配送管理", 0)]
            [DescriptionWithIndex(SSPSJG, 1)]
            public const string SSPSJG = "配送签收[窗体]";
            [CategoryWithIndex("配送管理", 0)]
            [DescriptionWithIndex(OrderReturnForDelivery, 3)]
            public const string OrderReturnForDelivery = "配送退货申请[功能]";

            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(OrderReturnInventory, 9)]
            public const string OrderReturnInventory = "销退出入库处理[窗体]";

            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(SaleOrderReturnReceiving, 10)]
            public const string SaleOrderReturnReceiving = "销退收货[功能]";
            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(SaleOrderReturnChecking, 11)]
            public const string SaleOrderReturnChecking = "销退验收[功能]";
            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(SaleOrderReturnInInventory, 12)]
            public const string SaleOrderReturnInInventory = "销退入库[功能]";


            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(YKGL, 0)]
            public const string YKGL = "移库请求[窗体]";
            [CategoryWithIndex("仓储管理", 0)]
            [DescriptionWithIndex(YKGLSH, 0)]
            public const string YKGLSH = "移库审批[窗体]";
            
            [CategoryWithIndex("车辆管理", 0)]
            [DescriptionWithIndex(CLGL, 0)]
            public const string CLGL = "车辆管理[窗体]";

            [CategoryWithIndex("近效期品种查询", 0)]
            [DescriptionWithIndex(JXQPZCL, 0)]
            public const string JXQPZCL = "近效期品种查询[窗体]";
        #endregion

        #region 质量管理

            [CategoryWithIndex("首营信息审批", 0)]
            [DescriptionWithIndex(SupplyUnitApproval, 0)]
            public const string SupplyUnitApproval = "首营供货商审批[窗体]";
            [CategoryWithIndex("首营信息审批", 0)]
            [DescriptionWithIndex(PurchaseUnitApproval, 0)]
            public const string PurchaseUnitApproval = "首营客户审批[窗体]";
            [CategoryWithIndex("首营信息审批", 0)]
            [DescriptionWithIndex(DrugInfoApproval, 0)]
            public const string DrugInfoApproval = "首营药品审批[窗体]";


            [CategoryWithIndex("首营信息审批", 0)]
            [DescriptionWithIndex(DrugInfoLock, 0)]
            public const string DrugInfoLock = "药品解锁审批[窗体]";
            [CategoryWithIndex("首营信息审批", 0)]
            [DescriptionWithIndex(PurchaseUnitLock, 0)]
            public const string PurchaseUnitLock = "客户解锁审批[窗体]";
            [CategoryWithIndex("首营信息审批", 0)]
            [DescriptionWithIndex(SupplyUnitLock, 0)]
            public const string SupplyUnitLock = "供货商解锁审批[窗体]";
            [CategoryWithIndex("首营信息审批", 0)]
            [DescriptionWithIndex(DrugInfoEdit, 0)]
            public const string DrugInfoEdit = "药品修改审批[窗体]";
            [CategoryWithIndex("首营信息审批", 0)]
            [DescriptionWithIndex(SupplyUnitEdit, 0)]
            public const string SupplyUnitEdit = "供货商修改审批[窗体]";
            [CategoryWithIndex("首营信息审批", 0)]
            [DescriptionWithIndex(PurchaseUnitEdit, 0)]
            public const string PurchaseUnitEdit = "供货商修改审批[窗体]";

            [CategoryWithIndex("其他审批审核", 0)]
            [DescriptionWithIndex(BHGYPSH, 0)]
            public const string BHGYPSH = "不合格药品审核[窗体]";

            [CategoryWithIndex("其他审批审核", 0)]
            [DescriptionWithIndex(ApprovalPurchaseReturnQuality, 0)]
            public const string ApprovalPurchaseReturnQuality = "采购退货质量管理部审核[功能]";
            [CategoryWithIndex("其他审批审核", 0)]
            [DescriptionWithIndex(ApprovalPurchaseReturnManager, 0)]
            public const string ApprovalPurchaseReturnManager = "采购退货总经理审核[功能]";
            [CategoryWithIndex("其他审批审核", 0)]
            [DescriptionWithIndex(ApprovalPurchaseReturnFinance, 0)]
            public const string ApprovalPurchaseReturnFinance = "采购退货财务部审核[功能]";

            [CategoryWithIndex("其他审批审核", 0)]
            [DescriptionWithIndex(SellerApprovedOrderReturn, 6)]
            public const string SellerApprovedOrderReturn = "销退销售员审核[窗体]";
            [CategoryWithIndex("其他审批审核", 0)]
            [DescriptionWithIndex(TradeApprovedOrderReturn, 7)]
            public const string TradeApprovedOrderReturn = "销退营业部审核[窗体]";
            [CategoryWithIndex("其他审批审核", 0)]
            [DescriptionWithIndex(QualityApprovedOrderReturn, 8)]
            public const string QualityApprovedOrderReturn = "销退质管部审核通过[窗体]";

            [CategoryWithIndex("其他审批审核", 0)]
            [DescriptionWithIndex(DCLYPQK, 0)]
            public const string DCLYPQK = "待处理药品质管员复核[窗体]";
            [CategoryWithIndex("其他审批审核", 0)]
            [DescriptionWithIndex(DCLYPFHJL, 1)]
            public const string DCLYPFHJL = "待处理药品质管部复核结论[窗体]";

        #endregion 

        //update 2012-1-9
        #region 拒收及不合格管理

        [CategoryWithIndex("拒收及不合格管理", 0)]
        [DescriptionWithIndex(JSDSH, 0)]
        public const string JSDSH = "拒收单审核[窗体]";

        [CategoryWithIndex("拒收及不合格管理", 0)]
        [DescriptionWithIndex(BHGYPCX, 0)]
        public const string BHGYPCX = "不合格药品处理[窗体]";

        [CategoryWithIndex("拒收及不合格管理", 0)]
        [DescriptionWithIndex(YPBSSH, 0)]
        public const string YPBSSH = "药品报损审核[窗体]";

        [CategoryWithIndex("拒收及不合格管理", 0)]
        [DescriptionWithIndex(DXHQD, 0)]
        public const string DXHQD = "待销毁清单[窗体]";

        [CategoryWithIndex("拒收及不合格管理", 0)]
        [DescriptionWithIndex(YXHQD, 0)]
        public const string YXHQD = "已销毁清单[窗体]";

        #endregion
        //end

        #region 信息查询管理
            [CategoryWithIndex("基础信息查询管理", 0)]
            [DescriptionWithIndex(GHSCX, 0)]
            public const string GHSCX = "供货商查询[窗体]";

            [CategoryWithIndex("基础信息查询管理", 0)]
            [DescriptionWithIndex(KHCX, 0)]
            public const string KHCX = "客户查询[窗体]";

            [CategoryWithIndex("基础信息查询管理", 0)]
            [DescriptionWithIndex(YPXXCX, 0)]
            public const string YPXXCX = "药品信息查询[窗体]";

            [CategoryWithIndex("基础信息查询管理", 0)]
            [DescriptionWithIndex(RZCX, 0)]
            public const string RZCX = "日志查询[窗体]";
            [CategoryWithIndex("基础信息查询管理", 0)]
            [DescriptionWithIndex(ZZGQCXCT, 0)]
            public const string ZZGQCXCT = "证照过期查询[窗体]";
            [CategoryWithIndex("基础信息查询管理", 0)]
            [DescriptionWithIndex(RYGQCX, 0)]
            public const string RYGQCX = "人员过期查询[窗体]";

            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(CGJLCX, 0)]
            public const string CGJLCX = "采购记录查询[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(shjlcx, 0)]
            public const string shjlcx = "收货记录查询[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(YSJLCX, 0)]
            public const string YSJLCX = "验收记录查询[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(RKJLCX, 0)]
            public const string RKJLCX = "入库记录查询[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(THJLCX, 0)]
            public const string THJLCX = "退货记录查询[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(CGJLHZCX, 0)]
            public const string CGJLHZCX = "采购记录汇总查询[窗体]";

            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(CGDD, 0)]
            public const string CGDD = "采购记录[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(CGJL, 0)]
            public const string CGJL = "采购记录[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(ZYCCGJL, 0)]
            public const string ZYCCGJL = "中药材采购记录[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(ZYYPCGJL, 0)]
            public const string ZYYPCGJL = "中药饮片采购记录[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(SHTXD, 0)]
            public const string SHTXD = "随货同行单(票)[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(SHJL, 0)]
            public const string SHJL = "收货记录[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(JSJL, 0)]
            public const string JSJL = "拒收记录[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(YSJL, 0)]
            public const string YSJL = "验收记录[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(ZYCYSJL, 0)]
            public const string ZYCYSJL = "中药材验收记录[窗体]";
            [CategoryWithIndex("采购相关查询", 0)]
            [DescriptionWithIndex(ZYYPYSJL, 0)]
            public const string ZYYPYSJL = "中药饮片验收记录[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(订单查询, 0)]
            public const string 订单查询 = "订单查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(药品销售记录, 0)]
            public const string 药品销售记录 = "药品销售记录[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(取消记录查询, 0)]
            public const string 取消记录查询 = "销售取消记录查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(结算记录查询, 0)]
            public const string 结算记录查询 = "结算记录查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(销退记录单查询, 0)]
            public const string 销退记录单查询 = "销退记录单查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(销退验收记录查询, 0)]
            public const string 销退验收记录查询 = "销退验收记录查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(销退入库记录查询, 0)]
            public const string 销退入库记录查询 = "销退入库记录查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(销退取消记录查询, 0)]
            public const string 销退取消记录查询 = "销退取消记录查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(出库记录查询, 0)]
            public const string 出库记录查询 = "出库记录查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(出库审核记录查询, 0)]
            public const string 出库审核记录查询 = "出库审核记录查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(配送申请记录查询, 0)]
            public const string 配送申请记录查询 = "配送申请记录查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(配送取消记录查询, 0)]
            public const string 配送取消记录查询 = "配送取消记录查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(配送出库记录查询, 0)]
            public const string 配送出库记录查询 = "配送出库记录查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(配送签收记录查询, 0)]
            public const string 配送签收记录查询 = "配送签收记录查询[窗体]";

            [CategoryWithIndex("销售相关查询", 0)]
            [DescriptionWithIndex(配送销退记录查询, 0)]
            public const string 配送销退记录查询 = "配送销退记录查询[窗体]";

        #endregion 

        #region 系统管理

            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(JSGL, 0)]
            public const string JSGL = "角色管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(JSGLYH, 0)]
            public const string JSGLYH = "角色关联用户[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(JSQXGL, 0)]
            public const string JSQXGL = "角色权限管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(YHGL_USER, 0)]
            public const string YHGL_USER = "用户管理[窗体]";

            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(QYGL, 0)]
            public const string QYGL = "区域管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(BCYZGL, 0)]
            public const string BCYZGL = "不常用字管理[窗体]";

            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(JYFWGL, 0)]
            public const string JYFWGL = "药品经营范围管理[窗体]";

            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(JYFS, 0)]
            public const string JYFS = "经营方式[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(QYLX, 0)]
            public const string QYLX = "企业类型[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(YHFLGL, 0)]
            public const string YHFLGL = "药物分类管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(CCFSGL, 0)]
            public const string CCFSGL = "储藏方式管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(YWGGGL, 0)]
            public const string YWGGGL = "药物规格管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(ZDYYYLX, 0)]
            public const string ZDYYYLX = "自定义药物类型[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(JLDWGL, 0)]
            public const string JLDWGL = "计量单位管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(CLDWGL, 0)]
            public const string CLDWGL = "拆零单位管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(JXGL, 0)]
            public const string JXGL = "剂型管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(LCGL, 0)]
            public const string LCGL = "流程管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(LCJDGL, 0)]
            public const string LCJDGL = "流程节点管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(SPLCCX, 0)]
            public const string SPLCCX = "审批流程查询[窗体]";

            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(YSGJ, 0)]
            public const string YSGJ = "运输工具[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(CKGL, 0)]
            public const string CKGL = "仓库管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(KQGL, 0)]
            public const string KQGL = "库区管理[窗体]";
            [CategoryWithIndex("系统管理", 0)]
            [DescriptionWithIndex(MDGL, 0)]
            public const string MDGL = "门店管理[窗体]";

        #endregion 



        #region 零售管理
        //[CategoryWithIndex("零售管理", 0)]
        //[DescriptionWithIndex(LSXJ, 0)]
        //public const string LSXJ = "零售新建[窗体]";
        //[CategoryWithIndex("零售管理", 0)]
        //[DescriptionWithIndex(LSDDCX, 0)]
        //public const string LSDDCX = "零售订单查询[窗体]";
        //[CategoryWithIndex("零售管理", 0)]
        //[DescriptionWithIndex(LSTH, 0)]
        //public const string LSTH = "零售退货[窗体]";
        #endregion



       #endregion
    }

    public class CategoryWithIndex : CategoryAttribute
    {
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int Index { get; set; }
        public CategoryWithIndex(string category, int index = 0)
            : base(category)
        {
            Index = index;
        }

        public override bool Equals(object obj)
        {
            var objCategoryWithIndex = obj as CategoryWithIndex;
            if (objCategoryWithIndex == null) return false;
            return objCategoryWithIndex.Category == this.Category;
        }
    }

    public class DescriptionWithIndex : DescriptionAttribute
    {
        public int Index { get; set; }
        public DescriptionWithIndex(string description, int index = 0)
            : base(description)
        {
            Index = index;
        }

        public override bool Equals(object obj)
        {
            var objCategoryWithIndex = obj as DescriptionWithIndex;
            if (objCategoryWithIndex == null) return false;
            return objCategoryWithIndex.Description == this.Description;
        }
    }

    /// <summary>
    /// 商品类型Keys
    /// </summary>
    public static class GoodsTypeKeys
    {
        /// <summary>
        /// 药品>>国产
        /// </summary>
        public const string DrugDomestic = "药品>>国产";

        /// <summary>
        /// 药品>>进口
        /// </summary>
        public const string DrugImport = "药品>>进口";

        /// <summary>
        /// 器械>>国产
        /// </summary>
        public const string InstrumentDomestic = "器械>>国产";

        /// <summary>
        /// 器械>>进口
        /// </summary>
        public const string InstrumentImport = "器械>>进口";

        /// <summary>
        /// 保健食品>>国产
        /// </summary>
        public const string HealthFoodDomestic = "保健食品>>国产";

        /// <summary>
        /// 保健食品>>国产
        /// </summary>
        public const string HealthFoodImport = "保健食品>>进口";

        /// <summary>
        /// 化妆品>>国产
        /// </summary>
        public const string CosmeticDomestic = "化妆品>>国产";

        /// <summary>
        /// 化妆品>>进口
        /// </summary>
        public const string CosmeticImport = "化妆品>>进口";


    }

    /// <summary>
    /// 此类型商品的附加属性
    /// </summary>
    public class GoodsAdditionalPropertyAttribute : Attribute
    {
        public string AdditionalPropertyString { get; set; }

        public List<string> AdditionalProperties
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AdditionalPropertyString))
                {
                    return new List<string>();
                }
                else
                {
                    return AdditionalPropertyString.Split(',')
                        .ToList();
                }
            }
        }
    }

}

