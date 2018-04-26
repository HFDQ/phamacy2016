using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Common.Security
{
    public class EncodeHelper
    {
        #region base64  

        public static string Base64Encode(string code, Encoding coding = null)
        {
            coding = coding ?? Encoding.UTF8;
            var buffer = coding.GetBytes(code);
            var encode = Convert.ToBase64String(buffer);
            return encode;
        } 
 
        public static string Base64Decode(string code, Encoding coding = null)
        {
            coding = coding ?? Encoding.UTF8;
            byte[] buffer = Convert.FromBase64String(code);
            var decode = coding.GetString(buffer); ;
            return decode;
        } 

        #endregion 
    }
}
