using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    /// <summary>
    /// 部门处理
    /// </summary>
    partial class DepartmentBusinessHandler
    {
        protected override IQueryable<Department> IncludeNavigationProperties(IQueryable<Department> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable.Include(t => t.Employees)
               );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<Department>>(ex.Message, ex);
            } 
           
        }

        /// <summary>
        /// 重写此方法为添加做验证 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string ValidateAdd(Models.Department value)
        { 
            string result=base.ValidateAdd(value);//调用base验证valule null，String 以及日期
            if (!string.IsNullOrWhiteSpace(result)) return result;
            //开始验证那些必填的。
            if (string.IsNullOrWhiteSpace(value.Name))
            {
                return "请您输入[部门]的[名称]!"; 
            } 
            return string.Empty; 
        }

        /// <summary>
        /// 根据某部门编号获取子部门
        /// </summary>
        /// <param name="pDepartmentId"></param>
        /// <returns></returns>
        public IEnumerable<Department> GetSubDepartments(Guid pDepartmentId)
        {
            try
            {
                return this.Fetch(d => d.DepartmentId == pDepartmentId).ToList();

            }
            catch (Exception ex)
            { 
                return this.HandleException<IEnumerable<Department>>("根据某部门编号获取子部门失败", ex);
            }
        }

        /// <summary>
        /// 根据部门编号获取其上级部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetParentDepartment(Guid id)
        {
            try
            { 
                Department department = Get(id);
                return this.Fetch(d => department.Id == department.DepartmentId)
                           .FirstOrDefault();

            }
            catch (Exception ex)
            { 
                return this.HandleException<Department>("根据某部门编号获取子部门失败", ex);
            }
        }

        /// <summary>
        /// //
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteSubDepartment(Guid id)
        {
            throw  new TodoException();
        }
    }
}
