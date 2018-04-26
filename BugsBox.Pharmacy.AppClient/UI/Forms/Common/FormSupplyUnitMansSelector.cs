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
    public partial class FormSupplyUnitMansSelector : BaseFunctionForm
    {
        private string msg = string.Empty;
        /// <summary>
        /// 供方销售员
        /// </summary>
        public FormSupplyUnitMansSelector()
        {
            InitializeComponent();
        }


        public FormSupplyUnitMansSelector(Guid supplyUnitGuid)
        {
            InitializeComponent();
            try
            {
                dataGridView1.DataSource = this.PharmacyDatabaseService.AllSupplyUnitSalesmans(out msg).Where(p => p.SupplyUnitId == supplyUnitGuid && p.Enabled == true && p.Valid == true).ToList();
                ProcessGridViewAppearance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcessGridViewAppearance()
        {
            foreach (DataGridViewColumn clm in this.dataGridView1.Columns)
            {
                switch (clm.Name)
                {
                    case "Name":
                        clm.HeaderText = "姓名";
                        clm.Visible = true;
                        break;
                    case "Tel":
                        clm.HeaderText = "电话";
                        clm.Visible = true;
                        break;
                    case "Address":
                        clm.HeaderText = "地址";
                        clm.Visible = true;
                        break;
                    case "Gender":
                        clm.HeaderText = "性别";
                        clm.Visible = true;
                        break;
                    default:
                        clm.Visible = false;
                        break;
                }
            }
        }
    }
}
