using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class FormListDepartmentsEmployees : Form
    {
        private Department department;

        public FormListDepartmentsEmployees(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException("部门对象不可为空");
            }
            this.department = department;
            InitializeComponent();
        }
    }
}
