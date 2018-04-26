using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace BugsBox.Pharmacy.AppClient.Side
{
    public partial class Task : DockContent
    {
        public Task()
        {
            InitializeComponent();
        }

        private void Task_FormClosed(object sender, FormClosedEventArgs e)
        {
            //(Parent.FindForm() as frmMain).我的任务ToolStripMenuItem.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //(Parent.FindForm() as frmMain).ShowForm(new Event.入库());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //(Parent.FindForm() as frmMain).ShowForm(new Event.养护());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //(Parent.FindForm() as frmMain).ShowForm(new Event.拣货());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //(Parent.FindForm() as frmMain).ShowForm(new Event.拣货核查());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //(Parent.FindForm() as frmMain).ShowForm(new Event.运输());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BugsBox.Pharmacy.AppClient.UI.Forms.Approval.FormApprovalFlowCenter form = new UI.Forms.Approval.FormApprovalFlowCenter();
            (Parent.FindForm() as frmMain).ShowForm(form);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //(Parent.FindForm() as frmMain).ShowForm(new Event.疑问药品());
        }
    }
}
