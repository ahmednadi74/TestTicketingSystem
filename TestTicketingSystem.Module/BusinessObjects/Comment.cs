using DevExpress.ExpressApp.MiddleTier;
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
    
    public class Comment : XPObject
    {
        public Comment(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        
        }
        
        private string content;
        [Size(500)]
        public string Content {
             get =>  content; 
             set => SetPropertyValue(nameof(Content), ref content, value); 
        }
       
        private DateTime creationDate;
        public DateTime CreationDate {
            get { return creationDate; }
            set { SetPropertyValue(nameof(CreationDate), ref creationDate, value); }
        }

        private ApplicationUser createdBy;
        public ApplicationUser CreatedBy {
            get { return createdBy; }
            set { SetPropertyValue(nameof(CreatedBy), value); }
        }


        private ApplicationUser assignTo;
        public ApplicationUser AssignTo {
            get { return assignTo; }
            set { SetPropertyValue(nameof(AssignTo), value); }
        }

        private Ticket ticket;
        [Association("Ticket-Comments")]
        public Ticket Ticket {
            get { return ticket; }
            set { SetPropertyValue(nameof(Ticket), value); }
        }
       
    }
}
