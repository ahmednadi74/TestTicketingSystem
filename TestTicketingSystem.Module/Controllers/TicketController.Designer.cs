namespace TestTicketingSystem.Module.Controllers {
    partial class TicketController {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.DefineOwnership = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.TakeOwnership = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.CloseTicket = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // DefineOwnership
            // 
            this.DefineOwnership.AcceptButtonCaption = null;
            this.DefineOwnership.CancelButtonCaption = null;
            this.DefineOwnership.Caption = "Define Ownership";
            this.DefineOwnership.ConfirmationMessage = null;
            this.DefineOwnership.Id = "DefineOwnership";
            this.DefineOwnership.ToolTip = null;
            this.DefineOwnership.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.DefineOwnership_CustomizePopupWindowParams);
            this.DefineOwnership.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.DefineOwnership_Execute);
            // 
            // TakeOwnership
            // 
            this.TakeOwnership.Caption = "Take Ownership";
            this.TakeOwnership.ConfirmationMessage = null;
            this.TakeOwnership.Id = "TakeOwnership";
            this.TakeOwnership.ToolTip = null;
            this.TakeOwnership.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.TakeOwnership_Execute);
            // 
            // CloseTicket
            // 
            this.CloseTicket.Caption = "Close Ticket";
            this.CloseTicket.Category = "Save";
            this.CloseTicket.ConfirmationMessage = null;
            this.CloseTicket.Id = "CloseTicket";
            this.CloseTicket.ToolTip = null;
            this.CloseTicket.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.CloseTicket_Execute);
            // 
            // TicketController
            // 
            this.Actions.Add(this.DefineOwnership);
            this.Actions.Add(this.TakeOwnership);
            this.Actions.Add(this.CloseTicket);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction DefineOwnership;
        private DevExpress.ExpressApp.Actions.SimpleAction TakeOwnership;
        private DevExpress.ExpressApp.Actions.SimpleAction CloseTicket;
    }
}
