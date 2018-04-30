using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.UI.Common.Printer;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Business.Models;
using CustomValidatorsLibrary;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugsUnqualification
{
    public partial class formDrugsUnqualification : BaseFunctionForm
    {
        DataTable dt = null;
        private bool flag;
        DrugsUnqualication item = null;
        BindingList<DrugsUnqualication> bList = new BindingList<DrugsUnqualication>();
        double pageNum = 0.0;
        double pageSize=30.0;
        int recordCount = 0;
        decimal count;
        string msg=string.Empty;
        DrugsUnqualication currentDU = null;
        InventeryModel CurrentIM = null;

        public formDrugsUnqualification()
        {
            InitializeComponent();
            this.dgvDrugDetailList.AutoGenerateColumns = false;
            List<int> flowTypeList = new List<int>();
            flowTypeList.Add((int)ApprovalType.drugsUnqualityApproval);
            string msg = string.Empty;
            List<ApprovalFlowType> list = PharmacyDatabaseService.GetApprovalFlowTypeByTypeList(out msg, flowTypeList.ToArray()).Where(r=>r.Deleted==false).ToList();
            this.cmbApprovalSelector.ComboBox.DataSource = list;
            this.cmbApprovalSelector.ComboBox.DisplayMember = "Name";
            this.cmbApprovalSelector.ComboBox.ValueMember = "Id";

            

            #region 事件声明
            this.textBox1.KeyDown+=textBox1_KeyDown;
            this.dgvDrugDetailList.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dgvDrugDetailList.CellDoubleClick+=dgvDrugDetailList_CellDoubleClick;
            this.checkBox1.Click += checkBox1_Click;
            #endregion

            this.dgvDrugDetailList.DataSource = bList;
            this.GetUnqualificationData();
        }

        void checkBox1_Click(object sender, EventArgs e)
        {
            if (this.currentDU == null) return;            
            this.textBox2.Enabled = !this.checkBox1.Checked;
            this.textBox2.Text =this.checkBox1.Checked? this.CurrentIM.CanSaleNum.ToString():"0";
        }
       
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            #region 检测不合格输入的数量及其格式
            try
            {
                count = Convert.ToDecimal(this.textBox3.Text);
                if (Convert.ToDecimal(this.textBox2.Text) > count || Convert.ToDecimal(this.textBox2.Text)==0)
                {
                    this.textBox2.Focus();
                    return;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("请正确输入不合格数量！");
                this.textBox2.Focus();
                return;
            }
            #endregion 

            currentDU.quantity = Convert.ToDecimal(textBox2.Text);

            decimal currentCanSaleNum = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, CurrentIM.InventoryID).CanSaleNum;
            if (currentDU.quantity > currentCanSaleNum)
            {
                MessageBox.Show("当前库存不足，请修改数量");
                this.textBox3.Text = currentCanSaleNum.ToString();
                this.textBox2.Text = "0";
                return;
            }

            currentDU.Description = this.txtRemark.Text.Trim();
            this.PharmacyDatabaseService.EditDrugUnqualification(currentDU, 0, out msg);
            if (msg != string.Empty)
            {
                MessageBox.Show(msg);
                return;
            }
            
            this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功创建不合格药品信息");

            if(((ToolStripButton)sender).Name.Contains(toolStripButton10.Name))
            {
                MessageBox.Show("不合格药品新建成功，但并未提交审核，可点击‘提交审核’按钮执行！");
                this.GetUnqualificationData();
                return;
            }

            if (MessageBox.Show("不合格信息保存成功，需要提交至不合格审批流程吗？ \n注意：提交至不合格审批流程后，将无法更改该信息！", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                currentDU.ApprovalStatusValue = 0;
                if (PharmacyDatabaseService.addDrugsUnqualityApproval(currentDU, Guid.Parse(this.cmbApprovalSelector.ComboBox.SelectedValue.ToString()), currentDU.createUID, "新增不合格审批：" + currentDU.drugName, out msg))
                {
                    MessageBox.Show("成功提交至不合格审批流程,请至审批流程查询审批！");
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功提交不合格药品信息至审批流程:" + currentDU.drugName);
                }
            }           
            this.GetUnqualificationData();
        }

        //刷新列表
        private void GetUnqualificationData()
        {
            drugsUnqualificationCondition duc = new drugsUnqualificationCondition();
            duc.dtFrom = DateTime.MinValue;
            duc.dtTo = DateTime.MaxValue;
            duc.unqualificationType = -1;  //新建不合格
            var c = this.PharmacyDatabaseService.GetDrugsUnqualificationByCondition(out msg,duc);
            c = c.Where(r => r.ApprovalStatusValue == -1 || r.ApprovalStatusValue==4).ToArray();
            bList.Clear();
            foreach (var a in c)
            {
                bList.Add(a);
            }
            this.ClearCurrent();
        }

        //窗体清除
        private void ClearCurrent()
        {
            this.currentDU = null;
            this.CurrentIM = null;
            this.checkBox1.Checked = false;
            toolStripButton10.Enabled =tsbtnSave.Enabled = true;
            this.textBox1.Enabled=true;
            this.toolStripButton8.Enabled = this.toolStripButton2.Enabled=false;
            this.toolStripButton11.Enabled = true;
            foreach (Control control in this.groupBox2.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
            this.txtRemark.Text = "质量问题，需复查或者提交不合格审查";
            this.toolStripComboBox1.SelectedIndex = 0;
        }

        void dgvDrugDetailList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 ) return;
            string msg = string.Empty;
            int rIdx=e.RowIndex;
            Guid itemId=new Guid (this.dgvDrugDetailList.Rows[rIdx].Cells["id"].Value.ToString());
            Guid approvalFlowId = new Guid(this.dgvDrugDetailList.Rows[rIdx].Cells["FlowId"].Value.ToString());
            item= PharmacyDatabaseService.GetDrugsUnqualificationByID(out msg,itemId);
            if(PharmacyDatabaseService.GetFinishApproveFlowsRecord(out msg,approvalFlowId,0).Count()>1)
            {
                FormUnqualificationApprovalDetail f = new FormUnqualificationApprovalDetail();
                Business.Models.drugsUnqualificationQuery dq = PharmacyDatabaseService.getDrugsUnqualificationQueryByFlowID(approvalFlowId, out msg);
                UserControls.ucDrugsUnqualification ucf = new UserControls.ucDrugsUnqualification(dq);                
                f.Height+= ucf.Height;
                f.Controls.Add(ucf);
                ucf.Dock = DockStyle.Fill;
                f.ShowDialog();
                f = null;
                dq = null;
                ucf = null;
            }
            if (item != null)
            {
                textBox1.Text = item.drugName;
                this.textBox2.Text = item.quantity.ToString();
                this.txtRemark.Text = item.Description;
            }
            flag = true;
        }
        
        private void tsbtnCancel_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(this, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void formDrugsUnqualification_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (currentDU == null)
            {
                MessageBox.Show("请双击列表项后，再点击删除按钮！");
                return;
            }
            if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) return;

            
            if (currentDU.ApprovalStatusValue >0 && currentDU.ApprovalStatusValue!=4)
            {
                MessageBox.Show("该信息已被提交不合格药品审核，不能删除！");
                return;
            }


            if (this.PharmacyDatabaseService.EditDrugUnqualification(currentDU,2 ,out msg))
            {
                if (msg == string.Empty)
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show(msg);
                }
            }

            this.GetUnqualificationData();
        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.pageSize=Convert.ToInt16(this.toolStripTextBox1.Text);
            
        }

        private void dgvDrugDetailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bList == null) return;
            if (e.RowIndex < 0) return;
            if (  this.dgvDrugDetailList.Columns[e.ColumnIndex].Name==this.submit.Name)
            {
                if (MessageBox.Show("确定要提交至不合格审批流程吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DrugsUnqualication du = bList[e.RowIndex];
                    du.ApprovalStatusValue = 0;
                    du.updateTime = DateTime.Now;
                    
                    if (PharmacyDatabaseService.addDrugsUnqualityApproval(du, Guid.Parse(this.cmbApprovalSelector.ComboBox.SelectedValue.ToString()), du.createUID, "新增不合格审批："+du.drugName, out msg))
                    {

                        MessageBox.Show("已提交至不合格审批流程！");
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功提交不合格药品信息至审批流程:" + du.drugName);
                        this.GetUnqualificationData();
                    }
                }
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (pageNum >= Math.Ceiling(Convert.ToDouble(recordCount) / pageSize)-1) return;
            pageNum++;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (pageNum <= 0) return;
            pageNum--;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            pageNum = Convert.ToDouble(toolStripButton5.Text) - 1;
            double p = Math.Ceiling(Convert.ToDouble(recordCount) / pageSize);
            if (pageNum < 0 || pageNum >= p)
            {
                return;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string py=textBox1.Text.Trim();
            if(py==string.Empty)return;
            if (e.KeyData == Keys.Return)
            {
                using(Form1 f1 = new Form1())
                {
                    f1.py = py;
                    f1.ShowDialog();
                    if (f1.DialogResult == DialogResult.OK)
                    {
                        var im = f1.iml;
                        this.CurrentIM = f1.iml;
                        this.checkBox1.Checked = false;

                        this.textBox5.Text = im.ProductGeneralName;
                        this.textBox3.Text = im.CanSaleNum.ToString();
                        this.textBox4.Text = im.FactoryName;
                        this.textBox6.Text = im.DictionarySpecificationCode;
                        this.textBox7.Text = im.BatchNumber;
                        this.textBox8.Text = im.Origin;
                        this.textBox9.Text = im.DictionaryDosageCode;
                        this.textBox10.Text = im.PurchasePrice.ToString();

                        if (im.IsOutDate.Contains("已过期"))
                        {
                            this.txtRemark.Text = "本品种：" + im.ProductGeneralName + ",已过期，需不合格审批后执行报损流程！";
                        }
                        else
                        {
                            this.txtRemark.Text = "本品种：" + im.ProductGeneralName + ",未过期，但存在质量问题，需不合格审批后执行报损流程！";
                        }

                        currentDU = new DrugsUnqualication();
                        currentDU.ApprovalStatus = ApprovalStatus.NonApproval;
                        currentDU.ApprovalStatusValue = -1;
                        currentDU.batchNo = im.BatchNumber;
                        currentDU.createTime = DateTime.Now;
                        currentDU.createUID = AppClientContext.CurrentUser.Id;
                        currentDU.Deleted = false;
                        currentDU.Description = string.Empty;
                        currentDU.DosageType = im.DictionaryDosageCode;
                        currentDU.DrugInventoryRecordID = im.InventoryID;
                        currentDU.drugName = im.ProductGeneralName;
                        currentDU.ExpireDate = im.OutValidDate;
                        currentDU.flowID = Guid.NewGuid();
                        currentDU.Id = Guid.NewGuid();
                        currentDU.produceDate = im.PruductDate;
                        currentDU.source = "新建不合格";
                        currentDU.Specific = im.DictionarySpecificationCode;
                        currentDU.unqualificationType = 0;
                        currentDU.updateTime = DateTime.Now;
                        currentDU.factoryName = im.FactoryName;
                        currentDU.DrugInfo = im.DrugInfoId;
                        currentDU.PurchasePrice = im.PurchasePrice;
                        currentDU.Origin = im.Origin;
                        currentDU.Supplyer = im.SupplyUnitName;
                        currentDU.PurchaseOrderDocumentNumber = im.PurchaseOrderDocumentNumber;
                        currentDU.PurchaseOrderId = im.PurchaseOrderId;
                        this.textBox2.Focus();
                    }
                }
                
            }
        }

        private void dgvDrugDetailList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.currentDU = this.dgvDrugDetailList.Rows[e.RowIndex].DataBoundItem as DrugsUnqualication;;
            if (this.currentDU.source.Contains("质量复核"))
            {
                MessageBox.Show("该单据已被质量复核，确定为不合格品，不得修改，请提交不合格审核！");
                return;
            }

            toolStripButton8.Enabled = toolStripButton2.Enabled=true;
            toolStripButton10.Enabled = tsbtnSave.Enabled = toolStripButton10.Enabled= false;

            textBox1.Enabled = false;

            this.textBox2.Text = this.currentDU.quantity.ToString();
            this.textBox5.Text = this.currentDU.drugName;
            var inventoryInof=this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg,this.currentDU.DrugInventoryRecordID);
            this.textBox3.Text = (inventoryInof.CanSaleNum + currentDU.quantity).ToString();
            this.textBox4.Text = inventoryInof.DrugInfo.FactoryName;
            this.textBox6.Text = this.currentDU.Specific;
            this.textBox7.Text = this.currentDU.batchNo;
            this.textBox8.Text = this.currentDU.Origin;
            this.textBox9.Text = this.currentDU.DosageType;
            this.textBox10.Text = this.currentDU.PurchasePrice.ToString();

            this.txtRemark.Text = this.currentDU.Description;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (currentDU == null)
            {
                MessageBox.Show("请双击列表项，对数据执行修改后，再点击保存按钮！");
                return;
            }
            if (currentDU.ApprovalStatusValue >-1)
            {
                MessageBox.Show("该信息已被提交不合格药品审核，不能修改！");
                return;
            }

            try
            {
                count = Convert.ToDecimal(this.textBox3.Text);
                if (Convert.ToDecimal(this.textBox2.Text) > count || Convert.ToDecimal(this.textBox2.Text) == 0)
                {
                    MessageBox.Show("请填写不合格数量！");
                    this.textBox2.Focus();
                    this.textBox2.SelectedText = this.textBox2.Text;
                    
                    return;
                }
            }
            catch (Exception ex)
            {
                this.textBox2.Focus();
                return;
            }
            currentDU.quantity = Convert.ToDecimal(this.textBox2.Text);
            currentDU.Description = this.txtRemark.Text.Trim();
            try
            {
                if (this.PharmacyDatabaseService.EditDrugUnqualification(currentDU, 1, out msg))
                {
                    MessageBox.Show("修改成功！");
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "处理不合格品种信息成功: " + currentDU.drugName);
                    toolStripButton8.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务器故障，提交失败，请稍后尝试提交！\n"+ex.Message);
            }
            
            if (msg == string.Empty)
            {
                MessageBox.Show(msg);
            }
            this.GetUnqualificationData();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dgvDrugDetailList,"不合格药品申请");
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugsUnqualificationCondition duc = new drugsUnqualificationCondition();
            duc.dtFrom = DateTime.MinValue;
            duc.dtTo = DateTime.MaxValue;
            duc.unqualificationType = -1;
            var c = this.PharmacyDatabaseService.GetDrugsUnqualificationByCondition(out msg, duc);
            
            bList.Clear();
            switch (toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    c = c.Where(r => r.ApprovalStatusValue == -1 || r.ApprovalStatusValue==4).ToArray();
                    bList.Clear();
                    foreach (var a in c)
                    {
                        bList.Add(a);
                    }
                    break;
                case 1:
                    c = c.Where(r => r.ApprovalStatusValue == -1 ).ToArray();
                    foreach (var a in c)
                    {
                    
                        bList.Add(a);
                    }
                break;

                case 2:
                    c = c.Where(r => r.ApprovalStatusValue == 4).ToArray();
                    foreach (var a in c)
                    {
                        bList.Add(a);
                    }
                break;
                
            }
            currentDU = null;
            CurrentIM = null;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.ClearCurrent();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            this.tsbtnSave_Click(sender, e);
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (this.currentDU == null)
            {
                MessageBox.Show("请点击‘注记码’文本框，回车，并且选择药品，填写数量后执行提交操作！");
                return;
            }
            if (MessageBox.Show("确定要提交至质量复查吗？","提示",MessageBoxButtons.OKCancel)==DialogResult.Cancel) return;
            decimal quantity=0m;
            if (!decimal.TryParse(this.textBox2.Text, out quantity))
            {
                MessageBox.Show("请填写数字信息！");
                this.textBox2.Text = "0";
                this.textBox2.Focus();
                return;
            }
            var v = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, this.CurrentIM.InventoryID);
            decimal currentCansaleNumber = v.CanSaleNum;
            if (quantity > currentCansaleNumber)
            {
                MessageBox.Show("数量超过当前库存量，请修改！");
                this.textBox2.Text = "0";
                this.textBox3.Text = currentCansaleNumber.ToString();
                CurrentIM.CanSaleNum = currentCansaleNumber;
                this.textBox2.Focus();
                return;
            }

            DrugsUndeterminate du = new DrugsUndeterminate();
            du.supplyer = currentDU.Supplyer;
            du.BatchNumber = currentDU.batchNo;
            du.creater = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Employee.Name;
            du.Deleted = false;
            var d = PharmacyDatabaseService.GenerateBillDocumentCodeByTypeValue(out msg, (int)BillDocumentType.DrugUndeterminate);
            du.DocumentNumber=d.Code;
            du.DosageType = currentDU.DosageType;
            du.DrugInfoID = currentDU.DrugInfo;
            du.drugName = currentDU.drugName;
            du.ExpireDate = currentDU.ExpireDate;
            du.Id = Guid.NewGuid();
            du.InventoryID = currentDU.DrugInventoryRecordID;
            du.OrderDocumentID = CurrentIM.PurchaseOrderDocumentNumber;
            du.Origin = currentDU.Origin;
            du.proc = 0;
            du.produceDate = currentDU.produceDate;
            du.PurchaseOrderID = CurrentIM.PurchaseOrderId;
            du.PurchasePrice = currentDU.PurchasePrice;
            du.QualificationQuantity = 0;
            du.quantity = Decimal.Parse(this.textBox2.Text);
            du.rsn = this.txtRemark.Text.Trim();
            du.Source = "其他";
            du.Specific = currentDU.Specific;
            du.storeID = BugsBox.Pharmacy.AppClient.Common.AppClientContext.Config.Store.Id;
            du.supplyer = currentDU.Supplyer;
            du.UnqualificationApprovalID = Guid.Empty;
            du.UnqualificationQuantity = 0;
            du.wareHouse = "待处理药品库";

            if (this.PharmacyDatabaseService.AddDrugsUndeterminate(du, out msg))
            {
                v.drugsUnqualicationNum += du.quantity;
                this.PharmacyDatabaseService.SaveDrugInventoryRecord(out msg, v);
                this.PharmacyDatabaseService.AddBillDocumentCode(out msg, d);
                MessageBox.Show("提交成功！单号：" + du.DocumentNumber);                
                this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "提交质量复查成功！");
                this.ClearCurrent();
            }
            else
            {
                MessageBox.Show("提交失败，请联系管理员！");
            }
        }
                
    }
}
