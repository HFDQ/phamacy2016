using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class EmployeeBusinessHandler
    {
        protected override System.Linq.IQueryable<BugsBox.Pharmacy.Models.Employee> IncludeNavigationProperties(System.Linq.IQueryable<BugsBox.Pharmacy.Models.Employee> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
                            .Include(e => e.Users)
                            .Include(e => e.Department)
                            );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<Employee>>(ex.Message, ex);
            }

        }

        #region  人员过期

        public List<BusinessPersonModel> QueryBusinessPerson(QueryBusinessPersonModel queryBusinessPersonModel)
        {
            try
            {
                List<BusinessPersonModel> dataList = new List<BusinessPersonModel>(); 
                var employees = QueryEmployees(queryBusinessPersonModel);
                if (queryBusinessPersonModel!=null
                    &&(queryBusinessPersonModel.PersonTypeValue<0||queryBusinessPersonModel.PersonTypeValue==(int)PersonType.Employee)
                    && employees != null)
                {
                    dataList.AddRange(employees);
                } 
                var purchaseUnitBuyers = QueryPurchaseUnitBuyers(queryBusinessPersonModel);
                if (
                    queryBusinessPersonModel != null
                    && (queryBusinessPersonModel.PersonTypeValue < 0 || queryBusinessPersonModel.PersonTypeValue == (int)PersonType.PurchaseUnitBuyer)
                    &&purchaseUnitBuyers != null)
                {
                    dataList.AddRange(purchaseUnitBuyers);
                }
                var supplyUnitSalesman = QuerySupplyUnitSalesmans(queryBusinessPersonModel);
                if (
                      queryBusinessPersonModel != null
                    && (queryBusinessPersonModel.PersonTypeValue < 0 || queryBusinessPersonModel.PersonTypeValue == (int)PersonType.SupplyUnitSalesman)
                    &&supplyUnitSalesman != null)
                {
                    dataList.AddRange(supplyUnitSalesman);
                }
                return dataList;
            }
            catch (Exception ex)
            {
                ex = new BusinessException("查询人员失败", ex);
                Log.Error(ex);
                return new List<BusinessPersonModel>();
            }
        }

        private List<BusinessPersonModel> QueryEmployees(QueryBusinessPersonModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.Employees.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {

                    string Name = queryModel.Name;
                    if (!string.IsNullOrEmpty(Name))
                    {
                        query = query.Where(t => t.Name.Contains(Name));
                    }
                    string IDNumber = queryModel.IDNumber;
                    if (!string.IsNullOrEmpty(IDNumber))
                    {
                        query = query.Where(t => t.IdentityNo.Contains(IDNumber));
                    }
                    string Tel = queryModel.Tel;
                    if (!string.IsNullOrEmpty(Tel))
                    {
                        query = query.Where(t => t.Phone.Contains(Tel));
                    }
                    string Address = queryModel.Address;
                    if (!string.IsNullOrEmpty(Address))
                    {
                        query = query.Where(t => t.Address.Contains(Address));
                    }
                    string Gender = queryModel.Gender;
                    if (!string.IsNullOrEmpty(Address))
                    {
                        query = query.Where(t => t.Gender.Contains(Gender));
                    }

                    var Birthday = queryModel.Birthday;
                    if (Birthday != null && Birthday.Max >= Birthday.Min)
                    {
                        DateTime BirthdayMax = Birthday.Max;
                        DateTime BirthdayMin = Birthday.Min;
                        if (BirthdayMax == BirthdayMin)
                        {
                            query = query.Where(t => t.BirthDay == BirthdayMax);
                        }
                        else
                        {
                            query = query.Where(t => t.BirthDay >= BirthdayMin && t.BirthDay <= BirthdayMax);
                        }
                    }
                    var OutDate = queryModel.OutDate;
                    if (OutDate != null && OutDate.Max >= OutDate.Min)
                    {
                        DateTime OutDateMax = OutDate.Max;
                        DateTime OutDateMin = OutDate.Min;
                        if (OutDateMax == OutDateMin)
                        {
                            query = query.Where(t => t.OutDate == OutDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= OutDateMin && t.OutDate <= OutDateMax);
                        }
                    }
                   

                }
                return query.ToList()
                    .Select(t => new BusinessPersonModel 
                    {
                            Address=t.Address,
                            Birthday=t.BirthDay??DateTime.MinValue,
                            Gender=t.Gender,
                            IDNumber=t.IdentityNo,
                            Id=t.Id,
                            Name=t.Name,
                            OutDate=t.OutDate,
                            PersonType=PersonType.Employee,
                            Tel=t.Phone 
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<BusinessPersonModel> QueryPurchaseUnitBuyers(QueryBusinessPersonModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.PurchaseUnitBuyers.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {

                    string Name = queryModel.Name;
                    if (!string.IsNullOrEmpty(Name))
                    {
                        query = query.Where(t => t.Name.Contains(Name));
                    }
                    string IDNumber = queryModel.IDNumber;
                    if (!string.IsNullOrEmpty(IDNumber))
                    {
                        query = query.Where(t => t.IDNumber.Contains(IDNumber));
                    }
                    string Tel = queryModel.Tel;
                    if (!string.IsNullOrEmpty(Tel))
                    {
                        query = query.Where(t => t.Tel.Contains(Tel));
                    }
                    string Address = queryModel.Address;
                    if (!string.IsNullOrEmpty(Address))
                    {
                        query = query.Where(t => t.Address.Contains(Address));
                    }
                    string Gender = queryModel.Gender;
                    if (!string.IsNullOrEmpty(Address))
                    {
                        query = query.Where(t => t.Gender.Contains(Gender));
                    }

                    var Birthday = queryModel.Birthday;
                    if (Birthday != null && Birthday.Max >= Birthday.Min)
                    {
                        DateTime BirthdayMax = Birthday.Max;
                        DateTime BirthdayMin = Birthday.Min;
                        if (BirthdayMax == BirthdayMin)
                        {
                            query = query.Where(t => t.Birthday == BirthdayMax);
                        }
                        else
                        {
                            query = query.Where(t => t.Birthday >= BirthdayMin && t.Birthday <= BirthdayMax);
                        }
                    }
                    var OutDate = queryModel.OutDate;
                    if (OutDate != null && OutDate.Max >= OutDate.Min)
                    {
                        DateTime OutDateMax = OutDate.Max;
                        DateTime OutDateMin = OutDate.Min;
                        if (OutDateMax == OutDateMin)
                        {
                            query = query.Where(t => t.OutDate == OutDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= OutDateMin && t.OutDate <= OutDateMax);
                        }
                    }


                }
                return query.ToList()
                    .Select(t => new BusinessPersonModel
                    {
                        Address = t.Address,
                        Birthday = t.Birthday,
                        Gender = t.Gender,
                        IDNumber = t.IDNumber ,
                        Id = t.Id,
                        Name = t.Name,
                        OutDate = t.OutDate,
                        PersonType = PersonType.PurchaseUnitBuyer,
                        Tel = t.Tel
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<BusinessPersonModel> QuerySupplyUnitSalesmans(QueryBusinessPersonModel queryModel)
        {
            try
            {
                var db = this._UnitOfWork as Db;
                var query = db.SupplyUnitSalesmans.AsQueryable().Where(t => !t.Deleted);

                if (queryModel != null)
                {

                    string Name = queryModel.Name;
                    if (!string.IsNullOrEmpty(Name))
                    {
                        query = query.Where(t => t.Name.Contains(Name));
                    }
                    string IDNumber = queryModel.IDNumber;
                    if (!string.IsNullOrEmpty(IDNumber))
                    {
                        query = query.Where(t => t.IDNumber.Contains(IDNumber));
                    }
                    string Tel = queryModel.Tel;
                    if (!string.IsNullOrEmpty(Tel))
                    {
                        query = query.Where(t => t.Tel.Contains(Tel));
                    }
                    string Address = queryModel.Address;
                    if (!string.IsNullOrEmpty(Address))
                    {
                        query = query.Where(t => t.Address.Contains(Address));
                    }
                    string Gender = queryModel.Gender;
                    if (!string.IsNullOrEmpty(Address))
                    {
                        query = query.Where(t => t.Gender.Contains(Gender));
                    }

                    var Birthday = queryModel.Birthday;
                    if (Birthday != null && Birthday.Max >= Birthday.Min)
                    {
                        DateTime BirthdayMax = Birthday.Max;
                        DateTime BirthdayMin = Birthday.Min;
                        if (BirthdayMax == BirthdayMin)
                        {
                            query = query.Where(t => t.Birthday == BirthdayMax);
                        }
                        else
                        {
                            query = query.Where(t => t.Birthday >= BirthdayMin && t.Birthday <= BirthdayMax);
                        }
                    }
                    var OutDate = queryModel.OutDate;
                    if (OutDate != null && OutDate.Max >= OutDate.Min)
                    {
                        DateTime OutDateMax = OutDate.Max;
                        DateTime OutDateMin = OutDate.Min;
                        if (OutDateMax == OutDateMin)
                        {
                            query = query.Where(t => t.OutDate == OutDateMax);
                        }
                        else
                        {
                            query = query.Where(t => t.OutDate >= OutDateMin && t.OutDate <= OutDateMax);
                        }
                    }


                }
                return query.ToList()
                    .Select(t => new BusinessPersonModel
                    {
                        Address = t.Address,
                        Birthday = t.Birthday,
                        Gender = t.Gender,
                        IDNumber = t.IDNumber,
                        Id = t.Id,
                        Name = t.Name,
                        OutDate = t.OutDate,
                        PersonType = PersonType.SupplyUnitSalesman,
                        Tel = t.Tel
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
