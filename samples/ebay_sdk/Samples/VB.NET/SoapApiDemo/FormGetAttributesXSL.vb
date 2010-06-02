Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetAttributesXSL
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

		Friend WithEvents LblAttributeData As System.Windows.Forms.Label 

		Friend WithEvents TxtAttributeData As System.Windows.Forms.TextBox 

		Friend WithEvents BtnGetAttributesXSL As System.Windows.Forms.Button 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()


			Me.BtnGetAttributesXSL = new System.Windows.Forms.Button()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.TxtAttributeData = new System.Windows.Forms.TextBox()

			Me.LblAttributeData = new System.Windows.Forms.Label()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' BtnGetAttributesXSL

			' 

			Me.BtnGetAttributesXSL.Location = new System.Drawing.Point(200, 8)

			Me.BtnGetAttributesXSL.Name = "BtnGetAttributesXSL"

			Me.BtnGetAttributesXSL.Size = new System.Drawing.Size(128, 23)

			Me.BtnGetAttributesXSL.TabIndex = 9

			Me.BtnGetAttributesXSL.Text = "GetAttributesXSL"

        'Me.BtnGetAttributesXSL.Click += new System.EventHandler(Me.BtnGetAttributesXSL_Click)

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.TxtAttributeData)

			Me.GrpResult.Controls.Add(Me.LblAttributeData)

			Me.GrpResult.Location = new System.Drawing.Point(8, 40)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(504, 256)

			Me.GrpResult.TabIndex = 10

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Result"

			' 

			' TxtAttributeData

			' 

			Me.TxtAttributeData.Location = new System.Drawing.Point(24, 56)

			Me.TxtAttributeData.Multiline = true

			Me.TxtAttributeData.Name = "TxtAttributeData"

			Me.TxtAttributeData.ReadOnly = true

			Me.TxtAttributeData.Size = new System.Drawing.Size(456, 192)

			Me.TxtAttributeData.TabIndex = 74

			Me.TxtAttributeData.Text = ""

			' 

			' LblAttributeData

			' 

			Me.LblAttributeData.Location = new System.Drawing.Point(16, 24)

			Me.LblAttributeData.Name = "LblAttributeData"

			Me.LblAttributeData.Size = new System.Drawing.Size(475, 23)

			Me.LblAttributeData.TabIndex = 12

			Me.LblAttributeData.Text = "Attribute XSL:"

			' 

			' FrmGetAttributesXSL

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(520, 301)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetAttributesXSL)

			Me.Name = "FrmGetAttributesXSL"

			Me.Text = "GetAttributesXSL"

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)

   End Sub

#End Region


    Public Context As ApiContext

		Private Sub  BtnGetAttributesXSL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetAttributesXSL.Click

		

			Try

				Dim apicall As GetAttributesXSLCall = new GetAttributesXSLCall(Context)

            apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)



            Dim attfiles As XSLFileTypeCollection = apicall.GetAttributesXSL()

            GetAttributesXSLCall.DecodeFileContent(attfiles(0))

            TxtAttributeData.Text = attfiles(0).FileContent.Replace("\n", "\r\n")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class

