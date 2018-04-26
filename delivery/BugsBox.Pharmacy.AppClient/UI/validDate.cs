using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI
{
    class validDate
    {
        System.IFormatProvider format = new System.Globalization.CultureInfo("zh-CN", true);

        public bool validStringIsDate(string str)
        {
            try
            {
                DateTime dt = DateTime.ParseExact(str, "yyyyMMdd", format);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查日期是否正确");
                return false;

            }
        }
    }
}
