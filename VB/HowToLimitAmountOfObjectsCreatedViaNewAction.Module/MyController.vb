Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent.BaseImpl

Namespace LimitObjectsCreatedViaNewAction.Module
	Partial Public Class MyController
		Inherits ViewController
		Public Sub New()
			InitializeComponent()
			RegisterActions(components)
		End Sub

		Private Sub MyController_FrameAssigned(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.FrameAssigned
			Dim standardController As NewObjectViewController = Frame.GetController(Of NewObjectViewController)()
			AddHandler standardController.ObjectCreating, AddressOf standardController_ObjectCreating
		End Sub

		Private Sub standardController_ObjectCreating(ByVal sender As Object, ByVal e As ObjectCreatingEventArgs)
			If View.ObjectTypeInfo.Type Is GetType(Task) Then
				Dim count As Integer = 0
				If TypeOf View Is DevExpress.ExpressApp.ListView Then
					count = (CType(View, DevExpress.ExpressApp.ListView)).CollectionSource.GetCount()
				Else
					count = View.ObjectSpace.GetObjectsCount(GetType(Task), Nothing)
				End If
				If count >= 3 Then
					e.Cancel = True
				End If
			End If
		End Sub
	End Class
End Namespace
