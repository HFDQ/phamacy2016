namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    partial class FormGoodsInfoView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BugsBox.Pharmacy.Models.DrugInfo drugInfo1 = new BugsBox.Pharmacy.Models.DrugInfo();
            this.ucGoodsInfo1 = new BugsBox.Pharmacy.AppClient.UI.UserControls.ucGoodsInfo();
            this.SuspendLayout();
            // 
            // ucGoodsInfo1
            // 
            this.ucGoodsInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            drugInfo1.ApprovalDate = new System.DateTime(((long)(0)));
            drugInfo1.ApprovalStatus = BugsBox.Pharmacy.Models.ApprovalStatus.NonApproval;
            drugInfo1.ApprovalStatusValue = 0;
            drugInfo1.BarCode = null;
            drugInfo1.BigPackage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.BusinessScopeCode = null;
            drugInfo1.Code = null;
            drugInfo1.CreateTime = new System.DateTime(((long)(0)));
            drugInfo1.CreateUserId = new System.Guid("00000000-0000-0000-0000-000000000000");
            drugInfo1.Deleted = false;
            drugInfo1.DeleteTime = null;
            drugInfo1.Description = null;
            drugInfo1.DictionaryDosageCode = null;
            drugInfo1.DictionaryMeasurementUnitCode = null;
            drugInfo1.DictionaryPiecemealUnitCode = null;
            drugInfo1.DictionarySpecificationCode = null;
            drugInfo1.DictionaryUserDefinedTypeCode = null;
            drugInfo1.DocCode = null;
            drugInfo1.DrugCategoryCode = null;
            drugInfo1.DrugClinicalCategoryCode = null;
            drugInfo1.DrugInventoryRecords = null;
            drugInfo1.DrugStorageTypeCode = null;
            drugInfo1.Enabled = false;
            drugInfo1.FactoryName = null;
            drugInfo1.FactoryNameAbbreviation = null;
            drugInfo1.FlowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            drugInfo1.GoodsAdditionalProperty = null;
            drugInfo1.GoodsType = BugsBox.Pharmacy.Models.GoodsType.DrugDomestic;
            drugInfo1.GoodsTypeValue = 0;
            drugInfo1.Id = new System.Guid("be80a3a2-b3eb-4c23-a1a6-86b778869139");
            drugInfo1.IsApproval = false;
            drugInfo1.IsImport = false;
            drugInfo1.IsLock = false;
            drugInfo1.IsMainMaintenance = false;
            drugInfo1.IsMedicalInsurance = false;
            drugInfo1.IsPrescription = false;
            drugInfo1.IsSpecialDrugCategory = false;
            drugInfo1.LicensePermissionNumber = null;
            drugInfo1.LimitedLowPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.LimitedUpPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.LockRemark = null;
            drugInfo1.LowSalePrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.MaxInventoryCount = 0;
            drugInfo1.MedicalCategoryDetailCode = null;
            drugInfo1.MiddlePackage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.MinInventoryCount = 0;
            drugInfo1.NationalSalePrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.Origin = null;
            drugInfo1.Package = null;
            drugInfo1.PackageAmount = 0;
            drugInfo1.PerformanceStandards = null;
            drugInfo1.PermitDate = new System.DateTime(((long)(0)));
            drugInfo1.PermitLicenseCode = null;
            drugInfo1.PermitOutDate = new System.DateTime(((long)(0)));
            drugInfo1.PiecemealNumber = 0;
            drugInfo1.PiecemealSpecification = null;
            drugInfo1.Pinyin = null;
            drugInfo1.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.ProductEnglishName = null;
            drugInfo1.ProductGeneralName = null;
            drugInfo1.ProductName = null;
            drugInfo1.ProductOtherName = null;
            drugInfo1.PurchaseManageCategoryDetailCode = null;
            drugInfo1.PurchasePrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.RetailPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.SalePrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.SmallPackage = 0;
            drugInfo1.SpecialDrugCategoryCode = null;
            drugInfo1.StandardCode = null;
            drugInfo1.TagPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.UpdateTime = new System.DateTime(((long)(0)));
            drugInfo1.UpdateUserId = new System.Guid("00000000-0000-0000-0000-000000000000");
            drugInfo1.Valid = false;
            drugInfo1.ValidPeriod = 0;
            drugInfo1.ValidRemark = null;
            drugInfo1.WareHouses = new System.Guid("00000000-0000-0000-0000-000000000000");
            drugInfo1.WareHouseZones = null;
            drugInfo1.WholeSalePrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucGoodsInfo1.DrugInfo = drugInfo1;
            this.ucGoodsInfo1.FlowTypeID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucGoodsInfo1.GoodsAdditional = null;
            this.ucGoodsInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucGoodsInfo1.Name = "ucGoodsInfo1";
            this.ucGoodsInfo1.RunMode = BugsBox.Pharmacy.UI.Common.FormRunMode.Add;
            this.ucGoodsInfo1.SelectedWarehouseZones = "";
            this.ucGoodsInfo1.Size = new System.Drawing.Size(887, 542);
            this.ucGoodsInfo1.TabIndex = 0;
            // 
            // FormGoodsInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 542);
            this.Controls.Add(this.ucGoodsInfo1);
            this.Name = "FormGoodsInfoView";
            this.Text = "药品基本信息查看";
            this.Load += new System.EventHandler(this.FormGoodsInfoView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucGoodsInfo ucGoodsInfo1;
    }
}