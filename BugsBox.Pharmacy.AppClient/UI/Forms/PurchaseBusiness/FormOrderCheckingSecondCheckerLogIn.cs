using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormOrderCheckingSecondCheckerLogIn : BaseFunctionForm
    {
        Business.Models.PurchaseCommonEntity pce = null;

        public FormOrderCheckingSecondCheckerLogIn( Business.Models.PurchaseCommonEntity pce)
        {
            InitializeComponent();
            this.pce = pce;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var c = this.PharmacyDatabaseService.GetUserByPosition("验收", this.textBox1.Text.Trim(), BugsBox.Common.Security.EncodeHelper.Base64Encode(this.textBox2.Text.Trim()));
            if (c.Count<Models.User>() <= 0)
            {
                MessageBox.Show("请输入第二验收员账户和密码信息！");
                return;
            }
            Models.User Checker = c.First<Models.User>();

            if (BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id == Checker.Id)
            {
                MessageBox.Show("您输入的是当前验收员的账户和密码,请输入第二验收员账户和密码信息！");
                return;
            }
            pce.SecondCheckerId = Checker.Id;
            pce.SecondCheckerName = Checker.Employee.Name;
            pce.SecondCheckMemo = this.textBox3.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
