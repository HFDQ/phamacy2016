using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseForm
{
    public partial class PurchaseRecordList : BaseFunctionForm
    {
        public PurchaseRecordList()
        {
            InitializeComponent();
          
        }

        public PurchaseRecordList(params object[] args)
            : this()
        {
            if (args != null && args.Length > 0)
            {

                PurchaseRecordType type = EnumHelper<PurchaseRecordType>.Parse(args[0].ToString());
                this.Text=EnumHelper<PurchaseRecordType>.GetDisplayValue(type);
                this.ucPurchaseRecord1.GridPurchaseRecordType = type;
            }
        }
    }
}
