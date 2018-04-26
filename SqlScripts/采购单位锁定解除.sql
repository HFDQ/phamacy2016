update  [dbo].[PurchaseUnit] set IsApproval=2,OutDate=DATEADD(YY,2,GETDATE()),IsLock=0,GSPLicenseOutDate=DATEADD(YY,2,GETDATE())
                    , GMPLicenseOutDate=DATEADD(YY,2,GETDATE())
                    , BusinessLicenseeOutDate=DATEADD(YY,2,GETDATE())
                    , MedicineProductionLicenseOutDate=DATEADD(YY,2,GETDATE())
                    , MedicineBusinessLicenseOutDate=DATEADD(YY,2,GETDATE())
                    , InstrumentsProductionLicenseOutDate=DATEADD(YY,2,GETDATE())
                    , InstrumentsBusinessLicenseOutDate=DATEADD(YY,2,GETDATE()),OrganizationCodeLicenseOutDate=DATEADD(YY,2,GETDATE())
					,MmedicalInstitutionPermitOutDate=DATEADD(YY,2,GETDATE()),ApprovalStatusValue=2

					select OutDate,IsApproval,* from   [dbo].[PurchaseUnit] where id='07EB8302-39EB-44B4-84DF-D1D23ED5EA77'