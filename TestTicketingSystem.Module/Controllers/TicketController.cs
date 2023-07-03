using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Security;
using DevExpress.Internal;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using System;
using System.Linq;
using System.Windows.Forms;
using TestTicketingSystem.Module.BusinessObjects;

namespace TestTicketingSystem.Module.Controllers {
    public partial class TicketController : ViewController {
        public TicketController() {
            InitializeComponent();

            // Activate the Controller in any type of View.
            TargetObjectType = typeof(Ticket);
            TargetViewType = ViewType.DetailView;

            //PopupWindowShowAction DefineOwnership = new PopupWindowShowAction(this, "DefineOwnership", PredefinedCategory.Edit) {
            //    Caption = "Show Notes"
            //  };

            //DefineOwnership.CustomizePopupWindowParams += DefineOwnership_CustomizePopupWindowParams;
            //DefineOwnership.Execute += DefineOwnership_Execute;

        }

        protected override void OnActivated() {
            base.OnActivated();
            ISecurityUserWithRoles currentUser = (ISecurityUserWithRoles)SecuritySystem.CurrentUser;
            if (currentUser.IsUserInRole("User")) {
                DefineOwnership.Active.SetItemValue("Visible", false);
                TakeOwnership.Active.SetItemValue("Visible", false);
                //DefineOwnership.Enabled["ForAdminsOnly"] = currentUser.IsUserInRole("Administrators");
                //TakeOwnership.Enabled["ForAdminsOnly"] = currentUser.IsUserInRole("SupportStaff");

            }
        }
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated() {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void DefineOwnership_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) {

            //Create a List View for Users in the pop-up window.

           e.View = Application.CreateListView(typeof(ApplicationUser), true);
          
        }

        private void DefineOwnership_Execute(object sender, PopupWindowShowActionExecuteEventArgs e) {

            var selectedUser = e.PopupWindow.View.CurrentObject as ApplicationUser;
            if (selectedUser == null) {
                return;
            }
            var objectSpace = this.View.ObjectSpace;
            var currentObject = this.View.CurrentObject as Ticket;
            if (currentObject == null) {
                return;
            }
            var updatedTicket = objectSpace.GetObject(currentObject);
            //var currentUser = objectSpace.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            //if (currentUser == null) {
            //    return;
            //}
            //var currentUserRoles = currentUser.Roles.Select(r => r.Name).ToList();
            //if (!currentUserRoles.Contains("SupportStaff") && !currentUserRoles.Contains("Administrators")) {
              //  MessageBox.Show("Only users in the SupportStaff and Administrators roles can define ownership of a ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            updatedTicket.AssignedTo = objectSpace.GetObject(selectedUser);
            updatedTicket.Status = TicketStatus.InProgress;
            objectSpace.CommitChanges();
        }

        //    var selectedUser = e.PopupWindow.View.CurrentObject as ApplicationUser;
        //    if (selectedUser != null) {
        //        var objectSpace = this.View.ObjectSpace;
        //        var currentObject = this.View.CurrentObject as Ticket;
        //        if (currentObject != null) {
        //            var updatedTicket = objectSpace.GetObject(currentObject);
        //            var currentUser = objectSpace.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
        //                if (currentUser.Roles.Any(r => r.Name == "SupportStaff" || r.Name == "Administrators")) {
        //                    updatedTicket.AssignedTo = objectSpace.GetObject(selectedUser);
        //                    updatedTicket.Status = TicketStatus.InProgress;
        //                    objectSpace.CommitChanges();
        //                }
        //                else {
        //                    MessageBox.Show("Only users in the SupportStaff and Administrators roles can define ownership of a ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //        }
        //    }
        //} 
        //    var selectedUser = e.PopupWindow.View.CurrentObject as ApplicationUser;
        //    var ticket = e.CurrentObject as Ticket;
        //    if (ticket != null) {
        //        var objectSpace = this.ObjectSpace;
        //        var currentUser = objectSpace.GetObject(UserData.);
        //        var updatedTicket = objectSpace.GetObject(ticket);
        //        var updatedUser = objectSpace.GetObject(selectedUser);
        //        if (updatedUser != null && (SecuritySystem.IsGranted(new PermissionRequest(ObjectSpace, typeof(ApplicationUser), SecurityOperations.Read, updatedUser)) || SecuritySystem.IsGranted(new PermissionRequest(ObjectSpace, typeof(Role), SecurityOperations.Read)))) {
        //            if (updatedUser.Roles.Any(r => r.Name == "SupportStaff" || r.Name == "Administrators")) {
        //                updatedTicket.AssignedTo = updatedUser;
        //                updatedTicket.Status = TicketStatus.InProgress;
        //                objectSpace.CommitChanges();
        //            }
        //            else {
        //                MessageBox.Show("Only users in the SupportStaff and Administrators roles can define ownership of a ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //}


        //        var selectedUser = e.PopupWindow.View.CurrentObject as ApplicationUser;
        //        if (selectedUser != null) {
        //            var selectedObjects = this.View.SelectedObjects;
        //            if (selectedObjects != null) {
        //                var objectSpace = this.View.ObjectSpace;
        //                foreach (var obj in selectedObjects) {
        //                    if (obj is Ticket ticket) {
        //                        var updatedTicket = objectSpace.GetObject(ticket);
        //        var updatedUser = objectSpace.GetObject(selectedUser);
        //        updatedTicket.AssignedTo = updatedUser;
        //                        updatedTicket.Status = TicketStatus.InProgress;
        //                    }
        //}
        //objectSpace.CommitChanges();
        //            }
        //}
        //   }

        private void TakeOwnership_Execute(object sender, SimpleActionExecuteEventArgs e) {
            var ticket = e.CurrentObject as Ticket;
            if (ticket != null) {
                var currentUser = SecuritySystem.CurrentUser as ApplicationUser;
                var assignedTo = ticket.AssignedTo;
                if (currentUser != null && assignedTo != null && currentUser.Oid == assignedTo.Oid) {
                    var objectSpace = this.ObjectSpace;
                    var updatedTicket = objectSpace.GetObject(ticket);
                    updatedTicket.AssignDate = DateTime.Now;
                    objectSpace.CommitChanges();
                }
                else {
                    MessageBox.Show("Only the assigned user can take ownership of this ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CloseTicket_Execute(object sender, SimpleActionExecuteEventArgs e) {

            var ticket = e.CurrentObject as Ticket;
            if (ticket != null) {
                var currentUser = SecuritySystem.CurrentUser as ApplicationUser;
                var assignedTo = ticket.AssignedTo;
                if (currentUser != null && assignedTo != null && currentUser.Oid == assignedTo.Oid) {
                    var objectSpace = this.ObjectSpace;
                    var updatedTicket = objectSpace.GetObject(ticket);
                    updatedTicket.ClosedDate = DateTime.Now;
                    updatedTicket.Status = TicketStatus.Resolved;
                    objectSpace.CommitChanges();
                }
                else {
                    MessageBox.Show("Only the assigned user can close this ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}