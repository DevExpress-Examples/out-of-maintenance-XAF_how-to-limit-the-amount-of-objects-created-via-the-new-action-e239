Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.SystemModule

Public Class MyController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

	End Sub

   Private Sub MyController_FrameAssigned(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FrameAssigned
      Dim standardController As NewObjectViewController = _
         Frame.GetController(Of NewObjectViewController)()
      AddHandler standardController.ObjectCreating, AddressOf _
         standardController_ObjectCreating
   End Sub
   Private Sub standardController_ObjectCreating(ByVal sender As Object, ByVal e As ObjectCreatingEventArgs)
      Dim count As Integer = 0
      If TypeOf View Is DevExpress.ExpressApp.ListView Then
         count = (CType(View, DevExpress.ExpressApp.ListView)).CollectionSource.GetCount()
      Else
         count = View.ObjectSpace.GetObjectsCount(GetType(Task), Nothing)
      End If
      If count >= 3 Then
         e.Cancel = True
      End If
   End Sub
End Class
