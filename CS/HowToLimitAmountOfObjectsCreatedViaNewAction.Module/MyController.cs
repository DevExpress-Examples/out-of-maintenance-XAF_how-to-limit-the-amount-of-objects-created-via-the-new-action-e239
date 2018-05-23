using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.BaseImpl;

namespace HowToLimitAmountOfObjectsCreatedViaNewAction.Module {
	public partial class MyController : ViewController {
		public MyController() {
			InitializeComponent();
			RegisterActions(components);
		}

		private void MyController_FrameAssigned(object sender, EventArgs e) {
			NewObjectViewController standardController =
			Frame.GetController<NewObjectViewController>();
			standardController.ObjectCreating += new EventHandler<ObjectCreatingEventArgs>(standardController_ObjectCreating);
		}

		void standardController_ObjectCreating(object sender, ObjectCreatingEventArgs e) {
			int count = 0;
			if(View is DevExpress.ExpressApp.ListView) {
				count = ((DevExpress.ExpressApp.ListView)View).CollectionSource.GetCount();
			}
			else {
				count = View.ObjectSpace.GetObjectsCount(typeof(Task), null);
			}
			if(count >= 3) {
				e.Cancel = true;
			}
		}
	}
}
