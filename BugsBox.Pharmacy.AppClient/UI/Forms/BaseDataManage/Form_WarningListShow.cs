using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class Form_WarningListShow : Form
    {
        public Form_WarningListShow(List<Business.Models.QualityFilesWarningModel> ListModel)
        {
            InitializeComponent();

            this.dataGridView1.AllowUserToAddRows = false;

            BaseForm.BasicInfoRightMenu cms = new BaseForm.BasicInfoRightMenu(this.dataGridView1);

            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ListModel = ListModel.OrderBy(r => r.QualityFileWarningTypeValue).ThenBy(r => r.Name).ToList();

            var c = from i in ListModel
                    select new QualityModel
                    {
                        Id = i.Id,
                        QualityFileWarningTypeValue = i.QualityFileWarningTypeValue,
                        Name = i.Name,
                        WarningDate = i.WarningDate,
                        WarningDateSetUpMonth = i.WarningDateSetUpMonth,
                        WarningType = ((Business.Models.QualityFileWarningType)i.QualityFileWarningTypeValue).ToString()
                    };

            this.dataGridView1.DataSource = new BindingCollection<QualityModel>(c.ToList());

            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["QualityFileWarningTypeValue"].Visible = false;
        }

        class QualityModel : Business.Models.QualityFilesWarningModel
        {
            [DisplayName("预警类别")]
            public string WarningType { get; set; }

        }
        public event WarningChanged WarningSetupChanged;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form_QualityFileSetup frm = new Form_QualityFileSetup();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (this.WarningSetupChanged != null)
                {
                    this.WarningSetupChanged();
                }
                this.Close();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, DateTime.Now.ToLongDateString()+"资质近效期列表"  );
        }
    }

    public delegate void WarningChanged();
}
