using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Web;

namespace LimitObjectsCreatedViaNewAction.Web {
	public partial class LimitObjectsCreatedViaNewActionAspNetApplication : WebApplication {
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProvider = new XPObjectSpaceProvider(args.ConnectionString, args.Connection);
        }
		private DevExpress.ExpressApp.SystemModule.SystemModule module1;
		private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
		private LimitObjectsCreatedViaNewAction.Module.LimitObjectsCreatedViaNewActionModule module3;
        private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
        private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule module6;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private DevExpress.ExpressApp.Validation.ValidationModule module5;

		public LimitObjectsCreatedViaNewActionAspNetApplication() {
			InitializeComponent();
		}

		private void LimitObjectsCreatedViaNewActionAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
			e.Updater.Update();
			e.Handled = true;
		}

		private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
            this.module3 = new LimitObjectsCreatedViaNewAction.Module.LimitObjectsCreatedViaNewActionModule();
            this.module5 = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.module6 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // module5
            // 
            this.module5.AllowValidationDetailsAccess = true;
            this.module5.IgnoreWarningAndInformationRules = false;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=LimitObjectsCreatedViaNewAction;Integrated Se" +
    "curity=SSPI;Pooling=false";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // LimitObjectsCreatedViaNewActionAspNetApplication
            // 
            this.ApplicationName = "LimitObjectsCreatedViaNewAction";
            this.Connection = this.sqlConnection1;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.module6);
            this.Modules.Add(this.module3);
            this.Modules.Add(this.module5);
            this.Modules.Add(this.securityModule1);
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.LimitObjectsCreatedViaNewActionAspNetApplication_DatabaseVersionMismatch);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
	}
}
