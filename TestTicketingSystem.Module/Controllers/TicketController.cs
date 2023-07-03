using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Security;
using System;
using TestTicketingSystem.Module.BusinessObjects;

namespace TestTicketingSystem.Module.Controllers {
    public partial class TicketController : ViewController {
        public TicketController() {
            InitializeComponent();

            // Activate the Controller in any type of View.
            TargetObjectType = typeof(Ticket);
            TargetViewType = ViewType.DetailView;
        }

        protected override void OnActivated() {
            base.OnActivated();
            //ISecurityUserWithRoles currentUser = (ISecurityUserWithRoles)SecuritySystem.CurrentUser;
            //if (currentUser.IsUserInRole("User")) {
            //    DefineOwnership.Active.SetItemValue("Visible", false);
            //    TakeOwnership.Active.SetItemValue("Visible", false);
            //    CloseTicket.Active.SetItemValue("Visible", false);

            //}
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
            if (e.PopupWindow.View.CurrentObject is ApplicationUser selectedUser
                && View.CurrentObject is Ticket ticket) {
                ticket.DefineOwnerShip(selectedUser.Oid);
            }
            ObjectSpace.CommitChanges();
            Application.ShowViewStrategy.ShowMessage($"The ticket is Assigned To {e.PopupWindow.View.CurrentObject} Successfully.", InformationType.Success);

        }

        private void TakeOwnership_Execute(object sender, SimpleActionExecuteEventArgs e) {

            if (SecuritySystem.CurrentUser is ApplicationUser selectedUser
                && View.CurrentObject is Ticket ticket) {
                if (ticket.AssignedTo != null) {
                    Application.ShowViewStrategy.ShowMessage($"The ticket is already assigned to: {ticket.AssignedTo.UserName}", InformationType.Error);
                    return;
                }
                ticket.DefineOwnerShip(selectedUser.Oid);
            }
            ObjectSpace.CommitChanges();
        }

        private void CloseTicket_Execute(object sender, SimpleActionExecuteEventArgs e) {

            if (SecuritySystem.CurrentUser is ApplicationUser selectedUser && View.CurrentObject is Ticket ticket) {
                ticket.CloseTicket();
            }
            ObjectSpace.CommitChanges();
            Application.ShowViewStrategy.ShowMessage($"The ticket is Resolved Successfully.", InformationType.Success);

        }
    }
}