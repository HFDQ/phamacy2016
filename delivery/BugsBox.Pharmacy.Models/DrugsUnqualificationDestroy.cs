using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    
        [Description("不合格药品销毁情况")]
        [DataContract]
        public class DrugsUnqualificationDestroy : Entity
        {

            /// <summary>
            /// 创建人
            /// </summary>
            [Required]
            [DataMember]
            public System.Guid createUID
            {
                get;
                set;
            }

            /// <summary>
            /// 创建时间
            /// </summary>
            [DataMember]
            public DateTime createTime
            {
                get;
                set;
            }

            /// <summary>
            /// 更新时间
            /// </summary>
            [DataMember]
            public System.DateTime updateTime
            {
                get;
                set;
            }

            /// <summary>
            /// 药品名称
            /// </summary>
            [DataMember]
            public string drugName
            {
                get;
                set;
            }

            /// <summary>
            /// 药品批次号
            /// </summary>
            [DataMember]
            public string batchNo
            {
                get;
                set;
            }
            

            /// <summary>
            /// 生产商
            /// </summary>
            [DataMember]
            public string FactoryName { get; set; }


            //销毁药品总额
            [DataMember]
            public decimal price
            {
                get;
                set;
            }

            /// <summary>
            /// 原所在库位
            /// </summary>
            [DataMember]
            public string wareHouseZone
            {
                get;
                set;
            }

            /// <summary>
            /// 销毁方式
            /// </summary>
            [DataMember]
            public string DestroyMethod
            {
                get;
                set;
            }

            /// <summary>
            /// 销毁原因
            /// </summary>
            [DataMember]
            public string DestroyReason
            {
                get;
                set;
            }

            /// <summary>
            /// 销毁地点
            /// </summary>
            [DataMember]
            public string DestroyPlace
            {
                get;
                set;
            }

            /// <summary>
            /// 销毁时间
            /// </summary>
            [DataMember]
            public DateTime DestroyTime
            {
                get;
                set;
            }

            /// <summary>
            /// 运输工具
            /// </summary>
            [DataMember]
            public string DestroyCargo
            {
                get;
                set;
            }

            /// <summary>
            /// <运输人员
            /// </summary>
            [DataMember]
            public string DestroyMan
            {
                get;
                set;
            }

            /// <summary>
            /// <销毁执行人员>
            /// </summary>
            [DataMember]
            public string Destroyer
            {
                get;
                set;
            }

            /// <summary>
            /// <销毁后现场情况>
            /// </summary>
            [DataMember]
            public string DestroyState
            {
                get;
                set;
            }

            /// <summary>
            /// <药监部门意见>
            /// </summary>
            [DataMember]
            public string SupervisorOpinion
            {
                get;
                set;
            }

            /// <summary>
            /// 药品不合格ID及导航属性
            /// </summary>
            [DataMember]
            public Guid DrugsUnqualicationID { get; set; }


            //规格
            [DataMember]
            public string Specific
            {
                get;
                set;
            }

            //剂型
            [DataMember]
            public string DosageType
            {
                get;
                set;
            }

            /// <summary>
            /// 生产日期
            /// </summary>
            [DataMember]
            public DateTime produceDate
            {
                get;
                set;
            }

            /// <summary>
            /// 失效期
            /// </summary>
            [DataMember]
            public DateTime ExpireDate
            {
                get;
                set;
            }

            /// <summary>
            /// 品种ID
            /// </summary>
            [DataMember]
            public Guid DrugInfoId { get; set; }

            /// <summary>
            /// 产地
            /// </summary>
            [DataMember]
            public string Origin
            {
                get;
                set;
            }

            /// <summary>
            /// 购进价格
            /// </summary>
            [DataMember]
            public decimal PurchasePrice { get; set; }

        }
    
}
