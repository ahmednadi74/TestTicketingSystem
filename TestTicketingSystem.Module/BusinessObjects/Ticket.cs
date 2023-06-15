using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Utils;
using static TestTicketingSystem.Module.BusinessObjects.Ticket;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;

namespace TestTicketingSystem.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Ticket : XPObject {
        public Ticket(Session session)
            : base(session) {
        }
        public override void AfterConstruction() {
            base.AfterConstruction();
        }
      
       
        private string title;
        public string Title {
            get => title;
            set => SetPropertyValue(nameof(Title), ref title, value);
        }

        private string description;
        public string Description {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        private ApplicationUser createdBy;
        [Association("User-Tickets")]
        public ApplicationUser CreatedBy {
            get { return createdBy; }
            set { SetPropertyValue(nameof(CreatedBy), value); }
        }

        [Association("Ticket-Comments")]
        [DevExpress.Xpo.Aggregated]
        public XPCollection<Comment> Comments => GetCollection<Comment>(nameof(Comments));

 
     
        private TicketPriority priority;
        public TicketPriority Priority {
            get { return priority; }
            set { SetPropertyValue(nameof(Priority), ref priority, value); }
        }

        private TicketStatus status;
        public TicketStatus Status {
            get { return status; }
            set { SetPropertyValue(nameof(Status), ref status, value); }
            
        }
      
    }
}