using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Repository;
using Omu.ValueInjecter;


namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class BusinessLicenseBusinessHandler
    {
        protected override IQueryable<Models.BusinessLicense> IncludeNavigationProperties(IQueryable<Models.BusinessLicense> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable);

            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<BusinessLicense>>(ex.Message, ex);
            }
        }

        public List<PharmacyLicense> QueryPharmacyLicenseForOutdate(QueryPharmacyLicenseModel queryModel)
        {
            try
            {

                //GSPLicense,GMPLicense,BusinessLicense,MedicineProductionLicense,MedicineBusinessLicense,InstrumentsBusinessLicense,InstrumentsProductionLicense
                List<PharmacyLicense> dataList = new List<PharmacyLicense>();

                var GSPLicenses = QueryGSPLicense(queryModel);
                if (GSPLicenses != null)
                {
                    dataList.AddRange(GSPLicenses);
                }

                var GMPLicenses = QueryGMPLicense(queryModel);
                if (GMPLicenses != null)
                {
                    dataList.AddRange(GMPLicenses);
                }

                var BusinessLicenses = QueryBusinessLicense(queryModel);
                if (BusinessLicenses != null)
                {
                    dataList.AddRange(BusinessLicenses);
                }

                var MedicineProductionLicenses = QueryMedicineProductionLicense(queryModel);
                if (MedicineProductionLicenses != null)
                {
                    dataList.AddRange(MedicineProductionLicenses);
                }


                var MedicineBusinessLicenses = QueryMedicineBusinessLicense(queryModel);
                if (MedicineBusinessLicenses != null)
                {
                    dataList.AddRange(MedicineBusinessLicenses);
                }

                var InstrumentsBusinessLicenses = QueryInstrumentsBusinessLicense(queryModel);
                if (InstrumentsBusinessLicenses != null)
                {
                    dataList.AddRange(InstrumentsBusinessLicenses);
                }

                var InstrumentsProductionLicenses = QueryInstrumentsProductionLicense(queryModel);
                if (InstrumentsProductionLicenses != null)
                {
                    dataList.AddRange(InstrumentsProductionLicenses);
                }

                var OrganizationCodeLicenses = QueryOrganizationCodeLicense(queryModel);
                if (OrganizationCodeLicenses != null)
                {
                    dataList.AddRange(OrganizationCodeLicenses);
                }

                var FoodCirculateLicenses = QueryFoodCirculateLicense(queryModel);
                if (FoodCirculateLicenses != null)
                {
                    dataList.AddRange(FoodCirculateLicenses);
                }

                var HealthLicenses = QueryHealthLicense(queryModel);
                if (HealthLicenses != null)
                {
                    dataList.AddRange(HealthLicenses);
                }

                var TaxRegisterLicenses = QueryTaxRegisterLicense(queryModel);
                if (TaxRegisterLicenses != null)
                {
                    dataList.AddRange(TaxRegisterLicenses);
                }

                var LnstitutionLegalPersonLicenses = QueryLnstitutionLegalPersonLicense(queryModel);
                if (LnstitutionLegalPersonLicenses != null)
                {
                    dataList.AddRange(LnstitutionLegalPersonLicenses);
                }

                var MmedicalInstitutionPermits = QueryMmedicalInstitutionPermit(queryModel);
                if (MmedicalInstitutionPermits != null)
                {
                    dataList.AddRange(MmedicalInstitutionPermits);
                }

                dataList = dataList.OrderBy(t => t.OutDate).ToList();
                List<PharmacyLicense> destArray = new List<PharmacyLicense>();
                foreach (PharmacyLicense pharmacyLicense in dataList)
                {
                    PharmacyLicense destPharmacyLicense = new PharmacyLicense();
                    destPharmacyLicense.InjectFrom(pharmacyLicense);
                    destArray.Add(destPharmacyLicense);
                }
                return destArray;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return new List<PharmacyLicense>();
            }
        }

        private List<PharmacyLicense> QueryGSPLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.GSPLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<PharmacyLicense> QueryGMPLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.GMPLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<PharmacyLicense> QueryBusinessLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.BusinessLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<PharmacyLicense> QueryMedicineProductionLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.MedicineProductionLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<PharmacyLicense> QueryMedicineBusinessLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.MedicineBusinessLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<PharmacyLicense> QueryInstrumentsBusinessLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.InstrumentsBusinessLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<PharmacyLicense> QueryInstrumentsProductionLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.InstrumentsProductionLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //wfz,组织机构代码证书
        private List<PharmacyLicense> QueryOrganizationCodeLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.OrganizationCodeLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //食品流通许可证
        private List<PharmacyLicense> QueryFoodCirculateLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.FoodCirculateLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //卫生许可证
        private List<PharmacyLicense> QueryHealthLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.HealthLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //税务登记证
        private List<PharmacyLicense> QueryTaxRegisterLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.TaxRegisterLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //事业单位法人证
        private List<PharmacyLicense> QueryLnstitutionLegalPersonLicense(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.LnstitutionLegalPersonLicenses.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //医疗机构执业许可证
        private List<PharmacyLicense> QueryMmedicalInstitutionPermit(QueryPharmacyLicenseModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.MmedicalInstitutionPermits.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {
                    if (queryModel.LicenseTypeValue > -1)
                    {
                        int typeValue = queryModel.LicenseTypeValue;
                        query = query.Where(t => t.LicenseTypeValue == typeValue);
                    }
                    string code = queryModel.Code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        query = query.Where(t => t.Code.Contains(code));
                    }
                    var enabled = queryModel.Enabled;
                    if (enabled != null && enabled.Query)
                    {
                        bool enabledValue = enabled.Value;
                        query = query.Where(t => t.Enabled == enabledValue);
                    }

                    var issuanceDate = queryModel.IssuanceDate;
                    if (issuanceDate != null && issuanceDate.Max >= issuanceDate.Min)
                    {
                        DateTime issuanceDateMax = issuanceDate.Max;
                        DateTime issuanceDateMin = issuanceDate.Min;
                        if (issuanceDateMax == issuanceDateMin)
                        {
                            query = query.Where(t => t.IssuanceDate == issuanceDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.IssuanceDate >= issuanceDateMin && t.IssuanceDate <= issuanceDateMax);
                        }
                    }
                    string org = queryModel.IssuanceOrg;
                    if (!string.IsNullOrEmpty(org))
                    {
                        query = query.Where(t => t.IssuanceOrg.Contains(org));
                    }
                    string licenseCode = queryModel.LicenseCode;
                    if (!string.IsNullOrEmpty(licenseCode))
                    {
                        query = query.Where(t => t.LicenseCode.Contains(licenseCode));
                    }
                    int licenseTypeValue = queryModel.LicenseTypeValue;
                    if (licenseTypeValue > -1)
                    {
                        query = query.Where(t => t.LicenseTypeValue == licenseTypeValue);
                    }
                    string name = queryModel.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        query = query.Where(t => t.Name.Contains(name));
                    }
                    var outDate = queryModel.OutDate;
                    if (outDate != null && outDate.Max >= outDate.Min)
                    {
                        DateTime outDateMax = outDate.Max;
                        DateTime outDateMin = outDate.Min;
                        if (outDateMax == outDateMin)
                        {
                            query = query.Where(t => t.OutDate == outDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= outDateMin && t.IssuanceDate <= outDateMax);
                        }
                    }
                    string regAddress = queryModel.RegAddress;
                    if (!string.IsNullOrEmpty(regAddress))
                    {
                        query = query.Where(t => t.RegAddress.Contains(regAddress));
                    }
                    var startDate = queryModel.StartDate;
                    if (startDate != null && startDate.Max >= startDate.Min)
                    {
                        DateTime startDateMax = startDate.Max;
                        DateTime startDateMin = startDate.Min;
                        if (startDateMax == startDateMin)
                        {
                            query = query.Where(t => t.StartDate == startDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.StartDate >= startDateMin && t.IssuanceDate <= startDateMax);
                        }
                    }
                    string unitName = queryModel.UnitName;
                    if (!string.IsNullOrEmpty(unitName))
                    {
                        query = query.Where(t => t.UnitName.Contains(unitName));
                    }

                    var valid = queryModel.Valid;
                    if (valid != null && valid.Query)
                    {
                        bool validValue = valid.Value;
                        query = query.Where(t => t.Valid == validValue);
                    }

                }
                return query.ToList()
                    .Select(t => t as PharmacyLicense)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
