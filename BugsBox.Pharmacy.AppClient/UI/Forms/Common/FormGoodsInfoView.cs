using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class FormGoodsInfoView : Form
    {
        public FormGoodsInfoView(DrugInfo drugInfo)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                DrugInfo = drugInfo;
            }
        }

        public DrugInfo DrugInfo
        {
            get { return this.ucGoodsInfo1.DrugInfo; }
            set 
            {
                this.ucGoodsInfo1.RunMode = FormRunMode.Browse;
                this.ucGoodsInfo1.DrugInfo = value; 
            }
        }

        private void FormGoodsInfoView_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
            }
        }
    }
}
