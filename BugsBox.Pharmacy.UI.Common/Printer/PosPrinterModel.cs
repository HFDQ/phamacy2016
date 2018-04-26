using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common.Printer
{
    /// <summary>
    /// 小票打印实体类模板
    /// </summary>
    public class PosPrinterModel
    {
        public string Header { get; set; }

        public string Footer { get; set; }

        /// <summary>
        /// 单号
        /// </summary>
        public string SaildID { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public string GeneDate { get; set; }

        /// <summary>
        /// 明细数据
        /// </summary>
        public List<List<string>> Datas{ get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string Nums { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public string TotalPrice { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public string Discount { get; set; }

        /// <summary>
        /// 应收金额
        /// </summary>
        public string ActualCash { get; set; }

        /// <summary>
        /// 收款金额
        /// </summary>
        public string ReceiveCash { get; set; }

        /// <summary>
        /// 找零金额
        /// </summary>
        public string RetCash { get; set; }

        /// <summary>
        /// 会员卡号 
        /// </summary>
        public string CardNo { get; set; }


        /// <summary>
        /// 本次积分
        /// </summary>
        public string MarkIn { get; set; }

        /// <summary>
        /// 可用积分
        /// </summary>
        public string MarkAvailable { get; set; }

        /// <summary>
        /// 卡 消 费 
        /// </summary>
        public string CardConsume { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        public string CardAvailable { get; set; }

    }
}
