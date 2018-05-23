Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Namespace LimitObjectsCreatedViaNewAction.Web
    Partial Public Class LimitObjectsCreatedViaNewActionAspNetApplication
        Inherits WebApplication

        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection)
        End Sub
        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As LimitObjectsCreatedViaNewAction.Module.LimitObjectsCreatedViaNewActionModule
        Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
        Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
        Private sqlConnection1 As System.Data.SqlClient.SqlConnection
        Private module5 As DevExpress.ExpressApp.Validation.ValidationModule

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub LimitObjectsCreatedViaNewActionAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
            e.Updater.Update()
            e.Handled = True
        End Sub

        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New LimitObjectsCreatedViaNewAction.Module.LimitObjectsCreatedViaNewActionModule()
            Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
            Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
            Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
            Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' module5
            ' 
            Me.module5.AllowValidationDetailsAccess = True
            Me.module5.IgnoreWarningAndInformationRules = False
            ' 
            ' sqlConnection1
            ' 
            Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=LimitObjectsCreatedViaNewAction;Integrated Se" & "curity=SSPI;Pooling=false"
            Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
            ' 
            ' LimitObjectsCreatedViaNewActionAspNetApplication
            ' 
            Me.ApplicationName = "LimitObjectsCreatedViaNewAction"
            Me.Connection = Me.sqlConnection1
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module6)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.module5)
            Me.Modules.Add(Me.securityModule1)
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
