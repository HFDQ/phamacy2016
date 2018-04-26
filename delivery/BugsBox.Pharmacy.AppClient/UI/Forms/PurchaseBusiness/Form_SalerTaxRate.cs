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
    public partial class Form_SalerTaxRate : BaseFunctionForm
    {
        IEnumerable<UserEm> ListUser;
        string msg = string.Empty;

        public Form_SalerTaxRate()
        {
            InitializeComponent();            
            this.dataGridView1.AutoGenerateColumns = false;

            var c = this.PharmacyDatabaseService.AllUsers(out msg).OrderBy(r=>r.Employee.Name);
            var role = this.PharmacyDatabaseService.AllRoles(out msg);
            var rw = this.PharmacyDatabaseService.AllRoleWithUsers(out msg);

            ListUser = from i in rw
                          join j in c on i.UserId equals j.Id
                          join k in role on i.RoleId equals k.Id
                          select new UserEm
                          {
                               name=j.Employee.Name,
                               Duty=k.Name,
                               Id=j.Id,
                               PurchaseTaxReturn = j.PurchaseTaxReturn
                          };
            var GroupListUser = from i in ListUser
                    group i by i.Id into g
                    let dutys=g.Select(b=>b.Duty)
                    select new UserEm
                    {
                        name = g.FirstOrDefault().name,
                        Duty = String.Join(",",dutys),
                        Id = g.FirstOrDefault().Id,
                        PurchaseTaxReturn = g.FirstOrDefault().PurchaseTaxReturn
                    };
            this.dataGridView1.DataSource = GroupListUser.OrderBy(r => r.name).ToList();
        }

        public Form_SalerTaxRate(Guid Uid):this()
        {
            ListUser= ListUser.Where(r => r.Id == Uid).ToList();
            if (ListUser == null)
            {
                MessageBox.Show("账号出现问题，请联系管理员！");
                return;
            }
            this.dataGridView1.DataSource = ListUser;
        }
        
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0||e.ColumnIndex<0) return;
            UserEm u=(UserEm)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            Models.User usr = this.PharmacyDatabaseService.GetUser(out msg, u.Id);
            usr.PurchaseTaxReturn = u.PurchaseTaxReturn;
            if (this.PharmacyDatabaseService.SaveUser(out msg, usr))
            {
                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("保存失败，请联系管理员！");
            }
        }

    }
    public class UserEm
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string Duty { get; set; }
        public decimal? PurchaseTaxReturn { get; set; }
    }
}
