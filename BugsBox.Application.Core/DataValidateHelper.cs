using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BugsBox.Application.Core
{
    //数据类型：INTEGER整数；POSINTERGER 非零正整数；FLOAT 浮点型
    public enum AttributeDataType { INTEGER = 1,POSINTERGER=2, FLOAT = 3 };


    /// <summary>
    /// 数据校验
    /// INTEGER ,POSINTERGER, FLOAT 三种可传入AttributeDataType 进行校验
    /// 也可直接传入正则表达式进行校验
    /// </summary>
    public static class DataValidateHelper
    {
        /// <summary>
        /// 使用正则表达式进行校验
        /// </summary>
        /// <param name="attributeValue">待校验的数据</param>
        /// <param name="strFormat">校验正则表达式</param>
        /// <returns></returns>
        public static bool DataValidate(string attributeValue, string strFormat)
        {
            Regex regex;
            regex = new Regex(strFormat);

            return regex.IsMatch(attributeValue);

        }

        /// <summary>
        /// 使用AttributeDataType数据类型进行校验
        /// </summary>
        /// <param name="attributeValue">待校验的数据</param>
        /// <param name="formatType">AttributeDataType数据类型</param>
        /// <returns></returns>
        public static bool DataTypeValidate(string attributeValue, AttributeDataType formatType)
        {
            AttributeDataType dataType = (AttributeDataType)Convert.ToInt32(formatType);
            
            Regex regex;
            switch (dataType)
            {
                case AttributeDataType.INTEGER:
                    regex = new Regex("^-?\\d+$");
                    return regex.IsMatch(attributeValue);

                case AttributeDataType.POSINTERGER:
                    regex = new Regex("^[1-9][0-9]*$");
                    return regex.IsMatch(attributeValue);

                case AttributeDataType.FLOAT:
                    regex = new Regex("^(-?\\d+)(\\.\\d+)?$");
                    return regex.IsMatch(attributeValue);

                default:
                    return true;
            }

           
        }
    }
}
