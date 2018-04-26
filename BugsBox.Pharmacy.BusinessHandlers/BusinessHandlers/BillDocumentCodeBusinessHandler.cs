using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class BillDocumentCodeBusinessHandler
    {
        private static readonly object lockHelper = new object();
        /// <summary>
        /// 根据单据类型获取新的单据编号
        /// Code Demo:2013 0808 1212 0000 0000
        /// Code Desc:yyyy MMdd HHmm TYPE 0000(0001)
        /// </summary>
        /// <param name="typeValue"></param>
        /// <returns></returns>
        public BillDocumentCode GenerateBillDocumentCodeByTypeValue(int typeValue)
        {
           
            lock (lockHelper)
            {
                DateTime now=DateTime.Now;
                try
                {
                    BillDocumentType codeType;
                    if (!Enum.GetValues(typeof(BillDocumentType)).Cast<int>().Contains(typeValue))
                    {
                        throw new Exception("单据类型值不正确即没有定义");
                    }
                    else
                    {
                        codeType = (BillDocumentType)typeValue;
                    }
                    BillDocumentCode code = new BillDocumentCode();
                    code.Canceled = false;
                    code.Locked = true;
                    code.CreateTime = now;
                    code.UpdateTime = code.CreateTime;
                    code.UpdateUserId = code.CreateUserId;
                    code.BillDocumentTypeValue = typeValue;
                    //计算编号
                    string head = "";
                    switch (typeValue)
                    {
                        case 1:
                            head = "CGD";
                            break;
                        case 2:
                            head = "SHD";
                            break;
                        case 3:
                            head = "YHD";
                            break;
                        case 4:
                            head = "KCJLD";
                            break;
                        case 5:
                            head = "CGTHD";
                            break;
                        case 6:
                            head = "CGJSD";
                            break;
                        case 7:
                            head = "XSD";
                            break;
                        case 8:
                            head = "XSQXD";
                            break;
                        case 9:
                            head = "XSJSD";
                            break;
                        case 10:
                            head = "XSCKD";
                            break;
                        case 11:
                            head = "XTSQD";
                            break;
                        case 12:
                            head = "XTQXD";
                            break;
                        case 13:
                            head = "XTYSD";
                            break;
                        case 14:
                            head = "XTRKD";
                            break;
                        case 15:
                            head = "ZXTHD";
                            break;
                        case 16:
                            head = "LSD";
                            break;
                        case 17:
                            head = "YHJLD";
                            break;
                        case 18:
                            head = "JSD";
                            break;
                        case 19:
                            head = "DCLD";
                            break;
                        case 20:
                            head = "BHGD";
                            break;
                        case 21:
                            head = "CGCCJD";
                            break;
                        case 22:
                            head = "YPBSD";
                            break;
                        case 23:
                            head = "YPXHD";
                            break;
                        case 24:
                            head = "PSD";
                            break;
                        case 25:
                            head = "ZDXSD";
                            break;
                    }
                    string codeTest = head + now.ToString("yyyyMMdd");

                    int lastcode = this.Fetch(c => c.BillDocumentTypeValue == typeValue).Count() + 1;
                    string serialNumber = lastcode.ToString().PadLeft(6, '0');
                    string generateCode = codeTest + serialNumber;
                    code.Code = generateCode;

                    this.Add(code);
                    //if (!string.IsNullOrWhiteSpace(messge))
                    //{
                    //    throw new Exception(messge);
                    //}
                    return code;
                }
                catch (Exception ex)
                {
                    ex = new BusinessException("根据单据类型获取新的单据编号失败", ex);
                    return this.HandleException<BillDocumentCode>(ex.Message, ex);
                }
                finally
                {
                    this.Dispose();
                }
            }
           
        }
        
        /// <summary>
        /// 将单据编号设置为已经使用(未保存)
        /// 由具体单据入数据库使用
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        internal bool SetBillDocumentCodeUsed(BillDocumentCode code)
        {
            try
            {
                code.Canceled = false;
                code.Used = true;
                code.Locked = false;
                code.UpdateTime = DateTime.Now; 
                this.Save(code);
                return true;
            }
            catch (Exception ex)
            {
                ex = new BusinessException("根据单据类型获取新的单据编号失败", ex);
                return this.HandleException<bool>(ex.Message, ex);
            }
        }

        /// <summary>
        /// 将单据编号设置为已经Canceled(未保存) 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        internal bool SetBillDocumentCodeCanceled(BillDocumentCode code)
        {
            try
            {
                code.Canceled = true;
                code.Used = false;
                code.Locked = true;
                code.UpdateTime = DateTime.Now;
                this.Save(code);
                return true;
            }
            catch (Exception ex)
            {
                ex = new BusinessException("根据单据类型获取新的单据编号失败", ex);
                return this.HandleException<bool>(ex.Message, ex);
            }
        }
    }
}
