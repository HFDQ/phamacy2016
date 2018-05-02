using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 单据编号
    /// </summary>
    [Description("单据编号")]
    [DataContract(IsReference = true)]
    public class BillDocumentCode : Entity, ILEntity,IStore
    {
        #region Entiy Property

        /// <summary>
        /// 锁定了
        /// 已经某界面显示了但未使用
        /// </summary>
        [Required]
        [DataMember]
        public bool Locked { get; set; }

        /// <summary>
        /// 已经使用了
        /// </summary>
        [Required]
        [DataMember]
        public bool Used { get; set; }

        /// <summary>
        /// 使用记录编号
        /// </summary>
        [Required]
        [DataMember]
        public Guid UsedId { get; set; } 

        /// <summary>
        /// 取消了
        /// </summary>
        [Required]
        [DataMember]
        public bool Canceled { get; set; }



        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        [DataMember]
        [MaxLength(20)]
        [MinLength(1)]
        public string Code { get; set; }

        [Required]
        [DataMember]
        public int BillDocumentTypeValue { get; set; }


        [NotMapped]
        [IgnoreDataMember]
        public BillDocumentType BillDocumentType
        {
            get
            {
                return (BillDocumentType)BillDocumentTypeValue;
            }
            set
            {
                BillDocumentTypeValue = (int)value;
            }
        }

        #region ILEntity

        [Required]
        [DataMember]
        public DateTime CreateTime { get; set; }

        [Required]
        [DataMember]
        public Guid CreateUserId { get; set; }

        [DataMember]
        public DateTime UpdateTime { get; set; }

        [DataMember]
        public Guid UpdateUserId { get; set; }

        #endregion

        #endregion

        #region Navigation Property

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        #endregion

    }
}
