using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UpdateBugBox
{
    public partial class Form1 : Form
    {
        string dir = "应用客户端";
        public Form1()
        {
            InitializeComponent();
            
        }

        private bool CopyFiles()
        {
            try
            {
                var Files = System.IO.Directory.GetFileSystemEntries(System.IO.Directory.GetCurrentDirectory() + "\\应用客户端\\");
                foreach (var d in Files)
                {
                    bool b = Directory.Exists(d);
                    if (!b)
                    {
                        string FileName = System.IO.Directory.GetCurrentDirectory() + "\\" + d.Substring(d.LastIndexOf('\\') + 1, d.Length - d.LastIndexOf('\\') - 1);
                        if (FileName.Contains("UpdateBugBox")) continue;
                        File.Copy(d, FileName, true);
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失败!\r\n"+ex.Message);
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if (this.CopyFiles())
            {
                MessageBox.Show("更新成功！");
            }
            Application.Exit();
        }
    }
}
