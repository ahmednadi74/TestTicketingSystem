using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTicketingSystem.Module.BusinessObjects
{

    [DefaultClassOptions]
   
    public class Department : XPObject
    { 
        public Department(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
      
        private string name;
        public string Name {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
        

        [Association("Department-Users")]
        public XPCollection<ApplicationUser> Users => GetCollection<ApplicationUser>(nameof(Users));

        
        //[Association("Department-SupportStaff")]
        //public XPCollection<SupportStaff> SupportStaff => GetCollection<SupportStaff>(nameof(SupportStaff));

    }
}
