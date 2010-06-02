Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetProductFinder
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

		Friend WithEvents BtnGetProductFinder As System.Windows.Forms.Button 

		Friend WithEvents LblFinderVersion As System.Windows.Forms.Label 

		Friend WithEvents TxtFinderVersion As System.Windows.Forms.TextBox 

		Friend WithEvents TxtFinderSets As System.Windows.Forms.TextBox 

		Friend WithEvents LblFinderSets As System.Windows.Forms.Label 

		Friend WithEvents TxtFinderData As System.Windows.Forms.TextBox 

		Friend WithEvents LblFinderData As System.Windows.Forms.Label 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnGetProductFinder = New System.Windows.Forms.Button()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.TxtFinderData = New System.Windows.Forms.TextBox()
        Me.LblFinderData = New System.Windows.Forms.Label()
        Me.LblFinderVersion = New System.Windows.Forms.Label()
        Me.TxtFinderVersion = New System.Windows.Forms.TextBox()
        Me.TxtFinderSets = New System.Windows.Forms.TextBox()
        Me.LblFinderSets = New System.Windows.Forms.Label()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnGetProductFinder
        '
        Me.BtnGetProductFinder.Location = New System.Drawing.Point(200, 72)
        Me.BtnGetProductFinder.Name = "BtnGetProductFinder"
        Me.BtnGetProductFinder.Size = New System.Drawing.Size(128, 23)
        Me.BtnGetProductFinder.TabIndex = 9
        Me.BtnGetProductFinder.Text = "GetProductFinder"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.TxtFinderData, Me.LblFinderData})
        Me.GrpResult.Location = New System.Drawing.Point(8, 104)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(504, 256)
        Me.GrpResult.TabIndex = 10
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'TxtFinderData
        '
        Me.TxtFinderData.Location = New System.Drawing.Point(24, 56)
        Me.TxtFinderData.Multiline = True
        Me.TxtFinderData.Name = "TxtFinderData"
        Me.TxtFinderData.ReadOnly = True
        Me.TxtFinderData.Size = New System.Drawing.Size(456, 192)
        Me.TxtFinderData.TabIndex = 74
        Me.TxtFinderData.Text = ""
        '
        'LblFinderData
        '
        Me.LblFinderData.Location = New System.Drawing.Point(16, 24)
        Me.LblFinderData.Name = "LblFinderData"
        Me.LblFinderData.Size = New System.Drawing.Size(475, 23)
        Me.LblFinderData.TabIndex = 12
        Me.LblFinderData.Text = "Product Finder Data:"
        '
        'LblFinderVersion
        '
        Me.LblFinderVersion.Location = New System.Drawing.Point(80, 16)
        Me.LblFinderVersion.Name = "LblFinderVersion"
        Me.LblFinderVersion.Size = New System.Drawing.Size(128, 23)
        Me.LblFinderVersion.TabIndex = 13
        Me.LblFinderVersion.Text = "Finder Version:"
        '
        'TxtFinderVersion
        '
        Me.TxtFinderVersion.Location = New System.Drawing.Point(208, 16)
        Me.TxtFinderVersion.Name = "TxtFinderVersion"
        Me.TxtFinderVersion.TabIndex = 14
        Me.TxtFinderVersion.Text = ""
        '
        'TxtFinderSets
        '
        Me.TxtFinderSets.Location = New System.Drawing.Point(208, 40)
        Me.TxtFinderSets.Name = "TxtFinderSets"
        Me.TxtFinderSets.Size = New System.Drawing.Size(240, 20)
        Me.TxtFinderSets.TabIndex = 16
        Me.TxtFinderSets.Text = ""
        '
        'LblFinderSets
        '
        Me.LblFinderSets.Location = New System.Drawing.Point(16, 40)
        Me.LblFinderSets.Name = "LblFinderSets"
        Me.LblFinderSets.Size = New System.Drawing.Size(192, 23)
        Me.LblFinderSets.TabIndex = 15
        Me.LblFinderSets.Text = "Finder Id's (separate by comma):"
        '
        'FormGetProductFinder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 365)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TxtFinderSets, Me.LblFinderSets, Me.TxtFinderVersion, Me.LblFinderVersion, Me.GrpResult, Me.BtnGetProductFinder})
        Me.Name = "FormGetProductFinder"
        Me.Text = "GetProductFinder"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext

		Private Sub  BtnGetProductFinder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetProductFinder.Click

		

			Try

		
				TxtFinderData.Text = ""



				Dim apicall As GetProductFinderCall = new GetProductFinderCall(Context)

				apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)



				If TxtFinderVersion.Text <> String.Empty Then
					apicall.AttributeVersion = TxtFinderVersion.Text
				End If


				If TxtFinderSets.Text <> String.Empty Then
                apicall.ProductFinderIDList = New Int32Collection()

                Dim atts() As String = TxtFinderSets.Text.Split(",")
                Dim att As String

                For Each att In atts
                    apicall.ProductFinderIDList.Add(Convert.ToInt32(att))
                Next att

            End If



				Dim finderdata As String = apicall.GetProductFinder()

            If Not finderdata Is Nothing Then
                TxtFinderData.Text = finderdata.Replace("\n", "\r\n")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class


