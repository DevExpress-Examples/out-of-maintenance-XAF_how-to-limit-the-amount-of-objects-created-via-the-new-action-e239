using DevExpress.ExpressApp.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;

namespace LimitObjectsCreatedViaNewAction.Win {
	public partial class LimitObjectsCreatedViaNewActionWindowsFormsApplication : WinApplication {
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProvider = new XPObjectSpaceProvider(args.ConnectionString, args.Connection);
        }
		public LimitObjectsCreatedViaNewActionWindowsFormsApplication() {
			InitializeComponent();
		}

		private void LimitObjectsCreatedViaNewActionWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
    		e.Updater.Update();
			e.Handled = true;
		}
	}
}
