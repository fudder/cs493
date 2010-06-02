Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetProductSearchPage
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

		Friend WithEvents BtnGetProductSearchPage As System.Windows.Forms.Button 

		Friend WithEvents LblSearchPageVersion As System.Windows.Forms.Label 

		Friend WithEvents TxtSearchPageVersion As System.Windows.Forms.TextBox 

		Friend WithEvents TxtSearchPageSets As System.Windows.Forms.TextBox 

		Friend WithEvents LblSearchPageSets As System.Windows.Forms.Label 



		Friend WithEvents LblSearchPageData As System.Windows.Forms.Label 
    Friend WithEvents LstItems As System.Windows.Forms.ListView
    Friend WithEvents ClmAttrId As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmDisplaySeq As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClmName As System.Windows.Forms.ColumnHeader


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnGetProductSearchPage = New System.Windows.Forms.Button()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblSearchPageData = New System.Windows.Forms.Label()
        Me.LblSearchPageVersion = New System.Windows.Forms.Label()
        Me.TxtSearchPageVersion = New System.Windows.Forms.TextBox()
        Me.TxtSearchPageSets = New System.Windows.Forms.TextBox()
        Me.LblSearchPageSets = New System.Windows.Forms.Label()
        Me.LstItems = New System.Windows.Forms.ListView()
        Me.ClmAttrId = New System.Windows.Forms.ColumnHeader()
        Me.ClmDisplaySeq = New System.Windows.Forms.ColumnHeader()
        Me.ClmName = New System.Windows.Forms.ColumnHeader()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnGetProductSearchPage
        '
        Me.BtnGetProductSearchPage.Location = New System.Drawing.Point(200, 72)
        Me.BtnGetProductSearchPage.Name = "BtnGetProductSearchPage"
        Me.BtnGetProductSearchPage.Size = New System.Drawing.Size(152, 23)
        Me.BtnGetProductSearchPage.TabIndex = 9
        Me.BtnGetProductSearchPage.Text = "GetProductSearchPage"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.LstItems, Me.LblSearchPageData})
        Me.GrpResult.Location = New System.Drawing.Point(8, 104)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(504, 320)
        Me.GrpResult.TabIndex = 10
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'LblSearchPageData
        '
        Me.LblSearchPageData.Location = New System.Drawing.Point(16, 24)
        Me.LblSearchPageData.Name = "LblSearchPageData"
        Me.LblSearchPageData.Size = New System.Drawing.Size(160, 23)
        Me.LblSearchPageData.TabIndex = 12
        Me.LblSearchPageData.Text = "Product Search Page Data:"
        '
        'LblSearchPageVersion
        '
        Me.LblSearchPageVersion.Location = New System.Drawing.Point(112, 16)
        Me.LblSearchPageVersion.Name = "LblSearchPageVersion"
        Me.LblSearchPageVersion.Size = New System.Drawing.Size(128, 23)
        Me.LblSearchPageVersion.TabIndex = 13
        Me.LblSearchPageVersion.Text = "Attributes Version:"
        '
        'TxtSearchPageVersion
        '
        Me.TxtSearchPageVersion.Location = New System.Drawing.Point(240, 16)
        Me.TxtSearchPageVersion.Name = "TxtSearchPageVersion"
        Me.TxtSearchPageVersion.TabIndex = 14
        Me.TxtSearchPageVersion.Text = ""
        '
        'TxtSearchPageSets
        '
        Me.TxtSearchPageSets.Location = New System.Drawing.Point(240, 40)
        Me.TxtSearchPageSets.Name = "TxtSearchPageSets"
        Me.TxtSearchPageSets.Size = New System.Drawing.Size(240, 20)
        Me.TxtSearchPageSets.TabIndex = 16
        Me.TxtSearchPageSets.Text = ""
        '
        'LblSearchPageSets
        '
        Me.LblSearchPageSets.Location = New System.Drawing.Point(32, 40)
        Me.LblSearchPageSets.Name = "LblSearchPageSets"
        Me.LblSearchPageSets.Size = New System.Drawing.Size(208, 23)
        Me.LblSearchPageSets.TabIndex = 15
        Me.LblSearchPageSets.Text = "Characteristic Ids (separate by comma):"
        '
        'LstItems
        '
        Me.LstItems.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.LstItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmAttrId, Me.ClmDisplaySeq, Me.ClmName})
        Me.LstItems.GridLines = True
        Me.LstItems.Location = New System.Drawing.Point(16, 40)
        Me.LstItems.Name = "LstItems"
        Me.LstItems.Size = New System.Drawing.Size(440, 264)
        Me.LstItems.TabIndex = 13
        Me.LstItems.View = System.Windows.Forms.View.Details
        '
        'ClmAttrId
        '
        Me.ClmAttrId.Text = "Attribute ID"
        Me.ClmAttrId.Width = 80
        '
        'ClmDisplaySeq
        '
        Me.ClmDisplaySeq.Text = "Display Seq"
        Me.ClmDisplaySeq.Width = 173
        '
        'ClmName
        '
        Me.ClmName.Text = "Name"
        '
        'FormGetProductSearchPage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 438)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TxtSearchPageSets, Me.LblSearchPageSets, Me.TxtSearchPageVersion, Me.LblSearchPageVersion, Me.GrpResult, Me.BtnGetProductSearchPage})
        Me.Name = "FormGetProductSearchPage"
        Me.Text = "GetProductSearchPage"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext


    Private Sub BtnGetProductSearchPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetProductSearchPage.Click

        Try
            LstItems.Items.Clear()

            Dim ApiCall As GetProductSearchPageCall = New GetProductSearchPageCall(Context)

            ApiCall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)

            If TxtSearchPageVersion.Text <> String.Empty Then
                ApiCall.AttributeVersion = TxtSearchPageVersion.Text
            End If

            If TxtSearchPageSets.Text <> String.Empty Then
                ApiCall.AttributeSetIDList = New Int32Collection()
                Dim attrs() As String = TxtSearchPageSets.Text.Split(",")
                Dim attr As String

                For Each attr In attrs
                    ApiCall.AttributeSetIDList.Add(Convert.ToInt32(attr))
                Next attr
            End If

            Dim spages As ProductSearchPageTypeCollection = ApiCall.GetProductSearchPage()
            Dim page As ProductSearchPageType
            For Each page In spages
                Dim val As CharacteristicType
                For Each val In page.SearchCharacteristicsSet.Characteristics
                    Dim listparams(3) As String
                    listparams(0) = val.AttributeID.ToString()
                    listparams(1) = val.DisplaySequence
                    listparams(2) = val.Label.Name
                    Dim vi As ListViewItem = New ListViewItem(listparams)

                    LstItems.Items.Add(vi)
                Next val
            Next page

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub TxtSearchPageData_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class

