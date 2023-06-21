using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TestTicketingSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
     public class Company : XPObject
    { 
        public Company(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        private string fName;
        public string Name
        {
            get => fName;
            set => SetPropertyValue(nameof(Name), ref fName, value);
        }
        private string fAddress;
        [Size(500)]

        public string Address
        {
            get => fAddress;
            set => SetPropertyValue(nameof(Address), ref fAddress, value);
        }
        private string fContactInfo;
        [Size(500)]

        public string ContactInfo
        {
            get => fContactInfo;
            set => SetPropertyValue(nameof(ContactInfo), ref fContactInfo, value);
        }
        [Association("Company-Users")]
        public XPCollection<ApplicationUser> Users => GetCollection<ApplicationUser>(nameof(Users));



    }
}