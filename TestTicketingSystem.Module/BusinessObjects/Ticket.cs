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
            CreationDate = DateTime.Now;

           // CreatedBy = (ApplicationUser)SecuritySystem.CurrentUser;
        }
       
        public override void AfterConstruction() {
            base.AfterConstruction();
           
        }


        private string fSubject;
        public string Subject
        {
            get => fSubject;
            set => SetPropertyValue(nameof(Subject), ref fSubject, value);
        }

        private string fDescription;
        [Size(500)]
        public string Description {
            get => fDescription;
            set => SetPropertyValue(nameof(Description), ref fDescription, value);
        }

        private DateTime fCreationDate;
        public DateTime CreationDate {
            get { return fCreationDate; }
            set { SetPropertyValue(nameof(CreationDate), ref fCreationDate, value); }
        }
        private DateTime fAssignDate;
        [ModelDefault("AllowEdit", "False")]
        public DateTime AssignDate
        {
            get { return fAssignDate; }
            set { SetPropertyValue(nameof(AssignDate), ref fAssignDate, value); }
        }
        private DateTime fClosedDate;
        public DateTime ClosedDate
        {
            get { return fClosedDate; }
            set { SetPropertyValue(nameof(ClosedDate), ref fClosedDate, value); }
        }

        private ApplicationUser fCreatedBy;
        [Association("User-Tickets")]

        public ApplicationUser CreatedBy {
            get { return fCreatedBy; }
            set { SetPropertyValue(nameof(CreatedBy), ref fCreatedBy, value); }
        }

        private ApplicationUser assignedTo;
        [Association("SupportStaff-Tickets")]
        public ApplicationUser AssignedTo {
            get { return assignedTo; }
            set { SetPropertyValue(nameof(AssignedTo),ref assignedTo, value); }
        }

        [Association("Ticket-Comments")]
        [DevExpress.Xpo.Aggregated]
        public XPCollection<Comment> Comments => GetCollection<Comment>(nameof(Comments));



        private TicketPriority fPriority;
        public TicketPriority Priority {
            get { return fPriority; }
            set { SetPropertyValue(nameof(Priority), ref fPriority, value); }
        }

        private TicketStatus fStatus;
        public TicketStatus Status {
            get { return fStatus; }
            set { SetPropertyValue(nameof(Status), ref fStatus, value); }

        }
        public void DefineOwnerShip(object UserId) {

            AssignedTo = Session.GetObjectByKey<ApplicationUser>(UserId);
            Status = TicketStatus.InProgress;
            AssignDate = DateTime.Now;
        }

        public void CloseTicket() {

            ClosedDate = DateTime.Now;
            Status = TicketStatus.Resolved;
        }
        protected override void OnSaving() {
            base.OnSaving();
            //CreatedBy = (ApplicationUser)SecuritySystem.CurrentUser;
            //if (Session.IsNewObject(this)) {
            //    CreationDate = DateTime.Now;
            //    CreatedBy = SecuritySystem.CurrentUserName;
            //}
        }

       
    }
}