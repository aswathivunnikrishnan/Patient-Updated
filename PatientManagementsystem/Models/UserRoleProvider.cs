using PatientManagementsystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PatientManagementsystem.Models
{
    public class UserRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            loginDBHelper login = new loginDBHelper();
            Employee employee =login.GetEmployeeByUserName(username);   
            List<string> role = new List<string>();
            if (employee.Designation == "SUPERADMIN")
            {
                role.Add("SuperAdmin");
            }
            else if (employee.Admin== true)
            {
                role.Add("Admin");
            }
            else if(employee.Designation=="DOCTOR")
            {
                role.Add("Doctor");
            }
            else if (employee.Designation == "PHARMACIST")
            {
                role.Add("Pharmacist");
            }
            else
            {
                role.Add("Patient");
            }
            return role.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}