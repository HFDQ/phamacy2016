using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class RoleWithModuleModel
    {
        [DisplayName("角色名称")]
        [DataMember]
        public string RoleName { get; set; }

        [DisplayName("角色编码")]
        [DataMember]
        public string RoleCode { get; set; }

        [DisplayName("角色描述")]
        [DataMember]
        public string RoleDescription { get; set; }

        [DisplayName("权限名称")]
        [DataMember]
        public string ModuleName { get; set; }

        [DisplayName("授权码")]
        [DataMember]
        public string ModuleAuthKey { get; set; }
    }


    public class RoleWithUserModel
    {
        [DisplayName("角色名称")]
        [DataMember]
        public string RoleName { get; set; }

        [DisplayName("角色编码")]
        [DataMember]
        public string RoleCode { get; set; }

        [DisplayName("角色描述")]
        [DataMember]
        public string RoleDescription { get; set; }

        [DisplayName("用户账号")]
        [DataMember]
        public string UserAcount { get; set; }

        [DisplayName("密码")]
        [DataMember]
        public string Password { get; set; }

        [DisplayName("员工姓名")]
        [DataMember]
        public string EmployeeName{ get; set; }
    }

}
