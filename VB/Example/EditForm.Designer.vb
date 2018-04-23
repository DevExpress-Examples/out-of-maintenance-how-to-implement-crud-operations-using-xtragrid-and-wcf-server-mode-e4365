Imports Microsoft.VisualBasic
Imports System
Namespace Example
	Partial Public Class EditForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton2 = New DevExpress.XtraEditors.SimpleButton()
			Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.teComN = New DevExpress.XtraEditors.TextEdit()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.teConN = New DevExpress.XtraEditors.TextEdit()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.teAdd = New DevExpress.XtraEditors.TextEdit()
			Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.teC = New DevExpress.XtraEditors.TextEdit()
			Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.layoutControl1.SuspendLayout()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.teComN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.teConN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.teAdd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.teC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' simpleButton1
			' 
			Me.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.simpleButton1.Location = New System.Drawing.Point(52, 233)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(75, 23)
			Me.simpleButton1.TabIndex = 0
			Me.simpleButton1.Text = "OK"
			' 
			' simpleButton2
			' 
			Me.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.simpleButton2.Location = New System.Drawing.Point(142, 233)
			Me.simpleButton2.Name = "simpleButton2"
			Me.simpleButton2.Size = New System.Drawing.Size(75, 23)
			Me.simpleButton2.TabIndex = 1
			Me.simpleButton2.Text = "Cancel"
			' 
			' layoutControl1
			' 
			Me.layoutControl1.Controls.Add(Me.teC)
			Me.layoutControl1.Controls.Add(Me.teAdd)
			Me.layoutControl1.Controls.Add(Me.teConN)
			Me.layoutControl1.Controls.Add(Me.teComN)
			Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControl1.Name = "layoutControl1"
			Me.layoutControl1.Root = Me.layoutControlGroup1
			Me.layoutControl1.Size = New System.Drawing.Size(284, 227)
			Me.layoutControl1.TabIndex = 2
			Me.layoutControl1.Text = "layoutControl1"
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
			Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem1, Me.layoutControlItem2, Me.layoutControlItem3, Me.layoutControlItem4})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "layoutControlGroup1"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(284, 227)
			Me.layoutControlGroup1.Text = "layoutControlGroup1"
			Me.layoutControlGroup1.TextVisible = False
			' 
			' teComN
			' 
			Me.teComN.Location = New System.Drawing.Point(91, 12)
			Me.teComN.Name = "teComN"
			Me.teComN.Size = New System.Drawing.Size(181, 20)
			Me.teComN.StyleController = Me.layoutControl1
			Me.teComN.TabIndex = 4
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.teComN
			Me.layoutControlItem1.CustomizationFormText = "Company Name"
			Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(264, 24)
			Me.layoutControlItem1.Text = "Company Name"
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(75, 13)
			' 
			' teConN
			' 
			Me.teConN.Location = New System.Drawing.Point(91, 36)
			Me.teConN.Name = "teConN"
			Me.teConN.Size = New System.Drawing.Size(181, 20)
			Me.teConN.StyleController = Me.layoutControl1
			Me.teConN.TabIndex = 5
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.teConN
			Me.layoutControlItem2.CustomizationFormText = "Contact Name"
			Me.layoutControlItem2.Location = New System.Drawing.Point(0, 24)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(264, 24)
			Me.layoutControlItem2.Text = "Contact Name"
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(75, 13)
			' 
			' teAdd
			' 
			Me.teAdd.Location = New System.Drawing.Point(91, 60)
			Me.teAdd.Name = "teAdd"
			Me.teAdd.Size = New System.Drawing.Size(181, 20)
			Me.teAdd.StyleController = Me.layoutControl1
			Me.teAdd.TabIndex = 6
			' 
			' layoutControlItem3
			' 
			Me.layoutControlItem3.Control = Me.teAdd
			Me.layoutControlItem3.CustomizationFormText = "Address"
			Me.layoutControlItem3.Location = New System.Drawing.Point(0, 48)
			Me.layoutControlItem3.Name = "layoutControlItem3"
			Me.layoutControlItem3.Size = New System.Drawing.Size(264, 24)
			Me.layoutControlItem3.Text = "Address"
			Me.layoutControlItem3.TextSize = New System.Drawing.Size(75, 13)
			' 
			' teC
			' 
			Me.teC.Location = New System.Drawing.Point(91, 84)
			Me.teC.Name = "teC"
			Me.teC.Size = New System.Drawing.Size(181, 20)
			Me.teC.StyleController = Me.layoutControl1
			Me.teC.TabIndex = 7
			' 
			' layoutControlItem4
			' 
			Me.layoutControlItem4.Control = Me.teC
			Me.layoutControlItem4.CustomizationFormText = "Country"
			Me.layoutControlItem4.Location = New System.Drawing.Point(0, 72)
			Me.layoutControlItem4.Name = "layoutControlItem4"
			Me.layoutControlItem4.Size = New System.Drawing.Size(264, 135)
			Me.layoutControlItem4.Text = "Country"
			Me.layoutControlItem4.TextSize = New System.Drawing.Size(75, 13)
			' 
			' EditForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(284, 262)
			Me.Controls.Add(Me.layoutControl1)
			Me.Controls.Add(Me.simpleButton2)
			Me.Controls.Add(Me.simpleButton1)
			Me.Name = "EditForm"
			Me.Text = "EditForm"
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.layoutControl1.ResumeLayout(False)
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.teComN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.teConN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.teAdd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.teC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private simpleButton2 As DevExpress.XtraEditors.SimpleButton
		Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private teC As DevExpress.XtraEditors.TextEdit
		Private teAdd As DevExpress.XtraEditors.TextEdit
		Private teConN As DevExpress.XtraEditors.TextEdit
		Private teComN As DevExpress.XtraEditors.TextEdit
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
	End Class
End Namespace