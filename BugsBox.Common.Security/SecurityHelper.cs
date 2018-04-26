using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BugsBox.Common.Security
{
    /// <summary>
    /// 加密与解密助手
    /// </summary>
    public static class SecurityHelper
    {
        #region Md5

        private static readonly MD5 Md5 = new MD5CryptoServiceProvider();

        public static byte[] Md5EncodeBytes(byte[] bytes)
        {
           byte[] buffer = Md5.ComputeHash(bytes, 0, bytes.Length);
           return buffer;
        }

        public static string Md5Encode(byte[] bytes)
        {
            byte[] buffer = Md5EncodeBytes(bytes);
            var encode = BitConverter.ToString(buffer).Replace("-", "");
            return encode;
        }

        public static string Md5Encode(string code, Encoding coding = null)
        {
            coding = coding ?? Encoding.Default;
            byte[] bytes = coding.GetBytes(code);
            var encode = Md5Encode(bytes);
            return encode; 
 
        }

        public static byte[] Md5EncodeBytes(string code, Encoding coding = null)
        {
            coding=coding ?? Encoding.Default;
            byte[] bytes = coding.GetBytes(code);
            byte[] buffer = Md5EncodeBytes(bytes);
            return buffer;
        } 

        #endregion 

        #region RSA

        #endregion  

        #region SHA1

        static SHA1 Sha1 = new SHA1CryptoServiceProvider();

        public static byte[] SHA1EncodeBytes(byte[] bytes)
        {
            byte[] buffer = Sha1.ComputeHash(bytes, 0, bytes.Length); 
            return buffer;
        }

        public static string SHA1Encode(byte[] bytes)
        {
            byte[] buffer = SHA1EncodeBytes(bytes);
            var encode = BitConverter.ToString(buffer).Replace("-", "");
            return encode;
        }

        public static string SHA1Encode(string code, Encoding coding = null)
        {
            coding = coding ?? Encoding.Default;
            byte[] bytes = coding.GetBytes(code);
            var encode = SHA1Encode(bytes);
            return encode;

        }

        public static byte[] SHA1EncodeBytes(string code, Encoding coding = null)
        {
            coding = coding ?? Encoding.Default;
            byte[] bytes = coding.GetBytes(code);
            byte[] buffer = SHA1EncodeBytes(bytes);
            return buffer;
        } 

        #endregion 
    }
}
