Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetAttributesCS
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer




		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents BtnGetAttributesCS As System.Windows.Forms.Button 

		Friend WithEvents LblAttributeData As System.Windows.Forms.Label 

		Friend WithEvents TxtAttributeData As System.Windows.Forms.TextBox 

		Friend WithEvents LblAttVersion As System.Windows.Forms.Label 

		Friend WithEvents TxtAttVersion As System.Windows.Forms.TextBox 

		Friend WithEvents LblAttSets As System.Windows.Forms.Label 

		Friend WithEvents TxtAttSets As System.Windows.Forms.TextBox 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnGetAttributesCS = New System.Windows.Forms.Button
        Me.GrpResult = New System.Windows.Forms.GroupBox
        Me.TxtAttributeData = New System.Windows.Forms.TextBox
        Me.LblAttributeData = New System.Windows.Forms.Label
        Me.LblAttVersion = New System.Windows.Forms.Label
        Me.TxtAttVersion = New System.Windows.Forms.TextBox
        Me.TxtAttSets = New System.Windows.Forms.TextBox
        Me.LblAttSets = New System.Windows.Forms.Label
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnGetAttributesCS
        '
        Me.BtnGetAttributesCS.Location = New System.Drawing.Point(200, 72)
        Me.BtnGetAttributesCS.Name = "BtnGetAttributesCS"
        Me.BtnGetAttributesCS.TabIndex = 9
        Me.BtnGetAttributesCS.Text = "GetAttributesCS"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.Add(Me.TxtAttributeData)
        Me.GrpResult.Controls.Add(Me.LblAttributeData)
        Me.GrpResult.Location = New System.Drawing.Point(8, 104)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(416, 248)
        Me.GrpResult.TabIndex = 10
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'TxtAttributeData
        '
        Me.TxtAttributeData.Location = New System.Drawing.Point(24, 56)
        Me.TxtAttributeData.Multiline = True
        Me.TxtAttributeData.Name = "TxtAttributeData"
        Me.TxtAttributeData.ReadOnly = True
        Me.TxtAttributeData.Size = New System.Drawing.Size(368, 176)
        Me.TxtAttributeData.TabIndex = 74
        Me.TxtAttributeData.Text = ""
        '
        'LblAttributeData
        '
        Me.LblAttributeData.Location = New System.Drawing.Point(16, 24)
        Me.LblAttributeData.Name = "LblAttributeData"
        Me.LblAttributeData.TabIndex = 12
        Me.LblAttributeData.Text = "Attribute CS Data:"
        '
        'LblAttVersion
        '
        Me.LblAttVersion.Location = New System.Drawing.Point(80, 16)
        Me.LblAttVersion.Name = "LblAttVersion"
        Me.LblAttVersion.TabIndex = 13
        Me.LblAttVersion.Text = "Attributes Version:"
        '
        'TxtAttVersion
        '
        Me.TxtAttVersion.Location = New System.Drawing.Point(208, 16)
        Me.TxtAttVersion.Name = "TxtAttVersion"
        Me.TxtAttVersion.TabIndex = 14
        Me.TxtAttVersion.Text = ""
        '
        'TxtAttSets
        '
        Me.TxtAttSets.Location = New System.Drawing.Point(208, 40)
        Me.TxtAttSets.Name = "TxtAttSets"
        Me.TxtAttSets.TabIndex = 16
        Me.TxtAttSets.Text = ""
        '
        'LblAttSets
        '
        Me.LblAttSets.Location = New System.Drawing.Point(80, 32)
        Me.LblAttSets.Name = "LblAttSets"
        Me.LblAttSets.Size = New System.Drawing.Size(120, 32)
        Me.LblAttSets.TabIndex = 15
        Me.LblAttSets.Text = "Attributes Sets (separate by comma):"
        '
        'FormGetAttributesCS
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 366)
        Me.Controls.Add(Me.TxtAttSets)
        Me.Controls.Add(Me.LblAttSets)
        Me.Controls.Add(Me.TxtAttVersion)
        Me.Controls.Add(Me.LblAttVersion)
        Me.Controls.Add(Me.GrpResult)
        Me.Controls.Add(Me.BtnGetAttributesCS)
        Me.Name = "FormGetAttributesCS"
        Me.Text = "GetAttributesCS"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext
		Private Sub  BtnGetAttributesCS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetAttributesCS.Click

		Try
				
            TxtAttributeData.Text = ""
            Dim apicall As GetAttributesCSCall = New GetAttributesCSCall(Context)
            apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)

            If TxtAttVersion.Text.Length > 0 Then
                apicall.AttributeVersion = TxtAttVersion.Text
            End If

            If TxtAttSets.Text.Length > 0 Then
                apicall.AttributeSetIDList = New Int32Collection()
                Dim atts() As String = TxtAttSets.Text.Split(",")
                Dim att As String
                For Each att In atts
                    apicall.AttributeSetIDList.Add(Convert.ToInt32(att))
                Next att
            End If

            Dim attdata As String = apicall.GetAttributesCS()
            TxtAttributeData.Text = attdata.Replace("\n", "\r\n")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class

