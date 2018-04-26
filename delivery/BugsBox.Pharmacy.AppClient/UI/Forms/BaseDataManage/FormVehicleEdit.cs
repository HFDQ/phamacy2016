using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DataDictionary
{
    public partial class FormVehicleEdit : BaseFunctionForm
    {
        public DialogResult ruslt = DialogResult.No;

        private FormOperation m_state;
        private Vehicle m_Vehicle = new Vehicle();
        private Guid id ;
        private string msg=string.Empty;
        ApprovalFlowType aft = null;
        List<Vehicle> ListVehicle = new List<Vehicle>();


        public FormVehicleEdit()
        {
            InitializeComponent();
        }
        public FormVehicleEdit(Vehicle vehicle,bool r=false)
        {
            InitializeComponent();

            ListVehicle = this.PharmacyDatabaseService.AllVehicles(out msg).ToList();

            if (vehicle == null)
            {
                this.Width = 280;
                this.Text = "新增车辆";
                m_state = FormOperation.Add;
                m_Vehicle.Id = Guid.NewGuid();
                this.id = Guid.NewGuid();
                this.comboBox1.SelectedIndex = 0;
            }
            else
            {
                this.Width = 280;
                this.Text = "修改车辆";
                m_state = FormOperation.Modify;
                m_Vehicle = vehicle;
                this.id = vehicle.Id;

                this.txtType.Text = vehicle.Type;
                this.txtCubage.Text = vehicle.Cubage;
                this.txtDriver.Text = vehicle.Driver;
                this.txtRule.Text = vehicle.Rule;
                this.txtLicensePlate.Text = vehicle.LicensePlate;
                this.txtOther.Text = vehicle.Other;
                this.chkStatus.Checked = vehicle.Status;
                this.comboBox1.SelectedIndex = vehicle.VehicleCategoryValue;
                if (this.comboBox1.SelectedIndex == 1)
                {
                    this.Width = 540;
                    this.txtDelegateMan.Text = vehicle.DelegateMan;
                    this.txtDelegateCompany.Text = vehicle.DelegateCompany;
                    this.txtDelegateTel.Text = vehicle.DelegateTel;
                    this.textBox2.Text = vehicle.LiscenceCode;
                    this.textBox1.Text = vehicle.DelegateAddr;
                    this.textBox3.Text = vehicle.DelegateScope;
                    this.dateTimePicker1.Value=vehicle.StartDate==null?DateTime.Now.Date:(DateTime)vehicle.StartDate;
                    this.dateTimePicker2.Value=vehicle.EndDate==null?DateTime.Now.Date:(DateTime)vehicle.EndDate;
                }               
            }
            if (r)
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = false;
                }
                btnSave.Visible = false;
                btnCancel.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要提交吗？", "", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            aft = this.PharmacyDatabaseService.GetApprovalFlowTypeByBusiness(out msg, ApprovalType.VehicleApproval).FirstOrDefault();

            if (aft == null)
            {
                MessageBox.Show("定义委托车辆需定义审批流程，请通知管理员定义该审批流程！");
                this.Dispose();
            }
            try
            {
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(TextBox))
                    {
                        if (string.IsNullOrEmpty(c.Text.Trim()))
                        {
                            MessageBox.Show("有未填项！", "警告");
                            c.Focus();
                            return;
                        }
                    }
                }
                
                    m_Vehicle.Type = this.txtType.Text.Trim();
                    m_Vehicle.Cubage = this.txtCubage.Text.Trim();
                    m_Vehicle.Rule = this.txtRule.Text.Trim();
                    m_Vehicle.Other = this.txtOther.Text.Trim();
                    m_Vehicle.LicensePlate = this.txtLicensePlate.Text.Trim();
                    m_Vehicle.Driver = this.txtDriver.Text.Trim();
                    m_Vehicle.Status = this.chkStatus.Checked;
                    m_Vehicle.VehicleCategoryValue = this.comboBox1.SelectedIndex;
                    m_Vehicle.createUID = (Guid)BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id;
                    m_Vehicle.DelegateMan = this.txtDelegateMan.Text.Trim();
                    m_Vehicle.DelegateCompany = this.txtDelegateCompany.Text.Trim();
                    m_Vehicle.DelegateTel = this.txtDelegateTel.Text.Trim();
                    m_Vehicle.LiscenceCode = this.textBox2.Text.Trim();
                    m_Vehicle.DelegateAddr = this.textBox1.Text.Trim();
                    m_Vehicle.StartDate = this.dateTimePicker1.Value.Date;
                    m_Vehicle.EndDate = this.dateTimePicker2.Value.Date;
                    m_Vehicle.DelegateScope = this.textBox3.Text.Trim();

                                        
                    if (m_state == FormOperation.Add)
                    {
                        if (m_Vehicle.VehicleCategoryValue == 1)
                        {
                            m_Vehicle.FlowID = Guid.NewGuid();
                            bool b=this.PharmacyDatabaseService.AddVehicleToApprovalByFlowID(m_Vehicle,aft.Id,"新增委托车辆审批",out msg);
                            if (b)
                            {
                                MessageBox.Show("委托车辆信息新增成功！请通知委托车辆信息审批流程人员审查该信息！");
                            }
                        }
                        else
                        {
                            if (PharmacyDatabaseService.AddVehicle(out msg, m_Vehicle))
                            {
                                MessageBox.Show("自有车辆信息新增成功！");
                            }
                        }
                    }
                    else
                    {
                        bool b=PharmacyDatabaseService.SaveVehicle(out msg, m_Vehicle);
                        if (b) MessageBox.Show("保存成功！");
                    }

                    if (!string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg, "Error");
                        return;
                    }

                    ruslt = System.Windows.Forms.DialogResult.Yes;
                    this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存数据失败！", "系统错误");
                Log.Error(ex);
                this.Close(); 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                this.Width = 540;
            }
            else
            {
                this.Width = 280;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string q = this.textBox2.Text.Trim();
            if (this.ListVehicle.Count <= 0) return;
            var c = this.ListVehicle.Where(r => r.LiscenceCode.Contains(q)).ToList();
            if (c.Count <= 0) return;

            Vehicle v = c.First();
            this.textBox2.Text = v.LiscenceCode;
            this.txtDelegateCompany.Text = v.DelegateCompany;
            this.txtDelegateMan.Text = v.DelegateMan;
            this.txtDelegateTel.Text = v.DelegateTel;
            this.textBox1.Text = v.DelegateAddr;
            this.dateTimePicker1.Value = (DateTime)v.StartDate;
            this.dateTimePicker2.Value = (DateTime)v.EndDate;
            this.textBox3.Text = v.DelegateScope;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(10, Guid.Empty);
        }
    }
}
