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
    Public Class LimitTaskAmountController
        Inherits ViewController

        Private controller As NewObjectViewController
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            controller = Frame.GetController(Of NewObjectViewController)()
            If controller IsNot Nothing Then
                AddHandler controller.ObjectCreating, AddressOf controller_ObjectCreating
            End If
        End Sub
        Private Sub controller_ObjectCreating(ByVal sender As Object, ByVal e As ObjectCreatingEventArgs)
            If (e.ObjectType Is GetType(Task)) AndAlso (e.ObjectSpace.GetObjectsCount(GetType(Task), Nothing) >= 3) Then
                 e.Cancel = True
                 Throw New UserFriendlyException("Cannot create a task. Maximum allowed task count exceeded.")
            End If
        End Sub
        Protected Overrides Sub OnDeactivated()
            If controller IsNot Nothing Then
                RemoveHandler controller.ObjectCreating, AddressOf controller_ObjectCreating
            End If
            MyBase.OnDeactivated()
        End Sub
    End Class
End Namespace
