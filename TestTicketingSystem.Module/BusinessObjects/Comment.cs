using DevExpress.ExpressApp;
using DevExpress.ExpressApp.MiddleTier;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTicketingSystem.Module.BusinessObjects {
    [DefaultClassOptions]

    public class Comment : XPObject {
        public Comment(Session session)
            : base(session) {
        }
        public override void AfterConstruction() {
            base.AfterConstruction();
            if (Session.IsNewObject(this)) {
                fCreationDate = DateTime.Now;
                fCreatedBy = SecuritySystem.CurrentUserName;
            }
        }

        private string fDescription;
        [Size(500)]
        public string Description
        {
            get => fDescription;
            set => SetPropertyValue(nameof(Description), ref fDescription, value);
        }

        private DateTime fCreationDate;
        public DateTime CreationDate {
            get { return fCreationDate; }
            set { SetPropertyValue(nameof(CreationDate), ref fCreationDate, value); }
        }

        private string fCreatedBy;
        public string CreatedBy {
            get { return fCreatedBy; }
            set { SetPropertyValue(nameof(CreatedBy), value); }
        }


        private Ticket fTicket;
        [Association("Ticket-Comments")]
        public Ticket Ticket {
            get { return fTicket; }
            set { SetPropertyValue(nameof(Ticket), value); }
        }

        protected override void OnSaving() {
            base.OnSaving();

            if (Session.IsNewObject(this)) {
                fCreationDate = DateTime.Now;
                fCreatedBy = SecuritySystem.CurrentUserName;
            }
        }
    }
}
