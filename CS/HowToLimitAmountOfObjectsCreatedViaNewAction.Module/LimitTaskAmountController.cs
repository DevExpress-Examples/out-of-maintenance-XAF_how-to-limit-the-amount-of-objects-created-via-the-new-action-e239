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

namespace LimitObjectsCreatedViaNewAction.Module {
	public class LimitTaskAmountController : ViewController {
		private NewObjectViewController controller;
        protected override void OnActivated() {
            base.OnActivated();
            controller = Frame.GetController<NewObjectViewController>();
            if (controller != null) {
                controller.ObjectCreating += controller_ObjectCreating;
            }
        }
		void controller_ObjectCreating(object sender, ObjectCreatingEventArgs e) {
            if ((e.ObjectType == typeof(Task)) && 
                (e.ObjectSpace.GetObjectsCount(typeof(Task), null) >= 3)) {
                 e.Cancel = true;
                 throw new UserFriendlyException("Cannot create a task. Maximum allowed task count exceeded.");
            }
		}
        protected override void OnDeactivated() {
            if (controller != null) {
                controller.ObjectCreating -= controller_ObjectCreating;
            }
            base.OnDeactivated();
        }
	}
}
