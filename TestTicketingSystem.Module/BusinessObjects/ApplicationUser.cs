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

        private string fFirstName;
        public string FirstName {
            get => fFirstName;
            set => SetPropertyValue(nameof(FirstName), ref fFirstName, value);
        }

        private string fLastName;
        public string LastName {
            get => fLastName;
            set => SetPropertyValue(nameof(LastName), ref fLastName, value);
        }

        private string fEmail;
        public string Email {
            get => fEmail;
            set => SetPropertyValue(nameof(Email), ref fEmail, value);
        }
       
        private string fMobile;
        public string Mobile {
            get => fMobile;
            set => SetPropertyValue(nameof(Mobile), ref fMobile, value);
        }

        [Association("User-Tickets")]
        public XPCollection<Ticket> UserTickets => GetCollection<Ticket>(nameof(UserTickets));

        [Association("SupportStaff-Tickets")]
        public XPCollection<Ticket> SupportStaffTickets => GetCollection<Ticket>(nameof(SupportStaffTickets));

        private Department fDepartment;
        [Association("Department-Users")]
        public Department Department{
            get { return fDepartment; }
            set { SetPropertyValue(nameof(Department),ref fDepartment, value); }
        }
        private Subsidiary fSubsidiary;
        [Association("Subsidiary-Users")]
        public Subsidiary Subsidiary {
            get { return fSubsidiary; }
            set { SetPropertyValue(nameof(Subsidiary),ref fSubsidiary, value); }
        }

    }
}
