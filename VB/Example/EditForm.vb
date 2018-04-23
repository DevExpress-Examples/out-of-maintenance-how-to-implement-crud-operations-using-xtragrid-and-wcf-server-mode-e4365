Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Example.ServiceReference1

Namespace Example
	Partial Public Class EditForm
		Inherits Form
		Public Sub New(ByVal customer As Customers)
			InitializeComponent()
			teComN.DataBindings.Add("EditValue", customer, "CompanyName")
			teConN.DataBindings.Add("EditValue", customer, "ContactName")
			teAdd.DataBindings.Add("EditValue", customer, "Address")
			teC.DataBindings.Add("EditValue", customer, "Country")
		End Sub
	End Class
End Namespace
