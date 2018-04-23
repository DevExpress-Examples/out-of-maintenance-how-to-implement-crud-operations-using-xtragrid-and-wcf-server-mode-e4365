Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Xpf.Core.ServerMode
Imports DevExpress.Data.WcfLinq
Imports System.Data.Services.Client
Imports Example.ServiceReference1

Namespace Example
	Partial Public Class MainForm
		Inherits Form
		Private context As NorthwindEntities

		Private wcfInstantSource As WcfInstantFeedbackSource

		Private newCustomer As Customers

		Private customerToEdit As Customers

		Public Sub New()
			InitializeComponent()
			context = New NorthwindEntities(New Uri("http://localhost:56848/NorthwindWcfDataService.svc/"))
			wcfInstantSource = New WcfInstantFeedbackSource()
			wcfInstantSource.KeyExpression &= "CustomerID"
			AddHandler wcfInstantSource.GetSource, AddressOf wcfInstantSource_GetSource
			gridControl1.DataSource = wcfInstantSource
		End Sub

		Private Sub wcfInstantSource_GetSource(ByVal sender As Object, ByVal e As GetSourceEventArgs)
			e.Query = context.Customers
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			newCustomer = CreateNewCustomer()
			EditCustomer(newCustomer, "Add new customer", AddressOf CloseAddNewCustomerHandler)
		End Sub

		Private Sub CloseAddNewCustomerHandler(ByVal sender As Object, ByVal e As EventArgs)
			If (CType(sender, EditForm)).DialogResult = System.Windows.Forms.DialogResult.OK Then
				context.AddToCustomers(newCustomer)
				SaveChandes()
			End If
			newCustomer = Nothing
		End Sub

		Private Function CreateNewCustomer() As Customers
			Dim newCustomer = New Customers()
			newCustomer.CustomerID = GenerateCustomerID()
			Return newCustomer
		End Function

		Private Function GenerateCustomerID() As String
			Const IDLength As Integer = 5
			Dim result = String.Empty
			Dim rnd = New Random()
			For i = 0 To IDLength - 1
				result += Convert.ToChar(rnd.Next(65, 90))
			Next i
			Return result
		End Function

		Private Sub EditCustomer(ByVal customer As Customers, ByVal windowTitle As String, ByVal closedDelegate As FormClosingEventHandler)
			Dim frm = New EditForm(customer)
			frm.Text = windowTitle
			AddHandler frm.FormClosing, closedDelegate
			frm.ShowDialog()
		End Sub

		Private Sub SaveChandes()
			Dim asyncResult As IAsyncResult = Nothing
			Try
				asyncResult = context.BeginSaveChanges(AddressOf SaveCallback, Nothing)
			Catch ex As Exception
				context.CancelRequest(asyncResult)
				HandleException(ex)
			End Try
		End Sub

		Private Sub SaveCallback(ByVal asyncResult As IAsyncResult)
			Dim response As DataServiceResponse = Nothing
			Try
				response = context.EndSaveChanges(asyncResult)
			Catch ex As Exception
				gridControl1.BeginInvoke(CType(Function() AnonymousMethod1(asyncResult), MethodInvoker))
				HandleException(ex)
				gridControl1.BeginInvoke(CType(Function() AnonymousMethod2(), MethodInvoker))
			End Try
			gridControl1.BeginInvoke(CType(Function() AnonymousMethod3(), MethodInvoker))
		End Sub
		
		Private Function AnonymousMethod1(ByVal asyncResult As IAsyncResult) As Boolean
			context.CancelRequest(asyncResult)
			Return True
		End Function
		
		Private Function AnonymousMethod2() As Boolean
			DetachFailedEntities()
			Return True
		End Function
		
		Private Function AnonymousMethod3() As Boolean
			wcfInstantSource.Refresh()
			Return True
		End Function

		Private Sub DetachFailedEntities()
			For Each entityDescriptor As EntityDescriptor In context.Entities
				If entityDescriptor.State <> EntityStates.Unchanged Then
					context.Detach(entityDescriptor.Entity)
				End If
			Next entityDescriptor
		End Sub

		Private Sub HandleException(ByVal ex As Exception)
			gridControl1.BeginInvoke(CType(Function() AnonymousMethod4(ex), MethodInvoker))
		End Sub
		
		Private Function AnonymousMethod4(ByVal ex As Exception) As Boolean
			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
			Return True
		End Function

		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			EditSelectedCustomer(gridView1.FocusedRowHandle)
		End Sub

		Private Sub EditSelectedCustomer(ByVal rowHandle As Integer)
			If rowHandle < 0 Then
				Return
			End If
			FindCustomerByIDAndProcess(GetCustomerIDByRowHandle(rowHandle), Function(customer) AnonymousMethod5(customer))
		End Sub
		
		Private Function AnonymousMethod5(ByVal customer As Object) As Boolean
			customerToEdit = customer
			EditCustomer(customerToEdit, "Edit customer", AddressOf CloseEditCustomerHandler)
			Return True
		End Function

		Private Function GetCustomerIDByRowHandle(ByVal rowHandle As Integer) As String
			Return CStr(gridView1.GetRowCellValue(rowHandle, "CustomerID"))
		End Function

		Private Sub CloseEditCustomerHandler(ByVal sender As Object, ByVal e As EventArgs)
			If (CType(sender, EditForm)).DialogResult = System.Windows.Forms.DialogResult.OK Then
				context.UpdateObject(customerToEdit)
				SaveChandes()
			End If
			customerToEdit = Nothing
		End Sub

        Private Sub FindCustomerByIDAndProcess(ByVal customerID As String, ByVal action As Action(Of Customers))
            Dim query As DataServiceQuery(Of Customers) = CType(context.Customers.Where(Function(customer) customer.CustomerID = customerID), DataServiceQuery(Of Customers))
            Try
                query.BeginExecute(AddressOf FindCustomerByIDCallback, New QueryAction(query, action))
            Catch ex As Exception
                HandleException(ex)
            End Try
        End Sub

		Private Sub FindCustomerByIDCallback(ByVal ar As IAsyncResult)
			Dim state = CType(ar.AsyncState, QueryAction)
			Dim customers = state.Query.EndExecute(ar)
			For Each customer As Customers In customers
				Try
					gridControl1.BeginInvoke(CType(Function() AnonymousMethod6(state, customer), MethodInvoker))
				Catch ex As Exception
					HandleException(ex)
				End Try
			Next customer
		End Sub
		
        Private Function AnonymousMethod6(ByVal state As QueryAction, ByVal customer As Customers) As Boolean
            state.Action(customer)
            Return True
        End Function

		Private Sub simpleButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton3.Click
			DeleteSelectedCustomer(gridView1.FocusedRowHandle)
		End Sub

		Private Sub DeleteSelectedCustomer(ByVal rowHandle As Integer)
			If rowHandle < 0 Then
				Return
			End If
			If MessageBox.Show("Do you really want to delete the selected customer?", "Delete Customer", MessageBoxButtons.OKCancel) <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If
			FindCustomerByIDAndProcess(GetCustomerIDByRowHandle(rowHandle), Function(customer) AnonymousMethod7(customer))
		End Sub
		
		Private Function AnonymousMethod7(ByVal customer As Object) As Boolean
			context.DeleteObject(customer)
			SaveChandes()
			Return True
		End Function
	End Class

	Public Class QueryAction
		Private query_Renamed As DataServiceQuery(Of Customers)

		Private action_Renamed As Action(Of Customers)

		Public Sub New(ByVal query As DataServiceQuery(Of Customers), ByVal action As Action(Of Customers))
			Me.query_Renamed = query
			Me.action_Renamed = action
		End Sub

		Public ReadOnly Property Query() As DataServiceQuery(Of Customers)
			Get
				Return query_Renamed
			End Get
		End Property

        Public Sub Action(customer As Customers)
            action_Renamed(customer)
        End Sub
    End Class
End Namespace
