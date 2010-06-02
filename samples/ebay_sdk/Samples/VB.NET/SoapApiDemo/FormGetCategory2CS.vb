Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetCategory2CS
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

		Friend WithEvents LblCategories As System.Windows.Forms.Label 

		Friend WithEvents LstCategories As System.Windows.Forms.ListView 

		Friend WithEvents ClmCatId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents BtnGetCategory2CS As System.Windows.Forms.Button 

		Friend WithEvents LblCategory As System.Windows.Forms.Label 

		Friend WithEvents TxtCategory As System.Windows.Forms.TextBox 

		Friend WithEvents ClmCharName As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmCharId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmCatEnabled As System.Windows.Forms.ColumnHeader 


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()




        Me.BtnGetCategory2CS = New System.Windows.Forms.Button()

        Me.GrpResult = New System.Windows.Forms.GroupBox()

        Me.LblCategories = New System.Windows.Forms.Label()

        Me.LstCategories = New System.Windows.Forms.ListView()

        Me.ClmCatId = New System.Windows.Forms.ColumnHeader()

        Me.ClmCharName = New System.Windows.Forms.ColumnHeader()

        Me.ClmCharId = New System.Windows.Forms.ColumnHeader()

        Me.ClmCatEnabled = New System.Windows.Forms.ColumnHeader()

        Me.LblCategory = New System.Windows.Forms.Label()

        Me.TxtCategory = New System.Windows.Forms.TextBox()

        Me.GrpResult.SuspendLayout()

        Me.SuspendLayout()

        ' 

        ' BtnGetCategory2CS

        ' 

        Me.BtnGetCategory2CS.Location = New System.Drawing.Point(200, 48)

        Me.BtnGetCategory2CS.Name = "BtnGetCategory2CS"

        Me.BtnGetCategory2CS.Size = New System.Drawing.Size(128, 23)

        Me.BtnGetCategory2CS.TabIndex = 9

        Me.BtnGetCategory2CS.Text = "GetCategory2CS"

        'Me.BtnGetCategory2CS.Click += new System.EventHandler(Me.BtnGetCategory2CS_Click)

        ' 

        ' GrpResult

        ' 

        Me.GrpResult.Controls.Add(Me.LblCategories)

        Me.GrpResult.Controls.Add(Me.LstCategories)

        Me.GrpResult.Location = New System.Drawing.Point(8, 80)

        Me.GrpResult.Name = "GrpResult"

        Me.GrpResult.Size = New System.Drawing.Size(504, 280)

        Me.GrpResult.TabIndex = 10

        Me.GrpResult.TabStop = False

        Me.GrpResult.Text = "Result"

        ' 

        ' LblCategories

        ' 

        Me.LblCategories.Location = New System.Drawing.Point(16, 24)

        Me.LblCategories.Name = "LblCategories"

        Me.LblCategories.Size = New System.Drawing.Size(475, 23)

        Me.LblCategories.TabIndex = 12

        Me.LblCategories.Text = "Category CS:"

        ' 

        ' LstCategories

        ' 

        Me.LstCategories.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmCatId, Me.ClmCharName, Me.ClmCharId, Me.ClmCatEnabled})

        Me.LstCategories.GridLines = True

        Me.LstCategories.Location = New System.Drawing.Point(16, 48)

        Me.LstCategories.Name = "LstCategories"

        Me.LstCategories.Size = New System.Drawing.Size(480, 264)

        Me.LstCategories.TabIndex = 13

        Me.LstCategories.View = System.Windows.Forms.View.Details

        ' 

        ' ClmCatId

        ' 

        Me.ClmCatId.Text = "Category Id"

        Me.ClmCatId.Width = 69

        ' 

        ' ClmCharName

        ' 

        Me.ClmCharName.Text = "Characteristic Name"

        Me.ClmCharName.Width = 120

        ' 

        ' ClmCharId

        ' 

        Me.ClmCharId.Text = "Characteristic Id"

        Me.ClmCharId.Width = 94

        ' 

        ' ClmCatEnabled

        ' 

        Me.ClmCatEnabled.Text = "Catalog Enabled"

        Me.ClmCatEnabled.Width = 94

        ' 

        ' 

        ' LblCategory

        ' 

        Me.LblCategory.Location = New System.Drawing.Point(112, 16)

        Me.LblCategory.Name = "LblCategory"

        Me.LblCategory.Size = New System.Drawing.Size(96, 23)

        Me.LblCategory.TabIndex = 13

        Me.LblCategory.Text = "Category Id:"

        ' 

        ' TxtCategory

        ' 

        Me.TxtCategory.Location = New System.Drawing.Point(208, 16)

        Me.TxtCategory.Name = "TxtCategory"

        Me.TxtCategory.TabIndex = 14

        Me.TxtCategory.Text = ""

        ' 

        ' FrmGetCategory2CS

        ' 

        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)

        Me.ClientSize = New System.Drawing.Size(520, 365)

        Me.Controls.Add(Me.TxtCategory)

        Me.Controls.Add(Me.LblCategory)

        Me.Controls.Add(Me.GrpResult)

        Me.Controls.Add(Me.BtnGetCategory2CS)

        Me.Name = "FrmGetCategory2CS"

        Me.Text = "GetCategory2CSForm"

        Me.GrpResult.ResumeLayout(False)

        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext

		Private Sub  BtnGetCategory2CS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetCategory2CS.Click

			Try

				LstCategories.Items.Clear()

				Dim apicall As GetCategory2CSCall = new GetCategory2CSCall(Context)

				apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)

            If (TxtCategory.Text.Length > 0) Then
                apicall.CategoryID = TxtCategory.Text
            End If

            Dim cats As CategoryTypeCollection = apicall.GetCategory2CS()
            Dim category As CategoryType

            For Each category In cats
                Dim listparams(5) As String

                listparams(0) = category.CategoryID

                listparams(1) = category.CharacteristicsSets(0).Name

                listparams(2) = category.CharacteristicsSets(0).AttributeSetID.ToString()

                listparams(3) = category.CatalogEnabled.ToString()

                Dim vi As ListViewItem = New ListViewItem(listparams)

                Me.LstCategories.Items.Add(vi)
            Next category


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class


