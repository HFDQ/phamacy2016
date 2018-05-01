namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugBusiness
{
    partial class FormDoubtDrugEdit
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
            BugsBox.Pharmacy.Models.GoodsAdditionalProperty goodsAdditionalProperty1 = new BugsBox.Pharmacy.Models.GoodsAdditionalProperty();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucGoodsInfo1 = new BugsBox.Pharmacy.AppClient.UI.UserControls.ucGoodsInfo();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonSelectDrugInventoryRecord = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDoubtDrugDecription = new System.Windows.Forms.TextBox();
            this.textBoxDoubtEmployee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelCanSaleNum = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelRetailDismantingAmount = new System.Windows.Forms.Label();
            this.labelDismantingAmount = new System.Windows.Forms.Label();
            this.labelRetailCount = new System.Windows.Forms.Label();
            this.labelSalesCount = new System.Windows.Forms.Label();
            this.labelCurrentInventoryCount = new System.Windows.Forms.Label();
            this.labelInInventoryCount = new System.Windows.Forms.Label();
            this.labelOutValidDate = new System.Windows.Forms.Label();
            this.label1PruductDate = new System.Windows.Forms.Label();
            this.label1BatchNumber = new System.Windows.Forms.Label();
            this.labelDurgInventoryType = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.ucGoodsInfo1);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 510);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "药物信息";
            // 
            // ucGoodsInfo1
            // 
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
            drugInfo1.Id = new System.Guid("fbc71165-a424-4662-b99f-3ab416f75b42");
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
            goodsAdditionalProperty1.CareFunction = null;
            goodsAdditionalProperty1.Deleted = false;
            goodsAdditionalProperty1.DeleteTime = null;
            goodsAdditionalProperty1.DrugInfo = null;
            //goodsAdditionalProperty1.DrugInfoId = new System.Guid("00000000-0000-0000-0000-000000000000");
            goodsAdditionalProperty1.FactoryAddress = null;
            goodsAdditionalProperty1.FactoryAddressEnglish = null;
            goodsAdditionalProperty1.FactoryNameEnglish = null;
            goodsAdditionalProperty1.HealthPermit = null;
            goodsAdditionalProperty1.Id = new System.Guid("a480d5e1-33a5-4377-9936-f0a208b59fe9");
            goodsAdditionalProperty1.LandmarkIngredient = null;
            goodsAdditionalProperty1.LicensePermissionDate = new System.DateTime(((long)(0)));
            goodsAdditionalProperty1.MainIngredient = null;
            goodsAdditionalProperty1.NotSuitablePeople = null;
            goodsAdditionalProperty1.ProductAddress = null;
            goodsAdditionalProperty1.ProductAddressEnglish = null;
            goodsAdditionalProperty1.ProductCountry = null;
            goodsAdditionalProperty1.ProductCountryEnglish = null;
            goodsAdditionalProperty1.PutOnRecord = null;
            goodsAdditionalProperty1.PutOnRecordDate = new System.DateTime(((long)(0)));
            goodsAdditionalProperty1.RegCode = null;
            goodsAdditionalProperty1.RegProxyCompany = null;
            goodsAdditionalProperty1.SuitablePeople = null;
            goodsAdditionalProperty1.UsageAndDosage = null;
            this.ucGoodsInfo1.GoodsAdditional = goodsAdditionalProperty1;
            this.ucGoodsInfo1.Location = new System.Drawing.Point(3, 17);
            this.ucGoodsInfo1.Name = "ucGoodsInfo1";
            this.ucGoodsInfo1.RunMode = BugsBox.Pharmacy.UI.Common.FormRunMode.Add;
            this.ucGoodsInfo1.SelectedWarehouseZones = "";
            this.ucGoodsInfo1.Size = new System.Drawing.Size(880, 583);
            this.ucGoodsInfo1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(550, 603);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 39);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(366, 603);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(94, 39);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "保存";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonSelectDrugInventoryRecord
            // 
            this.buttonSelectDrugInventoryRecord.Location = new System.Drawing.Point(12, 12);
            this.buttonSelectDrugInventoryRecord.Name = "buttonSelectDrugInventoryRecord";
            this.buttonSelectDrugInventoryRecord.Size = new System.Drawing.Size(108, 23);
            this.buttonSelectDrugInventoryRecord.TabIndex = 4;
            this.buttonSelectDrugInventoryRecord.Text = "选择药物";
            this.buttonSelectDrugInventoryRecord.UseVisualStyleBackColor = true;
            this.buttonSelectDrugInventoryRecord.Click += new System.EventHandler(this.buttonSelectDrugInventoryRecord_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDoubtDrugDecription);
            this.groupBox2.Controls.Add(this.textBoxDoubtEmployee);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(900, 394);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 248);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "疑问信息";
            // 
            // textBoxDoubtDrugDecription
            // 
            this.textBoxDoubtDrugDecription.Location = new System.Drawing.Point(9, 20);
            this.textBoxDoubtDrugDecription.MaxLength = 256;
            this.textBoxDoubtDrugDecription.Multiline = true;
            this.textBoxDoubtDrugDecription.Name = "textBoxDoubtDrugDecription";
            this.textBoxDoubtDrugDecription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDoubtDrugDecription.Size = new System.Drawing.Size(170, 179);
            this.textBoxDoubtDrugDecription.TabIndex = 2;
            // 
            // textBoxDoubtEmployee
            // 
            this.textBoxDoubtEmployee.Location = new System.Drawing.Point(79, 216);
            this.textBoxDoubtEmployee.Name = "textBoxDoubtEmployee";
            this.textBoxDoubtEmployee.ReadOnly = true;
            this.textBoxDoubtEmployee.Size = new System.Drawing.Size(100, 21);
            this.textBoxDoubtEmployee.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "质疑人员";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelCanSaleNum);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.labelRetailDismantingAmount);
            this.groupBox3.Controls.Add(this.labelDismantingAmount);
            this.groupBox3.Controls.Add(this.labelRetailCount);
            this.groupBox3.Controls.Add(this.labelSalesCount);
            this.groupBox3.Controls.Add(this.labelCurrentInventoryCount);
            this.groupBox3.Controls.Add(this.labelInInventoryCount);
            this.groupBox3.Controls.Add(this.labelOutValidDate);
            this.groupBox3.Controls.Add(this.label1PruductDate);
            this.groupBox3.Controls.Add(this.label1BatchNumber);
            this.groupBox3.Controls.Add(this.labelDurgInventoryType);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(900, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 346);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "药物库存信息";
            // 
            // labelCanSaleNum
            // 
            this.labelCanSaleNum.AutoSize = true;
            this.labelCanSaleNum.Location = new System.Drawing.Point(102, 308);
            this.labelCanSaleNum.Name = "labelCanSaleNum";
            this.labelCanSaleNum.Size = new System.Drawing.Size(83, 12);
            this.labelCanSaleNum.TabIndex = 21;
            this.labelCanSaleNum.Text = "可销售/零售：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 308);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "可销售/零售：";
            // 
            // labelRetailDismantingAmount
            // 
            this.labelRetailDismantingAmount.AutoSize = true;
            this.labelRetailDismantingAmount.Location = new System.Drawing.Point(103, 281);
            this.labelRetailDismantingAmount.Name = "labelRetailDismantingAmount";
            this.labelRetailDismantingAmount.Size = new System.Drawing.Size(77, 12);
            this.labelRetailDismantingAmount.TabIndex = 19;
            this.labelRetailDismantingAmount.Text = "已售拆零数量";
            // 
            // labelDismantingAmount
            // 
            this.labelDismantingAmount.AutoSize = true;
            this.labelDismantingAmount.Location = new System.Drawing.Point(102, 255);
            this.labelDismantingAmount.Name = "labelDismantingAmount";
            this.labelDismantingAmount.Size = new System.Drawing.Size(77, 12);
            this.labelDismantingAmount.TabIndex = 18;
            this.labelDismantingAmount.Text = "待售拆零数量";
            // 
            // labelRetailCount
            // 
            this.labelRetailCount.AutoSize = true;
            this.labelRetailCount.Location = new System.Drawing.Point(102, 226);
            this.labelRetailCount.Name = "labelRetailCount";
            this.labelRetailCount.Size = new System.Drawing.Size(65, 12);
            this.labelRetailCount.TabIndex = 17;
            this.labelRetailCount.Text = "已零售数量";
            // 
            // labelSalesCount
            // 
            this.labelSalesCount.AutoSize = true;
            this.labelSalesCount.Location = new System.Drawing.Point(102, 198);
            this.labelSalesCount.Name = "labelSalesCount";
            this.labelSalesCount.Size = new System.Drawing.Size(65, 12);
            this.labelSalesCount.TabIndex = 16;
            this.labelSalesCount.Text = "已销售数量";
            // 
            // labelCurrentInventoryCount
            // 
            this.labelCurrentInventoryCount.AutoSize = true;
            this.labelCurrentInventoryCount.Location = new System.Drawing.Point(102, 171);
            this.labelCurrentInventoryCount.Name = "labelCurrentInventoryCount";
            this.labelCurrentInventoryCount.Size = new System.Drawing.Size(65, 12);
            this.labelCurrentInventoryCount.TabIndex = 15;
            this.labelCurrentInventoryCount.Text = "当前库存量";
            // 
            // labelInInventoryCount
            // 
            this.labelInInventoryCount.AutoSize = true;
            this.labelInInventoryCount.Location = new System.Drawing.Point(102, 141);
            this.labelInInventoryCount.Name = "labelInInventoryCount";
            this.labelInInventoryCount.Size = new System.Drawing.Size(53, 12);
            this.labelInInventoryCount.TabIndex = 14;
            this.labelInInventoryCount.Text = "入库数量";
            // 
            // labelOutValidDate
            // 
            this.labelOutValidDate.AutoSize = true;
            this.labelOutValidDate.Location = new System.Drawing.Point(102, 113);
            this.labelOutValidDate.Name = "labelOutValidDate";
            this.labelOutValidDate.Size = new System.Drawing.Size(53, 12);
            this.labelOutValidDate.TabIndex = 13;
            this.labelOutValidDate.Text = "过期日期";
            // 
            // label1PruductDate
            // 
            this.label1PruductDate.AutoSize = true;
            this.label1PruductDate.Location = new System.Drawing.Point(102, 84);
            this.label1PruductDate.Name = "label1PruductDate";
            this.label1PruductDate.Size = new System.Drawing.Size(53, 12);
            this.label1PruductDate.TabIndex = 12;
            this.label1PruductDate.Text = "生产日期";
            // 
            // label1BatchNumber
            // 
            this.label1BatchNumber.AutoSize = true;
            this.label1BatchNumber.Location = new System.Drawing.Point(102, 55);
            this.label1BatchNumber.Name = "label1BatchNumber";
            this.label1BatchNumber.Size = new System.Drawing.Size(53, 12);
            this.label1BatchNumber.TabIndex = 11;
            this.label1BatchNumber.Text = "生产批号";
            // 
            // labelDurgInventoryType
            // 
            this.labelDurgInventoryType.AutoSize = true;
            this.labelDurgInventoryType.Location = new System.Drawing.Point(102, 27);
            this.labelDurgInventoryType.Name = "labelDurgInventoryType";
            this.labelDurgInventoryType.Size = new System.Drawing.Size(53, 12);
            this.labelDurgInventoryType.TabIndex = 10;
            this.labelDurgInventoryType.Text = "入库类型";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 281);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "已售拆零数量：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 255);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "待售拆零数量：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "已零售数量：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "当前库存量：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "已销售数量：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "入库数量：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "过期日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "生产日期：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "生产批号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "入库类型：";
            // 
            // FormDoubtDrugEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 666);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonSelectDrugInventoryRecord);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(1105, 705);
            this.Name = "FormDoubtDrugEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "疑问药品编辑";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonSelectDrugInventoryRecord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDoubtEmployee;
        private System.Windows.Forms.TextBox textBoxDoubtDrugDecription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelInInventoryCount;
        private System.Windows.Forms.Label labelOutValidDate;
        private System.Windows.Forms.Label label1PruductDate;
        private System.Windows.Forms.Label label1BatchNumber;
        private System.Windows.Forms.Label labelDurgInventoryType;
        private System.Windows.Forms.Label labelSalesCount;
        private System.Windows.Forms.Label labelCurrentInventoryCount;
        private System.Windows.Forms.Label labelRetailCount;
        private System.Windows.Forms.Label labelRetailDismantingAmount;
        private System.Windows.Forms.Label labelDismantingAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelCanSaleNum;
        private UserControls.ucGoodsInfo ucGoodsInfo1;
    }
}