using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
      
        private string fName;
        public string Name {
            get => fName;
            set => SetPropertyValue(nameof(Name), ref fName, value);
        }
        

        [Association("Department-Users")]
        public XPCollection<ApplicationUser> Users => GetCollection<ApplicationUser>(nameof(Users));


    }
}
