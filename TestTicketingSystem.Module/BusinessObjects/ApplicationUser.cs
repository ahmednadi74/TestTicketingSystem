using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;

namespace TestTicketingSystem.Module.BusinessObjects {
    [MapInheritance(MapInheritanceType.ParentTable)]
    [DefaultProperty(nameof(UserName))]
    public class ApplicationUser : PermissionPolicyUser, IObjectSpaceLink, ISecurityUserWithLoginInfo {
        public ApplicationUser(Session session) : base(session) { }




        [Browsable(false)]
        [Aggregated, Association("User-LoginInfo")]
        public XPCollection<ApplicationUserLoginInfo> LoginInfo {
            get { return GetCollection<ApplicationUserLoginInfo>(nameof(LoginInfo)); }
        }

        IEnumerable<ISecurityUserLoginInfo> IOAuthSecurityUser.UserLogins => LoginInfo.OfType<ISecurityUserLoginInfo>();

        IObjectSpace IObjectSpaceLink.ObjectSpace { get; set; }

        ISecurityUserLoginInfo ISecurityUserWithLoginInfo.CreateUserLoginInfo(string loginProviderName, string providerUserKey) {
            ApplicationUserLoginInfo result = ((IObjectSpaceLink)this).ObjectSpace.CreateObject<ApplicationUserLoginInfo>();
            result.LoginProviderName = loginProviderName;
            result.ProviderUserKey = providerUserKey;
            result.User = this;
            return result;
        }

        private string firstName;
        public string FirstName {
            get => firstName;
            set => SetPropertyValue(nameof(FirstName), ref firstName, value);
        }

        private string lastName;
        public string LastName {
            get => lastName;
            set => SetPropertyValue(nameof(LastName), ref lastName, value);
        }

        private string email;
        public string Email {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [Association("User-Tickets")]
        public XPCollection<Ticket> Tickets => GetCollection<Ticket>(nameof(Tickets));

        private Department department;
        [Association("Department-Users")]
        public Department Department{
            get { return department; }
            set { SetPropertyValue(nameof(Department), value); }
        }

    }
}
