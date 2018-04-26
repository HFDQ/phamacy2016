using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
//此文件放置枚举类型
namespace BugsBox.Pharmacy.Models
{
    [Description("商品类型")]
    public enum GoodsType
    {
        [Display(Name = "药品>>国产")]
        [GoodsAdditionalProperty(AdditionalPropertyString = "" +
                                                            "" +
                                                            "" +
                                                            "" +
                                                            "" +
                                                            "" +
                                                            "" +
                                                            "")]
        DrugDomestic,
        [Display(Name = "药品>>进口")]
        [GoodsAdditionalProperty(AdditionalPropertyString = "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "")]
        DrugImport,
        [Display(Name = "器械>>国产")]
        [GoodsAdditionalProperty(AdditionalPropertyString = "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "")]
        InstrumentDomestic,
        [Display(Name = "器械>>进口")]
        [GoodsAdditionalProperty(AdditionalPropertyString = "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "")]
        InstrumentImport,
        [Display(Name = "保健食品>>国产")]
        [GoodsAdditionalProperty(AdditionalPropertyString = "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "")]
        HealthFoodDomestic,
        [Display(Name = "保健食品>>进口")]
        [GoodsAdditionalProperty(AdditionalPropertyString = "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "")]
        HealthFoodImport,
        [Display(Name = "化妆品>>国产")]
        [GoodsAdditionalProperty(AdditionalPropertyString = "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "")]
        CosmeticDomestic,
        [Display(Name = "化妆品>>进口")]
        [GoodsAdditionalProperty(AdditionalPropertyString = "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "")]
        CosmeticImport,
        [Display(Name = "食品>>食品")]
        [GoodsAdditionalProperty(AdditionalPropertyString = "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "" +
                                                        "")]
        Food
    }

    [Description("库区类型")]
    public enum WarehouseZoneType
    {
        [Display(Name = "库区")]
        WarehouseZone,
        [Display(Name = "柜台")]
        Counter
    }

    /// <summary>
    /// 门店类型
    /// </summary>
    [Description("门店类型")]
    public enum StoreType
    {
        [Display(Name = "总店")]
        Main,
        [Display(Name = "分店")]
        Branch
    }

    /// <summary>
    /// 在职状态
    /// </summary>
    [Description("在职状态")]
    public enum EmployStatus : int
    {
        /// <summary>
        /// 在职
        /// </summary>
        [Display(Name = "在职")]
        Serving = 1,

        /// <summary>
        /// 离职
        /// </summary>
        [Display(Name = "离职")]
        Departure = 0,
    }

    /// <summary>
    /// 药师职称
    /// </summary>
    [Description("药师职称")]
    public enum PharmacistsTitleType : int
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Name = "无")]
        None = 0,

        /// <summary>
        /// 其他
        /// </summary>
        [Display(Name = "其他")]
        Other = 1,
        /// <summary>
        /// 药士职称
        /// </summary>
        [Display(Name = "药士")]
        PharmacistAssistant = 2,

        /// <summary>
        /// 药师
        /// </summary>
        [Display(Name = "药师")]
        Pharmacists = 3,

        /// <summary>
        /// 主管药师
        /// </summary>
        [Display(Name = "主管药师")]
        HeadPharmacists = 4,

        /// <summary>
        /// 副主任药师
        /// </summary>
        [Display(Name = "副主任药师")]
        ViceDirectorPharmacists = 5,

        /// <summary>
        /// 主任药师
        /// </summary>
        [Display(Name = "主任药师")]
        DirectorPharmacists = 6,
    }

    /// <summary>
    /// 从业资格
    /// </summary>
    [Description("从业资格")]
    public enum PharmacistsQualification
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Name = "无")]
        None = 0,

        /// <summary>
        /// 其他
        /// </summary>
        [Display(Name = "其他")]
        Other = 1,

        /// <summary>
        /// 执业药师
        /// </summary>
        [Display(Name = "执业药师")]
        LicensedPharmacist = 2,

        /// <summary>
        /// 从业药师
        /// </summary>
        [Display(Name = "从业药师")]
        PractitionersPharmacist = 3

    }

    [Description("出库类型")]
    public enum OutInventoryType : int
    {
        /// <summary>
        ///  退供货商
        /// </summary>
        [Display(Name = "退供货商")]
        Return = 0,
        /// <summary>
        /// 调拨
        /// </summary>
        [Display(Name = "调拨")]
        Transfers,

        /// <summary>
        /// 库存报损
        /// </summary>
        [Display(Name = "库存报损")]
        InventoryLoss,

        /// <summary>
        /// 零售
        /// </summary>
        [Display(Name = "零售")]
        Retail,

        /// <summary>
        /// 销售出库
        /// </summary>
        [Display(Name = "销售出库")]
        SalesNormal,

        /// <summary>
        /// 销售补货
        /// </summary>
        [Display(Name = "销售补货")]
        SalesReissue,

        /// <summary>
        /// 其他原因
        /// </summary>
        [Display(Name = "其他原因")]
        Other,

    }
    [Description("采购记录类型")]
    public enum PurchaseRecordType
    {
        [Display(Name = "医疗器械采购记录")]
        YLQXCGJL=-1,
        [Display(Name = "采购记录")]
        CGJL=0,
        [Display(Name = "中药材采购记录")]
        ZYCCGJL,
        [Display(Name = "中药饮片采购记录")]
        ZYYPCGJL,
        [Display(Name = "随货同行单(票)")]
        SHTXD,
        [Display(Name = "收货记录")]
        SHJL,
        [Display(Name = "拒收记录")]
        JSJL,
        [Display(Name = "验收记录")]
        YSJL,
        [Display(Name = "中药材验收记录")]
        ZYCYSJL,
        [Display(Name = "中药饮片验收记录")]
        ZYYPYSJL,
        [Display(Name = "医疗器械验收记录")]
        YLQXYSJL ,
        
        
    }

    [Description("数据源类型")]
    public enum DataSoruceType
    {

        [Display(Name = "店面管理")]
        Store,
        [Display(Name = "区域管理")]
        District,
        [Display(Name = "不常用字(生僻字)管理")]
        Rareword,
        [Display(Name = "仓库管理")]
        Warehouse,
        [Display(Name = "库区管理")]
        WarehouseZone,
        [Display(Name = "用户管理")]
        User,
        [Display(Name = "用户操作日志管理")]
        UserLog,
        [Display(Name = "角色管理")]
        Role,
        [Display(Name = "功能模块分类管理")]
        ModuleCategory,
        [Display(Name = "功能模块")]
        Module,
        [Display(Name = "车辆管理")]
        Vehicle,
        [Display(Name = "药物分类管理")]
        DrugCategory,
        [Display(Name = "药物规格管理")]
        DictionarySpecification,
        [Display(Name = "药物类型管理")]
        DrugType,
        [Display(Name = "储藏方式管理")]
        DictionaryStorageType,
        [Display(Name = "计量单位管理")]
        DictionaryMeasurementUnit,
        [Display(Name = "拆零单位管理")]
        DictionaryPiecemealUnit,
        [Display(Name = "用户自定义药物类型管理")]
        DictionaryUserDefinedType,
        [Display(Name = "剂型管理")]
        DictionaryDosage,
        [Display(Name = "购货单位类型管理")]
        PurchaseUnitType,
        [Display(Name = "购货单位管理")]
        PurchaseUnit,
        [Display(Name = "客户采购员")]
        PurchaseUnitBuyer,
        [Display(Name = "购货单位提货人员")]
        PurchaseUnitDeliverer,
        [Display(Name = "供货单位")]
        SupplyUnit,
        [Display(Name = "供货商销售人员")]
        SupplyUnitSalesman,
        [Display(Name = "员工录入")]
        Employee,
        [Display(Name = "经营方式")]
        BusinessType,
        [Display(Name = "企业类型")]
        UnitType,
        [Display(Name = "审批流程类型")]
        ApprovalFlowType,

        [Display(Name = "首营药材供货人")]
        SupplyPerson,

        [Display(Name = "药品经营范围管理")]
        BusinessScope
    }

    /// <summary>
    /// 订单类型
    /// </summary>
    [Description("订单类型")]
    public enum OrderType
    {
        /// <summary>
        /// 采购单
        /// </summary>
        [Display(Name = "采购单")]
        PurchaseOrder,
        /// <summary>
        /// 采购收货单
        /// </summary>
        [Display(Name = "采购收货单")]
        PurchaseReceivingOrder,
        /// <summary>
        /// 验收记录
        /// </summary>
        [Display(Name = "验收记录")]
        PurchaseCheckingOrder,
        /// <summary>
        /// 库存记录
        /// </summary>
        [Display(Name = "库存记录")]
        PurchaseInInventeryOrder,
        /// <summary>
        /// 采购结算单
        /// </summary>
        [Display(Name = "采购结算单")]
        PurchaseBillingOrder,
        /// <summary>
        /// 采购退货单
        /// </summary>
        [Display(Name = "采购退货单")]
        PurchaseOrderReturn,

         /// <summary>
        /// 待处理货单
        /// </summary>
        [Display(Name = "待处理货单")]
        Undeterminate,
        
         /// <summary>
        /// 拒收单
        /// </summary>
        [Display (Name="拒收单")]
        Refuse
    }

    /// <summary>
    /// 审批类型
    /// 供货商审批
    /// 采购商审批
    /// 经营药物审批
    /// </summary>
    [Description("审批类型")]
    public enum ApprovalType
    {
        /// <summary>
        /// 首营供货商审批
        /// </summary>
        [Display(Name = "首营供货商审批")]
        SupplyUnitApproval = 1,
        /// <summary>
        /// 首营客户审批
        /// </summary>
        [Display(Name = "首营客户审批")]
        PurchaseUnitApproval = 2,
        /// <summary>
        /// 首营药品审批
        /// </summary>
        [Display(Name = "首营药品审批")]
        DrugInfoApproval = 3,
        /// <summary>
        /// 药品解锁审批
        /// </summary>
        [Display(Name = "药品解锁审批")]
        DrugInfoLockApproval = 4,
        /// <summary>
        /// 客户解锁审批
        /// </summary>
        [Display(Name = "客户解锁审批")]
        PurchaseUnitLockApproval = 5,
        /// <summary>
        /// 供货商解锁审批
        /// </summary>
        [Display(Name = "供货商解锁审批")]
        SupplyUnitLockApproval = 6,
        /// <summary>
        /// 药品修改审批
        /// </summary>
        [Display(Name = "药品修改审批")]
        DrugInfoEditApproval = 7,
        /// <summary>
        /// 客户修改审批
        /// </summary>
        [Display(Name = "客户修改审批")]
        PurchaseUnitEditApproval = 8,
        /// <summary>
        /// 供货商修改审批
        /// </summary>
        [Display(Name = "供货商修改审批")]
        SupplyUnitEditApproval = 9,
        /// <summary>
        /// 不合格药品审批
        /// </summary>
        [Display(Name = "不合格药品审批")]
        drugsUnqualityApproval = 10,
        /// <summary>
        /// 报损审批
        /// </summary>
        [Display(Name = "药品报损审批")]
        drugsBreakageApproval = 11,

        /// <summary>
        /// 移库审批
        /// </summary>
        [Display(Name = "移库审批")]
        drugsInventoryMove = 12,

        [Display(Name = "委托车辆")]
        VehicleApproval = 13,


        [Display(Name="直调审批")]
        DirectSalesApproval=14
    }

    /// <summary>
    /// 审批状态
    /// </summary>
    [Description("审批状态")]
    public enum ApprovalStatus
    {
        /// <summary>
        /// 无流程
        /// </summary> 
        [Display(Name = "无流程")]
        NonApproval = 0,
        
        /// <summary>
        /// 待审
        /// </summary> 
        [Display(Name = "待审")]
        Waitting = 1,

        /// <summary>
        /// 已审
        /// </summary>
        [Display(Name = "通过")]
        Approvaled = 2,

        /// <summary>
        /// 审查未通过
        /// </summary>
        [Display(Name = "审查未通过")]
        Reject = 4,

        /// <summary>
        /// 失效
        /// </summary>
        [Display(Name = "失效")]
        Abate = 8,

        /// <summary>
        /// 取消
        /// </summary>
        [Display(Name = "取消")]
        Canceled = 16
    }

    /// <summary>
    /// 经销方式
    /// </summary>
    [Description("经销方式")]
    public enum DealerMethod
    {
        /// <summary>
        /// 采购入库
        /// </summary> 
        [Display(Name = "采购入库")]
        PurchaseInInventory,

        /// <summary>
        /// 采购退货
        /// </summary>
        [Display(Name = "采购退货")]
        PurchaseReturn
    }

    /// <summary>
    /// 车辆类别
    /// </summary>
    [Description("车辆类别")]
    public enum VehicleCategory
    {
        [Display(Name = "自有车辆")]
        Free,
        [Display(Name = "委托车辆")]
        Commission
    }
    /// <summary>
    /// 订单状态
    /// </summary>
    [Description("订单状态")]
    public enum OrderStatus
    {
        [Display(Name="正常")]
        Normal=0,
        /// <summary>
        /// 销售单录入等待审批
        /// </summary>
        [Display(Name = "待审")]
        Waitting = 1,

        /// <summary>
        /// 销售单审批通过
        /// </summary>
        [Display(Name = "审核通过")]
        Approved = 2,

        /// <summary>
        /// 销售单审批拒绝
        /// </summary>
        [Display(Name = "审核拒绝")]
        Rejected = 3,

        /// <summary>
        /// 销售单取消作废
        /// </summary>
        [Display(Name = "取消作废")]
        Canceled = 4,

        /// <summary>
        /// 销售订单已被结算
        /// </summary>
        [Display(Name = "已结算")]
        Banlaced = 5,

        ///// <summary>
        ///// 销售订单已出库审核中
        ///// </summary>
        //[Display(Name = "出库审核中")]
        //Outing = 6,

        ///// <summary>
        ///// 出库完毕
        ///// </summary>
        //[Display(Name = "出库完毕")]
        //Outed = 7,

        /// <summary>
        /// 销售订单已出库中
        /// </summary>
        [Display(Name = "出库中")]
        Outing = 6,

        /// <summary>
        /// 销售配送中
        /// </summary>
        [Display(Name = "配送完毕")]
        Delivering = 7,

        /// <summary>
        /// 销退申请中
        /// </summary>
        [Display(Name = "销退申请中")]
        Returning = 8,

        /// <summary>
        /// 销售单被退回
        /// </summary>
        [Display(Name = "订单退回")]
        Returned = 9,

        /// <summary>
        /// 采购收货
        /// </summary>
        [Display(Name = "收货")]
        PurchaseReceiving = 10,

        /// <summary>
        /// 采购拒收
        /// </summary>
        [Display(Name = "拒收")]
        PurchaseReceivingReject = 11,

        /// <summary>
        /// 采购验收不合格
        /// </summary>
        [Display(Name = "不合格")]
        PurchaseCheckFault = 12,

        /// <summary>
        /// 采购验收
        /// </summary>
        [Display(Name = "验收")]
        PurchaseCheck = 13,

        /// <summary>
        /// 采购入库
        /// </summary>
        [Display(Name = "入库")]
        PurchaseInInventory = 14,

        /// <summary>
        /// 采购结算
        /// </summary>
        [Display(Name = "结算")]
        BillAccount = 15,

        /// <summary>
        /// “采购记录”中某种药品的采购数量与到货数量不同，需经过审批修改采购数量（仅数量能修改）
        /// </summary>
        [Display(Name = "采购数量不一致")]
        PurchaseReceinvingAmountDiff = 16,

        /// <summary>
        /// “采购记录”中某种药品的采购数量与到货数量不同，需经过审批修改采购数量（仅数量能修改）
        /// </summary>
        [Display(Name = "采购数量修改审批通过")]
        PurchaseApprovedReceinvingAmountDiff = 17,

        [Display(Name = "采购数量修改申请")]
        PurchaseApplyReceinvingAmountDiff = 18,

        [Display(Name = "退货重新收货")]
        PurchaseReturnReceiving = 19,

        /// <summary>
        /// 收货完成
        /// </summary>
        [Display(Name = "收货完成")]
        Signed = 100,

        /// <summary>
        /// 状态为空
        /// </summary>
        [Display(Name = "状态为空")]
        None = 101,

        [Display(Name="已删除")]
        purchaseOrderDeleted=120,

        [Display(Name="销售冲差价申请状态")]
        purchaseRefund=130,

        [Display(Name="采购多次到货")]
        purchaseMReceiving=140
    }

    /// <summary>
    /// 出库状态
    /// </summary>
    public enum OutInventoryStatus
    {
        /// <summary>
        /// 销售订单已出库审核中
        /// </summary>
        [Display(Name = "出库审核中")]
        Outing = 1,

        /// <summary>
        /// 出库完毕
        /// </summary>
        [Display(Name = "出库完毕")]
        Outed = 2,

        /// <summary>
        /// 销退申请中
        /// </summary>
        [Display(Name = "销退申请中")]
        Returning = 3,

        /// <summary>
        /// 无状态
        /// </summary>
        [Display(Name = "无状态")]
        None = 0,

        /// <summary>
        /// 特殊药品复合状态
        /// </summary>
        [Display(Name = "特殊药品复合状态")]
        important = 4
    }

    /// <summary>
    /// 消退状态
    /// </summary>
    [Description("退货状态")]
    public enum OrderReturnStatus
    {
        /// <summary>
        /// 无状态(不出现在数据库中)
        /// </summary>
        [Display(Name = "无状态")]
        None = 0,
        /// <summary>
        /// 消退申请中
        /// </summary>
        [Display(Name = "退货申请中")]
        Waitting = 1,

        /// <summary>
        /// 消退申请审核1(销售员审核)
        /// </summary>
        [Display(Name = "销售员审核")]
        SellerApproved,

        /// <summary>
        /// 消退申请审核2(营业部审核)
        /// </summary>
        [Display(Name = "营业部审核")]
        TradeApproved,

        /// <summary>
        /// 消退申请审核3(质量管理部审核)
        /// </summary>
        [Display(Name = "质管部审核通过")]
        QualityApproved,

        /// <summary>
        /// 处理完毕(入库完毕)
        /// </summary>
        [Display(Name = "处理完毕")]
        Over,

        /// <summary>
        /// 退货拒绝
        /// </summary>
        [Display(Name = "退货申请拒绝")]
        Rejected,

        /// <summary>
        /// 总经理审核
        /// </summary>
        [Display(Name = "总经理审核通过")]
        GeneralManagerApproved,

        /// <summary>
        /// 财务部审核
        /// </summary>
        [Display(Name = "财务部审核通过")]
        FinanceDepartmentApproved,

        /// <summary>
        /// 取消
        /// </summary>
        [Display(Name = "取消")]
        Canceled,

        /// <summary>
        /// 结算
        /// </summary>
        [Display(Name="结算")]
        Balanced,

        /// <summary>
        /// 收货
        /// </summary>
        [Display(Name="收货")]
        ReturnReceived,

        /// <summary>
        /// 收货验收
        /// </summary>
        [Display(Name="收货验收")]
        ReturnChecked,

        /// <summary>
        /// 采购出库拣货
        /// </summary>
        [Display(Name = "采购出库拣货")]
        ReturnPickup,

        /// <summary>
        /// 采购退货出库验收
        /// </summary>
        [Display(Name="采购出库验收")]
        ReturnPickupChecked,

    }

    /// <summary>
    /// 销退理由
    /// </summary>
    [Description("退货理由")]
    public enum OrderReturnReason
    {
        /// <summary>
        /// 正常退货
        /// </summary>
        [Display(Name = "正常退货")]
        Return = 1,

        /// <summary>
        /// 过期
        /// </summary>
        [Display(Name = "过期")]
        Expired,

        /// <summary>
        /// 损坏
        /// </summary>
        [Display(Name = "损坏")]
        Damage,
    }

    /// <summary>
    /// 退货处理方式
    /// </summary>
    [Description("退货处理方式")]
    public enum ReturnHandledMethod
    {
        /// <summary>
        /// 本地销毁
        /// </summary>
        [Display(Name = "本地销毁")]
        LocalDestroy = 1,

        /// <summary>
        /// 带回销毁
        /// </summary>
        [Display(Name = "带回销毁")]
        ReturnDestroy,

        /// <summary>
        /// 损坏
        /// </summary>
        [Display(Name = "损坏")]
        Damage,

        /// <summary>
        /// 其他处理
        /// </summary>
        [Display(Name = "其他处理")]
        Other,
    }

    /// <summary>
    /// 采购退货来源
    /// </summary>
    [Description("采购退货来源")]
    public enum PurchaseReturnSource
    {
        /// <summary>
        /// 收货阶段
        /// </summary>
        [Display(Name = "收货阶段")]
        ReturnFromReceiving,

        /// <summary>
        /// 验收阶段
        /// </summary>
        [Display(Name = "验收阶段")]
        ReturnFromChecking,

        /// <summary>
        /// 库存
        /// </summary>
        [Display(Name = "库存")]
        ReturnFromInInventery,

        /// <summary>
        /// 其他
        /// </summary>
        [Display(Name = "其他")]
        Other
    }

    /// <summary>
    /// 入库类型
    /// </summary>
    [Description("入库类型")]
    public enum DurgInventoryType
    {
        /// <summary>
        /// 采购入库
        /// </summary>
        [Display(Name = "采购入库")]
        Purchase,

        /// <summary>
        /// 销售退货入库
        /// </summary>
        [Display(Name = "销售退货入库")]
        SaleReturn,

        /// <summary>
        /// 其他
        /// </summary>
        [Display(Name = "其他")]
        Other
    }

    /// <summary>
    /// 角色类型
    /// </summary>
    [Description("角色类型")]
    public enum RoleType
    {
        [Display(Name = "采购员", Description = "1F39FAF3-F52F-4785-94F4-0127C8814E39")]
        Purchaser,
        [Display(Name = "采购审批员", Description = "DC4B6839-A988-4DCD-B299-09E7CFB3D790")]
        PurchaseChecker,
        [Display(Name = "验收员", Description = "283A8335-8A44-409E-BC7A-022E4B0716F6")]
        Inspector,
        [Display(Name = "保管员", Description = "36ABB534-89F7-4967-A940-02B498FE1064")]
        Storeman
    }

    /// <summary>
    /// 零售结算方式
    /// </summary>
    [Description("零售结算方式")]
    public enum RetailPaymentMethod
    {
        /// <summary>
        /// 现金
        /// </summary>
        [Display(Name = "现  金")]
        Cash,

        /// <summary>
        /// 银行卡或信用卡
        /// </summary>
        [Display(Name = "银行卡或信用卡")]
        BankOrCreditCard,

        /// <summary>
        /// 医保卡
        /// </summary>
        [Display(Name = "医保卡")]
        MedicalInsuranceCard,

        /// <summary>
        /// 代金券
        /// </summary>
        [Display(Name = "代金券")]
        Cashcoupon,
    }

    /// <summary>
    /// 零售顾客类型
    /// </summary>
    [Description("零售顾客类型")]
    public enum RetailCustomerType
    {
        /// <summary>
        /// 顾客(即散客)
        /// </summary>
        [Display(Name = "顾客(即散客)")]
        Customer,
        /// <summary>
        /// 会员
        /// </summary>
        [Display(Name = "会员")]
        Member,
    }

    /// <summary>
    /// 单据类型
    /// </summary>
    [Description("单据类型")]
    public enum BillDocumentType
    {
        /// <summary>
        /// 测试
        /// </summary>
        [Display(Name = "测试")]
        Test = 0,
        [Display(Name = "采购单")]
        PurchaseOrder,
        [Display(Name = "采购收货单")]
        PurchaseReceivingOrder,
        [Display(Name = "采购验货单")]
        PurchaseCheckingOrder,
        [Display(Name = "库存记录")]
        PurchaseInInventeryOrder,
        [Display(Name = "采购退货单")]
        PurchaseOrderReturn,
        [Display(Name = "采购结算单")]
        PurchaseCashOrder,
        [Display(Name = "销售单")]
        SalesOrder,
        [Display(Name = "销售取消单")]
        SalesOrderCancel,
        [Display(Name = "销售结算单")]
        SalesOrderBalance,
        [Display(Name = "销售出库单")]
        SalesOrderOutInventory,
        [Display(Name = "销售退货申请单")]
        SalesOrderReturn,
        [Display(Name = "销售退货取消单")]
        OrderReturnCancel,
        [Display(Name = "销售退货验收单")]
        OrderReturnCheck,
        [Display(Name = "销售退货入库单")]
        OrderReturnInInventory,
        [Display(Name = "直销退后单")]
        OrderDirectReturn,
        [Display(Name = "零售单")]
        RetailOrder,
        [Display(Name = "药品养护检查记录")]
        DrugMaintain,
        [Display(Name="拒收单")]
        refuseDocument,
        [Display(Name="待处理药品单")]
        DrugUndeterminate,
        [Display(Name = "不合格药品单")]
        DrugUnqualification,
        [Display(Name = "销售冲差价单")]
        PurchaseRefund,
        [Display(Name = "药品报损单")]
        DrugBreakage,
        [Display(Name = "药品销毁单")]
        DrugDestroy,
        [Display(Name = "销售配送单")]
        Delivery,
        [Display(Name="直调销售单")]
        DirectSale,

    }
    /// <summary>
    /// 配送状态
    /// </summary>
    [Description("配送状态")]
    public enum DeliveryStatus
    {
        [Display(Name="正常")]
        Normal=0,
        /// <summary>
        /// 配送预约
        /// </summary>
        [Display(Name = "配送预约")]
        Reservation = 1,
        /// <summary>
        /// 配送受理
        /// </summary>
        [Display(Name = "配送受理")]
        Accepted,
        /// <summary>
        /// 配送取消
        /// </summary>
        [Display(Name = "配送取消")]
        Canceled,
        /// <summary>
        /// 配送出库
        /// </summary>
        [Display(Name = "配送出库")]
        Outed,
        /// <summary>
        /// 配送签收
        /// </summary>
        [Display(Name = "配送签收")]
        Signed,
        /// <summary>
        /// 销退申请
        /// </summary>
        [Display(Name = "销退申请")]
        Return,

        //一下状态暂不使用
#if false
        /// <summary>
        /// 未签收退货
        /// </summary>
        [Display(Name = "未签退货")]//未收退货申请单据编号
        UnSignReturning,
        /// <summary>
        /// 未签收退货确认(接下来走入库申请了)
        /// </summary>
        [Display(Name = "未签退货承认")]
        UnSignReturned,
        /// <summary>
        /// 配退申请
        /// </summary>
        [Display(Name = "签后退货申请")]//
        SignedReturning,
        /// <summary>
        /// 配退验收
        /// </summary>
        [Display(Name = "签后退货承认")]
        SignedReturned,
        /// <summary>
        /// 配退申请取消
        /// </summary>
        [Display(Name = "签后退货申请取消")]
        SignedReturnCancel,
#endif
    }

    /// <summary>
    /// 配送类型
    /// </summary>
    [Description("配送类型")]
    public enum DeliveryMethod
    {
        /// <summary>
        /// 自理
        /// </summary>
        [Display(Name = "客户自理")]
        CustSelf = 0,

        /// <summary>
        /// 自理
        /// </summary>
        [Display(Name = "自有车辆运输")]
        Self = 1,

        /// <summary>
        /// 委托
        /// </summary>
        [Display(Name = "委托运输")]
        Entrust = 2,
    }
    /// <summary>
    /// 运输类型
    /// </summary>
    [Description("运输类型")]
    public enum TransportMethod
    {
        [Display(Name="客户自理")]
        Normal=0,
        /// <summary>
        /// 自有车辆运输
        /// </summary>
        [Display(Name = "自有车辆运输")]
        OwnVehicle = 1,
        /// <summary>
        /// 委托运输
        /// </summary>
        [Display(Name = "委托运输")]
        Entrust = 2,
        /// <summary>
        /// 拼箱发货
        /// </summary>
        [Display(Name = "拼箱发货")]
        LCL = 3,
    }


    /// <summary>
    /// 药品养护类型
    /// </summary>
    [Description("药品养护类型")]
    public enum DrugMaintainType
    {
        /// <summary>
        /// 普通药品
        /// </summary>
        [Display(Name = "普通药品")]
        Normal = 0,

        /// <summary>
        /// 特殊药品
        /// </summary>
        [Display(Name = "特殊药品")]
        Special = 1,

        /// <summary>
        /// 医疗器械
        /// </summary>
        [Display(Name = "医疗器械")]
        Inst = 2,

        /// <summary>
        /// 中药饮片
        /// </summary>
        [Display(Name = "中药饮片")]
        Zyyp = 3,

        /// <summary>
        /// 中药材
        /// </summary>
        [Display(Name = "中药材")]
        Zyc = 4,

        [Display(Name = "保健食品")]
        BJSP = 5
    }

    /// <summary>
    /// 生成单号类型
    /// </summary>
    [Description("生成单号类型")]
    public enum DocumentNumberType
    {
        /// <summary>
        /// 普通药品
        /// </summary>
        [Display(Name = "采购单号")]
        PurchaseOrderNumber,

        /// <summary>
        /// 特殊药品
        /// </summary>
        [Display(Name = "验收入库单号")]
        CheckInInventoryNumber = 1
    }

    /// <summary>
    /// 统计对象
    /// </summary>
    [Description("统计对象")]
    public enum StatisticObject
    {
        /// <summary>
        /// 药品
        /// </summary>
        [Display(Name = "品种")]
        Drug = 0,

        /// <summary>
        /// 采购商
        /// </summary>
        [Display(Name = "购货商")]
        Buyer,

        /// <summary>
        /// 销售员
        /// </summary>
        [Display(Name = "销售员")]
        Seller,

        
        [Display(Name = "仓库库位")]
        WareHouseZone,

        [Display(Name = "剂型")]
        DoSage,

        [Display(Name = "经营范围")]
        BussinessType,

        [Display(Name="中西药")]
        ChinesOrWestern
    }

    /// <summary>
    /// 统计时间单位
    /// </summary>
    [Description("统计时间单位")]
    public enum StatisticTimeUnit
    {
        /// <summary>
        /// 月
        /// </summary>
        [Display(Name = "月")]
        Month = 0,

        /// <summary>
        /// 年
        /// </summary>
        [Display(Name = "年")]
        Year,
    }


    [Description("证书类型")]
    public enum LicenseType
    {
        /// <summary>
        /// GSP证书
        /// </summary>
        [Display(Name = "GSP证书")]
        GSP,
        /// <summary>
        /// GMP证书
        /// </summary>
        [Display(Name = "GMP证书")]
        GMP,
        /// <summary>
        /// 营业执照
        /// </summary>
        [Display(Name = "营业执照")]
        BusinessLicense,
        /// <summary>
        /// 事业单位法人证书
        /// </summary>
        [Display(Name = "事业单位法人证书")]
        LnstitutionLegalPersonLicense,
        /// <summary>
        /// 组织机构代码证
        /// </summary>
        [Display(Name = "组织机构代码证")]
        OrganizationCodeLicense,
        /// <summary>
        /// 法人委托书
        /// </summary>
        [Display(Name = "法人委托书")]
        LegalPersonAttorney,
        /// <summary>
        /// 医疗机构执业许可证
        /// </summary>
        [Display(Name = "医疗机构执业许可证")]
        MmedicalInstitutionPermit,
        /// <summary>
        /// 器械经营许可证
        /// </summary>
        [Display(Name = "医疗器械经营许可证")]
        InstrumentsBusinessLicense,
        /// <summary>
        /// 器械生产许可证
        /// </summary>
        [Display(Name = "医疗器械生产许可证")]
        InstrumentsProductionLicense,
        /// <summary>
        /// 药品生产许可证
        /// </summary>
        [Display(Name = "药品生产许可证")]
        MedicineProductionLicense,
        /// <summary>
        /// 药品经营许可证
        /// </summary>
        [Display(Name = "药品经营许可证")]
        MedicineBusinessLicense,
        /// <summary>
        /// 卫生许可证
        /// </summary>
        [Display(Name = "卫生许可证")]
        HealthLicense,
        /// <summary>
        /// 食品流通许可证
        /// </summary>
        [Display(Name = "食品流通许可证")]
        FoodCirculateLicense,
        /// <summary>
        /// 税务登记证
        /// </summary>
        [Display(Name = "税务登记证")]
        TaxRegisterLicense,

        /// <summary>
        /// 全国工业产品生产许可证
        /// </summary>
        [Display(Name = "全国工业产品生产许可证")]
        IndustoryProductCertificateLiscence,

        /// <summary>
        /// 其他证书
        /// </summary>
        [Display(Name = "其他证书")]
        OtherLicense
    }


    /// <summary>
    /// 药品销售类型
    /// </summary>
    [Description("药品销售类型")]
    public enum SalesDrugType
    {
        /// <summary>
        /// 药品
        /// </summary>
        [Display(Name = "药品")]
        Drug,

        /// <summary>
        /// 中药材
        /// </summary>
        [Display(Name = "中药材")]
        ChineseDrug,

        /// <summary>
        /// 中药饮品
        /// </summary>
        [Display(Name = "中药饮片")]
        ChineseDrugDrink,

        [Display(Name="医疗器械")]
        Instrument
    }



    /// <summary>
    /// 提货方式
    /// </summary>
    [Description("提货方式")]
    public enum PickUpGoodType
    {
        /// <summary>
        /// 送货
        /// </summary>
        [Display(Name = "送货")]
        Delivered=0,

        /// <summary>
        /// 客户自提
        /// </summary>
        [Display(Name = "客户自提")]
        GetBySelf=1,

        /// <summary>
        /// 委托运输
        /// </summary>
        [Display(Name="委托运输")]
        DelegateTransport=2
    }

    /// <summary>
    /// 人员类型
    /// </summary>
    [Description("人员类型")]
    public enum PersonType
    {

        /// <summary>
        /// 员工
        /// </summary>
        [Display(Name = "员工")]
        Employee,
        /// <summary>
        /// 供货商销售人员
        /// </summary>
        [Display(Name = "供货商销售人员")]
        SupplyUnitSalesman,

        /// <summary>
        /// 客户采购人员
        /// </summary>
        [Display(Name = "客户采购人员")]
        PurchaseUnitBuyer
    }

    /// <summary>
    /// 采购限制类型
    /// </summary>
    [Description("采购限制类型")]
    public enum PurchaseLimitType
    {

        /// <summary>
        /// 一次
        /// </summary>
        [Display(Name = "一次")]
        Once,
        /// <summary>
        /// 长期
        /// </summary>
        [Display(Name = "长期")]
        Long,
    }

    public enum drugsUnqualificationType
    {
        药品过期或包装破损,
        药品存储或养护检验不合格,
        药品陈列销售检验不合格,
        售后退货药品验收不合格
    }

    //update 2013-3-10
    //待处理药品来源
    public enum sourceType
    {
        全部,
        收货,
        养护,
        其他
    }
    /// <summary>
    /// 直调验收方式
    /// </summary>
    public enum DirectSaleType
    {
        直调委托验收,
        直调驻厂验收
    }
    /// <summary>
    /// 直调验收状态
    /// </summary>
    public enum DirectSalesSatus
    {
        UnChecked,
        Checked,
    }

    /// <summary>
    /// 销售开票时，限定价格规则
    /// </summary>
    public enum SalePriceControlEnum
    {
       [Display(Name="不低于采购价")]
        不低于采购价=0,       
        [Display(Name = "可低于采购价")]
        可低于采购价=1,
         [Display(Name = "不高于最高定价")]
        不高于最高定价=2,        
    }



}

