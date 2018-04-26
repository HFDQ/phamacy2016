using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseForm
{
    public partial class FormDZJGM : BaseFunctionForm
    {
        private string _path=null;
        public FormDZJGM()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            string xmlFile = AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml";
            doc.Load(xmlFile);
            XmlNodeList nodeList = doc.SelectNodes("/SalePriceType/DZJGMCX");
            _path = nodeList[0].Attributes["LinkURL"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_path == string.Empty)
                {
                    MessageBox.Show("连接路径未正确设置，请检查！");
                    return;
                }
                System.Diagnostics.Process.Start(_path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
