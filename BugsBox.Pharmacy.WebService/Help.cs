using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace BugsBox.Pharmacy.WebService
{
    public class Help
    {
        public static bool CheckToken(string token, int i)
        {
            return token.Equals(GetMD5("dongqing" + DateTime.Now.ToString("MMdd") + i));
        }
        
        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }

    }
}