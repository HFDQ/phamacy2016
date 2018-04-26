using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseForm
{
    public class BasicInfoRightMenu
    {
        string msg = string.Empty;
        BugsBox.Pharmacy.UI.Common.BaseRightMenu brm = null;

        public System.Windows.Forms.DataGridView Datagridview { get; set; }
        public Guid Sid { get; set; }
        public Guid DrugId { get; set; }
        public Guid Pid { get; set; }
        public Guid DrugInventoryId { get; set; }

        public BasicInfoRightMenu(System.Windows.Forms.DataGridView Datagridview)
        {
            this.Datagridview = Datagridview;
            brm = new BugsBox.Pharmacy.UI.Common.BaseRightMenu(this.Datagridview);
        }

        //供货商基础信息
        public void InsertSupplyUnitBasicInfo( )
        {
            this.brm.InsertMenuItem("供货商基础信息", this.GetSupplyUnit);
        }
        public void GetSupplyUnit()
        {
            if (Sid == null || Sid == Guid.Empty) return;
            Models.SupplyUnit su = new Pharmacy.AppClient.UI.BaseFunctionForm().PharmacyDatabaseService.GetSupplyUnit(out msg, this.Sid);
            if(su==null)return;
            UserControls.ucSupplyUnit us = new UserControls.ucSupplyUnit(su, false);
            System.Windows.Forms.Form f = new System.Windows.Forms.Form();
            f.Text = su.Name;
            f.AutoSize = true;
            f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            p.AutoSize = true;
            p.Controls.Add(us);
            f.Controls.Add(p);
            f.ShowDialog();
        }

        public void InsertDrugBasicInfo()
        {
            brm.InsertMenuItem("经营品种基础信息", this.GetDrugInfo);
        }
        
        public void GetDrugInfo()
        {
            using (BaseFunctionForm bf = new Pharmacy.AppClient.UI.BaseFunctionForm())
            {

                if (this.DrugId ==Guid.Empty && this.DrugInventoryId!=Guid.Empty)
                {
                    var div = bf.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, this.DrugInventoryId);
                    this.DrugId = div.DrugInfoId;
                }

                var di = bf.PharmacyDatabaseService.GetDrugInfo(out msg, this.DrugId);
                if (di == null) return;
                if (di.BusinessScopeCode.Contains("医疗器械"))
                {
                    Forms.BaseDataManage.FormInstrument frm = new BaseDataManage.FormInstrument();
                    frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    frm.entity = di;
                    Common.SetControls.SetControlReadonly(frm, true);
                    frm.ShowDialog();
                    return;
                }

                if (di.BusinessScopeCode.Contains("保健食品"))
                {
                    Forms.BaseDataManage.FormFood frm = new BaseDataManage.FormFood();
                    frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    frm.entity = di;
                    Common.SetControls.SetControlReadonly(frm, true);
                    frm.ShowDialog();
                    return;
                }

                UI.UserControls.ucGoodsInfo ucControl = new UserControls.ucGoodsInfo(di);
                System.Windows.Forms.Form f = new System.Windows.Forms.Form();
                f.WindowState = System.Windows.Forms.FormWindowState.Normal;
                f.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                f.Text = di.ProductGeneralName;
                f.AutoSize = true;
                f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
                p.AutoSize = true;
                p.Controls.Add(ucControl);
                f.Controls.Add(p);
                Forms.Common.SetControls.SetControlReadonly(f, true);
                f.ShowDialog();
                f.Dispose();
            }
        }
        
        public void InsertPurchaseUnitBasicInfo() 
        {
            brm.InsertMenuItem("购货商基础信息", this.GetPurchaseUnit);
        }
        public void GetPurchaseUnit( )
        {
            Models.PurchaseUnit pu = new Pharmacy.AppClient.UI.BaseFunctionForm().PharmacyDatabaseService.GetPurchaseUnit(out msg, this.Pid);
            if (pu == null) return;
            UserControls.ucPurchaseUnit us = new UserControls.ucPurchaseUnit(pu, false);
            System.Windows.Forms.Form f = new System.Windows.Forms.Form();
            f.Text = pu.Name;
            f.AutoSize = true;
            f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            f.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            p.AutoSize = true;
            p.Controls.Add(us);
            f.Controls.Add(p);
            Forms.Common.SetControls.SetControlReadonly(f, true);
            f.ShowDialog();
        }

        public void InserMenu( string MenuName,BugsBox.Pharmacy.UI.Common.InsertM m )
        {
            brm.InsertMenuItem(MenuName, m);
        }
    }
}
