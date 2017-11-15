using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace lesFiltres.Models {
    public class MyRoleProvider : RoleProvider {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles() {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username) {
            throw new NotImplementedException();
            // vérification des roles via la BDD par exemple
            string[] arrayOfString;
            WPFTutorialEntities1DataContext gu = new WPFTutorialEntities1DataContext();
            var listRole = gu.GetRoleOfUser( username ).ToList<GetRoleOfUserResult>();
            int indice = 0;
            foreach( GetRoleOfUserResult tmp in listRole) {
                arrayOfString[indice] = tmp.Name;
                indice++;
            }

            return arrayOfString;

        }

        public override string[] GetUsersInRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName) {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName) {
            throw new NotImplementedException();
        }
    }
}