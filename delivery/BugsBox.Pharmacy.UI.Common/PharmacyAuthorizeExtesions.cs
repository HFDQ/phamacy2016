using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.Common;

namespace System
{
    public static class PharmacyAuthorizeExtesions
    {
        public static bool Authorize(this Control ctrl, string moduleKey)
        {
            return PharmacyAuthorize.ValidateAuthorize(moduleKey);
        }
    }
}
