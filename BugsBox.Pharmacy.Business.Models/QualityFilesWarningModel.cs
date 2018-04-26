using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class QualityFilesWarningModel
    {
        /// <summary>
        /// 资质类别
        /// </summary>
        [DisplayName("类别")]
        public int QualityFileWarningTypeValue { get; set; }


        public Guid Id { get; set; }

        /// <summary>
        /// 企业或者客户或药品名称
        /// </summary>
        [DisplayName("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 预警期限
        /// </summary>
        [DisplayName("预警期限")]
        public DateTime WarningDate { get; set; }

        /// <summary>
        /// 预警设置-单位：月
        /// </summary>
        [DisplayName("预警设置(月)")]
        public int WarningDateSetUpMonth { get; set; }
    }

    public enum QualityFileWarningType
    {
        供货单位,
        客户单位,
        品种许可有效期,
        库存品种近效期,
        库存重点养护品种近效期
    }

    /// <summary>
    /// 资质近效期提示
    /// </summary>
    [Serializable]
    public class NearExpireDateQualifiedFiles
    {
        /// <summary>
        /// 供应商资质预警期限*个月
        /// </summary>
        public int WarningDate { get; set; }

        /// <summary>
        /// 客户资质预警期限
        /// </summary>
        public int PurchaseWarningDate { get; set; }

        /// <summary>
        /// 药品许可证有效期预警期限
        /// </summary>
        public int DrugInfoQualityWarningDate { get; set; }

        /// <summary>
        /// 库存药品近效期预警期限
        /// </summary>
        public int DrugWarningDate { get; set; }

        /// <summary>
        /// 库存重点养护药品近效期预警期限
        /// </summary>
        public int ImpDrugWarningDate { get; set; }
    }

    /// <summary>
    /// 总配置文件，用于存储与本地硬盘
    /// </summary>
    [Serializable]
    public class CommonSetupFile
    {
        /// <summary>
        /// 过期资质对象
        /// </summary>
        public NearExpireDateQualifiedFiles o { get; set; }

        public CommonSetupFile()
        {
            this.o = new NearExpireDateQualifiedFiles
            {
                WarningDate = 1,
                DrugWarningDate = 1,
                PurchaseWarningDate = 1,
                 DrugInfoQualityWarningDate=1
            };
        }
    }
}
